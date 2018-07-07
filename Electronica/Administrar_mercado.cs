using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_mercado : Form
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

		private Label label6;

		private TextBox txtttsolucion;

		private Label label7;

		private TextBox txtttrevisadas;

		private Label label8;

		private TextBox txtttpendiente;

		public Administrar_mercado()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT sum( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'Vendida' )p";
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
				string query5 = "SELECT count( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'Vendida' )p";
				conn.Open();
				MySqlCommand cmd_query6 = new MySqlCommand(query5, conn);
				txtentregar.Text = cmd_query6.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex7)
			{
				MessageBox.Show(ex7.Message);
			}
			try
			{
				string query7 = "SELECT sum( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'Pendiente' )p";
				conn.Open();
				MySqlCommand cmd_query7 = new MySqlCommand(query7, conn);
				txtpendiente.Text = cmd_query7.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex6)
			{
				MessageBox.Show(ex6.Message);
			}
			try
			{
				string query6 = "SELECT count( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'Pendiente' )p";
				conn.Open();
				MySqlCommand cmd_query5 = new MySqlCommand(query6, conn);
				txtttpendiente.Text = cmd_query5.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex5)
			{
				MessageBox.Show(ex5.Message);
			}
			try
			{
				string query4 = "SELECT sum( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'Publicada' )p";
				conn.Open();
				MySqlCommand cmd_query4 = new MySqlCommand(query4, conn);
				txtttrevisadas.Text = cmd_query4.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message);
			}
			try
			{
				string query3 = "SELECT count( p.precio ) AS total_total FROM (SELECT precio FROM refacciones_tv WHERE estado =  'publicada' )p";
				conn.Open();
				MySqlCommand cmd_query3 = new MySqlCommand(query3, conn);
				conn.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
			try
			{
				string query2 = "SELECT count( p.estado ) AS total_total FROM (SELECT estado FROM refacciones_tv WHERE estado =  'Publicada' )p";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query2, conn);
				txtttsolucion.Text = cmd_query.ExecuteScalar().ToString();
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
			label6 = new System.Windows.Forms.Label();
			txtttsolucion = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtttrevisadas = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtttpendiente = new System.Windows.Forms.TextBox();
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
			txtreparado.Location = new System.Drawing.Point(217, 66);
			txtreparado.Name = "txtreparado";
			txtreparado.ReadOnly = true;
			txtreparado.Size = new System.Drawing.Size(100, 31);
			txtreparado.TabIndex = 13;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(25, 73);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(157, 24);
			label1.TabIndex = 14;
			label1.Text = "Total $ en ventas:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(339, 73);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(175, 24);
			label3.TabIndex = 16;
			label3.Text = "Cantidad en ventas:";
			txtentregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtentregar.Location = new System.Drawing.Point(551, 69);
			txtentregar.Name = "txtentregar";
			txtentregar.ReadOnly = true;
			txtentregar.Size = new System.Drawing.Size(100, 31);
			txtentregar.TabIndex = 15;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(23, 132);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(188, 24);
			label4.TabIndex = 18;
			label4.Text = "Total $ en pendiente:";
			txtpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpendiente.Location = new System.Drawing.Point(217, 128);
			txtpendiente.Name = "txtpendiente";
			txtpendiente.ReadOnly = true;
			txtpendiente.Size = new System.Drawing.Size(100, 31);
			txtpendiente.TabIndex = 17;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(25, 200);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(159, 24);
			label6.TabIndex = 25;
			label6.Text = "Total $ publicado:";
			txtttsolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttsolucion.Location = new System.Drawing.Point(551, 196);
			txtttsolucion.Name = "txtttsolucion";
			txtttsolucion.ReadOnly = true;
			txtttsolucion.Size = new System.Drawing.Size(100, 31);
			txtttsolucion.TabIndex = 24;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(339, 203);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(185, 24);
			label7.TabIndex = 23;
			label7.Text = "Cantidad publicadas:";
			txtttrevisadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttrevisadas.Location = new System.Drawing.Point(217, 196);
			txtttrevisadas.Name = "txtttrevisadas";
			txtttrevisadas.ReadOnly = true;
			txtttrevisadas.Size = new System.Drawing.Size(100, 31);
			txtttrevisadas.TabIndex = 22;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(339, 132);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(206, 24);
			label8.TabIndex = 21;
			label8.Text = "Cantidad en pendiente:";
			txtttpendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtttpendiente.Location = new System.Drawing.Point(551, 128);
			txtttpendiente.Name = "txtttpendiente";
			txtttpendiente.ReadOnly = true;
			txtttpendiente.Size = new System.Drawing.Size(100, 31);
			txtttpendiente.TabIndex = 20;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1096, 582);
			base.Controls.Add(label6);
			base.Controls.Add(txtttsolucion);
			base.Controls.Add(label7);
			base.Controls.Add(txtttrevisadas);
			base.Controls.Add(label8);
			base.Controls.Add(txtttpendiente);
			base.Controls.Add(label4);
			base.Controls.Add(txtpendiente);
			base.Controls.Add(label3);
			base.Controls.Add(txtentregar);
			base.Controls.Add(label1);
			base.Controls.Add(txtreparado);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Administrar_mercado";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
