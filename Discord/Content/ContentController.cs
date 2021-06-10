using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordAndDragons.Discord
{
    public class ContentController
    {
        private ContentFactory ContentFactory;

        public ContentController()
        {
            ContentFactory = new ContentFactory();
        }

        public string GetContent(RollInformation rollInformation)
        {
            List<string> contentList = ContentFactory.GetContentList(rollInformation.RollType);

            if (contentList.IsNullOrEmpty())
                return ContentFactory.DefaultContent(rollInformation);

            return ContentFactory.PickCustomContent(rollInformation, contentList);
        }
    }
}