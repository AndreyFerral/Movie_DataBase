
namespace Movie_DataBase
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNameSrv = new System.Windows.Forms.Label();
            this.lblNameDB = new System.Windows.Forms.Label();
            this.lblTypeAutor = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.cmbTypeAutor = new System.Windows.Forms.ComboBox();
            this.txtNameSrv = new System.Windows.Forms.TextBox();
            this.txtNameDB = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.bttConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNameSrv
            // 
            this.lblNameSrv.AutoSize = true;
            this.lblNameSrv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNameSrv.Location = new System.Drawing.Point(32, 31);
            this.lblNameSrv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameSrv.Name = "lblNameSrv";
            this.lblNameSrv.Size = new System.Drawing.Size(106, 20);
            this.lblNameSrv.TabIndex = 0;
            this.lblNameSrv.Text = "Имя сервера";
            // 
            // lblNameDB
            // 
            this.lblNameDB.AutoSize = true;
            this.lblNameDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNameDB.Location = new System.Drawing.Point(32, 70);
            this.lblNameDB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameDB.Name = "lblNameDB";
            this.lblNameDB.Size = new System.Drawing.Size(141, 20);
            this.lblNameDB.TabIndex = 1;
            this.lblNameDB.Text = "Имя базы данных";
            // 
            // lblTypeAutor
            // 
            this.lblTypeAutor.AutoSize = true;
            this.lblTypeAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTypeAutor.Location = new System.Drawing.Point(32, 109);
            this.lblTypeAutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeAutor.Name = "lblTypeAutor";
            this.lblTypeAutor.Size = new System.Drawing.Size(188, 20);
            this.lblTypeAutor.TabIndex = 2;
            this.lblTypeAutor.Text = "Проверка подлинности";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserName.Location = new System.Drawing.Point(32, 148);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(153, 20);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Имя пользователя";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPass.Location = new System.Drawing.Point(32, 187);
            this.lblPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 20);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Пароль";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTypeAutor
            // 
            this.cmbTypeAutor.FormattingEnabled = true;
            this.cmbTypeAutor.Location = new System.Drawing.Point(250, 101);
            this.cmbTypeAutor.Name = "cmbTypeAutor";
            this.cmbTypeAutor.Size = new System.Drawing.Size(295, 28);
            this.cmbTypeAutor.TabIndex = 5;
            this.cmbTypeAutor.Tag = "";
            this.cmbTypeAutor.Text = "Проверка подлинности SQL Server";
            this.cmbTypeAutor.SelectedIndexChanged += new System.EventHandler(this.cmbTypeAutor_SelectionChangeCommitted);
            this.cmbTypeAutor.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeAutor_SelectionChangeCommitted);
            // 
            // txtNameSrv
            // 
            this.txtNameSrv.Location = new System.Drawing.Point(250, 25);
            this.txtNameSrv.Name = "txtNameSrv";
            this.txtNameSrv.Size = new System.Drawing.Size(295, 26);
            this.txtNameSrv.TabIndex = 6;
            // 
            // txtNameDB
            // 
            this.txtNameDB.Location = new System.Drawing.Point(250, 64);
            this.txtNameDB.Name = "txtNameDB";
            this.txtNameDB.Size = new System.Drawing.Size(295, 26);
            this.txtNameDB.TabIndex = 7;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(250, 142);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(295, 26);
            this.txtUserName.TabIndex = 8;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(250, 181);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(295, 26);
            this.txtPass.TabIndex = 9;
            // 
            // bttConnect
            // 
            this.bttConnect.Location = new System.Drawing.Point(431, 222);
            this.bttConnect.Name = "bttConnect";
            this.bttConnect.Size = new System.Drawing.Size(114, 38);
            this.bttConnect.TabIndex = 10;
            this.bttConnect.Text = "Соединить";
            this.bttConnect.UseVisualStyleBackColor = true;
            this.bttConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 278);
            this.Controls.Add(this.bttConnect);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtNameDB);
            this.Controls.Add(this.txtNameSrv);
            this.Controls.Add(this.cmbTypeAutor);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblTypeAutor);
            this.Controls.Add(this.lblNameDB);
            this.Controls.Add(this.lblNameSrv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Введите параметры подключения";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameSrv;
        private System.Windows.Forms.Label lblNameDB;
        private System.Windows.Forms.Label lblTypeAutor;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.ComboBox cmbTypeAutor;
        private System.Windows.Forms.TextBox txtNameSrv;
        private System.Windows.Forms.TextBox txtNameDB;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button bttConnect;
    }
}

