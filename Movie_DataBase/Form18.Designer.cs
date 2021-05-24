
namespace Movie_DataBase
{
    partial class Form18
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id_timing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_prokat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_hall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Длительность = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_timing,
            this.id_prokat,
            this.id_hall,
            this.Длительность,
            this.datetime,
            this.cost});
            this.dataGridView1.Location = new System.Drawing.Point(13, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(702, 207);
            this.dataGridView1.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(186, 98);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(296, 26);
            this.textBox3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ряд";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(296, 26);
            this.textBox1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(24, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Место";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 56);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(296, 26);
            this.textBox2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Номер расписания";
            // 
            // id_timing
            // 
            this.id_timing.DataPropertyName = "idРасписание";
            this.id_timing.HeaderText = "Номер расписания";
            this.id_timing.Name = "id_timing";
            this.id_timing.ReadOnly = true;
            // 
            // id_prokat
            // 
            this.id_prokat.DataPropertyName = "Прокат_фильма_Номер_договора";
            this.id_prokat.HeaderText = "Номер проката";
            this.id_prokat.Name = "id_prokat";
            this.id_prokat.ReadOnly = true;
            // 
            // id_hall
            // 
            this.id_hall.DataPropertyName = "Зал_idЗал";
            this.id_hall.HeaderText = "Номер зала";
            this.id_hall.Name = "id_hall";
            this.id_hall.ReadOnly = true;
            // 
            // Длительность
            // 
            this.Длительность.DataPropertyName = "Сотрудник_idСотрудник";
            this.Длительность.HeaderText = "Номер сотрудника";
            this.Длительность.Name = "Длительность";
            this.Длительность.ReadOnly = true;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "Дата_время";
            this.datetime.HeaderText = "Дата и время";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.Width = 150;
            // 
            // cost
            // 
            this.cost.DataPropertyName = "Стоимость";
            this.cost.HeaderText = "Стоимость";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            // 
            // Form18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 361);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form18";
            this.Text = "Информация о билете";
            this.Load += new System.EventHandler(this.Form18_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_timing;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_prokat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_hall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Длительность;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
    }
}