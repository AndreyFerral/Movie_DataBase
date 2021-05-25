
namespace Movie_DataBase
{
    partial class Form11
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
            this.text2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idФильм = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Описание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Длительность = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(200, 25);
            this.text2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.text2.Name = "text2";
            this.text2.ReadOnly = true;
            this.text2.Size = new System.Drawing.Size(296, 26);
            this.text2.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(48, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "ФИО Режиссер";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idФильм,
            this.Название,
            this.Описание,
            this.Длительность});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(719, 191);
            this.dataGridView1.TabIndex = 19;
            // 
            // idФильм
            // 
            this.idФильм.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idФильм.DataPropertyName = "idФильм";
            this.idФильм.HeaderText = "Номер фильма";
            this.idФильм.Name = "idФильм";
            this.idФильм.ReadOnly = true;
            // 
            // Название
            // 
            this.Название.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Название.DataPropertyName = "Название";
            this.Название.HeaderText = "Название фильма";
            this.Название.Name = "Название";
            this.Название.ReadOnly = true;
            this.Название.Width = 159;
            // 
            // Описание
            // 
            this.Описание.DataPropertyName = "Описание";
            this.Описание.HeaderText = "Описание";
            this.Описание.Name = "Описание";
            this.Описание.ReadOnly = true;
            this.Описание.Width = 250;
            // 
            // Длительность
            // 
            this.Длительность.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Длительность.DataPropertyName = "Длительность";
            this.Длительность.HeaderText = "Длительность";
            this.Длительность.Name = "Длительность";
            this.Длительность.ReadOnly = true;
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 257);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр информации о режиссере";
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idФильм;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Описание;
        private System.Windows.Forms.DataGridViewTextBoxColumn Длительность;
    }
}