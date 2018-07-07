using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_depositos : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private DataGridView TablaEquipos;

		private TextBox Buscador;

		private Label label1;

		public TextBox txt_folio;

		public TextBox txtfolio;

		public Administrar_depositos()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarEquipos(string valueToSearch)
		{
			string query_tabla_equipos = "SELECT * FROM depositos where CONCAT(id_deposito,fecha,autorizacion,cuenta,cantidad,id_personal,id_equipo,serie,id_folio) LIKE '%" + valueToSearch + "%'";
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
				Administrar_depositos_vista cl = new Administrar_depositos_vista();
				cl.txtautorizacion.Text = row.Cells["autorizacion"].Value.ToString();
				cl.txtcantidad.Text = row.Cells["cantidad"].Value.ToString();
				cl.txtcuenta.Text = row.Cells["cuenta"].Value.ToString();
				cl.txtidfolio.Text = row.Cells["id_folio"].Value.ToString();
				cl.txtidequipo.Text = row.Cells["id_equipo"].Value.ToString();
				cl.txtidpersonal.Text = row.Cells["id_personal"].Value.ToString();
				cl.txtdeposito.Text = row.Cells["id_deposito"].Value.ToString();
				cl.pictureBox.Image = Image.FromFile(Application.StartupPath + row.Cells["imagen"].Value.ToString());
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			label2 = new System.Windows.Forms.Label();
			TablaEquipos = new System.Windows.Forms.DataGridView();
			Buscador = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txt_folio = new System.Windows.Forms.TextBox();
			txtfolio = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)TablaEquipos).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(212, 24);
			label2.TabIndex = 2;
			label2.Text = "Depositos pendientes";
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
			TablaEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			TablaEquipos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			TablaEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaEquipos.Location = new System.Drawing.Point(12, 133);
			TablaEquipos.Name = "TablaEquipos";
			TablaEquipos.ReadOnly = true;
			TablaEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			TablaEquipos.Size = new System.Drawing.Size(1056, 419);
			TablaEquipos.TabIndex = 3;
			TablaEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(TablaEquipos_CellContentClick_1);
			TablaEquipos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(TablaEquipos_CellMouseClick);
			Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Buscador.Location = new System.Drawing.Point(104, 87);
			Buscador.Name = "Buscador";
			Buscador.Size = new System.Drawing.Size(100, 26);
			Buscador.TabIndex = 5;
			Buscador.TextChanged += new System.EventHandler(Buscador_TextChanged);
			Buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Buscador_KeyPress);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(18, 87);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 24);
			label1.TabIndex = 6;
			label1.Text = "Buscar:";
			txt_folio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_folio.Location = new System.Drawing.Point(1373, 12);
			txt_folio.Name = "txt_folio";
			txt_folio.Size = new System.Drawing.Size(100, 26);
			txt_folio.TabIndex = 7;
			txt_folio.Visible = false;
			txtfolio.Location = new System.Drawing.Point(1149, 25);
			txtfolio.Margin = new System.Windows.Forms.Padding(2);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(76, 20);
			txtfolio.TabIndex = 8;
			txtfolio.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1080, 543);
			base.Controls.Add(txtfolio);
			base.Controls.Add(txt_folio);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(TablaEquipos);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Administrar_depositos";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Taller_Load);
			((System.ComponentModel.ISupportInitialize)TablaEquipos).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
