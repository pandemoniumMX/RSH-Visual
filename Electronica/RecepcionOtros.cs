using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class RecepcionOtros : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label1;

		private Label label2;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label11;

		private TextBox txtmodelo;

		private ComboBox combolocacion;

		private DateTimePicker fechapicker;

		private TextBox txtcomentarios;

		private Button gtngenorden;

		public TextBox txtidoculto;

		public TextBox txtequipo;

		private TextBox txtfalla;

		private TextBox txtaccesorios;

		public TextBox txtmarca;

		public RecepcionOtros()
		{
			InitializeComponent();
		}

		private void gtngenorden_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Los datos de la orden son correctos?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtequipo.Text))
			{
				MessageBox.Show("Campo equipo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmarca.Text))
			{
				MessageBox.Show("Campo marca vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtfalla.Text))
			{
				MessageBox.Show("Campo falla vacío");
			}
			if (string.IsNullOrWhiteSpace(combolocacion.Text))
			{
				MessageBox.Show("Campo locacion no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(fechapicker.Text))
			{
				MessageBox.Show("Campo fecha no asignada");
			}
			else
			{
				string equipo = txtequipo.Text;
				string marca = txtmarca.Text;
				string falla = txtfalla.Text;
				string locacion = combolocacion.SelectedItem.ToString();
				string accesorios = txtaccesorios.Text;
				string modelo = txtmodelo.Text;
				string fecha = Convert.ToDateTime(fechapicker.Text).ToString("yyyy-MM-dd");
				string comentarios = txtcomentarios.Text;
				int idfolio = Convert.ToInt32(txtidoculto.Text);
				string query_insertar_cel = "insert into reparar_electrodomesticos (equipo, marca, modelo, accesorios, falla, comentarios,fecha_entregar,fecha_egreso, servicio, estado,ubicacion, id_folio) values ('" + equipo + "', '" + marca + "', '" + modelo + "','" + accesorios + "', '" + falla + "','" + comentarios + "','" + fecha + "', '" + fecha + "',  '" + locacion + "','Pendiente','Recepcion', '" + idfolio + "') ";
				MySqlCommand cmd_query_insertar_cel = new MySqlCommand(query_insertar_cel, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando = cmd_query_insertar_cel.ExecuteReader();
					MessageBox.Show(equipo + " agregado(a) correctamente");
					conn.Close();
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void txtequipo_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtequipo.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		

		private void txtmodelo_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtmodelo.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		

	

	

		



		private void txtmarca_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtmarca.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		private void txtaccesorios_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtaccesorios.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		private void txtfalla_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtfalla.Text))
			{
				MessageBox.Show("Debe completar la informacion");
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
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			txtequipo = new System.Windows.Forms.TextBox();
			txtmodelo = new System.Windows.Forms.TextBox();
			combolocacion = new System.Windows.Forms.ComboBox();
			fechapicker = new System.Windows.Forms.DateTimePicker();
			txtcomentarios = new System.Windows.Forms.TextBox();
			txtidoculto = new System.Windows.Forms.TextBox();
			txtfalla = new System.Windows.Forms.TextBox();
			txtaccesorios = new System.Windows.Forms.TextBox();
			txtmarca = new System.Windows.Forms.TextBox();
			gtngenorden = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(8, 7);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(285, 20);
			label1.TabIndex = 0;
			label1.Text = "Orden de Servicio de Linea Blanca";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(20, 47);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(43, 13);
			label2.TabIndex = 1;
			label2.Text = "Equipo:";
			label2.Click += new System.EventHandler(label2_Click);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(515, 36);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 13);
			label5.TabIndex = 4;
			label5.Text = "Comentarios:";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(19, 78);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(45, 13);
			label6.TabIndex = 5;
			label6.Text = "Modelo:";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(250, 113);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(150, 13);
			label7.TabIndex = 6;
			label7.Text = "Fecha de solicitud de servicio:";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(250, 77);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(62, 13);
			label8.TabIndex = 7;
			label8.Text = "Accesorios:";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(250, 45);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(40, 13);
			label9.TabIndex = 8;
			label9.Text = "Marca:";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(22, 136);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(54, 13);
			label10.TabIndex = 9;
			label10.Text = "Locacion:";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(22, 108);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(32, 13);
			label11.TabIndex = 10;
			label11.Text = "Falla:";
			txtequipo.Location = new System.Drawing.Point(67, 42);
			txtequipo.Margin = new System.Windows.Forms.Padding(2);
			txtequipo.Name = "txtequipo";
			txtequipo.Size = new System.Drawing.Size(102, 20);
			txtequipo.TabIndex = 0;
			txtequipo.TextChanged += new System.EventHandler(txtequipo_TextChanged);
			txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtmodelo.Location = new System.Drawing.Point(67, 75);
			txtmodelo.Margin = new System.Windows.Forms.Padding(2);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.Size = new System.Drawing.Size(102, 20);
			txtmodelo.TabIndex = 2;
			txtmodelo.TextChanged += new System.EventHandler(txtmodelo_TextChanged);
			combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combolocacion.FormattingEnabled = true;
			combolocacion.Items.AddRange(new object[4]
			{
				"Taller",
				"Servicio a domicilio",
				"Re-ingreso por garantia",
				"Otro"
			});
			combolocacion.Location = new System.Drawing.Point(80, 133);
			combolocacion.Margin = new System.Windows.Forms.Padding(2);
			combolocacion.Name = "combolocacion";
			combolocacion.Size = new System.Drawing.Size(90, 21);
			combolocacion.TabIndex = 5;
			fechapicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			fechapicker.Location = new System.Drawing.Point(253, 136);
			fechapicker.Margin = new System.Windows.Forms.Padding(2);
			fechapicker.Name = "fechapicker";
			fechapicker.Size = new System.Drawing.Size(151, 20);
			fechapicker.TabIndex = 6;
			txtcomentarios.Location = new System.Drawing.Point(518, 56);
			txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
			txtcomentarios.Multiline = true;
			txtcomentarios.Name = "txtcomentarios";
			txtcomentarios.Size = new System.Drawing.Size(273, 122);
			txtcomentarios.TabIndex = 7;
			txtidoculto.Location = new System.Drawing.Point(355, 0);
			txtidoculto.Margin = new System.Windows.Forms.Padding(2);
			txtidoculto.Name = "txtidoculto";
			txtidoculto.Size = new System.Drawing.Size(102, 20);
			txtidoculto.TabIndex = 23;
			txtidoculto.Visible = false;
			txtfalla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtfalla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtfalla.Location = new System.Drawing.Point(67, 105);
			txtfalla.Margin = new System.Windows.Forms.Padding(2);
			txtfalla.Name = "txtfalla";
			txtfalla.Size = new System.Drawing.Size(102, 20);
			txtfalla.TabIndex = 4;
			txtfalla.TextChanged += new System.EventHandler(txtfalla_TextChanged);
			txtaccesorios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtaccesorios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtaccesorios.Location = new System.Drawing.Point(316, 74);
			txtaccesorios.Margin = new System.Windows.Forms.Padding(2);
			txtaccesorios.Name = "txtaccesorios";
			txtaccesorios.Size = new System.Drawing.Size(102, 20);
			txtaccesorios.TabIndex = 3;
			txtaccesorios.TextChanged += new System.EventHandler(txtaccesorios_TextChanged);
			txtmarca.Location = new System.Drawing.Point(294, 40);
			txtmarca.Margin = new System.Windows.Forms.Padding(2);
			txtmarca.Name = "txtmarca";
			txtmarca.Size = new System.Drawing.Size(102, 20);
			txtmarca.TabIndex = 1;
			txtmarca.TextChanged += new System.EventHandler(txtmarca_TextChanged);
			gtngenorden.FlatAppearance.BorderSize = 0;
			gtngenorden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			gtngenorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			gtngenorden.Image = Electronica.Properties.Resources.contract;
			gtngenorden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			gtngenorden.Location = new System.Drawing.Point(659, 271);
			gtngenorden.Margin = new System.Windows.Forms.Padding(2);
			gtngenorden.Name = "gtngenorden";
			gtngenorden.Size = new System.Drawing.Size(132, 37);
			gtngenorden.TabIndex = 8;
			gtngenorden.Text = "Generar Orden";
			gtngenorden.UseVisualStyleBackColor = true;
			gtngenorden.Click += new System.EventHandler(gtngenorden_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(857, 419);
			base.Controls.Add(txtfalla);
			base.Controls.Add(txtaccesorios);
			base.Controls.Add(txtmarca);
			base.Controls.Add(txtidoculto);
			base.Controls.Add(gtngenorden);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(fechapicker);
			base.Controls.Add(combolocacion);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(txtequipo);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "RecepcionElectrodomesticos";
			Text = "RecepcionTablets_Cel";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
