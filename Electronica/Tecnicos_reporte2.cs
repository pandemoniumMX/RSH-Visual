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
            this.txtfalla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsolucion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtconclusion = new System.Windows.Forms.TextBox();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsolicitud = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtfalla
            // 
            this.txtfalla.Location = new System.Drawing.Point(72, 131);
            this.txtfalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtfalla.Multiline = true;
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.ReadOnly = true;
            this.txtfalla.Size = new System.Drawing.Size(299, 145);
            this.txtfalla.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Reporte para reparacion con el equipo con el numero:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Falla especifica:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(396, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Solución específica:";
            // 
            // txtsolucion
            // 
            this.txtsolucion.Location = new System.Drawing.Point(400, 131);
            this.txtsolucion.Margin = new System.Windows.Forms.Padding(2);
            this.txtsolucion.Multiline = true;
            this.txtsolucion.Name = "txtsolucion";
            this.txtsolucion.ReadOnly = true;
            this.txtsolucion.Size = new System.Drawing.Size(302, 145);
            this.txtsolucion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(729, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Comentario final:";
            // 
            // txtconclusion
            // 
            this.txtconclusion.Location = new System.Drawing.Point(733, 131);
            this.txtconclusion.Margin = new System.Windows.Forms.Padding(2);
            this.txtconclusion.Multiline = true;
            this.txtconclusion.Name = "txtconclusion";
            this.txtconclusion.ReadOnly = true;
            this.txtconclusion.Size = new System.Drawing.Size(299, 145);
            this.txtconclusion.TabIndex = 3;
            // 
            // txtidequipo
            // 
            this.txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidequipo.Location = new System.Drawing.Point(527, 9);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.ReadOnly = true;
            this.txtidequipo.Size = new System.Drawing.Size(81, 26);
            this.txtidequipo.TabIndex = 33;
            this.txtidequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 549);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 18);
            this.label10.TabIndex = 46;
            this.label10.Text = "Pieza solicitada por el técnico:";
            // 
            // txtsolicitud
            // 
            this.txtsolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolicitud.Location = new System.Drawing.Point(312, 545);
            this.txtsolicitud.Name = "txtsolicitud";
            this.txtsolicitud.ReadOnly = true;
            this.txtsolicitud.Size = new System.Drawing.Size(178, 26);
            this.txtsolicitud.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Electronica.Properties.Resources.mail_sent__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(866, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 64);
            this.button1.TabIndex = 47;
            this.button1.Text = "      Solicitar refacción";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Tecnicos_reporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 669);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtsolicitud);
            this.Controls.Add(this.txtidequipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtconclusion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsolucion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "Tecnicos_reporte2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Historial de reportes de tecnicos";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tecnicos_reporte2_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Tecnicos_reporte2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
