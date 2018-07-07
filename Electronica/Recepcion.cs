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
				string query3 = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Entregado' )p";
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			label2 = new System.Windows.Forms.Label();
			TablaClientes = new System.Windows.Forms.DataGridView();
			Buscador = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txtfolio = new System.Windows.Forms.TextBox();
			txtreparado = new System.Windows.Forms.TextBox();
			txtdeposito = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btn_cliente_nuevo = new System.Windows.Forms.Button();
			txtpersonal = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)TablaClientes).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(201, 24);
			label2.TabIndex = 2;
			label2.Text = "Clientes Registrados";
			label2.Click += new System.EventHandler(label2_Click);
			dataGridViewCellStyle.BackColor = System.Drawing.Color.Silver;
			TablaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaClientes.GridColor = System.Drawing.Color.FromArgb(45, 45, 48);
			TablaClientes.Location = new System.Drawing.Point(110, 180);
			TablaClientes.Name = "TablaClientes";
			TablaClientes.ReadOnly = true;
			TablaClientes.Size = new System.Drawing.Size(885, 419);
			TablaClientes.TabIndex = 3;
			TablaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(TablaClientes_CellContentClick);
			TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(TablaClientes_CellMouseClick);
			Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Buscador.Location = new System.Drawing.Point(129, 103);
			Buscador.Name = "Buscador";
			Buscador.Size = new System.Drawing.Size(100, 26);
			Buscador.TabIndex = 5;
			Buscador.TextChanged += new System.EventHandler(Buscador_TextChanged);
			Buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Buscador_KeyPress);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(53, 103);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 24);
			label1.TabIndex = 6;
			label1.Text = "Buscar:";
			txtfolio.Location = new System.Drawing.Point(423, 25);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(100, 20);
			txtfolio.TabIndex = 7;
			txtfolio.Visible = false;
			txtreparado.Location = new System.Drawing.Point(557, 25);
			txtreparado.Name = "txtreparado";
			txtreparado.Size = new System.Drawing.Size(100, 20);
			txtreparado.TabIndex = 9;
			txtreparado.Visible = false;
			txtdeposito.Location = new System.Drawing.Point(688, 24);
			txtdeposito.Name = "txtdeposito";
			txtdeposito.Size = new System.Drawing.Size(100, 20);
			txtdeposito.TabIndex = 11;
			txtdeposito.Visible = false;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button3.Image = Electronica.Properties.Resources.shopping_cart;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(877, 98);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(178, 36);
			button3.TabIndex = 12;
			button3.Text = "      Ventas";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.Image = Electronica.Properties.Resources._002_coin;
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(621, 98);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(233, 36);
			button2.TabIndex = 10;
			button2.Text = "      Depositos en reparacion";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Image = Electronica.Properties.Resources.tick_inside_circle;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(419, 98);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(178, 36);
			button1.TabIndex = 8;
			button1.Text = "      Equipos reparados";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			btn_cliente_nuevo.FlatAppearance.BorderSize = 0;
			btn_cliente_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btn_cliente_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_cliente_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_cliente_nuevo.Image = Electronica.Properties.Resources.new_user;
			btn_cliente_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_cliente_nuevo.Location = new System.Drawing.Point(263, 98);
			btn_cliente_nuevo.Name = "btn_cliente_nuevo";
			btn_cliente_nuevo.Size = new System.Drawing.Size(138, 36);
			btn_cliente_nuevo.TabIndex = 4;
			btn_cliente_nuevo.Text = "     Nuevo Cliente";
			btn_cliente_nuevo.UseVisualStyleBackColor = true;
			btn_cliente_nuevo.Click += new System.EventHandler(Cliente_nuevo);
			txtpersonal.Location = new System.Drawing.Point(688, 61);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(100, 20);
			txtpersonal.TabIndex = 13;
			txtpersonal.Visible = false;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button4.Image = Electronica.Properties.Resources.alert;
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(877, 25);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(178, 36);
			button4.TabIndex = 14;
			button4.Text = "      Avisos";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1120, 707);
			base.Controls.Add(button4);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(button3);
			base.Controls.Add(txtdeposito);
			base.Controls.Add(button2);
			base.Controls.Add(txtreparado);
			base.Controls.Add(button1);
			base.Controls.Add(txtfolio);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(btn_cliente_nuevo);
			base.Controls.Add(TablaClientes);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Recepcion";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			((System.ComponentModel.ISupportInitialize)TablaClientes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
