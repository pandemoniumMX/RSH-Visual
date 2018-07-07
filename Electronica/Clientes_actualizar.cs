using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Clientes_actualizar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		public TextBox txtnombre;

		private Label label2;

		public TextBox txtdireccion;

		private Label label3;

		public TextBox txtapellidos;

		private Label label4;

		public TextBox txtcorreo;

		private Label label5;

		public TextBox txtcelular;

		private Label label6;

		public Button AgregarClientes;

		public TextBox txtfolio;

		public TextBox txtpuntos;

		private Label label1;

		private Label label7;

		public Clientes_actualizar()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Clientes_actualizar_Load(object sender, EventArgs e)
		{
		}

		private void AgregarClientes_Click(object sender, EventArgs e)
		{
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
			else
			{
				int folio = Convert.ToInt32(txtfolio.Text);
				string nombre = txtnombre.Text;
				string apellido = txtapellidos.Text;
				string direccion = txtdireccion.Text;
				string correo = txtcorreo.Text;
				string celular = txtcelular.Text;
				int puntos = Convert.ToInt32(txtpuntos.Text);
				string query_insertar_clientes = "update clientes set nombre = '" + nombre + "',apellidos= '" + apellido + "',direccion = '" + direccion + "',correo = '" + correo + "',celular = '" + celular + "',puntos = '" + puntos + "' where id_folio='" + folio + "'";
				MySqlCommand cmd_query_insertar_clientes = new MySqlCommand(query_insertar_clientes, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando = cmd_query_insertar_clientes.ExecuteReader();
					MessageBox.Show("Cliente Actualizado");
					conn.Close();
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void txtpuntos_TextChanged(object sender, EventArgs v)
		{
		}

		private void txtcelular_TextChanged(object sender, EventArgs v)
		{
		}

		private void txtpuntos_KeyPress(object sender, KeyPressEventArgs v)
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
			txtfolio = new System.Windows.Forms.TextBox();
			txtpuntos = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			AgregarClientes = new System.Windows.Forms.Button();
			SuspendLayout();
			txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtnombre.Location = new System.Drawing.Point(121, 47);
			txtnombre.Name = "txtnombre";
			txtnombre.Size = new System.Drawing.Size(261, 26);
			txtnombre.TabIndex = 1;
			txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtnombre_KeyPress);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(26, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(87, 20);
			label2.TabIndex = 2;
			label2.Text = "Nombre(s):";
			txtdireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtdireccion.Location = new System.Drawing.Point(121, 143);
			txtdireccion.Name = "txtdireccion";
			txtdireccion.Size = new System.Drawing.Size(261, 26);
			txtdireccion.TabIndex = 3;
			txtdireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(26, 144);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 20);
			label3.TabIndex = 6;
			label3.Text = "Direccion:";
			txtapellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtapellidos.Location = new System.Drawing.Point(121, 95);
			txtapellidos.Name = "txtapellidos";
			txtapellidos.Size = new System.Drawing.Size(261, 26);
			txtapellidos.TabIndex = 2;
			txtapellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtapellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtapellidos_KeyPress);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(26, 96);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(77, 20);
			label4.TabIndex = 4;
			label4.Text = "Apellidos:";
			txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcorreo.Location = new System.Drawing.Point(121, 185);
			txtcorreo.Name = "txtcorreo";
			txtcorreo.Size = new System.Drawing.Size(261, 26);
			txtcorreo.TabIndex = 4;
			txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(26, 186);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 20);
			label5.TabIndex = 10;
			label5.Text = "Correo:";
			txtcelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcelular.Location = new System.Drawing.Point(121, 226);
			txtcelular.Name = "txtcelular";
			txtcelular.Size = new System.Drawing.Size(261, 26);
			txtcelular.TabIndex = 5;
			txtcelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcelular.TextChanged += new System.EventHandler(txtcelular_TextChanged);
			txtcelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcelular_KeyPress);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(26, 227);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(62, 20);
			label6.TabIndex = 8;
			label6.Text = "Celular:";
			txtfolio.Location = new System.Drawing.Point(121, 14);
			txtfolio.Name = "txtfolio";
			txtfolio.ReadOnly = true;
			txtfolio.Size = new System.Drawing.Size(117, 20);
			txtfolio.TabIndex = 13;
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			txtpuntos.Location = new System.Drawing.Point(121, 268);
			txtpuntos.Name = "txtpuntos";
			txtpuntos.ReadOnly = true;
			txtpuntos.Size = new System.Drawing.Size(261, 20);
			txtpuntos.TabIndex = 6;
			txtpuntos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtpuntos.TextChanged += new System.EventHandler(txtpuntos_TextChanged);
			txtpuntos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtpuntos_KeyPress);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(26, 266);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 20);
			label1.TabIndex = 15;
			label1.Text = "Puntos:";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(31, 12);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(47, 20);
			label7.TabIndex = 16;
			label7.Text = "Folio:";
			AgregarClientes.FlatAppearance.BorderSize = 0;
			AgregarClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			AgregarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			AgregarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			AgregarClientes.Image = Electronica.Properties.Resources._003_refresh_button1;
			AgregarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			AgregarClientes.Location = new System.Drawing.Point(238, 307);
			AgregarClientes.Name = "AgregarClientes";
			AgregarClientes.Size = new System.Drawing.Size(144, 45);
			AgregarClientes.TabIndex = 7;
			AgregarClientes.Text = "   Actualizar";
			AgregarClientes.UseVisualStyleBackColor = true;
			AgregarClientes.Click += new System.EventHandler(AgregarClientes_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(414, 382);
			base.Controls.Add(label7);
			base.Controls.Add(label1);
			base.Controls.Add(txtpuntos);
			base.Controls.Add(txtfolio);
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
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Clientes_actualizar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Actualizar Clientes";
			base.Load += new System.EventHandler(Clientes_actualizar_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
