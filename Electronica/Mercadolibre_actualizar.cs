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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mercadolibre_actualizar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combomarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtetiqueta1 = new System.Windows.Forms.TextBox();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combocantidad = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtetiqueta2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btngenerar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboalmacen = new System.Windows.Forms.ComboBox();
            this.txtrefacciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcosto = new System.Windows.Forms.TextBox();
            this.comboestado = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.combopartes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nueva Publicacion en MercadoLibre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de pieza:";
            // 
            // combomarca
            // 
            this.combomarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combomarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combomarca.FormattingEnabled = true;
            this.combomarca.Items.AddRange(new object[] {
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
            "Otras"});
            this.combomarca.Location = new System.Drawing.Point(578, 36);
            this.combomarca.Margin = new System.Windows.Forms.Padding(2);
            this.combomarca.Name = "combomarca";
            this.combomarca.Size = new System.Drawing.Size(137, 28);
            this.combomarca.TabIndex = 3;
            this.combomarca.SelectedIndexChanged += new System.EventHandler(this.combofalla_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(504, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(284, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Etiqueta #1:";
            // 
            // txtetiqueta1
            // 
            this.txtetiqueta1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtetiqueta1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtetiqueta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtetiqueta1.Location = new System.Drawing.Point(382, 87);
            this.txtetiqueta1.Margin = new System.Windows.Forms.Padding(2);
            this.txtetiqueta1.Name = "txtetiqueta1";
            this.txtetiqueta1.Size = new System.Drawing.Size(118, 26);
            this.txtetiqueta1.TabIndex = 9;
            this.txtetiqueta1.TextChanged += new System.EventHandler(this.txtetiqueta1_TextChanged);
            // 
            // txtmodelo
            // 
            this.txtmodelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtmodelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodelo.Location = new System.Drawing.Point(353, 41);
            this.txtmodelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.Size = new System.Drawing.Size(105, 26);
            this.txtmodelo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(284, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Modelo:";
            // 
            // combocantidad
            // 
            this.combocantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combocantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combocantidad.FormattingEnabled = true;
            this.combocantidad.Items.AddRange(new object[] {
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
            "20"});
            this.combocantidad.Location = new System.Drawing.Point(812, 36);
            this.combocantidad.Margin = new System.Windows.Forms.Padding(2);
            this.combocantidad.Name = "combocantidad";
            this.combocantidad.Size = new System.Drawing.Size(92, 28);
            this.combocantidad.TabIndex = 12;
            this.combocantidad.SelectedIndexChanged += new System.EventHandler(this.comboaccesorios_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(731, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Cantidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 134);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Estado actual:";
            // 
            // txtetiqueta2
            // 
            this.txtetiqueta2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtetiqueta2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtetiqueta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtetiqueta2.Location = new System.Drawing.Point(603, 87);
            this.txtetiqueta2.Margin = new System.Windows.Forms.Padding(2);
            this.txtetiqueta2.Name = "txtetiqueta2";
            this.txtetiqueta2.Size = new System.Drawing.Size(112, 26);
            this.txtetiqueta2.TabIndex = 16;
            this.txtetiqueta2.TextChanged += new System.EventHandler(this.txtetiqueta2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(504, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Etiqueta #2:";
            // 
            // btngenerar
            // 
            this.btngenerar.FlatAppearance.BorderSize = 0;
            this.btngenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerar.Image = global::Electronica.Properties.Resources._003_refresh_button1;
            this.btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerar.Location = new System.Drawing.Point(842, 476);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(191, 49);
            this.btngenerar.TabIndex = 20;
            this.btngenerar.Text = "   Actualizar Pieza";
            this.btngenerar.UseVisualStyleBackColor = true;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 89);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Almacen:";
            // 
            // comboalmacen
            // 
            this.comboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboalmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboalmacen.FormattingEnabled = true;
            this.comboalmacen.Items.AddRange(new object[] {
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
            "50"});
            this.comboalmacen.Location = new System.Drawing.Point(123, 85);
            this.comboalmacen.Margin = new System.Windows.Forms.Padding(2);
            this.comboalmacen.Name = "comboalmacen";
            this.comboalmacen.Size = new System.Drawing.Size(140, 28);
            this.comboalmacen.TabIndex = 22;
            // 
            // txtrefacciones
            // 
            this.txtrefacciones.Location = new System.Drawing.Point(925, 11);
            this.txtrefacciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtrefacciones.Name = "txtrefacciones";
            this.txtrefacciones.Size = new System.Drawing.Size(76, 20);
            this.txtrefacciones.TabIndex = 23;
            this.txtrefacciones.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(284, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Costo:";
            // 
            // txtcosto
            // 
            this.txtcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcosto.Location = new System.Drawing.Point(366, 131);
            this.txtcosto.Name = "txtcosto";
            this.txtcosto.Size = new System.Drawing.Size(92, 26);
            this.txtcosto.TabIndex = 26;
            this.txtcosto.TextChanged += new System.EventHandler(this.txtcosto_TextChanged);
            this.txtcosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcosto_KeyPress);
            // 
            // comboestado
            // 
            this.comboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboestado.FormattingEnabled = true;
            this.comboestado.Items.AddRange(new object[] {
            "Publicada",
            "No publicada",
            "Perdida",
            "Detalle",
            "Vendida"});
            this.comboestado.Location = new System.Drawing.Point(127, 131);
            this.comboestado.Margin = new System.Windows.Forms.Padding(2);
            this.comboestado.Name = "comboestado";
            this.comboestado.Size = new System.Drawing.Size(136, 28);
            this.comboestado.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 180);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Imagenes:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(214, 201);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(191, 180);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(422, 201);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(191, 180);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(631, 201);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(191, 180);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(842, 201);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(191, 180);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(7, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 34);
            this.button1.TabIndex = 34;
            this.button1.Text = "Cargar Imagen #1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(214, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 34);
            this.button2.TabIndex = 35;
            this.button2.Text = "Cargar Imagen #2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(631, 406);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 34);
            this.button3.TabIndex = 37;
            this.button3.Text = "Cargar Imagen #4";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(422, 406);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 34);
            this.button4.TabIndex = 36;
            this.button4.Text = "Cargar Imagen #3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(842, 406);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 34);
            this.button5.TabIndex = 38;
            this.button5.Text = "Cargar Imagen #5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // combopartes
            // 
            this.combopartes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combopartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combopartes.FormattingEnabled = true;
            this.combopartes.Items.AddRange(new object[] {
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
            "Led Driver"});
            this.combopartes.Location = new System.Drawing.Point(123, 41);
            this.combopartes.Margin = new System.Windows.Forms.Padding(2);
            this.combopartes.Name = "combopartes";
            this.combopartes.Size = new System.Drawing.Size(140, 28);
            this.combopartes.TabIndex = 39;
            this.combopartes.SelectedIndexChanged += new System.EventHandler(this.combopartes_SelectedIndexChanged);
            // 
            // Mercadolibre_actualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 702);
            this.Controls.Add(this.combopartes);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboestado);
            this.Controls.Add(this.txtcosto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtrefacciones);
            this.Controls.Add(this.comboalmacen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtetiqueta2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combocantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.txtetiqueta1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combomarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(242, 35);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Mercadolibre_actualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RecepcionTelevisores";
            this.Load += new System.EventHandler(this.RecepcionTelevisores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mercadolibre_actualizar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Mercadolibre_actualizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
