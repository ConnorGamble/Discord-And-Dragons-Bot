namespace DiscordAndDragons
{
    partial class Nat20Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nat20Dialog));
            this.YouRektText = new System.Windows.Forms.Label();
            this.DrinkBleachText = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DrinkBleachGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrinkBleachGif)).BeginInit();
            this.SuspendLayout();
            // 
            // YouRektText
            // 
            this.YouRektText.AutoSize = true;
            this.YouRektText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YouRektText.Location = new System.Drawing.Point(107, 9);
            this.YouRektText.Name = "YouRektText";
            this.YouRektText.Size = new System.Drawing.Size(115, 31);
            this.YouRektText.TabIndex = 0;
            this.YouRektText.Text = "You rekt";
            // 
            // DrinkBleachText
            // 
            this.DrinkBleachText.AutoSize = true;
            this.DrinkBleachText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrinkBleachText.Location = new System.Drawing.Point(63, 42);
            this.DrinkBleachText.Name = "DrinkBleachText";
            this.DrinkBleachText.Size = new System.Drawing.Size(202, 31);
            this.DrinkBleachText.TabIndex = 1;
            this.DrinkBleachText.Text = "Fucken \'ell cunt";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(77, 259);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(175, 33);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Fuck yeah cunt";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DrinkBleachGif
            // 
            this.DrinkBleachGif.Image = global::DiscordAndDragons.Properties.Resources.ClarenceFuckYeah;
            this.DrinkBleachGif.Location = new System.Drawing.Point(16, 78);
            this.DrinkBleachGif.Name = "DrinkBleachGif";
            this.DrinkBleachGif.Size = new System.Drawing.Size(297, 175);
            this.DrinkBleachGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrinkBleachGif.TabIndex = 2;
            this.DrinkBleachGif.TabStop = false;
            // 
            // Nat20Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 304);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DrinkBleachGif);
            this.Controls.Add(this.DrinkBleachText);
            this.Controls.Add(this.YouRektText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nat20Dialog";
            this.Text = "NAT20BOIIIIZ";
            ((System.ComponentModel.ISupportInitialize)(this.DrinkBleachGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label YouRektText;
        private System.Windows.Forms.Label DrinkBleachText;
        private System.Windows.Forms.PictureBox DrinkBleachGif;
        private System.Windows.Forms.Button CloseButton;
    }
}