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
    }

    public static class ListExtensions
    {
        public static void UpdateModifiers(this List<TextBox> modifiers, object sender)
        {
            var modifierBox = (TextBox)sender;
            modifiers.ForEach(x => x.Text = modifierBox.Text);
        }
    }
}
