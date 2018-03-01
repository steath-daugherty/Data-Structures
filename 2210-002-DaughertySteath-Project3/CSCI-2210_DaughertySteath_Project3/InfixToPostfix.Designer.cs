namespace CSCI_2210_DaughertySteath_Project3
{
    partial class InfixToPostfixForm
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
            this.EquationsListBox = new System.Windows.Forms.ListBox();
            this.btnConvertInfix = new System.Windows.Forms.Button();
            this.postfixTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputInfixFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutInfixToPostfixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.infixTextBox = new System.Windows.Forms.TextBox();
            this.postfixLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EquationsListBox
            // 
            this.EquationsListBox.FormattingEnabled = true;
            this.EquationsListBox.Location = new System.Drawing.Point(12, 36);
            this.EquationsListBox.Name = "EquationsListBox";
            this.EquationsListBox.Size = new System.Drawing.Size(637, 225);
            this.EquationsListBox.TabIndex = 1;
            this.EquationsListBox.SelectedIndexChanged += new System.EventHandler(this.EquationsListBox_SelectedIndexChanged);
            // 
            // btnConvertInfix
            // 
            this.btnConvertInfix.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConvertInfix.Location = new System.Drawing.Point(102, 387);
            this.btnConvertInfix.Name = "btnConvertInfix";
            this.btnConvertInfix.Size = new System.Drawing.Size(117, 23);
            this.btnConvertInfix.TabIndex = 3;
            this.btnConvertInfix.Text = "Convert To Postfix";
            this.btnConvertInfix.UseVisualStyleBackColor = true;
            this.btnConvertInfix.Click += new System.EventHandler(this.btnConvertInfix_Click);
            // 
            // postfixTextBox
            // 
            this.postfixTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.postfixTextBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.postfixTextBox.Location = new System.Drawing.Point(102, 334);
            this.postfixTextBox.Name = "postfixTextBox";
            this.postfixTextBox.ReadOnly = true;
            this.postfixTextBox.Size = new System.Drawing.Size(547, 20);
            this.postfixTextBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputInfixFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // inputInfixFileToolStripMenuItem
            // 
            this.inputInfixFileToolStripMenuItem.Name = "inputInfixFileToolStripMenuItem";
            this.inputInfixFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.inputInfixFileToolStripMenuItem.Text = "Input Infix File";
            this.inputInfixFileToolStripMenuItem.Click += new System.EventHandler(this.inputInfixFileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutInfixToPostfixToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutInfixToPostfixToolStripMenuItem
            // 
            this.aboutInfixToPostfixToolStripMenuItem.Name = "aboutInfixToPostfixToolStripMenuItem";
            this.aboutInfixToPostfixToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.aboutInfixToPostfixToolStripMenuItem.Text = "About Infix to Postfix";
            this.aboutInfixToPostfixToolStripMenuItem.Click += new System.EventHandler(this.aboutInfixToPostfixToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Infix Equation";
            // 
            // infixTextBox
            // 
            this.infixTextBox.Location = new System.Drawing.Point(102, 290);
            this.infixTextBox.Name = "infixTextBox";
            this.infixTextBox.Size = new System.Drawing.Size(547, 20);
            this.infixTextBox.TabIndex = 8;
            // 
            // postfixLabel
            // 
            this.postfixLabel.AutoSize = true;
            this.postfixLabel.Location = new System.Drawing.Point(9, 337);
            this.postfixLabel.Name = "postfixLabel";
            this.postfixLabel.Size = new System.Drawing.Size(83, 13);
            this.postfixLabel.TabIndex = 9;
            this.postfixLabel.Text = "Postfix Equation";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(282, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(470, 387);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // InfixToPostfixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(661, 422);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.postfixLabel);
            this.Controls.Add(this.infixTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postfixTextBox);
            this.Controls.Add(this.btnConvertInfix);
            this.Controls.Add(this.EquationsListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InfixToPostfixForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project 3 -Infix To Postfix, Steath Daugherty";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConvertInfix;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inputInfixFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutInfixToPostfixToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label postfixLabel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.TextBox infixTextBox;
        public System.Windows.Forms.ListBox EquationsListBox;
        public System.Windows.Forms.TextBox postfixTextBox;
    }
}

