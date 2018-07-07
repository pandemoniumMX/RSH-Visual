using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_ventas : Form
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

		public Administrar_ventas()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT sum( p.costo ) AS total_total FROM (SELECT costo FROM ventas_tv WHERE estado =  'Depositado')p ";
				conn.Open();
				MySqlCommand cmd_query2 = new MySqlCommand(query, conn);
				txtreparado.Text = cmd_query2.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message);
			}
			try
			{
				string query3 = "SELECT sum( p.costo ) AS total_total FROM (SELECT costo FROM ventas_tv WHERE estado =  'En venta')p ";
				conn.Open();
				MySqlCommand cmd_query3 = new MySqlCommand(query3, conn);
				txtentregar.Text = cmd_query3.ExecuteScalar().ToString();
				conn.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
			try
			{
				string query2 = "SELECT sum( p.costo ) AS total_total FROM (SELECT costo FROM ventas_tv WHERE estado =  'Vendida')p ";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query2, conn);
				txtpendiente.Text = cmd_query.ExecuteScalar().ToString();
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
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(438, 29);
			label2.TabIndex = 2;
			label2.Text = "Estadisticas del ventas en recepcion";
			label2.Click += new System.EventHandler(label2_Click);
			txtreparado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtreparado.Location = new System.Drawing.Point(254, 69);
			txtreparado.Name = "txtreparado";
			txtreparado.Size = new System.Drawing.Size(100, 31);
			txtreparado.TabIndex = 13;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(25, 73);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(220, 24);
			label1.TabIndex = 14;
			label1.Text = "Total generado en venta:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(398, 73);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(206, 24);
			label3.TabIndex = 16;
			label3.Text = "Total equipos en venta:";
			txtentregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtentregar.Location = new System.Drawing.Point(610, 69);
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
			txtpendiente.Location = new System.Drawing.Point(284, 128);
			txtpendiente.Name = "txtpendiente";
			txtpendiente.Size = new System.Drawing.Size(100, 31);
			txtpendiente.TabIndex = 17;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1096, 582);
			base.Controls.Add(label4);
			base.Controls.Add(txtpendiente);
			base.Controls.Add(label3);
			base.Controls.Add(txtentregar);
			base.Controls.Add(label1);
			base.Controls.Add(txtreparado);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Administrar_ventas";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
