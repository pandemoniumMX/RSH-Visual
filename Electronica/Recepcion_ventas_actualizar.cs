using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Recepcion_ventas_actualizar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private OpenFileDialog opf = new OpenFileDialog();

		private Recepcion rp = new Recepcion();

		private IContainer components = null;

		public TextBox txtcosto;

		private Label label8;

		public TextBox txtserie;

		public TextBox txtmarca;

		private Button button4;

		private Button button2;

		private Button button1;

		public PictureBox pictureBox3;

		public PictureBox pictureBox2;

		private Label label10;

		public PictureBox pictureBox1;

		private Button btngenerar;

		private Label label7;

		public TextBox txtmodelo;

		private Label label3;

		private Label label2;

		private Label label1;

		public TextBox txtvendedor;

		private Label label4;

		public Recepcion_ventas_actualizar()
		{
			InitializeComponent();
		}

		public void btngenerar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtmarca.Text))
			{
				MessageBox.Show("Campo marca vacío");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(txtserie.Text))
			{
				MessageBox.Show("Campo serie vacío");
			}
			if (string.IsNullOrWhiteSpace(txtcosto.Text))
			{
				MessageBox.Show("Campo costo vació");
			}
			if (string.IsNullOrWhiteSpace(txtvendedor.Text))
			{
				MessageBox.Show("Campo ID usuario vació");
			}
			else
			{
				DialogResult dr = MessageBox.Show("¿Confirma la venta de la television? Verifique la información, esta acción es irreversible", "Alerta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
				if (dr == DialogResult.Yes && opf.CheckFileExists)
				{
					string modelos = txtmodelo.Text;
					string marcas = txtmarca.Text;
					string serie = txtserie.Text;
					int vendedor = Convert.ToInt32(txtvendedor.Text);
					string query_insertar_televisor = "UPDATE ventas_tv set estado='Vendida', idvendedor='" + vendedor + "' where serie='" + serie + "'";
					MySqlCommand cmd_query_insertar_televisor = new MySqlCommand(query_insertar_televisor, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_query_insertar_televisor.ExecuteReader();
						MessageBox.Show("Felicidades vendiste Televisión marca " + marcas);
						conn.Close();
						Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private void txtetiqueta1_TextChanged(object sender, EventArgs e)
		{
		}

		private void combofalla_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void comboaccesorios_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void txtetiqueta2_TextChanged(object sender, EventArgs e)
		{
		}

		private void RecepcionTelevisores_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			opf.InitialDirectory = "C:\\Users";
			opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf.FilterIndex = 1;
			if (opf.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(opf.FileName);
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf.CheckFileExists)
			{
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			opf.InitialDirectory = "C:\\Users";
			opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf.FilterIndex = 1;
			if (opf.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.Image = Image.FromFile(opf.FileName);
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf.CheckFileExists)
			{
				return;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			opf.InitialDirectory = "C:\\Users";
			opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf.FilterIndex = 1;
			if (opf.ShowDialog() == DialogResult.OK)
			{
				pictureBox3.Image = Image.FromFile(opf.FileName);
				pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf.CheckFileExists)
			{
				return;
			}
		}

		private void combopartes_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void txtcosto_KeyPress(object sender, KeyPressEventArgs v)
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

		private void txtcosto_TextChanged(object sender, EventArgs e)
		{
		}

		public void button3_Click(object sender, EventArgs e)
		{
			int costo = Convert.ToInt32(txtcosto.Text);
			string modelos = txtmodelo.Text;
			string marcas = txtmarca.Text;
			string serie = txtserie.Text;
			string ruta = ("\\Base de datos\\Ventas de televisiones\\Recepcion\\" + marcas + "\\" + modelos + "\\" + serie) ?? "";
			string paths = Application.StartupPath;
			Process.Start(paths + ruta);
		}

		private void txtvendedor_KeyPress(object sender, KeyPressEventArgs v)
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
			txtcosto = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtserie = new System.Windows.Forms.TextBox();
			txtmarca = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			txtmodelo = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtvendedor = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btngenerar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			txtcosto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtcosto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcosto.Location = new System.Drawing.Point(809, 72);
			txtcosto.Margin = new System.Windows.Forms.Padding(2);
			txtcosto.Name = "txtcosto";
			txtcosto.ReadOnly = true;
			txtcosto.Size = new System.Drawing.Size(142, 26);
			txtcosto.TabIndex = 58;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(755, 75);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(55, 20);
			label8.TabIndex = 57;
			label8.Text = "Costo:";
			txtserie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtserie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtserie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtserie.Location = new System.Drawing.Point(593, 72);
			txtserie.Margin = new System.Windows.Forms.Padding(2);
			txtserie.Name = "txtserie";
			txtserie.ReadOnly = true;
			txtserie.Size = new System.Drawing.Size(142, 26);
			txtserie.TabIndex = 56;
			txtmarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtmarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtmarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmarca.Location = new System.Drawing.Point(158, 72);
			txtmarca.Margin = new System.Windows.Forms.Padding(2);
			txtmarca.Name = "txtmarca";
			txtmarca.ReadOnly = true;
			txtmarca.Size = new System.Drawing.Size(136, 26);
			txtmarca.TabIndex = 55;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Location = new System.Drawing.Point(836, 428);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(191, 34);
			button4.TabIndex = 54;
			button4.Text = "Cargar Imagen #3";
			button4.UseVisualStyleBackColor = true;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Location = new System.Drawing.Point(465, 428);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(191, 34);
			button2.TabIndex = 53;
			button2.Text = "Cargar Imagen #2";
			button2.UseVisualStyleBackColor = true;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Location = new System.Drawing.Point(103, 428);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(191, 34);
			button1.TabIndex = 52;
			button1.Text = "Cargar Imagen #1";
			button1.UseVisualStyleBackColor = true;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(23, 132);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(93, 20);
			label10.TabIndex = 49;
			label10.Text = "Imagenes:";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(319, 75);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(65, 20);
			label7.TabIndex = 45;
			label7.Text = "Modelo:";
			txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmodelo.Location = new System.Drawing.Point(388, 72);
			txtmodelo.Margin = new System.Windows.Forms.Padding(2);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.ReadOnly = true;
			txtmodelo.Size = new System.Drawing.Size(147, 26);
			txtmodelo.TabIndex = 44;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(539, 75);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(50, 20);
			label3.TabIndex = 43;
			label3.Text = "Serie:";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(97, 75);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(57, 20);
			label2.TabIndex = 42;
			label2.Text = "Marca:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(21, 23);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(285, 25);
			label1.TabIndex = 41;
			label1.Text = "Nueva television en venta";
			txtvendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtvendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtvendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtvendedor.Location = new System.Drawing.Point(998, 24);
			txtvendedor.Margin = new System.Windows.Forms.Padding(2);
			txtvendedor.Name = "txtvendedor";
			txtvendedor.Size = new System.Drawing.Size(84, 26);
			txtvendedor.TabIndex = 60;
			txtvendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtvendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtvendedor_KeyPress);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(877, 27);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(108, 20);
			label4.TabIndex = 59;
			label4.Text = "ID de usuario:";
			pictureBox3.Location = new System.Drawing.Point(759, 171);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(303, 234);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 51;
			pictureBox3.TabStop = false;
			pictureBox2.Location = new System.Drawing.Point(412, 171);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(303, 234);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 50;
			pictureBox2.TabStop = false;
			pictureBox1.Location = new System.Drawing.Point(54, 171);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(303, 234);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 48;
			pictureBox1.TabStop = false;
			btngenerar.FlatAppearance.BorderSize = 0;
			btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btngenerar.Image = Electronica.Properties.Resources.tick_inside_circle;
			btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btngenerar.Location = new System.Drawing.Point(858, 535);
			btngenerar.Margin = new System.Windows.Forms.Padding(2);
			btngenerar.Name = "btngenerar";
			btngenerar.Size = new System.Drawing.Size(191, 49);
			btngenerar.TabIndex = 46;
			btngenerar.Text = "   Vendida";
			btngenerar.UseVisualStyleBackColor = true;
			btngenerar.Click += new System.EventHandler(btngenerar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(txtvendedor);
			base.Controls.Add(label4);
			base.Controls.Add(txtcosto);
			base.Controls.Add(label8);
			base.Controls.Add(txtserie);
			base.Controls.Add(txtmarca);
			base.Controls.Add(button4);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(pictureBox3);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(label10);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(btngenerar);
			base.Controls.Add(label7);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Recepcion_ventas_actualizar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "RecepcionTelevisores";
			base.Load += new System.EventHandler(RecepcionTelevisores_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
