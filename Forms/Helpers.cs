using System.Windows.Forms;

namespace MyDick.Forms
{
    public static class Helpers
    {
        public static void CreateMessageBox(string content)
        {
            MessageBox.Show(content);
        }

        public static void OpenHelpDocumentation()
        {
            System.Diagnostics.Process.Start("https://www.connorgamble.com/discord-and-dragons");
        }
    }
}
