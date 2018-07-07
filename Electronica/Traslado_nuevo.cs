using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Traslado_nuevo : Form
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

		public ComboBox comboubicacion;

		public ComboBox combodestino;

		private Label label5;

		public Traslado_nuevo()
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
			if (string.IsNullOrWhiteSpace(txtaviso.Text))
			{
				MessageBox.Show("No puede dejar el campo direccion vacío");
			}
			if (string.IsNullOrWhiteSpace(combodestino.Text))
			{
				MessageBox.Show("No puede dejar el campo destino vacío");
			}
			if (string.IsNullOrWhiteSpace(comboubicacion.Text))
			{
				MessageBox.Show("No puede dejar el campo ubicación vacío");
			}
			else
			{
				int folio = Convert.ToInt32(txtfolio.Text);
				string direccion = txtaviso.Text;
				string ubi = comboubicacion.SelectedItem.ToString();
				string coment = txtcomentarios.Text;
				string destino = combodestino.SelectedItem.ToString();
				string query = "insert into traslado(estado,direccion,comentarios,ubicacion,destino,id_folio) values('Pendiente','" + direccion + "','" + coment + "','" + ubi + "','" + destino + "','" + folio + "')";
				MySqlCommand cmd_query = new MySqlCommand(query, conn);
				try
				{
					conn.Open();
					MySqlDataReader leer = cmd_query.ExecuteReader();
					MessageBox.Show("Solicitud enviada correctamente");
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
			txtaviso = new System.Windows.Forms.TextBox();
			txtfolio = new System.Windows.Forms.TextBox();
			txtcomentarios = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			comboubicacion = new System.Windows.Forms.ComboBox();
			combodestino = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(58, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(140, 20);
			label1.TabIndex = 18;
			label1.Text = "Folio del cliente:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(96, 144);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(147, 20);
			label3.TabIndex = 20;
			label3.Text = "Dirección exacta:";
			txtaviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtaviso.Location = new System.Drawing.Point(23, 171);
			txtaviso.Margin = new System.Windows.Forms.Padding(2);
			txtaviso.Multiline = true;
			txtaviso.Name = "txtaviso";
			txtaviso.Size = new System.Drawing.Size(302, 201);
			txtaviso.TabIndex = 3;
			txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfolio.Location = new System.Drawing.Point(218, 12);
			txtfolio.Name = "txtfolio";
			txtfolio.Size = new System.Drawing.Size(81, 26);
			txtfolio.TabIndex = 1;
			txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtfolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtfolio_KeyPress);
			txtcomentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtcomentarios.Location = new System.Drawing.Point(23, 409);
			txtcomentarios.Margin = new System.Windows.Forms.Padding(2);
			txtcomentarios.Multiline = true;
			txtcomentarios.Name = "txtcomentarios";
			txtcomentarios.Size = new System.Drawing.Size(302, 138);
			txtcomentarios.TabIndex = 4;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(69, 374);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(210, 20);
			label2.TabIndex = 50;
			label2.Text = "Comentarios adicionales:";
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources.mail_sent__1_;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(185, 552);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(140, 47);
			button1.TabIndex = 5;
			button1.Text = "      Solicitar traslado";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(59, 65);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 20);
			label4.TabIndex = 51;
			label4.Text = "Ubicación:";
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
			comboubicacion.Location = new System.Drawing.Point(192, 62);
			comboubicacion.Name = "comboubicacion";
			comboubicacion.Size = new System.Drawing.Size(121, 28);
			comboubicacion.TabIndex = 2;
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
			combodestino.Location = new System.Drawing.Point(192, 105);
			combodestino.Name = "combodestino";
			combodestino.Size = new System.Drawing.Size(121, 28);
			combodestino.TabIndex = 52;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(59, 108);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(76, 20);
			label5.TabIndex = 53;
			label5.Text = "Destino:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(347, 605);
			base.Controls.Add(combodestino);
			base.Controls.Add(label5);
			base.Controls.Add(comboubicacion);
			base.Controls.Add(label4);
			base.Controls.Add(label2);
			base.Controls.Add(txtcomentarios);
			base.Controls.Add(txtfolio);
			base.Controls.Add(button1);
			base.Controls.Add(label3);
			base.Controls.Add(txtaviso);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Traslado_nuevo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Solicitud de traslado";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
