using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Avisos : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		private Label label1;

		private Label label3;

		public TextBox txtaviso;

		private Button button1;

		public TextBox txtfolio;

		public Avisos()
		{
			InitializeComponent();
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de enviar este aviso?", "Confirmar envío de aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtfolio.Text))
			{
				MessageBox.Show("Campo folio vacío");
			}
			if (string.IsNullOrWhiteSpace(txtaviso.Text))
			{
				MessageBox.Show("No puede dejar el campo aviso vacío");
			}
			else
			{
				int folio = Convert.ToInt32(txtfolio.Text);
				string aviso = txtaviso.Text;
				string query = "insert into avisos(folio,aviso,estado) values('" + folio + "','" + aviso + "','Pendiente')";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					conn.Open();
					MySqlDataReader leer = cmd_query.ExecuteReader();
					MessageBox.Show("Aviso enviado correctamente");
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void txtfolio_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (char.IsDigit(v.KeyChar))
			{
				v.Handled = false;
			}
			else if (char.IsSeparator(v.KeyChar))
			{
				v.Handled = false;
			}
			else if (char.IsControl(v.KeyChar))
			{
				v.Handled = false;
			}
			else
			{
				v.Handled = true;
				MessageBox.Show("Solo Numeros");
			}
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
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtaviso = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			txtfolio = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(59, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(140, 20);
			label1.TabIndex = 18;
			label1.Text = "Folio del cliente:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(59, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(211, 20);
			label3.TabIndex = 20;
			label3.Text = "Aviso o queja en general:";
			txtaviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtaviso.Location = new System.Drawing.Point(22, 103);
			txtaviso.Margin = new System.Windows.Forms.Padding(2);
			txtaviso.Multiline = true;
			txtaviso.Name = "txtaviso";
			txtaviso.Size = new System.Drawing.Size(302, 201);
			txtaviso.TabIndex = 2;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources.mail_sent__1_;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(177, 346);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(147, 47);
			button1.TabIndex = 47;
			button1.Text = "      Enviar aviso";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfolio.Location = new System.Drawing.Point(219, 18);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(81, 26);
			txtfolio.TabIndex = 48;
			txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(347, 425);
			base.Controls.Add(txtfolio);
			base.Controls.Add(button1);
			base.Controls.Add(label3);
			base.Controls.Add(txtaviso);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Avisos";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Avisos y quejas de clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
