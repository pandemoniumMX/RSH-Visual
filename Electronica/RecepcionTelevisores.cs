using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class RecepcionTelevisores : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private Recepcion rp = new Recepcion();

		private IContainer components = null;

		private Label label1;

		private Label label2;

		private ComboBox combomarca;

		private Label label3;

		private TextBox txtmodelo;

		private Label label7;

		private ComboBox comboaccesorios;

		private Label label8;

		private Label label9;

		private DateTimePicker PickerFecha;

		private TextBox txtcomentarios;

		private Label label10;

		private Button btngenerar;

		private Label label11;

		private ComboBox combolacacion;

		public TextBox txtidoculto;

		private TextBox txtfalla;

		public RecepcionTelevisores()
		{
			InitializeComponent();
		}

		private void btngenerar_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Los datos de la orden son correctos?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(combomarca.Text))
			{
				MessageBox.Show("Campo marca no asignado");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtfalla.Text))
			{
				MessageBox.Show("Campo falla vacío");
			}
			if (string.IsNullOrWhiteSpace(combolacacion.Text))
			{
				MessageBox.Show("Campo locacion no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(PickerFecha.Text))
			{
				MessageBox.Show("Campo fecha no asignada");
			}
			else
			{
				string fecha = Convert.ToDateTime(PickerFecha.Text).ToString("yyyy-MM-dd");
				string marca = combomarca.SelectedItem.ToString();
				string falla = txtfalla.Text;
				string locacion = combolacacion.SelectedItem.ToString();
				string accesorios = comboaccesorios.SelectedItem.ToString();
				string modelo = txtmodelo.Text;
				string comentarios = txtcomentarios.Text;
				int idfolio = Convert.ToInt32(txtidoculto.Text);
				string query_insertar_televisor = "insert into reparar_tv (equipo, marca, modelo, accesorios, falla, comentarios,fecha_entregar,fecha_egreso, servicio, estado,ubicacion, id_folio) values ('Television', '" + marca + "', '" + modelo + "','" + accesorios + "', '" + falla + "', '" + comentarios + "', '" + fecha + "','" + fecha + "', '" + locacion + "','Pendiente','Recepcion', '" + idfolio + "') ";
				MySqlCommand cmd_query_insertar_televisor = new MySqlCommand(query_insertar_televisor, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando = cmd_query_insertar_televisor.ExecuteReader();
					MessageBox.Show("Television agregada correctamente");
					conn.Close();
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void combomarca_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void label11_Click(object sender, EventArgs e)
		{
		}

		private void label5_Click(object sender, EventArgs e)
		{
		}

		private void label6_Click(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void txtidoculto_TextChanged(object sender, EventArgs e)
		{
		}

		private void combolacacion_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label10_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void PickerFecha_ValueChanged(object sender, EventArgs e)
		{
		}

		private void label9_Click(object sender, EventArgs e)
		{
		}

		private void label8_Click(object sender, EventArgs e)
		{
		}

		private void txtcomentarios_TextChanged(object sender, EventArgs e)
		{
		}

		private void label7_Click(object sender, EventArgs e)
		{
		}

		private void txtmodelo_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtpresupuesto_TextChanged(object sender, EventArgs e)
		{
		}

		private void combofalla_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void comboaccesorios_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void txtabono_TextChanged(object sender, EventArgs e)
		{
		}

		private void RecepcionTelevisores_Load(object sender, EventArgs e)
		{
		}

		private void txtpresupuesto_KeyPress(object sender, KeyPressEventArgs v)
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
			label2 = new System.Windows.Forms.Label();
			combomarca = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			txtmodelo = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			comboaccesorios = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			PickerFecha = new System.Windows.Forms.DateTimePicker();
			txtcomentarios = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			combolacacion = new System.Windows.Forms.ComboBox();
			txtidoculto = new System.Windows.Forms.TextBox();
			txtfalla = new System.Windows.Forms.TextBox();
			btngenerar = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(10, 11);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(254, 20);
			label1.TabIndex = 0;
			label1.Text = "Orden de Servicio Televisiones";
			label1.Click += new System.EventHandler(label1_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 44);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 13);
			label2.TabIndex = 1;
			label2.Text = "Marca:";
			label2.Click += new System.EventHandler(label2_Click);
			combomarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combomarca.FormattingEnabled = true;
			combomarca.Items.AddRange(new object[29]
			{
				"AOC",
				"Aiwa",
				"Atvio",
				"Blu Sens",
				"Blue Point",
				"Cobia",
				"DWDisplay",
				"Hisense",
				"LG",
				"Panasonic",
				"Philips",
				"Pioneer",
				"Polaroid",
				"Mangavox",
				"RCA",
				"Samsung",
				"Sanyo",
				"Sharp",
				"Speeler",
				"Spectra",
				"Sony Bravia",
				"Toshiba",
				"TCL",
				"Vech Technics",
				"Vizio",
				"Vios",
				"Viore",
				"Wgite Westin House",
				"Otros"
			});
			combomarca.Location = new System.Drawing.Point(73, 41);
			combomarca.Margin = new System.Windows.Forms.Padding(2);
			combomarca.Name = "combomarca";
			combomarca.Size = new System.Drawing.Size(178, 21);
			combomarca.TabIndex = 0;
			combomarca.SelectedIndexChanged += new System.EventHandler(combomarca_SelectedIndexChanged);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 79);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(32, 13);
			label3.TabIndex = 5;
			label3.Text = "Falla:";
			label3.Click += new System.EventHandler(label3_Click);
			txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtmodelo.Location = new System.Drawing.Point(356, 41);
			txtmodelo.Margin = new System.Windows.Forms.Padding(2);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.Size = new System.Drawing.Size(92, 20);
			txtmodelo.TabIndex = 1;
			txtmodelo.TextChanged += new System.EventHandler(txtmodelo_TextChanged);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(291, 44);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(45, 13);
			label7.TabIndex = 11;
			label7.Text = "Modelo:";
			label7.Click += new System.EventHandler(label7_Click);
			comboaccesorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboaccesorios.FormattingEnabled = true;
			comboaccesorios.Items.AddRange(new object[5]
			{
				"Ninguno",
				"Base",
				"Cable de corriente",
				"Control de TV",
				"Otros (Especificar en comentarios)"
			});
			comboaccesorios.Location = new System.Drawing.Point(356, 85);
			comboaccesorios.Margin = new System.Windows.Forms.Padding(2);
			comboaccesorios.Name = "comboaccesorios";
			comboaccesorios.Size = new System.Drawing.Size(92, 21);
			comboaccesorios.TabIndex = 3;
			comboaccesorios.SelectedIndexChanged += new System.EventHandler(comboaccesorios_SelectedIndexChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(291, 85);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(62, 13);
			label8.TabIndex = 13;
			label8.Text = "Accesorios:";
			label8.Click += new System.EventHandler(label8_Click);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(291, 117);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(150, 13);
			label9.TabIndex = 14;
			label9.Text = "Fecha de solicitud de servicio:";
			label9.Click += new System.EventHandler(label9_Click);
			PickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			PickerFecha.Location = new System.Drawing.Point(294, 141);
			PickerFecha.Margin = new System.Windows.Forms.Padding(2);
			PickerFecha.Name = "PickerFecha";
			PickerFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
			PickerFecha.Size = new System.Drawing.Size(147, 20);
			PickerFecha.TabIndex = 5;
			PickerFecha.ValueChanged += new System.EventHandler(PickerFecha_ValueChanged);
			txtcomentarios.Location = new System.Drawing.Point(502, 46);
			txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
			txtcomentarios.Multiline = true;
			txtcomentarios.Name = "txtcomentarios";
			txtcomentarios.Size = new System.Drawing.Size(298, 131);
			txtcomentarios.TabIndex = 6;
			txtcomentarios.TextChanged += new System.EventHandler(txtcomentarios_TextChanged);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(499, 31);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(68, 13);
			label10.TabIndex = 19;
			label10.Text = "Comentarios:";
			label10.Click += new System.EventHandler(label10_Click);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(12, 118);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(54, 13);
			label11.TabIndex = 21;
			label11.Text = "Locacion:";
			label11.Click += new System.EventHandler(label11_Click);
			combolacacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combolacacion.FormattingEnabled = true;
			combolacacion.Items.AddRange(new object[4]
			{
				"Taller",
				"Domicilio",
				"Garantia",
				"Otros"
			});
			combolacacion.Location = new System.Drawing.Point(73, 118);
			combolacacion.Margin = new System.Windows.Forms.Padding(2);
			combolacacion.Name = "combolacacion";
			combolacacion.Size = new System.Drawing.Size(178, 21);
			combolacacion.TabIndex = 4;
			combolacacion.SelectedIndexChanged += new System.EventHandler(combolacacion_SelectedIndexChanged);
			txtidoculto.Location = new System.Drawing.Point(290, 11);
			txtidoculto.Margin = new System.Windows.Forms.Padding(2);
			txtidoculto.Name = "txtidoculto";
			txtidoculto.Size = new System.Drawing.Size(76, 20);
			txtidoculto.TabIndex = 23;
			txtidoculto.Visible = false;
			txtidoculto.TextChanged += new System.EventHandler(txtidoculto_TextChanged);
			txtfalla.Location = new System.Drawing.Point(73, 76);
			txtfalla.Name = "txtfalla";
			txtfalla.Size = new System.Drawing.Size(178, 20);
			txtfalla.TabIndex = 2;
			btngenerar.FlatAppearance.BorderSize = 0;
			btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btngenerar.Image = Electronica.Properties.Resources.contract;
			btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btngenerar.Location = new System.Drawing.Point(662, 270);
			btngenerar.Margin = new System.Windows.Forms.Padding(2);
			btngenerar.Name = "btngenerar";
			btngenerar.Size = new System.Drawing.Size(138, 37);
			btngenerar.TabIndex = 7;
			btngenerar.Text = "Generar Orden";
			btngenerar.UseVisualStyleBackColor = true;
			btngenerar.Click += new System.EventHandler(btngenerar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(857, 419);
			base.Controls.Add(txtfalla);
			base.Controls.Add(txtidoculto);
			base.Controls.Add(combolacacion);
			base.Controls.Add(label11);
			base.Controls.Add(btngenerar);
			base.Controls.Add(label10);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(PickerFecha);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(comboaccesorios);
			base.Controls.Add(label7);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(label3);
			base.Controls.Add(combomarca);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "RecepcionTelevisores";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "RecepcionTelevisores";
			base.Load += new System.EventHandler(RecepcionTelevisores_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
