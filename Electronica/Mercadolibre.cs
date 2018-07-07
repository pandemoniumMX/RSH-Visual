using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Mercadolibre : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Panel panelanidado;

		private Label label9;

		private Button btnpublicadas;

		private Button btnvendidas;

		private Button btnnuevo;

		private Button btnpendiente;

		private Button btntodas;

		private Label msjadm;

		private Button button1;

		private Panel panel1;

		public TextBox txtpersonal;

		private Button button3;

		public Mercadolibre()
		{
			InitializeComponent();
			txtpersonal.Text = txtpersonal.Text.ToString();
		}

		private void limpiarpanelanidado()
		{
		}

		private void AbrirFormaHija(object formhija)
		{
			if (panelanidado.Controls.Count > 0)
			{
				panelanidado.Controls.RemoveAt(0);
			}
			Form fh = formhija as Form;
			fh.TopLevel = false;
			fh.Dock = DockStyle.Fill;
			panelanidado.Controls.Add(fh);
			panelanidado.Tag = fh;
			fh.Show();
		}

		public void btnverificar_Click(object sender, EventArgs e)
		{
		}

		private void btntele_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			Mercadolibre_nueva ret = new Mercadolibre_nueva();
			txtpersonal.Text = txtpersonal.Text.ToString();
			ret.TopLevel = false;
			ret.Parent = panelanidado;
			ret.Show();
		}

		private void txtfolio_TextChanged(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void btncel_Click(object sender, EventArgs e)
		{
		}

		private void btnelectro_Click(object sender, EventArgs e)
		{
			Mercadolibre_publicadas ss = new Mercadolibre_publicadas();
			ss.ShowDialog();
		}

		private void btnaudio_Click(object sender, EventArgs e)
		{
			Mercadolibre_vendidas ss = new Mercadolibre_vendidas();
			ss.ShowDialog();
		}

		private void Recepcion_Load(object sender, EventArgs e)
		{
		}

		private void label9_Click(object sender, EventArgs e)
		{
		}

		private void btnnuevo_Click(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.Show();
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			RecepcionBuscar ss = new RecepcionBuscar();
			ss.Show();
		}

		private void btnhistorial_Click(object sender, EventArgs e)
		{
			RecepcionHistorial his = new RecepcionHistorial();
			his.Show();
		}

		private void btntodas_Click(object sender, EventArgs e)
		{
			Mercadolibre_todas ss = new Mercadolibre_todas();
			ss.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void panelanidado_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Mercadolibre_ventas ss = new Mercadolibre_ventas();
			ss.ShowDialog();
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
			panelanidado = new System.Windows.Forms.Panel();
			label9 = new System.Windows.Forms.Label();
			msjadm = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btntodas = new System.Windows.Forms.Button();
			btnpendiente = new System.Windows.Forms.Button();
			btnnuevo = new System.Windows.Forms.Button();
			btnvendidas = new System.Windows.Forms.Button();
			btnpublicadas = new System.Windows.Forms.Button();
			txtpersonal = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			SuspendLayout();
			panelanidado.BackColor = System.Drawing.SystemColors.Control;
			panelanidado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panelanidado.Location = new System.Drawing.Point(15, 103);
			panelanidado.Margin = new System.Windows.Forms.Padding(2);
			panelanidado.Name = "panelanidado";
			panelanidado.Size = new System.Drawing.Size(1045, 581);
			panelanidado.TabIndex = 22;
			panelanidado.Paint += new System.Windows.Forms.PaintEventHandler(panelanidado_Paint);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(11, 9);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(145, 24);
			label9.TabIndex = 27;
			label9.Text = "Mercado Libre";
			label9.Click += new System.EventHandler(label9_Click);
			msjadm.AutoSize = true;
			msjadm.BackColor = System.Drawing.SystemColors.ActiveCaption;
			msjadm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			msjadm.ForeColor = System.Drawing.SystemColors.InfoText;
			msjadm.Location = new System.Drawing.Point(88, 662);
			msjadm.Name = "msjadm";
			msjadm.Size = new System.Drawing.Size(0, 20);
			msjadm.TabIndex = 0;
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button3);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(msjadm);
			panel1.Controls.Add(btntodas);
			panel1.Controls.Add(btnpendiente);
			panel1.Controls.Add(btnnuevo);
			panel1.Controls.Add(btnvendidas);
			panel1.Controls.Add(btnpublicadas);
			panel1.ForeColor = System.Drawing.SystemColors.HighlightText;
			panel1.Location = new System.Drawing.Point(15, 43);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1045, 55);
			panel1.TabIndex = 30;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button3.ForeColor = System.Drawing.SystemColors.ControlText;
			button3.Image = Electronica.Properties.Resources.shopping_cart;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(919, 8);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(114, 36);
			button3.TabIndex = 30;
			button3.Text = "      Ventas";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.SystemColors.Desktop;
			button1.Image = Electronica.Properties.Resources.hold;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(705, 8);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(174, 34);
			button1.TabIndex = 29;
			button1.Text = "     Solicitudes de taller";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			btntodas.FlatAppearance.BorderSize = 0;
			btntodas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btntodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btntodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btntodas.ForeColor = System.Drawing.SystemColors.Desktop;
			btntodas.Image = Electronica.Properties.Resources.notepad;
			btntodas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btntodas.Location = new System.Drawing.Point(578, 8);
			btntodas.Margin = new System.Windows.Forms.Padding(2);
			btntodas.Name = "btntodas";
			btntodas.Size = new System.Drawing.Size(112, 34);
			btntodas.TabIndex = 28;
			btntodas.Text = "     Ver Todas";
			btntodas.UseVisualStyleBackColor = true;
			btntodas.Click += new System.EventHandler(btntodas_Click);
			btnpendiente.FlatAppearance.BorderSize = 0;
			btnpendiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnpendiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnpendiente.ForeColor = System.Drawing.SystemColors.Desktop;
			btnpendiente.Image = Electronica.Properties.Resources._unchecked;
			btnpendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnpendiente.Location = new System.Drawing.Point(124, 8);
			btnpendiente.Margin = new System.Windows.Forms.Padding(2);
			btnpendiente.Name = "btnpendiente";
			btnpendiente.Size = new System.Drawing.Size(148, 34);
			btnpendiente.TabIndex = 24;
			btnpendiente.Text = "Pendientes";
			btnpendiente.UseVisualStyleBackColor = true;
			btnpendiente.Click += new System.EventHandler(btncel_Click);
			btnnuevo.FlatAppearance.BorderSize = 0;
			btnnuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnnuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnnuevo.ForeColor = System.Drawing.SystemColors.Desktop;
			btnnuevo.Image = Electronica.Properties.Resources.plus__1_;
			btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnnuevo.Location = new System.Drawing.Point(2, 8);
			btnnuevo.Margin = new System.Windows.Forms.Padding(2);
			btnnuevo.Name = "btnnuevo";
			btnnuevo.Size = new System.Drawing.Size(101, 34);
			btnnuevo.TabIndex = 23;
			btnnuevo.Text = "     Nuevo";
			btnnuevo.UseVisualStyleBackColor = true;
			btnnuevo.Click += new System.EventHandler(btntele_Click);
			btnvendidas.FlatAppearance.BorderSize = 0;
			btnvendidas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnvendidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnvendidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnvendidas.ForeColor = System.Drawing.SystemColors.Desktop;
			btnvendidas.Image = Electronica.Properties.Resources.package_for_delivery;
			btnvendidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnvendidas.Location = new System.Drawing.Point(440, 8);
			btnvendidas.Margin = new System.Windows.Forms.Padding(2);
			btnvendidas.Name = "btnvendidas";
			btnvendidas.Size = new System.Drawing.Size(114, 34);
			btnvendidas.TabIndex = 26;
			btnvendidas.Text = "    Vendidas";
			btnvendidas.UseVisualStyleBackColor = true;
			btnvendidas.Click += new System.EventHandler(btnaudio_Click);
			btnpublicadas.FlatAppearance.BorderSize = 0;
			btnpublicadas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnpublicadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnpublicadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnpublicadas.ForeColor = System.Drawing.SystemColors.Desktop;
			btnpublicadas.Image = Electronica.Properties.Resources.tick_inside_circle;
			btnpublicadas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnpublicadas.Location = new System.Drawing.Point(287, 8);
			btnpublicadas.Margin = new System.Windows.Forms.Padding(2);
			btnpublicadas.Name = "btnpublicadas";
			btnpublicadas.Size = new System.Drawing.Size(127, 34);
			btnpublicadas.TabIndex = 25;
			btnpublicadas.Text = "   Publicadas";
			btnpublicadas.UseVisualStyleBackColor = true;
			btnpublicadas.Click += new System.EventHandler(btnelectro_Click);
			txtpersonal.Location = new System.Drawing.Point(952, 9);
			txtpersonal.Margin = new System.Windows.Forms.Padding(2);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(76, 20);
			txtpersonal.TabIndex = 31;
			txtpersonal.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1082, 707);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(panel1);
			base.Controls.Add(label9);
			base.Controls.Add(panelanidado);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Mercadolibre";
			Text = "Recepcion";
			base.Load += new System.EventHandler(Recepcion_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
