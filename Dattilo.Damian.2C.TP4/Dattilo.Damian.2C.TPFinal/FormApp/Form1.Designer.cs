namespace FormApp
{
    partial class rBtnEmpresa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMostrarListaClientes = new System.Windows.Forms.Button();
            this.btnNuevaPersona = new System.Windows.Forms.Button();
            this.btnNuevaEmpresa = new System.Windows.Forms.Button();
            this.btngregarTramiteEmpresa = new System.Windows.Forms.Button();
            this.btnAgregarTramitePersona = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMostrarListaClientes
            // 
            this.btnMostrarListaClientes.Location = new System.Drawing.Point(456, 187);
            this.btnMostrarListaClientes.Name = "btnMostrarListaClientes";
            this.btnMostrarListaClientes.Size = new System.Drawing.Size(184, 69);
            this.btnMostrarListaClientes.TabIndex = 5;
            this.btnMostrarListaClientes.Text = "Mostrar Lista Clientes";
            this.btnMostrarListaClientes.UseVisualStyleBackColor = true;
            this.btnMostrarListaClientes.Click += new System.EventHandler(this.btnMostrarListaClientes_Click);
            // 
            // btnNuevaPersona
            // 
            this.btnNuevaPersona.Location = new System.Drawing.Point(179, 131);
            this.btnNuevaPersona.Name = "btnNuevaPersona";
            this.btnNuevaPersona.Size = new System.Drawing.Size(190, 76);
            this.btnNuevaPersona.TabIndex = 6;
            this.btnNuevaPersona.Text = "Nueva Persona";
            this.btnNuevaPersona.UseVisualStyleBackColor = true;
            this.btnNuevaPersona.Click += new System.EventHandler(this.btnNuevaPersona_Click);
            // 
            // btnNuevaEmpresa
            // 
            this.btnNuevaEmpresa.Location = new System.Drawing.Point(732, 131);
            this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            this.btnNuevaEmpresa.Size = new System.Drawing.Size(211, 76);
            this.btnNuevaEmpresa.TabIndex = 7;
            this.btnNuevaEmpresa.Text = "Nueva Empresa";
            this.btnNuevaEmpresa.UseVisualStyleBackColor = true;
            this.btnNuevaEmpresa.Click += new System.EventHandler(this.btnNuevaEmpresa_Click);
            // 
            // btngregarTramiteEmpresa
            // 
            this.btngregarTramiteEmpresa.Location = new System.Drawing.Point(742, 251);
            this.btngregarTramiteEmpresa.Name = "btngregarTramiteEmpresa";
            this.btngregarTramiteEmpresa.Size = new System.Drawing.Size(192, 73);
            this.btngregarTramiteEmpresa.TabIndex = 8;
            this.btngregarTramiteEmpresa.Text = "Agregar Tramite empresa";
            this.btngregarTramiteEmpresa.UseVisualStyleBackColor = true;
            this.btngregarTramiteEmpresa.Click += new System.EventHandler(this.btngregarTramiteEmpresa_Click);
            // 
            // btnAgregarTramitePersona
            // 
            this.btnAgregarTramitePersona.Location = new System.Drawing.Point(179, 251);
            this.btnAgregarTramitePersona.Name = "btnAgregarTramitePersona";
            this.btnAgregarTramitePersona.Size = new System.Drawing.Size(190, 73);
            this.btnAgregarTramitePersona.TabIndex = 9;
            this.btnAgregarTramitePersona.Text = "Agregar Tramite Persona";
            this.btnAgregarTramitePersona.UseVisualStyleBackColor = true;
            this.btnAgregarTramitePersona.Click += new System.EventHandler(this.btnAgregarTramitePersona_Click);
            // 
            // rBtnEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 486);
            this.Controls.Add(this.btnAgregarTramitePersona);
            this.Controls.Add(this.btngregarTramiteEmpresa);
            this.Controls.Add(this.btnNuevaEmpresa);
            this.Controls.Add(this.btnNuevaPersona);
            this.Controls.Add(this.btnMostrarListaClientes);
            this.Name = "rBtnEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.rBtnEmpresa_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMostrarListaClientes;
        private System.Windows.Forms.Button btnNuevaPersona;
        private System.Windows.Forms.Button btnNuevaEmpresa;
        private System.Windows.Forms.Button btngregarTramiteEmpresa;
        private System.Windows.Forms.Button btnAgregarTramitePersona;
    }
}
