
namespace Movie_DataBase
{
    partial class Form21
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
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.добавлениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.id_timing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dogovor_number = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.hall_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 17;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_timing,
            this.dogovor_number,
            this.hall_name,
            this.staff_name,
            this.datetime,
            this.cost});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 437);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // добавлениеToolStripMenuItem1
            // 
            this.добавлениеToolStripMenuItem1.Name = "добавлениеToolStripMenuItem1";
            this.добавлениеToolStripMenuItem1.Size = new System.Drawing.Size(94, 20);
            this.добавлениеToolStripMenuItem1.Text = "Добавление+";
            this.добавлениеToolStripMenuItem1.Click += new System.EventHandler(this.добавлениеToolStripMenuItem1_Click);
            // 
            // id_timing
            // 
            this.id_timing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_timing.DataPropertyName = "idРасписание";
            this.id_timing.HeaderText = "Номер расписания";
            this.id_timing.Name = "id_timing";
            this.id_timing.ReadOnly = true;
            // 
            // dogovor_number
            // 
            this.dogovor_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dogovor_number.DataPropertyName = "Прокат_фильма_Номер_договора";
            this.dogovor_number.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dogovor_number.HeaderText = "Номер проката";
            this.dogovor_number.Name = "dogovor_number";
            this.dogovor_number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dogovor_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // hall_name
            // 
            this.hall_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hall_name.DataPropertyName = "Название";
            this.hall_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hall_name.HeaderText = "Зал";
            this.hall_name.Name = "hall_name";
            this.hall_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hall_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hall_name.Width = 64;
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
            // datetime
            // 
            this.datetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datetime.DataPropertyName = "Дата_время";
            this.datetime.HeaderText = "Дата и время";
            this.datetime.Name = "datetime";
            this.datetime.Width = 137;
            // 
            // cost
            // 
            this.cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cost.DataPropertyName = "Стоимость";
            this.cost.HeaderText = "Стоимость";
            this.cost.Name = "cost";
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form21";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список расписаний";
            this.Load += new System.EventHandler(this.Form21_Load);
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
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_timing;
        private System.Windows.Forms.DataGridViewComboBoxColumn dogovor_number;
        private System.Windows.Forms.DataGridViewComboBoxColumn hall_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
    }
}