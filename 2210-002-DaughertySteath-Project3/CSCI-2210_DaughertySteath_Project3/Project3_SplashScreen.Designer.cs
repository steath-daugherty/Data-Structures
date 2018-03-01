namespace CSCI_2210_DaughertySteath_Project3
{
    partial class Project3_SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project3_SplashScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splashscreenPictureBox = new System.Windows.Forms.PictureBox();
            this.splashscreenLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splashscreenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splashscreenPictureBox
            // 
            this.splashscreenPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("splashscreenPictureBox.Image")));
            this.splashscreenPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("splashscreenPictureBox.InitialImage")));
            this.splashscreenPictureBox.Location = new System.Drawing.Point(80, 12);
            this.splashscreenPictureBox.Name = "splashscreenPictureBox";
            this.splashscreenPictureBox.Size = new System.Drawing.Size(429, 349);
            this.splashscreenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splashscreenPictureBox.TabIndex = 0;
            this.splashscreenPictureBox.TabStop = false;
            // 
            // splashscreenLabel
            // 
            this.splashscreenLabel.AutoSize = true;
            this.splashscreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashscreenLabel.Location = new System.Drawing.Point(106, 364);
            this.splashscreenLabel.Name = "splashscreenLabel";
            this.splashscreenLabel.Size = new System.Drawing.Size(388, 37);
            this.splashscreenLabel.TabIndex = 1;
            this.splashscreenLabel.Text = "Infix to Postfix Converter";
            // 
            // Project3_SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(593, 421);
            this.Controls.Add(this.splashscreenLabel);
            this.Controls.Add(this.splashscreenPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Project3_SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project3_SplashScreen";
            this.Load += new System.EventHandler(this.Project3_SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splashscreenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox splashscreenPictureBox;
        private System.Windows.Forms.Label splashscreenLabel;
    }
}