using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller_actualizar3 : Form
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

		public TextBox txtresta;

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

		private Panel panel2;

		private Label label22;
        public TextBox txtegreso;
        private Label label23;
        private Label label27;
        private Button button6;
        public TextBox txtubicacion;
        public TextBox txtsubtotal;

		public Taller_actualizar3()
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
			DialogResult dr = MessageBox.Show("¿Los datos de la orden son correctos?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtequipo.Text))
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
				string locacion = combolocacion.SelectedItem.ToString();
				int idequipo = Convert.ToInt32(txtidequipo.Text);
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
				string query_actualizar_orden = "update  " + tabla + " set equipo='" + equipo + "', marca='" + marca + "', modelo='" + modelo + "', accesorios= '" + accesorios + "', falla=  '" + falla + "',servicio='" + locacion + "', ubicacion='"+txtubicacion.Text+"' , comentarios= '" + comentarios + "' where id_equipo='" + idequipo + "'";
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
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		
		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Son correctos los costos de la orden número?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(txtrefaccion.Text))
				{
					MessageBox.Show("Campo costo de refacción");
				}
				if (string.IsNullOrWhiteSpace(txtmano.Text))
				{
					MessageBox.Show("Campo mano de obra vacío");
				}
				if (string.IsNullOrWhiteSpace(txtresta.Text))
				{
					MessageBox.Show("Campo total vacio");
				}
				if (string.IsNullOrWhiteSpace(txtabono.Text))
				{
					MessageBox.Show("Campo abono vacio");
				}
                else
                {
                    int refaccion = Convert.ToInt32(txtrefaccion.Text);
                    int mano = Convert.ToInt32(txtmano.Text);
                    int abono = Convert.ToInt32(txtabono.Text);
                    int resta = Convert.ToInt32(txtresta.Text);
                    int folio = Convert.ToInt32(txtfolio.Text);
                    int equipo = Convert.ToInt32(txtidequipo.Text);
                    string tabla = txttipo.Text;
                    int sub;

                    sub = refaccion + mano;
                    resta = refaccion + mano - abono;

                    string query_costos = "update " + tabla + "  set presupuesto='" + refaccion + "', mano_obra='" + mano + "', abono='" + abono + "',restante='" + resta + "', costo_total='" + sub + "' where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
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

		private void button1_Click(object sender, EventArgs e)
		{
			string tabla = txttipo.Text;
			string tecnico = combotecnico.SelectedItem.ToString();
			DialogResult dr = MessageBox.Show("¿Esta seguro que desea signar al tecnico número '" + tecnico + "' ?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(combotecnico.Text))
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
			else
			{
				int idequipos = Convert.ToInt32(txtidequipo.Text);
				string estado = txtestado.SelectedItem.ToString();
				string query_estado = "update " + tabla + " set estado='" + estado + "', ubicacion='Taller' where id_equipo='" + idequipos + "'";
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
		}

		private void Taller_actualizar_Load(object sender, EventArgs e)
		{
            if (txtubicacion.Text == "Taller")
            {
                button6.Visible = true;
            }
            if (!string.IsNullOrEmpty(txtrefaccion.Text) && !string.IsNullOrEmpty(txtmano.Text) && !string.IsNullOrEmpty(txtabono.Text))
            {
                txtresta.Text = (Convert.ToInt32(txtsubtotal.Text) - Convert.ToInt32(txtabono.Text)).ToString();
            }
        }

	

		private void txtmano_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtmano.Text))
			{
				return;
			}
		}

		private void txtrefaccion_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (string.IsNullOrEmpty(txtrefaccion.Text))
			{
				return;
			}
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
				tr.txtsolicitud.Text = sr["parte"].ToString();
				tr.ShowDialog();
			}
			conn.Close();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtequipo = new System.Windows.Forms.TextBox();
            this.txtfalla = new System.Windows.Forms.TextBox();
            this.txtmarca = new System.Windows.Forms.TextBox();
            this.txtaccesorios = new System.Windows.Forms.TextBox();
            this.txtcomentarios = new System.Windows.Forms.TextBox();
            this.txtrefaccion = new System.Windows.Forms.TextBox();
            this.combolocacion = new System.Windows.Forms.ComboBox();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmano = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.combotecnico = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtresta = new System.Windows.Forms.TextBox();
            this.txtabono = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txttipo = new System.Windows.Forms.TextBox();
            this.txtfechaen = new System.Windows.Forms.TextBox();
            this.txtfechain = new System.Windows.Forms.TextBox();
            this.txt_puntos = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btncostos = new System.Windows.Forms.Button();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtubicacion = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtegreso = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnasignar = new System.Windows.Forms.Button();
            this.btngenerar = new System.Windows.Forms.Button();
            this.txtpersonal1 = new System.Windows.Forms.TextBox();
            this.txtestado = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignar Tareas a Tecnicos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Equipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label3.Location = new System.Drawing.Point(455, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comentarios:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label4.Location = new System.Drawing.Point(21, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de solicitud de servicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label5.Location = new System.Drawing.Point(240, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Accesorios:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(19, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Costo Refaccion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(20, 431);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Presupuesto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label8.Location = new System.Drawing.Point(17, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Locacion:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label9.Location = new System.Drawing.Point(17, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Falla:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label10.Location = new System.Drawing.Point(238, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Marca:";
            // 
            // txtequipo
            // 
            this.txtequipo.BackColor = System.Drawing.SystemColors.Control;
            this.txtequipo.Location = new System.Drawing.Point(64, 65);
            this.txtequipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtequipo.Name = "txtequipo";
            this.txtequipo.Size = new System.Drawing.Size(157, 20);
            this.txtequipo.TabIndex = 0;
            this.txtequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtfalla
            // 
            this.txtfalla.BackColor = System.Drawing.SystemColors.Control;
            this.txtfalla.Location = new System.Drawing.Point(64, 93);
            this.txtfalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.Size = new System.Drawing.Size(157, 20);
            this.txtfalla.TabIndex = 2;
            this.txtfalla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmarca
            // 
            this.txtmarca.BackColor = System.Drawing.SystemColors.Control;
            this.txtmarca.Location = new System.Drawing.Point(307, 65);
            this.txtmarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.Size = new System.Drawing.Size(123, 20);
            this.txtmarca.TabIndex = 1;
            this.txtmarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaccesorios
            // 
            this.txtaccesorios.BackColor = System.Drawing.SystemColors.Control;
            this.txtaccesorios.Location = new System.Drawing.Point(307, 126);
            this.txtaccesorios.Margin = new System.Windows.Forms.Padding(2);
            this.txtaccesorios.Name = "txtaccesorios";
            this.txtaccesorios.Size = new System.Drawing.Size(120, 20);
            this.txtaccesorios.TabIndex = 5;
            this.txtaccesorios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.BackColor = System.Drawing.SystemColors.Control;
            this.txtcomentarios.Location = new System.Drawing.Point(458, 65);
            this.txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomentarios.Multiline = true;
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.Size = new System.Drawing.Size(467, 96);
            this.txtcomentarios.TabIndex = 9;
            // 
            // txtrefaccion
            // 
            this.txtrefaccion.BackColor = System.Drawing.SystemColors.Control;
            this.txtrefaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtrefaccion.Location = new System.Drawing.Point(137, 50);
            this.txtrefaccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtrefaccion.Name = "txtrefaccion";
            this.txtrefaccion.Size = new System.Drawing.Size(76, 22);
            this.txtrefaccion.TabIndex = 15;
            this.txtrefaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrefaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrefaccion_KeyPress);
            // 
            // combolocacion
            // 
            this.combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combolocacion.FormattingEnabled = true;
            this.combolocacion.Items.AddRange(new object[] {
            "Taller",
            "Domicilio",
            "Garantia",
            "Otros"});
            this.combolocacion.Location = new System.Drawing.Point(70, 118);
            this.combolocacion.Margin = new System.Windows.Forms.Padding(2);
            this.combolocacion.Name = "combolocacion";
            this.combolocacion.Size = new System.Drawing.Size(92, 21);
            this.combolocacion.TabIndex = 4;
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(651, 11);
            this.txtfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(76, 20);
            this.txtfolio.TabIndex = 20;
            this.txtfolio.Visible = false;
            // 
            // txtmodelo
            // 
            this.txtmodelo.BackColor = System.Drawing.SystemColors.Control;
            this.txtmodelo.Location = new System.Drawing.Point(307, 96);
            this.txtmodelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.Size = new System.Drawing.Size(123, 20);
            this.txtmodelo.TabIndex = 3;
            this.txtmodelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label12.Location = new System.Drawing.Point(240, 99);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Modelo:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label13.Location = new System.Drawing.Point(196, 179);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Fecha de inicio de reparacion:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.label14.Location = new System.Drawing.Point(270, 292);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Estado actual:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.Location = new System.Drawing.Point(236, 469);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "Mano de Obra:";
            // 
            // txtmano
            // 
            this.txtmano.BackColor = System.Drawing.SystemColors.Control;
            this.txtmano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtmano.Location = new System.Drawing.Point(341, 50);
            this.txtmano.Margin = new System.Windows.Forms.Padding(2);
            this.txtmano.Name = "txtmano";
            this.txtmano.Size = new System.Drawing.Size(76, 22);
            this.txtmano.TabIndex = 16;
            this.txtmano.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmano_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(16, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(234, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Modificar Orden de Servicio:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(20, 241);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(264, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "Asignar tecnico para reparacion";
            // 
            // combotecnico
            // 
            this.combotecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.combotecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotecnico.FormattingEnabled = true;
            this.combotecnico.Location = new System.Drawing.Point(124, 289);
            this.combotecnico.Margin = new System.Windows.Forms.Padding(2);
            this.combotecnico.Name = "combotecnico";
            this.combotecnico.Size = new System.Drawing.Size(126, 21);
            this.combotecnico.TabIndex = 11;
            this.combotecnico.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.label17.Location = new System.Drawing.Point(33, 292);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "Técnico número:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label18.Location = new System.Drawing.Point(278, 522);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 16);
            this.label18.TabIndex = 37;
            this.label18.Text = "Resta:";
            // 
            // txtresta
            // 
            this.txtresta.BackColor = System.Drawing.SystemColors.Control;
            this.txtresta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtresta.Location = new System.Drawing.Point(341, 103);
            this.txtresta.Margin = new System.Windows.Forms.Padding(2);
            this.txtresta.Name = "txtresta";
            this.txtresta.ReadOnly = true;
            this.txtresta.Size = new System.Drawing.Size(76, 22);
            this.txtresta.TabIndex = 18;
            this.txtresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtabono
            // 
            this.txtabono.BackColor = System.Drawing.SystemColors.Control;
            this.txtabono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtabono.Location = new System.Drawing.Point(137, 103);
            this.txtabono.Margin = new System.Windows.Forms.Padding(2);
            this.txtabono.Name = "txtabono";
            this.txtabono.Size = new System.Drawing.Size(76, 22);
            this.txtabono.TabIndex = 17;
            this.txtabono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label19.Location = new System.Drawing.Point(61, 522);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 16);
            this.label19.TabIndex = 39;
            this.label19.Text = "Abono:";
            // 
            // txttipo
            // 
            this.txttipo.Location = new System.Drawing.Point(775, 11);
            this.txttipo.Margin = new System.Windows.Forms.Padding(2);
            this.txttipo.Name = "txttipo";
            this.txttipo.Size = new System.Drawing.Size(150, 20);
            this.txttipo.TabIndex = 41;
            this.txttipo.Visible = false;
            // 
            // txtfechaen
            // 
            this.txtfechaen.BackColor = System.Drawing.SystemColors.Control;
            this.txtfechaen.Location = new System.Drawing.Point(199, 195);
            this.txtfechaen.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechaen.Name = "txtfechaen";
            this.txtfechaen.ReadOnly = true;
            this.txtfechaen.Size = new System.Drawing.Size(138, 20);
            this.txtfechaen.TabIndex = 8;
            // 
            // txtfechain
            // 
            this.txtfechain.BackColor = System.Drawing.SystemColors.Control;
            this.txtfechain.Location = new System.Drawing.Point(24, 191);
            this.txtfechain.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechain.Name = "txtfechain";
            this.txtfechain.ReadOnly = true;
            this.txtfechain.Size = new System.Drawing.Size(138, 20);
            this.txtfechain.TabIndex = 7;
            // 
            // txt_puntos
            // 
            this.txt_puntos.BackColor = System.Drawing.SystemColors.Control;
            this.txt_puntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_puntos.Location = new System.Drawing.Point(550, 103);
            this.txt_puntos.Margin = new System.Windows.Forms.Padding(2);
            this.txt_puntos.Name = "txt_puntos";
            this.txt_puntos.Size = new System.Drawing.Size(76, 22);
            this.txt_puntos.TabIndex = 46;
            this.txt_puntos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label20.Location = new System.Drawing.Point(475, 106);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 16);
            this.label20.TabIndex = 45;
            this.label20.Text = "Puntos:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.label21.Location = new System.Drawing.Point(772, 292);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "Tecnico asignado #:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.btncostos);
            this.panel3.Controls.Add(this.txt_puntos);
            this.panel3.Controls.Add(this.txtsubtotal);
            this.panel3.Controls.Add(this.txtrefaccion);
            this.panel3.Controls.Add(this.txtabono);
            this.panel3.Controls.Add(this.txtmano);
            this.panel3.Controls.Add(this.txtresta);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.panel3.Location = new System.Drawing.Point(-4, 416);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 298);
            this.panel3.TabIndex = 51;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::Electronica.Properties.Resources.shipped;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(880, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(195, 36);
            this.button6.TabIndex = 57;
            this.button6.Text = "        Solicitud de traslado";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(459, 53);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 16);
            this.label22.TabIndex = 57;
            this.label22.Text = "Total:";
            // 
            // btncostos
            // 
            this.btncostos.BackColor = System.Drawing.Color.White;
            this.btncostos.FlatAppearance.BorderSize = 0;
            this.btncostos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btncostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncostos.Image = global::Electronica.Properties.Resources._002_coin;
            this.btncostos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncostos.Location = new System.Drawing.Point(701, 95);
            this.btncostos.Margin = new System.Windows.Forms.Padding(2);
            this.btncostos.Name = "btncostos";
            this.btncostos.Size = new System.Drawing.Size(137, 35);
            this.btncostos.TabIndex = 19;
            this.btncostos.Text = "      Asignar costos";
            this.btncostos.UseVisualStyleBackColor = false;
            this.btncostos.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtsubtotal.Location = new System.Drawing.Point(550, 50);
            this.txtsubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(76, 22);
            this.txtsubtotal.TabIndex = 19;
            this.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.panel1.Controls.Add(this.txtubicacion);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.txtegreso);
            this.panel1.Controls.Add(this.txtfechaen);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtidequipo);
            this.panel1.Controls.Add(this.txttipo);
            this.panel1.Controls.Add(this.txtfolio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(-4, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 235);
            this.panel1.TabIndex = 49;
            // 
            // txtubicacion
            // 
            this.txtubicacion.Location = new System.Drawing.Point(75, 147);
            this.txtubicacion.Name = "txtubicacion";
            this.txtubicacion.Size = new System.Drawing.Size(146, 20);
            this.txtubicacion.TabIndex = 59;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label27.Location = new System.Drawing.Point(12, 150);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 13);
            this.label27.TabIndex = 56;
            this.label27.Text = "Ubicación:";
            // 
            // txtegreso
            // 
            this.txtegreso.BackColor = System.Drawing.SystemColors.Control;
            this.txtegreso.Location = new System.Drawing.Point(370, 196);
            this.txtegreso.Margin = new System.Windows.Forms.Padding(2);
            this.txtegreso.Name = "txtegreso";
            this.txtegreso.ReadOnly = true;
            this.txtegreso.Size = new System.Drawing.Size(138, 20);
            this.txtegreso.TabIndex = 58;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label23.Location = new System.Drawing.Point(367, 180);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(161, 13);
            this.label23.TabIndex = 57;
            this.label23.Text = "Fecha egreso(Inicio de garantía)";
            // 
            // txtidequipo
            // 
            this.txtidequipo.BackColor = System.Drawing.Color.White;
            this.txtidequipo.Location = new System.Drawing.Point(259, 35);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.Size = new System.Drawing.Size(100, 20);
            this.txtidequipo.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Electronica.Properties.Resources._001_binoculars;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(24, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ver Reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnasignar
            // 
            this.btnasignar.FlatAppearance.BorderSize = 0;
            this.btnasignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnasignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnasignar.Image = global::Electronica.Properties.Resources.tick_inside_circle;
            this.btnasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnasignar.Location = new System.Drawing.Point(788, 349);
            this.btnasignar.Margin = new System.Windows.Forms.Padding(2);
            this.btnasignar.Name = "btnasignar";
            this.btnasignar.Size = new System.Drawing.Size(160, 35);
            this.btnasignar.TabIndex = 14;
            this.btnasignar.Text = "      Actualizar estado actual";
            this.btnasignar.UseVisualStyleBackColor = true;
            this.btnasignar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btngenerar
            // 
            this.btngenerar.FlatAppearance.BorderSize = 0;
            this.btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerar.Image = global::Electronica.Properties.Resources._003_refresh_button1;
            this.btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerar.Location = new System.Drawing.Point(788, 176);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(137, 35);
            this.btngenerar.TabIndex = 10;
            this.btngenerar.Text = "Actualizar Orden";
            this.btngenerar.UseVisualStyleBackColor = true;
            this.btngenerar.Click += new System.EventHandler(this.btngenorden_Click);
            // 
            // txtpersonal1
            // 
            this.txtpersonal1.BackColor = System.Drawing.SystemColors.Control;
            this.txtpersonal1.Location = new System.Drawing.Point(876, 289);
            this.txtpersonal1.Name = "txtpersonal1";
            this.txtpersonal1.Size = new System.Drawing.Size(100, 20);
            this.txtpersonal1.TabIndex = 47;
            this.txtpersonal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtestado
            // 
            this.txtestado.FormattingEnabled = true;
            this.txtestado.Items.AddRange(new object[] {
            "Reparada",
            "Sin solucion",
            "Necesita pieza"});
            this.txtestado.Location = new System.Drawing.Point(376, 61);
            this.txtestado.Name = "txtestado";
            this.txtestado.Size = new System.Drawing.Size(121, 21);
            this.txtestado.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.panel2.Controls.Add(this.txtestado);
            this.panel2.Location = new System.Drawing.Point(0, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 200);
            this.panel2.TabIndex = 56;
            // 
            // Taller_actualizar3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.txtfechain);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.combolocacion);
            this.Controls.Add(this.txtaccesorios);
            this.Controls.Add(this.txtmarca);
            this.Controls.Add(this.txtfalla);
            this.Controls.Add(this.txtequipo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtcomentarios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtpersonal1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combotecnico);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnasignar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Taller_actualizar3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ordenes de Servicio";
            this.Load += new System.EventHandler(this.Taller_actualizar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Taller_actualizar3_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Taller_actualizar3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Taller_traslado_nuevo ss = new Taller_traslado_nuevo(txtfolio.Text, txtidequipo.Text);
            ss.ShowDialog();
        }
    }
}
