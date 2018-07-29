using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Electronica
{
	public class Recepcion : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaClientes;

		private Button btn_cliente_nuevo;

		private TextBox Buscador;

		private Label label1;

		private Button button1;

		private TextBox txtreparado;

		private Button button2;

		private TextBox txtdeposito;

		private Button button3;

		public TextBox txtfolio;

		public TextBox txtpersonal;
        private Button button5;
        private Button button6;
        private Button button4;

		public Recepcion()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparada' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparada' )p";
				conn.Open();
				MySqlCommand cmd_query2 = new MySqlCommand(query, conn);
				int Reparado = Convert.ToInt32(cmd_query2.ExecuteScalar());
				if (Reparado >= 1)
				{
					PopupNotifier pop3 = new PopupNotifier();
					pop3.TitleText = "Notificación";
					pop3.ContentText = "Felicidades hay " + Reparado + " equipos reparado(s) satisfactoriamente, favor de comunicarse con los clientes correspondientes";
					pop3.Delay = 15000;
					pop3.ImagePadding = new Padding(10, 10, 10, 10);
					pop3.Image = Resources.information;
					pop3.TitleFont = new Font("Segoe UI", 16f);
					pop3.TitleColor = Color.White;
					pop3.ContentColor = Color.White;
					pop3.ContentFont = new Font("Segoe UI", 11f);
					pop3.BodyColor = Color.FromArgb(0, 122, 204);
                    
					pop3.Popup();
				}
				conn.Close();
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message);
			}
			try
			{
				string query3 = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM cobranza WHERE estado =  'Pendiente')p";
				conn.Open();
				MySqlCommand cmd_query3 = new MySqlCommand(query3, conn);
				int txtdeposito2 = Convert.ToInt32(cmd_query3.ExecuteScalar());
				if (txtdeposito2 >= 1)
				{
					PopupNotifier pop2 = new PopupNotifier();
					pop2.TitleText = "Notificación";
					pop2.ContentText = "Tienes " + txtdeposito2 + " depositos pendientes en reparacion, recuerda depositarlos de la manera más rápida posible";
					pop2.Delay = 10000;
					pop2.ImagePadding = new Padding(10, 10, 10, 10);
					pop2.Image = Resources.information;
					pop2.TitleFont = new Font("Segoe UI", 16f);
					pop2.TitleColor = Color.White;
					pop2.ContentColor = Color.White;
					pop2.ContentFont = new Font("Segoe UI", 11f);
					pop2.BodyColor = Color.FromArgb(0, 122, 204);
					pop2.Popup();
				}
				conn.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
			try
			{
				string query2 = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM ventas_tv WHERE estado =  'Vendida' )p";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query2, conn);
				int txtdeposito = Convert.ToInt32(cmd_query.ExecuteScalar());
				if (txtdeposito >= 1)
				{
					PopupNotifier pop = new PopupNotifier();
					pop.TitleText = "Notificación";
					pop.ContentText = "Tienes " + txtdeposito + " depositos pendientes en ventas, recuerda depositarlos de la manera más rápida posible";
					pop.Delay = 5000;
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

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
			string query_tabla_clientes = "SELECT * FROM `Clientes` WHERE CONCAT(`Id_folio`, `Nombre`, `Apellidos`, `Direccion`, `Correo`,`Celular`, `Puntos`)LIKE '%" + valueToSearch + "%'";
			MySqlCommand cmd_query_tabla_clientes = new MySqlCommand(query_tabla_clientes, conn);
			try
			{
				MySqlDataAdapter tabla = new MySqlDataAdapter();
				tabla.SelectCommand = cmd_query_tabla_clientes;
				DataTable dbdataset = new DataTable();
				tabla.Fill(dbdataset);
				BindingSource bSource = new BindingSource();
				bSource.DataSource = dbdataset;
				TablaClientes.DataSource = bSource;
				tabla.Update(dbdataset);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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
			string valueToSearch = Buscador.Text.ToString();
			BuscarCliente(valueToSearch);
		}

		private void Clientes_Load(object sender, EventArgs e)
		{
			BuscarCliente("");
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.ShowDialog();
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void TablaClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaClientes.Rows[e.RowIndex];
				Recepcion2 cl = new Recepcion2();
				cl.txtfolio.Text = row.Cells["id_folio"].Value.ToString();
				cl.txtnombre.Text = row.Cells["nombre"].Value.ToString();
				cl.txtapellido.Text = row.Cells["apellidos"].Value.ToString();
				cl.txtdireccion.Text = row.Cells["direccion"].Value.ToString();
				cl.txtcorreo.Text = row.Cells["correo"].Value.ToString();
				cl.txtcelular.Text = row.Cells["celular"].Value.ToString();
				cl.txtfecha.Text = row.Cells["fecha"].Value.ToString();
				cl.txtpuntos.Text = row.Cells["puntos"].Value.ToString();
				cl.ShowDialog();
			}
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

		private void button4_Click(object sender, EventArgs e)
		{
			Avisos ss = new Avisos();
			ss.ShowDialog();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.TablaClientes = new System.Windows.Forms.DataGridView();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.txtreparado = new System.Windows.Forms.TextBox();
            this.txtdeposito = new System.Windows.Forms.TextBox();
            this.txtpersonal = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cliente_nuevo = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clientes Registrados";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TablaClientes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.TablaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TablaClientes.Location = new System.Drawing.Point(129, 178);
            this.TablaClientes.Name = "TablaClientes";
            this.TablaClientes.ReadOnly = true;
            this.TablaClientes.Size = new System.Drawing.Size(853, 499);
            this.TablaClientes.TabIndex = 3;
            this.TablaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaClientes_CellContentClick);
            this.TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaClientes_CellMouseClick);
            // 
            // Buscador
            // 
            this.Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscador.Location = new System.Drawing.Point(129, 103);
            this.Buscador.Name = "Buscador";
            this.Buscador.Size = new System.Drawing.Size(100, 26);
            this.Buscador.TabIndex = 5;
            this.Buscador.TextChanged += new System.EventHandler(this.Buscador_TextChanged);
            this.Buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Buscador_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(423, 25);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 7;
            this.txtfolio.Visible = false;
            // 
            // txtreparado
            // 
            this.txtreparado.Location = new System.Drawing.Point(557, 25);
            this.txtreparado.Name = "txtreparado";
            this.txtreparado.Size = new System.Drawing.Size(100, 20);
            this.txtreparado.TabIndex = 9;
            this.txtreparado.Visible = false;
            // 
            // txtdeposito
            // 
            this.txtdeposito.Location = new System.Drawing.Point(688, 24);
            this.txtdeposito.Name = "txtdeposito";
            this.txtdeposito.Size = new System.Drawing.Size(100, 20);
            this.txtdeposito.TabIndex = 11;
            this.txtdeposito.Visible = false;
            // 
            // txtpersonal
            // 
            this.txtpersonal.Location = new System.Drawing.Point(821, 25);
            this.txtpersonal.Name = "txtpersonal";
            this.txtpersonal.Size = new System.Drawing.Size(100, 20);
            this.txtpersonal.TabIndex = 13;
            this.txtpersonal.Visible = false;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::Properties.Resources.sad1;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(419, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 36);
            this.button5.TabIndex = 15;
            this.button5.Text = "      Equipos sin solución";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Electronica.Properties.Resources.alert;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(877, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 36);
            this.button4.TabIndex = 14;
            this.button4.Text = "      Avisos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Electronica.Properties.Resources.shopping_cart;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(877, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "      Ventas";
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
            this.button2.Location = new System.Drawing.Point(621, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "      Depositos en reparacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Properties.Resources._002_smile1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(419, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "    Equipos reparados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_cliente_nuevo
            // 
            this.btn_cliente_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_cliente_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_cliente_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cliente_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cliente_nuevo.Image = global::Electronica.Properties.Resources.new_user;
            this.btn_cliente_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cliente_nuevo.Location = new System.Drawing.Point(263, 98);
            this.btn_cliente_nuevo.Name = "btn_cliente_nuevo";
            this.btn_cliente_nuevo.Size = new System.Drawing.Size(138, 36);
            this.btn_cliente_nuevo.TabIndex = 4;
            this.btn_cliente_nuevo.Text = "     Nuevo Cliente";
            this.btn_cliente_nuevo.UseVisualStyleBackColor = true;
            this.btn_cliente_nuevo.Click += new System.EventHandler(this.Cliente_nuevo);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::Electronica.Properties.Resources._002_coin;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(621, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(233, 36);
            this.button6.TabIndex = 16;
            this.button6.Text = "      Depositos en abonos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Recepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 707);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtpersonal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtdeposito);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtreparado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.btn_cliente_nuevo);
            this.Controls.Add(this.TablaClientes);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recepcion";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void button5_Click(object sender, EventArgs e)
        {
            RecepcionSinsolucion ss = new RecepcionSinsolucion();
            ss.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecepcionDepositos_abono ss = new RecepcionDepositos_abono();
            ss.ShowDialog();
        }
    }
}
