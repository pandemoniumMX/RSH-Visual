namespace Electronica
{
    partial class PDF_Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PDF_Generar = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PDF_Generar
            // 
            this.PDF_Generar.ActiveViewIndex = -1;
            this.PDF_Generar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PDF_Generar.Cursor = System.Windows.Forms.Cursors.Default;
            this.PDF_Generar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDF_Generar.Location = new System.Drawing.Point(0, 0);
            this.PDF_Generar.Name = "PDF_Generar";
            this.PDF_Generar.Size = new System.Drawing.Size(874, 471);
            this.PDF_Generar.TabIndex = 0;
            // 
            // PDF_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 471);
            this.Controls.Add(this.PDF_Generar);
            this.Name = "PDF_Reporte";
            this.Text = "PDF_Garantia";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer PDF_Generar;
    }
}