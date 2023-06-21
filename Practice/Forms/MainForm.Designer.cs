namespace Practice
{
    partial class MainForm
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
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(690, 49);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 0;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 140);
            button1.Name = "button1";
            button1.Size = new Size(161, 282);
            button1.TabIndex = 0;
            button1.Text = "Заказ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(91, 12);
            button2.Name = "button2";
            button2.Size = new Size(633, 104);
            button2.TabIndex = 1;
            button2.Text = "Продажи";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(625, 140);
            button4.Name = "button4";
            button4.Size = new Size(163, 282);
            button4.TabIndex = 2;
            button4.Text = "Поставщики";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(241, 140);
            button5.Name = "button5";
            button5.Size = new Size(318, 129);
            button5.TabIndex = 3;
            button5.Text = "Склад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(241, 305);
            button6.Name = "button6";
            button6.Size = new Size(318, 117);
            button6.TabIndex = 4;
            button6.Text = "Поставки";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}