using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Personal_actualizar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label1;

		private Label label2;

		private Label label4;

		private Label label5;

		private Label label6;

		private Button AgregarClientes;

		private Label label7;

		public TextBox txtfoliop;

		private Label label8;

		private Label label9;

		public ComboBox combotipo;

		public TextBox txtusuario;

		public TextBox txtcontraseña;

		public TextBox txtnombre;

		public TextBox txtapellidos;

		public TextBox txtcorreo;

		public TextBox txtcelular;

		public Personal_actualizar()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Clientes_nuevos_Load(object sender, EventArgs e)
		{
		}

		private void AgregarClientes_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Los datos del personal son correctos?", "Confirmar actualización personal nuevo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(combotipo.Text))
				{
					MessageBox.Show("Campo tipo no seleccionado vacío");
				}
				if (string.IsNullOrWhiteSpace(txtnombre.Text))
				{
					MessageBox.Show("Campo nombre vacío");
				}
				if (string.IsNullOrWhiteSpace(txtapellidos.Text))
				{
					MessageBox.Show("Campo apellido vacío");
				}
				if (string.IsNullOrWhiteSpace(txtusuario.Text))
				{
					MessageBox.Show("Campo usuario vacío");
				}
				if (string.IsNullOrWhiteSpace(txtcontraseña.Text))
				{
					MessageBox.Show("Campo contraseña vacío");
				}
				if (string.IsNullOrWhiteSpace(txtcelular.Text))
				{
					MessageBox.Show("Campo celular vacío");
				}
				else
				{
					int folio = Convert.ToInt32(txtfoliop.Text);
					string tipo = combotipo.SelectedItem.ToString();
					string usuario = txtusuario.Text;
					string contraseña = txtcontraseña.Text;
					string nombre = txtnombre.Text;
					string apellido = txtapellidos.Text;
					string correo = txtcorreo.Text;
					string celular = txtcelular.Text;
					string query_insertar_clientes = "update  personal set tipo= '" + tipo + "',usuario ='" + usuario + "', contraseña='" + contraseña + "', nombre='" + nombre + "', apellidos='" + apellido + "', correo='" + correo + "', celular='" + celular + "' where id_personal ='" + folio + "'";
					MySqlCommand cmd_query_insertar_clientes = new MySqlCommand(query_insertar_clientes, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_query_insertar_clientes.ExecuteReader();
						MessageBox.Show("Personal actualizado correctamente");
						conn.Close();
						Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
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

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (txtcorreo.Text.Length == 0)
			{
				v.KeyChar = v.KeyChar.ToString().ToUpper().ToCharArray()[0];
			}
		}

		private void combotipo_SelectedIndexChanged(object sender, EventArgs e)
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
			txtnombre = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtapellidos = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtcorreo = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtcelular = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			AgregarClientes = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			txtfoliop = new System.Windows.Forms.TextBox();
			txtcontraseña = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtusuario = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			combotipo = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(21, 43);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(124, 20);
			label1.TabIndex = 0;
			label1.Text = "Tipo de Usuario:";
			label1.Click += new System.EventHandler(label1_Click);
			txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtnombre.Location = new System.Drawing.Point(123, 181);
			txtnombre.Name = "txtnombre";
			txtnombre.Size = new System.Drawing.Size(187, 26);
			txtnombre.TabIndex = 4;
			txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtnombre.TextChanged += new System.EventHandler(txtnombre_TextChanged);
			txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtnombre_KeyPress);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(21, 184);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(87, 20);
			label2.TabIndex = 2;
			label2.Text = "Nombre(s):";
			txtapellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtapellidos.Location = new System.Drawing.Point(123, 229);
			txtapellidos.Name = "txtapellidos";
			txtapellidos.Size = new System.Drawing.Size(187, 26);
			txtapellidos.TabIndex = 5;
			txtapellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtapellidos.TextChanged += new System.EventHandler(txtapellidos_TextChanged);
			txtapellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtapellidos_KeyPress);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(21, 232);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(77, 20);
			label4.TabIndex = 4;
			label4.Text = "Apellidos:";
			txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcorreo.Location = new System.Drawing.Point(123, 275);
			txtcorreo.Name = "txtcorreo";
			txtcorreo.Size = new System.Drawing.Size(187, 26);
			txtcorreo.TabIndex = 6;
			txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcorreo_KeyPress);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(21, 278);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 20);
			label5.TabIndex = 10;
			label5.Text = "Correo:";
			txtcelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcelular.Location = new System.Drawing.Point(123, 316);
			txtcelular.Name = "txtcelular";
			txtcelular.Size = new System.Drawing.Size(187, 26);
			txtcelular.TabIndex = 7;
			txtcelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcelular.TextChanged += new System.EventHandler(txtcelular_TextChanged);
			txtcelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcelular_KeyPress);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(21, 319);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(62, 20);
			label6.TabIndex = 8;
			label6.Text = "Celular:";
			AgregarClientes.FlatAppearance.BorderSize = 0;
			AgregarClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			AgregarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			AgregarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			AgregarClientes.Image = Electronica.Properties.Resources._003_refresh_button;
			AgregarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			AgregarClientes.Location = new System.Drawing.Point(153, 357);
			AgregarClientes.Name = "AgregarClientes";
			AgregarClientes.Size = new System.Drawing.Size(139, 45);
			AgregarClientes.TabIndex = 8;
			AgregarClientes.Text = "      Actualizar";
			AgregarClientes.UseVisualStyleBackColor = true;
			AgregarClientes.Click += new System.EventHandler(AgregarClientes_Click);
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(1, 9);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(41, 16);
			label7.TabIndex = 13;
			label7.Text = "Folio:";
			txtfoliop.Location = new System.Drawing.Point(77, 8);
			txtfoliop.Name = "txtfoliop";
			txtfoliop.ReadOnly = true;
			txtfoliop.Size = new System.Drawing.Size(62, 20);
			txtfoliop.TabIndex = 14;
			txtfoliop.TextChanged += new System.EventHandler(txtfoliosig_TextChanged);
			txtcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcontraseña.Location = new System.Drawing.Point(123, 133);
			txtcontraseña.Name = "txtcontraseña";
			txtcontraseña.Size = new System.Drawing.Size(187, 26);
			txtcontraseña.TabIndex = 3;
			txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcontraseña.UseSystemPasswordChar = true;
			txtcontraseña.TextChanged += new System.EventHandler(textBox2_TextChanged);
			txtcontraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcontraseña_KeyPress);
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(21, 136);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(96, 20);
			label8.TabIndex = 18;
			label8.Text = "Contraseña:";
			txtusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtusuario.Location = new System.Drawing.Point(123, 85);
			txtusuario.Name = "txtusuario";
			txtusuario.Size = new System.Drawing.Size(187, 26);
			txtusuario.TabIndex = 2;
			txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(21, 88);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(68, 20);
			label9.TabIndex = 16;
			label9.Text = "Usuario:";
			combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combotipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combotipo.FormattingEnabled = true;
			combotipo.Items.AddRange(new object[7]
			{
				"Administrador",
				"Jefe de Tecnicos",
				"Jefe de Taller",
				"Jefe de Bodega",
				"Tecnico",
				"Recepcion",
				"Chofer"
			});
			combotipo.Location = new System.Drawing.Point(140, 40);
			combotipo.Margin = new System.Windows.Forms.Padding(2);
			combotipo.Name = "combotipo";
			combotipo.Size = new System.Drawing.Size(170, 28);
			combotipo.TabIndex = 1;
			combotipo.SelectedIndexChanged += new System.EventHandler(combotipo_SelectedIndexChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(330, 445);
			base.Controls.Add(combotipo);
			base.Controls.Add(txtcontraseña);
			base.Controls.Add(label8);
			base.Controls.Add(txtusuario);
			base.Controls.Add(label9);
			base.Controls.Add(txtfoliop);
			base.Controls.Add(label7);
			base.Controls.Add(AgregarClientes);
			base.Controls.Add(txtcorreo);
			base.Controls.Add(label5);
			base.Controls.Add(txtcelular);
			base.Controls.Add(label6);
			base.Controls.Add(txtapellidos);
			base.Controls.Add(label4);
			base.Controls.Add(txtnombre);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Personal_actualizar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Actualizar Personal";
			base.Load += new System.EventHandler(Clientes_nuevos_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
