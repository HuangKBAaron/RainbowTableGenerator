namespace RainbowTableGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPermute = new System.Windows.Forms.Button();
            this.dgvDisplayData = new System.Windows.Forms.DataGridView();
            this.txtNumDigits = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPermute
            // 
            this.btnPermute.Location = new System.Drawing.Point(133, 391);
            this.btnPermute.Name = "btnPermute";
            this.btnPermute.Size = new System.Drawing.Size(75, 23);
            this.btnPermute.TabIndex = 0;
            this.btnPermute.Text = "Permute";
            this.btnPermute.UseVisualStyleBackColor = true;
            this.btnPermute.Click += new System.EventHandler(this.btnPermute_Click);
            // 
            // dgvDisplayData
            // 
            this.dgvDisplayData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayData.Location = new System.Drawing.Point(12, 12);
            this.dgvDisplayData.Name = "dgvDisplayData";
            this.dgvDisplayData.Size = new System.Drawing.Size(462, 373);
            this.dgvDisplayData.TabIndex = 1;
            // 
            // txtNumDigits
            // 
            this.txtNumDigits.Location = new System.Drawing.Point(13, 393);
            this.txtNumDigits.Name = "txtNumDigits";
            this.txtNumDigits.Size = new System.Drawing.Size(100, 20);
            this.txtNumDigits.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 426);
            this.Controls.Add(this.txtNumDigits);
            this.Controls.Add(this.dgvDisplayData);
            this.Controls.Add(this.btnPermute);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rainbow-Table Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPermute;
        private System.Windows.Forms.DataGridView dgvDisplayData;
        private System.Windows.Forms.TextBox txtNumDigits;
    }
}

