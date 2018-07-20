using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            textBox2.Text = Seguridad.Encriptar(textBox2.Text);

            try
            {
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT id_personal, tipo from personal  WHERE usuario=@usuario and contraseña= @contraseña ", conn);
				cmd.Parameters.AddWithValue("usuario", textBox1.Text);
				cmd.Parameters.AddWithValue("contraseña", textBox2.Text);
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

		private void label2_Click(object sender, EventArgs e)
		{
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electronica.Login));
			textBox1 = new System.Windows.Forms.TextBox();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			textBox2 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			textBox1.BackColor = System.Drawing.Color.FromArgb(7, 83, 143);
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.ForeColor = System.Drawing.SystemColors.Control;
			textBox1.Location = new System.Drawing.Point(167, 340);
			textBox1.Margin = new System.Windows.Forms.Padding(2);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(132, 26);
			textBox1.TabIndex = 0;
			contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			textBox2.BackColor = System.Drawing.Color.FromArgb(2, 62, 124);
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox2.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox2.ForeColor = System.Drawing.SystemColors.Control;
			textBox2.Location = new System.Drawing.Point(167, 397);
			textBox2.Margin = new System.Windows.Forms.Padding(2);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(132, 26);
			textBox2.TabIndex = 1;
			textBox2.UseSystemPasswordChar = true;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label1.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.SystemColors.Control;
			label1.Location = new System.Drawing.Point(15, 342);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(86, 24);
			label1.TabIndex = 4;
			label1.Text = "Usuario:";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.FromArgb(2, 62, 124);
			label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label2.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.SystemColors.Control;
			label2.Location = new System.Drawing.Point(15, 399);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(135, 24);
			label2.TabIndex = 5;
			label2.Text = "Contraseña:";
			label2.Click += new System.EventHandler(label2_Click);
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.FromArgb(193, 247, 249);
			label9.Font = new System.Drawing.Font("Century Gothic", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(76, 30);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(199, 36);
			label9.TabIndex = 28;
			label9.Text = "Iniciar Sesión";
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pictureBox1.Location = new System.Drawing.Point(57, 83);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(242, 172);
			pictureBox1.TabIndex = 6;
			pictureBox1.TabStop = false;
			button1.BackColor = System.Drawing.Color.FromArgb(2, 22, 72);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.SystemColors.Control;
			button1.Image = Electronica.Properties.Resources._002_house_key2;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(167, 473);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(132, 46);
			button1.TabIndex = 2;
			button1.Text = "   Iniciar";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox2.Image = Electronica.Properties.Resources.landscape_3840x2160_flat_4k_5k_fog_iphone_wallpaper_forest_blue_11927;
			pictureBox2.Location = new System.Drawing.Point(0, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(346, 580);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 29;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.MintCream;
			base.ClientSize = new System.Drawing.Size(348, 579);
			base.Controls.Add(label9);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(pictureBox2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Login";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Login";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Login_FormClosing_1);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Login_FormClosed);
			base.Load += new System.EventHandler(Login_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
