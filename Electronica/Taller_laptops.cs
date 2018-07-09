using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller_laptops : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaEquipos;

		private TextBox Buscador;

		private Label label1;

		public TextBox txtfolio;

		private Button btntele;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		public TextBox txttipo;

		public Taller_laptops()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarEquipos(string valueToSearch)
		{
			string query_tabla_equipos = "SELECT * FROM `reparar_laptops` WHERE concat(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,puntos,id_folio,id_personal)LIKE '%" + valueToSearch + "%'";
			MySqlCommand cmd_query_tabla_equipos = new MySqlCommand(query_tabla_equipos, conn);
			try
			{
				MySqlDataAdapter tabla = new MySqlDataAdapter();
				tabla.SelectCommand = cmd_query_tabla_equipos;
				DataTable dbdataset = new DataTable();
				tabla.Fill(dbdataset);
				BindingSource bSource = new BindingSource();
				bSource.DataSource = dbdataset;
				TablaEquipos.DataSource = bSource;
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

		private void TablaEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
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
			BuscarEquipos(valueToSearch);
		}

		private void Taller_Load(object sender, EventArgs e)
		{
			BuscarEquipos("");
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
		}

		private void btntele_Click(object sender, EventArgs e)
		{
			Taller_laptops_pendiente ss = new Taller_laptops_pendiente();
			ss.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Taller_laptops_reparacion ss = new Taller_laptops_reparacion();
			ss.ShowDialog();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Taller_laptops_diagnosticada ss = new Taller_laptops_diagnosticada();
			ss.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Taller_laptops_reparacion ss = new Taller_laptops_reparacion();
			ss.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Taller_laptops_reparada ss = new Taller_laptops_reparada();
			ss.ShowDialog();
		}

		private void TablaEquipos_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void TablaEquipos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaEquipos.Rows[e.RowIndex];
				Taller_actualizar3 cl = new Taller_actualizar3();
				cl.txtfolio.Text = row.Cells["id_folio"].Value.ToString();
				cl.txttipo.Text = txttipo.Text.ToString();
				cl.txtequipo.Text = row.Cells["equipo"].Value.ToString();
				cl.txtmarca.Text = row.Cells["marca"].Value.ToString();
				cl.txtmodelo.Text = row.Cells["modelo"].Value.ToString();
				cl.txtaccesorios.Text = row.Cells["accesorios"].Value.ToString();
				cl.txtfalla.Text = row.Cells["falla"].Value.ToString();
				cl.txtcomentarios.Text = row.Cells["comentarios"].Value.ToString();
				cl.txtfechain.Text = row.Cells["fecha_ingreso"].Value.ToString();
				cl.txtfechaen.Text = row.Cells["fecha_entregar"].Value.ToString();
				cl.combolocacion.Text = row.Cells["servicio"].Value.ToString();
				cl.txtrefaccion.Text = row.Cells["presupuesto"].Value.ToString();
				cl.txtabono.Text = row.Cells["abono"].Value.ToString();
				cl.txtmano.Text = row.Cells["mano_obra"].Value.ToString();
                cl.txtresta.Text = row.Cells["restante"].Value.ToString();
                cl.txtsubtotal.Text = row.Cells["costo_total"].Value.ToString();
                cl.txtestado.Text = row.Cells["estado"].Value.ToString();
				cl.ShowDialog();
			}
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.TablaEquipos = new System.Windows.Forms.DataGridView();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.btntele = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txttipo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar Laptops y computadooras en Taller";
            // 
            // TablaEquipos
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.TablaEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaEquipos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaEquipos.Location = new System.Drawing.Point(12, 129);
            this.TablaEquipos.Name = "TablaEquipos";
            this.TablaEquipos.ReadOnly = true;
            this.TablaEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaEquipos.Size = new System.Drawing.Size(1080, 417);
            this.TablaEquipos.TabIndex = 3;
            this.TablaEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaEquipos_CellClick_1);
            this.TablaEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaEquipos_CellClick);
            this.TablaEquipos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaEquipos_CellContentDoubleClick);
            // 
            // Buscador
            // 
            this.Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscador.Location = new System.Drawing.Point(104, 87);
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
            this.label1.Location = new System.Drawing.Point(18, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(565, 25);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 7;
            this.txtfolio.Visible = false;
            // 
            // btntele
            // 
            this.btntele.FlatAppearance.BorderSize = 0;
            this.btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntele.Location = new System.Drawing.Point(297, 82);
            this.btntele.Margin = new System.Windows.Forms.Padding(2);
            this.btntele.Name = "btntele";
            this.btntele.Size = new System.Drawing.Size(119, 29);
            this.btntele.TabIndex = 30;
            this.btntele.Text = "Pendientes";
            this.btntele.UseVisualStyleBackColor = true;
            this.btntele.Click += new System.EventHandler(this.btntele_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(465, 82);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "Diagnosticadas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(639, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 29);
            this.button2.TabIndex = 32;
            this.button2.Text = "En reparacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(804, 82);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 29);
            this.button3.TabIndex = 33;
            this.button3.Text = "Sin Solucion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(981, 82);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 29);
            this.button4.TabIndex = 34;
            this.button4.Text = "Reparadas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txttipo
            // 
            this.txttipo.Location = new System.Drawing.Point(1190, 25);
            this.txttipo.Name = "txttipo";
            this.txttipo.Size = new System.Drawing.Size(100, 20);
            this.txttipo.TabIndex = 36;
            this.txttipo.Text = "reparar_laptops";
            this.txttipo.Visible = false;
            // 
            // Taller_laptops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 558);
            this.Controls.Add(this.txttipo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btntele);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.TablaEquipos);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "Taller_laptops";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Taller_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Taller_laptops_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TablaEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Taller_laptops_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
