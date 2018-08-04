using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.Text;
using System.Security.Cryptography;
namespace Electronica
{
	public class Login : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private TextBox textBox1;

		private ContextMenuStrip contextMenuStrip1;

		private TextBox textBox2;

		private Button button1;

		private Label label1;

		private Label label2;

		private PictureBox pictureBox1;

		private Label label9;

		private PictureBox pictureBox2;

		public Login()
		{
			InitializeComponent();
		}
       

		public void button1_Click(object sender, EventArgs e)
		{
            // textBox2.Text = Seguridad.Encriptar(textBox2.Text);
            textBox2.Text = GetMD5(textBox2.Text);
            try
            {
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT id_personal, tipo from personal  WHERE usuario=@usuario and contrasena= @contrasena ", conn);
				cmd.Parameters.AddWithValue("usuario", textBox1.Text);
				cmd.Parameters.AddWithValue("contrasena", textBox2.Text);
				MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Hide();
					if (dt.Rows[0][1].ToString() == "Administrador")
					{
						PopupNotifier pop4 = new PopupNotifier();
						pop4.TitleText = "Sesión iniciada correctamente";
						pop4.ContentText = "Bienvenido " + textBox1.Text + " que tengas un gran día";
						pop4.ImagePadding = new Padding(10, 10, 10, 10);
						pop4.Image = Resources.information;
						pop4.TitleFont = new Font("Segoe UI", 16f);
						pop4.TitleColor = Color.White;
						pop4.ContentColor = Color.White;
						pop4.ContentFont = new Font("Segoe UI", 12f);
						pop4.BodyColor = Color.FromArgb(0, 122, 204);
						pop4.Popup();
						new Principal(dt.Rows[0][0].ToString()).Show();
					}
					else if (dt.Rows[0][1].ToString() == "Tecnico")
					{
						PopupNotifier pop5 = new PopupNotifier();
						pop5.TitleText = "Sesión iniciada correctamente";
						pop5.ContentText = "Bienvenido " + textBox1.Text + " que tengas un gran día";
						pop5.ImagePadding = new Padding(10, 10, 10, 10);
						pop5.Image = Resources.information;
						pop5.TitleFont = new Font("Segoe UI", 16f);
						pop5.TitleColor = Color.White;
						pop5.ContentColor = Color.White;
						pop5.ContentFont = new Font("Segoe UI", 12f);
						pop5.BodyColor = Color.FromArgb(0, 122, 204);
						pop5.Popup();
						new Principal_tecnicos(dt.Rows[0][0].ToString()).Show();
					}
					else if (dt.Rows[0][1].ToString() == "Recepcion")
					{
						PopupNotifier pop3 = new PopupNotifier();
						pop3.TitleText = "Sesión iniciada correctamente";
						pop3.ContentText = "Bienvenido " + textBox1.Text + " que tengas un gran día";
						pop3.ImagePadding = new Padding(10, 10, 10, 10);
						pop3.Image = Resources.information;
						pop3.TitleFont = new Font("Segoe UI", 16f);
						pop3.TitleColor = Color.White;
						pop3.ContentColor = Color.White;
						pop3.ContentFont = new Font("Segoe UI", 12f);
						pop3.BodyColor = Color.FromArgb(0, 122, 204);
						pop3.Popup();
						new Principal_recepcion(dt.Rows[0][0].ToString()).Show();
					}
                    else if (dt.Rows[0][1].ToString() == "Jefe de Taller")
                    {
                        PopupNotifier pop5 = new PopupNotifier();
                        pop5.TitleText = "Sesión iniciada correctamente";
                        pop5.ContentText = "Bienvenido " + textBox1.Text + " que tengas un gran día";
                        pop5.ImagePadding = new Padding(10, 10, 10, 10);
                        pop5.Image = Resources.information;
                        pop5.TitleFont = new Font("Segoe UI", 16f);
                        pop5.TitleColor = Color.White;
                        pop5.ContentColor = Color.White;
                        pop5.ContentFont = new Font("Segoe UI", 12f);
                        pop5.BodyColor = Color.FromArgb(0, 122, 204);
                        pop5.Popup();
                        new Principal_taller(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Jefe partes")
					{
						PopupNotifier pop = new PopupNotifier();
						pop.TitleText = "Sesión iniciada correctamente";
						pop.ContentText = "Bienvenido " + textBox1.Text + " que tengas un gran día";
						pop.ImagePadding = new Padding(10, 10, 10, 10);
						pop.Image = Resources.information;
						pop.TitleFont = new Font("Segoe UI", 16f);
						pop.TitleColor = Color.White;
						pop.ContentColor = Color.White;
						pop.ContentFont = new Font("Segoe UI", 12f);
						pop.BodyColor = Color.FromArgb(0, 122, 204);
						pop.Popup();
						new Principal_mercado(dt.Rows[0][0].ToString()).Show();
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error en usuario y/o contraseña contacte al administrador");
				conn.Close();
			}
		}

        public string GetMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
              strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        private void label3_Click(object sender, EventArgs e)
		{
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
		}

		private void Login_Load(object sender, EventArgs e)
		{
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void Login_FormClosing_1(object sender, FormClosingEventArgs e)
		{
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(167, 340);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 31);
            this.textBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.Location = new System.Drawing.Point(167, 397);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 31);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(124)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(15, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(124)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(15, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(76, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 33);
            this.label9.TabIndex = 28;
            this.label9.Text = "Iniciar Sesión";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(57, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 172);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(22)))), ((int)(((byte)(72)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::Electronica.Properties.Resources._002_house_key2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(167, 473);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "   Iniciar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Electronica.Properties.Resources.landscape_3840x2160_flat_4k_5k_fog_iphone_wallpaper_forest_blue_11927;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(346, 580);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(348, 579);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
