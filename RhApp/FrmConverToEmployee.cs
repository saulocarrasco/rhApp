using Data;
using Data.Model;
using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    public partial class FrmConverToEmployee : Form
    {
        private RhDataService _service;
        public FrmConverToEmployee(RhDataService rhDataService)
        {
            InitializeComponent();

            _service = rhDataService;

            LstCandidates.DataSource = _service.GetAll<Candidate>().ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Ingrese un valor de busqueda");
                return;
            }

            var result = _service.GetAll<Candidate>().Where(i => i.IdentificationNumber.StartsWith(txtSearch.Text) || i.Name.StartsWith(txtSearch.Text)).ToList();
            LstCandidates.DataSource = result;
        }

        private void LstCandidates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            LstCandidates.Rows[e.RowIndex].Selected = true;
        }

        private void btnConvertEmployee_Click(object sender, EventArgs e)
        {
            if(LstCandidates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el candidato que quiere dar de alta");
                return;
            }

            var row = LstCandidates.SelectedRows[0];

            var id = Convert.ToInt32(row.Cells["Id"].Value);

            var candidate = _service.GetAll<Candidate>().FirstOrDefault(i=>i.Id == id);

            var positionInDb = _service.GetAll<JobPosition>().FirstOrDefault(i=>i.Name == candidate.AspirePosition);

            var employee = new Employee{

                DateJoin = DateTime.UtcNow.AddHours(-4),
                Department = candidate.Department,
                JobPosition = positionInDb.Name,
                Name = candidate.Name,
                IdentificationNumber = candidate.IdentificationNumber,
                Languages = candidate.Languages,
                Salary = positionInDb.MinSalary,
                Status = ObjectStatus.Enable
            };

            try
            {
                _service.Add(employee);

                candidate.Status = ObjectStatus.Disabled;
                _service.Update(candidate);

                _service.Save();
                MessageBox.Show("Empleado en alta satisfactoriamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en conexion");
            }

            this.Close();
            
        }

        private void cbxFilterType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbxFilterType.SelectedIndex)
            {
                case 1:
                    FillJobPosition();
                    break;
                case 2:
                    FillCompetition();
                    break;
                case 3:
                    FillTraining();
                    break;
                case 4:
                    ActiveSearchText();
                    break;
            }
        }

        private void ActiveSearchText()
        {
            txtSearch.Visible = true;
            cbxValue.Visible = false;
        }

        private void FillTraining()
        {
            cbxValue.ValueMember = "Id";
            cbxValue.DisplayMember = "Description";
            cbxValue.DataSource = _service.GetAll<Training>().ToList();
            cbxValue.SelectedIndex = -1;
            cbxValue.Visible = true;
            txtSearch.Visible = false;
        }

        private void FillJobPosition()
        {
            cbxValue.ValueMember = "Id";
            cbxValue.DisplayMember = "Name";
            cbxValue.DataSource = _service.GetAll<JobPosition>().ToList();
            cbxValue.SelectedIndex = -1;
            cbxValue.Visible = true;
            txtSearch.Visible = false;
        }

        private void FillCompetition()
        {
            cbxValue.ValueMember = "Id";
            cbxValue.DisplayMember = "Name";
            cbxValue.DataSource = _service.GetAll<Competition>().ToList();
            cbxValue.SelectedIndex = -1;
            cbxValue.Visible = true;
            txtSearch.Visible = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            if(cbxFilterType.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione un criterio de búsqueda");
                return;
            }

            if(cbxFilterType.SelectedIndex == 4)
            {
                if(string.IsNullOrEmpty(txtSearch.Text))
                {
                    MessageBox.Show("Ingrese un valor de búsqueda");
                    return;
                }

                var result = _service.GetAll<Candidate>().Where(i => i.IdentificationNumber.StartsWith(txtSearch.Text) || i.Name.StartsWith(txtSearch.Text)).ToList();
                LstCandidates.DataSource = result;
            }
            else
            {
                var valueSearch = cbxValue.GetItemText(cbxValue.SelectedItem);

                if (string.IsNullOrEmpty(valueSearch))
                {
                    MessageBox.Show("Ingrese un valor del criterio de búsqueda");
                    return;
                }

                CriticalSearch(cbxFilterType.SelectedIndex, valueSearch);
            }
        }

        private void CriticalSearch(int key, string value)
        {
            switch (cbxFilterType.SelectedIndex)
            {
                case 1:
                    SearchByJobPosition(value);
                    break;
                case 2:
                    SearchByCompetition(value);
                    break;
                case 3:
                    SearchByTraining(value);
                    break;
            }
        }

        private void SearchByTraining(string value)
        {
            var candidate = _service.GetAll<Candidate>().Where(i => i.Trainings.Where(b => b.Description.Equals(value)).Count() > 0);

            LstCandidates.DataSource = candidate.ToList(); ;
        }

        private void SearchByCompetition(string value)
        {
            var candidate = _service.GetAll<Candidate>().Where(i => i.Competitions.Where(b => b.Name.Equals(value)).Count() > 0);

            LstCandidates.DataSource = candidate.ToList(); ;
        }

        private void SearchByJobPosition(string value)
        {
            var candidate = _service.GetAll<Candidate>().Where(i => i.AspirePosition.Equals(value));

            LstCandidates.DataSource = candidate.ToList();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            LstCandidates.DataSource = _service.GetAll<Candidate>().ToList();
        }
    }
}
