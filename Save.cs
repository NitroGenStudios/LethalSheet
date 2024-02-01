using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSheet
{
    public class Save
    {

        public static void SaveState(Form1 form)
        {
            String saveData = $"{LethalSheet.ToString()}!";
            saveData += $"{form.keybinds[0]}|{form.keybinds[1]}|{form.keybinds[2]}";

            // save to file
            File.WriteAllText("save.txt", saveData);
        }

        public static void LoadState(Form1 form)
        {
            if (!File.Exists("save.txt"))
                return;

            // load from file
            String loadedData = File.ReadAllText("save.txt");

            String[] split = loadedData.Split("!");

            LethalSheet.FromString(split[0]);
            form.keybinds = split[1].Split("|").Select(int.Parse).ToArray();
        }

    }
}
