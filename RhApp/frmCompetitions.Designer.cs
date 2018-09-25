namespace RhApp
{
    partial class FrmCompetitions
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
            this.LstCpts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.CmdEdit = new System.Windows.Forms.Button();
            this.CmdDelete = new System.Windows.Forms.Button();
            this.CmdSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtNameCpt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LstCpts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstCpts
            // 
            this.LstCpts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstCpts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LstCpts.Location = new System.Drawing.Point(12, 189);
            this.LstCpts.Name = "LstCpts";
            this.LstCpts.ReadOnly = true;
            this.LstCpts.Size = new System.Drawing.Size(613, 189);
            this.LstCpts.TabIndex = 0;
            this.LstCpts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LstCpts_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.CmdEdit);
            this.panel1.Controls.Add(this.CmdDelete);
            this.panel1.Controls.Add(this.CmdSave);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtNameCpt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 149);
            this.panel1.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(3, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(266, 20);
            this.txtId.TabIndex = 6;
            this.txtId.Visible = false;
            // 
            // CmdEdit
            // 
            this.CmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdEdit.Location = new System.Drawing.Point(525, 61);
            this.CmdEdit.Name = "CmdEdit";
            this.CmdEdit.Size = new System.Drawing.Size(75, 23);
            this.CmdEdit.TabIndex = 5;
            this.CmdEdit.Text = "&Editar";
            this.CmdEdit.UseVisualStyleBackColor = true;
            this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
            // 
            // CmdDelete
            // 
            this.CmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDelete.Location = new System.Drawing.Point(525, 102);
            this.CmdDelete.Name = "CmdDelete";
            this.CmdDelete.Size = new System.Drawing.Size(75, 23);
            this.CmdDelete.TabIndex = 4;
            this.CmdDelete.Text = "&Borrar";
            this.CmdDelete.UseVisualStyleBackColor = true;
            // 
            // CmdSave
            // 
            this.CmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.Location = new System.Drawing.Point(525, 20);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(75, 23);
            this.CmdSave.TabIndex = 2;
            this.CmdSave.Text = "&Registrar";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(208, 76);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(266, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // txtNameCpt
            // 
            this.txtNameCpt.Location = new System.Drawing.Point(208, 27);
            this.txtNameCpt.Name = "txtNameCpt";
            this.txtNameCpt.Size = new System.Drawing.Size(266, 20);
            this.txtNameCpt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción de la competencia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la Competencia:";
            // 
            // FrmCompetitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LstCpts);
            this.Name = "FrmCompetitions";
            this.Text = "Administración de Competencias";
            ((System.ComponentModel.ISupportInitialize)(this.LstCpts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LstCpts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtNameCpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdEdit;
        private System.Windows.Forms.Button CmdDelete;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.TextBox txtId;
    }
}

