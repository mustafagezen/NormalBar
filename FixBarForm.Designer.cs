namespace NormalBar
{
    partial class FixBarForm
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
            this.evLogo = new System.Windows.Forms.PictureBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.fixIt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.evLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // evLogo
            // 
            this.evLogo.BackgroundImage = global::NormalBar.Properties.Resources.evasi0n_6_1_jailbreak_untethered_download;
            this.evLogo.Location = new System.Drawing.Point(83, 12);
            this.evLogo.Name = "evLogo";
            this.evLogo.Size = new System.Drawing.Size(206, 205);
            this.evLogo.TabIndex = 0;
            this.evLogo.TabStop = false;
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(83, 324);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(206, 20);
            this.ipBox.TabIndex = 1;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(83, 305);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(17, 13);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "IP";
            // 
            // fixIt
            // 
            this.fixIt.Location = new System.Drawing.Point(83, 424);
            this.fixIt.Name = "fixIt";
            this.fixIt.Size = new System.Drawing.Size(206, 55);
            this.fixIt.TabIndex = 6;
            this.fixIt.Text = "Fix it!";
            this.fixIt.UseVisualStyleBackColor = true;
            this.fixIt.Click += new System.EventHandler(this.fixIt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Password";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(83, 370);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(206, 20);
            this.passBox.TabIndex = 5;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(13, 255);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(381, 23);
            this.progress.TabIndex = 8;
            // 
            // FixBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(406, 535);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.fixIt);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.evLogo);
            this.Name = "FixBarForm";
            this.Text = "NormalBar";
            ((System.ComponentModel.ISupportInitialize)(this.evLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox evLogo;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Button fixIt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.ProgressBar progress;
    }
}

