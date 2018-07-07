using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Tecnicos_reporte2 : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		public TextBox txtfalla;

		private Label label2;

		private Label label1;

		private Label label3;

		public TextBox txtsolucion;

		private Label label4;

		public TextBox txtconclusion;

		public TextBox txtidequipo;

		private Label label10;

		public TextBox txtsolicitud;

		private Button button1;

		public Tecnicos_reporte2()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.Show();
		}

		private void TablaClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de solicitar la refacción?", ("Confirmar solicitud de " + txtsolucion.Text) ?? "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(txtsolicitud.Text))
				{
					MessageBox.Show("Campo solicitud vacío");
				}
				else
				{
					int reporte = Convert.ToInt32(txtidequipo.Text);
					string query = "update reportes_tecnicos set solicitud='Solicitado' where id_equipo='" + reporte + "'";
					MySqlCommand cmd_query = new MySqlCommand(query, conn);
					try
					{
						conn.Open();
						MySqlDataReader leer = cmd_query.ExecuteReader();
						MessageBox.Show("Solicitud hecha correctamente");
						Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
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
			txtfalla = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtsolucion = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtconclusion = new System.Windows.Forms.TextBox();
			txtidequipo = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			txtsolicitud = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			txtfalla.Location = new System.Drawing.Point(72, 131);
			txtfalla.Margin = new System.Windows.Forms.Padding(2);
			txtfalla.Multiline = true;
			txtfalla.Name = "txtfalla";
			txtfalla.ReadOnly = true;
			txtfalla.Size = new System.Drawing.Size(299, 145);
			txtfalla.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(520, 24);
			label2.TabIndex = 17;
			label2.Text = "Reporte para reparacion con el equipo con el numero:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(68, 109);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(139, 20);
			label1.TabIndex = 18;
			label1.Text = "Falla especifica:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(396, 109);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(169, 20);
			label3.TabIndex = 20;
			label3.Text = "Solución específica:";
			txtsolucion.Location = new System.Drawing.Point(400, 131);
			txtsolucion.Margin = new System.Windows.Forms.Padding(2);
			txtsolucion.Multiline = true;
			txtsolucion.Name = "txtsolucion";
			txtsolucion.ReadOnly = true;
			txtsolucion.Size = new System.Drawing.Size(302, 145);
			txtsolucion.TabIndex = 2;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(729, 108);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(145, 20);
			label4.TabIndex = 22;
			label4.Text = "Comentario final:";
			txtconclusion.Location = new System.Drawing.Point(733, 131);
			txtconclusion.Margin = new System.Windows.Forms.Padding(2);
			txtconclusion.Multiline = true;
			txtconclusion.Name = "txtconclusion";
			txtconclusion.ReadOnly = true;
			txtconclusion.Size = new System.Drawing.Size(299, 145);
			txtconclusion.TabIndex = 3;
			txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidequipo.Location = new System.Drawing.Point(527, 9);
			txtidequipo.Name = "txtidequipo";
			txtidequipo.ReadOnly = true;
			txtidequipo.Size = new System.Drawing.Size(81, 26);
			txtidequipo.TabIndex = 33;
			txtidequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(87, 549);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(208, 18);
			label10.TabIndex = 46;
			label10.Text = "Pieza solicitada por el técnico:";
			txtsolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolicitud.Location = new System.Drawing.Point(312, 545);
			txtsolicitud.Name = "txtsolicitud";
			txtsolicitud.ReadOnly = true;
			txtsolicitud.Size = new System.Drawing.Size(178, 26);
			txtsolicitud.TabIndex = 45;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources.mail_sent__1_;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(866, 527);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(147, 64);
			button1.TabIndex = 47;
			button1.Text = "      Solicitar refacción";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 669);
			base.Controls.Add(button1);
			base.Controls.Add(label10);
			base.Controls.Add(txtsolicitud);
			base.Controls.Add(txtidequipo);
			base.Controls.Add(label4);
			base.Controls.Add(txtconclusion);
			base.Controls.Add(label3);
			base.Controls.Add(txtsolucion);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(txtfalla);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Tecnicos_reporte2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
