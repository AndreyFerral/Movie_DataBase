
namespace Movie_DataBase
{
    partial class Moderator_Second
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
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnHall = new System.Windows.Forms.Button();
            this.btnTiming = new System.Windows.Forms.Button();
            this.btnFilmAndGenre = new System.Windows.Forms.Button();
            this.btnFilmMaker = new System.Windows.Forms.Button();
            this.btnGenre = new System.Windows.Forms.Button();
            this.btnFilm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTicket
            // 
            this.btnTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTicket.Location = new System.Drawing.Point(14, 163);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(266, 45);
            this.btnTicket.TabIndex = 17;
            this.btnTicket.Text = "Билет";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnHall
            // 
            this.btnHall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHall.Location = new System.Drawing.Point(150, 112);
            this.btnHall.Name = "btnHall";
            this.btnHall.Size = new System.Drawing.Size(130, 45);
            this.btnHall.TabIndex = 16;
            this.btnHall.Text = "Зал";
            this.btnHall.UseVisualStyleBackColor = true;
            this.btnHall.Click += new System.EventHandler(this.btnHall_Click);
            // 
            // btnTiming
            // 
            this.btnTiming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTiming.Location = new System.Drawing.Point(14, 112);
            this.btnTiming.Name = "btnTiming";
            this.btnTiming.Size = new System.Drawing.Size(130, 45);
            this.btnTiming.TabIndex = 15;
            this.btnTiming.Text = "Расписание";
            this.btnTiming.UseVisualStyleBackColor = true;
            this.btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // btnFilmAndGenre
            // 
            this.btnFilmAndGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFilmAndGenre.Location = new System.Drawing.Point(14, 61);
            this.btnFilmAndGenre.Name = "btnFilmAndGenre";
            this.btnFilmAndGenre.Size = new System.Drawing.Size(130, 45);
            this.btnFilmAndGenre.TabIndex = 14;
            this.btnFilmAndGenre.Text = "Фильм и Жанр";
            this.btnFilmAndGenre.UseVisualStyleBackColor = true;
            this.btnFilmAndGenre.Click += new System.EventHandler(this.btnFilmAndGenre_Click);
            // 
            // btnFilmMaker
            // 
            this.btnFilmMaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFilmMaker.Location = new System.Drawing.Point(150, 10);
            this.btnFilmMaker.Name = "btnFilmMaker";
            this.btnFilmMaker.Size = new System.Drawing.Size(130, 45);
            this.btnFilmMaker.TabIndex = 13;
            this.btnFilmMaker.Text = "Режиссер";
            this.btnFilmMaker.UseVisualStyleBackColor = true;
            this.btnFilmMaker.Click += new System.EventHandler(this.btnFilmMaker_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGenre.Location = new System.Drawing.Point(150, 61);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(130, 45);
            this.btnGenre.TabIndex = 12;
            this.btnGenre.Text = "Жанр";
            this.btnGenre.UseVisualStyleBackColor = true;
            this.btnGenre.Click += new System.EventHandler(this.btnGenre_Click);
            // 
            // btnFilm
            // 
            this.btnFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFilm.Location = new System.Drawing.Point(14, 10);
            this.btnFilm.Name = "btnFilm";
            this.btnFilm.Size = new System.Drawing.Size(130, 45);
            this.btnFilm.TabIndex = 11;
            this.btnFilm.Text = "Фильм";
            this.btnFilm.UseVisualStyleBackColor = true;
            this.btnFilm.Click += new System.EventHandler(this.btnFilm_Click);
            // 
            // Moderator_Second
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 216);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.btnHall);
            this.Controls.Add(this.btnTiming);
            this.Controls.Add(this.btnFilmAndGenre);
            this.Controls.Add(this.btnFilmMaker);
            this.Controls.Add(this.btnGenre);
            this.Controls.Add(this.btnFilm);
            this.MaximumSize = new System.Drawing.Size(310, 255);
            this.MinimumSize = new System.Drawing.Size(310, 255);
            this.Name = "Moderator_Second";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор таблицы из БД";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnHall;
        private System.Windows.Forms.Button btnTiming;
        private System.Windows.Forms.Button btnFilmAndGenre;
        private System.Windows.Forms.Button btnFilmMaker;
        private System.Windows.Forms.Button btnGenre;
        private System.Windows.Forms.Button btnFilm;
    }
}