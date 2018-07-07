using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Electronica
{
	public class Inicio : Form
	{
		private MySqlConnection conn = ConexionBD.ObtenerConexion();

		private string v;

		private IContainer components = null;

		private Label label1;

		private Label label2;

		public TextBox txtpersonal;

		public Inicio()
		{
			InitializeComponent();
		}

		public Inicio(string personal)
		{
			InitializeComponent();
			txtpersonal.Text = personal;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void BuscarCliente(string valueToSearch)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_TextChanged(object sender, EventArgs e)
		{
		}

		private void Buscador_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
		}

		private void Cliente_nuevo(object sender, EventArgs e)
		{
			Clientes_nuevos ss = new Clientes_nuevos();
			ss.Show();
		}

		private void TablaClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electronica.Inicio));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtpersonal = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.SystemColors.Control;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(187, 652);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(714, 25);
			label1.TabIndex = 0;
			label1.Text = "Con más de 30 años reparandando y dando mantenimiento a tus equipos";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.SystemColors.Control;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(469, 677);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(148, 24);
			label2.TabIndex = 1;
			label2.Text = "S.A de C.V 2018";
			txtpersonal.Location = new System.Drawing.Point(485, 12);
			txtpersonal.Name = "txtpersonal";
			txtpersonal.Size = new System.Drawing.Size(100, 20);
			txtpersonal.TabIndex = 8;
			txtpersonal.Visible = false;
			txtpersonal.WordWrap = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new System.Drawing.Size(1082, 707);
			base.Controls.Add(txtpersonal);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Inicio";
			base.Opacity = 0.7;
			Text = "Clientes";
			base.Load += new System.EventHandler(Inicio_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
