namespace LethalSheet
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
            debuglabel = new Label();
            debugimage = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ship = new Label();
            average = new Label();
            total = new Label();
            sold = new Label();
            quota = new Label();
            ((System.ComponentModel.ISupportInitialize)debugimage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // debuglabel
            // 
            debuglabel.AutoSize = true;
            debuglabel.BackColor = Color.Transparent;
            debuglabel.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            debuglabel.ForeColor = Color.FromArgb(255, 52, 3);
            debuglabel.Location = new Point(646, 396);
            debuglabel.Name = "debuglabel";
            debuglabel.Size = new Size(166, 22);
            debuglabel.TabIndex = 1;
            debuglabel.Text = "Result Debug:";
            // 
            // debugimage
            // 
            debugimage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            debugimage.BackColor = Color.Black;
            debugimage.Location = new Point(646, 429);
            debugimage.Margin = new Padding(3, 2, 3, 2);
            debugimage.Name = "debugimage";
            debugimage.Size = new Size(306, 100);
            debugimage.SizeMode = PictureBoxSizeMode.StretchImage;
            debugimage.TabIndex = 2;
            debugimage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("IBM 3270", 40F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 52, 3);
            label2.Location = new Point(8, 7);
            label2.Margin = new Padding(0, 0, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(372, 55);
            label2.TabIndex = 3;
            label2.Text = "Lethal Sheet";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.line1;
            pictureBox1.Location = new Point(12, 68);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(940, 5);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 52, 3);
            label1.Location = new Point(646, 86);
            label1.Margin = new Padding(0, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(226, 44);
            label1.TabIndex = 5;
            label1.Text = "Keybinds:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(255, 52, 3);
            label3.Location = new Point(658, 139);
            label3.Margin = new Padding(0, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(274, 22);
            label3.TabIndex = 6;
            label3.Text = "- Scrap collected: [1]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(255, 52, 3);
            label4.Location = new Point(658, 182);
            label4.Margin = new Padding(0, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(214, 22);
            label4.TabIndex = 7;
            label4.Text = "- Scrap sold: [2]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(255, 52, 3);
            label5.Location = new Point(658, 228);
            label5.Margin = new Padding(0, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(202, 22);
            label5.TabIndex = 8;
            label5.Text = "- New quota: [3]";
            // 
            // ship
            // 
            ship.AutoSize = true;
            ship.BackColor = Color.Transparent;
            ship.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            ship.ForeColor = Color.FromArgb(255, 52, 3);
            ship.Location = new Point(8, 485);
            ship.Margin = new Padding(0, 0, 3, 0);
            ship.Name = "ship";
            ship.Size = new Size(203, 44);
            ship.TabIndex = 9;
            ship.Text = "SHIP: ■0";
            // 
            // average
            // 
            average.AutoSize = true;
            average.BackColor = Color.Transparent;
            average.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            average.ForeColor = Color.FromArgb(255, 52, 3);
            average.Location = new Point(8, 453);
            average.Margin = new Padding(0, 0, 3, 0);
            average.Name = "average";
            average.Size = new Size(133, 32);
            average.TabIndex = 10;
            average.Text = "AVG: ■0";
            // 
            // total
            // 
            total.AutoSize = true;
            total.BackColor = Color.Transparent;
            total.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            total.ForeColor = Color.FromArgb(255, 52, 3);
            total.Location = new Point(306, 494);
            total.Margin = new Padding(0, 0, 3, 0);
            total.Name = "total";
            total.Size = new Size(167, 32);
            total.TabIndex = 11;
            total.Text = "TOTAL: ■0";
            // 
            // sold
            // 
            sold.AutoSize = true;
            sold.BackColor = Color.Transparent;
            sold.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            sold.ForeColor = Color.FromArgb(255, 52, 3);
            sold.Location = new Point(306, 453);
            sold.Margin = new Padding(0, 0, 3, 0);
            sold.Name = "sold";
            sold.Size = new Size(150, 32);
            sold.TabIndex = 12;
            sold.Text = "SOLD: ■0";
            // 
            // quota
            // 
            quota.AutoSize = true;
            quota.BackColor = Color.Transparent;
            quota.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            quota.ForeColor = Color.FromArgb(255, 52, 3);
            quota.Location = new Point(8, 378);
            quota.Margin = new Padding(0, 0, 3, 0);
            quota.Name = "quota";
            quota.Size = new Size(226, 44);
            quota.TabIndex = 13;
            quota.Text = "Q1: 0/130";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 10, 10);
            BackgroundImage = Properties.Resources.bg1;
            ClientSize = new Size(960, 540);
            Controls.Add(quota);
            Controls.Add(sold);
            Controls.Add(total);
            Controls.Add(average);
            Controls.Add(ship);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(debugimage);
            Controls.Add(debuglabel);
            Font = new Font("IBM 3270", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(255, 52, 3);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Opacity = 0.9D;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lethal Sheet";
            TopMost = true;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            ((System.ComponentModel.ISupportInitialize)debugimage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label debuglabel;
        private PictureBox debugimage;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label ship;
        private Label average;
        private Label total;
        private Label sold;
        private Label quota;
    }
}