using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Electronica
{
	public class RecepcionOtros : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private IContainer components = null;

		private Label label1;

		private Label label2;

		private Label label5;

		private Label label6;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label11;

		private TextBox txtmodelo;

		private ComboBox combolocacion;

		private TextBox txtcomentarios;

		private Button gtngenorden;

		public TextBox txtidoculto;

		public TextBox txtequipo;

		private TextBox txtfalla;

		private TextBox txtaccesorios;

		public TextBox txtmarca;
        public TextBox txtnombre;
        public TextBox txtapellido;

        public RecepcionOtros()
		{
			InitializeComponent();
		}

		private void gtngenorden_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Los datos de la orden son correctos?", "Confirmar información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtequipo.Text))
			{
				MessageBox.Show("Campo equipo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmarca.Text))
			{
				MessageBox.Show("Campo marca vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtfalla.Text))
			{
				MessageBox.Show("Campo falla vacío");
			}
			if (string.IsNullOrWhiteSpace(combolocacion.Text))
			{
				MessageBox.Show("Campo locacion no seleccionado");
			}
			
			else
			{

                Carga ss = new Carga();
                ss.ShowDialog();

                //generador de reporte pdf
                PDF_Reporte pdf = new PDF_Reporte();
                PDF_Orden_otros cr = new PDF_Orden_otros();


                TextObject txtfolio1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtfolio"];
                TextObject txtnom = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtnom"];
                TextObject txtape = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtape"];
                TextObject txtequipo1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtequipo"];
                TextObject txtmarca1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtmarca"];
                TextObject txtmodelo1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtmodelo"];
                TextObject txtservicio = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["servicio"];
                TextObject txtaccesorios = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["accesorios"];
                TextObject txtfalla1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtfalla"];

                txtfolio1.Text = txtidoculto.Text;
                txtnom.Text = txtnombre.Text;
                txtape.Text = txtapellido.Text;
                txtmarca1.Text = txtmarca.Text;
                txtmodelo1.Text = txtmodelo.Text;
                txtfalla1.Text = txtfalla.Text;
                txtservicio.Text = combolocacion.Text;
                txtaccesorios.Text = txtservicio.Text;


                pdf.PDF_Generar.ReportSource = cr;
                //f2.crystalReportViewer1.ReportSource = cr;
                pdf.Show();

                string equipo = txtequipo.Text;
				string marca = txtmarca.Text;
				string falla = txtfalla.Text;
				string locacion = combolocacion.SelectedItem.ToString();
				string accesorios = txtaccesorios.Text;
				string modelo = txtmodelo.Text;
			
				string comentarios = txtcomentarios.Text;
				int idfolio = Convert.ToInt32(txtidoculto.Text);
				string query_insertar_cel = "insert into reparar_electrodomesticos (equipo, marca, modelo, accesorios, falla, comentarios,fecha_entregar,fecha_egreso, servicio, estado,ubicacion, id_folio) values ('" + equipo + "', '" + marca + "', '" + modelo + "','" + accesorios + "', '" + falla + "','" + comentarios + "', '" + locacion + "','Pendiente','Recepcion', '" + idfolio + "') ";
				MySqlCommand cmd_query_insertar_cel = new MySqlCommand(query_insertar_cel, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando = cmd_query_insertar_cel.ExecuteReader();
				//	MessageBox.Show(equipo + " agregado(a) correctamente");
					conn.Close();
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

	

		private void txtequipo_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtequipo.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		

		private void txtmodelo_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtmodelo.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}
        



		private void txtmarca_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtmarca.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		private void txtaccesorios_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtaccesorios.Text))
			{
				MessageBox.Show("Debe completar la informacion");
			}
		}

		private void txtfalla_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtfalla.Text))
			{
				MessageBox.Show("Debe completar la informacion");
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtequipo = new System.Windows.Forms.TextBox();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.combolocacion = new System.Windows.Forms.ComboBox();
            this.txtcomentarios = new System.Windows.Forms.TextBox();
            this.txtidoculto = new System.Windows.Forms.TextBox();
            this.txtfalla = new System.Windows.Forms.TextBox();
            this.txtaccesorios = new System.Windows.Forms.TextBox();
            this.txtmarca = new System.Windows.Forms.TextBox();
            this.gtngenorden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de Servicio de Linea Blanca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Equipo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comentarios:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Modelo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Accesorios:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 45);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Marca:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Locacion:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 108);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Falla:";
            // 
            // txtequipo
            // 
            this.txtequipo.Location = new System.Drawing.Point(67, 42);
            this.txtequipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtequipo.Name = "txtequipo";
            this.txtequipo.Size = new System.Drawing.Size(102, 20);
            this.txtequipo.TabIndex = 0;
            this.txtequipo.TextChanged += new System.EventHandler(this.txtequipo_TextChanged);
            // 
            // txtmodelo
            // 
            this.txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtmodelo.Location = new System.Drawing.Point(67, 75);
            this.txtmodelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.Size = new System.Drawing.Size(102, 20);
            this.txtmodelo.TabIndex = 2;
            this.txtmodelo.TextChanged += new System.EventHandler(this.txtmodelo_TextChanged);
            // 
            // combolocacion
            // 
            this.combolocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combolocacion.FormattingEnabled = true;
            this.combolocacion.Items.AddRange(new object[] {
            "Taller",
            "Servicio a domicilio",
            "Re-ingreso por garantia",
            "Otro"});
            this.combolocacion.Location = new System.Drawing.Point(80, 133);
            this.combolocacion.Margin = new System.Windows.Forms.Padding(2);
            this.combolocacion.Name = "combolocacion";
            this.combolocacion.Size = new System.Drawing.Size(90, 21);
            this.combolocacion.TabIndex = 5;
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.Location = new System.Drawing.Point(518, 56);
            this.txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomentarios.Multiline = true;
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.Size = new System.Drawing.Size(273, 122);
            this.txtcomentarios.TabIndex = 7;
            // 
            // txtidoculto
            // 
            this.txtidoculto.Location = new System.Drawing.Point(355, 0);
            this.txtidoculto.Margin = new System.Windows.Forms.Padding(2);
            this.txtidoculto.Name = "txtidoculto";
            this.txtidoculto.Size = new System.Drawing.Size(102, 20);
            this.txtidoculto.TabIndex = 23;
            this.txtidoculto.Visible = false;
            // 
            // txtfalla
            // 
            this.txtfalla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtfalla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtfalla.Location = new System.Drawing.Point(67, 105);
            this.txtfalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.Size = new System.Drawing.Size(102, 20);
            this.txtfalla.TabIndex = 4;
            this.txtfalla.TextChanged += new System.EventHandler(this.txtfalla_TextChanged);
            // 
            // txtaccesorios
            // 
            this.txtaccesorios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtaccesorios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtaccesorios.Location = new System.Drawing.Point(316, 74);
            this.txtaccesorios.Margin = new System.Windows.Forms.Padding(2);
            this.txtaccesorios.Name = "txtaccesorios";
            this.txtaccesorios.Size = new System.Drawing.Size(102, 20);
            this.txtaccesorios.TabIndex = 3;
            this.txtaccesorios.TextChanged += new System.EventHandler(this.txtaccesorios_TextChanged);
            // 
            // txtmarca
            // 
            this.txtmarca.Location = new System.Drawing.Point(294, 40);
            this.txtmarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.Size = new System.Drawing.Size(102, 20);
            this.txtmarca.TabIndex = 1;
            this.txtmarca.TextChanged += new System.EventHandler(this.txtmarca_TextChanged);
            // 
            // gtngenorden
            // 
            this.gtngenorden.FlatAppearance.BorderSize = 0;
            this.gtngenorden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.gtngenorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gtngenorden.Image = global::Electronica.Properties.Resources.contract;
            this.gtngenorden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gtngenorden.Location = new System.Drawing.Point(659, 256);
            this.gtngenorden.Margin = new System.Windows.Forms.Padding(2);
            this.gtngenorden.Name = "gtngenorden";
            this.gtngenorden.Size = new System.Drawing.Size(132, 37);
            this.gtngenorden.TabIndex = 8;
            this.gtngenorden.Text = "Generar Orden";
            this.gtngenorden.UseVisualStyleBackColor = true;
            this.gtngenorden.Click += new System.EventHandler(this.gtngenorden_Click);
            // 
            // RecepcionOtros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(857, 419);
            this.Controls.Add(this.txtfalla);
            this.Controls.Add(this.txtaccesorios);
            this.Controls.Add(this.txtmarca);
            this.Controls.Add(this.txtidoculto);
            this.Controls.Add(this.gtngenorden);
            this.Controls.Add(this.txtcomentarios);
            this.Controls.Add(this.combolocacion);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.txtequipo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RecepcionOtros";
            this.Text = "RecepcionTablets_Cel";
            this.Load += new System.EventHandler(this.RecepcionOtros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void RecepcionOtros_Load(object sender, EventArgs e)
        {
            //Mayusculas permanentes en campo modelo y falla
            txtmodelo.CharacterCasing = CharacterCasing.Upper;
            txtfalla.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
