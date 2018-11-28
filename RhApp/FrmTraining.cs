using Data.Model;
using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    public partial class FrmTraining : Form
    {
        private RhDataService _rhDataService;
        public FrmTraining(RhDataService rhDataService)
        {
            _rhDataService = rhDataService;
            InitializeComponent();
            txtStartDate.Value = DateTime.UtcNow.AddHours(-4);
            txtStartDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            txtToDate.Value = DateTime.UtcNow.AddHours(-4);
            txtToDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            LstTrainings.DataSource = _rhDataService.GetAll<Training>().ToList();
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
                    var training = new Training
                    {
                        Description = txtDescription.Text,
                        From = txtStartDate.Value,
                        To = txtToDate.Value,
                        Level = ((LevelTraining)(cbxLevel.SelectedIndex + 1)),
                        Institution = txtInstitution.Text,
                        Status = ObjectStatus.Enable
                    };

                    _rhDataService.Add(training);
                }

                if (txtStartDate.Value >= txtToDate.Value)
                {
                    MessageBox.Show("La fecha final debe ser mayor a la fecha de inicio.");
                    return;
                }

                var result =_rhDataService.Save();

                if (result > 0)
                {
                    MessageBox.Show("La Capacitacion se guardo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            ClearFormData();
            LstTrainings.DataSource = _rhDataService.GetAll<Training>().ToList();
        }

        private void ClearFormData()
        {
            txtId.Text = "";
            txtDescription.Text = "";
            txtInstitution.Text = "";
            txtSearch.Text = "";
            txtStartDate.Value = DateTime.UtcNow.AddHours(-4);
            txtToDate.Value = DateTime.UtcNow.AddHours(-4);
            cbxLevel.SelectedIndex = -1;
            LstTrainings.ClearSelection();

        }

        private void CmdEdit_Click(object sender, EventArgs e)
        {
            
            if (LstTrainings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la competencia ha editar");
                return;
            }
            var row = LstTrainings.SelectedRows[0];

            txtId.Text = row.Cells["Id"].Value.ToString();
            //cbxLevel.SelectedText = row.Cells[5].Value.ToString();

            var startDate = Convert.ToDateTime(row.Cells["From"].Value);
            var endDate = Convert.ToDateTime(row.Cells["To"].Value);

            txtStartDate.Value = startDate;
            txtToDate.Value = endDate;

            txtInstitution.Text = row.Cells["Institution"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();

            var trainingGrade = row.Cells["Level"].Value.ToString();
            var checkResult = GetTextOfLevel(trainingGrade);


            cbxLevel.SelectedIndex = checkResult;
        }

        private void Update()
        {
            var oldTraining = _rhDataService.GetAll<Training>().FirstOrDefault(i => i.Id == Convert.ToInt32(txtId.Text));
            oldTraining.Description = txtDescription.Text;
            oldTraining.From = txtStartDate.Value;
            oldTraining.To = txtToDate.Value;
            oldTraining.Level = ((LevelTraining)(cbxLevel.SelectedIndex + 1));
            oldTraining.Institution = txtInstitution.Text;

            try
            {
                _rhDataService.Update(oldTraining);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private int GetTextOfLevel(string trainingGrade)
        {
            switch (trainingGrade)
            {
                case "Grade":
                    return 0;
                case "PostGrade":
                    return 1;
                case "Master":
                   return 2;
                case "PHD":
                    return 3;
                case "Technical":
                    return 4;
                case "Management":
                    return 5;
                default:
                    return -1;
            }
        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = LstTrainings.SelectedRows;


            if (LstTrainings.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar el registro que desea borrar.");

                return;
            }

            var trainingId = Convert.ToInt32(rowSelected[0].Cells[0].Value.ToString());

            var training = _rhDataService.GetAll<Training>().FirstOrDefault(i=>i.Id == trainingId);
            training.Status = ObjectStatus.Disabled;

            _rhDataService.Update(training);
            _rhDataService.Save();

            MessageBox.Show("Capacitacion Eliminada correctamente.");

            LstTrainings.DataSource = _rhDataService.GetAll<Training>().ToList();

            ClearFormData();
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Escriba el valor que desea buscar.");
                return;
            }

            var filter = _rhDataService.GetAll<Training>().Where(i => i.Institution.ToUpper().StartsWith(txtSearch.Text.ToUpper()) || i.Description.ToUpper().StartsWith(txtSearch.Text.ToUpper()));

            if (filter.Count() > 0)
            {
                LstTrainings.DataSource = filter.ToList();
            }
            else
            {
                LstTrainings.DataSource = _rhDataService.GetAll<Training>().ToList();
                MessageBox.Show("No hay resultados para su busqueda.");
            }

            txtSearch.Text = "";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private void LstTrainings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstTrainings.Rows[e.RowIndex].Selected = true;
        }
    }
}
