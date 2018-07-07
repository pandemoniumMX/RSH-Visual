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
	public class Mercadolibre_ventas : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaClientes;

		private TextBox Buscador;

		private Label label1;

		private TextBox txtfolio;

		private TextBox Reparado;

		public Mercadolibre_ventas()
		{
			InitializeComponent();
			try
			{
				string query = "SELECT COUNT( p.estado ) AS total_total FROM (SELECT estado FROM reparar_smartphones WHERE estado =  'Reparado' UNION ALL SELECT estado FROM reparar_tv WHERE estado =  'Reparado' UNION ALL SELECT estado FROM reparar_laptops WHERE estado =  'Reparado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparado' UNION ALL SELECT estado FROM reparar_electrodomesticos WHERE estado =  'Reparado' )p";
				conn.Open();
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				int Reparado = Convert.ToInt32(cmd_query.ExecuteScalar());
				if (Reparado >= 1)
				{
					PopupNotifier pop = new PopupNotifier();
					pop.Image = Resources.information;
					pop.TitleText = "Notificación";
					pop.ContentText = "Felicidades hay " + Reparado + " equipos reparado(s) satisfactoriamente, favor de comunicarse con los clientes correspondientes";
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
			TablaClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
			TablaClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			string query_tabla_clientes = "SELECT * FROM `Ventas_tv` WHERE estado = 'En venta' and CONCAT(`idventa_tv`, `marca`, `modelo`, `serie`, `costo`,`estado`)LIKE '%" + valueToSearch + "%'";
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

		private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void TablaClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaClientes.Rows[e.RowIndex];
				Mercadolibre_ventas_vista cl = new Mercadolibre_ventas_vista();
				cl.txtmarca.Text = row.Cells["marca"].Value.ToString();
				cl.txtmodelo.Text = row.Cells["modelo"].Value.ToString();
				cl.txtserie.Text = row.Cells["serie"].Value.ToString();
				cl.txtcosto.Text = row.Cells["costo"].Value.ToString();
				cl.pictureBox1.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen1"].Value.ToString());
				cl.pictureBox2.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen2"].Value.ToString());
				cl.pictureBox3.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen3"].Value.ToString());
				cl.ShowDialog();
			}
		}

		private void TablaClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void btn_cliente_nuevo_Click(object sender, EventArgs e)
		{
			Recepcion_ventas_nueva ss = new Recepcion_ventas_nueva();
			ss.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Recepcion_ventas_depositos ss = new Recepcion_ventas_depositos();
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
			Reparado = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)TablaClientes).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(220, 24);
			label2.TabIndex = 2;
			label2.Text = "Ventas de televisiones";
			label2.Click += new System.EventHandler(label2_Click);
			dataGridViewCellStyle.BackColor = System.Drawing.Color.Silver;
			TablaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaClientes.Location = new System.Drawing.Point(22, 133);
			TablaClientes.Name = "TablaClientes";
			TablaClientes.ReadOnly = true;
			TablaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			TablaClientes.Size = new System.Drawing.Size(1060, 547);
			TablaClientes.TabIndex = 3;
			TablaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(TablaClientes_CellContentClick_1);
			TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(TablaClientes_CellMouseClick);
			Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Buscador.Location = new System.Drawing.Point(94, 86);
			Buscador.Name = "Buscador";
			Buscador.Size = new System.Drawing.Size(100, 26);
			Buscador.TabIndex = 5;
			Buscador.TextChanged += new System.EventHandler(Buscador_TextChanged);
			Buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Buscador_KeyPress);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(18, 86);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 24);
			label1.TabIndex = 6;
			label1.Text = "Buscar:";
			txtfolio.Location = new System.Drawing.Point(555, 20);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(100, 20);
			txtfolio.TabIndex = 7;
			txtfolio.Visible = false;
			Reparado.Location = new System.Drawing.Point(681, 20);
			Reparado.Name = "Reparado";
			Reparado.Size = new System.Drawing.Size(131, 20);
			Reparado.TabIndex = 8;
			Reparado.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(Reparado);
			base.Controls.Add(txtfolio);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(TablaClientes);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Mercadolibre_ventas";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			((System.ComponentModel.ISupportInitialize)TablaClientes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
