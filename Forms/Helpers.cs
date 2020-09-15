using System.Collections.Generic;
using System.Windows.Forms;

namespace DiscordAndDragons.Forms
{
    public static class Helpers
    {
        public static void CreateMessageBox(string content)
        {
            MessageBox.Show(content);
        }

        public static void UpdateModifierBoxes(object sender, List<TextBox> modifiers)
        {
            var modifierBox = (TextBox)sender;
            modifiers.ForEach(x => x.Text = modifierBox.Text);
        }
    }
}
