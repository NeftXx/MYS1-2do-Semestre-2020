namespace HT6
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnModelo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModelo
            // 
            this.btnModelo.Location = new System.Drawing.Point(83, 14);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(113, 51);
            this.btnModelo.TabIndex = 0;
            this.btnModelo.Text = "Crear modelo";
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Click += new System.EventHandler(this.BtnModelo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 77);
            this.Controls.Add(this.btnModelo);
            this.Name = "MainForm";
            this.Text = "Hoja de trabajo 6";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModelo;
    }
}

