namespace RDCompiler.Notepad
{
    partial class NotepadWelcome
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
            this.components = new System.ComponentModel.Container();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.CRLabel = new System.Windows.Forms.Label();
            this.TimerClosed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.CausesValidation = false;
            this.LogoLabel.Font = new System.Drawing.Font("微软雅黑", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogoLabel.ForeColor = System.Drawing.Color.White;
            this.LogoLabel.Location = new System.Drawing.Point(25, 43);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(335, 68);
            this.LogoLabel.TabIndex = 0;
            this.LogoLabel.Text = "RDCompiler";
            // 
            // CRLabel
            // 
            this.CRLabel.AutoSize = true;
            this.CRLabel.CausesValidation = false;
            this.CRLabel.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CRLabel.ForeColor = System.Drawing.Color.White;
            this.CRLabel.Location = new System.Drawing.Point(249, 136);
            this.CRLabel.Name = "CRLabel";
            this.CRLabel.Size = new System.Drawing.Size(123, 14);
            this.CRLabel.TabIndex = 1;
            this.CRLabel.Text = "Copyright @Redebug.com";
            // 
            // TimerClosed
            // 
            this.TimerClosed.Enabled = true;
            this.TimerClosed.Interval = 1200;
            this.TimerClosed.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NotepadWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(384, 159);
            this.ControlBox = false;
            this.Controls.Add(this.CRLabel);
            this.Controls.Add(this.LogoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotepadWelcome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NotepadWelcome";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.Label CRLabel;
        private System.Windows.Forms.Timer TimerClosed;
    }
}