using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Xml.Linq;

namespace LethalSheet
{
    public partial class Form1 : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook;

        public Form1()
        {
            InitializeComponent();

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            LethalSheet.Reset();
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                int keycode = e.KeyboardData.VirtualCode;

                if (keycode < 49 || keycode > 51)
                    return;

                Label? outputLabel = this.Controls.Find("debuglabel", true).FirstOrDefault() as Label;
                PictureBox? outputPicture = this.Controls.Find("debugimage", true).FirstOrDefault() as PictureBox;

                Bitmap bmp = null;
                String result = string.Empty;

                switch (keycode)
                {
                    case 49:    // [1] -> collected scrap
                        {
                            result = Screenshot.GetCollectedScrap(out bmp);

                            if (result == String.Empty)
                                break;

                            LethalSheet.AddScrapCollected(int.Parse(result));
                            break;
                        }
                    case 50:    // [2] -> sold scrap
                        {
                            result = Screenshot.GetSoldAmount(out bmp);

                            if (result == String.Empty)
                                break;

                            break;
                        }
                    case 51:    // [3] -> new quota
                        {
                            result = Screenshot.GetNewQuota(out bmp);

                            if (result == String.Empty)
                                break;

                            break;
                        }
                }

                outputLabel.Text = $"Result Debug: {result}";
                outputPicture.Image = bmp;

                RefreshForm();

                e.Handled = true;
            }
        }

        public void RefreshForm()
        {
            Label? shipLabel = this.Controls.Find("ship", true).FirstOrDefault() as Label;
            Label? averageLabel = this.Controls.Find("average", true).FirstOrDefault() as Label;
            Label? soldLabel = this.Controls.Find("sold", true).FirstOrDefault() as Label;
            Label? totalLabel = this.Controls.Find("total", true).FirstOrDefault() as Label;
            Label? quotaLabel = this.Controls.Find("quota", true).FirstOrDefault() as Label;
            Label? creditsLabel = this.Controls.Find("credits", true).FirstOrDefault() as Label;

            String credit = Encoding.UTF8.GetString(new byte[] { 0xE2, 0x96, 0xA0 });

            shipLabel.Text = $"SHIP: {credit}{LethalSheet.overallShip}";
            averageLabel.Text = $"AVG: {credit}{LethalSheet.overallAverage}";
            soldLabel.Text = $"SOLD: {credit}{LethalSheet.overallSold}";
            totalLabel.Text = $"TOTAL: {credit}{LethalSheet.overallTotal}";

            Quota currentQuota = LethalSheet.GetCurrentQuota();
            quotaLabel.Text = $"Q{LethalSheet.currentQuota + 1}: {currentQuota.sold}/{currentQuota.quotaReq} +{LethalSheet.CalculateOvertimeBonus()}";
            creditsLabel.Text = $"{credit}{LethalSheet.currentCredits}";
        }

        private Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}