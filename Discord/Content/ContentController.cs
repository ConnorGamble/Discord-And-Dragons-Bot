using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiscordAndDragons.Discord
{
    public class ContentController
    {
        private List<string> Content;
        private Random Random;
        public ContentController()
        {
            Content = Properties.Resources.DiscordContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            Random = new Random();
        }

        public string GetContent()
        {
            var index = Random.Next(0, Content.Count);
            return Content[index];
        }
    }
}