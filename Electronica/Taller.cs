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
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txtpendientetv = new System.Windows.Forms.TextBox();
			txtreparaciontv = new System.Windows.Forms.TextBox();
			txtsoluciontv = new System.Windows.Forms.TextBox();
			txtreparadotv = new System.Windows.Forms.TextBox();
			txtreparadosmart = new System.Windows.Forms.TextBox();
			txtsolucionsmart = new System.Windows.Forms.TextBox();
			txtreparacionsmart = new System.Windows.Forms.TextBox();
			txtpendientesmart = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtreparadohogar = new System.Windows.Forms.TextBox();
			txtsolucionhogar = new System.Windows.Forms.TextBox();
			txtreparacionhogar = new System.Windows.Forms.TextBox();
			txtpendientehogar = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			txtreparadoaudio = new System.Windows.Forms.TextBox();
			txtsolucionaudio = new System.Windows.Forms.TextBox();
			txtreparacionaudio = new System.Windows.Forms.TextBox();
			txtpendienteaudio = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			txtreparadolaptop = new System.Windows.Forms.TextBox();
			txtsolucionlaptop = new System.Windows.Forms.TextBox();
			txtreparacionlaptop = new System.Windows.Forms.TextBox();
			txtpendientelaptop = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			txtrevisadalaptop = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			txtrevisadaaudio = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			txtrevisadahogar = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			txtrevisadasmart = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			txtrevisadatv = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			btnaudio = new System.Windows.Forms.Button();
			btnelectro = new System.Windows.Forms.Button();
			btncel = new System.Windows.Forms.Button();
			btntele = new System.Windows.Forms.Button();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(389, 24);
			label2.TabIndex = 2;
			label2.Text = "Control de equipos para reparar en taller";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(371, 117);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(112, 20);
			label1.TabIndex = 34;
			label1.Text = "En reparacion:";
			label1.Click += new System.EventHandler(label1_Click);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(228, 117);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(93, 20);
			label3.TabIndex = 35;
			label3.Text = "Pendientes:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(693, 115);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(101, 20);
			label4.TabIndex = 37;
			label4.Text = "Sin Solución:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(844, 115);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(84, 20);
			label5.TabIndex = 36;
			label5.Text = "Reparado:";
			txtpendientetv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendientetv.Location = new System.Drawing.Point(317, 114);
			txtpendientetv.Name = "txtpendientetv";
			txtpendientetv.ReadOnly = true;
			txtpendientetv.Size = new System.Drawing.Size(48, 26);
			txtpendientetv.TabIndex = 38;
			txtpendientetv.Click += new System.EventHandler(txtpendientetv_Click);
			txtpendientetv.TextChanged += new System.EventHandler(textBox1_TextChanged_1);
			txtreparaciontv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparaciontv.Location = new System.Drawing.Point(479, 114);
			txtreparaciontv.Name = "txtreparaciontv";
			txtreparaciontv.ReadOnly = true;
			txtreparaciontv.Size = new System.Drawing.Size(48, 26);
			txtreparaciontv.TabIndex = 39;
			txtreparaciontv.Click += new System.EventHandler(txtreparaciontv_Click);
			txtreparaciontv.TextChanged += new System.EventHandler(txtreparaciontv_TextChanged);
			txtsoluciontv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsoluciontv.Location = new System.Drawing.Point(790, 111);
			txtsoluciontv.Name = "txtsoluciontv";
			txtsoluciontv.ReadOnly = true;
			txtsoluciontv.Size = new System.Drawing.Size(48, 26);
			txtsoluciontv.TabIndex = 40;
			txtsoluciontv.Click += new System.EventHandler(txtsoluciontv_Click);
			txtsoluciontv.TextChanged += new System.EventHandler(txtsoluciontv_TextChanged);
			txtreparadotv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparadotv.Location = new System.Drawing.Point(924, 111);
			txtreparadotv.Name = "txtreparadotv";
			txtreparadotv.ReadOnly = true;
			txtreparadotv.Size = new System.Drawing.Size(48, 26);
			txtreparadotv.TabIndex = 41;
			txtreparadotv.Click += new System.EventHandler(txtreparadotv_Click);
			txtreparadosmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparadosmart.Location = new System.Drawing.Point(921, 207);
			txtreparadosmart.Name = "txtreparadosmart";
			txtreparadosmart.ReadOnly = true;
			txtreparadosmart.Size = new System.Drawing.Size(48, 26);
			txtreparadosmart.TabIndex = 49;
			txtreparadosmart.Click += new System.EventHandler(txtreparadosmart_Click);
			txtsolucionsmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolucionsmart.Location = new System.Drawing.Point(787, 207);
			txtsolucionsmart.Name = "txtsolucionsmart";
			txtsolucionsmart.ReadOnly = true;
			txtsolucionsmart.Size = new System.Drawing.Size(48, 26);
			txtsolucionsmart.TabIndex = 48;
			txtsolucionsmart.Click += new System.EventHandler(txtsolucionsmart_Click);
			txtreparacionsmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparacionsmart.Location = new System.Drawing.Point(476, 210);
			txtreparacionsmart.Name = "txtreparacionsmart";
			txtreparacionsmart.ReadOnly = true;
			txtreparacionsmart.Size = new System.Drawing.Size(48, 26);
			txtreparacionsmart.TabIndex = 47;
			txtreparacionsmart.Click += new System.EventHandler(txtreparacionsmart_Click);
			txtpendientesmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendientesmart.Location = new System.Drawing.Point(314, 210);
			txtpendientesmart.Name = "txtpendientesmart";
			txtpendientesmart.ReadOnly = true;
			txtpendientesmart.Size = new System.Drawing.Size(48, 26);
			txtpendientesmart.TabIndex = 46;
			txtpendientesmart.Click += new System.EventHandler(txtpendientesmart_Click);
			txtpendientesmart.TextChanged += new System.EventHandler(txtpendientesmart_TextChanged);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(690, 211);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(101, 20);
			label6.TabIndex = 45;
			label6.Text = "Sin Solución:";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(841, 211);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(84, 20);
			label7.TabIndex = 44;
			label7.Text = "Reparado:";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(225, 213);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(93, 20);
			label8.TabIndex = 43;
			label8.Text = "Pendientes:";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(368, 213);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(112, 20);
			label9.TabIndex = 42;
			label9.Text = "En reparacion:";
			txtreparadohogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparadohogar.Location = new System.Drawing.Point(921, 474);
			txtreparadohogar.Name = "txtreparadohogar";
			txtreparadohogar.ReadOnly = true;
			txtreparadohogar.Size = new System.Drawing.Size(48, 26);
			txtreparadohogar.TabIndex = 57;
			txtreparadohogar.Click += new System.EventHandler(txtreparadohogar_Click);
			txtsolucionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolucionhogar.Location = new System.Drawing.Point(787, 474);
			txtsolucionhogar.Name = "txtsolucionhogar";
			txtsolucionhogar.ReadOnly = true;
			txtsolucionhogar.Size = new System.Drawing.Size(48, 26);
			txtsolucionhogar.TabIndex = 56;
			txtsolucionhogar.Click += new System.EventHandler(txtsolucionhogar_Click);
			txtreparacionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparacionhogar.Location = new System.Drawing.Point(476, 477);
			txtreparacionhogar.Name = "txtreparacionhogar";
			txtreparacionhogar.ReadOnly = true;
			txtreparacionhogar.Size = new System.Drawing.Size(48, 26);
			txtreparacionhogar.TabIndex = 55;
			txtreparacionhogar.Click += new System.EventHandler(txtreparacionhogar_Click);
			txtpendientehogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendientehogar.Location = new System.Drawing.Point(314, 477);
			txtpendientehogar.Name = "txtpendientehogar";
			txtpendientehogar.ReadOnly = true;
			txtpendientehogar.Size = new System.Drawing.Size(48, 26);
			txtpendientehogar.TabIndex = 54;
			txtpendientehogar.Click += new System.EventHandler(txtpendientehogar_Click);
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(690, 478);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(101, 20);
			label10.TabIndex = 53;
			label10.Text = "Sin Solución:";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(841, 478);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(84, 20);
			label11.TabIndex = 52;
			label11.Text = "Reparado:";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(225, 480);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(93, 20);
			label12.TabIndex = 51;
			label12.Text = "Pendientes:";
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(368, 480);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(112, 20);
			label13.TabIndex = 50;
			label13.Text = "En reparacion:";
			txtreparadoaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparadoaudio.Location = new System.Drawing.Point(921, 301);
			txtreparadoaudio.Name = "txtreparadoaudio";
			txtreparadoaudio.ReadOnly = true;
			txtreparadoaudio.Size = new System.Drawing.Size(48, 26);
			txtreparadoaudio.TabIndex = 65;
			txtreparadoaudio.Click += new System.EventHandler(txtreparadoaudio_Click);
			txtsolucionaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolucionaudio.Location = new System.Drawing.Point(787, 301);
			txtsolucionaudio.Name = "txtsolucionaudio";
			txtsolucionaudio.ReadOnly = true;
			txtsolucionaudio.Size = new System.Drawing.Size(48, 26);
			txtsolucionaudio.TabIndex = 64;
			txtsolucionaudio.Click += new System.EventHandler(txtsolucionaudio_Click);
			txtreparacionaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparacionaudio.Location = new System.Drawing.Point(476, 304);
			txtreparacionaudio.Name = "txtreparacionaudio";
			txtreparacionaudio.ReadOnly = true;
			txtreparacionaudio.Size = new System.Drawing.Size(48, 26);
			txtreparacionaudio.TabIndex = 63;
			txtreparacionaudio.Click += new System.EventHandler(txtreparacionaudio_Click);
			txtpendienteaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendienteaudio.Location = new System.Drawing.Point(314, 304);
			txtpendienteaudio.Name = "txtpendienteaudio";
			txtpendienteaudio.ReadOnly = true;
			txtpendienteaudio.Size = new System.Drawing.Size(48, 26);
			txtpendienteaudio.TabIndex = 62;
			txtpendienteaudio.Click += new System.EventHandler(txtpendienteaudio_Click);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(690, 305);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(101, 20);
			label14.TabIndex = 61;
			label14.Text = "Sin Solución:";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(841, 305);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(84, 20);
			label15.TabIndex = 60;
			label15.Text = "Reparado:";
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(225, 307);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(93, 20);
			label16.TabIndex = 59;
			label16.Text = "Pendientes:";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label17.Location = new System.Drawing.Point(368, 307);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(112, 20);
			label17.TabIndex = 58;
			label17.Text = "En reparacion:";
			txtreparadolaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparadolaptop.Location = new System.Drawing.Point(921, 387);
			txtreparadolaptop.Name = "txtreparadolaptop";
			txtreparadolaptop.ReadOnly = true;
			txtreparadolaptop.Size = new System.Drawing.Size(48, 26);
			txtreparadolaptop.TabIndex = 73;
			txtreparadolaptop.Click += new System.EventHandler(txtreparadolaptop_Click);
			txtsolucionlaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolucionlaptop.Location = new System.Drawing.Point(787, 387);
			txtsolucionlaptop.Name = "txtsolucionlaptop";
			txtsolucionlaptop.ReadOnly = true;
			txtsolucionlaptop.Size = new System.Drawing.Size(48, 26);
			txtsolucionlaptop.TabIndex = 72;
			txtsolucionlaptop.Click += new System.EventHandler(txtsolucionlaptop_Click);
			txtreparacionlaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparacionlaptop.Location = new System.Drawing.Point(476, 390);
			txtreparacionlaptop.Name = "txtreparacionlaptop";
			txtreparacionlaptop.ReadOnly = true;
			txtreparacionlaptop.Size = new System.Drawing.Size(48, 26);
			txtreparacionlaptop.TabIndex = 71;
			txtreparacionlaptop.Click += new System.EventHandler(txtreparacionlaptop_Click);
			txtpendientelaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendientelaptop.Location = new System.Drawing.Point(314, 390);
			txtpendientelaptop.Name = "txtpendientelaptop";
			txtpendientelaptop.ReadOnly = true;
			txtpendientelaptop.Size = new System.Drawing.Size(48, 26);
			txtpendientelaptop.TabIndex = 70;
			txtpendientelaptop.Click += new System.EventHandler(txtpendientelaptop_Click);
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(690, 391);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(101, 20);
			label18.TabIndex = 69;
			label18.Text = "Sin Solución:";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(841, 391);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(84, 20);
			label19.TabIndex = 68;
			label19.Text = "Reparado:";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(225, 393);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(93, 20);
			label20.TabIndex = 67;
			label20.Text = "Pendientes:";
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(368, 393);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(112, 20);
			label21.TabIndex = 66;
			label21.Text = "En reparacion:";
			txtrevisadalaptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtrevisadalaptop.Location = new System.Drawing.Point(623, 390);
			txtrevisadalaptop.Name = "txtrevisadalaptop";
			txtrevisadalaptop.ReadOnly = true;
			txtrevisadalaptop.Size = new System.Drawing.Size(48, 26);
			txtrevisadalaptop.TabIndex = 83;
			txtrevisadalaptop.Click += new System.EventHandler(txtrevisadalaptop_Click);
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label22.Location = new System.Drawing.Point(541, 394);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(87, 20);
			label22.TabIndex = 82;
			label22.Text = "Revisadas:";
			txtrevisadaaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtrevisadaaudio.Location = new System.Drawing.Point(623, 304);
			txtrevisadaaudio.Name = "txtrevisadaaudio";
			txtrevisadaaudio.ReadOnly = true;
			txtrevisadaaudio.Size = new System.Drawing.Size(48, 26);
			txtrevisadaaudio.TabIndex = 81;
			txtrevisadaaudio.Click += new System.EventHandler(txtrevisadaaudio_Click);
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(541, 308);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(87, 20);
			label23.TabIndex = 80;
			label23.Text = "Revisadas:";
			txtrevisadahogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtrevisadahogar.Location = new System.Drawing.Point(623, 477);
			txtrevisadahogar.Name = "txtrevisadahogar";
			txtrevisadahogar.ReadOnly = true;
			txtrevisadahogar.Size = new System.Drawing.Size(48, 26);
			txtrevisadahogar.TabIndex = 79;
			txtrevisadahogar.Click += new System.EventHandler(txtrevisadahogar_Click);
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label24.Location = new System.Drawing.Point(541, 481);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(87, 20);
			label24.TabIndex = 78;
			label24.Text = "Revisadas:";
			txtrevisadasmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtrevisadasmart.Location = new System.Drawing.Point(623, 210);
			txtrevisadasmart.Name = "txtrevisadasmart";
			txtrevisadasmart.ReadOnly = true;
			txtrevisadasmart.Size = new System.Drawing.Size(48, 26);
			txtrevisadasmart.TabIndex = 77;
			txtrevisadasmart.Click += new System.EventHandler(txtrevisadasmart_Click);
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label25.Location = new System.Drawing.Point(541, 214);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(87, 20);
			label25.TabIndex = 76;
			label25.Text = "Revisadas:";
			txtrevisadatv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtrevisadatv.Location = new System.Drawing.Point(626, 114);
			txtrevisadatv.Name = "txtrevisadatv";
			txtrevisadatv.ReadOnly = true;
			txtrevisadatv.Size = new System.Drawing.Size(48, 26);
			txtrevisadatv.TabIndex = 75;
			txtrevisadatv.Click += new System.EventHandler(txtrevisadatv_Click);
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label26.Location = new System.Drawing.Point(544, 118);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(87, 20);
			label26.TabIndex = 74;
			label26.Text = "Revisadas:";
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Image = Electronica.Properties.Resources._002_laptop1;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(62, 383);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(142, 40);
			button1.TabIndex = 33;
			button1.Text = "     Laptop/Cpu";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			btnaudio.FlatAppearance.BorderSize = 0;
			btnaudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnaudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnaudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnaudio.Image = Electronica.Properties.Resources._003_big_music_player_speaker;
			btnaudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnaudio.Location = new System.Drawing.Point(62, 298);
			btnaudio.Margin = new System.Windows.Forms.Padding(2);
			btnaudio.Name = "btnaudio";
			btnaudio.Size = new System.Drawing.Size(145, 40);
			btnaudio.TabIndex = 32;
			btnaudio.Text = "      Audio/Sonido";
			btnaudio.UseVisualStyleBackColor = true;
			btnaudio.Click += new System.EventHandler(btnaudio_Click);
			btnelectro.FlatAppearance.BorderSize = 0;
			btnelectro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btnelectro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnelectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnelectro.Image = Electronica.Properties.Resources._001_washing_machine;
			btnelectro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnelectro.Location = new System.Drawing.Point(62, 470);
			btnelectro.Margin = new System.Windows.Forms.Padding(2);
			btnelectro.Name = "btnelectro";
			btnelectro.Size = new System.Drawing.Size(142, 40);
			btnelectro.TabIndex = 31;
			btnelectro.Text = "      Linea Blanca";
			btnelectro.UseVisualStyleBackColor = true;
			btnelectro.Click += new System.EventHandler(btnelectro_Click);
			btncel.FlatAppearance.BorderSize = 0;
			btncel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btncel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btncel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btncel.Image = Electronica.Properties.Resources._004_smartphone_call;
			btncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btncel.Location = new System.Drawing.Point(62, 201);
			btncel.Margin = new System.Windows.Forms.Padding(2);
			btncel.Name = "btncel";
			btncel.Size = new System.Drawing.Size(145, 40);
			btncel.TabIndex = 30;
			btncel.Text = "     Celular / Tablet";
			btncel.UseVisualStyleBackColor = true;
			btncel.Click += new System.EventHandler(btncel_Click);
			btntele.FlatAppearance.BorderSize = 0;
			btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btntele.Image = Electronica.Properties.Resources._005_computer_screen;
			btntele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btntele.Location = new System.Drawing.Point(62, 105);
			btntele.Margin = new System.Windows.Forms.Padding(2);
			btntele.Name = "btntele";
			btntele.Size = new System.Drawing.Size(145, 40);
			btntele.TabIndex = 29;
			btntele.Text = "        Televisiones";
			btntele.UseVisualStyleBackColor = true;
			btntele.Click += new System.EventHandler(btntele_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1059, 574);
			base.Controls.Add(txtrevisadalaptop);
			base.Controls.Add(label22);
			base.Controls.Add(txtrevisadaaudio);
			base.Controls.Add(label23);
			base.Controls.Add(txtrevisadahogar);
			base.Controls.Add(label24);
			base.Controls.Add(txtrevisadasmart);
			base.Controls.Add(label25);
			base.Controls.Add(txtrevisadatv);
			base.Controls.Add(label26);
			base.Controls.Add(txtreparadolaptop);
			base.Controls.Add(txtsolucionlaptop);
			base.Controls.Add(txtreparacionlaptop);
			base.Controls.Add(txtpendientelaptop);
			base.Controls.Add(label18);
			base.Controls.Add(label19);
			base.Controls.Add(label20);
			base.Controls.Add(label21);
			base.Controls.Add(txtreparadoaudio);
			base.Controls.Add(txtsolucionaudio);
			base.Controls.Add(txtreparacionaudio);
			base.Controls.Add(txtpendienteaudio);
			base.Controls.Add(label14);
			base.Controls.Add(label15);
			base.Controls.Add(label16);
			base.Controls.Add(label17);
			base.Controls.Add(txtreparadohogar);
			base.Controls.Add(txtsolucionhogar);
			base.Controls.Add(txtreparacionhogar);
			base.Controls.Add(txtpendientehogar);
			base.Controls.Add(label10);
			base.Controls.Add(label11);
			base.Controls.Add(label12);
			base.Controls.Add(label13);
			base.Controls.Add(txtreparadosmart);
			base.Controls.Add(txtsolucionsmart);
			base.Controls.Add(txtreparacionsmart);
			base.Controls.Add(txtpendientesmart);
			base.Controls.Add(label6);
			base.Controls.Add(label7);
			base.Controls.Add(label8);
			base.Controls.Add(label9);
			base.Controls.Add(txtreparadotv);
			base.Controls.Add(txtsoluciontv);
			base.Controls.Add(txtreparaciontv);
			base.Controls.Add(txtpendientetv);
			base.Controls.Add(label4);
			base.Controls.Add(label5);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Controls.Add(button1);
			base.Controls.Add(btnaudio);
			base.Controls.Add(btnelectro);
			base.Controls.Add(btncel);
			base.Controls.Add(btntele);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Taller";
			Text = "Clientes";
			base.Load += new System.EventHandler(Taller_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
