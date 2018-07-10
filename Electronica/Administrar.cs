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
            this.label2 = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.txtreparado = new System.Windows.Forms.TextBox();
            this.txtdeposito = new System.Windows.Forms.TextBox();
            this.panelcontenedor = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cliente_nuevo = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Administración y estadística";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(0, -3);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 7;
            this.txtfolio.Visible = false;
            this.txtfolio.TextChanged += new System.EventHandler(this.txtfolio_TextChanged);
            // 
            // txtreparado
            // 
            this.txtreparado.Location = new System.Drawing.Point(167, 47);
            this.txtreparado.Name = "txtreparado";
            this.txtreparado.Size = new System.Drawing.Size(100, 20);
            this.txtreparado.TabIndex = 9;
            this.txtreparado.Visible = false;
            // 
            // txtdeposito
            // 
            this.txtdeposito.Location = new System.Drawing.Point(34, 47);
            this.txtdeposito.Name = "txtdeposito";
            this.txtdeposito.Size = new System.Drawing.Size(100, 20);
            this.txtdeposito.TabIndex = 11;
            this.txtdeposito.Visible = false;
            // 
            // panelcontenedor
            // 
            this.panelcontenedor.Location = new System.Drawing.Point(12, 113);
            this.panelcontenedor.Name = "panelcontenedor";
            this.panelcontenedor.Size = new System.Drawing.Size(1096, 582);
            this.panelcontenedor.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Electronica.Properties.Resources.shopping_cart;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(930, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "      Ver depositos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Electronica.Properties.Resources._002_coin;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(468, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "      Estadisticas de venta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Electronica.Properties.Resources.tick_inside_circle;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(248, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "      Estadisticas del taller";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cliente_nuevo
            // 
            this.btn_cliente_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_cliente_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_cliente_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cliente_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cliente_nuevo.Image = global::Electronica.Properties.Resources.new_user;
            this.btn_cliente_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cliente_nuevo.Location = new System.Drawing.Point(19, 71);
            this.btn_cliente_nuevo.Name = "btn_cliente_nuevo";
            this.btn_cliente_nuevo.Size = new System.Drawing.Size(214, 36);
            this.btn_cliente_nuevo.TabIndex = 4;
            this.btn_cliente_nuevo.Text = "     Personal";
            this.btn_cliente_nuevo.UseVisualStyleBackColor = true;
            this.btn_cliente_nuevo.Click += new System.EventHandler(this.Cliente_nuevo);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Electronica.Properties.Resources._002_coin;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(688, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 36);
            this.button4.TabIndex = 14;
            this.button4.Text = "      Estadisticas ML";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::Electronica.Properties.Resources.alert;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(468, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(178, 36);
            this.button5.TabIndex = 15;
            this.button5.Text = "      Avisos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::Electronica.Properties.Resources.shopping_cart;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(688, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(178, 36);
            this.button6.TabIndex = 16;
            this.button6.Text = "      Ver reportes";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Administrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 707);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panelcontenedor);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtdeposito);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtreparado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.btn_cliente_nuevo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Administrar";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormaHija(new Administrar_Tecnicos_reporte());
        }
    }
}
