namespace RhApp
{
    partial class FrmConverToEmployee
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
            this.LstCandidates = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnConvertEmployee = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbxValue = new System.Windows.Forms.ComboBox();
            this.cbxFilterType = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AspirePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LstCandidates)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstCandidates
            // 
            this.LstCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LstCandidates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Status,
            this.IdentificationNumber,
            this.Name,
            this.AspirePosition,
            this.Department,
            this.Salary});
            this.LstCandidates.Location = new System.Drawing.Point(12, 119);
            this.LstCandidates.Name = "LstCandidates";
            this.LstCandidates.Size = new System.Drawing.Size(910, 402);
            this.LstCandidates.TabIndex = 0;
            this.LstCandidates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LstCandidates_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(301, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(135, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Visible = false;
            // 
            // btnConvertEmployee
            // 
            this.btnConvertEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertEmployee.Location = new System.Drawing.Point(736, 33);
            this.btnConvertEmployee.Name = "btnConvertEmployee";
            this.btnConvertEmployee.Size = new System.Drawing.Size(147, 23);
            this.btnConvertEmployee.TabIndex = 2;
            this.btnConvertEmployee.Text = "Dar De Alta";
            this.btnConvertEmployee.UseVisualStyleBackColor = true;
            this.btnConvertEmployee.Click += new System.EventHandler(this.btnConvertEmployee_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClearFilter);
            this.panel2.Controls.Add(this.btnConvertEmployee);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnFilter);
            this.panel2.Controls.Add(this.cbxValue);
            this.panel2.Controls.Add(this.cbxFilterType);
            this.panel2.Location = new System.Drawing.Point(12, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 76);
            this.panel2.TabIndex = 5;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.Location = new System.Drawing.Point(545, 30);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Text = "Limpiar Filtros";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Criterio de búsqueda:";
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(455, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Buscar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbxValue
            // 
            this.cbxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxValue.FormattingEnabled = true;
            this.cbxValue.Location = new System.Drawing.Point(315, 32);
            this.cbxValue.Name = "cbxValue";
            this.cbxValue.Size = new System.Drawing.Size(121, 21);
            this.cbxValue.TabIndex = 1;
            // 
            // cbxFilterType
            // 
            this.cbxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterType.FormattingEnabled = true;
            this.cbxFilterType.Items.AddRange(new object[] {
            "",
            "Puesto",
            "Competencia",
            "Capacitación",
            "Otros"});
            this.cbxFilterType.Location = new System.Drawing.Point(156, 32);
            this.cbxFilterType.Name = "cbxFilterType";
            this.cbxFilterType.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterType.TabIndex = 0;
            this.cbxFilterType.SelectedValueChanged += new System.EventHandler(this.cbxFilterType_SelectedValueChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // IdentificationNumber
            // 
            this.IdentificationNumber.DataPropertyName = "IdentificationNumber";
            this.IdentificationNumber.HeaderText = "Cedula";
            this.IdentificationNumber.Name = "IdentificationNumber";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Nombre";
            this.Name.Name = "Name";
            // 
            // AspirePosition
            // 
            this.AspirePosition.DataPropertyName = "AspirePosition";
            this.AspirePosition.HeaderText = "Posición Seleccionada";
            this.AspirePosition.Name = "AspirePosition";
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Departamento";
            this.Department.Name = "Department";
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "SalaryLike";
            this.Salary.HeaderText = "Salario De Aspiracion";
            this.Salary.Name = "Salary";
            // 
            // FrmConverToEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LstCandidates);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de Alta Candidatos";
            ((System.ComponentModel.ISupportInitialize)(this.LstCandidates)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LstCandidates;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnConvertEmployee;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxValue;
        private System.Windows.Forms.ComboBox cbxFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn AspirePosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
    }
}