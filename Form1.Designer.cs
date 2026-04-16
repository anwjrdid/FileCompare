namespace FileCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            txtRightDir = new TextBox();
            txtLeftDir = new TextBox();
            btnRightDir = new Button();
            btnLeftDir = new Button();
            btnCopyFromLeft = new Button();
            btnCopyFromRight = new Button();
            lvwLeftDir = new ListView();
            lvwrightDir = new ListView();
            SplitContainer = new SplitContainer();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
            SplitContainer.Panel1.SuspendLayout();
            SplitContainer.Panel2.SuspendLayout();
            SplitContainer.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.DodgerBlue;
            lblAppName.Location = new Point(0, 23);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(290, 57);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // txtRightDir
            // 
            txtRightDir.Location = new Point(3, 19);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(329, 27);
            txtRightDir.TabIndex = 1;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Location = new Point(-3, 3);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(334, 27);
            txtLeftDir.TabIndex = 2;
            // 
            // btnRightDir
            // 
            btnRightDir.Location = new Point(12, 14);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(94, 29);
            btnRightDir.TabIndex = 3;
            btnRightDir.Text = "<<<";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnCopyFromRight_Click;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Location = new Point(385, 12);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(94, 29);
            btnLeftDir.TabIndex = 4;
            btnLeftDir.Text = ">>>";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnCopyFromLeft_Click;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Location = new Point(382, 3);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(94, 29);
            btnCopyFromLeft.TabIndex = 5;
            btnCopyFromLeft.Text = "폴더선택";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            btnCopyFromLeft.Click += btnLeftDir_Click;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Location = new Point(346, 16);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(94, 29);
            btnCopyFromRight.TabIndex = 6;
            btnCopyFromRight.Text = "폴더선택";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            btnCopyFromRight.Click += btnRightDir_Click;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Location = new Point(3, 3);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(461, 318);
            lvwLeftDir.TabIndex = 7;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            // 
            // lvwrightDir
            // 
            lvwrightDir.Location = new Point(3, 11);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(425, 321);
            lvwrightDir.TabIndex = 8;
            lvwrightDir.UseCompatibleStateImageBehavior = false;
            // 
            // SplitContainer
            // 
            SplitContainer.Dock = DockStyle.Fill;
            SplitContainer.Location = new Point(0, 0);
            SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            SplitContainer.Panel1.Controls.Add(panel3);
            SplitContainer.Panel1.Controls.Add(panel2);
            SplitContainer.Panel1.Controls.Add(panel1);
            // 
            // SplitContainer.Panel2
            // 
            SplitContainer.Panel2.Controls.Add(panel6);
            SplitContainer.Panel2.Controls.Add(panel5);
            SplitContainer.Panel2.Controls.Add(panel4);
            SplitContainer.Size = new Size(961, 513);
            SplitContainer.SplitterDistance = 490;
            SplitContainer.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvwLeftDir);
            panel3.Location = new Point(12, 168);
            panel3.Name = "panel3";
            panel3.Size = new Size(467, 333);
            panel3.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtLeftDir);
            panel2.Controls.Add(btnCopyFromLeft);
            panel2.Location = new Point(3, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(479, 44);
            panel2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblAppName);
            panel1.Controls.Add(btnLeftDir);
            panel1.Location = new Point(0, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(487, 95);
            panel1.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(lvwrightDir);
            panel6.Location = new Point(15, 157);
            panel6.Name = "panel6";
            panel6.Size = new Size(440, 353);
            panel6.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtRightDir);
            panel5.Controls.Add(btnCopyFromRight);
            panel5.Location = new Point(12, 80);
            panel5.Name = "panel5";
            panel5.Size = new Size(452, 71);
            panel5.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnRightDir);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(464, 71);
            panel4.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 513);
            Controls.Add(SplitContainer);
            Name = "Form1";
            Text = "File Contaioner v1.0";
            Load += Form1_Load;
            SplitContainer.Panel1.ResumeLayout(false);
            SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
            SplitContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblAppName;
        private TextBox txtRightDir;
        private TextBox txtLeftDir;
        private Button btnRightDir;
        private Button btnLeftDir;
        private Button btnCopyFromLeft;
        private Button btnCopyFromRight;
        private ListView lvwLeftDir;
        private ListView lvwrightDir;
        private SplitContainer SplitContainer;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
    }
}
