using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    public partial class FrmCandidate : Form
    {
        private RhDataService _rhDataService;
        private BindingSource _competitionSource;
        private BindingSource _capcitationSource;
        private BindingSource _experiencesSource;
        private BindingSource _languageSource;

        public FrmCandidate(RhDataService rhDataService)
        {
           // Expression<Func<BindingSource, bool>> expr = x => x.Count == 1;

            InitializeComponent();
            _rhDataService = rhDataService;
            FillCombos();
            txtFrom.Value = DateTime.UtcNow.AddHours(-4);
            txtFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            txtTo.Value = DateTime.UtcNow.AddHours(-4);
            txtTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            _competitionSource = new BindingSource();
            _capcitationSource = new BindingSource();
            _experiencesSource = new BindingSource();
            _languageSource = new BindingSource();
            salaryLike.Maximum = Decimal.MaxValue;
            txtOldSalary.Maximum = Decimal.MaxValue;
        }

        private void FillCombos()
        {
            var competitions = _rhDataService.GetAll<Competition>().ToList();
            competitions.Insert(0, new Competition { Id = 0, Name = "Elegir" });
            cbxCompetition.DataSource = competitions;
            cbxCompetition.ValueMember = "Id";
            cbxCompetition.DisplayMember = "Name";


            //var capacitations = _rhDataService.GetAll<Training>().ToList();
            //capacitations.Insert(0, new Training { Id = 0, Description = "Elegir"});
            //cbxCapacitaciones.DataSource = capacitations;
            //cbxCapacitaciones.ValueMember = "Id";
            //cbxCapacitaciones.DisplayMember = "Description";

            var languages = _rhDataService.GetAll<Language>().ToList();
            languages.Insert(0, new Language { Id = 0, Name = "Elegir" });
            cbxLanguages.DataSource = languages;
            cbxLanguages.ValueMember = "Id";
            cbxLanguages.DisplayMember = "Name";

            var positions = _rhDataService.GetAll<JobPosition>().ToList();
            positions.Insert(0, new JobPosition { Id = 0, Name = "Elegir" });
            cbxPositions.DataSource = positions;
            cbxPositions.ValueMember = "Id";
            cbxPositions.DisplayMember = "Name";
        }

        public static bool ValidaCedula(string pCedula)
        {
            try
            {
                Convert.ToInt64(pCedula);

            }
            catch (Exception ex)
            {
                return false;
            }

            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        private void CmdSaveCandidate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdentification.Text))
            {
                MessageBox.Show("Debe ingresar una cédula");
                return;
            }

            if(!ValidaCedula(txtIdentification.Text))
            {
                MessageBox.Show("Cédula invalida");
                return;
            }

            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Debe ingresar nombre del candidato");
                return;
            }

            if(cbxPositions.SelectedIndex == 0)
            {
                MessageBox.Show("Debe ingrese la posición del candidato");
                return;
            }

            if (string.IsNullOrEmpty(txtDeparment.Text))
            {
                MessageBox.Show("Ingrese el departamento del candidato");
            }

            if (salaryLike.Value <= 0)
            {
                MessageBox.Show("Indique el salario que ganaba.");
                return;
            }

            if(_competitionSource.Count == 0)
            {
                MessageBox.Show("Ingrese al menos una competencia");
                return;
            }

            if (_capcitationSource.Count == 0)
            {
                MessageBox.Show("Ingrese al menos una capacitación");
                return;
            }

            if (_experiencesSource.Count == 0)
            {
                MessageBox.Show("Ingrese al menos una experiencia laboral");
                return;
            }

            if (_languageSource.Count == 0)
            {
                MessageBox.Show("Ingrese al menos un idioma");
                return;
            }

            var competitions = _competitionSource.List.Cast<Competition>();
            var workExperience = _experiencesSource.List.Cast<WorkExperience>();
            var trainings = _capcitationSource.List.Cast<Training>();
            var languages = _languageSource.List.Cast<Language>();
            var positionSelected = cbxPositions.SelectedItem as JobPosition;

            Candidate candidate = new Candidate
            {
                IdentificationNumber = txtIdentification.Text,
                Name = txtName.Text,
                Department = txtDeparment.Text,
                SalaryLike = salaryLike.Value,
                Competitions = competitions.ToList(),
                Trainings = trainings.ToList(),
                WorkExperiences = workExperience.ToList(),
                Languages = languages.ToList(),
                AspirePosition = positionSelected.Name,
                Status = Model.ObjectStatus.Enable
            };

            try
            {
                _rhDataService.Add(candidate);
                _rhDataService.Save();

                MessageBox.Show("Candidato guardado satisfactoriamente");
                this.Close();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CmdAddCompetition_Click(object sender, EventArgs e)
        {
            if(cbxCompetition.SelectedIndex == 0)
            {
                MessageBox.Show("Debe elegir una competencia.");
                return;
            }

            var competition = cbxCompetition.SelectedItem as Competition;


            var list = _competitionSource.List as IEnumerable<Competition>;

            if (_competitionSource.Count > 0 && list.FirstOrDefault(i => i.Id == competition.Id) != null)
            {
                MessageBox.Show("No puede agregar una competicion, dos veces.");
                return;
            }

            _competitionSource.Add(competition);
            LstCompetitions.DataSource = _competitionSource;

            cbxCompetition.SelectedIndex = 0;
        }

        private void CmdAddTrainings_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Ingrese la descripción");
                return;
            }

            if(cbxCapacitaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una capacitación");
                return;
            }

            if (txtStartDate.Value >= txtToDate.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor a la fecha de inicio.");
                return;
            }

            if(string.IsNullOrWhiteSpace(txtInstitution.Text))
            {
                MessageBox.Show("Ingrese la institución de estudios.");
                return;
            }

            var list = _capcitationSource.List as IEnumerable<Training>;

            if (_capcitationSource.Count > 0 && list.FirstOrDefault(i => i.Level == ((LevelTraining)(cbxCapacitaciones.SelectedIndex + 1))
                    && i.Institution.ToUpper() == txtInstitution.Text.ToUpper()
                    && i.From == txtStartDate.Value && i.To == txtToDate.Value) != null)
            {
                MessageBox.Show("No puede agregar una Capacitacion, dos veces.");
                return;
            }

            var training = new Training
            {
                Description = txtDescription.Text,
                From = txtStartDate.Value,
                To = txtToDate.Value,
                Level = ((LevelTraining)(cbxCapacitaciones.SelectedIndex + 1)),
                Institution = txtInstitution.Text,
                Status = Model.ObjectStatus.Enable
            };

            _capcitationSource.Add(training);
            LstTrainings.DataSource = _capcitationSource;

            txtDescription.Text = "";
            txtStartDate.Value = DateTime.UtcNow.AddHours(-4);
            txtToDate.Value = DateTime.UtcNow.AddHours(-4);
            cbxCapacitaciones.SelectedIndex = -1;
            txtInstitution.Text = "";
        }

        private void CmdAddWorkExperiences_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtOldPosition.Text))
            {
                MessageBox.Show("Indique el nombre de la posicion, que desempeñaba");
                return;
            }

            if (string.IsNullOrEmpty(txtBusiness.Text))
            {
                MessageBox.Show("Indique el nombre de la empresa en que trabajo");
                return;
            }

            if (txtOldSalary.Value <= 0)
            {
                MessageBox.Show("Indique el salario que ganaba.");
                return;
            }

            if (txtFrom.Value >= txtTo.Value)
            {
                MessageBox.Show("El valor Hasta debe ser mayor que el valor desde.");
                return;
            }

            if (_experiencesSource.Count > 0)
            {
                var list = _experiencesSource.List as IEnumerable<WorkExperience>;

                if (list.FirstOrDefault(i => i.Company.ToUpper() == txtBusiness.Text.ToUpper() && i.From == txtFrom.Value && i.To == txtTo.Value) != null)
                {
                    MessageBox.Show("No puede agregar una experiencia laboral dos veces.");
                    return;
                }
            }

            var workExperiencies = new WorkExperience
            {
                JobName = txtOldPosition.Text,
                Company = txtBusiness.Text,
                Salary = txtOldSalary.Value,
                From = txtFrom.Value,
                To = txtTo.Value
            };

            _experiencesSource.Add(workExperiencies);
            LstWorkExperiencies.DataSource = _experiencesSource;

            txtOldPosition.Text = "";
            txtBusiness.Text = "";
            txtOldSalary.Value = 0;
            txtFrom.Value = DateTime.UtcNow.AddHours(-4);
            txtTo.Value = DateTime.UtcNow.AddHours(-4);
        }

        private void LstTrainings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstTrainings.Rows[e.RowIndex].Selected = true;
        }

        private void btnDltTraining_Click(object sender, EventArgs e)
        {
            if(LstTrainings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para borrar");
                return;
            }

            var training = LstTrainings.SelectedRows[0].DataBoundItem as Training;

            _capcitationSource.Remove(training);
        }

        private void btnDltExperience_Click(object sender, EventArgs e)
        {
            if (LstWorkExperiencies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para borrar");
                return;
            }

            var oldJob = LstWorkExperiencies.SelectedRows[0].DataBoundItem as WorkExperience;

            _experiencesSource.Remove(oldJob);
        }

        private void LstWorkExperiencies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstWorkExperiencies.Rows[e.RowIndex].Selected = true;
        }

        private void btnDltCompetition_Click(object sender, EventArgs e)
        {
            if (LstCompetitions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para borrar");
                return;
            }

            var oldCompetition = LstCompetitions.SelectedRows[0].DataBoundItem as Competition;

            _competitionSource.Remove(oldCompetition);
        }

        private void LstCompetitions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstCompetitions.Rows[e.RowIndex].Selected = true;
        }

        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            if (cbxLanguages.SelectedIndex == 0)
            {
                MessageBox.Show("Debe elegir un idioma.");
                return;
            }

            var language = cbxLanguages.SelectedItem as Language;


            var list = _languageSource.List as IEnumerable<Language>;

            if (_languageSource.Count > 0 && list.FirstOrDefault(i => i.Id == language.Id) != null)
            {
                MessageBox.Show("No puede agregar un idioma, dos veces.");
                return;
            }

            _languageSource.Add(language);
            LstLanguages.DataSource = _languageSource;

            cbxLanguages.SelectedIndex = 0;
        }

        private void LstLanguages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LstLanguages.Rows[e.RowIndex].Selected = true;
        }

        private void btnDltLanguague_Click(object sender, EventArgs e)
        {
            if (LstLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para borrar");
                return;
            }

            var oldLanguage = LstLanguages.SelectedRows[0].DataBoundItem as Language;

            _languageSource.Remove(oldLanguage);
        }
    }
}
