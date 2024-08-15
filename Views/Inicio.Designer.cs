namespace WindowsFormsApp1
{
    partial class Inicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.Inventario = new System.Windows.Forms.Button();
            this.BtnSales = new System.Windows.Forms.Button();
            this.BtnCopyDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compra venta y almacen la marquez";
            // 
            // Inventario
            // 
            this.Inventario.Location = new System.Drawing.Point(215, 85);
            this.Inventario.Name = "Inventario";
            this.Inventario.Size = new System.Drawing.Size(109, 30);
            this.Inventario.TabIndex = 1;
            this.Inventario.Text = "Inventario";
            this.Inventario.UseVisualStyleBackColor = true;
            this.Inventario.Click += new System.EventHandler(this.Inventario_Click);
            // 
            // BtnSales
            // 
            this.BtnSales.Location = new System.Drawing.Point(330, 85);
            this.BtnSales.Name = "BtnSales";
            this.BtnSales.Size = new System.Drawing.Size(109, 30);
            this.BtnSales.TabIndex = 4;
            this.BtnSales.Text = "Ventas";
            this.BtnSales.UseVisualStyleBackColor = true;
            this.BtnSales.Click += new System.EventHandler(this.BtnSales_Click);
            // 
            // BtnCopyDb
            // 
            this.BtnCopyDb.Location = new System.Drawing.Point(445, 85);
            this.BtnCopyDb.Name = "BtnCopyDb";
            this.BtnCopyDb.Size = new System.Drawing.Size(109, 30);
            this.BtnCopyDb.TabIndex = 5;
            this.BtnCopyDb.Text = "Copia DB";
            this.BtnCopyDb.UseVisualStyleBackColor = true;
            this.BtnCopyDb.Click += new System.EventHandler(this.BtnCopyDb_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCopyDb);
            this.Controls.Add(this.BtnSales);
            this.Controls.Add(this.Inventario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Inventario;
        private System.Windows.Forms.Button BtnSales;
        private System.Windows.Forms.Button BtnCopyDb;
    }
}

