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
    public partial class Main : Form
    {
        private RhDataService _rhService;
        private FrmCompetitions _frmCompetitions;
        private FrmLanguages _frmLanguages;
        private FrmTraining _frmTraining;
        private FrmPositions _frmPositions;
        private UserCredential _user;
        private FrmCandidate _frmCandidate;
        private Login _login;
        private FrmConverToEmployee _frmConvertToEmployee;
        private FrmReportEmployees _frmReportEmployees;

        public Main(RhDataService rhService, UserCredential user, Login login)
        {
            _rhService = rhService;
            _user = user;
            _login = login;
            InitializeComponent();

            if (_user.UserRole != UserRole.Rh)
            {
                optLanguages.Visible = false;
                optCompetitions.Visible = false;
                optPositions.Visible = false;
                optCapacitations.Visible = false;
                optConverToEmployee.Visible = false;
                optReportEmployee.Visible = false;
            }
        }

        private void optCompetitions_Click(object sender, EventArgs e)
        {
            _frmCompetitions = new FrmCompetitions(_rhService);
            _frmCompetitions.Show();
        }

        private void optLanguages_Click(object sender, EventArgs e)
        {
            _frmLanguages = new FrmLanguages(_rhService);
            _frmLanguages.ShowDialog();
        }

        private void optCapacitations_Click(object sender, EventArgs e)
        {
            _frmTraining = new FrmTraining(_rhService);
            _frmTraining.ShowDialog();
        }

        private void optPositions_Click(object sender, EventArgs e)
        {
            _frmPositions = new FrmPositions(_rhService);
            _frmPositions.ShowDialog();
        }

        private void optCantidate_Click(object sender, EventArgs e)
        {
            _frmCandidate = new FrmCandidate(_rhService);
            _frmCandidate.ShowDialog();
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            _login.Close();
            _login.Dispose();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            _login.Close();
            _login.Dispose();
        }

        private void darAltaCandidatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmConvertToEmployee = new FrmConverToEmployee(_rhService);
            _frmConvertToEmployee.ShowDialog();
        }

        private void optReportEmployee_Click(object sender, EventArgs e)
        {
            _frmReportEmployees = new FrmReportEmployees(_rhService);
            _frmReportEmployees.ShowDialog();
        }

        private void optLeaveSession_Click(object sender, EventArgs e)
        {
            _login.Visible = true;
            this.Dispose();
        }
    }
}
