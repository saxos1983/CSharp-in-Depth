namespace Chapter15_Async_Await
{
    partial class AsyncFormDeadLock
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelStatusValue = new System.Windows.Forms.Label();
            this.btnWaitDeadlock = new System.Windows.Forms.Button();
            this.btnAwaitNoDeadlock = new System.Windows.Forms.Button();
            this.btnConfigureAwaitNoDeadlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // labelStatusValue
            // 
            this.labelStatusValue.AutoSize = true;
            this.labelStatusValue.Location = new System.Drawing.Point(70, 13);
            this.labelStatusValue.Name = "labelStatusValue";
            this.labelStatusValue.Size = new System.Drawing.Size(24, 13);
            this.labelStatusValue.TabIndex = 1;
            this.labelStatusValue.Text = "n/a";
            // 
            // btnWaitDeadlock
            // 
            this.btnWaitDeadlock.Location = new System.Drawing.Point(16, 46);
            this.btnWaitDeadlock.Name = "btnWaitDeadlock";
            this.btnWaitDeadlock.Size = new System.Drawing.Size(256, 23);
            this.btnWaitDeadlock.TabIndex = 2;
            this.btnWaitDeadlock.Text = "Execute WAIT (DeadLock)";
            this.btnWaitDeadlock.UseVisualStyleBackColor = true;
            this.btnWaitDeadlock.Click += new System.EventHandler(this.btnWaitDeadlock_Click);
            // 
            // btnAwaitNoDeadlock
            // 
            this.btnAwaitNoDeadlock.Location = new System.Drawing.Point(16, 75);
            this.btnAwaitNoDeadlock.Name = "btnAwaitNoDeadlock";
            this.btnAwaitNoDeadlock.Size = new System.Drawing.Size(256, 23);
            this.btnAwaitNoDeadlock.TabIndex = 3;
            this.btnAwaitNoDeadlock.Text = "Execute await (No DeadLock)";
            this.btnAwaitNoDeadlock.UseVisualStyleBackColor = true;
            this.btnAwaitNoDeadlock.Click += new System.EventHandler(this.btnAwaitNoDeadlock_Click);
            // 
            // btnConfigureAwaitNoDeadlock
            // 
            this.btnConfigureAwaitNoDeadlock.Location = new System.Drawing.Point(16, 104);
            this.btnConfigureAwaitNoDeadlock.Name = "btnConfigureAwaitNoDeadlock";
            this.btnConfigureAwaitNoDeadlock.Size = new System.Drawing.Size(256, 23);
            this.btnConfigureAwaitNoDeadlock.TabIndex = 4;
            this.btnConfigureAwaitNoDeadlock.Text = "Execute ConfigureAwait (No DeadLock)";
            this.btnConfigureAwaitNoDeadlock.UseVisualStyleBackColor = true;
            this.btnConfigureAwaitNoDeadlock.Click += new System.EventHandler(this.btnConfigureAwaitNoDeadlock_Click);
            // 
            // AsyncFormDeadLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnConfigureAwaitNoDeadlock);
            this.Controls.Add(this.btnAwaitNoDeadlock);
            this.Controls.Add(this.btnWaitDeadlock);
            this.Controls.Add(this.labelStatusValue);
            this.Controls.Add(this.lblStatus);
            this.Name = "AsyncFormDeadLock";
            this.Text = "AsyncFormDeadLock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label labelStatusValue;
        private System.Windows.Forms.Button btnWaitDeadlock;
        private System.Windows.Forms.Button btnAwaitNoDeadlock;
        private System.Windows.Forms.Button btnConfigureAwaitNoDeadlock;
    }
}