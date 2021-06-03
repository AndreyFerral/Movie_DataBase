
namespace Movie_DataBase
{
    partial class Form19
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.n_dogovor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.film_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.distrib_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.добавлениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n_dogovor1,
            this.staff_name,
            this.film_name,
            this.distrib_name,
            this.date1,
            this.date2,
            this.week1,
            this.cost1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1084, 437);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеToolStripMenuItem,
            this.добавлениеToolStripMenuItem1,
            this.удалениеToolStripMenuItem,
            this.сохранениеToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавлениеToolStripMenuItem
            // 
            this.добавлениеToolStripMenuItem.Name = "добавлениеToolStripMenuItem";
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.добавлениеToolStripMenuItem.Text = "Добавление";
            this.добавлениеToolStripMenuItem.Click += new System.EventHandler(this.добавлениеToolStripMenuItem_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // сохранениеToolStripMenuItem
            // 
            this.сохранениеToolStripMenuItem.Name = "сохранениеToolStripMenuItem";
            this.сохранениеToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.сохранениеToolStripMenuItem.Text = "Изменение";
            this.сохранениеToolStripMenuItem.Click += new System.EventHandler(this.сохранениеToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.назадToolStripMenuItem.Text = "Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // n_dogovor1
            // 
            this.n_dogovor1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.n_dogovor1.DataPropertyName = "Номер_договора";
            this.n_dogovor1.HeaderText = "Номер договора";
            this.n_dogovor1.Name = "n_dogovor1";
            this.n_dogovor1.ReadOnly = true;
            // 
            // staff_name
            // 
            this.staff_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_name.DataPropertyName = "ФИО";
            this.staff_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staff_name.HeaderText = "Сотрудник";
            this.staff_name.Name = "staff_name";
            this.staff_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.staff_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.staff_name.Width = 116;
            // 
            // film_name
            // 
            this.film_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.film_name.DataPropertyName = "Фильм";
            this.film_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.film_name.HeaderText = "Фильм";
            this.film_name.Name = "film_name";
            this.film_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.film_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.film_name.Width = 88;
            // 
            // distrib_name
            // 
            this.distrib_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.distrib_name.DataPropertyName = "Прокатчик";
            this.distrib_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distrib_name.HeaderText = "Прокатчик";
            this.distrib_name.Name = "distrib_name";
            this.distrib_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.distrib_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.distrib_name.Width = 116;
            // 
            // date1
            // 
            this.date1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date1.DataPropertyName = "Дата_Договора";
            this.date1.HeaderText = "Дата договора";
            this.date1.Name = "date1";
            // 
            // date2
            // 
            this.date2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date2.DataPropertyName = "Дата_проката";
            this.date2.HeaderText = "Дата проката";
            this.date2.Name = "date2";
            // 
            // week1
            // 
            this.week1.DataPropertyName = "Количество_недель";
            this.week1.HeaderText = "Кол-во недель";
            this.week1.Name = "week1";
            this.week1.Width = 80;
            // 
            // cost1
            // 
            this.cost1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cost1.DataPropertyName = "Стоимость";
            this.cost1.HeaderText = "Стоимость";
            this.cost1.Name = "cost1";
            this.cost1.Width = 118;
            // 
            // добавлениеToolStripMenuItem1
            // 
            this.добавлениеToolStripMenuItem1.Name = "добавлениеToolStripMenuItem1";
            this.добавлениеToolStripMenuItem1.Size = new System.Drawing.Size(94, 20);
            this.добавлениеToolStripMenuItem1.Text = "Добавление+";
            this.добавлениеToolStripMenuItem1.Click += new System.EventHandler(this.добавлениеToolStripMenuItem1_Click);
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список договоров";
            this.Load += new System.EventHandler(this.Form19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn n_dogovor1;
        private System.Windows.Forms.DataGridViewComboBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn film_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn distrib_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn week1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem1;
    }
}