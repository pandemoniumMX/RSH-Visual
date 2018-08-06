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

		
		public void BuscarCliente(string valueToSearch)
		{
			string query_tabla_tecnicos = "select p.id_personal, p.nombre,tv.equipo,tv.marca,tv.modelo,tv.falla,tv.estado,tv.id_equipo from personal p inner join reparar_tv tv on p.id_personal = tv.id_personal where p.id_personal = '" + txtpersonal.Text + "' and tv.estado='En reparación'union select p.id_personal, p.nombre,smart.equipo,smart.marca,smart.modelo,smart.falla,smart.estado,smart.id_equipo from personal p inner join reparar_electrodomesticos smart on p.id_personal = smart.id_personal where p.id_personal = '" + txtpersonal.Text + "'and smart.estado='En reparación'";
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

		
		private void Buscador_KeyPress(object sender, KeyPressEventArgs e)
		{
			string valueToSearch = Buscador.Text.ToString();
			BuscarCliente(valueToSearch);
		}

		private void Clientes_Load(object sender, EventArgs e)
		{
			BuscarCliente("");
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
            this.label2 = new System.Windows.Forms.Label();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpersonal = new System.Windows.Forms.TextBox();
            this.TablaClientes = new System.Windows.Forms.DataGridView();
            this.txttipo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trabajos asignados a tecnico";
            // 
            // Buscador
            // 
            this.Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscador.Location = new System.Drawing.Point(94, 86);
            this.Buscador.Name = "Buscador";
            this.Buscador.Size = new System.Drawing.Size(100, 26);
            this.Buscador.TabIndex = 5;
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
            // txtpersonal
            // 
            this.txtpersonal.Location = new System.Drawing.Point(563, 24);
            this.txtpersonal.Name = "txtpersonal";
            this.txtpersonal.Size = new System.Drawing.Size(100, 20);
            this.txtpersonal.TabIndex = 7;
            this.txtpersonal.Visible = false;
            this.txtpersonal.WordWrap = false;
            // 
            // TablaClientes
            // 
            this.TablaClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablaClientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.TablaClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaClientes.Location = new System.Drawing.Point(12, 143);
            this.TablaClientes.Name = "TablaClientes";
            this.TablaClientes.Size = new System.Drawing.Size(943, 419);
            this.TablaClientes.TabIndex = 3;
            this.TablaClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaClientes_CellMouseClick);
            // 
            // txttipo
            // 
            this.txttipo.BackColor = System.Drawing.SystemColors.Control;
            this.txttipo.Location = new System.Drawing.Point(342, 25);
            this.txttipo.Margin = new System.Windows.Forms.Padding(2);
            this.txttipo.Name = "txttipo";
            this.txttipo.Size = new System.Drawing.Size(150, 20);
            this.txttipo.TabIndex = 43;
            this.txttipo.Visible = false;
            // 
            // Tecnicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(967, 574);
            this.Controls.Add(this.txttipo);
            this.Controls.Add(this.txtpersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.TablaClientes);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tecnicos";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
