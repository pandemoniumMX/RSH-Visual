using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Recepcion2 : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Button btnverificar;

		private Button btnbuscar;

		private Button btnnuevo;

		private Button btnhistorial;

		private Label label1;

		public TextBox txtfolio;

		public TextBox txtnombre;

		public TextBox txtapellido;

		public TextBox txtdireccion;

		public TextBox txtcorreo;

		public TextBox txtcelular;

		public TextBox txtpuntos;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		public TextBox txtfecha;

		private Label label2;

		private Panel panelanidado;

		private Button btntele;

		private Button btnelectro;

		private Label label9;

		public Recepcion2()
		{
			InitializeComponent();
		}

		private void limpiarpanelanidado()
		{
			if (panelanidado.Controls.Count > 0)
			{
				panelanidado.Controls.RemoveAt(0);
			}
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

		private void borrarcampos()
		{
			txtapellido.Clear();
			txtcelular.Clear();
			txtcorreo.Clear();
			txtdireccion.Clear();
			txtfolio.Clear();
			txtnombre.Clear();
			txtpuntos.Clear();
		}

		public void btnverificar_Click(object sender, EventArgs e)
		{
			string query_verificar = "Select * from clientes where id_folio = '" + txtfolio.Text + "'";
			MySqlCommand cmd_query_verificar = new MySqlCommand(query_verificar, conn);
			try
			{
				conn.Open();
				MySqlDataReader leerusuario = cmd_query_verificar.ExecuteReader();
				while (leerusuario.Read())
				{
					string nombre = leerusuario.GetString("nombre");
					string apellido = leerusuario.GetString("apellidos");
					string direccion = leerusuario.GetString("direccion");
					string correo = leerusuario.GetString("correo");
					string celular = leerusuario.GetString("celular");
					string fecha = leerusuario.GetString("fecha");
					int puntos = leerusuario.GetInt32("puntos");
					txtnombre.Text = nombre;
					txtapellido.Text = apellido;
					txtdireccion.Text = direccion;
					txtcorreo.Text = correo;
					txtcelular.Text = celular;
					txtpuntos.Text = Convert.ToString(puntos);
					txtfecha.Text = fecha;
					
					btntele.Visible = true;
					btnelectro.Visible = true;
					btnhistorial.Visible = true;
				}
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btntele_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			RecepcionTelevisores ret = new RecepcionTelevisores();
			ret.txtidoculto.Text = txtfolio.Text.ToString();
            ret.txtnombre.Text = txtnombre.Text.ToString();
            ret.txtapellido.Text = txtapellido.Text.ToString();

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

		
		private void btnelectro_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			RecepcionOtros rec = new RecepcionOtros();
			rec.txtidoculto.Text = txtfolio.Text.ToString();
			rec.TopLevel = false;
			rec.Parent = panelanidado;
			rec.Show();
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
			ss.ShowDialog();
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			RecepcionBuscar ss = new RecepcionBuscar();
			ss.ShowDialog();
		}

		private void btnhistorial_Click(object sender, EventArgs e)
		{
			RecepcionHistorial his = new RecepcionHistorial();
			his.txt_folio.Text = txtfolio.Text.ToString();
			his.ShowDialog();
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


		private void panelanidado_Paint(object sender, PaintEventArgs e)
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.txtcelular = new System.Windows.Forms.TextBox();
            this.txtpuntos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelanidado = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnelectro = new System.Windows.Forms.Button();
            this.btntele = new System.Windows.Forms.Button();
            this.btnhistorial = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.btnverificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folio:";
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(69, 31);
            this.txtfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.ReadOnly = true;
            this.txtfolio.Size = new System.Drawing.Size(76, 20);
            this.txtfolio.TabIndex = 5;
            this.txtfolio.TextChanged += new System.EventHandler(this.txtfolio_TextChanged);
            this.txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfolio_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(78, 79);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.ReadOnly = true;
            this.txtnombre.Size = new System.Drawing.Size(136, 20);
            this.txtnombre.TabIndex = 6;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(325, 77);
            this.txtapellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.ReadOnly = true;
            this.txtapellido.Size = new System.Drawing.Size(151, 20);
            this.txtapellido.TabIndex = 7;
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(572, 79);
            this.txtdireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.ReadOnly = true;
            this.txtdireccion.Size = new System.Drawing.Size(212, 20);
            this.txtdireccion.TabIndex = 8;
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(78, 109);
            this.txtcorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.ReadOnly = true;
            this.txtcorreo.Size = new System.Drawing.Size(136, 20);
            this.txtcorreo.TabIndex = 10;
            // 
            // txtcelular
            // 
            this.txtcelular.Location = new System.Drawing.Point(325, 106);
            this.txtcelular.Margin = new System.Windows.Forms.Padding(2);
            this.txtcelular.Name = "txtcelular";
            this.txtcelular.ReadOnly = true;
            this.txtcelular.Size = new System.Drawing.Size(151, 20);
            this.txtcelular.TabIndex = 11;
            // 
            // txtpuntos
            // 
            this.txtpuntos.Location = new System.Drawing.Point(572, 106);
            this.txtpuntos.Margin = new System.Windows.Forms.Padding(2);
            this.txtpuntos.Name = "txtpuntos";
            this.txtpuntos.ReadOnly = true;
            this.txtpuntos.Size = new System.Drawing.Size(76, 20);
            this.txtpuntos.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Apellidos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Celular:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(489, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Direccion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(489, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Puntos:";
            // 
            // txtfecha
            // 
            this.txtfecha.BackColor = System.Drawing.SystemColors.Control;
            this.txtfecha.Location = new System.Drawing.Point(96, 637);
            this.txtfecha.Margin = new System.Windows.Forms.Padding(2);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(144, 20);
            this.txtfecha.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 640);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Miembro desde:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelanidado
            // 
            this.panelanidado.BackColor = System.Drawing.SystemColors.Control;
            this.panelanidado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelanidado.Location = new System.Drawing.Point(118, 200);
            this.panelanidado.Margin = new System.Windows.Forms.Padding(2);
            this.panelanidado.Name = "panelanidado";
            this.panelanidado.Size = new System.Drawing.Size(857, 419);
            this.panelanidado.TabIndex = 22;
            this.panelanidado.Paint += new System.Windows.Forms.PaintEventHandler(this.panelanidado_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, -1);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "Orden de Servicio:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnelectro
            // 
            this.btnelectro.BackColor = System.Drawing.SystemColors.Control;
            this.btnelectro.FlatAppearance.BorderSize = 0;
            this.btnelectro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnelectro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnelectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnelectro.Image = global::Electronica.Properties.Resources._001_washing_machine;
            this.btnelectro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnelectro.Location = new System.Drawing.Point(298, 157);
            this.btnelectro.Margin = new System.Windows.Forms.Padding(2);
            this.btnelectro.Name = "btnelectro";
            this.btnelectro.Size = new System.Drawing.Size(155, 39);
            this.btnelectro.TabIndex = 25;
            this.btnelectro.Text = "      Otros equipos";
            this.btnelectro.UseVisualStyleBackColor = false;
            this.btnelectro.Click += new System.EventHandler(this.btnelectro_Click);
            // 
            // btntele
            // 
            this.btntele.BackColor = System.Drawing.SystemColors.Control;
            this.btntele.FlatAppearance.BorderSize = 0;
            this.btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntele.Image = global::Electronica.Properties.Resources._005_computer_screen;
            this.btntele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntele.Location = new System.Drawing.Point(143, 157);
            this.btntele.Margin = new System.Windows.Forms.Padding(2);
            this.btntele.Name = "btntele";
            this.btntele.Size = new System.Drawing.Size(127, 39);
            this.btntele.TabIndex = 23;
            this.btntele.Text = "       Televisores";
            this.btntele.UseVisualStyleBackColor = false;
            this.btntele.Click += new System.EventHandler(this.btntele_Click);
            // 
            // btnhistorial
            // 
            this.btnhistorial.FlatAppearance.BorderSize = 0;
            this.btnhistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnhistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhistorial.Image = global::Electronica.Properties.Resources.history_clock_button;
            this.btnhistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhistorial.Location = new System.Drawing.Point(162, 27);
            this.btnhistorial.Margin = new System.Windows.Forms.Padding(2);
            this.btnhistorial.Name = "btnhistorial";
            this.btnhistorial.Size = new System.Drawing.Size(108, 29);
            this.btnhistorial.TabIndex = 3;
            this.btnhistorial.Text = "    Historial";
            this.btnhistorial.UseVisualStyleBackColor = true;
            this.btnhistorial.Click += new System.EventHandler(this.btnhistorial_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.FlatAppearance.BorderSize = 0;
            this.btnnuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnuevo.Image = global::Electronica.Properties.Resources.new_user;
            this.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnuevo.Location = new System.Drawing.Point(969, 26);
            this.btnnuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(96, 30);
            this.btnnuevo.TabIndex = 2;
            this.btnnuevo.Text = "   Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = true;
            this.btnnuevo.Visible = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.FlatAppearance.BorderSize = 0;
            this.btnbuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.Image = global::Electronica.Properties.Resources.magnifier;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(854, 26);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(94, 30);
            this.btnbuscar.TabIndex = 1;
            this.btnbuscar.Text = "    Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Visible = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnverificar
            // 
            this.btnverificar.FlatAppearance.BorderSize = 0;
            this.btnverificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnverificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnverificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverificar.Image = global::Electronica.Properties.Resources.tick_inside_circle;
            this.btnverificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnverificar.Location = new System.Drawing.Point(730, 26);
            this.btnverificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnverificar.Name = "btnverificar";
            this.btnverificar.Size = new System.Drawing.Size(105, 30);
            this.btnverificar.TabIndex = 0;
            this.btnverificar.Text = "    Verificar";
            this.btnverificar.UseVisualStyleBackColor = true;
            this.btnverificar.Visible = false;
            this.btnverificar.Click += new System.EventHandler(this.btnverificar_Click);
            // 
            // Recepcion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnelectro);
            this.Controls.Add(this.btntele);
            this.Controls.Add(this.panelanidado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpuntos);
            this.Controls.Add(this.txtcelular);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnhistorial);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.btnverificar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Recepcion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Orden de Servicio";
            this.Load += new System.EventHandler(this.Recepcion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recepcion2_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Recepcion2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
