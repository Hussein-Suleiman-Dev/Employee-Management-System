namespace Test_Windows_Form1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGetAll = new System.Windows.Forms.DataGridView();
            this.btnAddNewEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAll)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGetAll
            // 
            this.dgvGetAll.AllowUserToAddRows = false;
            this.dgvGetAll.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGetAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGetAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGetAll.Location = new System.Drawing.Point(0, 154);
            this.dgvGetAll.Name = "dgvGetAll";
            this.dgvGetAll.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGetAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGetAll.RowHeadersWidth = 51;
            this.dgvGetAll.RowTemplate.Height = 24;
            this.dgvGetAll.Size = new System.Drawing.Size(940, 296);
            this.dgvGetAll.TabIndex = 0;
            this.dgvGetAll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGetAll_CellContentClick);
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.Location = new System.Drawing.Point(648, 41);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(176, 63);
            this.btnAddNewEmployee.TabIndex = 1;
            this.btnAddNewEmployee.Text = "button1";
            this.btnAddNewEmployee.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.btnAddNewEmployee);
            this.Controls.Add(this.dgvGetAll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGetAll;
        private System.Windows.Forms.Button btnAddNewEmployee;
    }
}

