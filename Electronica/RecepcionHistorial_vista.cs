using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Electronica
{
	public class RecepcionHistorial_vista : Form
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

		public TextBox txtsubtotal;

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
        private Label label26;
        public TextBox txtrestante;
        private Button button6;
        public TextBox txtubicacion;
        private Label label27;
        public Button button5;
        private Label label25;

        public RecepcionHistorial_vista()
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
			int total = Convert.ToInt32(txtsubtotal.Text);
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
            if (txtubicacion.Text == "Recepcion")
            {
                button6.Visible = true;
            }
          

            if (txtubicacion.Text == "Cliente")
            {
                if(txtestado.Text == "Entregado")
                    button5.Visible = true;
            }

            if (!string.IsNullOrEmpty(txtrefaccion.Text) && !string.IsNullOrEmpty(txtmano.Text) && !string.IsNullOrEmpty(txtabono.Text))
            {
                txtrestante.Text = (Convert.ToInt32(txtsubtotal.Text) - Convert.ToInt32(txtabono.Text)).ToString();
            }
        }

		private void txttotal_TextChanged(object sender, EventArgs e)
		{
		}

		private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
		{
			
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
			DialogResult dr = MessageBox.Show("¿Es correcto el abono de "+txtabono.Text+" a la orden de servicio número: "+txtidequipo.Text+" ?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(txtabono.Text))
				{
					MessageBox.Show("Campo abono vacio");
				}
				else
				{

                    //generador de reporte pdf
                    PDF_Reporte pdf = new PDF_Reporte();
                    PDF_Abono cr = new PDF_Abono();


                    TextObject txtfolio1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtfolio"];
                    TextObject txtidequipo1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtequipo"];
                    TextObject txtnombre1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtnombre"];
                    TextObject txtapellido1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtapellido"];
                    TextObject txtabono1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtabono"];


                    txtfolio1.Text = txtfolio.Text;
                    txtidequipo1.Text = txtidequipo.Text;
                    txtnombre1.Text = txtnombre.Text;
                    txtapellido1.Text = txtapellidos.Text;
                    txtabono1.Text = txtabono.Text;

                    pdf.PDF_Generar.ReportSource = cr;
                    //f2.crystalReportViewer1.ReportSource = cr;
                    pdf.Show();


                    int presupuesto = Convert.ToInt32(txtrefaccion.Text);
					int mano = Convert.ToInt32(txtmano.Text);
					int abono = Convert.ToInt32(txtabono.Text);
					int total2 = Convert.ToInt32(txtsubtotal.Text);
					int folio = Convert.ToInt32(txtfolio.Text);
					int equipo = Convert.ToInt32(txtidequipo.Text);
                    int restante = Convert.ToInt32(txtrestante.Text);
                    string tabla = txttipo.Text;
					int total = int.Parse(txtsubtotal.Text);

                    restante = total2 - abono;

                    string query_costoxs = "insert into cobranza(tipo,estado,cantidad,id_equipo,id_folio) values('Abono','Pendiente','"+abono+"','"+txtidequipo.Text+"','"+txtfolio.Text+"')";
                    MySqlCommand cmd_query_costosx = new MySqlCommand(query_costoxs, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_costosx.ExecuteReader();

                        conn.Close();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //
                    string query_costos = "update reparar_tv  set abono='" + abono + "' , restante ='"+ restante + "' where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
					MySqlCommand cmd_query_costos = new MySqlCommand(query_costos, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_query_costos.ExecuteReader();
	
						conn.Close();
						Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
                    string query_costos1 = "update reparar_audio  set abono='" + abono + "' , restante ='" + restante + "' where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
                    MySqlCommand cmd_query_costos1 = new MySqlCommand(query_costos1, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_costos1.ExecuteReader();
                   
                        conn.Close();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    string query_costos2 = "update reparar_smartphones  set abono='" + abono + "', restante ='" + restante + "'  where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
                    MySqlCommand cmd_query_costos2 = new MySqlCommand(query_costos2, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_costos2.ExecuteReader();

                        conn.Close();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    string query_costos3 = "update reparar_electrodomesticos  set abono='" + abono + "' , restante ='" + restante + "' where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
                    MySqlCommand cmd_query_costos3 = new MySqlCommand(query_costos3, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_costos3.ExecuteReader();

                        conn.Close();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    string query_costos4 = "update reparar_laptops  set abono='" + abono + "' , restante ='" + restante + "'  where id_folio='" + folio + "' and id_equipo='" + equipo + "'";
                    MySqlCommand cmd_query_costos4 = new MySqlCommand(query_costos4, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_costos4.ExecuteReader();
                        MessageBox.Show("Abono agregado satisfactoriamente");
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
				string total = txtsubtotal.Text;
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
            if (txtabono.Text != "0")
            {
               // if (txtubicacion.Text == "Taller")
                    button2.Visible = true;
            }
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
                button2.Visible = false;
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
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.txtabono = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txttipo = new System.Windows.Forms.TextBox();
            this.txtfechaen = new System.Windows.Forms.TextBox();
            this.txtfechain = new System.Windows.Forms.TextBox();
            this.txtestado = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtubicacion = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.txtpersonal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.txtegreso = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.txtcelular = new System.Windows.Forms.TextBox();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtrestante = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtpuntos = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.label4.Location = new System.Drawing.Point(21, 178);
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
            this.label6.Location = new System.Drawing.Point(19, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Costo Refaccion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 431);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Presupuesto acordado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label8.Location = new System.Drawing.Point(17, 128);
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
            this.txtequipo.BackColor = System.Drawing.SystemColors.Window;
            this.txtequipo.Location = new System.Drawing.Point(64, 65);
            this.txtequipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtequipo.Name = "txtequipo";
            this.txtequipo.ReadOnly = true;
            this.txtequipo.Size = new System.Drawing.Size(157, 20);
            this.txtequipo.TabIndex = 10;
            this.txtequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtfalla
            // 
            this.txtfalla.BackColor = System.Drawing.SystemColors.Window;
            this.txtfalla.Location = new System.Drawing.Point(64, 93);
            this.txtfalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.ReadOnly = true;
            this.txtfalla.Size = new System.Drawing.Size(157, 20);
            this.txtfalla.TabIndex = 11;
            this.txtfalla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmarca
            // 
            this.txtmarca.BackColor = System.Drawing.SystemColors.Window;
            this.txtmarca.Location = new System.Drawing.Point(307, 65);
            this.txtmarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.ReadOnly = true;
            this.txtmarca.Size = new System.Drawing.Size(123, 20);
            this.txtmarca.TabIndex = 12;
            this.txtmarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaccesorios
            // 
            this.txtaccesorios.BackColor = System.Drawing.SystemColors.Window;
            this.txtaccesorios.Location = new System.Drawing.Point(307, 126);
            this.txtaccesorios.Margin = new System.Windows.Forms.Padding(2);
            this.txtaccesorios.Name = "txtaccesorios";
            this.txtaccesorios.ReadOnly = true;
            this.txtaccesorios.Size = new System.Drawing.Size(120, 20);
            this.txtaccesorios.TabIndex = 13;
            this.txtaccesorios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.BackColor = System.Drawing.SystemColors.Window;
            this.txtcomentarios.Location = new System.Drawing.Point(458, 72);
            this.txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomentarios.Multiline = true;
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.ReadOnly = true;
            this.txtcomentarios.Size = new System.Drawing.Size(467, 96);
            this.txtcomentarios.TabIndex = 14;
            // 
            // txtrefaccion
            // 
            this.txtrefaccion.BackColor = System.Drawing.SystemColors.Window;
            this.txtrefaccion.Location = new System.Drawing.Point(112, 466);
            this.txtrefaccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtrefaccion.Name = "txtrefaccion";
            this.txtrefaccion.ReadOnly = true;
            this.txtrefaccion.Size = new System.Drawing.Size(76, 20);
            this.txtrefaccion.TabIndex = 17;
            this.txtrefaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combolocacion
            // 
            this.combolocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combolocacion.FormattingEnabled = true;
            this.combolocacion.Items.AddRange(new object[] {
            "Taller",
            "Domicilio",
            "Garantia",
            "Otros"});
            this.combolocacion.Location = new System.Drawing.Point(79, 125);
            this.combolocacion.Margin = new System.Windows.Forms.Padding(2);
            this.combolocacion.Name = "combolocacion";
            this.combolocacion.Size = new System.Drawing.Size(141, 21);
            this.combolocacion.TabIndex = 19;
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(889, 27);
            this.txtfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(76, 20);
            this.txtfolio.TabIndex = 20;
            this.txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmodelo
            // 
            this.txtmodelo.BackColor = System.Drawing.SystemColors.Window;
            this.txtmodelo.Location = new System.Drawing.Point(307, 96);
            this.txtmodelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.ReadOnly = true;
            this.txtmodelo.Size = new System.Drawing.Size(123, 20);
            this.txtmodelo.TabIndex = 22;
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
            this.label13.Location = new System.Drawing.Point(190, 178);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Fecha de inicio reparación:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label14.Location = new System.Drawing.Point(24, 290);
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
            this.label11.Location = new System.Drawing.Point(236, 469);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Mano de Obra:";
            // 
            // txtmano
            // 
            this.txtmano.BackColor = System.Drawing.SystemColors.Window;
            this.txtmano.Location = new System.Drawing.Point(318, 466);
            this.txtmano.Margin = new System.Windows.Forms.Padding(2);
            this.txtmano.Name = "txtmano";
            this.txtmano.ReadOnly = true;
            this.txtmano.Size = new System.Drawing.Size(76, 20);
            this.txtmano.TabIndex = 30;
            this.txtmano.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = " Orden de Servicio:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 241);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(200, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "Estado de la reparación";
            // 
            // combotecnico
            // 
            this.combotecnico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.combotecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.combotecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotecnico.FormattingEnabled = true;
            this.combotecnico.Location = new System.Drawing.Point(281, 171);
            this.combotecnico.Margin = new System.Windows.Forms.Padding(2);
            this.combotecnico.Name = "combotecnico";
            this.combotecnico.Size = new System.Drawing.Size(126, 21);
            this.combotecnico.TabIndex = 35;
            this.combotecnico.Visible = false;
            this.combotecnico.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label17.Location = new System.Drawing.Point(190, 174);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "Técnico número:";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label18.Location = new System.Drawing.Point(437, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Total:";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtsubtotal.Location = new System.Drawing.Point(477, 53);
            this.txtsubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(76, 20);
            this.txtsubtotal.TabIndex = 38;
            this.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsubtotal.TextChanged += new System.EventHandler(this.txttotal_TextChanged);
            this.txtsubtotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotal_KeyPress);
            // 
            // txtabono
            // 
            this.txtabono.BackColor = System.Drawing.SystemColors.Window;
            this.txtabono.Location = new System.Drawing.Point(477, 119);
            this.txtabono.Margin = new System.Windows.Forms.Padding(2);
            this.txtabono.Name = "txtabono";
            this.txtabono.Size = new System.Drawing.Size(76, 20);
            this.txtabono.TabIndex = 40;
            this.txtabono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtabono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtabono_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label19.Location = new System.Drawing.Point(426, 122);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
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
            this.txtfechaen.BackColor = System.Drawing.SystemColors.Window;
            this.txtfechaen.Location = new System.Drawing.Point(193, 198);
            this.txtfechaen.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechaen.Name = "txtfechaen";
            this.txtfechaen.ReadOnly = true;
            this.txtfechaen.Size = new System.Drawing.Size(138, 20);
            this.txtfechaen.TabIndex = 44;
            // 
            // txtfechain
            // 
            this.txtfechain.BackColor = System.Drawing.SystemColors.Window;
            this.txtfechain.Location = new System.Drawing.Point(24, 191);
            this.txtfechain.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechain.Name = "txtfechain";
            this.txtfechain.ReadOnly = true;
            this.txtfechain.Size = new System.Drawing.Size(138, 20);
            this.txtfechain.TabIndex = 43;
            // 
            // txtestado
            // 
            this.txtestado.BackColor = System.Drawing.SystemColors.Window;
            this.txtestado.Location = new System.Drawing.Point(103, 287);
            this.txtestado.Margin = new System.Windows.Forms.Padding(2);
            this.txtestado.Name = "txtestado";
            this.txtestado.ReadOnly = true;
            this.txtestado.Size = new System.Drawing.Size(101, 20);
            this.txtestado.TabIndex = 45;
            this.txtestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.panel1.Controls.Add(this.txtubicacion);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.txtidequipo);
            this.panel1.Controls.Add(this.txtpersonal);
            this.panel1.Controls.Add(this.txtfechaen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtcomentarios);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.combolocacion);
            this.panel1.Location = new System.Drawing.Point(0, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 235);
            this.panel1.TabIndex = 46;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtubicacion
            // 
            this.txtubicacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtubicacion.Location = new System.Drawing.Point(79, 150);
            this.txtubicacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtubicacion.Name = "txtubicacion";
            this.txtubicacion.ReadOnly = true;
            this.txtubicacion.Size = new System.Drawing.Size(165, 20);
            this.txtubicacion.TabIndex = 50;
            this.txtubicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(174)))), ((int)(((byte)(202)))));
            this.label27.Location = new System.Drawing.Point(17, 153);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 13);
            this.label27.TabIndex = 49;
            this.label27.Text = "Ubicación:";
            // 
            // txtidequipo
            // 
            this.txtidequipo.BackColor = System.Drawing.Color.White;
            this.txtidequipo.Location = new System.Drawing.Point(184, 38);
            this.txtidequipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.Size = new System.Drawing.Size(101, 20);
            this.txtidequipo.TabIndex = 54;
            // 
            // txtpersonal
            // 
            this.txtpersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(198)))));
            this.txtpersonal.Location = new System.Drawing.Point(532, 28);
            this.txtpersonal.Margin = new System.Windows.Forms.Padding(2);
            this.txtpersonal.Name = "txtpersonal";
            this.txtpersonal.Size = new System.Drawing.Size(49, 20);
            this.txtpersonal.TabIndex = 48;
            this.txtpersonal.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.txtegreso);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtcorreo);
            this.panel2.Controls.Add(this.combotecnico);
            this.panel2.Controls.Add(this.txtcelular);
            this.panel2.Controls.Add(this.txtapellidos);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtnombre);
            this.panel2.Controls.Add(this.txtfolio);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Location = new System.Drawing.Point(0, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1106, 201);
            this.panel2.TabIndex = 47;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.button6.Location = new System.Drawing.Point(870, 151);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(195, 36);
            this.button6.TabIndex = 48;
            this.button6.Text = "        Solicitud de traslado";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtegreso
            // 
            this.txtegreso.BackColor = System.Drawing.SystemColors.Window;
            this.txtegreso.Location = new System.Drawing.Point(434, 71);
            this.txtegreso.Margin = new System.Windows.Forms.Padding(2);
            this.txtegreso.Name = "txtegreso";
            this.txtegreso.ReadOnly = true;
            this.txtegreso.Size = new System.Drawing.Size(138, 20);
            this.txtegreso.TabIndex = 50;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label25.Location = new System.Drawing.Point(242, 74);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(188, 13);
            this.label25.TabIndex = 49;
            this.label25.Text = "Fecha de entrega e inicio de garantía:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Electronica.Properties.Resources.call_answer;
            this.pictureBox1.Location = new System.Drawing.Point(668, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label21.Location = new System.Drawing.Point(862, 120);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 56;
            this.label21.Text = "Correo:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(711, 25);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 20);
            this.label20.TabIndex = 49;
            this.label20.Text = "Contacto del cliente:";
            // 
            // txtcorreo
            // 
            this.txtcorreo.BackColor = System.Drawing.SystemColors.Window;
            this.txtcorreo.Location = new System.Drawing.Point(907, 117);
            this.txtcorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.ReadOnly = true;
            this.txtcorreo.Size = new System.Drawing.Size(158, 20);
            this.txtcorreo.TabIndex = 55;
            this.txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcelular
            // 
            this.txtcelular.BackColor = System.Drawing.SystemColors.Window;
            this.txtcelular.Location = new System.Drawing.Point(908, 86);
            this.txtcelular.Margin = new System.Windows.Forms.Padding(2);
            this.txtcelular.Name = "txtcelular";
            this.txtcelular.ReadOnly = true;
            this.txtcelular.Size = new System.Drawing.Size(145, 20);
            this.txtcelular.TabIndex = 54;
            this.txtcelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtapellidos
            // 
            this.txtapellidos.BackColor = System.Drawing.SystemColors.Window;
            this.txtapellidos.Location = new System.Drawing.Point(687, 114);
            this.txtapellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.ReadOnly = true;
            this.txtapellidos.Size = new System.Drawing.Size(157, 20);
            this.txtapellidos.TabIndex = 53;
            this.txtapellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtnombre
            // 
            this.txtnombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtnombre.Location = new System.Drawing.Point(687, 86);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.ReadOnly = true;
            this.txtnombre.Size = new System.Drawing.Size(157, 20);
            this.txtnombre.TabIndex = 52;
            this.txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label22.Location = new System.Drawing.Point(631, 117);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 51;
            this.label22.Text = "Apellidos:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label24.Location = new System.Drawing.Point(625, 89);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 13);
            this.label24.TabIndex = 49;
            this.label24.Text = "Nombre(s):";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.label23.Location = new System.Drawing.Point(862, 89);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 50;
            this.label23.Text = "Celular:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.txtrestante);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.txtpuntos);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtsubtotal);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtabono);
            this.panel3.Location = new System.Drawing.Point(0, 413);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 295);
            this.panel3.TabIndex = 48;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::Properties.Resources.guarantee;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(870, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(195, 36);
            this.button5.TabIndex = 58;
            this.button5.Text = "        Ingreso por garantía";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label26.Location = new System.Drawing.Point(249, 122);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 13);
            this.label26.TabIndex = 46;
            this.label26.Text = "Restante:";
            // 
            // txtrestante
            // 
            this.txtrestante.BackColor = System.Drawing.SystemColors.Window;
            this.txtrestante.Location = new System.Drawing.Point(318, 119);
            this.txtrestante.Margin = new System.Windows.Forms.Padding(2);
            this.txtrestante.Name = "txtrestante";
            this.txtrestante.ReadOnly = true;
            this.txtrestante.Size = new System.Drawing.Size(76, 20);
            this.txtrestante.TabIndex = 47;
            this.txtrestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::Electronica.Properties.Resources.shipped;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(870, 111);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(195, 35);
            this.button4.TabIndex = 45;
            this.button4.Text = "       Confirmar entrega del equipo";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtpuntos
            // 
            this.txtpuntos.BackColor = System.Drawing.SystemColors.Window;
            this.txtpuntos.Location = new System.Drawing.Point(112, 119);
            this.txtpuntos.Margin = new System.Windows.Forms.Padding(2);
            this.txtpuntos.Name = "txtpuntos";
            this.txtpuntos.ReadOnly = true;
            this.txtpuntos.Size = new System.Drawing.Size(76, 20);
            this.txtpuntos.TabIndex = 42;
            this.txtpuntos.Text = "0";
            this.txtpuntos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Electronica.Properties.Resources.tick_inside_circle;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(581, 45);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 35);
            this.button3.TabIndex = 44;
            this.button3.Text = "    Confirmar descuento";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Electronica.Properties.Resources.discount;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(581, 111);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 35);
            this.button2.TabIndex = 43;
            this.button2.Text = "       Confirmar abono";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(65, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Puntos:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Electronica.Properties.Resources._001_binoculars;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(27, 346);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 35);
            this.button1.TabIndex = 42;
            this.button1.Text = "Ver Reporte";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RecepcionHistorial_vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.txttipo);
            this.Controls.Add(this.txtestado);
            this.Controls.Add(this.txtfechain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtmano);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.txtrefaccion);
            this.Controls.Add(this.txtaccesorios);
            this.Controls.Add(this.txtmarca);
            this.Controls.Add(this.txtfalla);
            this.Controls.Add(this.txtequipo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RecepcionHistorial_vista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Historial orden de servicio";
            this.Load += new System.EventHandler(this.Taller_actualizar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecepcionHistorial_vista2_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void RecepcionHistorial_vista2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Recepcion_Traslado_nuevo ss = new Recepcion_Traslado_nuevo(txtfolio.Text, txtidequipo.Text, txttipo.Text);
            ss.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea realizar reingreso por garantía?", "Confirmar reingreso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
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
                    string ubicacion = txtubicacion.Text;
                    string comentarios = txtcomentarios.Text;
                    int idfolio = Convert.ToInt32(txtfolio.Text);
                    string tabla = txttipo.Text;
                   //garantia tv
                    string query_actualizar_orden = "update  reparar_tv set estado='Pendiente', ubicacion='Recepcion' , servicio='Garantia' , id_personal='0',abono='0',mano_obra='0',presupuesto='0' where id_equipo='" + idequipo + "'";
                    MySqlCommand cmd_query_actualizar_orden = new MySqlCommand(query_actualizar_orden, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader leercomando = cmd_query_actualizar_orden.ExecuteReader();
                        conn.Close();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                //garantia smarthphone
                string query_actualizar_orden1 = "update  reparar_smartphones set estado='Pendiente', ubicacion='Recepcion' , servicio='Garantia' , id_personal='0' where id_equipo='" + idequipo + "'";
                MySqlCommand cmd_query_actualizar_orden1 = new MySqlCommand(query_actualizar_orden1, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leercomando = cmd_query_actualizar_orden1.ExecuteReader();
                    conn.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //garantia audio
                string query_actualizar_orden2 = "update  reparar_audio set estado='Pendiente', ubicacion='Recepcion' , servicio='Garantia' , id_personal='0' where id_equipo='" + idequipo + "'";
                MySqlCommand cmd_query_actualizar_orden2 = new MySqlCommand(query_actualizar_orden2, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leercomando = cmd_query_actualizar_orden2.ExecuteReader();
                    conn.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //garantia laptops
                string query_actualizar_orden3 = "update  reparar_laptops set estado='Pendiente', ubicacion='Recepcion' , servicio='Garantia' , id_personal='0' where id_equipo='" + idequipo + "'";
                MySqlCommand cmd_query_actualizar_orden3 = new MySqlCommand(query_actualizar_orden3, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leercomando = cmd_query_actualizar_orden3.ExecuteReader();
                    conn.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //garantia electrodomesticos
                string query_actualizar_orden4 = "update  reparar_electrodomesticos set estado='Pendiente', ubicacion='Recepcion' , servicio='Garantia' , id_personal='0' where id_equipo='" + idequipo + "'";
                MySqlCommand cmd_query_actualizar_orden4 = new MySqlCommand(query_actualizar_orden4, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leercomando = cmd_query_actualizar_orden4.ExecuteReader();
                    MessageBox.Show("Reingreso por garantía exitosamente");
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
}
