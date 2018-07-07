using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Electronica
{
	public class Mercadolibre_actualizar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private OpenFileDialog opf = new OpenFileDialog();

		private OpenFileDialog opf2 = new OpenFileDialog();

		private OpenFileDialog opf3 = new OpenFileDialog();

		private OpenFileDialog opf4 = new OpenFileDialog();

		private OpenFileDialog opf5 = new OpenFileDialog();

		private Recepcion rp = new Recepcion();

		private IContainer components = null;

		private Label label1;

		private Label label2;

		public ComboBox combomarca;

		private Label label3;

		private Label label6;

		public TextBox txtetiqueta1;

		public TextBox txtmodelo;

		private Label label7;

		public ComboBox combocantidad;

		private Label label8;

		private Label label9;

		public TextBox txtetiqueta2;

		private Label label4;

		private Button btngenerar;

		private Label label11;

		public ComboBox comboalmacen;

		public TextBox txtrefacciones;

		private Label label5;

		public TextBox txtcosto;

		public PictureBox pictureBox1;

		private Label label10;

		public PictureBox pictureBox2;

		public PictureBox pictureBox3;

		public PictureBox pictureBox4;

		public PictureBox pictureBox5;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private Button button5;

		public ComboBox combopartes;

		public ComboBox comboestado;

		public Mercadolibre_actualizar()
		{
			InitializeComponent();
		}

		private void btngenerar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(combopartes.Text))
			{
				MessageBox.Show("Campo tipo de pieza no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtmodelo.Text))
			{
				MessageBox.Show("Campo modelo vacío");
			}
			if (string.IsNullOrWhiteSpace(combomarca.Text))
			{
				MessageBox.Show("Campo marca no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(combocantidad.Text))
			{
				MessageBox.Show("Campo cantidad no seleccionada");
			}
			if (string.IsNullOrWhiteSpace(comboalmacen.Text))
			{
				MessageBox.Show("Campo almacen no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtetiqueta1.Text))
			{
				MessageBox.Show("Campo etiqueta 1 vacía");
			}
			if (string.IsNullOrWhiteSpace(txtetiqueta2.Text))
			{
				MessageBox.Show("Campo etiqueta 2 vacía");
			}
			if (string.IsNullOrWhiteSpace(comboestado.Text))
			{
				MessageBox.Show("Campo estado no seleccionado");
			}
			if (string.IsNullOrWhiteSpace(txtcosto.Text))
			{
				MessageBox.Show("Campo costo vacío");
			}
			else
			{
				DialogResult dr = MessageBox.Show("¿Está seguro de enviar la información anterior? Verifique la información, esta acción es irreversible", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
				if (dr == DialogResult.Yes && opf.CheckFileExists)
				{
					int almacen = Convert.ToInt32(comboalmacen.SelectedItem.ToString());
					int cantidad = Convert.ToInt32(combocantidad.SelectedItem.ToString());
					string pieza = combopartes.SelectedItem.ToString();
					string marcas = combomarca.SelectedItem.ToString();
					string estado = comboestado.SelectedItem.ToString();
					int precio = Convert.ToInt32(txtcosto.Text);
					string etiqueta_3 = txtetiqueta1.Text;
					string etiqueta_2 = txtetiqueta2.Text;
					int id_refacciones = Convert.ToInt32(txtrefacciones.Text);
					string modelos = txtmodelo.Text;
					string CorrectFilename9 = Path.GetFileName(opf.FileName.Replace("\\\\", "\\"));
					string CorrectFilename8 = Path.GetFileName(opf2.FileName.Replace("\\\\", "\\"));
					string CorrectFilename7 = Path.GetFileName(opf3.FileName.Replace("\\\\", "\\"));
					string CorrectFilename6 = Path.GetFileName(opf4.FileName.Replace("\\\\", "\\"));
					string CorrectFilename5 = Path.GetFileName(opf5.FileName.Replace("\\\\", "\\"));
					Directory.CreateDirectory(("Base de datos\\Publicaciones Mercadolibre\\Almacen\\" + almacen + "\\" + marcas + "\\" + modelos + "\\" + etiqueta_3 + "\\" + etiqueta_2) ?? "");
					string ruta = "\\\\Base de datos\\\\Publicaciones Mercadolibre\\\\Almacen\\\\" + almacen + "\\\\" + marcas + "\\\\" + modelos + "\\\\" + etiqueta_3 + "\\\\" + etiqueta_2 + "\\\\";
					string paths = Application.StartupPath;
					string query_insertar_televisor = "update refacciones_tv set pieza='" + pieza + "', marcas='" + marcas + "', modelos='" + modelos + "', cantidad='" + cantidad + "', almacen='" + almacen + "', estado='" + estado + "' ,precio='" + precio + "', etiqueta_1='" + etiqueta_3 + "', etiqueta_2='" + etiqueta_2 + "' where id_refacciones='" + id_refacciones + "'";
					MySqlCommand cmd_query_insertar_televisor = new MySqlCommand(query_insertar_televisor, conn);
					try
					{
						conn.Open();
						MySqlDataReader leercomando = cmd_query_insertar_televisor.ExecuteReader();
						MessageBox.Show("Refacción actualizada correctamente");
						conn.Close();
						Close();
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message);
					}
					try
					{
						conn.Open();
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
			opf2.InitialDirectory = "C:\\Users";
			opf2.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf2.FilterIndex = 1;
			if (opf2.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.Image = Image.FromFile(opf2.FileName);
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf2.CheckFileExists)
			{
				return;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			opf3.InitialDirectory = "C:\\Users";
			opf3.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf3.FilterIndex = 1;
			if (opf3.ShowDialog() == DialogResult.OK)
			{
				pictureBox3.Image = Image.FromFile(opf3.FileName);
				pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf3.CheckFileExists)
			{
				return;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			opf4.InitialDirectory = "C:\\Users";
			opf4.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf4.FilterIndex = 1;
			if (opf4.ShowDialog() == DialogResult.OK)
			{
				pictureBox4.Image = Image.FromFile(opf4.FileName);
				pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf4.CheckFileExists)
			{
				return;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			opf5.InitialDirectory = "C:\\Users";
			opf5.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
			opf5.FilterIndex = 1;
			if (opf5.ShowDialog() == DialogResult.OK)
			{
				pictureBox5.Image = Image.FromFile(opf5.FileName);
				pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (!opf5.CheckFileExists)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electronica.Mercadolibre_actualizar));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			combomarca = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtetiqueta1 = new System.Windows.Forms.TextBox();
			txtmodelo = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			combocantidad = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtetiqueta2 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			btngenerar = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			comboalmacen = new System.Windows.Forms.ComboBox();
			txtrefacciones = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtcosto = new System.Windows.Forms.TextBox();
			comboestado = new System.Windows.Forms.ComboBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label10 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			pictureBox5 = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			combopartes = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(10, 11);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(294, 20);
			label1.TabIndex = 0;
			label1.Text = "Nueva Publicacion en MercadoLibre";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 44);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(107, 20);
			label2.TabIndex = 1;
			label2.Text = "Tipo de pieza:";
			combomarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combomarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combomarca.FormattingEnabled = true;
			combomarca.Items.AddRange(new object[26]
			{
				"AOC",
				"Blu Sens",
				"Blue Point",
				"Cobia",
				"Hisense",
				"LG",
				"Panasonic",
				"Philips",
				"Pioneer",
				"Polaroid",
				"Magnavox",
				"RCA",
				"Samsung",
				"Sanyo",
				"Sharp",
				"Speeler",
				"Spectra",
				"Sony Bravia",
				"Toshiba",
				"TCL",
				"Vech Technics",
				"Vizio",
				"Vios",
				"Viore",
				"White Westin House",
				"Otras"
			});
			combomarca.Location = new System.Drawing.Point(578, 36);
			combomarca.Margin = new System.Windows.Forms.Padding(2);
			combomarca.Name = "combomarca";
			combomarca.Size = new System.Drawing.Size(137, 28);
			combomarca.TabIndex = 3;
			combomarca.SelectedIndexChanged += new System.EventHandler(combofalla_SelectedIndexChanged);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(504, 39);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(57, 20);
			label3.TabIndex = 5;
			label3.Text = "Marca:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(284, 89);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(95, 20);
			label6.TabIndex = 8;
			label6.Text = "Etiqueta #1:";
			txtetiqueta1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtetiqueta1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtetiqueta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtetiqueta1.Location = new System.Drawing.Point(382, 87);
			txtetiqueta1.Margin = new System.Windows.Forms.Padding(2);
			txtetiqueta1.Name = "txtetiqueta1";
			txtetiqueta1.Size = new System.Drawing.Size(118, 26);
			txtetiqueta1.TabIndex = 9;
			txtetiqueta1.TextChanged += new System.EventHandler(txtetiqueta1_TextChanged);
			txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmodelo.Location = new System.Drawing.Point(353, 41);
			txtmodelo.Margin = new System.Windows.Forms.Padding(2);
			txtmodelo.Name = "txtmodelo";
			txtmodelo.Size = new System.Drawing.Size(105, 26);
			txtmodelo.TabIndex = 10;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(284, 44);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(65, 20);
			label7.TabIndex = 11;
			label7.Text = "Modelo:";
			combocantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combocantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combocantidad.FormattingEnabled = true;
			combocantidad.Items.AddRange(new object[20]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"10",
				"11",
				"12",
				"13",
				"14",
				"15",
				"16",
				"17",
				"18",
				"19",
				"20"
			});
			combocantidad.Location = new System.Drawing.Point(812, 36);
			combocantidad.Margin = new System.Windows.Forms.Padding(2);
			combocantidad.Name = "combocantidad";
			combocantidad.Size = new System.Drawing.Size(92, 28);
			combocantidad.TabIndex = 12;
			combocantidad.SelectedIndexChanged += new System.EventHandler(comboaccesorios_SelectedIndexChanged);
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(731, 39);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(77, 20);
			label8.TabIndex = 13;
			label8.Text = "Cantidad:";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(12, 134);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(111, 20);
			label9.TabIndex = 14;
			label9.Text = "Estado actual:";
			txtetiqueta2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			txtetiqueta2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			txtetiqueta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtetiqueta2.Location = new System.Drawing.Point(603, 87);
			txtetiqueta2.Margin = new System.Windows.Forms.Padding(2);
			txtetiqueta2.Name = "txtetiqueta2";
			txtetiqueta2.Size = new System.Drawing.Size(112, 26);
			txtetiqueta2.TabIndex = 16;
			txtetiqueta2.TextChanged += new System.EventHandler(txtetiqueta2_TextChanged);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(504, 90);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(95, 20);
			label4.TabIndex = 17;
			label4.Text = "Etiqueta #2:";
			btngenerar.FlatAppearance.BorderSize = 0;
			btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btngenerar.Image = Electronica.Properties.Resources._003_refresh_button1;
			btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btngenerar.Location = new System.Drawing.Point(842, 476);
			btngenerar.Margin = new System.Windows.Forms.Padding(2);
			btngenerar.Name = "btngenerar";
			btngenerar.Size = new System.Drawing.Size(191, 49);
			btngenerar.TabIndex = 20;
			btngenerar.Text = "   Actualizar Pieza";
			btngenerar.UseVisualStyleBackColor = true;
			btngenerar.Click += new System.EventHandler(btngenerar_Click);
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(12, 89);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(75, 20);
			label11.TabIndex = 21;
			label11.Text = "Almacen:";
			comboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboalmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboalmacen.FormattingEnabled = true;
			comboalmacen.Items.AddRange(new object[50]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"10",
				"11",
				"12",
				"13",
				"14",
				"15",
				"16",
				"17",
				"18",
				"19",
				"20",
				"21",
				"22",
				"23",
				"24",
				"25",
				"26",
				"27",
				"28",
				"29",
				"30",
				"31",
				"32",
				"33",
				"34",
				"35",
				"36",
				"37",
				"38",
				"39",
				"40",
				"41",
				"42",
				"43",
				"44",
				"45",
				"46",
				"47",
				"48",
				"49",
				"50"
			});
			comboalmacen.Location = new System.Drawing.Point(123, 85);
			comboalmacen.Margin = new System.Windows.Forms.Padding(2);
			comboalmacen.Name = "comboalmacen";
			comboalmacen.Size = new System.Drawing.Size(140, 28);
			comboalmacen.TabIndex = 22;
			txtrefacciones.Location = new System.Drawing.Point(925, 11);
			txtrefacciones.Margin = new System.Windows.Forms.Padding(2);
			txtrefacciones.Name = "txtrefacciones";
			txtrefacciones.Size = new System.Drawing.Size(76, 20);
			txtrefacciones.TabIndex = 23;
			txtrefacciones.Visible = false;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(284, 134);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(55, 20);
			label5.TabIndex = 25;
			label5.Text = "Costo:";
			txtcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcosto.Location = new System.Drawing.Point(366, 131);
			txtcosto.Name = "txtcosto";
			txtcosto.Size = new System.Drawing.Size(92, 26);
			txtcosto.TabIndex = 26;
			txtcosto.TextChanged += new System.EventHandler(txtcosto_TextChanged);
			txtcosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcosto_KeyPress);
			comboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboestado.FormattingEnabled = true;
			comboestado.Items.AddRange(new object[5]
			{
				"Publicada",
				"No publicada",
				"Perdida",
				"Detalle",
				"Vendida"
			});
			comboestado.Location = new System.Drawing.Point(127, 131);
			comboestado.Margin = new System.Windows.Forms.Padding(2);
			comboestado.Name = "comboestado";
			comboestado.Size = new System.Drawing.Size(136, 28);
			comboestado.TabIndex = 27;
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.Location = new System.Drawing.Point(7, 201);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(191, 180);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 28;
			pictureBox1.TabStop = false;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(12, 180);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(93, 20);
			label10.TabIndex = 29;
			label10.Text = "Imagenes:";
			pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.Location = new System.Drawing.Point(214, 201);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(191, 180);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 30;
			pictureBox2.TabStop = false;
			pictureBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox3.BackgroundImage");
			pictureBox3.Location = new System.Drawing.Point(422, 201);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(191, 180);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 31;
			pictureBox3.TabStop = false;
			pictureBox4.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox4.BackgroundImage");
			pictureBox4.Location = new System.Drawing.Point(631, 201);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(191, 180);
			pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox4.TabIndex = 32;
			pictureBox4.TabStop = false;
			pictureBox5.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox5.BackgroundImage");
			pictureBox5.Location = new System.Drawing.Point(842, 201);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new System.Drawing.Size(191, 180);
			pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox5.TabIndex = 33;
			pictureBox5.TabStop = false;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Location = new System.Drawing.Point(7, 406);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(191, 34);
			button1.TabIndex = 34;
			button1.Text = "Cargar Imagen #1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Location = new System.Drawing.Point(214, 406);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(191, 34);
			button2.TabIndex = 35;
			button2.Text = "Cargar Imagen #2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Location = new System.Drawing.Point(631, 406);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(191, 34);
			button3.TabIndex = 37;
			button3.Text = "Cargar Imagen #4";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Location = new System.Drawing.Point(422, 406);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(191, 34);
			button4.TabIndex = 36;
			button4.Text = "Cargar Imagen #3";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button5.Location = new System.Drawing.Point(842, 406);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(191, 34);
			button5.TabIndex = 38;
			button5.Text = "Cargar Imagen #5";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			combopartes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combopartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combopartes.FormattingEnabled = true;
			combopartes.Items.AddRange(new object[16]
			{
				"Tarjeta Main",
				"Fuente de poder",
				"T-con",
				"Modulo Wi-fi",
				"Modulo Bluetooth",
				"Botonera/Joystick",
				"Leds",
				"Bocinas",
				"Y-sus",
				"Z-sus",
				"X-sus",
				"Tarjeta Logica",
				"Tarjeta de Video",
				"Procesadora de Audio",
				"BackLight Inverter",
				"Led Driver"
			});
			combopartes.Location = new System.Drawing.Point(123, 41);
			combopartes.Margin = new System.Windows.Forms.Padding(2);
			combopartes.Name = "combopartes";
			combopartes.Size = new System.Drawing.Size(140, 28);
			combopartes.TabIndex = 39;
			combopartes.SelectedIndexChanged += new System.EventHandler(combopartes_SelectedIndexChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1104, 702);
			base.Controls.Add(combopartes);
			base.Controls.Add(button5);
			base.Controls.Add(button3);
			base.Controls.Add(button4);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(pictureBox5);
			base.Controls.Add(pictureBox4);
			base.Controls.Add(pictureBox3);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(label10);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(comboestado);
			base.Controls.Add(txtcosto);
			base.Controls.Add(label5);
			base.Controls.Add(txtrefacciones);
			base.Controls.Add(comboalmacen);
			base.Controls.Add(label11);
			base.Controls.Add(btngenerar);
			base.Controls.Add(label4);
			base.Controls.Add(txtetiqueta2);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(combocantidad);
			base.Controls.Add(label7);
			base.Controls.Add(txtmodelo);
			base.Controls.Add(txtetiqueta1);
			base.Controls.Add(label6);
			base.Controls.Add(label3);
			base.Controls.Add(combomarca);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(242, 35);
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "Mercadolibre_actualizar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "RecepcionTelevisores";
			base.Load += new System.EventHandler(RecepcionTelevisores_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
