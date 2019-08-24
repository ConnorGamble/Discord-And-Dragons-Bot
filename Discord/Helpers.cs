using System;

namespace MyDick.Discord
{
    public static class Helpers
    {
        public static bool IsCommand(string message)
        {
            if (message[0] == '!')
                return true;
            else
                return false;
        }

        public static bool IsEmote(string message)
        {
            string emojiList = " <:SassyChoice:614514191897722890><:WAAAHH:367060898457583616> <:Simon5Head:589928513348436121> <:Sassy_Choice:426084105457762339> <:PogChamp:367061192625094659> <:Penis:367057752259821579> <:PedoBear:595324585709142016> <:NayeonDisgust:606861141620031488> <:MingLee:367061126342508544> <:MelWot:370265770070114305> <:MelWot:492792192000327710> <:MelsyCunt:367055304719990795> <:JackSlightSmile:367059949584515082> <:DoggoScared:471347360644202516> <:Dadbury:595323587695476767> <:AlexLikey:606861141578088457> <:AlexDerp:471346689677066240> <:AlexConfused:469968458600415233> <:AlexCaveMan:486986740301692938>";

            if (emojiList.Contains(message))
                return true;
            else
                return false;
        }

        public static bool ShouldRepeatEmote()
        {
            var shouldRepeat = new Random();

            var randomNumber = shouldRepeat.Next(0, 10);

            if (randomNumber < 3)
                return true;
            else
                return false;
        }
    }
}
