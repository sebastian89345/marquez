namespace WindowsFormsApp1
{
    partial class SalesDs
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtAmout = new System.Windows.Forms.TextBox();
            this.TxtPricing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.TxtIdInventory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnDowloand = new System.Windows.Forms.Button();
            this.DtStart = new System.Windows.Forms.DateTimePicker();
            this.CbxLength = new System.Windows.Forms.ComboBox();
            this.DtEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(751, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ventas";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(861, 283);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(121, 39);
            this.BtnDelete.TabIndex = 43;
            this.BtnDelete.Text = "Eliminar";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(717, 283);
            this.BtnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(121, 39);
            this.BtnUpdate.TabIndex = 42;
            this.BtnUpdate.Text = "Actualizar";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(934, 42);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(121, 39);
            this.BtnSearch.TabIndex = 41;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(699, 51);
            this.TxtId.Margin = new System.Windows.Forms.Padding(4);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(191, 22);
            this.TxtId.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(542, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "Identificacion";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(571, 283);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(121, 39);
            this.BtnSave.TabIndex = 38;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtAmout
            // 
            this.TxtAmout.Location = new System.Drawing.Point(699, 191);
            this.TxtAmout.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAmout.Name = "TxtAmout";
            this.TxtAmout.Size = new System.Drawing.Size(191, 22);
            this.TxtAmout.TabIndex = 37;
            // 
            // TxtPricing
            // 
            this.TxtPricing.Location = new System.Drawing.Point(699, 138);
            this.TxtPricing.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPricing.Name = "TxtPricing";
            this.TxtPricing.Size = new System.Drawing.Size(191, 22);
            this.TxtPricing.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(582, 189);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(609, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "Precio";
            // 
            // DtgList
            // 
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DtgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Location = new System.Drawing.Point(16, 381);
            this.DtgList.Margin = new System.Windows.Forms.Padding(4);
            this.DtgList.Name = "DtgList";
            this.DtgList.RowHeadersWidth = 51;
            this.DtgList.Size = new System.Drawing.Size(1540, 425);
            this.DtgList.TabIndex = 44;
            // 
            // TxtIdInventory
            // 
            this.TxtIdInventory.Location = new System.Drawing.Point(697, 89);
            this.TxtIdInventory.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdInventory.Name = "TxtIdInventory";
            this.TxtIdInventory.Size = new System.Drawing.Size(191, 22);
            this.TxtIdInventory.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Identificacion del inventario";
            // 
            // DtDate
            // 
            this.DtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDate.Location = new System.Drawing.Point(699, 241);
            this.DtDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtDate.Name = "DtDate";
            this.DtDate.Size = new System.Drawing.Size(191, 22);
            this.DtDate.TabIndex = 47;
            this.DtDate.Value = new System.DateTime(2024, 7, 10, 13, 41, 44, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 48;
            this.label3.Text = "Fecha actual";
            // 
            // BtnDowloand
            // 
            this.BtnDowloand.Location = new System.Drawing.Point(640, 334);
            this.BtnDowloand.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDowloand.Name = "BtnDowloand";
            this.BtnDowloand.Size = new System.Drawing.Size(121, 39);
            this.BtnDowloand.TabIndex = 49;
            this.BtnDowloand.Text = "Descargar";
            this.BtnDowloand.UseVisualStyleBackColor = true;
            this.BtnDowloand.Click += new System.EventHandler(this.BtnDowloand_Click);
            // 
            // DtStart
            // 
            this.DtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtStart.Location = new System.Drawing.Point(232, 344);
            this.DtStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtStart.Name = "DtStart";
            this.DtStart.Size = new System.Drawing.Size(191, 22);
            this.DtStart.TabIndex = 50;
            this.DtStart.Value = new System.DateTime(2024, 7, 10, 13, 41, 44, 0);
            // 
            // CbxLength
            // 
            this.CbxLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxLength.FormattingEnabled = true;
            this.CbxLength.Items.AddRange(new object[] {
            "Todo",
            "Mes"});
            this.CbxLength.Location = new System.Drawing.Point(27, 342);
            this.CbxLength.Margin = new System.Windows.Forms.Padding(4);
            this.CbxLength.Name = "CbxLength";
            this.CbxLength.Size = new System.Drawing.Size(191, 24);
            this.CbxLength.TabIndex = 52;
            // 
            // DtEnd
            // 
            this.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtEnd.Location = new System.Drawing.Point(441, 344);
            this.DtEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtEnd.Name = "DtEnd";
            this.DtEnd.Size = new System.Drawing.Size(191, 22);
            this.DtEnd.TabIndex = 53;
            this.DtEnd.Value = new System.DateTime(2024, 7, 10, 13, 41, 44, 0);
            // 
            // SalesDs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1569, 824);
            this.Controls.Add(this.DtEnd);
            this.Controls.Add(this.CbxLength);
            this.Controls.Add(this.DtStart);
            this.Controls.Add(this.BtnDowloand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtDate);
            this.Controls.Add(this.TxtIdInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtgList);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtAmout);
            this.Controls.Add(this.TxtPricing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SalesDs";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.SalesDs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtAmout;
        private System.Windows.Forms.TextBox TxtPricing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.TextBox TxtIdInventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnDowloand;
        private System.Windows.Forms.DateTimePicker DtStart;
        private System.Windows.Forms.ComboBox CbxLength;
        private System.Windows.Forms.DateTimePicker DtEnd;
    }
}