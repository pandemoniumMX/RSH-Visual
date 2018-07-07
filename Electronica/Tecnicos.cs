using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Tecnicos : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label2;

		private TextBox Buscador;

		private Label label1;

		public TextBox txtpersonal;

		private DataGridView TablaClientes;

		public TextBox txttipo;

		public Tecnicos(string personal)
		{
			InitializeComponent();
			txtpersonal.Text = personal;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
			string query_tabla_tecnicos = "select p.id_personal, p.nombre, tv.id_equipo,tv.equipo,tv.marca,tv.modelo,tv.falla,tv.estado,tv.id_equipo from personal p inner join reparar_tv tv on p.id_personal = tv.id_personal where p.id_personal = '" + txtpersonal.Text + "' and tv.estado='En reparación'union select p.id_personal, p.nombre, smart.id_equipo,smart.equipo,smart.marca,smart.modelo,smart.falla,smart.estado,smart.id_equipo from personal p inner join reparar_smartphones smart on p.id_personal = smart.id_personal where p.id_personal = '" + txtpersonal.Text + "'and smart.estado='En reparación'union select p.id_personal, p.nombre, lap.id_equipo,lap.equipo,lap.marca,lap.modelo,lap.falla,lap.estado,lap.id_equipo from personal p inner join reparar_laptops lap on p.id_personal = lap.id_personal where p.id_personal = '" + txtpersonal.Text + "'and lap.estado='En reparación'union select p.id_personal, p.nombre, audio.id_equipo,audio.equipo,audio.marca,audio.modelo,audio.falla,audio.estado,audio.id_equipo from personal p inner join reparar_audio audio on p.id_personal = audio.id_personal where p.id_personal = '" + txtpersonal.Text + "'and audio.estado='En reparación'union select p.id_personal, p.nombre, elec.id_equipo,elec.equipo,elec.marca,elec.modelo,elec.falla,elec.estado,elec.id_equipo from personal p inner join reparar_electrodomesticos elec on p.id_personal = elec.id_personal where p.id_personal = '" + txtpersonal.Text + "'and elec.estado='En reparación'";
			MySqlCommand cmd_query_tabla_tecnicos = new MySqlCommand(query_tabla_tecnicos, conn);
			try
			{
				MySqlDataAdapter tabla = new MySqlDataAdapter();
				tabla.SelectCommand = cmd_query_tabla_tecnicos;
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
		}

		private void TablaClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void txtpersonal_TextChanged(object sender, EventArgs e)
		{
		}

		private void TablaClientes_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void TablaClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = TablaClientes.Rows[e.RowIndex];
				Tecnicos_reporte tr = new Tecnicos_reporte();
				tr.txttipo.Text = txttipo.Text.ToString();
				tr.txtidequipo.Text = row.Cells["id_equipo1"].Value.ToString();
				tr.txtidpersonal.Text = row.Cells["id_personal"].Value.ToString();
				tr.txtequipo.Text = row.Cells["equipo"].Value.ToString();
				tr.txtmarca.Text = row.Cells["marca"].Value.ToString();
				tr.txtmodelo.Text = row.Cells["modelo"].Value.ToString();
				tr.txtfallax.Text = row.Cells["falla"].Value.ToString();
				tr.ShowDialog();
				Close();
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
			label2 = new System.Windows.Forms.Label();
			Buscador = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txtpersonal = new System.Windows.Forms.TextBox();
			TablaClientes = new System.Windows.Forms.DataGridView();
			txttipo = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)TablaClientes).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(283, 24);
			label2.TabIndex = 2;
			label2.Text = "Trabajos asignados a tecnico";
			label2.Click += new System.EventHandler(label2_Click);
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
			txtpersonal.Location = new System.Drawing.Point(563, 24);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(100, 20);
			txtpersonal.TabIndex = 7;
			txtpersonal.WordWrap = false;
			txtpersonal.TextChanged += new System.EventHandler(txtpersonal_TextChanged);
			TablaClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			TablaClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			TablaClientes.Location = new System.Drawing.Point(12, 143);
			TablaClientes.Name = "TablaClientes";
			TablaClientes.Size = new System.Drawing.Size(943, 419);
			TablaClientes.TabIndex = 3;
			TablaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(TablaClientes_CellContentClick_2);
			TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(TablaClientes_CellMouseClick);
			txttipo.BackColor = System.Drawing.SystemColors.Control;
			txttipo.Location = new System.Drawing.Point(342, 25);
			txttipo.Margin = new System.Windows.Forms.Padding(2);
			txttipo.Name = "txttipo";
			txttipo.Size = new System.Drawing.Size(150, 20);
			txttipo.TabIndex = 43;
			txttipo.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(967, 574);
			base.Controls.Add(txttipo);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(label1);
			base.Controls.Add(Buscador);
			base.Controls.Add(TablaClientes);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Tecnicos";
			Text = "Clientes";
			base.Load += new System.EventHandler(Clientes_Load);
			((System.ComponentModel.ISupportInitialize)TablaClientes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
