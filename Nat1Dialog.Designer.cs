namespace MyDick
{
    partial class Nat1Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nat1Dialog));
            this.GetFukedText = new System.Windows.Forms.Label();
            this.DrinkBleachText = new System.Windows.Forms.Label();
            this.DrinkBleachGif = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrinkBleachGif)).BeginInit();
            this.SuspendLayout();
            // 
            // GetFukedText
            // 
            this.GetFukedText.AutoSize = true;
            this.GetFukedText.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetFukedText.Location = new System.Drawing.Point(87, 9);
            this.GetFukedText.Name = "GetFukedText";
            this.GetFukedText.Size = new System.Drawing.Size(151, 33);
            this.GetFukedText.TabIndex = 0;
            this.GetFukedText.Text = "GET FUKD.";
            // 
            // DrinkBleachText
            // 
            this.DrinkBleachText.AutoSize = true;
            this.DrinkBleachText.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrinkBleachText.Location = new System.Drawing.Point(57, 42);
            this.DrinkBleachText.Name = "DrinkBleachText";
            this.DrinkBleachText.Size = new System.Drawing.Size(208, 33);
            this.DrinkBleachText.TabIndex = 1;
            this.DrinkBleachText.Text = "DRINK BLEACH";
            // 
            // DrinkBleachGif
            // 
            this.DrinkBleachGif.Image = global::MyDick.Properties.Resources.tenor;
            this.DrinkBleachGif.Location = new System.Drawing.Point(63, 78);
            this.DrinkBleachGif.Name = "DrinkBleachGif";
            this.DrinkBleachGif.Size = new System.Drawing.Size(200, 175);
            this.DrinkBleachGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrinkBleachGif.TabIndex = 2;
            this.DrinkBleachGif.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(77, 259);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(175, 33);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "I am so glad I can die.";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Nat1Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 304);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DrinkBleachGif);
            this.Controls.Add(this.DrinkBleachText);
            this.Controls.Add(this.GetFukedText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nat1Dialog";
            this.Text = "You fucking suck.";
            ((System.ComponentModel.ISupportInitialize)(this.DrinkBleachGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GetFukedText;
        private System.Windows.Forms.Label DrinkBleachText;
        private System.Windows.Forms.PictureBox DrinkBleachGif;
        private System.Windows.Forms.Button CloseButton;
    }
}