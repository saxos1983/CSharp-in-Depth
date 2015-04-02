namespace Chapter15_Async_Await
{
    partial class AsyncForm
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
            this.lblLengthTitle = new System.Windows.Forms.Label();
            this.lblLengthValue = new System.Windows.Forms.Label();
            this.btnFetchLength = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLengthTitle
            // 
            this.lblLengthTitle.AutoSize = true;
            this.lblLengthTitle.Location = new System.Drawing.Point(13, 13);
            this.lblLengthTitle.Name = "lblLengthTitle";
            this.lblLengthTitle.Size = new System.Drawing.Size(43, 13);
            this.lblLengthTitle.TabIndex = 0;
            this.lblLengthTitle.Text = "Length:";
            // 
            // lblLengthValue
            // 
            this.lblLengthValue.Location = new System.Drawing.Point(62, 13);
            this.lblLengthValue.Name = "lblLengthValue";
            this.lblLengthValue.Size = new System.Drawing.Size(55, 13);
            this.lblLengthValue.TabIndex = 1;
            this.lblLengthValue.Text = "n/a";
            this.lblLengthValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnFetchLength
            // 
            this.btnFetchLength.Location = new System.Drawing.Point(16, 40);
            this.btnFetchLength.Name = "btnFetchLength";
            this.btnFetchLength.Size = new System.Drawing.Size(75, 23);
            this.btnFetchLength.TabIndex = 2;
            this.btnFetchLength.Text = "Get Length!";
            this.btnFetchLength.UseVisualStyleBackColor = true;
            // 
            // AsyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnFetchLength);
            this.Controls.Add(this.lblLengthValue);
            this.Controls.Add(this.lblLengthTitle);
            this.Name = "AsyncForm";
            this.Text = "AsyncForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLengthTitle;
        private System.Windows.Forms.Label lblLengthValue;
        private System.Windows.Forms.Button btnFetchLength;
    }
}