using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class RecepcionDepositos : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaEquipos;

		private TextBox Buscador;

		private Label label1;

		public TextBox txt_folio;

		public TextBox txtfolio;

		public RecepcionDepositos()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarEquipos(string valueToSearch)
		{
			string query_tabla_equipos = "SELECT * FROM reparar_Tv where estado = 'Entregado' AND CONCAT(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,id_folio,id_personal) LIKE '%" + valueToSearch + "%' union all SELECT * FROM reparar_laptops where estado = 'Entregado' AND CONCAT(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,id_folio,id_personal) LIKE '%" + valueToSearch + "%' union all SELECT* FROM reparar_electrodomesticos where estado = 'Entregado' and CONCAT(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,id_folio,id_personal) LIKE '%" + valueToSearch + "%' union all SELECT* FROM reparar_audio where estado = 'Entregado' AND CONCAT(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,id_folio,id_personal) LIKE '%" + valueToSearch + "%' union all SELECT* FROM reparar_smartphones where estado = 'Entregado' AND CONCAT(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,id_folio,id_personal) LIKE '%" + valueToSearch + "%'";
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

		private void TablaEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

		private void TablaEquipos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaEquipos.Rows[e.RowIndex];
				RecepcionDeposito_vista cl = new RecepcionDeposito_vista();
				cl.txtidpersonal.Text = row.Cells["id_personal"].Value.ToString();
				cl.txtidequipo.Text = row.Cells["id_equipo"].Value.ToString();
				cl.txtidfolio.Text = row.Cells["id_folio"].Value.ToString();
				cl.ShowDialog();
				Close();
			}
		}

		private void TablaEquipos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.TablaEquipos = new System.Windows.Forms.DataGridView();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_folio = new System.Windows.Forms.TextBox();
            this.txtfolio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Depositos pendientes";
            // 
            // TablaEquipos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.TablaEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaEquipos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaEquipos.Location = new System.Drawing.Point(12, 133);
            this.TablaEquipos.Name = "TablaEquipos";
            this.TablaEquipos.ReadOnly = true;
            this.TablaEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaEquipos.Size = new System.Drawing.Size(1085, 557);
            this.TablaEquipos.TabIndex = 3;
            this.TablaEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaEquipos_CellContentClick_1);
            this.TablaEquipos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaEquipos_CellMouseClick);
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
            // txt_folio
            // 
            this.txt_folio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_folio.Location = new System.Drawing.Point(1373, 12);
            this.txt_folio.Name = "txt_folio";
            this.txt_folio.Size = new System.Drawing.Size(100, 26);
            this.txt_folio.TabIndex = 7;
            this.txt_folio.Visible = false;
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(1149, 25);
            this.txtfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(76, 20);
            this.txtfolio.TabIndex = 8;
            this.txtfolio.Visible = false;
            // 
            // RecepcionDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.txt_folio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.TablaEquipos);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "RecepcionDepositos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Depositos";
            this.Load += new System.EventHandler(this.Taller_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecepcionDepositos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TablaEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void RecepcionDepositos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
