namespace otdelkadrov
{
    partial class DepartmentContent
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDepartmentContent = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentContent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDepartmentContent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 463);
            this.panel3.TabIndex = 2;
            // 
            // dgvDepartmentContent
            // 
            this.dgvDepartmentContent.AllowUserToAddRows = false;
            this.dgvDepartmentContent.AllowUserToDeleteRows = false;
            this.dgvDepartmentContent.AllowUserToResizeRows = false;
            this.dgvDepartmentContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartmentContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.position});
            this.dgvDepartmentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmentContent.Location = new System.Drawing.Point(0, 0);
            this.dgvDepartmentContent.Name = "dgvDepartmentContent";
            this.dgvDepartmentContent.ReadOnly = true;
            this.dgvDepartmentContent.RowHeadersVisible = false;
            this.dgvDepartmentContent.RowTemplate.Height = 24;
            this.dgvDepartmentContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartmentContent.Size = new System.Drawing.Size(343, 463);
            this.dgvDepartmentContent.TabIndex = 0;
            // 
            // name
            // 
            this.name.HeaderText = "ФИО";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 180;
            // 
            // position
            // 
            this.position.HeaderText = "Должность";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Width = 150;
            // 
            // DepartmentContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 463);
            this.Controls.Add(this.panel3);
            this.Name = "DepartmentContent";
            this.Text = "Состав подразделения";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDepartmentContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
    }
}