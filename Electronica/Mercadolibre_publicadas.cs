using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Mercadolibre_publicadas : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaClientes;

		private TextBox Buscador;

		private Label label1;

		public Mercadolibre_publicadas()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
			string query_tabla_clientes = "SELECT * FROM `refacciones_tv` WHERE estado ='publicada' and CONCAT(`id_refacciones`, `pieza`, `marcas`, `modelos`, `cantidad`,`almacen`, `precio`,'fecha_entrada','fecha_salida','etiqueta_1','etiqueta_2') LIKE '%" + valueToSearch + "%'";
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

		private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
			ss.Show();
		}

		private void TablaClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaClientes.Rows[e.RowIndex];
				Mercadolibre_actualizar cl = new Mercadolibre_actualizar();
				cl.txtrefacciones.Text = row.Cells["id_refacciones"].Value.ToString();
				cl.combopartes.Text = row.Cells["pieza"].Value.ToString();
				cl.combomarca.Text = row.Cells["marcas"].Value.ToString();
				cl.txtmodelo.Text = row.Cells["modelos"].Value.ToString();
				cl.combocantidad.Text = row.Cells["cantidad"].Value.ToString();
				cl.comboalmacen.Text = row.Cells["almacen"].Value.ToString();
				cl.comboestado.Text = row.Cells["estado"].Value.ToString();
				cl.txtetiqueta1.Text = row.Cells["etiqueta_1"].Value.ToString();
				cl.txtetiqueta2.Text = row.Cells["etiqueta_2"].Value.ToString();
				cl.txtcosto.Text = row.Cells["precio"].Value.ToString();
				cl.pictureBox1.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen1"].Value.ToString());
				cl.pictureBox2.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen2"].Value.ToString());
				cl.pictureBox3.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen3"].Value.ToString());
				cl.pictureBox4.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen4"].Value.ToString());
				cl.pictureBox5.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen5"].Value.ToString());
				cl.ShowDialog();
			}
		}

		private void TablaClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
			TablaClientes = new System.Windows.Forms.DataGridView();
			Buscador = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)TablaClientes).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(377, 24);
			label2.TabIndex = 2;
			label2.Text = "Buscador de refacciones MercadoLibre";
			TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaClientes.Location = new System.Drawing.Point(12, 133);
			TablaClientes.Name = "TablaClientes";
			TablaClientes.Size = new System.Drawing.Size(1080, 562);
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(TablaClientes);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Mercadolibre_publicadas";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Mercado Libre";
			base.Load += new System.EventHandler(Clientes_Load);
			((System.ComponentModel.ISupportInitialize)TablaClientes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
