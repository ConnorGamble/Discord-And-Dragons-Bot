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
        // Create the soundplayer object
        private SoundPlayer player = new SoundPlayer();

        public Nat1Dialog()
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
            //string u
            // Determine which file needs is going to be played


            // Find the audio file
            // player.SoundLocation = 
            // Play the audio file
            // Wait for it to finish 
            // Close the music player 
        }
    }
}
