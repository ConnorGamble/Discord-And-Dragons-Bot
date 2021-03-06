﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace DiscordAndDragons.Forms
{
    public static class Helpers
    {
        public static void CreateMessageBox(string content)
        {
            MessageBox.Show(content);
        }
    }

    public static class ListExtensions
    {
        public static void UpdateModifiers(this List<TextBox> modifiers, object sender)
        {
            var modifierBox = (TextBox)sender;
            modifiers.ForEach(x => x.Text = modifierBox.Text);
        }

        public static bool ContainsMultipleRolls(this List<RollInformation> modifiers)
        {
            if (modifiers.Count > 1)
                return true;

            return false;
        }

        public static bool IsEmpty(this List<RollInformation> modifiers)
        {
            if (modifiers.Count > 0)
                return false;

            return true;
        }
    }
}
