using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Taller_reportes : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		public TextBox txtfalla;

		private Label label2;

		private Label label1;

		private Label label3;

		public TextBox txtsolucion;

		private Label label4;

		public TextBox txtconclusion;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		public TextBox txtequipo;

		public TextBox txtmarca;

		public TextBox txtmodelo;

		public TextBox txtfallax;

		private Button button1;

		public TextBox txtidequipo;

		public TextBox txtidpersonal;

		private Label label9;

		public Taller_reportes()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
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
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.Show();
		}

		private void TablaClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			string falla = txtfalla.Text;
			string solucion = txtsolucion.Text;
			string conclusion = txtconclusion.Text;
			int personal = Convert.ToInt32(txtidpersonal.Text);
			int equipo = Convert.ToInt32(txtidequipo.Text);
			string query_reporte = "insert into reportes_tecnicos (falla_especifica, solucion_especifica, conclusion,id_personal, id_equipo) values ('" + falla + "', '" + solucion + "','" + conclusion + "', '" + personal + "', '" + equipo + "') ";
			MySqlCommand cmd_query_reporte = new MySqlCommand(query_reporte, conn);
			try
			{
				conn.Open();
				MySqlDataReader leercomando = cmd_query_reporte.ExecuteReader();
				MessageBox.Show("Reporte enviado satisfactoriamente");
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
			txtfalla = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtsolucion = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtconclusion = new System.Windows.Forms.TextBox();
			txtequipo = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtmarca = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtmodelo = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtfallax = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			txtidequipo = new System.Windows.Forms.TextBox();
			txtidpersonal = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			SuspendLayout();
			txtfalla.Location = new System.Drawing.Point(49, 282);
			txtfalla.Margin = new System.Windows.Forms.Padding(2);
			txtfalla.Multiline = true;
			txtfalla.Name = "txtfalla";
			txtfalla.Size = new System.Drawing.Size(486, 145);
			txtfalla.TabIndex = 15;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(520, 24);
			label2.TabIndex = 17;
			label2.Text = "Reporte para reparacion con el equipo con el numero:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(45, 260);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(274, 20);
			label1.TabIndex = 18;
			label1.Text = "Describir especificamente la falla";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(556, 260);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(287, 20);
			label3.TabIndex = 20;
			label3.Text = "Describir solucion especificamente";
			txtsolucion.Location = new System.Drawing.Point(560, 282);
			txtsolucion.Margin = new System.Windows.Forms.Padding(2);
			txtsolucion.Multiline = true;
			txtsolucion.Name = "txtsolucion";
			txtsolucion.Size = new System.Drawing.Size(486, 145);
			txtsolucion.TabIndex = 19;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(58, 465);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(337, 20);
			label4.TabIndex = 22;
			label4.Text = "Conclusion o comentario final del tecnico";
			txtconclusion.Location = new System.Drawing.Point(62, 497);
			txtconclusion.Margin = new System.Windows.Forms.Padding(2);
			txtconclusion.Multiline = true;
			txtconclusion.Name = "txtconclusion";
			txtconclusion.Size = new System.Drawing.Size(486, 145);
			txtconclusion.TabIndex = 21;
			txtequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtequipo.Location = new System.Drawing.Point(134, 61);
			txtequipo.Name = "txtequipo";
			txtequipo.ReadOnly = true;
			txtequipo.Size = new System.Drawing.Size(123, 26);
			txtequipo.TabIndex = 24;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(58, 64);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(70, 20);
			label5.TabIndex = 25;
			label5.Text = "Equipo:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(285, 61);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(63, 20);
			label6.TabIndex = 27;
			label6.Text = "Marca:";
			txtmarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmarca.Location = new System.Drawing.Point(361, 58);
			txtmarca.Name = "txtmarca";
			txtmarca.ReadOnly = true;
			txtmarca.Size = new System.Drawing.Size(123, 26);
			txtmarca.TabIndex = 26;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(520, 61);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(72, 20);
			label7.TabIndex = 29;
			label7.Text = "Modelo:";
			txtmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmodelo.Location = new System.Drawing.Point(596, 58);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.ReadOnly = true;
			txtmodelo.Size = new System.Drawing.Size(413, 26);
			txtmodelo.TabIndex = 28;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(58, 110);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(53, 20);
			label8.TabIndex = 31;
			label8.Text = "Falla:";
			txtfallax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfallax.Location = new System.Drawing.Point(134, 107);
			txtfallax.Name = "txtfallax";
			txtfallax.ReadOnly = true;
			txtfallax.Size = new System.Drawing.Size(875, 26);
			txtfallax.TabIndex = 30;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Location = new System.Drawing.Point(793, 578);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(253, 64);
			button1.TabIndex = 32;
			button1.Text = "Enviar reporte";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidequipo.Location = new System.Drawing.Point(524, 9);
			txtidequipo.Name = "txtidequipo";
			txtidequipo.ReadOnly = true;
			txtidequipo.Size = new System.Drawing.Size(81, 26);
			txtidequipo.TabIndex = 33;
			txtidpersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidpersonal.Location = new System.Drawing.Point(976, 9);
			txtidpersonal.Name = "txtidpersonal";
			txtidpersonal.ReadOnly = true;
			txtidpersonal.Size = new System.Drawing.Size(81, 26);
			txtidpersonal.TabIndex = 34;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(870, 13);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(100, 20);
			label9.TabIndex = 35;
			label9.Text = "ID Tecnico:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1082, 707);
			base.Controls.Add(label9);
			base.Controls.Add(txtidpersonal);
			base.Controls.Add(txtidequipo);
			base.Controls.Add(button1);
			base.Controls.Add(label8);
			base.Controls.Add(txtfallax);
			base.Controls.Add(label7);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(label6);
			base.Controls.Add(txtmarca);
			base.Controls.Add(label5);
			base.Controls.Add(txtequipo);
			base.Controls.Add(label4);
			base.Controls.Add(txtconclusion);
			base.Controls.Add(label3);
			base.Controls.Add(txtsolucion);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(txtfalla);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Name = "Taller_reportes";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
