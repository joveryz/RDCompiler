namespace RDCompiler.Notepad
{
    partial class NotepadAbout
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
            this.LogoLabel = new System.Windows.Forms.Label();
            this.SeparatorLabel = new System.Windows.Forms.Label();
            this.DetailTextbox = new System.Windows.Forms.TextBox();
            this.SureButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.BackColor = System.Drawing.Color.Black;
            this.LogoLabel.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogoLabel.ForeColor = System.Drawing.Color.White;
            this.LogoLabel.Location = new System.Drawing.Point(80, 28);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(405, 83);
            this.LogoLabel.TabIndex = 0;
            this.LogoLabel.Text = "RDCompiler";
            // 
            // SeparatorLabel
            // 
            this.SeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SeparatorLabel.Enabled = false;
            this.SeparatorLabel.Location = new System.Drawing.Point(21, 134);
            this.SeparatorLabel.Name = "SeparatorLabel";
            this.SeparatorLabel.Size = new System.Drawing.Size(500, 3);
            this.SeparatorLabel.TabIndex = 1;
            // 
            // DetailTextbox
            // 
            this.DetailTextbox.BackColor = System.Drawing.Color.White;
            this.DetailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DetailTextbox.Enabled = false;
            this.DetailTextbox.Location = new System.Drawing.Point(74, 162);
            this.DetailTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DetailTextbox.Multiline = true;
            this.DetailTextbox.Name = "DetailTextbox";
            this.DetailTextbox.Size = new System.Drawing.Size(431, 214);
            this.DetailTextbox.TabIndex = 2;
            this.DetailTextbox.Text = "RDCompiler\r\n版本 0001\r\n© 2016 Redebug.com。保留所有权利。\r\nRDCompiler 编译器及其用户界面受中国和其他国家/地区的" +
    "商标法和其他待颁布或已颁布的知识产权法保护。\r\n\r\n\r\n\r\n根据软件许可协议，许可如下用户使用本产品：\r\n    ztb5129@live.com";
            // 
            // SureButton
            // 
            this.SureButton.Location = new System.Drawing.Point(479, 367);
            this.SureButton.Name = "SureButton";
            this.SureButton.Size = new System.Drawing.Size(75, 27);
            this.SureButton.TabIndex = 3;
            this.SureButton.Text = "确定";
            this.SureButton.UseVisualStyleBackColor = true;
            this.SureButton.Click += new System.EventHandler(this.Sure_Click);
            // 
            // NotepadAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 411);
            this.Controls.Add(this.SureButton);
            this.Controls.Add(this.DetailTextbox);
            this.Controls.Add(this.SeparatorLabel);
            this.Controls.Add(this.LogoLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotepadAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于“RDCompiler”";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DetailTextbox;
        private System.Windows.Forms.Label SeparatorLabel;
        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.Button SureButton;
    }
}