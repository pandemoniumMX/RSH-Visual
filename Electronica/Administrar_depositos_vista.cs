using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_depositos_vista : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private OpenFileDialog opf = new OpenFileDialog();

		private IContainer components = null;

		private Button btnticket;

		private Button button4;

		private Label label2;

		private Label label1;

		public TextBox txtautorizacion;

		public TextBox txtcantidad;

		private Label label3;

		private Label label4;

		public TextBox txtidpersonal;

		public TextBox txtidequipo;

		public TextBox txtidfolio;

		private Label label5;

		public TextBox txtcuenta;

		public PictureBox pictureBox;

		private Label label6;

		private Label label7;

		private Label label8;

		private Button btnactualizar;

		public TextBox txtdeposito;

		public Administrar_depositos_vista()
		{
			InitializeComponent();
		}

		private void Taller_actualizar_Load(object sender, EventArgs e)
		{
		}

		public void button3_Click(object sender, EventArgs e)
		{
			opf.InitialDirectory = "C:\\Users";
			opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf.FilterIndex = 1;
			if (opf.ShowDialog() == DialogResult.OK)
			{
				pictureBox.Image = Image.FromFile(opf.FileName);
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf.CheckFileExists)
			{
				return;
			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		public void button4_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de enviar ticket de deposito? Verifique información, esta acción es irreversible", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes && string.IsNullOrWhiteSpace(txtautorizacion.Text))
			{
				MessageBox.Show("Campo autorización vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcantidad.Text))
			{
				MessageBox.Show("Campo cantidad vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcuenta.Text))
			{
				MessageBox.Show("Campo cuenta vacío");
			}
			if (string.IsNullOrWhiteSpace(pictureBox.Text))
			{
				MessageBox.Show("Campo imagen ticke no seleccionada");
			}
			if (string.IsNullOrWhiteSpace(txtidfolio.Text))
			{
				MessageBox.Show("Campo id cliente vacío");
			}
			if (string.IsNullOrWhiteSpace(txtidpersonal.Text))
			{
				MessageBox.Show("Campo vendedor vacío");
			}
			if (string.IsNullOrWhiteSpace(txtidequipo.Text))
			{
				MessageBox.Show("Campo id equipo vacío");
			}
			else if (opf.CheckFileExists)
			{
				btnticket.Visible = true;
				int deposito = Convert.ToInt32(txtidequipo.Text);
				int equipo = Convert.ToInt32(txtidequipo.Text);
				int personal = Convert.ToInt32(txtidpersonal.Text);
				int folio = Convert.ToInt32(txtidfolio.Text);
				string auto = txtautorizacion.Text;
				int cantidad = Convert.ToInt32(txtcantidad.Text);
				string cuenta = txtcuenta.Text;
				conn.Open();
				string query = "update depositos set autorizacion='" + auto + "' , cuenta= '" + cuenta + "',cantidad='" + cantidad + "',id_personal='" + personal + "',id_equipo='" + equipo + "',id_folio='" + folio + " where id_deposito='" + deposito + "'')";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					MySqlDataReader leer = cmd_query.ExecuteReader();
					conn.Close();
					Close();
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
				}
				string descuento9 = "UPDATE ventas_tv SET estado = 'Depositado' WHERE id_personal='" + personal + "'";
				MySqlCommand cmd_descuento9 = new MySqlCommand(descuento9, conn);
				string descuento8 = "UPDATE reparar_tv SET estado = 'Depositado'  WHERE id_equipo ='" + equipo + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento8 = new MySqlCommand(descuento8, conn);
				string descuento7 = "UPDATE reparar_laptops SET estado = 'Depositado'  WHERE id_equipo ='" + equipo + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento7 = new MySqlCommand(descuento7, conn);
				string descuento6 = "UPDATE reparar_smartphones SET estado = 'Depositado' WHERE id_equipo ='" + equipo + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento6 = new MySqlCommand(descuento6, conn);
				string descuento5 = "UPDATE reparar_audio SET estado = 'Depositado' WHERE id_equipo ='" + equipo + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento5 = new MySqlCommand(descuento5, conn);
				string descuento4 = "UPDATE reparar_electrodomesticos SET estado = 'Depositado' WHERE id_equipo ='" + equipo + "' and id_personal='" + personal + "'";
				MySqlCommand cmd_descuento4 = new MySqlCommand(descuento4, conn);
				try
				{
					conn.Open();
					MySqlDataReader leercomando8 = cmd_descuento8.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando7 = cmd_descuento7.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando6 = cmd_descuento6.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando5 = cmd_descuento5.ExecuteReader();
					conn.Close();
					conn.Open();
					MySqlDataReader leercomando4 = cmd_descuento4.ExecuteReader();
					MessageBox.Show("Ticket de pago registrado exitosamente");
					conn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void btnactualizar_Click(object sender, EventArgs e)
		{
			int equipo = Convert.ToInt32(txtidequipo.Text);
			int personal = Convert.ToInt32(txtidpersonal.Text);
			int folio = Convert.ToInt32(txtidfolio.Text);
			string CorrectFilename = Path.GetFileName(opf.FileName.Replace("\\\\", "\\"));
			Directory.CreateDirectory(("Base de datos\\Equipos Reparados\\Depositos\\" + folio + "\\" + personal + "\\" + equipo) ?? "");
			string ruta = "\\\\Base de datos\\\\Equipos Reparados\\\\Depositos\\\\" + folio + "\\\\" + personal + "\\\\" + equipo + "\\\\";
			string paths = Application.StartupPath;
			File.Copy(opf.FileName, paths + ruta + CorrectFilename);
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtautorizacion = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnticket = new System.Windows.Forms.Button();
            this.txtidpersonal = new System.Windows.Forms.TextBox();
            this.txtidequipo = new System.Windows.Forms.TextBox();
            this.txtidfolio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.txtdeposito = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 24);
            this.label2.TabIndex = 47;
            this.label2.Text = "Datos del deposito";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Imagen del ticket del deposito";
            // 
            // txtautorizacion
            // 
            this.txtautorizacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtautorizacion.Location = new System.Drawing.Point(773, 315);
            this.txtautorizacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtautorizacion.Name = "txtautorizacion";
            this.txtautorizacion.Size = new System.Drawing.Size(181, 20);
            this.txtautorizacion.TabIndex = 49;
            this.txtautorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtcantidad.Location = new System.Drawing.Point(773, 407);
            this.txtcantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(181, 20);
            this.txtcantidad.TabIndex = 50;
            this.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Folio de autorización:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 407);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Cantidad depositada:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(107, 84);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(394, 471);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 46;
            this.pictureBox.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::Electronica.Properties.Resources._003_refresh_button1;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(837, 600);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 45;
            this.button4.Text = "         Actualizar ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnticket
            // 
            this.btnticket.BackColor = System.Drawing.SystemColors.Window;
            this.btnticket.FlatAppearance.BorderSize = 0;
            this.btnticket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.btnticket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnticket.Image = global::Electronica.Properties.Resources.photo_camera;
            this.btnticket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnticket.Location = new System.Drawing.Point(229, 600);
            this.btnticket.Margin = new System.Windows.Forms.Padding(2);
            this.btnticket.Name = "btnticket";
            this.btnticket.Size = new System.Drawing.Size(124, 35);
            this.btnticket.TabIndex = 44;
            this.btnticket.Text = "         Imagen del ticket";
            this.btnticket.UseVisualStyleBackColor = false;
            this.btnticket.Visible = false;
            this.btnticket.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtidpersonal
            // 
            this.txtidpersonal.BackColor = System.Drawing.SystemColors.Window;
            this.txtidpersonal.Location = new System.Drawing.Point(773, 266);
            this.txtidpersonal.Margin = new System.Windows.Forms.Padding(2);
            this.txtidpersonal.Name = "txtidpersonal";
            this.txtidpersonal.ReadOnly = true;
            this.txtidpersonal.Size = new System.Drawing.Size(181, 20);
            this.txtidpersonal.TabIndex = 53;
            this.txtidpersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtidequipo
            // 
            this.txtidequipo.BackColor = System.Drawing.SystemColors.Window;
            this.txtidequipo.Location = new System.Drawing.Point(773, 221);
            this.txtidequipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidequipo.Name = "txtidequipo";
            this.txtidequipo.ReadOnly = true;
            this.txtidequipo.Size = new System.Drawing.Size(181, 20);
            this.txtidequipo.TabIndex = 54;
            this.txtidequipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtidfolio
            // 
            this.txtidfolio.BackColor = System.Drawing.SystemColors.Window;
            this.txtidfolio.Location = new System.Drawing.Point(773, 169);
            this.txtidfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtidfolio.Name = "txtidfolio";
            this.txtidfolio.ReadOnly = true;
            this.txtidfolio.Size = new System.Drawing.Size(181, 20);
            this.txtidfolio.TabIndex = 55;
            this.txtidfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(605, 363);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "# de cuenta o tarjeta";
            // 
            // txtcuenta
            // 
            this.txtcuenta.BackColor = System.Drawing.SystemColors.Window;
            this.txtcuenta.Location = new System.Drawing.Point(773, 365);
            this.txtcuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(181, 20);
            this.txtcuenta.TabIndex = 56;
            this.txtcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(605, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "Folio del cliente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(605, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Folio del vendedor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(605, 221);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Folio del equipo:";
            // 
            // btnactualizar
            // 
            this.btnactualizar.BackColor = System.Drawing.SystemColors.Window;
            this.btnactualizar.FlatAppearance.BorderSize = 0;
            this.btnactualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizar.Image = global::Electronica.Properties.Resources._003_refresh_button1;
            this.btnactualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnactualizar.Location = new System.Drawing.Point(612, 600);
            this.btnactualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(135, 35);
            this.btnactualizar.TabIndex = 61;
            this.btnactualizar.Text = "         Actualizar ticket";
            this.btnactualizar.UseVisualStyleBackColor = false;
            this.btnactualizar.Visible = false;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
            // 
            // txtdeposito
            // 
            this.txtdeposito.Location = new System.Drawing.Point(991, 30);
            this.txtdeposito.Name = "txtdeposito";
            this.txtdeposito.ReadOnly = true;
            this.txtdeposito.Size = new System.Drawing.Size(100, 20);
            this.txtdeposito.TabIndex = 62;
            this.txtdeposito.Visible = false;
            // 
            // Administrar_depositos_vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1116, 661);
            this.Controls.Add(this.txtdeposito);
            this.Controls.Add(this.btnactualizar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcuenta);
            this.Controls.Add(this.txtidfolio);
            this.Controls.Add(this.txtidequipo);
            this.Controls.Add(this.txtidpersonal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.txtautorizacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnticket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Administrar_depositos_vista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Registro de depositos";
            this.Load += new System.EventHandler(this.Taller_actualizar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Administrar_depositos_vista_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Administrar_depositos_vista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
