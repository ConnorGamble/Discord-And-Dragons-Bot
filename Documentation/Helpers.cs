namespace MyDick.Documentation
{
    public class Helpers
    {
        public static void OpenHelpDocumentation(DocumentationType documentationType)
        {
            string url;

            switch (documentationType)
            {
                case DocumentationType.HowTo:
                    url = "https://www.connorgamble.com/discord-and-dragons-how-to";
                    break;
                case DocumentationType.BotSetup:
                default:
                    url = "https://www.connorgamble.com/discord-and-dragons";
                    break;
            }

            System.Diagnostics.Process.Start(url);
        }
    }

    public enum DocumentationType
    {
        BotSetup, 
        HowTo
    }
}
