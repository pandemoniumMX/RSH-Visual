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
	public class Recepcion_ventas : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaClientes;

		private TextBox Buscador;

		private Label label1;

		private TextBox txtfolio;

		private TextBox Reparado;

		private Button btn_cliente_nuevo;

		private Button button2;

		public Recepcion_ventas()
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
			string query_tabla_clientes = "SELECT * FROM `Ventas_tv` WHERE estado='En venta' and CONCAT(`idventa_tv`, `marca`, `modelo`, `serie`, `costo`,`estado`)LIKE '%" + valueToSearch + "%'";
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
				Recepcion_ventas_actualizar cl = new Recepcion_ventas_actualizar();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.TablaClientes = new System.Windows.Forms.DataGridView();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.Reparado = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_cliente_nuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ventas de televisiones";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TablaClientes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.TablaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaClientes.Location = new System.Drawing.Point(22, 133);
            this.TablaClientes.Name = "TablaClientes";
            this.TablaClientes.ReadOnly = true;
            this.TablaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaClientes.Size = new System.Drawing.Size(1061, 524);
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
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(555, 20);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 7;
            this.txtfolio.Visible = false;
            // 
            // Reparado
            // 
            this.Reparado.Location = new System.Drawing.Point(681, 20);
            this.Reparado.Name = "Reparado";
            this.Reparado.Size = new System.Drawing.Size(131, 20);
            this.Reparado.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Electronica.Properties.Resources._002_coin;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(641, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "      Depositos en ventas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_cliente_nuevo
            // 
            this.btn_cliente_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_cliente_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_cliente_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cliente_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cliente_nuevo.Image = global::Electronica.Properties.Resources.plus__1_;
            this.btn_cliente_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cliente_nuevo.Location = new System.Drawing.Point(368, 81);
            this.btn_cliente_nuevo.Name = "btn_cliente_nuevo";
            this.btn_cliente_nuevo.Size = new System.Drawing.Size(138, 36);
            this.btn_cliente_nuevo.TabIndex = 9;
            this.btn_cliente_nuevo.Text = "     Nueva venta";
            this.btn_cliente_nuevo.UseVisualStyleBackColor = true;
            this.btn_cliente_nuevo.Click += new System.EventHandler(this.btn_cliente_nuevo_Click);
            // 
            // Recepcion_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_cliente_nuevo);
            this.Controls.Add(this.Reparado);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.TablaClientes);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "Recepcion_ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recepción";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recepcion_ventas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Recepcion_ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
