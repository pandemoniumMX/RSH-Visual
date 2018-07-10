using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Electronica
{
	public class Recepcion_ventas_deposito_vista : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private OpenFileDialog opf = new OpenFileDialog();

		private IContainer components = null;

		private Button button3;

		private Button button4;

		private Label label2;

		private Label label1;

		public TextBox txtautorizacion;

		public TextBox txtcantidad;

		private Label label3;

		private Label label4;

		public TextBox txtserie;

		public TextBox txtpersonal;

		public TextBox txtidfolio;

		private Label label5;

		public TextBox txtcuenta;

		public PictureBox pictureBox;

		public Recepcion_ventas_deposito_vista()
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
			if (string.IsNullOrWhiteSpace(txtautorizacion.Text))
			{
				MessageBox.Show("Campo autorizacion vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcantidad.Text))
			{
				MessageBox.Show("Campo cantidad vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcuenta.Text))
			{
				MessageBox.Show("Campo cuenta/tarjeta vacío");
			}
			else
			{
				DialogResult dr = MessageBox.Show("¿Está seguro de enviar ticket de deposito? Verifique información, esta acción es irreversible", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
				if (dr == DialogResult.Yes && opf.CheckFileExists)
				{
					string serie = txtserie.Text;
					string auto = txtautorizacion.Text;
					int cantidad = Convert.ToInt32(txtcantidad.Text);
					string cuenta = txtcuenta.Text;
					int personal = Convert.ToInt32(txtpersonal.Text);
					string CorrectFilename = Path.GetFileName(opf.FileName.Replace("\\\\", "\\"));
					Directory.CreateDirectory(("Base de datos\\Ventas\\Depositos\\" + cuenta + "\\" + auto + "\\" + serie) ?? "");
					string ruta = "\\\\Base de datos\\\\Ventas\\\\Depositos\\\\" + cuenta + "\\\\" + auto + "\\\\" + serie + "\\\\";
					string paths = Application.StartupPath;
					File.Copy(opf.FileName, paths + ruta + CorrectFilename);
					conn.Open();
					string query = "insert into depositos (autorizacion,cuenta,cantidad,imagen,serie,id_personal) values('" + auto + "','" + cuenta + "','" + cantidad + "','" + ruta + CorrectFilename + "','" + serie + "','" + personal + "' )";
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
					string descuento = "UPDATE ventas_tv SET estado = 'Depositado' ,fecha_egreso =CURRENT_TIMESTAMP WHERE serie ='" + serie + "'";
					MySqlCommand cmd_descuento = new MySqlCommand(descuento, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_descuento.ExecuteReader();
						MessageBox.Show("Ticket de pago registrado exitosamente");
						conn.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtautorizacion = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtserie = new System.Windows.Forms.TextBox();
            this.txtpersonal = new System.Windows.Forms.TextBox();
            this.txtidfolio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 24);
            this.label2.TabIndex = 47;
            this.label2.Text = "Confirmación de pago por deposito";
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
            this.txtautorizacion.Location = new System.Drawing.Point(773, 170);
            this.txtautorizacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtautorizacion.Name = "txtautorizacion";
            this.txtautorizacion.Size = new System.Drawing.Size(181, 20);
            this.txtautorizacion.TabIndex = 49;
            this.txtautorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtcantidad.Location = new System.Drawing.Point(773, 262);
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
            this.label3.Location = new System.Drawing.Point(605, 168);
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
            this.label4.Location = new System.Drawing.Point(605, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Cantidad depositada:";
            // 
            // pictureBox
            // 
            this.pictureBox.InitialImage = null;
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
            this.button4.Image = global::Electronica.Properties.Resources.tick_inside_circle;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(837, 600);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 45;
            this.button4.Text = "         Enviar deposito";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(206)))), ((int)(((byte)(220)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Electronica.Properties.Resources.photo_camera;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(229, 600);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 35);
            this.button3.TabIndex = 44;
            this.button3.Text = "         Imagen del ticket";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtserie
            // 
            this.txtserie.BackColor = System.Drawing.SystemColors.Window;
            this.txtserie.Location = new System.Drawing.Point(533, 32);
            this.txtserie.Margin = new System.Windows.Forms.Padding(2);
            this.txtserie.Name = "txtserie";
            this.txtserie.ReadOnly = true;
            this.txtserie.Size = new System.Drawing.Size(90, 20);
            this.txtserie.TabIndex = 53;
            this.txtserie.Visible = false;
            // 
            // txtpersonal
            // 
            this.txtpersonal.BackColor = System.Drawing.SystemColors.Window;
            this.txtpersonal.Location = new System.Drawing.Point(652, 32);
            this.txtpersonal.Margin = new System.Windows.Forms.Padding(2);
            this.txtpersonal.Name = "txtpersonal";
            this.txtpersonal.ReadOnly = true;
            this.txtpersonal.Size = new System.Drawing.Size(66, 20);
            this.txtpersonal.TabIndex = 54;
            this.txtpersonal.Visible = false;
            // 
            // txtidfolio
            // 
            this.txtidfolio.BackColor = System.Drawing.SystemColors.Window;
            this.txtidfolio.Location = new System.Drawing.Point(740, 32);
            this.txtidfolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtidfolio.Name = "txtidfolio";
            this.txtidfolio.ReadOnly = true;
            this.txtidfolio.Size = new System.Drawing.Size(66, 20);
            this.txtidfolio.TabIndex = 55;
            this.txtidfolio.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(605, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "# de cuenta o tarjeta";
            // 
            // txtcuenta
            // 
            this.txtcuenta.BackColor = System.Drawing.SystemColors.Window;
            this.txtcuenta.Location = new System.Drawing.Point(773, 220);
            this.txtcuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(181, 20);
            this.txtcuenta.TabIndex = 56;
            this.txtcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Recepcion_ventas_deposito_vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcuenta);
            this.Controls.Add(this.txtidfolio);
            this.Controls.Add(this.txtpersonal);
            this.Controls.Add(this.txtserie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.txtautorizacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Recepcion_ventas_deposito_vista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ordenes de Servicio";
            this.Load += new System.EventHandler(this.Taller_actualizar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recepcion_ventas_deposito_vista_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Recepcion_ventas_deposito_vista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
