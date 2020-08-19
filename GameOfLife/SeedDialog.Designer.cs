namespace GameOfLife
{
    partial class SeedDialog
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
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(97, 75);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(86, 25);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(189, 75);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Location = new System.Drawing.Point(222, 25);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(96, 20);
            this.buttonRandomize.TabIndex = 8;
            this.buttonRandomize.Text = "Randomize";
            this.buttonRandomize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seed";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(87, 25);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(129, 20);
            this.numericUpDown1.TabIndex = 10;
            // 
            // SeedDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(388, 110);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRandomize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}