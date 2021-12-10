namespace View
{
    partial class AddForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.CircleRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TriangleRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(43, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButton3
            // 
            this.RectangleRadioButton.AutoSize = true;
            this.RectangleRadioButton.Location = new System.Drawing.Point(195, 29);
            this.RectangleRadioButton.Name = "radioButton3";
            this.RectangleRadioButton.Size = new System.Drawing.Size(93, 21);
            this.RectangleRadioButton.TabIndex = 1;
            this.RectangleRadioButton.TabStop = true;
            this.RectangleRadioButton.Text = "Rectangle";
            this.RectangleRadioButton.UseVisualStyleBackColor = true;
            this.RectangleRadioButton.CheckedChanged += new System.EventHandler(this.RectangleElementsOnFormRadioButton);
            // 
            // radioButton2
            // 
            this.CircleRadioButton.AutoSize = true;
            this.CircleRadioButton.Location = new System.Drawing.Point(125, 29);
            this.CircleRadioButton.Name = "radioButton2";
            this.CircleRadioButton.Size = new System.Drawing.Size(64, 21);
            this.CircleRadioButton.TabIndex = 1;
            this.CircleRadioButton.TabStop = true;
            this.CircleRadioButton.Text = "Circle";
            this.CircleRadioButton.UseVisualStyleBackColor = true;
            this.CircleRadioButton.CheckedChanged += new System.EventHandler(this.CircleElementsOnFormRadioButton);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OkAddFigureButton);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CancelButton);
            // 
            // radioButton1
            // 
            this.TriangleRadioButton.AutoSize = true;
            this.TriangleRadioButton.Checked = true;
            this.TriangleRadioButton.Location = new System.Drawing.Point(29, 29);
            this.TriangleRadioButton.Name = "radioButton1";
            this.TriangleRadioButton.Size = new System.Drawing.Size(81, 21);
            this.TriangleRadioButton.TabIndex = 3;
            this.TriangleRadioButton.TabStop = true;
            this.TriangleRadioButton.Text = "Triangle";
            this.TriangleRadioButton.UseVisualStyleBackColor = true;
            this.TriangleRadioButton.CheckedChanged += new System.EventHandler(this.TriangleElementsOnFormRadioButton);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 471);
            this.Controls.Add(this.RectangleRadioButton);
            this.Controls.Add(this.TriangleRadioButton);
            this.Controls.Add(this.CircleRadioButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "AddFigure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RectangleRadioButton;
        private System.Windows.Forms.RadioButton CircleRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton TriangleRadioButton;
    }
}