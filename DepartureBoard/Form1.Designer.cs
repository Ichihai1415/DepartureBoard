namespace DepartureBoard
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
            components = new System.ComponentModel.Container();
            TB_main = new TextBox();
            B_Restart = new Button();
            Ti_Sub = new System.Windows.Forms.Timer(components);
            Ti_Scroll = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // TB_main
            // 
            TB_main.Location = new Point(50, 12);
            TB_main.Multiline = true;
            TB_main.Name = "TB_main";
            TB_main.Size = new Size(738, 330);
            TB_main.TabIndex = 0;
            // 
            // B_Restart
            // 
            B_Restart.Location = new Point(24, 386);
            B_Restart.Name = "B_Restart";
            B_Restart.Size = new Size(94, 29);
            B_Restart.TabIndex = 1;
            B_Restart.Text = "button1";
            B_Restart.UseVisualStyleBackColor = true;
            B_Restart.Click += B_Restart_Click;
            // 
            // Ti_Sub
            // 
            Ti_Sub.Interval = 500;
            Ti_Sub.Tick += Ti_Sub_Tick;
            // 
            // Ti_Scroll
            // 
            Ti_Scroll.Interval = 1;
            Ti_Scroll.Tick += Ti_Scroll_Tick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(32, 330);
            textBox1.TabIndex = 2;
            textBox1.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(B_Restart);
            Controls.Add(TB_main);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_main;
        private Button B_Restart;
        private System.Windows.Forms.Timer Ti_Sub;
        private System.Windows.Forms.Timer Ti_Scroll;
        private TextBox textBox1;
    }
}
