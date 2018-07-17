using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private Button button1;

		private Button btnaudio;

		private Button btnelectro;

		private Button btncel;

		private Button btntele;

		private Label label1;

		private Label label3;

		private Label label4;

		private Label label5;

		private TextBox txtpendientetv;

		private TextBox txtreparaciontv;

		private TextBox txtsoluciontv;

		private TextBox txtreparadotv;

		private TextBox txtreparadosmart;

		private TextBox txtsolucionsmart;

		private TextBox txtreparacionsmart;

		private TextBox txtpendientesmart;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private TextBox txtreparadohogar;

		private TextBox txtsolucionhogar;

		private TextBox txtreparacionhogar;

		private TextBox txtpendientehogar;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private TextBox txtreparadoaudio;

		private TextBox txtsolucionaudio;

		private TextBox txtreparacionaudio;

		private TextBox txtpendienteaudio;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private TextBox txtreparadolaptop;

		private TextBox txtsolucionlaptop;

		private TextBox txtreparacionlaptop;

		private TextBox txtpendientelaptop;

		private Label label18;

		private Label label19;

		private Label label20;

		private Label label21;

		private TextBox txtrevisadalaptop;

		private Label label22;

		private TextBox txtrevisadaaudio;

		private Label label23;

		private TextBox txtrevisadahogar;

		private Label label24;

		private TextBox txtrevisadasmart;

		private Label label25;

		private TextBox txtrevisadatv;
        private Label label26;

		public Taller()
		{
			InitializeComponent();
			string query_tv8 = "select count(estado) from reparar_tv where estado='Pendiente'";
			string query_tv7 = "select count(estado) from reparar_tv where estado='En reparacion'";
			string query_tv6 = "select count(estado) from reparar_tv where estado='Sin solucion'";
			string query_tv5 = "select count(estado) from reparar_tv where estado='Reparada'";
			string query_tv4 = "select count(estado) from reparar_tv where estado='Diagnosticada'";
			string query_cel8 = "select count(estado) from reparar_smartphones where estado='Pendiente'";
			string query_cel7 = "select count(estado) from reparar_smartphones where estado='En reparacion'";
			string query_cel6 = "select count(estado) from reparar_smartphones where estado='Sin solucion'";
			string query_cel5 = "select count(estado) from reparar_smartphones where estado='Reparada'";
			string query_cel4 = "select count(estado) from reparar_smartphones where estado='Diagnosticada'";
			string query_audio8 = "select count(estado) from reparar_audio where estado='Pendiente'";
			string query_audio7 = "select count(estado) from reparar_audio where estado='En reparacion'";
			string query_audio6 = "select count(estado) from reparar_audio where estado='Sin solucion'";
			string query_audio5 = "select count(estado) from reparar_audio where estado='Reparada'";
			string query_audio4 = "select count(estado) from reparar_audio where estado='Diagnosticada'";
			string query_laptop8 = "select count(estado) from reparar_laptops where estado='Pendiente'";
			string query_laptop7 = "select count(estado) from reparar_laptops where estado='En reparacion'";
			string query_laptop6 = "select count(estado) from reparar_laptops where estado='Sin solucion'";
			string query_laptop5 = "select count(estado) from reparar_laptops where estado='Reparada'";
			string query_laptop4 = "select count(estado) from reparar_laptops where estado='Diagnosticada'";
			string query_hogar8 = "select count(estado) from reparar_electrodomesticos where estado='Pendiente'";
			string query_hogar7 = "select count(estado) from reparar_electrodomesticos where estado='En reparacion'";
			string query_hogar6 = "select count(estado) from reparar_electrodomesticos where estado='Sin solucion'";
			string query_hogar5 = "select count(estado) from reparar_electrodomesticos where estado='Reparada'";
			string query_hogar4 = "select count(estado) from reparar_electrodomesticos where estado='Diagnosticada'";
			conn.Open();
			try
			{
				MySqlCommand cmd_query_tv8 = new MySqlCommand(query_tv8, conn);
				MySqlCommand cmd_query_tv7 = new MySqlCommand(query_tv7, conn);
				MySqlCommand cmd_query_tv6 = new MySqlCommand(query_tv6, conn);
				MySqlCommand cmd_query_tv5 = new MySqlCommand(query_tv5, conn);
				MySqlCommand cmd_query_tv4 = new MySqlCommand(query_tv4, conn);
				txtpendientetv.Text = cmd_query_tv8.ExecuteScalar().ToString();
				txtreparaciontv.Text = cmd_query_tv7.ExecuteScalar().ToString();
				txtsoluciontv.Text = cmd_query_tv6.ExecuteScalar().ToString();
				txtreparadotv.Text = cmd_query_tv5.ExecuteScalar().ToString();
				txtrevisadatv.Text = cmd_query_tv4.ExecuteScalar().ToString();
				MySqlCommand cmd_query_cel8 = new MySqlCommand(query_cel8, conn);
				MySqlCommand cmd_query_cel7 = new MySqlCommand(query_cel7, conn);
				MySqlCommand cmd_query_cel6 = new MySqlCommand(query_cel6, conn);
				MySqlCommand cmd_query_cel5 = new MySqlCommand(query_cel5, conn);
				MySqlCommand cmd_query_cel4 = new MySqlCommand(query_cel4, conn);
				txtpendientesmart.Text = cmd_query_cel8.ExecuteScalar().ToString();
				txtreparacionsmart.Text = cmd_query_cel7.ExecuteScalar().ToString();
				txtsolucionsmart.Text = cmd_query_cel6.ExecuteScalar().ToString();
				txtreparadosmart.Text = cmd_query_cel5.ExecuteScalar().ToString();
				txtrevisadasmart.Text = cmd_query_cel4.ExecuteScalar().ToString();
				MySqlCommand cmd_query_audio8 = new MySqlCommand(query_audio8, conn);
				MySqlCommand cmd_query_audio7 = new MySqlCommand(query_audio7, conn);
				MySqlCommand cmd_query_audio6 = new MySqlCommand(query_audio6, conn);
				MySqlCommand cmd_query_audio5 = new MySqlCommand(query_audio5, conn);
				MySqlCommand cmd_query_audio4 = new MySqlCommand(query_audio4, conn);
				txtpendienteaudio.Text = cmd_query_audio8.ExecuteScalar().ToString();
				txtreparacionaudio.Text = cmd_query_audio7.ExecuteScalar().ToString();
				txtsolucionaudio.Text = cmd_query_audio6.ExecuteScalar().ToString();
				txtreparadoaudio.Text = cmd_query_audio5.ExecuteScalar().ToString();
				txtrevisadaaudio.Text = cmd_query_audio4.ExecuteScalar().ToString();
				MySqlCommand cmd_query_laptop8 = new MySqlCommand(query_laptop8, conn);
				MySqlCommand cmd_query_laptop7 = new MySqlCommand(query_laptop7, conn);
				MySqlCommand cmd_query_laptop6 = new MySqlCommand(query_laptop6, conn);
				MySqlCommand cmd_query_laptop5 = new MySqlCommand(query_laptop5, conn);
				MySqlCommand cmd_query_laptop4 = new MySqlCommand(query_laptop4, conn);
				txtpendientelaptop.Text = cmd_query_laptop8.ExecuteScalar().ToString();
				txtreparacionlaptop.Text = cmd_query_laptop7.ExecuteScalar().ToString();
				txtsolucionlaptop.Text = cmd_query_laptop6.ExecuteScalar().ToString();
				txtreparadolaptop.Text = cmd_query_laptop5.ExecuteScalar().ToString();
				txtrevisadalaptop.Text = cmd_query_laptop4.ExecuteScalar().ToString();
				MySqlCommand cmd_query_hogar8 = new MySqlCommand(query_hogar8, conn);
				MySqlCommand cmd_query_hogar7 = new MySqlCommand(query_hogar7, conn);
				MySqlCommand cmd_query_hogar6 = new MySqlCommand(query_hogar6, conn);
				MySqlCommand cmd_query_hogar5 = new MySqlCommand(query_hogar5, conn);
				MySqlCommand cmd_query_hogar4 = new MySqlCommand(query_hogar4, conn);
				txtpendientehogar.Text = cmd_query_hogar8.ExecuteScalar().ToString();
				txtreparacionhogar.Text = cmd_query_hogar7.ExecuteScalar().ToString();
				txtsolucionhogar.Text = cmd_query_hogar6.ExecuteScalar().ToString();
				txtreparadohogar.Text = cmd_query_hogar5.ExecuteScalar().ToString();
				txtrevisadahogar.Text = cmd_query_hogar4.ExecuteScalar().ToString();
			}
			catch (Exception)
			{
				conn.Close();
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void Buscar()
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void Taller_Load(object sender, EventArgs e)
		{
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void btncel_Click(object sender, EventArgs e)
		{
			Taller_smart ss = new Taller_smart();
			ss.ShowDialog();
		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{
		}

		private void btnelectro_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos ss = new Taller_electrodomesticos();
			ss.ShowDialog();
		}

		private void btntele_Click(object sender, EventArgs e)
		{
			Taller_tv ss = new Taller_tv();
			ss.ShowDialog();
		}

		private void btnaudio_Click(object sender, EventArgs e)
		{
			Taller_audio ss = new Taller_audio();
			ss.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Taller_laptops ss = new Taller_laptops();
			ss.ShowDialog();
		}

		private void txtpendientetv_Click(object sender, EventArgs e)
		{
			Taller_tv_pendientes ss = new Taller_tv_pendientes();
			ss.ShowDialog();
		}

		private void txtreparaciontv_Click(object sender, EventArgs e)
		{
			Taller_tv_reparacion ss = new Taller_tv_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadatv_Click(object sender, EventArgs e)
		{
			Taller_tv_diagnosticada ss = new Taller_tv_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsoluciontv_Click(object sender, EventArgs e)
		{
			Taller_tv_solucion ss = new Taller_tv_solucion();
			ss.ShowDialog();
		}

		private void txtreparadotv_Click(object sender, EventArgs e)
		{
			Taller_tv_reparada ss = new Taller_tv_reparada();
			ss.ShowDialog();
		}

		private void txtpendientesmart_Click(object sender, EventArgs e)
		{
			Taller_smart_pendiente ss = new Taller_smart_pendiente();
			ss.ShowDialog();
		}

		private void txtreparacionsmart_Click(object sender, EventArgs e)
		{
			Taller_smart_reparacion ss = new Taller_smart_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadasmart_Click(object sender, EventArgs e)
		{
			Taller_smart_diagnosticada ss = new Taller_smart_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsolucionsmart_Click(object sender, EventArgs e)
		{
			Taller_smart_solucion ss = new Taller_smart_solucion();
			ss.ShowDialog();
		}

		private void txtreparadosmart_Click(object sender, EventArgs e)
		{
			Taller_smart_reparada ss = new Taller_smart_reparada();
			ss.ShowDialog();
		}

		private void txtpendientehogar_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_pendiente ss = new Taller_electrodomesticos_pendiente();
			ss.ShowDialog();
		}

		private void txtreparacionhogar_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_reparacion ss = new Taller_electrodomesticos_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadahogar_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_diagnosticada ss = new Taller_electrodomesticos_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsolucionhogar_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_solucion ss = new Taller_electrodomesticos_solucion();
			ss.ShowDialog();
		}

		private void txtreparadohogar_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_reparada ss = new Taller_electrodomesticos_reparada();
			ss.ShowDialog();
		}

		private void txtpendienteaudio_Click(object sender, EventArgs e)
		{
			Taller_audio_pendiente ss = new Taller_audio_pendiente();
			ss.ShowDialog();
		}

		private void txtreparacionaudio_Click(object sender, EventArgs e)
		{
			Taller_audio_reparacion ss = new Taller_audio_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadaaudio_Click(object sender, EventArgs e)
		{
			Taller_audio_diagnosticada ss = new Taller_audio_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsolucionaudio_Click(object sender, EventArgs e)
		{
			Taller_audio_solucion ss = new Taller_audio_solucion();
			ss.ShowDialog();
		}

		private void txtreparadoaudio_Click(object sender, EventArgs e)
		{
			Taller_audio_reparada ss = new Taller_audio_reparada();
			ss.ShowDialog();
		}

		private void txtpendientelaptop_Click(object sender, EventArgs e)
		{
			Taller_laptops_pendiente ss = new Taller_laptops_pendiente();
			ss.ShowDialog();
		}

		private void txtreparacionlaptop_Click(object sender, EventArgs e)
		{
			Taller_laptops_reparacion ss = new Taller_laptops_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadalaptop_Click(object sender, EventArgs e)
		{
			Taller_laptops_diagnosticada ss = new Taller_laptops_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsolucionlaptop_Click(object sender, EventArgs e)
		{
			Taller_laptops_solucion ss = new Taller_laptops_solucion();
			ss.ShowDialog();
		}

		private void txtreparadolaptop_Click(object sender, EventArgs e)
		{
			Taller_laptops_reparada ss = new Taller_laptops_reparada();
			ss.ShowDialog();
		}

		private void txtpendientesmart_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtreparaciontv_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtsoluciontv_TextChanged(object sender, EventArgs e)
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpendientetv = new System.Windows.Forms.TextBox();
            this.txtreparaciontv = new System.Windows.Forms.TextBox();
            this.txtsoluciontv = new System.Windows.Forms.TextBox();
            this.txtreparadotv = new System.Windows.Forms.TextBox();
            this.txtreparadosmart = new System.Windows.Forms.TextBox();
            this.txtsolucionsmart = new System.Windows.Forms.TextBox();
            this.txtreparacionsmart = new System.Windows.Forms.TextBox();
            this.txtpendientesmart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtreparadohogar = new System.Windows.Forms.TextBox();
            this.txtsolucionhogar = new System.Windows.Forms.TextBox();
            this.txtreparacionhogar = new System.Windows.Forms.TextBox();
            this.txtpendientehogar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtreparadoaudio = new System.Windows.Forms.TextBox();
            this.txtsolucionaudio = new System.Windows.Forms.TextBox();
            this.txtreparacionaudio = new System.Windows.Forms.TextBox();
            this.txtpendienteaudio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtreparadolaptop = new System.Windows.Forms.TextBox();
            this.txtsolucionlaptop = new System.Windows.Forms.TextBox();
            this.txtreparacionlaptop = new System.Windows.Forms.TextBox();
            this.txtpendientelaptop = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtrevisadalaptop = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtrevisadaaudio = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtrevisadahogar = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtrevisadasmart = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtrevisadatv = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnaudio = new System.Windows.Forms.Button();
            this.btnelectro = new System.Windows.Forms.Button();
            this.btncel = new System.Windows.Forms.Button();
            this.btntele = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Control de equipos para reparar en taller";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "En reparacion:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Pendientes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(702, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Sin Solución:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(853, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Reparado:";
            // 
            // txtpendientetv
            // 
            this.txtpendientetv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendientetv.Location = new System.Drawing.Point(326, 113);
            this.txtpendientetv.Name = "txtpendientetv";
            this.txtpendientetv.ReadOnly = true;
            this.txtpendientetv.Size = new System.Drawing.Size(48, 26);
            this.txtpendientetv.TabIndex = 38;
            this.txtpendientetv.Click += new System.EventHandler(this.txtpendientetv_Click);
            this.txtpendientetv.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txtreparaciontv
            // 
            this.txtreparaciontv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparaciontv.Location = new System.Drawing.Point(488, 113);
            this.txtreparaciontv.Name = "txtreparaciontv";
            this.txtreparaciontv.ReadOnly = true;
            this.txtreparaciontv.Size = new System.Drawing.Size(48, 26);
            this.txtreparaciontv.TabIndex = 39;
            this.txtreparaciontv.Click += new System.EventHandler(this.txtreparaciontv_Click);
            this.txtreparaciontv.TextChanged += new System.EventHandler(this.txtreparaciontv_TextChanged);
            // 
            // txtsoluciontv
            // 
            this.txtsoluciontv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluciontv.Location = new System.Drawing.Point(799, 110);
            this.txtsoluciontv.Name = "txtsoluciontv";
            this.txtsoluciontv.ReadOnly = true;
            this.txtsoluciontv.Size = new System.Drawing.Size(48, 26);
            this.txtsoluciontv.TabIndex = 40;
            this.txtsoluciontv.Click += new System.EventHandler(this.txtsoluciontv_Click);
            this.txtsoluciontv.TextChanged += new System.EventHandler(this.txtsoluciontv_TextChanged);
            // 
            // txtreparadotv
            // 
            this.txtreparadotv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadotv.Location = new System.Drawing.Point(933, 110);
            this.txtreparadotv.Name = "txtreparadotv";
            this.txtreparadotv.ReadOnly = true;
            this.txtreparadotv.Size = new System.Drawing.Size(48, 26);
            this.txtreparadotv.TabIndex = 41;
            this.txtreparadotv.Click += new System.EventHandler(this.txtreparadotv_Click);
            // 
            // txtreparadosmart
            // 
            this.txtreparadosmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadosmart.Location = new System.Drawing.Point(930, 206);
            this.txtreparadosmart.Name = "txtreparadosmart";
            this.txtreparadosmart.ReadOnly = true;
            this.txtreparadosmart.Size = new System.Drawing.Size(48, 26);
            this.txtreparadosmart.TabIndex = 49;
            this.txtreparadosmart.Click += new System.EventHandler(this.txtreparadosmart_Click);
            // 
            // txtsolucionsmart
            // 
            this.txtsolucionsmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolucionsmart.Location = new System.Drawing.Point(796, 206);
            this.txtsolucionsmart.Name = "txtsolucionsmart";
            this.txtsolucionsmart.ReadOnly = true;
            this.txtsolucionsmart.Size = new System.Drawing.Size(48, 26);
            this.txtsolucionsmart.TabIndex = 48;
            this.txtsolucionsmart.Click += new System.EventHandler(this.txtsolucionsmart_Click);
            // 
            // txtreparacionsmart
            // 
            this.txtreparacionsmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparacionsmart.Location = new System.Drawing.Point(485, 209);
            this.txtreparacionsmart.Name = "txtreparacionsmart";
            this.txtreparacionsmart.ReadOnly = true;
            this.txtreparacionsmart.Size = new System.Drawing.Size(48, 26);
            this.txtreparacionsmart.TabIndex = 47;
            this.txtreparacionsmart.Click += new System.EventHandler(this.txtreparacionsmart_Click);
            // 
            // txtpendientesmart
            // 
            this.txtpendientesmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendientesmart.Location = new System.Drawing.Point(323, 209);
            this.txtpendientesmart.Name = "txtpendientesmart";
            this.txtpendientesmart.ReadOnly = true;
            this.txtpendientesmart.Size = new System.Drawing.Size(48, 26);
            this.txtpendientesmart.TabIndex = 46;
            this.txtpendientesmart.Click += new System.EventHandler(this.txtpendientesmart_Click);
            this.txtpendientesmart.TextChanged += new System.EventHandler(this.txtpendientesmart_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(699, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Sin Solución:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(850, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "Reparado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(234, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Pendientes:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(377, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "En reparacion:";
            // 
            // txtreparadohogar
            // 
            this.txtreparadohogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadohogar.Location = new System.Drawing.Point(930, 473);
            this.txtreparadohogar.Name = "txtreparadohogar";
            this.txtreparadohogar.ReadOnly = true;
            this.txtreparadohogar.Size = new System.Drawing.Size(48, 26);
            this.txtreparadohogar.TabIndex = 57;
            this.txtreparadohogar.Click += new System.EventHandler(this.txtreparadohogar_Click);
            // 
            // txtsolucionhogar
            // 
            this.txtsolucionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolucionhogar.Location = new System.Drawing.Point(796, 473);
            this.txtsolucionhogar.Name = "txtsolucionhogar";
            this.txtsolucionhogar.ReadOnly = true;
            this.txtsolucionhogar.Size = new System.Drawing.Size(48, 26);
            this.txtsolucionhogar.TabIndex = 56;
            this.txtsolucionhogar.Click += new System.EventHandler(this.txtsolucionhogar_Click);
            // 
            // txtreparacionhogar
            // 
            this.txtreparacionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparacionhogar.Location = new System.Drawing.Point(485, 476);
            this.txtreparacionhogar.Name = "txtreparacionhogar";
            this.txtreparacionhogar.ReadOnly = true;
            this.txtreparacionhogar.Size = new System.Drawing.Size(48, 26);
            this.txtreparacionhogar.TabIndex = 55;
            this.txtreparacionhogar.Click += new System.EventHandler(this.txtreparacionhogar_Click);
            // 
            // txtpendientehogar
            // 
            this.txtpendientehogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendientehogar.Location = new System.Drawing.Point(323, 476);
            this.txtpendientehogar.Name = "txtpendientehogar";
            this.txtpendientehogar.ReadOnly = true;
            this.txtpendientehogar.Size = new System.Drawing.Size(48, 26);
            this.txtpendientehogar.TabIndex = 54;
            this.txtpendientehogar.Click += new System.EventHandler(this.txtpendientehogar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(699, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Sin Solución:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(850, 477);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "Reparado:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(234, 479);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Pendientes:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(377, 479);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 50;
            this.label13.Text = "En reparacion:";
            // 
            // txtreparadoaudio
            // 
            this.txtreparadoaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadoaudio.Location = new System.Drawing.Point(930, 300);
            this.txtreparadoaudio.Name = "txtreparadoaudio";
            this.txtreparadoaudio.ReadOnly = true;
            this.txtreparadoaudio.Size = new System.Drawing.Size(48, 26);
            this.txtreparadoaudio.TabIndex = 65;
            this.txtreparadoaudio.Click += new System.EventHandler(this.txtreparadoaudio_Click);
            // 
            // txtsolucionaudio
            // 
            this.txtsolucionaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolucionaudio.Location = new System.Drawing.Point(796, 300);
            this.txtsolucionaudio.Name = "txtsolucionaudio";
            this.txtsolucionaudio.ReadOnly = true;
            this.txtsolucionaudio.Size = new System.Drawing.Size(48, 26);
            this.txtsolucionaudio.TabIndex = 64;
            this.txtsolucionaudio.Click += new System.EventHandler(this.txtsolucionaudio_Click);
            // 
            // txtreparacionaudio
            // 
            this.txtreparacionaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparacionaudio.Location = new System.Drawing.Point(485, 303);
            this.txtreparacionaudio.Name = "txtreparacionaudio";
            this.txtreparacionaudio.ReadOnly = true;
            this.txtreparacionaudio.Size = new System.Drawing.Size(48, 26);
            this.txtreparacionaudio.TabIndex = 63;
            this.txtreparacionaudio.Click += new System.EventHandler(this.txtreparacionaudio_Click);
            // 
            // txtpendienteaudio
            // 
            this.txtpendienteaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendienteaudio.Location = new System.Drawing.Point(323, 303);
            this.txtpendienteaudio.Name = "txtpendienteaudio";
            this.txtpendienteaudio.ReadOnly = true;
            this.txtpendienteaudio.Size = new System.Drawing.Size(48, 26);
            this.txtpendienteaudio.TabIndex = 62;
            this.txtpendienteaudio.Click += new System.EventHandler(this.txtpendienteaudio_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(699, 304);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 20);
            this.label14.TabIndex = 61;
            this.label14.Text = "Sin Solución:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(850, 304);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 20);
            this.label15.TabIndex = 60;
            this.label15.Text = "Reparado:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(234, 306);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 20);
            this.label16.TabIndex = 59;
            this.label16.Text = "Pendientes:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(377, 306);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 20);
            this.label17.TabIndex = 58;
            this.label17.Text = "En reparacion:";
            // 
            // txtreparadolaptop
            // 
            this.txtreparadolaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadolaptop.Location = new System.Drawing.Point(930, 386);
            this.txtreparadolaptop.Name = "txtreparadolaptop";
            this.txtreparadolaptop.ReadOnly = true;
            this.txtreparadolaptop.Size = new System.Drawing.Size(48, 26);
            this.txtreparadolaptop.TabIndex = 73;
            this.txtreparadolaptop.Click += new System.EventHandler(this.txtreparadolaptop_Click);
            // 
            // txtsolucionlaptop
            // 
            this.txtsolucionlaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolucionlaptop.Location = new System.Drawing.Point(796, 386);
            this.txtsolucionlaptop.Name = "txtsolucionlaptop";
            this.txtsolucionlaptop.ReadOnly = true;
            this.txtsolucionlaptop.Size = new System.Drawing.Size(48, 26);
            this.txtsolucionlaptop.TabIndex = 72;
            this.txtsolucionlaptop.Click += new System.EventHandler(this.txtsolucionlaptop_Click);
            // 
            // txtreparacionlaptop
            // 
            this.txtreparacionlaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparacionlaptop.Location = new System.Drawing.Point(485, 389);
            this.txtreparacionlaptop.Name = "txtreparacionlaptop";
            this.txtreparacionlaptop.ReadOnly = true;
            this.txtreparacionlaptop.Size = new System.Drawing.Size(48, 26);
            this.txtreparacionlaptop.TabIndex = 71;
            this.txtreparacionlaptop.Click += new System.EventHandler(this.txtreparacionlaptop_Click);
            // 
            // txtpendientelaptop
            // 
            this.txtpendientelaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendientelaptop.Location = new System.Drawing.Point(323, 389);
            this.txtpendientelaptop.Name = "txtpendientelaptop";
            this.txtpendientelaptop.ReadOnly = true;
            this.txtpendientelaptop.Size = new System.Drawing.Size(48, 26);
            this.txtpendientelaptop.TabIndex = 70;
            this.txtpendientelaptop.Click += new System.EventHandler(this.txtpendientelaptop_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(699, 390);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 20);
            this.label18.TabIndex = 69;
            this.label18.Text = "Sin Solución:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(850, 390);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 20);
            this.label19.TabIndex = 68;
            this.label19.Text = "Reparado:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(234, 392);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 20);
            this.label20.TabIndex = 67;
            this.label20.Text = "Pendientes:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(377, 392);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 20);
            this.label21.TabIndex = 66;
            this.label21.Text = "En reparacion:";
            // 
            // txtrevisadalaptop
            // 
            this.txtrevisadalaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadalaptop.Location = new System.Drawing.Point(632, 389);
            this.txtrevisadalaptop.Name = "txtrevisadalaptop";
            this.txtrevisadalaptop.ReadOnly = true;
            this.txtrevisadalaptop.Size = new System.Drawing.Size(48, 26);
            this.txtrevisadalaptop.TabIndex = 83;
            this.txtrevisadalaptop.Click += new System.EventHandler(this.txtrevisadalaptop_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(550, 393);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 20);
            this.label22.TabIndex = 82;
            this.label22.Text = "Revisadas:";
            // 
            // txtrevisadaaudio
            // 
            this.txtrevisadaaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadaaudio.Location = new System.Drawing.Point(632, 303);
            this.txtrevisadaaudio.Name = "txtrevisadaaudio";
            this.txtrevisadaaudio.ReadOnly = true;
            this.txtrevisadaaudio.Size = new System.Drawing.Size(48, 26);
            this.txtrevisadaaudio.TabIndex = 81;
            this.txtrevisadaaudio.Click += new System.EventHandler(this.txtrevisadaaudio_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(550, 307);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 20);
            this.label23.TabIndex = 80;
            this.label23.Text = "Revisadas:";
            // 
            // txtrevisadahogar
            // 
            this.txtrevisadahogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadahogar.Location = new System.Drawing.Point(632, 476);
            this.txtrevisadahogar.Name = "txtrevisadahogar";
            this.txtrevisadahogar.ReadOnly = true;
            this.txtrevisadahogar.Size = new System.Drawing.Size(48, 26);
            this.txtrevisadahogar.TabIndex = 79;
            this.txtrevisadahogar.Click += new System.EventHandler(this.txtrevisadahogar_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(550, 480);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 20);
            this.label24.TabIndex = 78;
            this.label24.Text = "Revisadas:";
            // 
            // txtrevisadasmart
            // 
            this.txtrevisadasmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadasmart.Location = new System.Drawing.Point(632, 209);
            this.txtrevisadasmart.Name = "txtrevisadasmart";
            this.txtrevisadasmart.ReadOnly = true;
            this.txtrevisadasmart.Size = new System.Drawing.Size(48, 26);
            this.txtrevisadasmart.TabIndex = 77;
            this.txtrevisadasmart.Click += new System.EventHandler(this.txtrevisadasmart_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(550, 213);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(87, 20);
            this.label25.TabIndex = 76;
            this.label25.Text = "Revisadas:";
            // 
            // txtrevisadatv
            // 
            this.txtrevisadatv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadatv.Location = new System.Drawing.Point(635, 113);
            this.txtrevisadatv.Name = "txtrevisadatv";
            this.txtrevisadatv.ReadOnly = true;
            this.txtrevisadatv.Size = new System.Drawing.Size(48, 26);
            this.txtrevisadatv.TabIndex = 75;
            this.txtrevisadatv.Click += new System.EventHandler(this.txtrevisadatv_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(553, 117);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 20);
            this.label26.TabIndex = 74;
            this.label26.Text = "Revisadas:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Electronica.Properties.Resources._002_laptop1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(71, 382);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 40);
            this.button1.TabIndex = 33;
            this.button1.Text = "     Laptop/Cpu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnaudio
            // 
            this.btnaudio.FlatAppearance.BorderSize = 0;
            this.btnaudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnaudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaudio.Image = global::Electronica.Properties.Resources._003_big_music_player_speaker;
            this.btnaudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaudio.Location = new System.Drawing.Point(71, 297);
            this.btnaudio.Margin = new System.Windows.Forms.Padding(2);
            this.btnaudio.Name = "btnaudio";
            this.btnaudio.Size = new System.Drawing.Size(145, 40);
            this.btnaudio.TabIndex = 32;
            this.btnaudio.Text = "      Audio/Sonido";
            this.btnaudio.UseVisualStyleBackColor = true;
            this.btnaudio.Click += new System.EventHandler(this.btnaudio_Click);
            // 
            // btnelectro
            // 
            this.btnelectro.FlatAppearance.BorderSize = 0;
            this.btnelectro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnelectro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnelectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnelectro.Image = global::Electronica.Properties.Resources._001_washing_machine;
            this.btnelectro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnelectro.Location = new System.Drawing.Point(71, 469);
            this.btnelectro.Margin = new System.Windows.Forms.Padding(2);
            this.btnelectro.Name = "btnelectro";
            this.btnelectro.Size = new System.Drawing.Size(142, 40);
            this.btnelectro.TabIndex = 31;
            this.btnelectro.Text = "      Linea Blanca";
            this.btnelectro.UseVisualStyleBackColor = true;
            this.btnelectro.Click += new System.EventHandler(this.btnelectro_Click);
            // 
            // btncel
            // 
            this.btncel.FlatAppearance.BorderSize = 0;
            this.btncel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btncel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncel.Image = global::Electronica.Properties.Resources._004_smartphone_call;
            this.btncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncel.Location = new System.Drawing.Point(71, 200);
            this.btncel.Margin = new System.Windows.Forms.Padding(2);
            this.btncel.Name = "btncel";
            this.btncel.Size = new System.Drawing.Size(145, 40);
            this.btncel.TabIndex = 30;
            this.btncel.Text = "     Celular / Tablet";
            this.btncel.UseVisualStyleBackColor = true;
            this.btncel.Click += new System.EventHandler(this.btncel_Click);
            // 
            // btntele
            // 
            this.btntele.FlatAppearance.BorderSize = 0;
            this.btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntele.Image = global::Electronica.Properties.Resources._005_computer_screen;
            this.btntele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntele.Location = new System.Drawing.Point(71, 104);
            this.btntele.Margin = new System.Windows.Forms.Padding(2);
            this.btntele.Name = "btntele";
            this.btntele.Size = new System.Drawing.Size(145, 40);
            this.btntele.TabIndex = 29;
            this.btntele.Text = "        Televisiones";
            this.btntele.UseVisualStyleBackColor = true;
            this.btntele.Click += new System.EventHandler(this.btntele_Click);
            // 
            // Taller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1059, 574);
            this.Controls.Add(this.txtrevisadalaptop);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtrevisadaaudio);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtrevisadahogar);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtrevisadasmart);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtrevisadatv);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtreparadolaptop);
            this.Controls.Add(this.txtsolucionlaptop);
            this.Controls.Add(this.txtreparacionlaptop);
            this.Controls.Add(this.txtpendientelaptop);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtreparadoaudio);
            this.Controls.Add(this.txtsolucionaudio);
            this.Controls.Add(this.txtreparacionaudio);
            this.Controls.Add(this.txtpendienteaudio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtreparadohogar);
            this.Controls.Add(this.txtsolucionhogar);
            this.Controls.Add(this.txtreparacionhogar);
            this.Controls.Add(this.txtpendientehogar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtreparadosmart);
            this.Controls.Add(this.txtsolucionsmart);
            this.Controls.Add(this.txtreparacionsmart);
            this.Controls.Add(this.txtpendientesmart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtreparadotv);
            this.Controls.Add(this.txtsoluciontv);
            this.Controls.Add(this.txtreparaciontv);
            this.Controls.Add(this.txtpendientetv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnaudio);
            this.Controls.Add(this.btnelectro);
            this.Controls.Add(this.btncel);
            this.Controls.Add(this.btntele);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Taller";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Taller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
