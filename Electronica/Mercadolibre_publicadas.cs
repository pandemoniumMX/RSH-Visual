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
            this.label2 = new System.Windows.Forms.Label();
            this.TablaClientes = new System.Windows.Forms.DataGridView();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscador de refacciones MercadoLibre";
            // 
            // TablaClientes
            // 
            this.TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaClientes.Location = new System.Drawing.Point(12, 133);
            this.TablaClientes.Name = "TablaClientes";
            this.TablaClientes.Size = new System.Drawing.Size(1080, 562);
            this.TablaClientes.TabIndex = 3;
            this.TablaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaClientes_CellContentClick_1);
            this.TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaClientes_CellMouseClick);
            // 
            // Buscador
            // 
            this.Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscador.Location = new System.Drawing.Point(94, 86);
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
            this.label1.Location = new System.Drawing.Point(18, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // Mercadolibre_publicadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.TablaClientes);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "Mercadolibre_publicadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mercado Libre";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mercadolibre_publicadas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Mercadolibre_publicadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
