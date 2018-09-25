using Data;
using Data.Repository;
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
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            var competition = new Competition
            {
                Name = txtNameCpt.Text,
                Description = txtDescription.Text,
                Status = CompetitionStatus.Enable
            };

            try
            {
                _service.Add(competition);
                var result = _service.Save();

                if(result > 0)
                {
                    MessageBox.Show("La competencia se guardo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LstCpts.DataSource = _service.GetAll<Competition>().ToList();
        }

        private void CmdEdit_Click(object sender, EventArgs e)
        {
            if(LstCpts.SelectedRows.Count < 0)
            {
                MessageBox.Show("Debe seleccionar la competencia ha editar");
                return;
            }

            var competition = new Competition
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtNameCpt.Text,
                Description = txtDescription.Text,
                Status = CompetitionStatus.Enable
            };

            try
            {
                _service.Update(competition);
                _service.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LstCpts.DataSource = _service.GetAll<Competition>().ToList();

        }

        private void LstCpts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = LstCpts.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtNameCpt.Text = row.Cells[1].Value.ToString();
            txtDescription.Text = row.Cells[2].Value.ToString();
        }
    }
}
