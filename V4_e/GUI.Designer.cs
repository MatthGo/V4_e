namespace V4_e
{
    partial class GUI
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
            this.openFolderButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.cancellationButton = new System.Windows.Forms.Button();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.outputForm = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressDefinition = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(637, 23);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openFolderButton.TabIndex = 0;
            this.openFolderButton.Text = "Open";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(637, 52);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancellationButton
            // 
            this.cancellationButton.Location = new System.Drawing.Point(637, 81);
            this.cancellationButton.Name = "cancellationButton";
            this.cancellationButton.Size = new System.Drawing.Size(75, 23);
            this.cancellationButton.TabIndex = 2;
            this.cancellationButton.Text = "Cancel";
            this.cancellationButton.UseVisualStyleBackColor = true;
            this.cancellationButton.Click += new System.EventHandler(this.CancellationButton_Click);
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(12, 25);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(619, 20);
            this.filePathBox.TabIndex = 3;
            // 
            // outputForm
            // 
            this.outputForm.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputForm.Location = new System.Drawing.Point(12, 53);
            this.outputForm.Name = "outputForm";
            this.outputForm.Size = new System.Drawing.Size(619, 655);
            this.outputForm.TabIndex = 4;
            this.outputForm.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 714);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(619, 23);
            this.progressBar.TabIndex = 5;
            // 
            // progressDefinition
            // 
            this.progressDefinition.AutoSize = true;
            this.progressDefinition.Location = new System.Drawing.Point(648, 719);
            this.progressDefinition.Name = "progressDefinition";
            this.progressDefinition.Size = new System.Drawing.Size(40, 13);
            this.progressDefinition.TabIndex = 6;
            this.progressDefinition.Text = "LABEL";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(633, 685);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 749);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressDefinition);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.outputForm);
            this.Controls.Add(this.filePathBox);
            this.Controls.Add(this.cancellationButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.openFolderButton);
            this.Name = "GUI";
            this.Text = "V4_e_GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancellationButton;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.RichTextBox outputForm;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressDefinition;
        private System.Windows.Forms.Button exitButton;
    }
}

