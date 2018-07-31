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

		private Button btnelectro;

		private Button btntele;

		private Label label1;

		private Label label3;

		private Label label4;

		private Label label5;

		private TextBox txtpendientetv;

		private TextBox txtreparaciontv;

		private TextBox txtsoluciontv;

		private TextBox txtreparadotv;

		private TextBox txtreparadohogar;

		private TextBox txtsolucionhogar;

		private TextBox txtreparacionhogar;

		private TextBox txtpendientehogar;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private TextBox txtrevisadahogar;

		private Label label24;

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
			
				MySqlCommand cmd_query_audio8 = new MySqlCommand(query_audio8, conn);
				MySqlCommand cmd_query_audio7 = new MySqlCommand(query_audio7, conn);
				MySqlCommand cmd_query_audio6 = new MySqlCommand(query_audio6, conn);
				MySqlCommand cmd_query_audio5 = new MySqlCommand(query_audio5, conn);
				MySqlCommand cmd_query_audio4 = new MySqlCommand(query_audio4, conn);
				
				MySqlCommand cmd_query_laptop8 = new MySqlCommand(query_laptop8, conn);
				MySqlCommand cmd_query_laptop7 = new MySqlCommand(query_laptop7, conn);
				MySqlCommand cmd_query_laptop6 = new MySqlCommand(query_laptop6, conn);
				MySqlCommand cmd_query_laptop5 = new MySqlCommand(query_laptop5, conn);
				MySqlCommand cmd_query_laptop4 = new MySqlCommand(query_laptop4, conn);
				
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

		

		private void btnelectro_Click(object sender, EventArgs e)
		{
			Taller_otros ss = new Taller_otros();
			ss.ShowDialog();
		}

		private void btntele_Click(object sender, EventArgs e)
		{
			Taller_tv ss = new Taller_tv();
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

		
		

		private void txtpendientehogar_Click(object sender, EventArgs e)
		{
			Taller_otros_pendiente ss = new Taller_otros_pendiente();
			ss.ShowDialog();
		}

		private void txtreparacionhogar_Click(object sender, EventArgs e)
		{
			Taller_otros_reparacion ss = new Taller_otros_reparacion();
			ss.ShowDialog();
		}

		private void txtrevisadahogar_Click(object sender, EventArgs e)
		{
			Taller_otros_diagnosticada ss = new Taller_otros_diagnosticada();
			ss.ShowDialog();
		}

		private void txtsolucionhogar_Click(object sender, EventArgs e)
		{
			Taller_otros_solucion ss = new Taller_otros_solucion();
			ss.ShowDialog();
		}

		private void txtreparadohogar_Click(object sender, EventArgs e)
		{
			Taller_otros_reparada ss = new Taller_otros_reparada();
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
            this.txtreparadohogar = new System.Windows.Forms.TextBox();
            this.txtsolucionhogar = new System.Windows.Forms.TextBox();
            this.txtreparacionhogar = new System.Windows.Forms.TextBox();
            this.txtpendientehogar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtrevisadahogar = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtrevisadatv = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnelectro = new System.Windows.Forms.Button();
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
            // txtreparadohogar
            // 
            this.txtreparadohogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparadohogar.Location = new System.Drawing.Point(908, 283);
            this.txtreparadohogar.Name = "txtreparadohogar";
            this.txtreparadohogar.ReadOnly = true;
            this.txtreparadohogar.Size = new System.Drawing.Size(48, 26);
            this.txtreparadohogar.TabIndex = 57;
            this.txtreparadohogar.Click += new System.EventHandler(this.txtreparadohogar_Click);
            // 
            // txtsolucionhogar
            // 
            this.txtsolucionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolucionhogar.Location = new System.Drawing.Point(774, 283);
            this.txtsolucionhogar.Name = "txtsolucionhogar";
            this.txtsolucionhogar.ReadOnly = true;
            this.txtsolucionhogar.Size = new System.Drawing.Size(48, 26);
            this.txtsolucionhogar.TabIndex = 56;
            this.txtsolucionhogar.Click += new System.EventHandler(this.txtsolucionhogar_Click);
            // 
            // txtreparacionhogar
            // 
            this.txtreparacionhogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparacionhogar.Location = new System.Drawing.Point(463, 286);
            this.txtreparacionhogar.Name = "txtreparacionhogar";
            this.txtreparacionhogar.ReadOnly = true;
            this.txtreparacionhogar.Size = new System.Drawing.Size(48, 26);
            this.txtreparacionhogar.TabIndex = 55;
            this.txtreparacionhogar.Click += new System.EventHandler(this.txtreparacionhogar_Click);
            // 
            // txtpendientehogar
            // 
            this.txtpendientehogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendientehogar.Location = new System.Drawing.Point(301, 286);
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
            this.label10.Location = new System.Drawing.Point(677, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Sin Solución:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(828, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "Reparado:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(212, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Pendientes:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(355, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 50;
            this.label13.Text = "En reparacion:";
            // 
            // txtrevisadahogar
            // 
            this.txtrevisadahogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrevisadahogar.Location = new System.Drawing.Point(610, 286);
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
            this.label24.Location = new System.Drawing.Point(528, 290);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 20);
            this.label24.TabIndex = 78;
            this.label24.Text = "Revisadas:";
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
            // btnelectro
            // 
            this.btnelectro.FlatAppearance.BorderSize = 0;
            this.btnelectro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnelectro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnelectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnelectro.Image = global::Electronica.Properties.Resources._001_washing_machine;
            this.btnelectro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnelectro.Location = new System.Drawing.Point(49, 279);
            this.btnelectro.Margin = new System.Windows.Forms.Padding(2);
            this.btnelectro.Name = "btnelectro";
            this.btnelectro.Size = new System.Drawing.Size(142, 40);
            this.btnelectro.TabIndex = 31;
            this.btnelectro.Text = "      Otros";
            this.btnelectro.UseVisualStyleBackColor = true;
            this.btnelectro.Click += new System.EventHandler(this.btnelectro_Click);
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
            this.Controls.Add(this.txtrevisadahogar);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtrevisadatv);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtreparadohogar);
            this.Controls.Add(this.txtsolucionhogar);
            this.Controls.Add(this.txtreparacionhogar);
            this.Controls.Add(this.txtpendientehogar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtreparadotv);
            this.Controls.Add(this.txtsoluciontv);
            this.Controls.Add(this.txtreparaciontv);
            this.Controls.Add(this.txtpendientetv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnelectro);
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
