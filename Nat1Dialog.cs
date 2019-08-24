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

namespace MyDick
{
    public partial class Nat1Dialog : Form
    {
        public Nat1Dialog()
        {
            InitializeComponent();
            PlayAudio();
        }

        /// <summary>
        /// The click event which will close the dialog box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }

        /// <summary>
        /// A method which will pick a random number and then use that number to pick what audio to play
        /// </summary>
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
                    url = Properties.Resources.Nat1Dialog_DonnyFuck;
                    break;
                case 2:
                    url = Properties.Resources.Nat1Dialog_MikeNolan;
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

            // Play the audio
            player.Play();
        }
    }
}
