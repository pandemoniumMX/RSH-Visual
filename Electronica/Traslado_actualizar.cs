using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Traslado_actualizar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		private Label label1;

		private Label label3;

		public TextBox txtdireccion;

		private Button button1;

		public TextBox txtfolio;

		public TextBox txtcomentarios;

		private Label label2;

		public TextBox txtidtraslado;

		private Label label4;

		private Label label5;

		private Label label6;

		public TextBox txtfecha;

		public TextBox txtpersonal;

		private Label label7;

		public TextBox txtcarro;

		private Label label8;

		public ComboBox comboestado;

		private Label label9;

		private Button button2;

		private Label label10;

		public ComboBox comboubicacion;

		public ComboBox combodestino;

		public Traslado_actualizar()
		{
			InitializeComponent();
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
			if (string.IsNullOrWhiteSpace(txtdireccion.Text))
			{
				MessageBox.Show("No puede dejar el campo direccion vacío");
			}
			else
			{
				int folio = Convert.ToInt32(txtfolio.Text);
				string direccion = txtdireccion.Text;
				string coment = txtcomentarios.Text;
				string ubi = comboubicacion.SelectedItem.ToString();
				string des = combodestino.SelectedItem.ToString();
				int idtras = Convert.ToInt32(txtidtraslado.Text);
				string query = "update traslado set direccion='" + direccion + "', comentarios='" + coment + "', destino='" + des + "', ubicacion='" + ubi + "' where id_traslado='" + idtras + "'";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					conn.Open();
					MySqlDataReader leer = cmd_query.ExecuteReader();
					MessageBox.Show("Solicitud actualizada correctamente");
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
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

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de solicitar traslado?", "Confirmar solicitud de traslado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				int idtras = Convert.ToInt32(txtidtraslado.Text);
				string query = "update traslado set estado='Cancelado' where id_traslado='" + idtras + "'";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					conn.Open();
					MySqlDataReader leer = cmd_query.ExecuteReader();
					MessageBox.Show("Solicitud cancelada correctamente");
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
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
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtdireccion = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			txtfolio = new System.Windows.Forms.TextBox();
			txtcomentarios = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtidtraslado = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			comboestado = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			txtfecha = new System.Windows.Forms.TextBox();
			txtpersonal = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtcarro = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			comboubicacion = new System.Windows.Forms.ComboBox();
			combodestino = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(257, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(140, 20);
			label1.TabIndex = 18;
			label1.Text = "Folio del cliente:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(72, 124);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(147, 20);
			label3.TabIndex = 20;
			label3.Text = "Dirección exacta:";
			txtdireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtdireccion.Location = new System.Drawing.Point(6, 162);
			txtdireccion.Margin = new System.Windows.Forms.Padding(2);
			txtdireccion.Multiline = true;
			txtdireccion.Name = "txtdireccion";
			txtdireccion.Size = new System.Drawing.Size(247, 201);
			txtdireccion.TabIndex = 3;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources.mail_sent__1_;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(349, 425);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(147, 47);
			button1.TabIndex = 5;
			button1.Text = "      Actualizar traslado";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfolio.Location = new System.Drawing.Point(415, 12);
			txtfolio.Name = "txtfolio";
			txtfolio.ReadOnly = true;
			txtfolio.Size = new System.Drawing.Size(81, 26);
			txtfolio.TabIndex = 48;
			txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			txtcomentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtcomentarios.Location = new System.Drawing.Point(261, 162);
			txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
			txtcomentarios.Multiline = true;
			txtcomentarios.Name = "txtcomentarios";
			txtcomentarios.Size = new System.Drawing.Size(247, 201);
			txtcomentarios.TabIndex = 4;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(286, 124);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(210, 20);
			label2.TabIndex = 50;
			label2.Text = "Comentarios adicionales:";
			txtidtraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidtraslado.Location = new System.Drawing.Point(160, 12);
			txtidtraslado.Name = "txtidtraslado";
			txtidtraslado.ReadOnly = true;
			txtidtraslado.Size = new System.Drawing.Size(81, 26);
			txtidtraslado.TabIndex = 52;
			txtidtraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(2, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(148, 20);
			label4.TabIndex = 51;
			label4.Text = "Traslado número:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(7, 72);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(71, 20);
			label5.TabIndex = 53;
			label5.Text = "Estado:";
			comboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboestado.Enabled = false;
			comboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboestado.FormattingEnabled = true;
			comboestado.Items.AddRange(new object[6]
			{
				"Pendiente",
				"Recoleccion",
				"En transito",
				"No se encontro",
				"Realizado",
				"Cancelado"
			});
			comboestado.Location = new System.Drawing.Point(98, 69);
			comboestado.Name = "comboestado";
			comboestado.Size = new System.Drawing.Size(121, 28);
			comboestado.TabIndex = 1;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(383, 372);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(96, 13);
			label6.TabIndex = 55;
			label6.Text = "Fecha de solicitud:";
			txtfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfecha.Location = new System.Drawing.Point(386, 393);
			txtfecha.Name = "txtfecha";
			txtfecha.ReadOnly = true;
			txtfecha.Size = new System.Drawing.Size(93, 26);
			txtfecha.TabIndex = 56;
			txtfecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtpersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtpersonal.Location = new System.Drawing.Point(209, 393);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.ReadOnly = true;
			txtpersonal.Size = new System.Drawing.Size(93, 26);
			txtpersonal.TabIndex = 58;
			txtpersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(213, 372);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(89, 13);
			label7.TabIndex = 57;
			label7.Text = "Personal número:";
			txtcarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtcarro.Location = new System.Drawing.Point(23, 393);
			txtcarro.Name = "txtcarro";
			txtcarro.ReadOnly = true;
			txtcarro.Size = new System.Drawing.Size(93, 26);
			txtcarro.TabIndex = 60;
			txtcarro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(47, 372);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(46, 13);
			label8.TabIndex = 59;
			label8.Text = "Id carro:";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(257, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(93, 20);
			label9.TabIndex = 61;
			label9.Text = "Ubicación:";
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Image = Electronica.Properties.Resources._unchecked;
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(23, 425);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(147, 47);
			button2.TabIndex = 62;
			button2.Text = "      Cancelar solicitud";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(257, 96);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(76, 20);
			label10.TabIndex = 64;
			label10.Text = "Destino:";
			comboubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboubicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboubicacion.FormattingEnabled = true;
			comboubicacion.Items.AddRange(new object[6]
			{
				"Camioneta",
				"Cliente",
				"DHL",
				"Bodega",
				"Taller",
				"Recepcion"
			});
			comboubicacion.Location = new System.Drawing.Point(368, 49);
			comboubicacion.Name = "comboubicacion";
			comboubicacion.Size = new System.Drawing.Size(128, 28);
			comboubicacion.TabIndex = 67;
			combodestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			combodestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combodestino.FormattingEnabled = true;
			combodestino.Items.AddRange(new object[6]
			{
				"Camioneta",
				"Cliente",
				"DHL",
				"Bodega",
				"Taller",
				"Recepcion"
			});
			combodestino.Location = new System.Drawing.Point(368, 93);
			combodestino.Name = "combodestino";
			combodestino.Size = new System.Drawing.Size(128, 28);
			combodestino.TabIndex = 68;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(519, 481);
			base.Controls.Add(combodestino);
			base.Controls.Add(comboubicacion);
			base.Controls.Add(label10);
			base.Controls.Add(button2);
			base.Controls.Add(label9);
			base.Controls.Add(txtcarro);
			base.Controls.Add(label8);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(label7);
			base.Controls.Add(txtfecha);
			base.Controls.Add(label6);
			base.Controls.Add(comboestado);
			base.Controls.Add(label5);
			base.Controls.Add(txtidtraslado);
			base.Controls.Add(label4);
			base.Controls.Add(label2);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(txtfolio);
			base.Controls.Add(button1);
			base.Controls.Add(label3);
			base.Controls.Add(txtdireccion);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Traslado_actualizar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Solicitud de traslado";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
