﻿namespace LethalSheet
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
            key1 = new Label();
            key2 = new Label();
            key3 = new Label();
            ship = new Label();
            average = new Label();
            total = new Label();
            sold = new Label();
            quota = new Label();
            credits = new Label();
            day1 = new Label();
            day2 = new Label();
            day3 = new Label();
            quotaNext = new Label();
            quotaPrev = new Label();
            avgReq = new Label();
            reset = new Label();
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
            label2.Size = new Size(488, 55);
            label2.TabIndex = 3;
            label2.Text = "Lethal Sheet v13";
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
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 52, 3);
            label1.Location = new Point(618, 146);
            label1.Margin = new Padding(0, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(334, 44);
            label1.TabIndex = 5;
            label1.Text = "Keybinds:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // key1
            // 
            key1.AutoSize = true;
            key1.BackColor = Color.Transparent;
            key1.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            key1.ForeColor = Color.FromArgb(255, 52, 3);
            key1.Location = new Point(658, 199);
            key1.Margin = new Padding(0, 0, 3, 0);
            key1.Name = "key1";
            key1.Size = new Size(274, 22);
            key1.TabIndex = 6;
            key1.Text = "- Scrap collected: [1]";
            key1.Click += rebind_Key;
            // 
            // key2
            // 
            key2.AutoSize = true;
            key2.BackColor = Color.Transparent;
            key2.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            key2.ForeColor = Color.FromArgb(255, 52, 3);
            key2.Location = new Point(658, 242);
            key2.Margin = new Padding(0, 0, 3, 0);
            key2.Name = "key2";
            key2.Size = new Size(214, 22);
            key2.TabIndex = 7;
            key2.Text = "- Scrap sold: [2]";
            key2.Click += rebind_Key;
            // 
            // key3
            // 
            key3.AutoSize = true;
            key3.BackColor = Color.Transparent;
            key3.Font = new Font("IBM 3270", 16F, FontStyle.Regular, GraphicsUnit.Point);
            key3.ForeColor = Color.FromArgb(255, 52, 3);
            key3.Location = new Point(658, 288);
            key3.Margin = new Padding(0, 0, 3, 0);
            key3.Name = "key3";
            key3.Size = new Size(202, 22);
            key3.TabIndex = 8;
            key3.Text = "- New quota: [3]";
            key3.Click += rebind_Key;
            // 
            // ship
            // 
            ship.AutoSize = true;
            ship.BackColor = Color.Transparent;
            ship.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            ship.ForeColor = Color.FromArgb(255, 52, 3);
            ship.Location = new Point(5, 482);
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
            average.Location = new Point(8, 450);
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
            total.Location = new Point(300, 491);
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
            sold.Location = new Point(300, 450);
            sold.Margin = new Padding(0, 0, 3, 0);
            sold.Name = "sold";
            sold.Size = new Size(150, 32);
            sold.TabIndex = 12;
            sold.Text = "SOLD: ■0";
            // 
            // quota
            // 
            quota.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            quota.BackColor = Color.Transparent;
            quota.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            quota.ForeColor = Color.FromArgb(255, 52, 3);
            quota.Location = new Point(59, 146);
            quota.Margin = new Padding(0, 0, 3, 0);
            quota.Name = "quota";
            quota.Size = new Size(509, 44);
            quota.TabIndex = 13;
            quota.Text = "Quota 1: 0/130 +0";
            quota.TextAlign = ContentAlignment.MiddleCenter;
            quota.Click += quota_Click;
            // 
            // credits
            // 
            credits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            credits.BackColor = Color.Transparent;
            credits.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            credits.ForeColor = Color.FromArgb(255, 52, 3);
            credits.Location = new Point(819, 7);
            credits.Margin = new Padding(0, 0, 3, 0);
            credits.Name = "credits";
            credits.RightToLeft = RightToLeft.No;
            credits.Size = new Size(133, 55);
            credits.TabIndex = 14;
            credits.Text = "■60";
            credits.TextAlign = ContentAlignment.MiddleRight;
            // 
            // day1
            // 
            day1.BackColor = Color.Transparent;
            day1.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            day1.ForeColor = Color.FromArgb(255, 52, 3);
            day1.Location = new Point(179, 199);
            day1.Margin = new Padding(0, 0, 3, 0);
            day1.Name = "day1";
            day1.Size = new Size(261, 32);
            day1.TabIndex = 15;
            day1.Text = "Day 1: ■0";
            day1.TextAlign = ContentAlignment.MiddleCenter;
            day1.Click += day_Click;
            // 
            // day2
            // 
            day2.BackColor = Color.Transparent;
            day2.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            day2.ForeColor = Color.FromArgb(255, 52, 3);
            day2.Location = new Point(179, 242);
            day2.Margin = new Padding(0, 0, 3, 0);
            day2.Name = "day2";
            day2.Size = new Size(261, 32);
            day2.TabIndex = 16;
            day2.Text = "Day 2: ■0";
            day2.TextAlign = ContentAlignment.MiddleCenter;
            day2.Click += day_Click;
            // 
            // day3
            // 
            day3.BackColor = Color.Transparent;
            day3.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            day3.ForeColor = Color.FromArgb(255, 52, 3);
            day3.Location = new Point(179, 288);
            day3.Margin = new Padding(0, 0, 3, 0);
            day3.Name = "day3";
            day3.Size = new Size(261, 32);
            day3.TabIndex = 17;
            day3.Text = "Day 3: ■0";
            day3.TextAlign = ContentAlignment.MiddleCenter;
            day3.Click += day_Click;
            // 
            // quotaNext
            // 
            quotaNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            quotaNext.BackColor = Color.Transparent;
            quotaNext.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            quotaNext.ForeColor = Color.FromArgb(255, 52, 3);
            quotaNext.Location = new Point(571, 146);
            quotaNext.Margin = new Padding(0, 0, 3, 0);
            quotaNext.Name = "quotaNext";
            quotaNext.Size = new Size(44, 44);
            quotaNext.TabIndex = 18;
            quotaNext.Text = ">";
            quotaNext.TextAlign = ContentAlignment.MiddleLeft;
            quotaNext.Click += quotaNext_Click;
            // 
            // quotaPrev
            // 
            quotaPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            quotaPrev.BackColor = Color.Transparent;
            quotaPrev.Font = new Font("IBM 3270", 32F, FontStyle.Regular, GraphicsUnit.Point);
            quotaPrev.ForeColor = Color.FromArgb(255, 52, 3);
            quotaPrev.Location = new Point(12, 146);
            quotaPrev.Margin = new Padding(0, 0, 3, 0);
            quotaPrev.Name = "quotaPrev";
            quotaPrev.Size = new Size(44, 44);
            quotaPrev.TabIndex = 19;
            quotaPrev.Text = "<";
            quotaPrev.TextAlign = ContentAlignment.MiddleLeft;
            quotaPrev.Click += quotaPrev_Click;
            // 
            // avgReq
            // 
            avgReq.AutoSize = true;
            avgReq.BackColor = Color.Transparent;
            avgReq.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            avgReq.ForeColor = Color.FromArgb(255, 52, 3);
            avgReq.Location = new Point(5, 387);
            avgReq.Margin = new Padding(0, 0, 3, 0);
            avgReq.Name = "avgReq";
            avgReq.Size = new Size(354, 32);
            avgReq.TabIndex = 20;
            avgReq.Text = "Average required: ■0";
            // 
            // reset
            // 
            reset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            reset.BackColor = Color.Transparent;
            reset.Font = new Font("IBM 3270", 24F, FontStyle.Regular, GraphicsUnit.Point);
            reset.ForeColor = Color.FromArgb(255, 52, 3);
            reset.Location = new Point(499, 7);
            reset.Margin = new Padding(0, 0, 3, 0);
            reset.Name = "reset";
            reset.RightToLeft = RightToLeft.No;
            reset.Size = new Size(133, 55);
            reset.TabIndex = 21;
            reset.Text = "RESET";
            reset.TextAlign = ContentAlignment.MiddleLeft;
            reset.Click += reset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 10, 10);
            BackgroundImage = Properties.Resources.bg1;
            ClientSize = new Size(960, 540);
            Controls.Add(reset);
            Controls.Add(avgReq);
            Controls.Add(quotaPrev);
            Controls.Add(quotaNext);
            Controls.Add(day3);
            Controls.Add(day2);
            Controls.Add(day1);
            Controls.Add(credits);
            Controls.Add(quota);
            Controls.Add(sold);
            Controls.Add(total);
            Controls.Add(average);
            Controls.Add(ship);
            Controls.Add(key3);
            Controls.Add(key2);
            Controls.Add(key1);
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
        private Label key1;
        private Label key2;
        private Label key3;
        private Label ship;
        private Label average;
        private Label total;
        private Label sold;
        private Label quota;
        private Label credits;
        private Label day1;
        private Label day2;
        private Label day3;
        private Label quotaNext;
        private Label quotaPrev;
        private Label avgReq;
        private Label reset;
    }
}