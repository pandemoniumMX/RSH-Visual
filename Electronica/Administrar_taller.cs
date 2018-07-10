using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_taller : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private TextBox txtreparado;

		private Label label1;

		private Label label3;

		private TextBox txtentregar;

		private Label label4;

		private TextBox txtpendiente;

		private Label label5;

		private Label label6;

		private TextBox txtttsolucion;

		private Label label7;

		private TextBox txtttrevisadas;

		private Label label8;

		private TextBox txtttpendiente;

		private Label label9;

		private TextBox txtttreparacion;

		private Label label10;

		private TextBox txtttreparadas;

		private Label label11;

		private TextBox txtttentregadas;

		private Label label12;

		private TextBox textBox1;

		private Label label13;

		private TextBox txthoy;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private TextBox textBox3;

		private Label label18;

		private TextBox textBox4;

		private Label label19;

		private TextBox textBox5;

		private Label label20;

		private TextBox textBox6;

		private Label label21;

		private TextBox textBox7;

		private Label label22;

		private TextBox textBox8;

		private TextBox textBox9;

		private TextBox textBox10;

		private TextBox textBox11;

		private TextBox textBox12;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox15;

		private TextBox textBox16;

		public Administrar_taller()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT sum( p.costo_total ) AS total_total FROM (SELECT costo_total FROM reparar_smartphones WHERE estado =  'Depositado' UNION ALL SELECT costo_total FROM reparar_tv WHERE estado =  'Depositado' UNION ALL SELECT costo_total FROM reparar_laptops WHERE estado =  'Depositado' UNION ALL SELECT costo_total FROM reparar_electrodomesticos WHERE estado =  'Depositado' UNION ALL SELECT costo_total FROM reparar_audio WHERE estado =  'Depositado' )p";
				conn.Open();
				MySqlCommand cmd_query2 = new MySqlCommand(query, conn);
				txtreparado.Text = cmd_query2.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex4)
			{
				MessageBox.Show(ex4.Message);
			}
			try
			{
				string query5 = "SELECT sum( p.costo_total ) AS total_total FROM (SELECT costo_total FROM reparar_smartphones WHERE estado =  'Reparada' UNION ALL SELECT costo_total FROM reparar_tv WHERE estado =  'Reparada' UNION ALL SELECT costo_total FROM reparar_laptops WHERE estado =  'Reparada' UNION ALL SELECT costo_total FROM reparar_electrodomesticos WHERE estado =  'Reparada' UNION ALL SELECT costo_total FROM reparar_electrodomesticos WHERE estado =  'Reparada' )p";
				conn.Open();
				MySqlCommand cmd_query6 = new MySqlCommand(query5, conn);
				txtentregar.Text = cmd_query6.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex8)
			{
				MessageBox.Show(ex8.Message);
			}
			try
			{
				string query9 = "SELECT sum( p.costo_total ) AS total_total FROM (SELECT costo_total FROM reparar_smartphones WHERE estado =  'Entregado' UNION ALL SELECT costo_total FROM reparar_tv WHERE estado =  'Entregado' UNION ALL SELECT costo_total FROM reparar_laptops WHERE estado =  'Entregado' UNION ALL SELECT costo_total FROM reparar_electrodomesticos WHERE estado =  'Entregado' UNION ALL SELECT costo_total FROM reparar_electrodomesticos WHERE estado =  'Entregado' )p";
				conn.Open();
				MySqlCommand cmd_query10 = new MySqlCommand(query9, conn);
				txtpendiente.Text = cmd_query10.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex10)
			{
				MessageBox.Show(ex10.Message);
			}
			try
			{
				string query10 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Pendiente' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Pendiente' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Pendiente' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Pendiente' UNION ALL SELECT estado FROM reparar_audio WHERE estado =  'Pendiente' )p";
				conn.Open();
				MySqlCommand cmd_query9 = new MySqlCommand(query10, conn);
				txtttpendiente.Text = cmd_query9.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex9)
			{
				MessageBox.Show(ex9.Message);
			}
			try
			{
				string query8 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Diagnosticada' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Diagnosticada' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Diagnosticada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Diagnosticada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Diagnosticada' )p";
				conn.Open();
				MySqlCommand cmd_query8 = new MySqlCommand(query8, conn);
				txtttrevisadas.Text = cmd_query8.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex7)
			{
				MessageBox.Show(ex7.Message);
			}
			try
			{
				string query7 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'En reparacion' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'En reparacion' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'En reparacion' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'En reparacion' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'En reparacion' )p";
				conn.Open();
				MySqlCommand cmd_query7 = new MySqlCommand(query7, conn);
				txtttreparacion.Text = cmd_query7.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex6)
			{
				MessageBox.Show(ex6.Message);
			}
			try
			{
				string query6 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Sin solucion' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Sin solucion' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Sin solucion' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Sin solucion' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Sin solucion' )p";
				conn.Open();
				MySqlCommand cmd_query5 = new MySqlCommand(query6, conn);
				txtttsolucion.Text = cmd_query5.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex5)
			{
				MessageBox.Show(ex5.Message);
			}
			try
			{
				string query4 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparada' )p";
				conn.Open();
				MySqlCommand cmd_query4 = new MySqlCommand(query4, conn);
				txtttreparadas.Text = cmd_query4.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message);
			}
			try
			{
				string query3 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' )p";
				conn.Open();
				MySqlCommand cmd_query3 = new MySqlCommand(query3, conn);
				txtttentregadas.Text = cmd_query3.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
			try
			{
				string query2 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Entregado' and fecha_egreso=CURRENT_TIMESTAMP\t UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Entregado' and fecha_egreso=CURRENT_TIMESTAMP UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Entregado' and fecha_egreso=CURRENT_TIMESTAMP UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' and fecha_egreso=CURRENT_TIMESTAMP UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' and fecha_egreso=CURRENT_TIMESTAMP )p";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query2, conn);
				txthoy.Text = cmd_query.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
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

		private void Clientes_Load(object sender, EventArgs e)
		{
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.ShowDialog();
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			RecepcionReparado ss = new RecepcionReparado();
			ss.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			RecepcionDepositos ss = new RecepcionDepositos();
			ss.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Recepcion_ventas ss = new Recepcion_ventas();
			ss.ShowDialog();
		}

		private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            this.txtreparado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtentregar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpendiente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtttsolucion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtttrevisadas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtttpendiente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtttreparacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtttreparadas = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtttentregadas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txthoy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estadisticas del taller";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtreparado
            // 
            this.txtreparado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreparado.Location = new System.Drawing.Point(323, 69);
            this.txtreparado.Name = "txtreparado";
            this.txtreparado.Size = new System.Drawing.Size(100, 31);
            this.txtreparado.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total depositado por reaparación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total equipos listo para entregar:";
            // 
            // txtentregar
            // 
            this.txtentregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtentregar.Location = new System.Drawing.Point(759, 69);
            this.txtentregar.Name = "txtentregar";
            this.txtentregar.Size = new System.Drawing.Size(100, 31);
            this.txtentregar.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total pendiente de depositar:";
            // 
            // txtpendiente
            // 
            this.txtpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpendiente.Location = new System.Drawing.Point(284, 128);
            this.txtpendiente.Name = "txtpendiente";
            this.txtpendiente.Size = new System.Drawing.Size(100, 31);
            this.txtpendiente.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "Estado de las reparaciones:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Total sin solucion:";
            // 
            // txtttsolucion
            // 
            this.txtttsolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttsolucion.Location = new System.Drawing.Point(189, 301);
            this.txtttsolucion.Name = "txtttsolucion";
            this.txtttsolucion.Size = new System.Drawing.Size(100, 31);
            this.txtttsolucion.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(309, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Total revisadas:";
            // 
            // txtttrevisadas
            // 
            this.txtttrevisadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttrevisadas.Location = new System.Drawing.Point(450, 242);
            this.txtttrevisadas.Name = "txtttrevisadas";
            this.txtttrevisadas.Size = new System.Drawing.Size(100, 31);
            this.txtttrevisadas.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "Total pendientes:";
            // 
            // txtttpendiente
            // 
            this.txtttpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttpendiente.Location = new System.Drawing.Point(189, 242);
            this.txtttpendiente.Name = "txtttpendiente";
            this.txtttpendiente.Size = new System.Drawing.Size(100, 31);
            this.txtttpendiente.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(572, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "Total en reparación:";
            // 
            // txtttreparacion
            // 
            this.txtttreparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttreparacion.Location = new System.Drawing.Point(751, 242);
            this.txtttreparacion.Name = "txtttreparacion";
            this.txtttreparacion.Size = new System.Drawing.Size(100, 31);
            this.txtttreparacion.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(307, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 24);
            this.label10.TabIndex = 29;
            this.label10.Text = "Total reparadas:";
            // 
            // txtttreparadas
            // 
            this.txtttreparadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttreparadas.Location = new System.Drawing.Point(450, 301);
            this.txtttreparadas.Name = "txtttreparadas";
            this.txtttreparadas.Size = new System.Drawing.Size(100, 31);
            this.txtttreparadas.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(582, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 24);
            this.label11.TabIndex = 31;
            this.label11.Text = "Total entregadas:";
            // 
            // txtttentregadas
            // 
            this.txtttentregadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttentregadas.Location = new System.Drawing.Point(751, 301);
            this.txtttentregadas.Name = "txtttentregadas";
            this.txtttentregadas.Size = new System.Drawing.Size(100, 31);
            this.txtttentregadas.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 486);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "Ayer:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(96, 482);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 26);
            this.textBox1.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 427);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "Hoy:";
            // 
            // txthoy
            // 
            this.txthoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoy.Location = new System.Drawing.Point(96, 423);
            this.txthoy.Name = "txthoy";
            this.txthoy.Size = new System.Drawing.Size(64, 26);
            this.txthoy.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 382);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(182, 29);
            this.label14.TabIndex = 32;
            this.label14.Text = "Informe diario:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(418, 382);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(213, 29);
            this.label15.TabIndex = 37;
            this.label15.Text = "Informe semanal:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(790, 382);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(213, 29);
            this.label16.TabIndex = 38;
            this.label16.Text = "Informe mensual:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(343, 486);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 20);
            this.label17.TabIndex = 42;
            this.label17.Text = "Semana pasada:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(479, 480);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 26);
            this.textBox3.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(355, 423);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 20);
            this.label18.TabIndex = 40;
            this.label18.Text = "Desde el lunes:";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(479, 417);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(71, 26);
            this.textBox4.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(340, 543);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 20);
            this.label19.TabIndex = 44;
            this.label19.Text = "Hace 2 semanas:";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(479, 540);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(71, 26);
            this.textBox5.TabIndex = 43;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(732, 542);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(115, 20);
            this.label20.TabIndex = 50;
            this.label20.Text = "Hace 2 meses:";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(853, 540);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(67, 26);
            this.textBox6.TabIndex = 49;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(746, 486);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 20);
            this.label21.TabIndex = 48;
            this.label21.Text = "Mes anterior:";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(853, 480);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(67, 26);
            this.textBox7.TabIndex = 47;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(767, 419);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 20);
            this.label22.TabIndex = 46;
            this.label22.Text = "Este mes:";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(853, 417);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(67, 26);
            this.textBox8.TabIndex = 45;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(177, 482);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(64, 26);
            this.textBox9.TabIndex = 52;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(177, 423);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(64, 26);
            this.textBox10.TabIndex = 51;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(560, 539);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(71, 26);
            this.textBox11.TabIndex = 55;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(560, 479);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(71, 26);
            this.textBox12.TabIndex = 54;
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(560, 416);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(71, 26);
            this.textBox13.TabIndex = 53;
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(936, 539);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(67, 26);
            this.textBox14.TabIndex = 58;
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(936, 479);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(67, 26);
            this.textBox15.TabIndex = 57;
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(936, 416);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(67, 26);
            this.textBox16.TabIndex = 56;
            // 
            // Administrar_taller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1096, 582);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txthoy);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtttentregadas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtttreparadas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtttreparacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtttsolucion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtttrevisadas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtttpendiente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpendiente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtentregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtreparado);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Administrar_taller";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
