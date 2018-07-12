using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Recepcion_Traslado_nuevo : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		private Label label1;

		private Label label3;

		public TextBox txtaviso;

		private Button button1;

		public TextBox txtfolio;

		public TextBox txtcomentarios;

		private Label label2;

		private Label label4;
        public TextBox txtubicacion;
        private Label label6;
        public TextBox txtidequipo;
        private ComboBox combodestino;
        private Label label5;

		public Recepcion_Traslado_nuevo(string qs, string qs1, string qs2)
		{
			InitializeComponent();
            txtfolio.Text = qs;
            txtidequipo.Text = qs1;
          

        }

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de solicitar traslado?", "Confirmar solicitud de traslado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtfolio.Text))
			{
				MessageBox.Show("Campo folio vacío");
			}
			if (string.IsNullOrWhiteSpace(txtaviso.Text))
			{
				MessageBox.Show("No puede dejar el campo direccion vacío");
			}
			if (string.IsNullOrWhiteSpace(combodestino.Text))
			{
				MessageBox.Show("No puede dejar el campo destino vacío");
			}
			if (string.IsNullOrWhiteSpace(txtubicacion.Text))
			{
				MessageBox.Show("No puede dejar el campo ubicación vacío");
			}
			else
			{
				int folio = Convert.ToInt32(txtfolio.Text);
				string direccion = txtaviso.Text;
                string ubi = txtubicacion.Text;
				string coment = txtcomentarios.Text;
                string destino = combodestino.SelectedItem.ToString();
                int idequipo = Convert.ToInt32(txtidequipo.Text);
				string query = "insert into traslado(estado,direccion,comentarios,ubicacion,destino,id_equipo,id_folio) values('Pendiente','" + direccion + "','" + coment + "','" + ubi + "','" + destino + "','"+ idequipo + "','" + folio + "')";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					conn.Open();
					MySqlDataReader leer = cmd_query.ExecuteReader();
					MessageBox.Show("Solicitud enviada correctamente");
					conn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
                //modificando ubicacion despues de solicitar el traslado television
                
                string query1 = "update reparar_tv set ubicacion='Recepcion con traslado solicitado' where id_equipo = '" + idequipo + "' and id_folio='"+folio+"' ";
                MySqlCommand cmd_query1 = new MySqlCommand(query1, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leer = cmd_query1.ExecuteReader();
                 
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //modificando ubicacion despues de solicitar el traslado smartphones

                string query2 = "update reparar_smartphones set ubicacion='Recepcion con traslado solicitado' where id_equipo = '" + idequipo + "' and id_folio='" + folio + "' ";
                MySqlCommand cmd_query2 = new MySqlCommand(query2, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leer = cmd_query2.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //modificando ubicacion despues de solicitar el traslado computadoras

                string query3 = "update reparar_laptops set ubicacion='Recepcion con traslado solicitado' where id_equipo = '" + idequipo + "' and id_folio='" + folio + "' ";
                MySqlCommand cmd_query3 = new MySqlCommand(query3, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leer = cmd_query3.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //modificando ubicacion despues de solicitar el traslado audio

                string query4 = "update reparar_audio set ubicacion='Recepcion con traslado solicitado' where id_equipo = '" + idequipo + "' and id_folio='" + folio + "' ";
                MySqlCommand cmd_query4 = new MySqlCommand(query4, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leer = cmd_query4.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //modificando ubicacion despues de solicitar el traslado electrodomesticos

                string query5 = "update reparar_electrodomesticos set ubicacion='Recepcion con traslado solicitado' where id_equipo = '" + idequipo + "' and id_folio='" + folio + "' ";
                MySqlCommand cmd_query5 = new MySqlCommand(query5, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader leer = cmd_query5.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Close();



            }
        }

		private void txtfolio_KeyPress(object sender, KeyPressEventArgs v)
		{
			if (char.IsDigit(v.KeyChar))
			{
				v.Handled = false;
			}
			else if (char.IsSeparator(v.KeyChar))
			{
				v.Handled = false;
			}
			else if (char.IsControl(v.KeyChar))
			{
				v.Handled = false;
			}
			else
			{
				v.Handled = true;
				MessageBox.Show("Solo Numeros");
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtaviso = new System.Windows.Forms.TextBox();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.txtcomentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtubicacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.combodestino = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Folio del cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Dirección exacta:";
            // 
            // txtaviso
            // 
            this.txtaviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaviso.Location = new System.Drawing.Point(23, 208);
            this.txtaviso.Margin = new System.Windows.Forms.Padding(2);
            this.txtaviso.Multiline = true;
            this.txtaviso.Name = "txtaviso";
            this.txtaviso.Size = new System.Drawing.Size(302, 201);
            this.txtaviso.TabIndex = 2;
            // 
            // txtfolio
            // 
            this.txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfolio.Location = new System.Drawing.Point(185, 15);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.ReadOnly = true;
            this.txtfolio.Size = new System.Drawing.Size(114, 26);
            this.txtfolio.TabIndex = 1;
            this.txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfolio_KeyPress);
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomentarios.Location = new System.Drawing.Point(23, 446);
            this.txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomentarios.Multiline = true;
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.Size = new System.Drawing.Size(302, 138);
            this.txtcomentarios.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Comentarios adicionales:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Electronica.Properties.Resources.mail_sent__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(185, 602);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "      Solicitar traslado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Ubicación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "Destino:";
            // 
            // txtubicacion
            // 
            this.txtubicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtubicacion.Location = new System.Drawing.Point(185, 94);
            this.txtubicacion.Name = "txtubicacion";
            this.txtubicacion.ReadOnly = true;
            this.txtubicacion.Size = new System.Drawing.Size(114, 26);
            this.txtubicacion.TabIndex = 54;
            this.txtubicacion.Text = "Recepcion";
            this.txtubicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 56;
            this.label6.Text = "Folio del equipo:";
            // 
            // txtidequipo
            // 
            this.txtidequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidequipo.Location = new System.Drawing.Point(185, 54);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.ReadOnly = true;
            this.txtidequipo.Size = new System.Drawing.Size(114, 26);
            this.txtidequipo.TabIndex = 57;
            this.txtidequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combodestino
            // 
            this.combodestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combodestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combodestino.FormattingEnabled = true;
            this.combodestino.Items.AddRange(new object[] {
            "Bodega",
            "Cliente",
            "Taller"});
            this.combodestino.Location = new System.Drawing.Point(185, 135);
            this.combodestino.Name = "combodestino";
            this.combodestino.Size = new System.Drawing.Size(114, 28);
            this.combodestino.TabIndex = 1;
            // 
            // Recepcion_Traslado_nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(347, 661);
            this.Controls.Add(this.combodestino);
            this.Controls.Add(this.txtidequipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtubicacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcomentarios);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtaviso);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Recepcion_Traslado_nuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud de traslado";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Traslado_nuevo_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Traslado_nuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
