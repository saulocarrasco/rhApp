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
    public partial class FrmPositions : Form
    {
        private RhDataService _rhDataService;
        public FrmPositions(RhDataService rhDataService)
        {
            InitializeComponent();
            _rhDataService = rhDataService;
            LstPositions.DataSource = _rhDataService.GetAll<JobPosition>().ToList();
            txtMaxSalary.Maximum = Decimal.MaxValue;
            txtMinSalary.Maximum = Decimal.MaxValue;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Update()
        {
            var minSalary = Convert.ToDecimal(txtMinSalary.Text);
            var maxSalary = Convert.ToDecimal(txtMaxSalary.Text);

            var position = _rhDataService.GetAll<JobPosition>().FirstOrDefault(i => i.Id == Convert.ToInt32(txtId.Text));
            position.Name = txtName.Text;
            position.RiskLevel = ((RiskLevel)(cbxRisk.SelectedIndex + 1));
            position.Status = ObjectStatus.Enable;
            position.MaxSalary = maxSalary;
            position.MinSalary = minSalary;
            _rhDataService.Update(position);

        }

        private void CmdSave_Click(object sender, EventArgs e)
        {

            try
            {
                var minSalary = Convert.ToDecimal(txtMinSalary.Text);
                var maxSalary = Convert.ToDecimal(txtMaxSalary.Text);

                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    Update();
                }
                else
                {    
                    var position = new JobPosition();
                    position.Name = txtName.Text;
                    position.RiskLevel = ((RiskLevel)(cbxRisk.SelectedIndex + 1));
                    position.Status = ObjectStatus.Enable;
                    position.MaxSalary = maxSalary;
                    position.MinSalary = minSalary;

                    _rhDataService.Add(position);
                }

                if (minSalary > maxSalary)
                {
                    MessageBox.Show("El salario maximo, no puede ser menor que el salario minimo");
                    return;
                }

                var result = _rhDataService.Save();

                if (result > 0)
                {
                    MessageBox.Show("La Posicion se guardo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            ClearFormData();
            LstPositions.DataSource = _rhDataService.GetAll<JobPosition>().ToList();
        }

        private void CmdEdit_Click(object sender, EventArgs e)
        {
            if(LstPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la posicion para editar.");
                return;
            }
            var row = LstPositions.SelectedRows[0];
            txtId.Text = row.Cells["Id"].Value.ToString();

            txtName.Text = row.Cells["Name"].Value.ToString();
            txtMaxSalary.Text = row.Cells["MaxSalary"].Value.ToString();
            txtMinSalary.Text = row.Cells["MinSalary"].Value.ToString();

            var riskLevel = row.Cells["RiskLevel"].Value.ToString();
            var checkResult = GetTextOfRiskLevel(riskLevel);

            cbxRisk.SelectedIndex = checkResult;

        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = LstPositions.SelectedRows;

            if (LstPositions.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar el registro que desea borrar.");

                return;
            }

            var jobPositionId = Convert.ToInt32(rowSelected[0].Cells["Id"].Value.ToString());

            var jobPosition = _rhDataService.GetAll<JobPosition>().FirstOrDefault(i => i.Id == jobPositionId);
            jobPosition.Status = ObjectStatus.Disabled;

            _rhDataService.Update(jobPosition);
            _rhDataService.Save();

            MessageBox.Show("Posicion Eliminada correctamente.");

            LstPositions.DataSource = _rhDataService.GetAll<JobPosition>().ToList();

            ClearFormData();
        }

        public void ClearFormData()
        {
            txtId.Text = "";
            txtMaxSalary.Value = 0;
            txtMinSalary.Value = 0;
            txtSearch.Text = "";
            txtName.Text = "";
            cbxRisk.SelectedIndex = -1;
            LstPositions.ClearSelection();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private int GetTextOfRiskLevel(string trainingGrade)
        {
            switch (trainingGrade)
            {
                case "High":
                    return 0;
                case "Medium":
                    return 1;
                case "Low":
                    return 2;
                default:
                    return -1;
            }
        }

        private void LstPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstPositions.Rows[e.RowIndex].Selected = true;
        }
    }
}
