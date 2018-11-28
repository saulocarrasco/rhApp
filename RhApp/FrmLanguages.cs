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
    public partial class FrmLanguages : Form
    {
        private RhDataService _rhDataService;
        public FrmLanguages(RhDataService rhDataService)
        {
            _rhDataService = rhDataService;
            InitializeComponent();
            var records = _rhDataService.GetAll<Language>().ToList();
            LstLanguages.DataSource = records;
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
                    var language = new Language
                    {
                        Name = txtNameCpt.Text,
                        Status = ObjectStatus.Enable
                    };

                    _rhDataService.Add(language);
                }

                var result = _rhDataService.Save();

                if (result > 0)
                {
                    MessageBox.Show("El idioma se guardo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var records = _rhDataService.GetAll<Language>().ToList();
            LstLanguages.DataSource = records;
            txtNameCpt.Text = "";
            txtId.Text = "";
        }

        private void Update()
        {
            var id = Convert.ToInt32(txtId.Text);
            var language = _rhDataService.GetAll<Language>().FirstOrDefault(i => i.Id == id);
            language.Name = txtNameCpt.Text;

            try
            {
                _rhDataService.Update(language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmdEdit_Click(object sender, EventArgs e)
        {
            if (LstLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el idioma para editar");
                return;
            }

            
            var row = LstLanguages.SelectedRows[0];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtNameCpt.Text = row.Cells["Name"].Value.ToString();
        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = LstLanguages.SelectedRows;


            if (LstLanguages.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar el registro que desea borrar.");

                return;
            }

            var id = Convert.ToInt32(LstLanguages.SelectedRows[0].Cells["Id"].Value);
            var language = _rhDataService.GetAll<Language>().FirstOrDefault(i => i.Id == id);

            language.Status = ObjectStatus.Disabled;

            _rhDataService.Update(language);
            _rhDataService.Save();

            MessageBox.Show("El idioma fue Eliminado correctamente.");

            LstLanguages.DataSource = _rhDataService.GetAll<Language>().ToList();

            txtId.Text = "";
            txtNameCpt.Text = "";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNameCpt.Text = "";
            LstLanguages.ClearSelection();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Escriba el valor que desea buscar.");
                return;
            }

            var filter = _rhDataService.GetAll<Language>().Where(i => i.Name.ToUpper().StartsWith(txtSearch.Text.ToUpper()));

            if (filter.Count() > 0)
            {
                LstLanguages.DataSource = filter.ToList();
            }
            else
            {
                MessageBox.Show("No hay resultados para su busqueda.");
                LstLanguages.DataSource = _rhDataService.GetAll<Language>().ToList();
            }

            txtSearch.Text = "";
        }

        private void LstLanguages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstLanguages.Rows[e.RowIndex].Selected = true;
        }
    }
}
