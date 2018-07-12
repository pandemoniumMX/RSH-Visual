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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combomarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboaccesorios = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PickerFecha = new System.Windows.Forms.DateTimePicker();
            this.txtcomentarios = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.combolacacion = new System.Windows.Forms.ComboBox();
            this.txtidoculto = new System.Windows.Forms.TextBox();
            this.txtfalla = new System.Windows.Forms.TextBox();
            this.btngenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de Servicio Televisiones";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // combomarca
            // 
            this.combomarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combomarca.FormattingEnabled = true;
            this.combomarca.Items.AddRange(new object[] {
            "AOC",
            "Aiwa",
            "Atvio",
            "Blu Sens",
            "Blue Point",
            "Cobia",
            "DWDisplay",
            "Haier",
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
            "Otros"});
            this.combomarca.Location = new System.Drawing.Point(73, 41);
            this.combomarca.Margin = new System.Windows.Forms.Padding(2);
            this.combomarca.Name = "combomarca";
            this.combomarca.Size = new System.Drawing.Size(178, 21);
            this.combomarca.TabIndex = 0;
            this.combomarca.SelectedIndexChanged += new System.EventHandler(this.combomarca_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Falla:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtmodelo
            // 
            this.txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtmodelo.Location = new System.Drawing.Point(356, 41);
            this.txtmodelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.Size = new System.Drawing.Size(92, 20);
            this.txtmodelo.TabIndex = 1;
            this.txtmodelo.TextChanged += new System.EventHandler(this.txtmodelo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Modelo:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // comboaccesorios
            // 
            this.comboaccesorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboaccesorios.FormattingEnabled = true;
            this.comboaccesorios.Items.AddRange(new object[] {
            "Ninguno",
            "Base",
            "Cable de corriente",
            "Control de TV",
            "Patas",
            "Otros (Especificar en comentarios)"});
            this.comboaccesorios.Location = new System.Drawing.Point(356, 85);
            this.comboaccesorios.Margin = new System.Windows.Forms.Padding(2);
            this.comboaccesorios.Name = "comboaccesorios";
            this.comboaccesorios.Size = new System.Drawing.Size(92, 21);
            this.comboaccesorios.TabIndex = 3;
            this.comboaccesorios.SelectedIndexChanged += new System.EventHandler(this.comboaccesorios_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Accesorios:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 117);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Fecha de solicitud de servicio:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // PickerFecha
            // 
            this.PickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PickerFecha.Location = new System.Drawing.Point(294, 141);
            this.PickerFecha.Margin = new System.Windows.Forms.Padding(2);
            this.PickerFecha.Name = "PickerFecha";
            this.PickerFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PickerFecha.Size = new System.Drawing.Size(147, 20);
            this.PickerFecha.TabIndex = 5;
            this.PickerFecha.ValueChanged += new System.EventHandler(this.PickerFecha_ValueChanged);
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.Location = new System.Drawing.Point(502, 46);
            this.txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomentarios.Multiline = true;
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.Size = new System.Drawing.Size(298, 131);
            this.txtcomentarios.TabIndex = 6;
            this.txtcomentarios.TextChanged += new System.EventHandler(this.txtcomentarios_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Comentarios:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 118);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Locacion:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // combolacacion
            // 
            this.combolacacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combolacacion.FormattingEnabled = true;
            this.combolacacion.Items.AddRange(new object[] {
            "Taller",
            "Domicilio",
            "Garantia",
            "Otros"});
            this.combolacacion.Location = new System.Drawing.Point(73, 118);
            this.combolacacion.Margin = new System.Windows.Forms.Padding(2);
            this.combolacacion.Name = "combolacacion";
            this.combolacacion.Size = new System.Drawing.Size(178, 21);
            this.combolacacion.TabIndex = 4;
            this.combolacacion.SelectedIndexChanged += new System.EventHandler(this.combolacacion_SelectedIndexChanged);
            // 
            // txtidoculto
            // 
            this.txtidoculto.Location = new System.Drawing.Point(290, 11);
            this.txtidoculto.Margin = new System.Windows.Forms.Padding(2);
            this.txtidoculto.Name = "txtidoculto";
            this.txtidoculto.Size = new System.Drawing.Size(76, 20);
            this.txtidoculto.TabIndex = 23;
            this.txtidoculto.Visible = false;
            this.txtidoculto.TextChanged += new System.EventHandler(this.txtidoculto_TextChanged);
            // 
            // txtfalla
            // 
            this.txtfalla.Location = new System.Drawing.Point(73, 76);
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.Size = new System.Drawing.Size(178, 20);
            this.txtfalla.TabIndex = 2;
            // 
            // btngenerar
            // 
            this.btngenerar.FlatAppearance.BorderSize = 0;
            this.btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerar.Image = global::Electronica.Properties.Resources.contract;
            this.btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerar.Location = new System.Drawing.Point(662, 270);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(138, 37);
            this.btngenerar.TabIndex = 7;
            this.btngenerar.Text = "Generar Orden";
            this.btngenerar.UseVisualStyleBackColor = true;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // RecepcionTelevisores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(857, 419);
            this.Controls.Add(this.txtfalla);
            this.Controls.Add(this.txtidoculto);
            this.Controls.Add(this.combolacacion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtcomentarios);
            this.Controls.Add(this.PickerFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboaccesorios);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combomarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RecepcionTelevisores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RecepcionTelevisores";
            this.Load += new System.EventHandler(this.RecepcionTelevisores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
