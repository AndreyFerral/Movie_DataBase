namespace Movie_DataBase
{
    partial class Form5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idФильм = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Описание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Длительность = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.удалениеToolStripMenuItem,
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(844, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавлениеToolStripMenuItem
            // 
            this.добавлениеToolStripMenuItem.Name = "добавлениеToolStripMenuItem";
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(133, 19);
            this.добавлениеToolStripMenuItem.Text = "Добавление фильма";
            this.добавлениеToolStripMenuItem.Click += new System.EventHandler(this.добавлениеToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(166, 19);
            this.информацияToolStripMenuItem.Text = "Информация / Изменение";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(71, 19);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(51, 19);
            this.назадToolStripMenuItem.Text = "Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(844, 397);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.Описание.Width = 300;
            // 
            // Длительность
            // 
            this.Длительность.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Длительность.DataPropertyName = "Длительность";
            this.Длительность.HeaderText = "Длительность";
            this.Длительность.Name = "Длительность";
            this.Длительность.ReadOnly = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 422);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список фильмов";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idФильм;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Описание;
        private System.Windows.Forms.DataGridViewTextBoxColumn Длительность;
    }
}