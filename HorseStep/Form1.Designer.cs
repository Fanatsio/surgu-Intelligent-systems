namespace HorseStep
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(872, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "5";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(872, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            textBox2.Text = "5";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(872, 70);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "2";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(872, 99);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            textBox4.Text = "2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(766, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Введите N";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(766, 44);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Введите M";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(739, 73);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 6;
            label3.Text = "Введите координату X";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(739, 107);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 7;
            label4.Text = "Введите координату Y";
            // 
            // button1
            // 
            button1.Location = new Point(809, 137);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 8;
            button1.Text = "Начать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Panel panel1;
    }
}
