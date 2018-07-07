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
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtautorizacion = new System.Windows.Forms.TextBox();
			txtcantidad = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			pictureBox = new System.Windows.Forms.PictureBox();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			txtserie = new System.Windows.Forms.TextBox();
			txtpersonal = new System.Windows.Forms.TextBox();
			txtidfolio = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtcuenta = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			SuspendLayout();
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(339, 24);
			label2.TabIndex = 47;
			label2.Text = "Confirmación de pago por deposito";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(103, 57);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(250, 20);
			label1.TabIndex = 48;
			label1.Text = "Imagen del ticket del deposito";
			txtautorizacion.BackColor = System.Drawing.SystemColors.Window;
			txtautorizacion.Location = new System.Drawing.Point(773, 170);
			txtautorizacion.Margin = new System.Windows.Forms.Padding(2);
			txtautorizacion.Name = "txtautorizacion";
			txtautorizacion.Size = new System.Drawing.Size(181, 20);
			txtautorizacion.TabIndex = 49;
			txtautorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtcantidad.BackColor = System.Drawing.SystemColors.Window;
			txtcantidad.Location = new System.Drawing.Point(773, 262);
			txtcantidad.Margin = new System.Windows.Forms.Padding(2);
			txtcantidad.Name = "txtcantidad";
			txtcantidad.Size = new System.Drawing.Size(181, 20);
			txtcantidad.TabIndex = 50;
			txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(605, 168);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(159, 20);
			label3.TabIndex = 51;
			label3.Text = "Folio de autorización:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(605, 262);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(160, 20);
			label4.TabIndex = 52;
			label4.Text = "Cantidad depositada:";
			pictureBox.Location = new System.Drawing.Point(107, 84);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new System.Drawing.Size(394, 471);
			pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox.TabIndex = 46;
			pictureBox.TabStop = false;
			button4.BackColor = System.Drawing.SystemColors.Window;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Image = Electronica.Properties.Resources.tick_inside_circle;
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(837, 600);
			button4.Margin = new System.Windows.Forms.Padding(2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(117, 35);
			button4.TabIndex = 45;
			button4.Text = "         Enviar deposito";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new System.EventHandler(button4_Click);
			button3.BackColor = System.Drawing.SystemColors.Window;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(111, 206, 220);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Image = Electronica.Properties.Resources.photo_camera;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(229, 600);
			button3.Margin = new System.Windows.Forms.Padding(2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(124, 35);
			button3.TabIndex = 44;
			button3.Text = "         Imagen del ticket";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click);
			txtserie.BackColor = System.Drawing.SystemColors.Window;
			txtserie.Location = new System.Drawing.Point(533, 32);
			txtserie.Margin = new System.Windows.Forms.Padding(2);
			txtserie.Name = "txtserie";
			txtserie.ReadOnly = true;
			txtserie.Size = new System.Drawing.Size(90, 20);
			txtserie.TabIndex = 53;
			txtserie.Visible = false;
			txtpersonal.BackColor = System.Drawing.SystemColors.Window;
			txtpersonal.Location = new System.Drawing.Point(652, 32);
			txtpersonal.Margin = new System.Windows.Forms.Padding(2);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.ReadOnly = true;
			txtpersonal.Size = new System.Drawing.Size(66, 20);
			txtpersonal.TabIndex = 54;
			txtpersonal.Visible = false;
			txtidfolio.BackColor = System.Drawing.SystemColors.Window;
			txtidfolio.Location = new System.Drawing.Point(740, 32);
			txtidfolio.Margin = new System.Windows.Forms.Padding(2);
			txtidfolio.Name = "txtidfolio";
			txtidfolio.ReadOnly = true;
			txtidfolio.Size = new System.Drawing.Size(66, 20);
			txtidfolio.TabIndex = 55;
			txtidfolio.Visible = false;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(605, 218);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(155, 20);
			label5.TabIndex = 57;
			label5.Text = "# de cuenta o tarjeta";
			txtcuenta.BackColor = System.Drawing.SystemColors.Window;
			txtcuenta.Location = new System.Drawing.Point(773, 220);
			txtcuenta.Margin = new System.Windows.Forms.Padding(2);
			txtcuenta.Name = "txtcuenta";
			txtcuenta.Size = new System.Drawing.Size(181, 20);
			txtcuenta.TabIndex = 56;
			txtcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(label5);
			base.Controls.Add(txtcuenta);
			base.Controls.Add(txtidfolio);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(txtserie);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(txtcantidad);
			base.Controls.Add(txtautorizacion);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(pictureBox);
			base.Controls.Add(button4);
			base.Controls.Add(button3);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Recepcion_ventas_deposito_vista";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Ordenes de Servicio";
			base.Load += new System.EventHandler(Taller_actualizar_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
