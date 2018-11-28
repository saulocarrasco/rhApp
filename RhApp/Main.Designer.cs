namespace RhApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuOptions = new System.Windows.Forms.MenuStrip();
            this.optMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optCompetitions = new System.Windows.Forms.ToolStripMenuItem();
            this.optLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.optCapacitations = new System.Windows.Forms.ToolStripMenuItem();
            this.optPositions = new System.Windows.Forms.ToolStripMenuItem();
            this.optCantidate = new System.Windows.Forms.ToolStripMenuItem();
            this.optConverToEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.optReportEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.optLeaveSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOptions
            // 
            this.menuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optMenu});
            this.menuOptions.Location = new System.Drawing.Point(0, 0);
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(804, 24);
            this.menuOptions.TabIndex = 0;
            this.menuOptions.Text = "menuStrip1";
            // 
            // optMenu
            // 
            this.optMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optCompetitions,
            this.optLanguages,
            this.optCapacitations,
            this.optPositions,
            this.optCantidate,
            this.optConverToEmployee,
            this.optReportEmployee,
            this.optLeaveSession});
            this.optMenu.Name = "optMenu";
            this.optMenu.Size = new System.Drawing.Size(50, 20);
            this.optMenu.Text = "Menu";
            // 
            // optCompetitions
            // 
            this.optCompetitions.Name = "optCompetitions";
            this.optCompetitions.Size = new System.Drawing.Size(177, 22);
            this.optCompetitions.Text = "Competencias";
            this.optCompetitions.Click += new System.EventHandler(this.optCompetitions_Click);
            // 
            // optLanguages
            // 
            this.optLanguages.Name = "optLanguages";
            this.optLanguages.Size = new System.Drawing.Size(177, 22);
            this.optLanguages.Text = "Idiomas";
            this.optLanguages.Click += new System.EventHandler(this.optLanguages_Click);
            // 
            // optCapacitations
            // 
            this.optCapacitations.Name = "optCapacitations";
            this.optCapacitations.Size = new System.Drawing.Size(177, 22);
            this.optCapacitations.Text = "Capacitaciones";
            this.optCapacitations.Click += new System.EventHandler(this.optCapacitations_Click);
            // 
            // optPositions
            // 
            this.optPositions.Name = "optPositions";
            this.optPositions.Size = new System.Drawing.Size(177, 22);
            this.optPositions.Text = "Posiciones";
            this.optPositions.Click += new System.EventHandler(this.optPositions_Click);
            // 
            // optCantidate
            // 
            this.optCantidate.Name = "optCantidate";
            this.optCantidate.Size = new System.Drawing.Size(177, 22);
            this.optCantidate.Text = "Candidatos";
            this.optCantidate.Click += new System.EventHandler(this.optCantidate_Click);
            // 
            // optConverToEmployee
            // 
            this.optConverToEmployee.Name = "optConverToEmployee";
            this.optConverToEmployee.Size = new System.Drawing.Size(177, 22);
            this.optConverToEmployee.Text = "Dar alta Candidatos";
            this.optConverToEmployee.Click += new System.EventHandler(this.darAltaCandidatosToolStripMenuItem_Click);
            // 
            // optReportEmployee
            // 
            this.optReportEmployee.Name = "optReportEmployee";
            this.optReportEmployee.Size = new System.Drawing.Size(177, 22);
            this.optReportEmployee.Text = "Reporte Empleados";
            this.optReportEmployee.Click += new System.EventHandler(this.optReportEmployee_Click);
            // 
            // optLeaveSession
            // 
            this.optLeaveSession.Name = "optLeaveSession";
            this.optLeaveSession.Size = new System.Drawing.Size(177, 22);
            this.optLeaveSession.Text = "Cerrar Sesion";
            this.optLeaveSession.Click += new System.EventHandler(this.optLeaveSession_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 454);
            this.Controls.Add(this.menuOptions);
            this.MainMenuStrip = this.menuOptions;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Central RH";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Leave += new System.EventHandler(this.Main_Leave);
            this.menuOptions.ResumeLayout(false);
            this.menuOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuOptions;
        private System.Windows.Forms.ToolStripMenuItem optMenu;
        private System.Windows.Forms.ToolStripMenuItem optCompetitions;
        private System.Windows.Forms.ToolStripMenuItem optLanguages;
        private System.Windows.Forms.ToolStripMenuItem optCapacitations;
        private System.Windows.Forms.ToolStripMenuItem optPositions;
        private System.Windows.Forms.ToolStripMenuItem optCantidate;
        private System.Windows.Forms.ToolStripMenuItem optConverToEmployee;
        private System.Windows.Forms.ToolStripMenuItem optReportEmployee;
        private System.Windows.Forms.ToolStripMenuItem optLeaveSession;
    }
}