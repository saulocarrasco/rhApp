using Data;
using Data.Repository;
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
    public partial class FrmCompetitions : Form
    {
        private RhDataService _service;

        public FrmCompetitions(RhDataService service)
        {
            _service = service;

            InitializeComponent();
            LstCpts.DataSource = _service.GetAll<Competition>().ToList();
            LstCpts.AutoGenerateColumns = false;
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {

            try
            {
                if(!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    Update();
                }
                else
                {
                    var competition = new Competition
                    {
                        Name = txtNameCpt.Text,
                        Description = txtDescription.Text,
                        Status = ObjectStatus.Enable
                    };

                    _service.Add(competition);
                }
                
                var result = _service.Save();

                if (result > 0)
                {
                    MessageBox.Show("La competencia se guardo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LstCpts.DataSource = _service.GetAll<Competition>().ToList();

            ClearInputs();
        }

        private void CmdEdit_Click(object sender, EventArgs e)
        {
            if (LstCpts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la competencia ha editar");
                return;
            }

            var row = LstCpts.SelectedRows[0];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtNameCpt.Text = row.Cells["Name"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();
        }

        private void Update()
        {

            if (LstCpts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la competencia ha editar");
                return;
            }

            var id = Convert.ToInt32(txtId.Text);
            var competition = _service.GetAll<Competition>().FirstOrDefault(i => i.Id == id);
            competition.Name = txtNameCpt.Text;
            competition.Description = txtDescription.Text;
            competition.Status = ObjectStatus.Enable;

            try
            {
                _service.Update(competition);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = LstCpts.SelectedRows;


            if (LstCpts.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar el registro que desea borrar.");

                return;
            }

            var id = Convert.ToInt32(LstCpts.SelectedRows[0].Cells["Id"].Value);
            var competition = _service.GetAll<Competition>().FirstOrDefault(i => i.Id == id);
            competition.Status = ObjectStatus.Disabled;

            _service.Update(competition);
            _service.Save();

            MessageBox.Show("Competencia Eliminada correctamente.");

            LstCpts.DataSource = _service.GetAll<Competition>().ToList();

            ClearInputs();
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Escriba el valor que desea buscar.");
                return;
            }

            var filter = _service.GetAll<Competition>().Where(i => i.Name.ToUpper().StartsWith(txtSearch.Text.ToUpper()) || i.Description.ToUpper().StartsWith(txtSearch.Text.ToUpper()));

            if(filter.Count() > 0)
            {
                LstCpts.DataSource = filter.ToList();
            }
            else
            {
                LstCpts.DataSource = _service.GetAll<Competition>().ToList();
                MessageBox.Show("No hay resultados para su busqueda.");
            }

            txtSearch.Text = "";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtId.Text = "";
            txtNameCpt.Text = "";
            txtDescription.Text = "";
            LstCpts.ClearSelection();
        }

        private void LstCpts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstCpts.Rows[e.RowIndex].Selected = true;
        }
    }
}
