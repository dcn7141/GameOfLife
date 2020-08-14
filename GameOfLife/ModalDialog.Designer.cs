namespace GameOfLife
{
    partial class ModalDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.labelTimeIntervalinMIlliseconds = new System.Windows.Forms.Label();
            this.labelWidthofUniverseinCells = new System.Windows.Forms.Label();
            this.labelHeightofUniverseinCells = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(54, 168);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(109, 33);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(178, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 33);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(226, 28);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(226, 68);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(226, 106);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown3.TabIndex = 4;
            // 
            // labelTimeIntervalinMIlliseconds
            // 
            this.labelTimeIntervalinMIlliseconds.AutoSize = true;
            this.labelTimeIntervalinMIlliseconds.Location = new System.Drawing.Point(64, 28);
            this.labelTimeIntervalinMIlliseconds.Name = "labelTimeIntervalinMIlliseconds";
            this.labelTimeIntervalinMIlliseconds.Size = new System.Drawing.Size(142, 13);
            this.labelTimeIntervalinMIlliseconds.TabIndex = 5;
            this.labelTimeIntervalinMIlliseconds.Text = "Timer Interval in Milliseconds";
            // 
            // labelWidthofUniverseinCells
            // 
            this.labelWidthofUniverseinCells.AutoSize = true;
            this.labelWidthofUniverseinCells.Location = new System.Drawing.Point(64, 68);
            this.labelWidthofUniverseinCells.Name = "labelWidthofUniverseinCells";
            this.labelWidthofUniverseinCells.Size = new System.Drawing.Size(128, 13);
            this.labelWidthofUniverseinCells.TabIndex = 6;
            this.labelWidthofUniverseinCells.Text = "Width of Universe in Cells";
            // 
            // labelHeightofUniverseinCells
            // 
            this.labelHeightofUniverseinCells.AutoSize = true;
            this.labelHeightofUniverseinCells.Location = new System.Drawing.Point(64, 108);
            this.labelHeightofUniverseinCells.Name = "labelHeightofUniverseinCells";
            this.labelHeightofUniverseinCells.Size = new System.Drawing.Size(131, 13);
            this.labelHeightofUniverseinCells.TabIndex = 7;
            this.labelHeightofUniverseinCells.Text = "Height of Universe in Cells";
            // 
            // ModalDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(345, 213);
            this.Controls.Add(this.labelHeightofUniverseinCells);
            this.Controls.Add(this.labelWidthofUniverseinCells);
            this.Controls.Add(this.labelTimeIntervalinMIlliseconds);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label labelTimeIntervalinMIlliseconds;
        private System.Windows.Forms.Label labelWidthofUniverseinCells;
        private System.Windows.Forms.Label labelHeightofUniverseinCells;
    }
}