using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller_actualizar2 : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label1;

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

		private Button btngenerar;

		public TextBox txtmodelo;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label11;

		public TextBox txtmano;

		private Label label15;

		private Button btnasignar;

		private Label label16;

		public ComboBox combotecnico;

		private Label label17;

		private Button btncostos;

		private Label label18;

		public TextBox txttotal;

		public TextBox txtabono;

		private Label label19;

		public TextBox txttipo;

		private Button button1;

		public TextBox txtfechaen;

		public TextBox txtfechain;

		public TextBox txt_puntos;

		private Label label20;

		private Label label21;

		private Panel panel3;

		private Panel panel1;

		public TextBox txtidequipo;

		public TextBox txtpersonal1;

		public ComboBox txtestado;

		public Taller_actualizar2()
		{
			InitializeComponent();
			try
			{
				string query = "select * from personal where tipo='tecnico'";
				conn.Open();
				MySqlCommand tecnico = new MySqlCommand(query, conn);
				MySqlDataReader tec = tecnico.ExecuteReader();
				while (tec.Read())
				{
					combotecnico.Items.Add(tec.GetString("id_personal"));
				}
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btngenorden_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtequipo.Text))
			{
				MessageBox.Show("Campo equipo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtfalla.Text))
			{
				MessageBox.Show("Campo falla vacío");
			}
			if (string.IsNullOrWhiteSpace(combolocacion.Text))
			{
				MessageBox.Show("Campo locación no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtmarca.Text))
			{
				MessageBox.Show("Campo marca vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtaccesorios.Text))
			{
				MessageBox.Show("Campo accesorio vacío");
			}
			else
			{
				string marca = txtmarca.Text;
				string falla = txtfalla.Text;
				string accesorios = txtaccesorios.Text;
				string equipo = txtequipo.Text;
				string estado = txtestado.SelectedItem.ToString();
				string modelo = txtmodelo.Text;
				string fecha = txtfechain.Text;
				string fechaeg = txtfechaen.Text;
				string comentarios = txtcomentarios.Text;
				int idfolio = Convert.ToInt32(txtfolio.Text);
				string tabla = txttipo.Text;
				string query_actualizar_orden = "update  " + tabla + " set equipo='" + equipo + "', marca='" + marca + "', modelo='" + modelo + "', accesorios= '" + accesorios + "', falla=  '" + falla + "', comentarios= '" + comentarios + "' where id_folio='" + idfolio + "'";
				MySqlCommand cmd_query_actualizar_orden = new MySqlCommand(query_actualizar_orden, conn);
				DialogResult dr = MessageBox.Show("¿Los datos de la orden son correctos?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
				if (dr == DialogResult.Yes)
				{
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
			}
		}

		private void comboestado_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void Combotecnico_Load(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtrefaccion.Text))
			{
				MessageBox.Show("Campo costo de refacción");
			}
			if (string.IsNullOrWhiteSpace(txtmano.Text))
			{
				MessageBox.Show("Campo mano de obra vacío");
			}
			if (string.IsNullOrWhiteSpace(txttotal.Text))
			{
				MessageBox.Show("Campo total vacio");
			}
			if (string.IsNullOrWhiteSpace(txtabono.Text))
			{
				MessageBox.Show("Campo abono vacio");
			}
			int presupuesto = Convert.ToInt32(txtrefaccion.Text);
			int mano = Convert.ToInt32(txtmano.Text);
			int abono = Convert.ToInt32(txtabono.Text);
			int total = Convert.ToInt32(txttotal.Text);
			int folio = Convert.ToInt32(txtfolio.Text);
			int equipo = Convert.ToInt32(txtidequipo.Text);
			string tabla = txttipo.Text;
			string query_costos = "update " + tabla + "  set presupuesto='" + presupuesto + "', mano_obra='" + mano + "', abono='" + abono + "', costo_total='" + total + "'where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
			MySqlCommand cmd_query_costos = new MySqlCommand(query_costos, conn);
			DialogResult dr = MessageBox.Show("¿Son correctos los costos de la orden número '" + equipo + "'?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
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

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(combotecnico.Text))
			{
				MessageBox.Show("Campo tecnico no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtestado.Text))
			{
				MessageBox.Show("Campo estado no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtpersonal1.Text))
			{
				MessageBox.Show("Campo tecnico asigado vacio");
			}
			string tabla = txttipo.Text;
			string tecnico = combotecnico.SelectedItem.ToString();
			string query_tecnico = "update " + tabla + "  set id_personal='" + tecnico + "'";
			MySqlCommand cmd_query_tecnico = new MySqlCommand(query_tecnico, conn);
			DialogResult dr = MessageBox.Show("¿Esta seguro que desea signar al tecnico número '" + tecnico + "' ?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				try
				{
					conn.Open();
					MySqlDataReader leercomando2 = cmd_query_tecnico.ExecuteReader();
					MessageBox.Show("Tecnico asignado satisfactoriamente");
					conn.Close();
					Close();
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
				}
			}
			string query_estado = "update " + tabla + " set estado='En Reparación', ubicacion='Taller' ";
			MySqlCommand cmd_query_estado = new MySqlCommand(query_estado, conn);
			try
			{
				conn.Open();
				MySqlDataReader leercomando = cmd_query_estado.ExecuteReader();
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Taller_actualizar_Load(object sender, EventArgs e)
		{
		}

		private void txttotal_TextChanged(object sender, EventArgs e)
		{
		}

		private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void txtabono_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtrefaccion.Text) && !string.IsNullOrEmpty(txtmano.Text) && !string.IsNullOrEmpty(txtabono.Text))
			{
				txttotal.Text = (Convert.ToInt32(txtrefaccion.Text) + Convert.ToInt32(txtmano.Text) - Convert.ToInt32(txtabono.Text)).ToString();
			}
		}

		private void txtmano_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void txtrefaccion_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			int idpersonal = Convert.ToInt32(txtpersonal1.Text);
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

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electronica.Taller_actualizar2));
			label1 = new System.Windows.Forms.Label();
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
			txt_puntos = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			txtidequipo = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			btncostos = new System.Windows.Forms.Button();
			btnasignar = new System.Windows.Forms.Button();
			btngenerar = new System.Windows.Forms.Button();
			txtpersonal1 = new System.Windows.Forms.TextBox();
			txtestado = new System.Windows.Forms.ComboBox();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label1.Name = "label1";
			resources.ApplyResources(label2, "label2");
			label2.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label2.Name = "label2";
			resources.ApplyResources(label3, "label3");
			label3.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label3.Name = "label3";
			resources.ApplyResources(label4, "label4");
			label4.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label4.Name = "label4";
			resources.ApplyResources(label5, "label5");
			label5.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label5.Name = "label5";
			resources.ApplyResources(label6, "label6");
			label6.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label6.Name = "label6";
			resources.ApplyResources(label7, "label7");
			label7.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label7.Name = "label7";
			resources.ApplyResources(label8, "label8");
			label8.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label8.Name = "label8";
			resources.ApplyResources(label9, "label9");
			label9.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label9.Name = "label9";
			resources.ApplyResources(label10, "label10");
			label10.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label10.Name = "label10";
			txtequipo.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtequipo, "txtequipo");
			txtequipo.Name = "txtequipo";
			txtfalla.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtfalla, "txtfalla");
			txtfalla.Name = "txtfalla";
			txtmarca.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtmarca, "txtmarca");
			txtmarca.Name = "txtmarca";
			txtaccesorios.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtaccesorios, "txtaccesorios");
			txtaccesorios.Name = "txtaccesorios";
			txtcomentarios.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtcomentarios, "txtcomentarios");
			txtcomentarios.Name = "txtcomentarios";
			txtrefaccion.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtrefaccion, "txtrefaccion");
			txtrefaccion.Name = "txtrefaccion";
			txtrefaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtrefaccion_KeyPress);
			combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combolocacion.FormattingEnabled = true;
			combolocacion.Items.AddRange(new object[4]
			{
				resources.GetString("combolocacion.Items"),
				resources.GetString("combolocacion.Items1"),
				resources.GetString("combolocacion.Items2"),
				resources.GetString("combolocacion.Items3")
			});
			resources.ApplyResources(combolocacion, "combolocacion");
			combolocacion.Name = "combolocacion";
			resources.ApplyResources(txtfolio, "txtfolio");
			txtfolio.Name = "txtfolio";
			txtmodelo.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtmodelo, "txtmodelo");
			txtmodelo.Name = "txtmodelo";
			resources.ApplyResources(label12, "label12");
			label12.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label12.Name = "label12";
			resources.ApplyResources(label13, "label13");
			label13.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label13.Name = "label13";
			resources.ApplyResources(label14, "label14");
			label14.BackColor = System.Drawing.Color.FromArgb(51, 133, 198);
			label14.Name = "label14";
			resources.ApplyResources(label11, "label11");
			label11.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label11.Name = "label11";
			txtmano.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtmano, "txtmano");
			txtmano.Name = "txtmano";
			txtmano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtmano_KeyPress);
			resources.ApplyResources(label15, "label15");
			label15.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			label15.Name = "label15";
			resources.ApplyResources(label16, "label16");
			label16.BackColor = System.Drawing.Color.FromArgb(51, 133, 198);
			label16.Name = "label16";
			combotecnico.BackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			combotecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combotecnico.FormattingEnabled = true;
			resources.ApplyResources(combotecnico, "combotecnico");
			combotecnico.Name = "combotecnico";
			combotecnico.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			resources.ApplyResources(label17, "label17");
			label17.BackColor = System.Drawing.Color.FromArgb(51, 133, 198);
			label17.Name = "label17";
			resources.ApplyResources(label18, "label18");
			label18.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label18.Name = "label18";
			txttotal.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txttotal, "txttotal");
			txttotal.Name = "txttotal";
			txttotal.ReadOnly = true;
			txttotal.TextChanged += new System.EventHandler(txttotal_TextChanged);
			txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txttotal_KeyPress);
			txtabono.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtabono, "txtabono");
			txtabono.Name = "txtabono";
			txtabono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtabono_KeyPress);
			resources.ApplyResources(label19, "label19");
			label19.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label19.Name = "label19";
			resources.ApplyResources(txttipo, "txttipo");
			txttipo.Name = "txttipo";
			txtfechaen.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtfechaen, "txtfechaen");
			txtfechaen.Name = "txtfechaen";
			txtfechain.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtfechain, "txtfechain");
			txtfechain.Name = "txtfechain";
			txt_puntos.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txt_puntos, "txt_puntos");
			txt_puntos.Name = "txt_puntos";
			resources.ApplyResources(label20, "label20");
			label20.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			label20.Name = "label20";
			resources.ApplyResources(label21, "label21");
			label21.BackColor = System.Drawing.Color.FromArgb(51, 133, 198);
			label21.Name = "label21";
			panel3.BackColor = System.Drawing.Color.FromArgb(1, 112, 168);
			panel3.Controls.Add(txtrefaccion);
			panel3.Controls.Add(txtabono);
			panel3.Controls.Add(txtmano);
			panel3.Controls.Add(txttotal);
			resources.ApplyResources(panel3, "panel3");
			panel3.Name = "panel3";
			panel1.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			panel1.Controls.Add(txtidequipo);
			panel1.Controls.Add(txttipo);
			panel1.Controls.Add(txtfolio);
			panel1.Controls.Add(label1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			txtidequipo.BackColor = System.Drawing.Color.FromArgb(66, 174, 202);
			resources.ApplyResources(txtidequipo, "txtidequipo");
			txtidequipo.Name = "txtidequipo";
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			resources.ApplyResources(button1, "button1");
			button1.Image = Electronica.Properties.Resources._001_binoculars;
			button1.Name = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			btncostos.FlatAppearance.BorderSize = 0;
			btncostos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			resources.ApplyResources(btncostos, "btncostos");
			btncostos.Image = Electronica.Properties.Resources._002_coin;
			btncostos.Name = "btncostos";
			btncostos.UseVisualStyleBackColor = true;
			btncostos.Click += new System.EventHandler(button2_Click);
			btnasignar.FlatAppearance.BorderSize = 0;
			btnasignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			resources.ApplyResources(btnasignar, "btnasignar");
			btnasignar.Image = Electronica.Properties.Resources.tick_inside_circle;
			btnasignar.Name = "btnasignar";
			btnasignar.UseVisualStyleBackColor = true;
			btnasignar.Click += new System.EventHandler(button1_Click);
			btngenerar.FlatAppearance.BorderSize = 0;
			btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			resources.ApplyResources(btngenerar, "btngenerar");
			btngenerar.Image = Electronica.Properties.Resources._003_refresh_button1;
			btngenerar.Name = "btngenerar";
			btngenerar.UseVisualStyleBackColor = true;
			btngenerar.Click += new System.EventHandler(btngenorden_Click);
			txtpersonal1.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(txtpersonal1, "txtpersonal1");
			txtpersonal1.Name = "txtpersonal1";
			txtestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			txtestado.FormattingEnabled = true;
			txtestado.Items.AddRange(new object[4]
			{
				resources.GetString("txtestado.Items"),
				resources.GetString("txtestado.Items1"),
				resources.GetString("txtestado.Items2"),
				resources.GetString("txtestado.Items3")
			});
			resources.ApplyResources(txtestado, "txtestado");
			txtestado.Name = "txtestado";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.Controls.Add(txtestado);
			base.Controls.Add(txt_puntos);
			base.Controls.Add(label20);
			base.Controls.Add(txtfechaen);
			base.Controls.Add(txtfechain);
			base.Controls.Add(label19);
			base.Controls.Add(label18);
			base.Controls.Add(btncostos);
			base.Controls.Add(label15);
			base.Controls.Add(label11);
			base.Controls.Add(label13);
			base.Controls.Add(label12);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(btngenerar);
			base.Controls.Add(combolocacion);
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
			base.Controls.Add(panel3);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(panel1);
			base.Controls.Add(txtpersonal1);
			base.Controls.Add(label21);
			base.Controls.Add(button1);
			base.Controls.Add(combotecnico);
			base.Controls.Add(label17);
			base.Controls.Add(label16);
			base.Controls.Add(btnasignar);
			base.Controls.Add(label14);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Taller_actualizar2";
			base.Load += new System.EventHandler(Taller_actualizar_Load);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
