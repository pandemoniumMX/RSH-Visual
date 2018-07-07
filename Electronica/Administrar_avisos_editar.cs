using Electronica.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Administrar_avisos_editar : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		private Label label1;

		private Label label3;

		public TextBox txtaviso;

		private Button button1;

		public TextBox txtfolio;

		public TextBox txtidaviso;

		private Label label2;

		private Label label4;

		private Label label5;

		public TextBox txtfecha;

		public ComboBox comboestado;

		public Administrar_avisos_editar()
		{
			InitializeComponent();
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("¿Está seguro de actualizar este aviso?", "Confirmar actualización", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
			if (dr == DialogResult.Yes)
			{
				if (string.IsNullOrWhiteSpace(txtaviso.Text))
				{
					MessageBox.Show("No puede dejar el campo aviso vacío");
				}
				else
				{
					int idaviso = Convert.ToInt32(txtidaviso.Text);
					int folio = Convert.ToInt32(txtfolio.Text);
					string aviso = txtaviso.Text;
					string estado = comboestado.SelectedItem.ToString();
					string query = "update avisos set estado='" + estado + "', aviso='" + aviso + "' where id_aviso='" + idaviso + "'";
					MySqlCommand cmd_query = new MySqlCommand(query, conn);
					try
					{
						conn.Open();
						MySqlDataReader leer = cmd_query.ExecuteReader();
						MessageBox.Show("Aviso actualizado correctamente");
						Close();
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
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtaviso = new System.Windows.Forms.TextBox();
			txtfolio = new System.Windows.Forms.TextBox();
			txtidaviso = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			comboestado = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			txtfecha = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(53, 50);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(140, 20);
			label1.TabIndex = 18;
			label1.Text = "Folio del cliente:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(59, 128);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(211, 20);
			label3.TabIndex = 20;
			label3.Text = "Aviso o queja en general:";
			txtaviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtaviso.Location = new System.Drawing.Point(24, 167);
			txtaviso.Margin = new System.Windows.Forms.Padding(2);
			txtaviso.Multiline = true;
			txtaviso.Name = "txtaviso";
			txtaviso.Size = new System.Drawing.Size(302, 296);
			txtaviso.TabIndex = 2;
			txtfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfolio.Location = new System.Drawing.Point(213, 47);
			txtfolio.Name = "txtfolio";
			txtfolio.ReadOnly = true;
			txtfolio.Size = new System.Drawing.Size(81, 26);
			txtfolio.TabIndex = 48;
			txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtidaviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtidaviso.Location = new System.Drawing.Point(213, 9);
			txtidaviso.Name = "txtidaviso";
			txtidaviso.ReadOnly = true;
			txtidaviso.Size = new System.Drawing.Size(81, 26);
			txtidaviso.TabIndex = 50;
			txtidaviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(53, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(122, 20);
			label2.TabIndex = 49;
			label2.Text = "Aviso número:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(53, 96);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 20);
			label4.TabIndex = 51;
			label4.Text = "Estado:";
			comboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboestado.FormattingEnabled = true;
			comboestado.Items.AddRange(new object[2]
			{
				"Pendiente",
				"Solucionado"
			});
			comboestado.Location = new System.Drawing.Point(168, 93);
			comboestado.Name = "comboestado";
			comboestado.Size = new System.Drawing.Size(126, 28);
			comboestado.TabIndex = 52;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(21, 533);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(85, 13);
			label5.TabIndex = 53;
			label5.Text = "Fecha del aviso:";
			txtfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfecha.Location = new System.Drawing.Point(24, 554);
			txtfecha.Name = "txtfecha";
			txtfecha.ReadOnly = true;
			txtfecha.Size = new System.Drawing.Size(90, 26);
			txtfecha.TabIndex = 54;
			txtfecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Image = Electronica.Properties.Resources._003_refresh_button1;
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(188, 533);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(147, 47);
			button1.TabIndex = 47;
			button1.Text = "      Actualizar aviso";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(347, 592);
			base.Controls.Add(txtfecha);
			base.Controls.Add(label5);
			base.Controls.Add(comboestado);
			base.Controls.Add(label4);
			base.Controls.Add(txtidaviso);
			base.Controls.Add(label2);
			base.Controls.Add(txtfolio);
			base.Controls.Add(button1);
			base.Controls.Add(label3);
			base.Controls.Add(txtaviso);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Administrar_avisos_editar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Avisos y quejas de clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
