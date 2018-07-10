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
            DialogResult dr = MessageBox.Show("¿Está seguro de solicitar traslado?", "Confirmar solicitud de traslado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtfalla.Text))
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
            else
            {
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
            this.txtfalla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsolucion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtconclusion = new System.Windows.Forms.TextBox();
            this.txtequipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmarca = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtfallax = new System.Windows.Forms.TextBox();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.txtidpersonal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txttipo = new System.Windows.Forms.TextBox();
            this.txtsolicitud = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkrefaccion = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtfalla
            // 
            this.txtfalla.Location = new System.Drawing.Point(62, 188);
            this.txtfalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtfalla.Multiline = true;
            this.txtfalla.Name = "txtfalla";
            this.txtfalla.Size = new System.Drawing.Size(299, 145);
            this.txtfalla.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Reporte para reparacion con el equipo con el numero:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Verificar y describir falla:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Diagnóstico y procedimientos realizados:";
            // 
            // txtsolucion
            // 
            this.txtsolucion.Location = new System.Drawing.Point(402, 188);
            this.txtsolucion.Margin = new System.Windows.Forms.Padding(2);
            this.txtsolucion.Multiline = true;
            this.txtsolucion.Name = "txtsolucion";
            this.txtsolucion.Size = new System.Drawing.Size(302, 145);
            this.txtsolucion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(781, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Conclusion final del tecnico";
            // 
            // txtconclusion
            // 
            this.txtconclusion.Location = new System.Drawing.Point(748, 188);
            this.txtconclusion.Margin = new System.Windows.Forms.Padding(2);
            this.txtconclusion.Multiline = true;
            this.txtconclusion.Name = "txtconclusion";
            this.txtconclusion.Size = new System.Drawing.Size(299, 145);
            this.txtconclusion.TabIndex = 3;
            // 
            // txtequipo
            // 
            this.txtequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtequipo.Location = new System.Drawing.Point(134, 61);
            this.txtequipo.Name = "txtequipo";
            this.txtequipo.ReadOnly = true;
            this.txtequipo.Size = new System.Drawing.Size(123, 26);
            this.txtequipo.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Equipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(285, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Marca:";
            // 
            // txtmarca
            // 
            this.txtmarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmarca.Location = new System.Drawing.Point(361, 58);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.ReadOnly = true;
            this.txtmarca.Size = new System.Drawing.Size(123, 26);
            this.txtmarca.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(520, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Modelo:";
            // 
            // txtmodelo
            // 
            this.txtmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodelo.Location = new System.Drawing.Point(596, 58);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.ReadOnly = true;
            this.txtmodelo.Size = new System.Drawing.Size(413, 26);
            this.txtmodelo.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Falla:";
            // 
            // txtfallax
            // 
            this.txtfallax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfallax.Location = new System.Drawing.Point(134, 107);
            this.txtfallax.Name = "txtfallax";
            this.txtfallax.ReadOnly = true;
            this.txtfallax.Size = new System.Drawing.Size(875, 26);
            this.txtfallax.TabIndex = 30;
            // 
            // txtidequipo
            // 
            this.txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidequipo.Location = new System.Drawing.Point(538, 9);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.ReadOnly = true;
            this.txtidequipo.Size = new System.Drawing.Size(81, 26);
            this.txtidequipo.TabIndex = 33;
            // 
            // txtidpersonal
            // 
            this.txtidpersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidpersonal.Location = new System.Drawing.Point(992, 7);
            this.txtidpersonal.Name = "txtidpersonal";
            this.txtidpersonal.ReadOnly = true;
            this.txtidpersonal.Size = new System.Drawing.Size(81, 26);
            this.txtidpersonal.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(886, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "ID Tecnico:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Electronica.Properties.Resources.mail_sent__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(900, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 64);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txttipo
            // 
            this.txttipo.BackColor = System.Drawing.SystemColors.Control;
            this.txttipo.Location = new System.Drawing.Point(661, 12);
            this.txttipo.Margin = new System.Windows.Forms.Padding(2);
            this.txttipo.Name = "txttipo";
            this.txttipo.Size = new System.Drawing.Size(150, 20);
            this.txttipo.TabIndex = 42;
            this.txttipo.Visible = false;
            // 
            // txtsolicitud
            // 
            this.txtsolicitud.Enabled = false;
            this.txtsolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsolicitud.Location = new System.Drawing.Point(306, 568);
            this.txtsolicitud.Name = "txtsolicitud";
            this.txtsolicitud.Size = new System.Drawing.Size(178, 26);
            this.txtsolicitud.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(490, 572);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 18);
            this.label10.TabIndex = 44;
            this.label10.Text = "Numero de parte que necesita";
            this.label10.Visible = false;
            // 
            // checkrefaccion
            // 
            this.checkrefaccion.AutoSize = true;
            this.checkrefaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkrefaccion.Location = new System.Drawing.Point(62, 566);
            this.checkrefaccion.Name = "checkrefaccion";
            this.checkrefaccion.Size = new System.Drawing.Size(208, 29);
            this.checkrefaccion.TabIndex = 45;
            this.checkrefaccion.Text = "Solicitar refacción:";
            this.checkrefaccion.UseVisualStyleBackColor = true;
            this.checkrefaccion.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkrefaccion.CheckStateChanged += new System.EventHandler(this.checkrefaccion_CheckStateChanged);
            // 
            // Tecnicos_reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 669);
            this.Controls.Add(this.checkrefaccion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtsolicitud);
            this.Controls.Add(this.txttipo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtidpersonal);
            this.Controls.Add(this.txtidequipo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtfallax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmarca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtequipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtconclusion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsolucion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Name = "Tecnicos_reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tecnicos_reporte_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Tecnicos_reporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
