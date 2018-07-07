using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller_electrodomesticos : Form
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

		public Taller_electrodomesticos()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarEquipos(string valueToSearch)
		{
			string query_tabla_equipos = "SELECT * FROM `reparar_electrodomesticos` WHERE concat(id_equipo,equipo,marca,modelo,accesorios,falla,comentarios,fecha_ingreso,fecha_entregar,fecha_egreso,servicio,presupuesto,mano_obra,abono,costo_total,estado,puntos,id_folio,id_personal)LIKE '%" + valueToSearch + "%'";
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
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaEquipos.Rows[e.RowIndex];
				Taller_actualizar cl = new Taller_actualizar();
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
				cl.txttotal.Text = row.Cells["costo_total"].Value.ToString();
				cl.txtestado.Text = row.Cells["estado"].Value.ToString();
				cl.ShowDialog();
			}
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
			Taller_electrodomesticos_pendiente ss = new Taller_electrodomesticos_pendiente();
			ss.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_reparacion ss = new Taller_electrodomesticos_reparacion();
			ss.ShowDialog();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Taller_electrodomesticos_diagnosticada ss = new Taller_electrodomesticos_diagnosticada();
			ss.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_reparacion ss = new Taller_electrodomesticos_reparacion();
			ss.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Taller_electrodomesticos_reparada ss = new Taller_electrodomesticos_reparada();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			label2 = new System.Windows.Forms.Label();
			TablaEquipos = new System.Windows.Forms.DataGridView();
			Buscador = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txtfolio = new System.Windows.Forms.TextBox();
			btntele = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			txttipo = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)TablaEquipos).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(282, 24);
			label2.TabIndex = 2;
			label2.Text = "Buscar linea blanca en Taller";
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
			TablaEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			TablaEquipos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			TablaEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			TablaEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaEquipos.Location = new System.Drawing.Point(12, 129);
			TablaEquipos.Name = "TablaEquipos";
			TablaEquipos.ReadOnly = true;
			TablaEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			TablaEquipos.Size = new System.Drawing.Size(1080, 417);
			TablaEquipos.TabIndex = 3;
			TablaEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(TablaEquipos_CellClick);
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
			txtfolio.Location = new System.Drawing.Point(565, 25);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(100, 20);
			txtfolio.TabIndex = 7;
			txtfolio.Visible = false;
			btntele.FlatAppearance.BorderSize = 0;
			btntele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btntele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btntele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btntele.Location = new System.Drawing.Point(297, 82);
			btntele.Margin = new System.Windows.Forms.Padding(2);
			btntele.Name = "btntele";
			btntele.Size = new System.Drawing.Size(119, 29);
			btntele.TabIndex = 30;
			btntele.Text = "Pendientes";
			btntele.UseVisualStyleBackColor = true;
			btntele.Click += new System.EventHandler(btntele_Click);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Location = new System.Drawing.Point(465, 82);
			button1.Margin = new System.Windows.Forms.Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(119, 29);
			button1.TabIndex = 31;
			button1.Text = "Diagnosticadas";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(639, 82);
			button2.Margin = new System.Windows.Forms.Padding(2);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(119, 29);
			button2.TabIndex = 32;
			button2.Text = "En reparacion";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(804, 82);
			button3.Margin = new System.Windows.Forms.Padding(2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(119, 29);
			button3.TabIndex = 33;
			button3.Text = "Sin Solucion";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button4.Location = new System.Drawing.Point(981, 82);
			button4.Margin = new System.Windows.Forms.Padding(2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(119, 29);
			button4.TabIndex = 34;
			button4.Text = "Reparadas";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			txttipo.Location = new System.Drawing.Point(1190, 25);
			txttipo.Name = "txttipo";
			txttipo.Size = new System.Drawing.Size(100, 20);
			txttipo.TabIndex = 36;
			txttipo.Text = "reparar_electrodomesticos";
			txttipo.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 558);
			base.Controls.Add(txttipo);
			base.Controls.Add(button4);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(btntele);
			base.Controls.Add(txtfolio);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(TablaEquipos);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Taller_electrodomesticos";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Taller_Load);
			((System.ComponentModel.ISupportInitialize)TablaEquipos).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
