using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace LethalSheet
{
    public partial class Form1 : Form
    {
        // some constants to make keys less confusing
        const int ESC = 27;
        const int ENTER = 13;
        const int BACKSPACE = 8;

        public enum modificationType
        {
            day, quota
        }

        private GlobalKeyboardHook _globalKeyboardHook;
        private int selectedQuota;

        private bool isModifyingValue = false;
        private int dayToModify = 0;
        private Label modifyLabel = null;
        private String modificationBase = "";
        private String currentModification = String.Empty;
        private modificationType modType = modificationType.day;

        private int[] quotaMod = new int[2];
        private int currentQuotaMod = 0;

        private int[] keybinds = new int[] { 49, 50, 51 };
        private bool isRebinding = false;
        private Label keybindLabel = null;
        private int selectedKeybindSlot = 0;

        Color defaultColor = Color.FromArgb(255, 52, 3);
        String credit = Encoding.UTF8.GetString(new byte[] { 0xE2, 0x96, 0xA0 });

        public Form1()
        {
            InitializeComponent();

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            LethalSheet.Reset();
            RefreshForm();
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            int keycode = e.KeyboardData.VirtualCode;

            if (e.KeyboardState != GlobalKeyboardHook.KeyboardState.KeyDown)
                return;

            // handle day modifications
            if (isModifyingValue)
            {
                HandleModification(keycode);
                return;
            }

            // handle keybinds
            if (isRebinding)
            {
                HandleRebind(keycode);
                return;
            }

            Label? outputLabel = this.Controls.Find("debuglabel", true).FirstOrDefault() as Label;
            PictureBox? outputPicture = this.Controls.Find("debugimage", true).FirstOrDefault() as PictureBox;

            Bitmap bmp = null;
            String result = string.Empty;

            if (keycode == keybinds[0])   // [1] -> collected scrap
            {
                result = Screenshot.GetCollectedScrap(out bmp);

                if (result == String.Empty)
                    goto done;

                try { LethalSheet.AddScrapCollected(int.Parse(result)); }
                catch { Debug.WriteLine($"int parse error: {result}"); }
            }
            else if (keycode == keybinds[1])    // [2] -> sold scrap
            {
                result = Screenshot.GetSoldAmount(out bmp);

                if (result == String.Empty)
                    goto done;

                try { LethalSheet.AddScrapSold(int.Parse(result)); }
                catch { Debug.WriteLine($"int parse error: {result}"); }
            }
            else if (keycode == keybinds[2])    // [3] -> new quota
            {
                result = Screenshot.GetNewQuota(out bmp);

                if (result == String.Empty)
                    goto done;

                try
                {
                    selectedQuota = LethalSheet.currentQuota + 1;
                    LethalSheet.SetNewQuota(int.Parse(result));
                }
                catch { Debug.WriteLine($"int parse error: {result}"); }
            }
            else
            {
                return;
            }

            done:

            outputLabel.Text = $"Result Debug: {result}";
            outputPicture.Image = bmp;

            RefreshForm();

            e.Handled = true;
        }

        private void HandleRebind(int keycode)
        {
            // cancel
            if (keycode == ESC)
            {
                // stop modifying the key
                isRebinding = false;
                keybindLabel.ForeColor = defaultColor;

                RefreshForm();
                return;
            }

            keybinds[selectedKeybindSlot] = keycode;

            // stop modifying the key
            isRebinding = false;
            keybindLabel.ForeColor = defaultColor;

            RefreshForm();
            return;
        }

        private void HandleModification(int keycode)
        {
            // cancel
            if (keycode == ESC)
            {
                // stop modifying the day
                isModifyingValue = false;
                modifyLabel.ForeColor = defaultColor;

                RefreshForm();
                return;
            }

            // submit
            if (keycode == ENTER)
            {
                // enter modification
                if (modType == modificationType.day)
                    LethalSheet.GetQuota(selectedQuota).SetDay(dayToModify, int.Parse(currentModification));
                if (modType == modificationType.quota)
                {
                    if (currentQuotaMod == 0)
                    {
                        quotaMod[0] = int.Parse(currentModification);
                        currentModification = "";
                        currentQuotaMod = 1;
                        return;
                    }

                    if (currentModification != "")
                        quotaMod[1] = int.Parse(currentModification);

                    LethalSheet.GetQuota(selectedQuota).sold = quotaMod[0];
                    LethalSheet.GetQuota(selectedQuota).quotaReq = quotaMod[1];
                }

                // stop modifying the day
                isModifyingValue = false;
                modifyLabel.ForeColor = defaultColor;

                // force recalculate
                LethalSheet.Recalculate();

                RefreshForm();
                return;
            }

            // handle deletion
            if (keycode == BACKSPACE && currentModification.Length > 0)
            {
                // remove last number and update text
                currentModification.Remove(currentModification.Length - 1, 1);

                if (modType == modificationType.day)
                    modifyLabel.Text = String.Format(modificationBase, dayToModify + 1, currentModification);
                if (modType == modificationType.quota && currentQuotaMod == 0)
                    modifyLabel.Text = String.Format(modificationBase, selectedQuota, currentModification, quotaMod[1]);
                if (modType == modificationType.quota && currentQuotaMod == 1)
                    modifyLabel.Text = String.Format(modificationBase, selectedQuota, quotaMod[0], currentModification);

                return;
            }

            // figure out the number pressed, 48 in ASCII is "0"
            int numberKey = keycode - 48;

            if (numberKey < 0 || numberKey >= 10)
                return;

            // add number to the end of the string
            currentModification += numberKey.ToString();

            // modify text
            if (modType == modificationType.day)
                modifyLabel.Text = String.Format(modificationBase, dayToModify + 1, currentModification);
            if (modType == modificationType.quota && currentQuotaMod == 0)
                modifyLabel.Text = String.Format(modificationBase, selectedQuota, currentModification, quotaMod[1]);
            if (modType == modificationType.quota && currentQuotaMod == 1)
                modifyLabel.Text = String.Format(modificationBase, selectedQuota, quotaMod[0], currentModification);
        }

        public void RefreshForm()
        {
            this.ship.Text = $"SHIP: {credit}{LethalSheet.overallShip}";
            this.average.Text = $"AVG: {credit}{LethalSheet.overallAverage}";
            this.sold.Text = $"SOLD: {credit}{LethalSheet.overallSold}";
            this.total.Text = $"TOTAL: {credit}{LethalSheet.overallTotal}";

            Quota quota = LethalSheet.GetQuota(selectedQuota);
            this.quota.Text = $"Quota {selectedQuota + 1}: {quota.sold}/{quota.quotaReq} +{LethalSheet.CalculateOvertimeBonus()}";
            this.credits.Text = $"{credit}{LethalSheet.currentCredits}";

            this.avgReq.Text = $"Average required: {credit}{LethalSheet.CalculateAverageRequiredToCompleteRun()}";

            this.day1.Text = $"Day 1: {credit}{quota.days[0]}";
            this.day2.Text = $"Day 2: {credit}{quota.days[1]}";
            this.day3.Text = $"Day 3: {credit}{quota.days[2]}";

            this.key1.Text = $"- Scrap collected: [{(char)keybinds[0]}]";
            this.key2.Text = $"- Scrap sold: [{(char)keybinds[1]}]";
            this.key3.Text = $"- New quota: [{(char)keybinds[2]}]";
        }

        private void quotaNext_Click(object sender, EventArgs e)
        {
            if (isModifyingValue)
                return;

            selectedQuota = Math.Min(selectedQuota + 1, LethalSheet.numOfQuotas - 1);
            RefreshForm();
        }

        private void quotaPrev_Click(object sender, EventArgs e)
        {
            if (isModifyingValue)
                return;

            selectedQuota = Math.Max(selectedQuota - 1, 0);
            RefreshForm();
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

        private void day_Click(object sender, EventArgs e)
        {
            if (isRebinding || isModifyingValue)
                return;

            currentModification = "";
            modifyLabel = sender as Label;
            modifyLabel.ForeColor = Color.White;
            dayToModify = int.Parse(Screenshot.RemoveLetters(modifyLabel.Name)) - 1;
            isModifyingValue = true;

            modType = modificationType.day;

            modificationBase = "Day {0}: " + credit + "{1}";
        }

        private void quota_Click(object sender, EventArgs e)
        {
            if (isRebinding || isModifyingValue)
                return;

            currentQuotaMod = 0;
            quotaMod[0] = 0;
            quotaMod[1] = LethalSheet.GetQuota(selectedQuota).quotaReq;

            currentModification = "";
            modifyLabel = sender as Label;
            modifyLabel.ForeColor = Color.White;
            isModifyingValue = true;
            dayToModify = selectedQuota; // this is a stupid workaround lmao

            modType = modificationType.quota;

            modificationBase = "Quota {0}: {1}/{2} +0";
        }

        private void reset_Click(object sender, EventArgs e)
        {
            LethalSheet.Reset();
            RefreshForm();
        }

        private void rebind_Key(object sender, EventArgs e)
        {
            if (isRebinding || isModifyingValue)
                return;

            isRebinding = true;
            keybindLabel = sender as Label;
            selectedKeybindSlot = int.Parse(keybindLabel.Name.Last().ToString()) - 1;
            keybindLabel.ForeColor = Color.White;
        }
    }
}