using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DiscordAndDragons
{
    public partial class Nat20Dialog : Form
    {
        public Nat20Dialog()
        {
            InitializeComponent();
            PlayAudio();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayAudio()
        {
            // Url to give the sound location
            System.IO.Stream url;

            // Creates a random instance
            Random rnd = new Random();

            // Generates a number 
            int tempNum = rnd.Next(1, 3);

            // Pick a random sound effect 
            switch (tempNum)
            {
                case 1:
                    url = Properties.Resources.Nat20Dialog_GroupFuckYeah;
                    break;
                case 2:
                    url = Properties.Resources.Nat20Dialog_LezFuckingSick;
                    break;
                default:
                    url = null;
                    break;
            }

            // If it is empty then just quit out
            if (url == null)
                return;

            // Create the soundplayer object
            SoundPlayer player = new SoundPlayer(url);
            player.Play();
        }
    }
}
