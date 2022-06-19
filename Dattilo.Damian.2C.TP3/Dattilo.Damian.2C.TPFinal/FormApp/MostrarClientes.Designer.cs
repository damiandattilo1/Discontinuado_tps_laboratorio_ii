namespace FormApp
{
    partial class MostrarClientes
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
            this.rtbLista = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLista
            // 
            this.rtbLista.Location = new System.Drawing.Point(30, 33);
            this.rtbLista.Name = "rtbLista";
            this.rtbLista.Size = new System.Drawing.Size(1230, 494);
            this.rtbLista.TabIndex = 0;
            this.rtbLista.Text = "";
            // 
            // MostrarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 553);
            this.Controls.Add(this.rtbLista);
            this.Name = "MostrarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarClientes";
            this.Load += new System.EventHandler(this.MostrarClientes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLista;
    }
}