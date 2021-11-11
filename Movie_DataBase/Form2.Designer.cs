
namespace Movie_DataBase
{
    partial class Form2
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
            this.btnDistrib = new System.Windows.Forms.Button();
            this.btnFilm = new System.Windows.Forms.Button();
            this.btnGenre = new System.Windows.Forms.Button();
            this.btnFilmMaker = new System.Windows.Forms.Button();
            this.btnFilmAndGenre = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnHall = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnTiming = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDistrib
            // 
            this.btnDistrib.Location = new System.Drawing.Point(150, 112);
            this.btnDistrib.Name = "btnDistrib";
            this.btnDistrib.Size = new System.Drawing.Size(130, 45);
            this.btnDistrib.TabIndex = 0;
            this.btnDistrib.Text = "Прокатчик";
            this.btnDistrib.UseVisualStyleBackColor = true;
            this.btnDistrib.Click += new System.EventHandler(this.btnDistrib_Click);
            // 
            // btnFilm
            // 
            this.btnFilm.Location = new System.Drawing.Point(14, 10);
            this.btnFilm.Name = "btnFilm";
            this.btnFilm.Size = new System.Drawing.Size(130, 45);
            this.btnFilm.TabIndex = 1;
            this.btnFilm.Text = "Фильм";
            this.btnFilm.UseVisualStyleBackColor = true;
            this.btnFilm.Click += new System.EventHandler(this.btnFilm_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.Location = new System.Drawing.Point(150, 61);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(130, 45);
            this.btnGenre.TabIndex = 2;
            this.btnGenre.Text = "Жанр";
            this.btnGenre.UseVisualStyleBackColor = true;
            this.btnGenre.Click += new System.EventHandler(this.btnGenre_Click);
            // 
            // btnFilmMaker
            // 
            this.btnFilmMaker.Location = new System.Drawing.Point(150, 10);
            this.btnFilmMaker.Name = "btnFilmMaker";
            this.btnFilmMaker.Size = new System.Drawing.Size(130, 45);
            this.btnFilmMaker.TabIndex = 3;
            this.btnFilmMaker.Text = "Режиссер";
            this.btnFilmMaker.UseVisualStyleBackColor = true;
            this.btnFilmMaker.Click += new System.EventHandler(this.btnFilmMaker_Click);
            // 
            // btnFilmAndGenre
            // 
            this.btnFilmAndGenre.Location = new System.Drawing.Point(14, 61);
            this.btnFilmAndGenre.Name = "btnFilmAndGenre";
            this.btnFilmAndGenre.Size = new System.Drawing.Size(130, 45);
            this.btnFilmAndGenre.TabIndex = 4;
            this.btnFilmAndGenre.Text = "Фильм и Жанр";
            this.btnFilmAndGenre.UseVisualStyleBackColor = true;
            this.btnFilmAndGenre.Click += new System.EventHandler(this.btnFilmAndGenre_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(14, 112);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(130, 45);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "Сотрудник";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnHall
            // 
            this.btnHall.Location = new System.Drawing.Point(14, 214);
            this.btnHall.Name = "btnHall";
            this.btnHall.Size = new System.Drawing.Size(130, 45);
            this.btnHall.TabIndex = 6;
            this.btnHall.Text = "Зал";
            this.btnHall.UseVisualStyleBackColor = true;
            this.btnHall.Click += new System.EventHandler(this.btnHall_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(150, 214);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(130, 45);
            this.btnTicket.TabIndex = 7;
            this.btnTicket.Text = "Билет";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnContract
            // 
            this.btnContract.Location = new System.Drawing.Point(14, 163);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(130, 45);
            this.btnContract.TabIndex = 8;
            this.btnContract.Text = "Договор";
            this.btnContract.UseVisualStyleBackColor = true;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // btnTiming
            // 
            this.btnTiming.Location = new System.Drawing.Point(150, 163);
            this.btnTiming.Name = "btnTiming";
            this.btnTiming.Size = new System.Drawing.Size(130, 45);
            this.btnTiming.TabIndex = 9;
            this.btnTiming.Text = "Расписание";
            this.btnTiming.UseVisualStyleBackColor = true;
            this.btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 271);
            this.Controls.Add(this.btnTiming);
            this.Controls.Add(this.btnContract);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.btnHall);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnFilmAndGenre);
            this.Controls.Add(this.btnFilmMaker);
            this.Controls.Add(this.btnGenre);
            this.Controls.Add(this.btnFilm);
            this.Controls.Add(this.btnDistrib);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(310, 310);
            this.MinimumSize = new System.Drawing.Size(310, 310);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор таблицы из БД";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDistrib;
        private System.Windows.Forms.Button btnFilm;
        private System.Windows.Forms.Button btnGenre;
        private System.Windows.Forms.Button btnFilmMaker;
        private System.Windows.Forms.Button btnFilmAndGenre;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnHall;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnTiming;
    }
}