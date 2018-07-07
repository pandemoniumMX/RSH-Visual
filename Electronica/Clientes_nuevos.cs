using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Clientes_nuevos : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label1;

		private TextBox txtfolio;

		private TextBox txtnombre;

		private Label label2;

		private TextBox txtdireccion;

		private Label label3;

		private TextBox txtapellidos;

		private Label label4;

		private TextBox txtcorreo;

		private Label label5;

		private TextBox txtcelular;

		private Label label6;

		private Button AgregarClientes;

		public Clientes_nuevos()
		{
			InitializeComponent();
			string query_ultimo_folio = "SELECT id_folio FROM  `clientes` ORDER BY  `fecha` DESC LIMIT 1";
			MySqlCommand cmd_query_ultimo_folio = new MySqlCommand(query_ultimo_folio, conn);
			try
			{
				conn.Open();
				MySqlDataReader leerfolio = cmd_query_ultimo_folio.ExecuteReader();
				while (leerfolio.Read())
				{
					int folio = leerfolio.GetInt32("id_folio");
					txtfolio.Text = Convert.ToString(folio + 1);
				}
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Clientes_nuevos_Load(object sender, EventArgs e)
		{
		}

		private void AgregarClientes_Click(object sender, EventArgs e)
		{
			int folio = Convert.ToInt32(txtfolio.Text);
			string nombre = txtnombre.Text;
			string apellido = txtapellidos.Text;
			string direccion = txtdireccion.Text;
			string correo = txtcorreo.Text;
			string celular = txtcelular.Text;
			string query_insertar_clientes = "insert into clientes (id_folio, nombre, apellidos, direccion, correo, celular) values ('" + folio + "','" + nombre + "','" + apellido + "','" + direccion + "','" + correo + "','" + celular + "')";
			string query_check = "select * from clientes where celular='" + celular + "'";
			MySqlCommand cmd_query_check = new MySqlCommand(query_check, conn);
			MySqlCommand cmd_query_insertar_clientes = new MySqlCommand(query_insertar_clientes, conn);
			DialogResult dr = MessageBox.Show("¿Los datos del cliente son correctos?", "Confirmar cliente nuevo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtfolio.Text))
			{
				MessageBox.Show("Campo folio vacío");
			}
			if (string.IsNullOrWhiteSpace(txtnombre.Text))
			{
				MessageBox.Show("Campo nombre vacío");
			}
			if (string.IsNullOrWhiteSpace(txtapellidos.Text))
			{
				MessageBox.Show("Campo apellido vacío");
			}
			if (string.IsNullOrWhiteSpace(txtdireccion.Text))
			{
				MessageBox.Show("Campo direccion vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcelular.Text))
			{
				MessageBox.Show("Campo celular vacío");
			}
			try
			{
				conn.Open();
				MySqlDataReader leercomando = cmd_query_insertar_clientes.ExecuteReader();
				MessageBox.Show("Cliente con el folio " + folio + " agregado satisfactoriamente");
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void txtfoliosig_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtfolio_TextChanged(object sender, EventArgs e)
		{
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

		private void txtnombre_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (char.IsLetter(v.KeyChar))
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
				MessageBox.Show("Solo Letras");
			}
			if (txtnombre.Text.Length == 0)
			{
				v.KeyChar = v.KeyChar.ToString().ToUpper().ToCharArray()[0];
			}
		}

		private void txtapellidos_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtapellidos_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (char.IsLetter(v.KeyChar))
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
				MessageBox.Show("Solo Letras");
			}
			if (txtapellidos.Text.Length == 0)
			{
				v.KeyChar = v.KeyChar.ToString().ToUpper().ToCharArray()[0];
			}
		}

		private void txtdireccion_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (txtdireccion.Text.Length == 0)
			{
				v.KeyChar = v.KeyChar.ToString().ToUpper().ToCharArray()[0];
			}
		}

		private void txtcelular_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtcelular_KeyPress(object sender, KeyPressEventArgs v)
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

		private void txtdireccion_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtnombre_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtcorreo_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (txtcorreo.Text.Length == 0)
			{
				v.KeyChar = v.KeyChar.ToString().ToUpper().ToCharArray()[0];
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
			txtfolio = new System.Windows.Forms.TextBox();
			txtnombre = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtdireccion = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtapellidos = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtcorreo = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtcelular = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			AgregarClientes = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(21, 55);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 20);
			label1.TabIndex = 0;
			label1.Text = "Folio:";
			label1.Click += new System.EventHandler(label1_Click);
			txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfolio.Location = new System.Drawing.Point(109, 52);
			txtfolio.Name = "txtfolio";
			txtfolio.ReadOnly = true;
			txtfolio.Size = new System.Drawing.Size(273, 26);
			txtfolio.TabIndex = 1;
			txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtfolio.TextChanged += new System.EventHandler(txtfolio_TextChanged);
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtnombre.Location = new System.Drawing.Point(109, 100);
			txtnombre.Name = "txtnombre";
			txtnombre.Size = new System.Drawing.Size(273, 26);
			txtnombre.TabIndex = 2;
			txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtnombre.TextChanged += new System.EventHandler(txtnombre_TextChanged);
			txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtnombre_KeyPress);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(21, 103);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(87, 20);
			label2.TabIndex = 2;
			label2.Text = "Nombre(s):";
			txtdireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtdireccion.Location = new System.Drawing.Point(109, 196);
			txtdireccion.Name = "txtdireccion";
			txtdireccion.Size = new System.Drawing.Size(273, 26);
			txtdireccion.TabIndex = 4;
			txtdireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtdireccion.TextChanged += new System.EventHandler(txtdireccion_TextChanged);
			txtdireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtdireccion_KeyPress);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(21, 199);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 20);
			label3.TabIndex = 6;
			label3.Text = "Direccion:";
			txtapellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtapellidos.Location = new System.Drawing.Point(109, 148);
			txtapellidos.Name = "txtapellidos";
			txtapellidos.Size = new System.Drawing.Size(273, 26);
			txtapellidos.TabIndex = 3;
			txtapellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtapellidos.TextChanged += new System.EventHandler(txtapellidos_TextChanged);
			txtapellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtapellidos_KeyPress);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(21, 151);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(77, 20);
			label4.TabIndex = 4;
			label4.Text = "Apellidos:";
			txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcorreo.Location = new System.Drawing.Point(109, 238);
			txtcorreo.Name = "txtcorreo";
			txtcorreo.Size = new System.Drawing.Size(273, 26);
			txtcorreo.TabIndex = 5;
			txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcorreo_KeyPress);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(21, 241);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 20);
			label5.TabIndex = 10;
			label5.Text = "Correo:";
			txtcelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcelular.Location = new System.Drawing.Point(109, 279);
			txtcelular.Name = "txtcelular";
			txtcelular.Size = new System.Drawing.Size(273, 26);
			txtcelular.TabIndex = 6;
			txtcelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcelular.TextChanged += new System.EventHandler(txtcelular_TextChanged);
			txtcelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcelular_KeyPress);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(21, 282);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(62, 20);
			label6.TabIndex = 8;
			label6.Text = "Celular:";
			AgregarClientes.FlatAppearance.BorderSize = 0;
			AgregarClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			AgregarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			AgregarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			AgregarClientes.Image = Electronica.Properties.Resources.plus;
			AgregarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			AgregarClientes.Location = new System.Drawing.Point(264, 325);
			AgregarClientes.Name = "AgregarClientes";
			AgregarClientes.Size = new System.Drawing.Size(118, 45);
			AgregarClientes.TabIndex = 7;
			AgregarClientes.Text = "      Agregar";
			AgregarClientes.UseVisualStyleBackColor = true;
			AgregarClientes.Click += new System.EventHandler(AgregarClientes_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(414, 382);
			base.Controls.Add(AgregarClientes);
			base.Controls.Add(txtcorreo);
			base.Controls.Add(label5);
			base.Controls.Add(txtcelular);
			base.Controls.Add(label6);
			base.Controls.Add(txtdireccion);
			base.Controls.Add(label3);
			base.Controls.Add(txtapellidos);
			base.Controls.Add(label4);
			base.Controls.Add(txtnombre);
			base.Controls.Add(label2);
			base.Controls.Add(txtfolio);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Clientes_nuevos";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Clientes nuevos";
			base.Load += new System.EventHandler(Clientes_nuevos_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
