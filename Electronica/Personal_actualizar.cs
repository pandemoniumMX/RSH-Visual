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
            this.label1 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcelular = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AgregarClientes = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfoliop = new System.Windows.Forms.TextBox();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combotipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(123, 181);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(187, 26);
            this.txtnombre.TabIndex = 4;
            this.txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre(s):";
            // 
            // txtapellidos
            // 
            this.txtapellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapellidos.Location = new System.Drawing.Point(123, 229);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(187, 26);
            this.txtapellidos.TabIndex = 5;
            this.txtapellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtapellidos.TextChanged += new System.EventHandler(this.txtapellidos_TextChanged);
            this.txtapellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapellidos_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Apellidos:";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreo.Location = new System.Drawing.Point(123, 275);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(187, 26);
            this.txtcorreo.TabIndex = 6;
            this.txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcorreo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Correo:";
            // 
            // txtcelular
            // 
            this.txtcelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcelular.Location = new System.Drawing.Point(123, 316);
            this.txtcelular.Name = "txtcelular";
            this.txtcelular.Size = new System.Drawing.Size(187, 26);
            this.txtcelular.TabIndex = 7;
            this.txtcelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcelular.TextChanged += new System.EventHandler(this.txtcelular_TextChanged);
            this.txtcelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcelular_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Celular:";
            // 
            // AgregarClientes
            // 
            this.AgregarClientes.FlatAppearance.BorderSize = 0;
            this.AgregarClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.AgregarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarClientes.Image = global::Electronica.Properties.Resources._003_refresh_button;
            this.AgregarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AgregarClientes.Location = new System.Drawing.Point(153, 357);
            this.AgregarClientes.Name = "AgregarClientes";
            this.AgregarClientes.Size = new System.Drawing.Size(139, 45);
            this.AgregarClientes.TabIndex = 8;
            this.AgregarClientes.Text = "      Actualizar";
            this.AgregarClientes.UseVisualStyleBackColor = true;
            this.AgregarClientes.Click += new System.EventHandler(this.AgregarClientes_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Folio:";
            // 
            // txtfoliop
            // 
            this.txtfoliop.Location = new System.Drawing.Point(186, 8);
            this.txtfoliop.Name = "txtfoliop";
            this.txtfoliop.ReadOnly = true;
            this.txtfoliop.Size = new System.Drawing.Size(62, 20);
            this.txtfoliop.TabIndex = 14;
            this.txtfoliop.TextChanged += new System.EventHandler(this.txtfoliosig_TextChanged);
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontraseña.Location = new System.Drawing.Point(123, 133);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(187, 26);
            this.txtcontraseña.TabIndex = 3;
            this.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcontraseña.UseSystemPasswordChar = true;
            this.txtcontraseña.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtcontraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontraseña_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Contraseña:";
            // 
            // txtusuario
            // 
            this.txtusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(123, 85);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(187, 26);
            this.txtusuario.TabIndex = 2;
            this.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Usuario:";
            // 
            // combotipo
            // 
            this.combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotipo.FormattingEnabled = true;
            this.combotipo.Items.AddRange(new object[] {
            "Administrador",
            "Jefe de Tecnicos",
            "Jefe de Taller",
            "Jefe de Bodega",
            "Tecnico",
            "Recepcion",
            "Chofer"});
            this.combotipo.Location = new System.Drawing.Point(140, 40);
            this.combotipo.Margin = new System.Windows.Forms.Padding(2);
            this.combotipo.Name = "combotipo";
            this.combotipo.Size = new System.Drawing.Size(170, 28);
            this.combotipo.TabIndex = 1;
            this.combotipo.SelectedIndexChanged += new System.EventHandler(this.combotipo_SelectedIndexChanged);
            // 
            // Personal_actualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 445);
            this.Controls.Add(this.combotipo);
            this.Controls.Add(this.txtcontraseña);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtfoliop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AgregarClientes);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcelular);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtapellidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Personal_actualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Personal";
            this.Load += new System.EventHandler(this.Clientes_nuevos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Personal_actualizar_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Personal_actualizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
