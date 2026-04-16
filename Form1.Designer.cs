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
            ((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
            SplitContainer.Panel1.SuspendLayout();
            SplitContainer.Panel2.SuspendLayout();
            SplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.DodgerBlue;
            lblAppName.Location = new Point(12, 16);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(290, 57);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // txtRightDir
            // 
            txtRightDir.Location = new Point(15, 101);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(329, 27);
            txtRightDir.TabIndex = 1;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Location = new Point(12, 101);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(334, 27);
            txtLeftDir.TabIndex = 2;
            // 
            // btnRightDir
            // 
            btnRightDir.Location = new Point(15, 22);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(94, 29);
            btnRightDir.TabIndex = 3;
            btnRightDir.Text = "<<<";
            btnRightDir.UseVisualStyleBackColor = true;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Location = new Point(368, 22);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(94, 29);
            btnLeftDir.TabIndex = 4;
            btnLeftDir.Text = ">>>";
            btnLeftDir.UseVisualStyleBackColor = true;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Location = new Point(368, 110);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(94, 29);
            btnCopyFromLeft.TabIndex = 5;
            btnCopyFromLeft.Text = "폴더선택";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Location = new Point(361, 101);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(94, 29);
            btnCopyFromRight.TabIndex = 6;
            btnCopyFromRight.Text = "폴더선택";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Location = new Point(0, 168);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(487, 342);
            lvwLeftDir.TabIndex = 7;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            // 
            // lvwrightDir
            // 
            lvwrightDir.Location = new Point(3, 168);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(461, 345);
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
            SplitContainer.Panel1.Controls.Add(lvwLeftDir);
            SplitContainer.Panel1.Controls.Add(btnCopyFromLeft);
            SplitContainer.Panel1.Controls.Add(txtLeftDir);
            SplitContainer.Panel1.Controls.Add(btnLeftDir);
            SplitContainer.Panel1.Controls.Add(lblAppName);
            // 
            // SplitContainer.Panel2
            // 
            SplitContainer.Panel2.Controls.Add(lvwrightDir);
            SplitContainer.Panel2.Controls.Add(btnCopyFromRight);
            SplitContainer.Panel2.Controls.Add(txtRightDir);
            SplitContainer.Panel2.Controls.Add(btnRightDir);
            SplitContainer.Size = new Size(961, 513);
            SplitContainer.SplitterDistance = 490;
            SplitContainer.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 513);
            Controls.Add(SplitContainer);
            Name = "Form1";
            Text = "File Contaioner v1.0";
            SplitContainer.Panel1.ResumeLayout(false);
            SplitContainer.Panel1.PerformLayout();
            SplitContainer.Panel2.ResumeLayout(false);
            SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
            SplitContainer.ResumeLayout(false);
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
    }
}
