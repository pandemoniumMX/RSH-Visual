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

		private Label label23;

		private TextBox txttreparado;

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
			label2 = new System.Windows.Forms.Label();
			txtreparado = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtentregar = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtpendiente = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtttsolucion = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtttrevisadas = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtttpendiente = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			txtttreparacion = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			txtttreparadas = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			txtttentregadas = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			txthoy = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			textBox9 = new System.Windows.Forms.TextBox();
			textBox10 = new System.Windows.Forms.TextBox();
			textBox11 = new System.Windows.Forms.TextBox();
			textBox12 = new System.Windows.Forms.TextBox();
			textBox13 = new System.Windows.Forms.TextBox();
			textBox14 = new System.Windows.Forms.TextBox();
			textBox15 = new System.Windows.Forms.TextBox();
			textBox16 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			txttreparado = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(263, 29);
			label2.TabIndex = 2;
			label2.Text = "Estadisticas del taller";
			label2.Click += new System.EventHandler(label2_Click);
			txtreparado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparado.Location = new System.Drawing.Point(292, 69);
			txtreparado.Name = "txtreparado";
			txtreparado.Size = new System.Drawing.Size(100, 31);
			txtreparado.TabIndex = 13;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(25, 73);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(270, 24);
			label1.TabIndex = 14;
			label1.Text = "Total generado en reparacion :";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(398, 73);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(278, 24);
			label3.TabIndex = 16;
			label3.Text = "Total equipos listo para entregar";
			txtentregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtentregar.Location = new System.Drawing.Point(682, 69);
			txtentregar.Name = "txtentregar";
			txtentregar.Size = new System.Drawing.Size(100, 31);
			txtentregar.TabIndex = 15;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(23, 132);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(255, 24);
			label4.TabIndex = 18;
			label4.Text = "Total pendiente de depositar:";
			txtpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendiente.Location = new System.Drawing.Point(292, 128);
			txtpendiente.Name = "txtpendiente";
			txtpendiente.Size = new System.Drawing.Size(100, 31);
			txtpendiente.TabIndex = 17;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(22, 201);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(339, 29);
			label5.TabIndex = 19;
			label5.Text = "Estado de las reparaciones:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(30, 305);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(161, 24);
			label6.TabIndex = 25;
			label6.Text = "Total sin solucion:";
			txtttsolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttsolucion.Location = new System.Drawing.Point(189, 301);
			txtttsolucion.Name = "txtttsolucion";
			txtttsolucion.Size = new System.Drawing.Size(100, 31);
			txtttsolucion.TabIndex = 24;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(309, 246);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(140, 24);
			label7.TabIndex = 23;
			label7.Text = "Total revisadas:";
			txtttrevisadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttrevisadas.Location = new System.Drawing.Point(450, 242);
			txtttrevisadas.Name = "txtttrevisadas";
			txtttrevisadas.Size = new System.Drawing.Size(100, 31);
			txtttrevisadas.TabIndex = 22;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(32, 246);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(155, 24);
			label8.TabIndex = 21;
			label8.Text = "Total pendientes:";
			txtttpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttpendiente.Location = new System.Drawing.Point(189, 242);
			txtttpendiente.Name = "txtttpendiente";
			txtttpendiente.Size = new System.Drawing.Size(100, 31);
			txtttpendiente.TabIndex = 20;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(572, 246);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(178, 24);
			label9.TabIndex = 27;
			label9.Text = "Total en reparación:";
			txtttreparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttreparacion.Location = new System.Drawing.Point(751, 242);
			txtttreparacion.Name = "txtttreparacion";
			txtttreparacion.Size = new System.Drawing.Size(100, 31);
			txtttreparacion.TabIndex = 26;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(307, 305);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(145, 24);
			label10.TabIndex = 29;
			label10.Text = "Total reparadas:";
			txtttreparadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttreparadas.Location = new System.Drawing.Point(450, 301);
			txtttreparadas.Name = "txtttreparadas";
			txtttreparadas.Size = new System.Drawing.Size(100, 31);
			txtttreparadas.TabIndex = 28;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(582, 305);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(155, 24);
			label11.TabIndex = 31;
			label11.Text = "Total entregadas:";
			txtttentregadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttentregadas.Location = new System.Drawing.Point(751, 301);
			txtttentregadas.Name = "txtttentregadas";
			txtttentregadas.Size = new System.Drawing.Size(100, 31);
			txtttentregadas.TabIndex = 30;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(39, 486);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(45, 20);
			label12.TabIndex = 36;
			label12.Text = "Ayer:";
			textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.Location = new System.Drawing.Point(96, 482);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(64, 26);
			textBox1.TabIndex = 35;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(41, 427);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(41, 20);
			label13.TabIndex = 34;
			label13.Text = "Hoy:";
			txthoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txthoy.Location = new System.Drawing.Point(96, 423);
			txthoy.Name = "txthoy";
			txthoy.Size = new System.Drawing.Size(64, 26);
			txthoy.TabIndex = 33;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(31, 382);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(182, 29);
			label14.TabIndex = 32;
			label14.Text = "Informe diario:";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(418, 382);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(213, 29);
			label15.TabIndex = 37;
			label15.Text = "Informe semanal:";
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(790, 382);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(213, 29);
			label16.TabIndex = 38;
			label16.Text = "Informe mensual:";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label17.Location = new System.Drawing.Point(343, 486);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(130, 20);
			label17.TabIndex = 42;
			label17.Text = "Semana pasada:";
			textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox3.Location = new System.Drawing.Point(479, 480);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(71, 26);
			textBox3.TabIndex = 41;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(355, 423);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(118, 20);
			label18.TabIndex = 40;
			label18.Text = "Desde el lunes:";
			textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox4.Location = new System.Drawing.Point(479, 417);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(71, 26);
			textBox4.TabIndex = 39;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(340, 543);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(133, 20);
			label19.TabIndex = 44;
			label19.Text = "Hace 2 semanas:";
			textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox5.Location = new System.Drawing.Point(479, 540);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(71, 26);
			textBox5.TabIndex = 43;
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(732, 542);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(115, 20);
			label20.TabIndex = 50;
			label20.Text = "Hace 2 meses:";
			textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox6.Location = new System.Drawing.Point(853, 540);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(67, 26);
			textBox6.TabIndex = 49;
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(746, 486);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(101, 20);
			label21.TabIndex = 48;
			label21.Text = "Mes anterior:";
			textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox7.Location = new System.Drawing.Point(853, 480);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(67, 26);
			textBox7.TabIndex = 47;
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label22.Location = new System.Drawing.Point(767, 419);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(80, 20);
			label22.TabIndex = 46;
			label22.Text = "Este mes:";
			textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox8.Location = new System.Drawing.Point(853, 417);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(67, 26);
			textBox8.TabIndex = 45;
			textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox9.Location = new System.Drawing.Point(177, 482);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(64, 26);
			textBox9.TabIndex = 52;
			textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox10.Location = new System.Drawing.Point(177, 423);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(64, 26);
			textBox10.TabIndex = 51;
			textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox11.Location = new System.Drawing.Point(560, 539);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(71, 26);
			textBox11.TabIndex = 55;
			textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox12.Location = new System.Drawing.Point(560, 479);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(71, 26);
			textBox12.TabIndex = 54;
			textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox13.Location = new System.Drawing.Point(560, 416);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(71, 26);
			textBox13.TabIndex = 53;
			textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox14.Location = new System.Drawing.Point(936, 539);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(67, 26);
			textBox14.TabIndex = 58;
			textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox15.Location = new System.Drawing.Point(936, 479);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(67, 26);
			textBox15.TabIndex = 57;
			textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox16.Location = new System.Drawing.Point(936, 416);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(67, 26);
			textBox16.TabIndex = 56;
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(475, 132);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(137, 24);
			label23.TabIndex = 60;
			label23.Text = "Total reparado:";
			txttreparado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txttreparado.Location = new System.Drawing.Point(682, 128);
			txttreparado.Name = "txttreparado";
			txttreparado.Size = new System.Drawing.Size(100, 31);
			txttreparado.TabIndex = 59;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1096, 582);
			base.Controls.Add(label23);
			base.Controls.Add(txttreparado);
			base.Controls.Add(textBox14);
			base.Controls.Add(textBox15);
			base.Controls.Add(textBox16);
			base.Controls.Add(textBox11);
			base.Controls.Add(textBox12);
			base.Controls.Add(textBox13);
			base.Controls.Add(textBox9);
			base.Controls.Add(textBox10);
			base.Controls.Add(label20);
			base.Controls.Add(textBox6);
			base.Controls.Add(label21);
			base.Controls.Add(textBox7);
			base.Controls.Add(label22);
			base.Controls.Add(textBox8);
			base.Controls.Add(label19);
			base.Controls.Add(textBox5);
			base.Controls.Add(label17);
			base.Controls.Add(textBox3);
			base.Controls.Add(label18);
			base.Controls.Add(textBox4);
			base.Controls.Add(label16);
			base.Controls.Add(label15);
			base.Controls.Add(label12);
			base.Controls.Add(textBox1);
			base.Controls.Add(label13);
			base.Controls.Add(txthoy);
			base.Controls.Add(label14);
			base.Controls.Add(label11);
			base.Controls.Add(txtttentregadas);
			base.Controls.Add(label10);
			base.Controls.Add(txtttreparadas);
			base.Controls.Add(label9);
			base.Controls.Add(txtttreparacion);
			base.Controls.Add(label6);
			base.Controls.Add(txtttsolucion);
			base.Controls.Add(label7);
			base.Controls.Add(txtttrevisadas);
			base.Controls.Add(label8);
			base.Controls.Add(txtttpendiente);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(txtpendiente);
			base.Controls.Add(label3);
			base.Controls.Add(txtentregar);
			base.Controls.Add(label1);
			base.Controls.Add(txtreparado);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Administrar_taller";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
