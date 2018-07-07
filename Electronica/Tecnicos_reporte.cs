using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Electronica
{
	public class Tecnicos_reporte : Form
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

		public TextBox txttipo;

		public TextBox txtsolicitud;

		private Label label10;

		private CheckBox checkrefaccion;

		public Tecnicos_reporte()
		{
			InitializeComponent();
			PopupNotifier pop = new PopupNotifier();
			pop.TitleText = "Notificación";
			pop.ContentText = "Especificar en 'Comentario final' sí el equipo quedó reparado o no";
			pop.Delay = 10000;
			pop.ImagePadding = new Padding(10, 10, 10, 10);
			pop.Image = Resources.information;
			pop.TitleFont = new Font("Segoe UI", 16f);
			pop.TitleColor = Color.White;
			pop.ContentColor = Color.White;
			pop.ContentFont = new Font("Segoe UI", 11f);
			pop.BodyColor = Color.FromArgb(0, 122, 204);
			pop.Popup();
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
			if (string.IsNullOrWhiteSpace(txtfalla.Text))
			{
				MessageBox.Show("Campo falla vacío");
			}
			if (string.IsNullOrWhiteSpace(txtsolucion.Text))
			{
				MessageBox.Show("Campo solución vacío");
			}
			if (string.IsNullOrWhiteSpace(txtconclusion.Text))
			{
				MessageBox.Show("Campo comentario final vacío");
			}
			string tabla = txttipo.Text;
			string falla = txtfalla.Text;
			string solucion = txtsolucion.Text;
			string conclusion = txtconclusion.Text;
			int personal = Convert.ToInt32(txtidpersonal.Text);
			int equipo = Convert.ToInt32(txtidequipo.Text);
			string parte = txtsolicitud.Text;
			string query_reporte = "insert into reportes_tecnicos (falla_especifica, solucion_especifica, conclusion,parte,id_personal, id_equipo) values ('" + falla + "', '" + solucion + "','" + conclusion + "','" + parte + "', '" + personal + "', '" + equipo + "') ";
			MySqlCommand cmd_query_reporte = new MySqlCommand(query_reporte, conn);
			string query_estado8 = "update reparar_tv set estado='Diagnosticada', ubicacion='Taller' where id_equipo='" + equipo + "' and id_personal='" + personal + "'";
			MySqlCommand cmd_query_estado8 = new MySqlCommand(query_estado8, conn);
			string query_estado7 = "update reparar_smartphones set estado='Diagnosticada', ubicacion='Taller' where id_equipo='" + equipo + "' and id_personal='" + personal + "'";
			MySqlCommand cmd_query_estado7 = new MySqlCommand(query_estado7, conn);
			string query_estado6 = "update reparar_smartphones set estado='Diagnosticada', ubicacion='Taller' where id_equipo='" + equipo + "' and id_personal='" + personal + "'";
			MySqlCommand cmd_query_estado6 = new MySqlCommand(query_estado6, conn);
			string query_estado5 = "update reparar_audio set estado='Diagnosticada', ubicacion='Taller' where id_equipo='" + equipo + "' and id_personal='" + personal + "'";
			MySqlCommand cmd_query_estado5 = new MySqlCommand(query_estado5, conn);
			string query_estado4 = "update reparar_electrodomesticos set estado='Diagnosticada', ubicacion='Taller' where id_equipo='" + equipo + "' and id_personal='" + personal + "'";
			MySqlCommand cmd_query_estado4 = new MySqlCommand(query_estado4, conn);
			try
			{
				conn.Open();
				MySqlDataReader leercomand = cmd_query_reporte.ExecuteReader();
				conn.Close();
				conn.Open();
				MySqlDataReader leercomando8 = cmd_query_estado8.ExecuteReader();
				conn.Close();
				conn.Open();
				MySqlDataReader leercomando7 = cmd_query_estado7.ExecuteReader();
				conn.Close();
				conn.Open();
				MySqlDataReader leercomando6 = cmd_query_estado6.ExecuteReader();
				conn.Close();
				conn.Open();
				MySqlDataReader leercomando5 = cmd_query_estado5.ExecuteReader();
				conn.Close();
				conn.Open();
				MySqlDataReader leercomando4 = cmd_query_estado4.ExecuteReader();
				MessageBox.Show("Reporte enviado satisfactoriamente");
				conn.Close();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void checkrefaccion_CheckStateChanged(object sender, EventArgs e)
		{
			if (!checkrefaccion.ThreeState)
			{
				checkrefaccion.ThreeState = true;
				txtsolicitud.Enabled = true;
				label10.Visible = true;
			}
			else
			{
				checkrefaccion.ThreeState = false;
				label10.Visible = false;
				txtsolicitud.Enabled = false;
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
			txtidequipo = new System.Windows.Forms.TextBox();
			txtidpersonal = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			txttipo = new System.Windows.Forms.TextBox();
			txtsolicitud = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			checkrefaccion = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			txtfalla.Location = new System.Drawing.Point(62, 188);
			txtfalla.Margin = new System.Windows.Forms.Padding(2);
			txtfalla.Multiline = true;
			txtfalla.Name = "txtfalla";
			txtfalla.Size = new System.Drawing.Size(299, 145);
			txtfalla.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(520, 24);
			label2.TabIndex = 17;
			label2.Text = "Reporte para reparacion con el equipo con el numero:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(107, 166);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(206, 20);
			label1.TabIndex = 18;
			label1.Text = "Verificar y describir falla:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(384, 166);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(336, 20);
			label3.TabIndex = 20;
			label3.Text = "Diagnóstico y procedimientos realizados:";
			txtsolucion.Location = new System.Drawing.Point(402, 188);
			txtsolucion.Margin = new System.Windows.Forms.Padding(2);
			txtsolucion.Multiline = true;
			txtsolucion.Name = "txtsolucion";
			txtsolucion.Size = new System.Drawing.Size(302, 145);
			txtsolucion.TabIndex = 2;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(781, 166);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(228, 20);
			label4.TabIndex = 22;
			label4.Text = "Conclusion final del tecnico";
			txtconclusion.Location = new System.Drawing.Point(748, 188);
			txtconclusion.Margin = new System.Windows.Forms.Padding(2);
			txtconclusion.Multiline = true;
			txtconclusion.Name = "txtconclusion";
			txtconclusion.Size = new System.Drawing.Size(299, 145);
			txtconclusion.TabIndex = 3;
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
			txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidequipo.Location = new System.Drawing.Point(538, 9);
			txtidequipo.Name = "txtidequipo";
			txtidequipo.ReadOnly = true;
			txtidequipo.Size = new System.Drawing.Size(81, 26);
			txtidequipo.TabIndex = 33;
			txtidpersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidpersonal.Location = new System.Drawing.Point(992, 7);
			txtidpersonal.Name = "txtidpersonal";
			txtidpersonal.ReadOnly = true;
			txtidpersonal.Size = new System.Drawing.Size(81, 26);
			txtidpersonal.TabIndex = 34;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(886, 11);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(100, 20);
			label9.TabIndex = 35;
			label9.Text = "ID Tecnico:";
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources.mail_sent__1_;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(900, 568);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(147, 64);
			button1.TabIndex = 4;
			button1.Text = "Enviar reporte";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			txttipo.BackColor = System.Drawing.SystemColors.Control;
			txttipo.Location = new System.Drawing.Point(661, 12);
			txttipo.Margin = new System.Windows.Forms.Padding(2);
			txttipo.Name = "txttipo";
			txttipo.Size = new System.Drawing.Size(150, 20);
			txttipo.TabIndex = 42;
			txttipo.Visible = false;
			txtsolicitud.Enabled = false;
			txtsolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsolicitud.Location = new System.Drawing.Point(306, 568);
			txtsolicitud.Name = "txtsolicitud";
			txtsolicitud.Size = new System.Drawing.Size(178, 26);
			txtsolicitud.TabIndex = 43;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(490, 572);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(206, 18);
			label10.TabIndex = 44;
			label10.Text = "Numero de parte que necesita";
			label10.Visible = false;
			checkrefaccion.AutoSize = true;
			checkrefaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			checkrefaccion.Location = new System.Drawing.Point(62, 566);
			checkrefaccion.Name = "checkrefaccion";
			checkrefaccion.Size = new System.Drawing.Size(208, 29);
			checkrefaccion.TabIndex = 45;
			checkrefaccion.Text = "Solicitar refacción:";
			checkrefaccion.UseVisualStyleBackColor = true;
			checkrefaccion.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			checkrefaccion.CheckStateChanged += new System.EventHandler(checkrefaccion_CheckStateChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 669);
			base.Controls.Add(checkrefaccion);
			base.Controls.Add(label10);
			base.Controls.Add(txtsolicitud);
			base.Controls.Add(txttipo);
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
			base.Name = "Tecnicos_reporte";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
