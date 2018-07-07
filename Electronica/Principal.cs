using Electronica.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Electronica
{
	public class Principal : Form
	{
		private IContainer components = null;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button7;

		private Panel panelcontenedor;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Panel panel2;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private Button button8;

		private Button button9;

		private Label label1;

		public TextBox txtpersonal;

		private void AbrirFormaHija(object formhija)
		{
			if (panelcontenedor.Controls.Count > 0)
			{
				panelcontenedor.Controls.RemoveAt(0);
			}
			Form fh = formhija as Form;
			fh.TopLevel = false;
			fh.Dock = DockStyle.Fill;
			panelcontenedor.Controls.Add(fh);
			panelcontenedor.Tag = fh;
			fh.Show();
		}

		[DllImport("user32.dll")]
		private static extern void ReleaseCapture();

		[DllImport("user32.dll")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		public Principal(string nombre)
		{
			InitializeComponent();
			txtpersonal.Text = nombre;
			AbrirFormaHija(new Inicio());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Recepcion());
		}

		private void Principal_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Principal_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Clientes());
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Taller());
		}

		private void Principal_Load(object sender, EventArgs e)
		{
		}

		private void panelcontenedor_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Mercadolibre());
			txtpersonal.Text = txtpersonal.Text.ToString();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Traslado());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Inicio());
		}

		private void button7_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar());
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro(a) de cerrar sesión actual?", "Cerrar sesión", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				Hide();
				Login ss = new Login();
				ss.ShowDialog();
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electronica.Principal));
			panelcontenedor = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			txtpersonal = new System.Windows.Forms.TextBox();
			button9 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			panelcontenedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			panelcontenedor.Location = new System.Drawing.Point(264, 41);
			panelcontenedor.Margin = new System.Windows.Forms.Padding(2);
			panelcontenedor.Name = "panelcontenedor";
			panelcontenedor.Size = new System.Drawing.Size(1082, 707);
			panelcontenedor.TabIndex = 9;
			panelcontenedor.Paint += new System.Windows.Forms.PaintEventHandler(panelcontenedor_Paint);
			panel1.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(txtpersonal);
			panel1.Controls.Add(button9);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(button8);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button3);
			panel1.Controls.Add(button6);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(button5);
			panel1.ForeColor = System.Drawing.SystemColors.HighlightText;
			panel1.Location = new System.Drawing.Point(2, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(241, 769);
			panel1.TabIndex = 10;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			txtpersonal.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			txtpersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtpersonal.ForeColor = System.Drawing.SystemColors.Control;
			txtpersonal.Location = new System.Drawing.Point(188, 5);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(39, 31);
			txtpersonal.TabIndex = 15;
			button9.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button9.FlatAppearance.BorderSize = 0;
			button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button9.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button9.Image = Electronica.Properties.Resources.sign_out;
			button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button9.Location = new System.Drawing.Point(-1, 682);
			button9.Margin = new System.Windows.Forms.Padding(2);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(235, 48);
			button9.TabIndex = 11;
			button9.Text = "    Cerrar sesión";
			button9.UseVisualStyleBackColor = false;
			button9.Click += new System.EventHandler(button9_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(3, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(187, 25);
			label1.TabIndex = 14;
			label1.Text = "ID DE USUARIO:";
			button7.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button7.FlatAppearance.BorderSize = 0;
			button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button7.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button7.Image = Electronica.Properties.Resources._001_admin_with_cogwheels1;
			button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button7.Location = new System.Drawing.Point(2, 630);
			button7.Margin = new System.Windows.Forms.Padding(2);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(235, 48);
			button7.TabIndex = 6;
			button7.Text = "  Administrar";
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			button8.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button8.FlatAppearance.BorderSize = 0;
			button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button8.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button8.Image = Electronica.Properties.Resources.warehouse;
			button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button8.Location = new System.Drawing.Point(5, 569);
			button8.Margin = new System.Windows.Forms.Padding(2);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(235, 48);
			button8.TabIndex = 10;
			button8.Text = "  Almacén";
			button8.UseVisualStyleBackColor = false;
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.Location = new System.Drawing.Point(16, 40);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(197, 129);
			pictureBox1.TabIndex = 9;
			pictureBox1.TabStop = false;
			button1.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button1.Image = Electronica.Properties.Resources.home1;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(2, 175);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(235, 48);
			button1.TabIndex = 0;
			button1.Text = "   Inicio";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button2.Image = Electronica.Properties.Resources.support1;
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(2, 243);
			button2.Margin = new System.Windows.Forms.Padding(2);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(235, 48);
			button2.TabIndex = 1;
			button2.Text = "    Recepcion";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(button2_Click);
			button3.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button3.Image = Electronica.Properties.Resources._002_people1;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(2, 308);
			button3.Margin = new System.Windows.Forms.Padding(2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(235, 48);
			button3.TabIndex = 2;
			button3.Text = "Clientes";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click);
			button6.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button6.FlatAppearance.BorderSize = 0;
			button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button6.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button6.Image = Electronica.Properties.Resources.shipped2;
			button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button6.Location = new System.Drawing.Point(2, 504);
			button6.Margin = new System.Windows.Forms.Padding(2);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(235, 48);
			button6.TabIndex = 5;
			button6.Text = "  Traslados";
			button6.UseVisualStyleBackColor = false;
			button6.Click += new System.EventHandler(button6_Click);
			button4.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button4.Image = Electronica.Properties.Resources.wrench;
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(2, 373);
			button4.Margin = new System.Windows.Forms.Padding(2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(235, 48);
			button4.TabIndex = 3;
			button4.Text = "Taller";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new System.EventHandler(button4_Click);
			button5.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 45, 48);
			button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button5.Font = new System.Drawing.Font("Century Gothic", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button5.Image = Electronica.Properties.Resources._9dd996de0e52006774a1032d311d9e22__1_;
			button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button5.Location = new System.Drawing.Point(2, 437);
			button5.Margin = new System.Windows.Forms.Padding(2);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(235, 48);
			button5.TabIndex = 4;
			button5.Text = "    Mercado";
			button5.UseVisualStyleBackColor = false;
			button5.Click += new System.EventHandler(button5_Click);
			panel2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
			panel2.Controls.Add(pictureBox3);
			panel2.Controls.Add(pictureBox2);
			panel2.Location = new System.Drawing.Point(242, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1123, 36);
			panel2.TabIndex = 11;
			panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(panel2_MouseDown);
			pictureBox3.Image = Electronica.Properties.Resources.diminish__1_;
			pictureBox3.Location = new System.Drawing.Point(1056, 6);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(27, 27);
			pictureBox3.TabIndex = 13;
			pictureBox3.TabStop = false;
			pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
			pictureBox2.Image = Electronica.Properties.Resources.clear_button;
			pictureBox2.Location = new System.Drawing.Point(1089, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(29, 30);
			pictureBox2.TabIndex = 12;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1366, 768);
			base.Controls.Add(panel2);
			base.Controls.Add(panelcontenedor);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Principal";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Principal";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Principal_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Principal_FormClosed);
			base.Load += new System.EventHandler(Principal_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
		}
	}
}
