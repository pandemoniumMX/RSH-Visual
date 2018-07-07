using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class RecepcionHistorial_vista2 : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label10;

		public TextBox txtequipo;

		public TextBox txtfalla;

		public TextBox txtmarca;

		public TextBox txtaccesorios;

		public TextBox txtcomentarios;

		public TextBox txtrefaccion;

		public ComboBox combolocacion;

		public TextBox txtfolio;

		public TextBox txtmodelo;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label11;

		public TextBox txtmano;

		private Label label15;

		private Label label16;

		public ComboBox combotecnico;

		private Label label17;

		private Label label18;

		public TextBox txttotal;

		public TextBox txtabono;

		private Label label19;

		public TextBox txttipo;

		private Button button1;

		public TextBox txtfechaen;

		public TextBox txtfechain;

		public TextBox txtestado;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		public TextBox txtidequipo;

		public TextBox txtpersonal;

		private Button button2;

		public TextBox txtpuntos;

		private Label label1;

		private Button button3;

		private PictureBox pictureBox1;

		private Label label21;

		private Label label20;

		public TextBox txtcorreo;

		public TextBox txtcelular;

		public TextBox txtapellidos;

		public TextBox txtnombre;

		private Label label22;

		private Label label24;

		private Label label23;

		private Button button4;

		public TextBox txtegreso;

		private Label label25;

		public RecepcionHistorial_vista2()
		{
			InitializeComponent();
		}

		private void btngenorden_Click(object sender, EventArgs e)
		{
			string marca = txtmarca.Text;
			string falla = txtfalla.Text;
			string accesorios = txtaccesorios.Text;
			string equipo = txtequipo.Text;
			string estado = txtestado.Text;
			string modelo = txtmodelo.Text;
			string fecha = txtfechain.Text;
			string fechaeg = txtfechaen.Text;
			string comentarios = txtcomentarios.Text;
			int idfolio = Convert.ToInt32(txtfolio.Text);
			string tabla = txttipo.Text;
			string query_actualizar_orden = "update  " + tabla + " set equipo='" + equipo + "', marca='" + marca + "', modelo='" + modelo + "', accesorios= '" + accesorios + "', falla=  '" + falla + "', comentarios= '" + comentarios + "' where id_folio='" + idfolio + "'";
			MySqlCommand cmd_query_actualizar_orden = new MySqlCommand(query_actualizar_orden, conn);
			try
			{
				conn.Open();
				MySqlDataReader leercomando = cmd_query_actualizar_orden.ExecuteReader();
				MessageBox.Show("Orden de servicio actualizada exitosamente");
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void comboestado_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int presupuesto = Convert.ToInt32(txtrefaccion.Text);
			int mano = Convert.ToInt32(txtmano.Text);
			int abono = Convert.ToInt32(txtabono.Text);
			int total = Convert.ToInt32(txttotal.Text);
			string tabla = txttipo.Text;
			string query_costos = "update " + tabla + "  set presupuesto='" + presupuesto + "', mano_obra='" + mano + "', abono='" + abono + "', costo_total='" + total + "'";
			MySqlCommand cmd_query_costos = new MySqlCommand(query_costos, conn);
			try
			{
				conn.Open();
				MySqlDataReader leercomando = cmd_query_costos.ExecuteReader();
				MessageBox.Show("Costos agregados satisfactoriamente");
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void Taller_actualizar_Load(object sender, EventArgs e)
		{
		}

		private void txttotal_TextChanged(object sender, EventArgs e)
		{
		}

		private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtrefaccion.Text) && !string.IsNullOrEmpty(txtmano.Text) && !string.IsNullOrEmpty(txtabono.Text))
			{
				txttotal.Text = (Convert.ToInt32(txtrefaccion.Text) + Convert.ToInt32(txtmano.Text) - Convert.ToInt32(txtabono.Text)).ToString();
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			int idpersonal = Convert.ToInt32(txtpersonal.Text);
			int idequipo = Convert.ToInt32(txtidequipo.Text);
			string reporte = "select * from reportes_tecnicos where id_equipo ='" + idequipo + "' and id_personal='" + idpersonal + "'";
			conn.Open();
			MySqlCommand cmd_reporte = new MySqlCommand(reporte, conn);
			MySqlDataReader sr = cmd_reporte.ExecuteReader();
			if (sr.Read())
			{
				Tecnicos_reporte2 tr = new Tecnicos_reporte2();
				tr.txtidequipo.Text = sr["id_equipo"].ToString();
				tr.txtconclusion.Text = sr["conclusion"].ToString();
				tr.txtfalla.Text = sr["falla_especifica"].ToString();
				tr.txtsolucion.Text = sr["solucion_especifica"].ToString();
				tr.ShowDialog();
			}
			conn.Close();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Son correctos los costos de la orden número ?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(txtabono.Text))
				{
					MessageBox.Show("Campo abono vacio");
				}
				else
				{
					int presupuesto = Convert.ToInt32(txtrefaccion.Text);
					int mano = Convert.ToInt32(txtmano.Text);
					int abono = Convert.ToInt32(txtabono.Text);
					int total2 = Convert.ToInt32(txttotal.Text);
					int folio = Convert.ToInt32(txtfolio.Text);
					int equipo = Convert.ToInt32(txtidequipo.Text);
					string tabla = txttipo.Text;
					int total = int.Parse(txttotal.Text);
					string query_costos = "update " + tabla + "  set abono='" + abono + "', costo_total='" + total2 + "' where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
					MySqlCommand cmd_query_costos = new MySqlCommand(query_costos, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_query_costos.ExecuteReader();
						MessageBox.Show("Costos agregados satisfactoriamente");
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

		private void panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro(a) de aplicar el descuento? Esta acción es irreversible", "Alerta de descuento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				string folio = txtfolio.Text;
				string total = txttotal.Text;
				string descuento8 = "UPDATE reparar_tv SET puntos = '0', costo_total='" + total + "' WHERE id_folio ='" + folio + "' and estado='Reparado'";
				MySqlCommand cmd_descuento8 = new MySqlCommand(descuento8, conn);
				string descuento7 = "UPDATE reparar_laptops SET puntos = '0' , costo_total='" + total + "' WHERE id_folio ='" + folio + "' and estado='reparado'";
				MySqlCommand cmd_descuento7 = new MySqlCommand(descuento7, conn);
				string descuento6 = "UPDATE reparar_smartphones SET puntos = '0' , costo_total='" + total + "' WHERE id_folio ='" + folio + "' and estado='reparado'";
				MySqlCommand cmd_descuento6 = new MySqlCommand(descuento6, conn);
				string descuento5 = "UPDATE reparar_audio SET puntos = '0' , costo_total='" + total + "' WHERE id_folio ='" + folio + "' and estado='reparado'";
				MySqlCommand cmd_descuento5 = new MySqlCommand(descuento5, conn);
				string descuento4 = "UPDATE reparar_electrodomesticos SET puntos = '0' , costo_total='" + total + "' WHERE id_equipo ='" + folio + "' and estado='reparado'";
				MySqlCommand cmd_descuento4 = new MySqlCommand(descuento4, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando8 = cmd_descuento8.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando7 = cmd_descuento7.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando6 = cmd_descuento6.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando5 = cmd_descuento5.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando4 = cmd_descuento4.ExecuteReader();
					MessageBox.Show("Descuento aplicado satisfcatoriamente");
					conn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Ya se le hizo entrega al cliente de su equipo? Esta acción es irreversible", "Alerta de entrega", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				string folio = txtidequipo.Text;
				string personal = txtpersonal.Text;
				string descuento8 = "UPDATE reparar_tv SET estado = 'Entregado', ubicacion='Cliente' , fecha_egreso=CURRENT_TIMESTAMP WHERE id_equipo ='" + folio + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento8 = new MySqlCommand(descuento8, conn);
				string descuento7 = "UPDATE reparar_laptops SET estado = 'Entregado', ubicacion='Cliente' WHERE id_equipo ='" + folio + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento7 = new MySqlCommand(descuento7, conn);
				string descuento6 = "UPDATE reparar_smartphones SET estado = 'Entregado', ubicacion='Cliente' WHERE id_equipo ='" + folio + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento6 = new MySqlCommand(descuento6, conn);
				string descuento5 = "UPDATE reparar_audio SET estado = 'Entregado', ubicacion='Cliente' WHERE id_equipo ='" + folio + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento5 = new MySqlCommand(descuento5, conn);
				string descuento4 = "UPDATE reparar_electrodomesticos SET estado = 'Entregado', ubicacion='Cliente' WHERE id_equipo ='" + folio + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento4 = new MySqlCommand(descuento4, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando8 = cmd_descuento8.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando7 = cmd_descuento7.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando6 = cmd_descuento6.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando5 = cmd_descuento5.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando4 = cmd_descuento4.ExecuteReader();
					MessageBox.Show("Entrega aplicada correctamente");
					conn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void txtabono_KeyPress(object sender, KeyPressEventArgs v)
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
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			txtequipo = new System.Windows.Forms.TextBox();
			txtfalla = new System.Windows.Forms.TextBox();
			txtmarca = new System.Windows.Forms.TextBox();
			txtaccesorios = new System.Windows.Forms.TextBox();
			txtcomentarios = new System.Windows.Forms.TextBox();
			txtrefaccion = new System.Windows.Forms.TextBox();
			combolocacion = new System.Windows.Forms.ComboBox();
			txtfolio = new System.Windows.Forms.TextBox();
			txtmodelo = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			txtmano = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			combotecnico = new System.Windows.Forms.ComboBox();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			txttotal = new System.Windows.Forms.TextBox();
			txtabono = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			txttipo = new System.Windows.Forms.TextBox();
			txtfechaen = new System.Windows.Forms.TextBox();
			txtfechain = new System.Windows.Forms.TextBox();
			txtestado = new System.Windows.Forms.TextBox();
			panel1 = new System.Windows.Forms.Panel();
			txtidequipo = new System.Windows.Forms.TextBox();
			txtpersonal = new System.Windows.Forms.TextBox();
			panel2 = new System.Windows.Forms.Panel();
			txtegreso = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label21 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			txtcorreo = new System.Windows.Forms.TextBox();
			txtcelular = new System.Windows.Forms.TextBox();
			txtapellidos = new System.Windows.Forms.TextBox();
			txtnombre = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			txtpuntos = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel3.SuspendLayout();
			SuspendLayout();
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label2.Location = new System.Drawing.Point(17, 68);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(43, 13);
			label2.TabIndex = 1;
			label2.Text = "Equipo:";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label3.Location = new System.Drawing.Point(455, 38);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(68, 13);
			label3.TabIndex = 2;
			label3.Text = "Comentarios:";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label4.Location = new System.Drawing.Point(21, 162);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(150, 13);
			label4.TabIndex = 3;
			label4.Text = "Fecha de solicitud de servicio:";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label5.Location = new System.Drawing.Point(240, 126);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(62, 13);
			label5.TabIndex = 4;
			label5.Text = "Accesorios:";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label6.Location = new System.Drawing.Point(19, 469);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(89, 13);
			label6.TabIndex = 5;
			label6.Text = "Costo Refaccion:";
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(20, 431);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(190, 20);
			label7.TabIndex = 6;
			label7.Text = "Presupuesto acordado";
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label8.Location = new System.Drawing.Point(17, 118);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(54, 13);
			label8.TabIndex = 7;
			label8.Text = "Locacion:";
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label9.Location = new System.Drawing.Point(17, 93);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 13);
			label9.TabIndex = 8;
			label9.Text = "Falla:";
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label10.Location = new System.Drawing.Point(238, 68);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(40, 13);
			label10.TabIndex = 9;
			label10.Text = "Marca:";
			txtequipo.BackColor = System.Drawing.SystemColors.Window;
			txtequipo.Location = new System.Drawing.Point(64, 65);
			txtequipo.Margin = new System.Windows.Forms.Padding(2);
			txtequipo.Name = "txtequipo";
			txtequipo.ReadOnly = true;
			txtequipo.Size = new System.Drawing.Size(157, 20);
			txtequipo.TabIndex = 10;
			txtfalla.BackColor = System.Drawing.SystemColors.Window;
			txtfalla.Location = new System.Drawing.Point(64, 93);
			txtfalla.Margin = new System.Windows.Forms.Padding(2);
			txtfalla.Name = "txtfalla";
			txtfalla.ReadOnly = true;
			txtfalla.Size = new System.Drawing.Size(157, 20);
			txtfalla.TabIndex = 11;
			txtmarca.BackColor = System.Drawing.SystemColors.Window;
			txtmarca.Location = new System.Drawing.Point(307, 65);
			txtmarca.Margin = new System.Windows.Forms.Padding(2);
			txtmarca.Name = "txtmarca";
			txtmarca.ReadOnly = true;
			txtmarca.Size = new System.Drawing.Size(123, 20);
			txtmarca.TabIndex = 12;
			txtaccesorios.BackColor = System.Drawing.SystemColors.Window;
			txtaccesorios.Location = new System.Drawing.Point(307, 126);
			txtaccesorios.Margin = new System.Windows.Forms.Padding(2);
			txtaccesorios.Name = "txtaccesorios";
			txtaccesorios.ReadOnly = true;
			txtaccesorios.Size = new System.Drawing.Size(120, 20);
			txtaccesorios.TabIndex = 13;
			txtcomentarios.BackColor = System.Drawing.SystemColors.Window;
			txtcomentarios.Location = new System.Drawing.Point(458, 65);
			txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
			txtcomentarios.Multiline = true;
			txtcomentarios.Name = "txtcomentarios";
			txtcomentarios.ReadOnly = true;
			txtcomentarios.Size = new System.Drawing.Size(467, 96);
			txtcomentarios.TabIndex = 14;
			txtrefaccion.BackColor = System.Drawing.SystemColors.Window;
			txtrefaccion.Location = new System.Drawing.Point(112, 466);
			txtrefaccion.Margin = new System.Windows.Forms.Padding(2);
			txtrefaccion.Name = "txtrefaccion";
			txtrefaccion.ReadOnly = true;
			txtrefaccion.Size = new System.Drawing.Size(76, 20);
			txtrefaccion.TabIndex = 17;
			combolocacion.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combolocacion.FormattingEnabled = true;
			combolocacion.Items.AddRange(new object[4]
			{
				"Taller",
				"Domicilio",
				"Garantia",
				"Otros"
			});
			combolocacion.Location = new System.Drawing.Point(70, 118);
			combolocacion.Margin = new System.Windows.Forms.Padding(2);
			combolocacion.Name = "combolocacion";
			combolocacion.Size = new System.Drawing.Size(92, 21);
			combolocacion.TabIndex = 19;
			txtfolio.Location = new System.Drawing.Point(889, 27);
			txtfolio.Margin = new System.Windows.Forms.Padding(2);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(76, 20);
			txtfolio.TabIndex = 20;
			txtmodelo.BackColor = System.Drawing.SystemColors.Window;
			txtmodelo.Location = new System.Drawing.Point(307, 96);
			txtmodelo.Margin = new System.Windows.Forms.Padding(2);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.ReadOnly = true;
			txtmodelo.Size = new System.Drawing.Size(123, 20);
			txtmodelo.TabIndex = 22;
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label12.Location = new System.Drawing.Point(240, 99);
			label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(45, 13);
			label12.TabIndex = 23;
			label12.Text = "Modelo:";
			label13.AutoSize = true;
			label13.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label13.Location = new System.Drawing.Point(241, 162);
			label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(108, 13);
			label13.TabIndex = 24;
			label13.Text = "Fecha de reparación:";
			label14.AutoSize = true;
			label14.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label14.Location = new System.Drawing.Point(24, 290);
			label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(75, 13);
			label14.TabIndex = 26;
			label14.Text = "Estado actual:";
			label11.AutoSize = true;
			label11.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label11.Location = new System.Drawing.Point(236, 469);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(78, 13);
			label11.TabIndex = 29;
			label11.Text = "Mano de Obra:";
			txtmano.BackColor = System.Drawing.SystemColors.Window;
			txtmano.Location = new System.Drawing.Point(318, 466);
			txtmano.Margin = new System.Windows.Forms.Padding(2);
			txtmano.Name = "txtmano";
			txtmano.ReadOnly = true;
			txtmano.Size = new System.Drawing.Size(76, 20);
			txtmano.TabIndex = 30;
			label15.AutoSize = true;
			label15.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(16, 31);
			label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(161, 20);
			label15.TabIndex = 31;
			label15.Text = " Orden de Servicio:";
			label16.AutoSize = true;
			label16.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(20, 241);
			label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(200, 20);
			label16.TabIndex = 33;
			label16.Text = "Estado de la reparación";
			combotecnico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			combotecnico.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			combotecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combotecnico.FormattingEnabled = true;
			combotecnico.Location = new System.Drawing.Point(281, 171);
			combotecnico.Margin = new System.Windows.Forms.Padding(2);
			combotecnico.Name = "combotecnico";
			combotecnico.Size = new System.Drawing.Size(126, 21);
			combotecnico.TabIndex = 35;
			combotecnico.Visible = false;
			combotecnico.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			label17.AutoSize = true;
			label17.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label17.Location = new System.Drawing.Point(190, 174);
			label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(87, 13);
			label17.TabIndex = 34;
			label17.Text = "Técnico número:";
			label17.Visible = false;
			label18.AutoSize = true;
			label18.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label18.Location = new System.Drawing.Point(278, 122);
			label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(34, 13);
			label18.TabIndex = 37;
			label18.Text = "Total:";
			txttotal.BackColor = System.Drawing.SystemColors.Window;
			txttotal.Location = new System.Drawing.Point(318, 119);
			txttotal.Margin = new System.Windows.Forms.Padding(2);
			txttotal.Name = "txttotal";
			txttotal.ReadOnly = true;
			txttotal.Size = new System.Drawing.Size(76, 20);
			txttotal.TabIndex = 38;
			txttotal.TextChanged += new System.EventHandler(txttotal_TextChanged);
			txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txttotal_KeyPress);
			txtabono.BackColor = System.Drawing.SystemColors.Window;
			txtabono.Location = new System.Drawing.Point(505, 53);
			txtabono.Margin = new System.Windows.Forms.Padding(2);
			txtabono.Name = "txtabono";
			txtabono.Size = new System.Drawing.Size(76, 20);
			txtabono.TabIndex = 40;
			txtabono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtabono_KeyPress);
			label19.AutoSize = true;
			label19.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label19.Location = new System.Drawing.Point(454, 56);
			label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(41, 13);
			label19.TabIndex = 39;
			label19.Text = "Abono:";
			txttipo.Location = new System.Drawing.Point(775, 11);
			txttipo.Margin = new System.Windows.Forms.Padding(2);
			txttipo.Name = "txttipo";
			txttipo.Size = new System.Drawing.Size(150, 20);
			txttipo.TabIndex = 41;
			txttipo.Visible = false;
			txtfechaen.BackColor = System.Drawing.SystemColors.Window;
			txtfechaen.Location = new System.Drawing.Point(244, 191);
			txtfechaen.Margin = new System.Windows.Forms.Padding(2);
			txtfechaen.Name = "txtfechaen";
			txtfechaen.ReadOnly = true;
			txtfechaen.Size = new System.Drawing.Size(101, 20);
			txtfechaen.TabIndex = 44;
			txtfechain.BackColor = System.Drawing.SystemColors.Window;
			txtfechain.Location = new System.Drawing.Point(24, 191);
			txtfechain.Margin = new System.Windows.Forms.Padding(2);
			txtfechain.Name = "txtfechain";
			txtfechain.ReadOnly = true;
			txtfechain.Size = new System.Drawing.Size(120, 20);
			txtfechain.TabIndex = 43;
			txtestado.BackColor = System.Drawing.SystemColors.Window;
			txtestado.Location = new System.Drawing.Point(103, 287);
			txtestado.Margin = new System.Windows.Forms.Padding(2);
			txtestado.Name = "txtestado";
			txtestado.ReadOnly = true;
			txtestado.Size = new System.Drawing.Size(101, 20);
			txtestado.TabIndex = 45;
			panel1.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			panel1.Controls.Add(txtidequipo);
			panel1.Controls.Add(txtpersonal);
			panel1.Location = new System.Drawing.Point(0, -7);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1106, 235);
			panel1.TabIndex = 46;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			txtidequipo.BackColor = System.Drawing.Color.White;
			txtidequipo.Location = new System.Drawing.Point(184, 38);
			txtidequipo.Margin = new System.Windows.Forms.Padding(2);
			txtidequipo.Name = "txtidequipo";
			txtidequipo.Size = new System.Drawing.Size(101, 20);
			txtidequipo.TabIndex = 54;
			txtpersonal.BackColor = System.Drawing.Color.FromArgb(51, 133, 198);
			txtpersonal.Location = new System.Drawing.Point(532, 28);
			txtpersonal.Margin = new System.Windows.Forms.Padding(2);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(49, 20);
			txtpersonal.TabIndex = 48;
			txtpersonal.Visible = false;
			panel2.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			panel2.Controls.Add(txtegreso);
			panel2.Controls.Add(label25);
			panel2.Controls.Add(pictureBox1);
			panel2.Controls.Add(label21);
			panel2.Controls.Add(label20);
			panel2.Controls.Add(txtcorreo);
			panel2.Controls.Add(combotecnico);
			panel2.Controls.Add(txtcelular);
			panel2.Controls.Add(txtapellidos);
			panel2.Controls.Add(label17);
			panel2.Controls.Add(txtnombre);
			panel2.Controls.Add(txtfolio);
			panel2.Controls.Add(label22);
			panel2.Controls.Add(label24);
			panel2.Controls.Add(label23);
			panel2.Location = new System.Drawing.Point(0, 216);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1106, 201);
			panel2.TabIndex = 47;
			panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			txtegreso.BackColor = System.Drawing.SystemColors.Window;
			txtegreso.Location = new System.Drawing.Point(374, 71);
			txtegreso.Margin = new System.Windows.Forms.Padding(2);
			txtegreso.Name = "txtegreso";
			txtegreso.ReadOnly = true;
			txtegreso.Size = new System.Drawing.Size(101, 20);
			txtegreso.TabIndex = 50;
			label25.AutoSize = true;
			label25.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label25.Location = new System.Drawing.Point(276, 74);
			label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(94, 13);
			label25.TabIndex = 49;
			label25.Text = "Fecha de entrega:";
			pictureBox1.Image = Electronica.Properties.Resources.call_answer;
			pictureBox1.Location = new System.Drawing.Point(668, 18);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(38, 34);
			pictureBox1.TabIndex = 57;
			pictureBox1.TabStop = false;
			label21.AutoSize = true;
			label21.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label21.Location = new System.Drawing.Point(862, 120);
			label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(41, 13);
			label21.TabIndex = 56;
			label21.Text = "Correo:";
			label20.AutoSize = true;
			label20.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(711, 25);
			label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(174, 20);
			label20.TabIndex = 49;
			label20.Text = "Contacto del cliente:";
			txtcorreo.BackColor = System.Drawing.SystemColors.Window;
			txtcorreo.Location = new System.Drawing.Point(907, 117);
			txtcorreo.Margin = new System.Windows.Forms.Padding(2);
			txtcorreo.Name = "txtcorreo";
			txtcorreo.ReadOnly = true;
			txtcorreo.Size = new System.Drawing.Size(158, 20);
			txtcorreo.TabIndex = 55;
			txtcelular.BackColor = System.Drawing.SystemColors.Window;
			txtcelular.Location = new System.Drawing.Point(908, 86);
			txtcelular.Margin = new System.Windows.Forms.Padding(2);
			txtcelular.Name = "txtcelular";
			txtcelular.ReadOnly = true;
			txtcelular.Size = new System.Drawing.Size(145, 20);
			txtcelular.TabIndex = 54;
			txtapellidos.BackColor = System.Drawing.SystemColors.Window;
			txtapellidos.Location = new System.Drawing.Point(687, 114);
			txtapellidos.Margin = new System.Windows.Forms.Padding(2);
			txtapellidos.Name = "txtapellidos";
			txtapellidos.ReadOnly = true;
			txtapellidos.Size = new System.Drawing.Size(157, 20);
			txtapellidos.TabIndex = 53;
			txtnombre.BackColor = System.Drawing.SystemColors.Window;
			txtnombre.Location = new System.Drawing.Point(687, 86);
			txtnombre.Margin = new System.Windows.Forms.Padding(2);
			txtnombre.Name = "txtnombre";
			txtnombre.ReadOnly = true;
			txtnombre.Size = new System.Drawing.Size(157, 20);
			txtnombre.TabIndex = 52;
			label22.AutoSize = true;
			label22.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label22.Location = new System.Drawing.Point(631, 117);
			label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(52, 13);
			label22.TabIndex = 51;
			label22.Text = "Apellidos:";
			label24.AutoSize = true;
			label24.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label24.Location = new System.Drawing.Point(625, 89);
			label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(58, 13);
			label24.TabIndex = 49;
			label24.Text = "Nombre(s):";
			label23.AutoSize = true;
			label23.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			label23.Location = new System.Drawing.Point(862, 89);
			label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(42, 13);
			label23.TabIndex = 50;
			label23.Text = "Celular:";
			panel3.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			panel3.Controls.Add(button4);
			panel3.Controls.Add(txtpuntos);
			panel3.Controls.Add(button3);
			panel3.Controls.Add(button2);
			panel3.Controls.Add(label1);
			panel3.Controls.Add(txttotal);
			panel3.Controls.Add(label18);
			panel3.Controls.Add(label19);
			panel3.Controls.Add(txtabono);
			panel3.Location = new System.Drawing.Point(0, 413);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(1106, 295);
			panel3.TabIndex = 48;
			panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
			button4.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Image = Electronica.Properties.Resources.shipped;
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(879, 186);
			button4.Margin = new System.Windows.Forms.Padding(2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(161, 35);
			button4.TabIndex = 45;
			button4.Text = "    Confirmar entrega del equipo";
			button4.UseVisualStyleBackColor = false;
			button4.Visible = false;
			button4.Click += new System.EventHandler(button4_Click);
			txtpuntos.BackColor = System.Drawing.SystemColors.Window;
			txtpuntos.Location = new System.Drawing.Point(112, 119);
			txtpuntos.Margin = new System.Windows.Forms.Padding(2);
			txtpuntos.Name = "txtpuntos";
			txtpuntos.ReadOnly = true;
			txtpuntos.Size = new System.Drawing.Size(76, 20);
			txtpuntos.TabIndex = 42;
			txtpuntos.Text = "0";
			button3.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Image = Electronica.Properties.Resources.tick_inside_circle;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(879, 111);
			button3.Margin = new System.Windows.Forms.Padding(2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(161, 35);
			button3.TabIndex = 44;
			button3.Text = "    Confirmar descuento";
			button3.UseVisualStyleBackColor = false;
			button3.Visible = false;
			button3.Click += new System.EventHandler(button3_Click);
			button2.BackColor = System.Drawing.Color.White;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Image = Electronica.Properties.Resources.discount;
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(683, 111);
			button2.Margin = new System.Windows.Forms.Padding(2);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(161, 35);
			button2.TabIndex = 43;
			button2.Text = "       Confirmar abono";
			button2.UseVisualStyleBackColor = false;
			button2.Visible = false;
			button2.Click += new System.EventHandler(button2_Click_1);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label1.Location = new System.Drawing.Point(65, 122);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(43, 13);
			label1.TabIndex = 41;
			label1.Text = "Puntos:";
			button1.BackColor = System.Drawing.SystemColors.Control;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources._001_binoculars;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(27, 346);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(137, 35);
			button1.TabIndex = 42;
			button1.Text = "Ver Reporte";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(txttipo);
			base.Controls.Add(txtestado);
			base.Controls.Add(txtfechaen);
			base.Controls.Add(txtfechain);
			base.Controls.Add(button1);
			base.Controls.Add(label16);
			base.Controls.Add(label15);
			base.Controls.Add(txtmano);
			base.Controls.Add(label11);
			base.Controls.Add(label14);
			base.Controls.Add(label13);
			base.Controls.Add(label12);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(combolocacion);
			base.Controls.Add(txtrefaccion);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(txtaccesorios);
			base.Controls.Add(txtmarca);
			base.Controls.Add(txtfalla);
			base.Controls.Add(txtequipo);
			base.Controls.Add(label10);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(panel1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel3);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "RecepcionHistorial_vista2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Ordenes de Servicio";
			base.Load += new System.EventHandler(Taller_actualizar_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
