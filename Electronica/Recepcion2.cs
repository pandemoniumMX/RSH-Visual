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

		private Button btncel;

		private Button btnelectro;

		private Button btnaudio;

		private Label label9;

		private Button button1;

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
					btnaudio.Visible = true;
					btntele.Visible = true;
					btncel.Visible = true;
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
			limpiarpanelanidado();
			RecepcionTablets_Cel rec = new RecepcionTablets_Cel();
			rec.txtidoculto.Text = txtfolio.Text.ToString();
			rec.TopLevel = false;
			rec.Parent = panelanidado;
			rec.Show();
		}

		private void btnelectro_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			RecepcionElectrodomesticos rec = new RecepcionElectrodomesticos();
			rec.txtidoculto.Text = txtfolio.Text.ToString();
			rec.TopLevel = false;
			rec.Parent = panelanidado;
			rec.Show();
		}

		private void btnaudio_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			RecepcionAudio rec = new RecepcionAudio();
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

		private void button1_Click(object sender, EventArgs e)
		{
			limpiarpanelanidado();
			RecepcionLaptops rec = new RecepcionLaptops();
			rec.txtidoculto.Text = txtfolio.Text.ToString();
			rec.TopLevel = false;
			rec.Parent = panelanidado;
			rec.Show();
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
			label1 = new System.Windows.Forms.Label();
			txtfolio = new System.Windows.Forms.TextBox();
			txtnombre = new System.Windows.Forms.TextBox();
			txtapellido = new System.Windows.Forms.TextBox();
			txtdireccion = new System.Windows.Forms.TextBox();
			txtcorreo = new System.Windows.Forms.TextBox();
			txtcelular = new System.Windows.Forms.TextBox();
			txtpuntos = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			txtfecha = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			panelanidado = new System.Windows.Forms.Panel();
			label9 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			btnaudio = new System.Windows.Forms.Button();
			btnelectro = new System.Windows.Forms.Button();
			btncel = new System.Windows.Forms.Button();
			btntele = new System.Windows.Forms.Button();
			btnhistorial = new System.Windows.Forms.Button();
			btnnuevo = new System.Windows.Forms.Button();
			btnbuscar = new System.Windows.Forms.Button();
			btnverificar = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(2, 31);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(53, 20);
			label1.TabIndex = 4;
			label1.Text = "Folio:";
			txtfolio.Location = new System.Drawing.Point(69, 31);
			txtfolio.Margin = new System.Windows.Forms.Padding(2);
			txtfolio.Name = "txtfolio";
			txtfolio.ReadOnly = true;
			txtfolio.Size = new System.Drawing.Size(76, 20);
			txtfolio.TabIndex = 5;
			txtfolio.TextChanged += new System.EventHandler(txtfolio_TextChanged);
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			txtnombre.Location = new System.Drawing.Point(78, 79);
			txtnombre.Margin = new System.Windows.Forms.Padding(2);
			txtnombre.Name = "txtnombre";
			txtnombre.ReadOnly = true;
			txtnombre.Size = new System.Drawing.Size(136, 20);
			txtnombre.TabIndex = 6;
			txtapellido.Location = new System.Drawing.Point(325, 77);
			txtapellido.Margin = new System.Windows.Forms.Padding(2);
			txtapellido.Name = "txtapellido";
			txtapellido.ReadOnly = true;
			txtapellido.Size = new System.Drawing.Size(151, 20);
			txtapellido.TabIndex = 7;
			txtdireccion.Location = new System.Drawing.Point(572, 79);
			txtdireccion.Margin = new System.Windows.Forms.Padding(2);
			txtdireccion.Name = "txtdireccion";
			txtdireccion.ReadOnly = true;
			txtdireccion.Size = new System.Drawing.Size(212, 20);
			txtdireccion.TabIndex = 8;
			txtcorreo.Location = new System.Drawing.Point(78, 109);
			txtcorreo.Margin = new System.Windows.Forms.Padding(2);
			txtcorreo.Name = "txtcorreo";
			txtcorreo.ReadOnly = true;
			txtcorreo.Size = new System.Drawing.Size(136, 20);
			txtcorreo.TabIndex = 10;
			txtcelular.Location = new System.Drawing.Point(325, 106);
			txtcelular.Margin = new System.Windows.Forms.Padding(2);
			txtcelular.Name = "txtcelular";
			txtcelular.ReadOnly = true;
			txtcelular.Size = new System.Drawing.Size(151, 20);
			txtcelular.TabIndex = 11;
			txtpuntos.Location = new System.Drawing.Point(572, 106);
			txtpuntos.Margin = new System.Windows.Forms.Padding(2);
			txtpuntos.Name = "txtpuntos";
			txtpuntos.ReadOnly = true;
			txtpuntos.Size = new System.Drawing.Size(76, 20);
			txtpuntos.TabIndex = 12;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(5, 77);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(69, 20);
			label3.TabIndex = 14;
			label3.Text = "Nombre:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(5, 107);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(61, 20);
			label4.TabIndex = 15;
			label4.Text = "Correo:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(244, 77);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(77, 20);
			label5.TabIndex = 16;
			label5.Text = "Apellidos:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(259, 107);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(62, 20);
			label6.TabIndex = 17;
			label6.Text = "Celular:";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(489, 77);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(79, 20);
			label7.TabIndex = 18;
			label7.Text = "Direccion:";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(489, 107);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(63, 20);
			label8.TabIndex = 19;
			label8.Text = "Puntos:";
			txtfecha.BackColor = System.Drawing.SystemColors.Control;
			txtfecha.Location = new System.Drawing.Point(96, 637);
			txtfecha.Margin = new System.Windows.Forms.Padding(2);
			txtfecha.Name = "txtfecha";
			txtfecha.Size = new System.Drawing.Size(144, 20);
			txtfecha.TabIndex = 20;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(10, 640);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(82, 13);
			label2.TabIndex = 21;
			label2.Text = "Miembro desde:";
			label2.Click += new System.EventHandler(label2_Click);
			panelanidado.BackColor = System.Drawing.SystemColors.Control;
			panelanidado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panelanidado.Location = new System.Drawing.Point(118, 200);
			panelanidado.Margin = new System.Windows.Forms.Padding(2);
			panelanidado.Name = "panelanidado";
			panelanidado.Size = new System.Drawing.Size(857, 419);
			panelanidado.TabIndex = 22;
			panelanidado.Paint += new System.Windows.Forms.PaintEventHandler(panelanidado_Paint);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(2, -1);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(186, 24);
			label9.TabIndex = 27;
			label9.Text = "Orden de Servicio:";
			label9.Click += new System.EventHandler(label9_Click);
			button1.BackColor = System.Drawing.SystemColors.Control;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Image = Electronica.Properties.Resources._002_laptop1;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(642, 157);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(135, 39);
			button1.TabIndex = 28;
			button1.Text = "       Laptop/Cpu";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			btnaudio.BackColor = System.Drawing.SystemColors.Control;
			btnaudio.FlatAppearance.BorderSize = 0;
			btnaudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnaudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnaudio.Image = Electronica.Properties.Resources._003_big_music_player_speaker;
			btnaudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnaudio.Location = new System.Drawing.Point(475, 157);
			btnaudio.Margin = new System.Windows.Forms.Padding(2);
			btnaudio.Name = "btnaudio";
			btnaudio.Size = new System.Drawing.Size(139, 39);
			btnaudio.TabIndex = 26;
			btnaudio.Text = "      Audio/Sonido";
			btnaudio.UseVisualStyleBackColor = false;
			btnaudio.Click += new System.EventHandler(btnaudio_Click);
			btnelectro.BackColor = System.Drawing.SystemColors.Control;
			btnelectro.FlatAppearance.BorderSize = 0;
			btnelectro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnelectro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnelectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnelectro.Image = Electronica.Properties.Resources._001_washing_machine;
			btnelectro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnelectro.Location = new System.Drawing.Point(796, 157);
			btnelectro.Margin = new System.Windows.Forms.Padding(2);
			btnelectro.Name = "btnelectro";
			btnelectro.Size = new System.Drawing.Size(140, 39);
			btnelectro.TabIndex = 25;
			btnelectro.Text = "      Linea blanca";
			btnelectro.UseVisualStyleBackColor = false;
			btnelectro.Click += new System.EventHandler(btnelectro_Click);
			btncel.BackColor = System.Drawing.SystemColors.Control;
			btncel.FlatAppearance.BorderSize = 0;
			btncel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btncel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btncel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btncel.Image = Electronica.Properties.Resources._004_smartphone_call;
			btncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btncel.Location = new System.Drawing.Point(302, 157);
			btncel.Margin = new System.Windows.Forms.Padding(2);
			btncel.Name = "btncel";
			btncel.Size = new System.Drawing.Size(148, 39);
			btncel.TabIndex = 24;
			btncel.Text = "     Celular / Tablet";
			btncel.UseVisualStyleBackColor = false;
			btncel.Click += new System.EventHandler(btncel_Click);
			btntele.BackColor = System.Drawing.SystemColors.Control;
			btntele.FlatAppearance.BorderSize = 0;
			btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btntele.Image = Electronica.Properties.Resources._005_computer_screen;
			btntele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btntele.Location = new System.Drawing.Point(143, 157);
			btntele.Margin = new System.Windows.Forms.Padding(2);
			btntele.Name = "btntele";
			btntele.Size = new System.Drawing.Size(127, 39);
			btntele.TabIndex = 23;
			btntele.Text = "       Televisores";
			btntele.UseVisualStyleBackColor = false;
			btntele.Click += new System.EventHandler(btntele_Click);
			btnhistorial.FlatAppearance.BorderSize = 0;
			btnhistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnhistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnhistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnhistorial.Image = Electronica.Properties.Resources.history_clock_button;
			btnhistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnhistorial.Location = new System.Drawing.Point(162, 27);
			btnhistorial.Margin = new System.Windows.Forms.Padding(2);
			btnhistorial.Name = "btnhistorial";
			btnhistorial.Size = new System.Drawing.Size(108, 29);
			btnhistorial.TabIndex = 3;
			btnhistorial.Text = "    Historial";
			btnhistorial.UseVisualStyleBackColor = true;
			btnhistorial.Click += new System.EventHandler(btnhistorial_Click);
			btnnuevo.FlatAppearance.BorderSize = 0;
			btnnuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnnuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnnuevo.Image = Electronica.Properties.Resources.new_user;
			btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnnuevo.Location = new System.Drawing.Point(969, 26);
			btnnuevo.Margin = new System.Windows.Forms.Padding(2);
			btnnuevo.Name = "btnnuevo";
			btnnuevo.Size = new System.Drawing.Size(96, 30);
			btnnuevo.TabIndex = 2;
			btnnuevo.Text = "   Nuevo";
			btnnuevo.UseVisualStyleBackColor = true;
			btnnuevo.Visible = false;
			btnnuevo.Click += new System.EventHandler(btnnuevo_Click);
			btnbuscar.FlatAppearance.BorderSize = 0;
			btnbuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnbuscar.Image = Electronica.Properties.Resources.magnifier;
			btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnbuscar.Location = new System.Drawing.Point(854, 26);
			btnbuscar.Margin = new System.Windows.Forms.Padding(2);
			btnbuscar.Name = "btnbuscar";
			btnbuscar.Size = new System.Drawing.Size(94, 30);
			btnbuscar.TabIndex = 1;
			btnbuscar.Text = "    Buscar";
			btnbuscar.UseVisualStyleBackColor = true;
			btnbuscar.Visible = false;
			btnbuscar.Click += new System.EventHandler(btnbuscar_Click);
			btnverificar.FlatAppearance.BorderSize = 0;
			btnverificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnverificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnverificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnverificar.Image = Electronica.Properties.Resources.tick_inside_circle;
			btnverificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnverificar.Location = new System.Drawing.Point(730, 26);
			btnverificar.Margin = new System.Windows.Forms.Padding(2);
			btnverificar.Name = "btnverificar";
			btnverificar.Size = new System.Drawing.Size(105, 30);
			btnverificar.TabIndex = 0;
			btnverificar.Text = "    Verificar";
			btnverificar.UseVisualStyleBackColor = true;
			btnverificar.Visible = false;
			btnverificar.Click += new System.EventHandler(btnverificar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(button1);
			base.Controls.Add(label9);
			base.Controls.Add(btnaudio);
			base.Controls.Add(btnelectro);
			base.Controls.Add(btncel);
			base.Controls.Add(btntele);
			base.Controls.Add(panelanidado);
			base.Controls.Add(label2);
			base.Controls.Add(txtfecha);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(txtpuntos);
			base.Controls.Add(txtcelular);
			base.Controls.Add(txtcorreo);
			base.Controls.Add(txtdireccion);
			base.Controls.Add(txtapellido);
			base.Controls.Add(txtnombre);
			base.Controls.Add(txtfolio);
			base.Controls.Add(label1);
			base.Controls.Add(btnhistorial);
			base.Controls.Add(btnnuevo);
			base.Controls.Add(btnbuscar);
			base.Controls.Add(btnverificar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Recepcion2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Orden de Servicio";
			base.Load += new System.EventHandler(Recepcion_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
