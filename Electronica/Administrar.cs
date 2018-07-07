using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Electronica
{
	public class Administrar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private Button btn_cliente_nuevo;

		private TextBox txtfolio;

		private Button button1;

		private TextBox txtreparado;

		private Button button2;

		private TextBox txtdeposito;

		private Button button3;

		private Panel panelcontenedor;

		private Button button4;

		private Button button5;

		private Button button6;

		public Administrar()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM avisos WHERE estado =  'Pendiente')p";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				int Reparado = Convert.ToInt32(cmd_query.ExecuteScalar());
				if (Reparado >= 1)
				{
					PopupNotifier pop = new PopupNotifier();
					pop.TitleText = "Notificación";
					pop.ContentText = "Atencion tienes " + Reparado + " avisos pendientes, por favor revísalos";
					pop.Delay = 15000;
					pop.ImagePadding = new Padding(10, 10, 10, 10);
					pop.Image = Resources.information;
					pop.TitleFont = new Font("Segoe UI", 16f);
					pop.TitleColor = Color.White;
					pop.ContentColor = Color.White;
					pop.ContentFont = new Font("Segoe UI", 11f);
					pop.BodyColor = Color.FromArgb(0, 122, 204);
					pop.Popup();
				}
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void AbrirFormaHija(object formhija)
		{
			if (panelcontenedor.Controls.Count > 0)
			{
				panelcontenedor.Controls.RemoveAt(0);
			}
			Form fh = formhija as Form;
			fh.TopLevel = false;
			fh.Dock = DockStyle.Fill;
			panelcontenedor.Controls.Add(fh);
			panelcontenedor.Tag = fh;
			fh.Show();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar_taller());
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
			AbrirFormaHija(new Personal());
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar_ventas());
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar_depositos());
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar_mercado());
		}

		private void button5_Click(object sender, EventArgs e)
		{
			AbrirFormaHija(new Administrar_avisos());
		}

		private void txtfolio_TextChanged(object sender, EventArgs e)
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
			txtfolio = new System.Windows.Forms.TextBox();
			txtreparado = new System.Windows.Forms.TextBox();
			txtdeposito = new System.Windows.Forms.TextBox();
			panelcontenedor = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btn_cliente_nuevo = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(267, 24);
			label2.TabIndex = 2;
			label2.Text = "Administración y estadística";
			label2.Click += new System.EventHandler(label2_Click);
			txtfolio.Location = new System.Drawing.Point(0, -3);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(100, 20);
			txtfolio.TabIndex = 7;
			txtfolio.Visible = false;
			txtfolio.TextChanged += new System.EventHandler(txtfolio_TextChanged);
			txtreparado.Location = new System.Drawing.Point(167, 47);
			txtreparado.Name = "txtreparado";
			txtreparado.Size = new System.Drawing.Size(100, 20);
			txtreparado.TabIndex = 9;
			txtreparado.Visible = false;
			txtdeposito.Location = new System.Drawing.Point(34, 47);
			txtdeposito.Name = "txtdeposito";
			txtdeposito.Size = new System.Drawing.Size(100, 20);
			txtdeposito.TabIndex = 11;
			txtdeposito.Visible = false;
			panelcontenedor.Location = new System.Drawing.Point(12, 113);
			panelcontenedor.Name = "panelcontenedor";
			panelcontenedor.Size = new System.Drawing.Size(1096, 582);
			panelcontenedor.TabIndex = 13;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button3.Image = Electronica.Properties.Resources.shopping_cart;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(930, 71);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(178, 36);
			button3.TabIndex = 12;
			button3.Text = "      Ver depositos";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.Image = Electronica.Properties.Resources._002_coin;
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(468, 71);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(200, 36);
			button2.TabIndex = 10;
			button2.Text = "      Estadisticas de venta";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Image = Electronica.Properties.Resources.tick_inside_circle;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(248, 71);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(201, 36);
			button1.TabIndex = 8;
			button1.Text = "      Estadisticas del taller";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			btn_cliente_nuevo.FlatAppearance.BorderSize = 0;
			btn_cliente_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btn_cliente_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_cliente_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_cliente_nuevo.Image = Electronica.Properties.Resources.new_user;
			btn_cliente_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_cliente_nuevo.Location = new System.Drawing.Point(19, 71);
			btn_cliente_nuevo.Name = "btn_cliente_nuevo";
			btn_cliente_nuevo.Size = new System.Drawing.Size(214, 36);
			btn_cliente_nuevo.TabIndex = 4;
			btn_cliente_nuevo.Text = "     Personal";
			btn_cliente_nuevo.UseVisualStyleBackColor = true;
			btn_cliente_nuevo.Click += new System.EventHandler(Cliente_nuevo);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button4.Image = Electronica.Properties.Resources._002_coin;
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(688, 71);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(200, 36);
			button4.TabIndex = 14;
			button4.Text = "      Estadisticas ML";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button5.Image = Electronica.Properties.Resources.alert;
			button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button5.Location = new System.Drawing.Point(468, 15);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(178, 36);
			button5.TabIndex = 15;
			button5.Text = "      Avisos";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button6.FlatAppearance.BorderSize = 0;
			button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button6.Image = Electronica.Properties.Resources.shopping_cart;
			button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button6.Location = new System.Drawing.Point(688, 15);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(178, 36);
			button6.TabIndex = 16;
			button6.Text = "      Ver reportes";
			button6.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1120, 707);
			base.Controls.Add(button6);
			base.Controls.Add(button5);
			base.Controls.Add(button4);
			base.Controls.Add(panelcontenedor);
			base.Controls.Add(button3);
			base.Controls.Add(txtdeposito);
			base.Controls.Add(button2);
			base.Controls.Add(txtreparado);
			base.Controls.Add(button1);
			base.Controls.Add(txtfolio);
			base.Controls.Add(btn_cliente_nuevo);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Administrar";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
