using MyDick.Discord;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDick
{
    public partial class MainApp : Form
    {
        #region Global variables
        // A list of all the active buttons.
        List<Button> dieButtons = new List<Button>();

        // The number of the currently active button. 
        public int currentActiveDieButton = -1;

        // A temp string to store the old name of the active button.
        public string inactiveButtonName = "";

        public Connection DiscordConnection;

        // Http client to create content
        public HttpClient _Client;

        #endregion

        /// <summary>
        /// Used for initialisation
        /// </summary>
        public MainApp()
        {
            InitializeComponent();
            dieButtons = GetDiceButtons();
            DiscordConnection = new Connection();
            _Client = new HttpClient();
        }

        #region Events

        private void DiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void D4Button_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D4 button the one which is currently active
            currentActiveDieButton = 0;
            inactiveButtonName = D4Button.Name;
            D4Button.Name = "D4Button - Active";

            // Change the D4 button to gold
            ChangeDieColourToGold(D4Button);
        }

        private void D6Button_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D6 button the one which is currently active
            currentActiveDieButton = 1;
            inactiveButtonName = D6Button.Name;
            D6Button.Name = "D6Button - Active";

            //Change the D6 button to gold
            ChangeDieColourToGold(D6Button);
        }

        private void D8Button_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D8 button the one which is currently active
            currentActiveDieButton = 2;
            inactiveButtonName = D8Button.Name;
            D8Button.Name = "D8Button - Active";

            //Change the D8 button to gold
            ChangeDieColourToGold(D8Button);
        }

        private void D10Button_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D10 button the one which is currently active
            currentActiveDieButton = 3;
            inactiveButtonName = D10Button.Name;
            D10Button.Name = "D10Button - Active";

            //Change the D10 button to gold
            ChangeDieColourToGold(D10Button);
        }

        private void D12_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D12 button the one which is currently active
            currentActiveDieButton = 4;
            inactiveButtonName = D12Button.Name;
            D12Button.Name = "D12Button - Active";

            //Change the D12 button to gold
            ChangeDieColourToGold(D12Button);
        }

        private void D20Button_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D20 button the one which is currently active
            currentActiveDieButton = 5;
            inactiveButtonName = D20Button.Name;
            D20Button.Name = "D20Button - Active";

            //Change the D20 button to gold
            ChangeDieColourToGold(D20Button);
        }

        private void D100_Click(object sender, EventArgs e)
        {
            // Checks if there is a die active and if there is then deactivate it
            IsThereADieActive();

            // Makes the D100 button the one which is currently active
            currentActiveDieButton = 6;
            inactiveButtonName = D100Button.Name;
            D100Button.Name = "D100Button - Active";

            //Change the D100 button to gold
            ChangeDieColourToGold(D100Button);
        }

        private void StrSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(StrModTextBox, StrResult, result, modifier);
        }

        private void DexSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(DexModTextBox, DexResult, result, modifier);
        }

        private void ConSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(ConModTextBox, ConResult, result, modifier);
        }

        private void IntSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(IntModTextBox, IntResult, result, modifier);
        }

        private void WisSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(WisModTextBox, WisResult, result, modifier);
        }

        private void CharSavButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(CharModTextBox, CharResult, result, modifier);
        }

        private void AcrobaticCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(AcrobaticsModTextBox, AcrobaticsResultBox, result, modifier);
        }

        private void AnimalHandlingCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(AnimalHandlingModTextBox, AnimalHandlingResultBox, result, modifier);
        }

        private void ArcanaCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(ArcanaModTextBox, ArcanaResultBox, result, modifier);
        }

        private void AthleticsCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(AthleticsModTextBox, AthleticsResultBox, result, modifier);
        }

        private void DeceptionCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(DeceptionModTextBox, DeceptionResultBox, result, modifier);
        }

        private void HistoryCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(HistoryModTextBox, HistoryResultBox, result, modifier);
        }

        private void InsightCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(InsightModTextBox, InsightResultBox, result, modifier);
        }

        private void IntimidationCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(IntimidationModTextBox, IntimidationResultBox, result, modifier);
        }

        private void InvestigationCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(InvestigationModTextBox, InvestigationResultBox, result, modifier);
        }

        private void MedicineCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(MedicineModTextBox, MedicineResultBox, result, modifier);
        }

        private void NatureCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(NatureModTextBox, NatureResultBox, result, modifier);
        }

        private void PerceptionCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(PerceptionModTextBox, PerceptionResultBox, result, modifier);
        }

        private void PerformanceCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(PerformanceModTextBox, PerformanceResultBox, result, modifier);
        }

        private void PersuasionCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(PersuasionModTextBox, PersuasionResultBox, result, modifier);
        }

        private void ReligionCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(ReligionModTextBox, ReligionResultBox, result, modifier);
        }

        private void SleightOfHandCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(SleightOfHandModTextBox, SleightOfHandResultBox, result, modifier);
        }

        private void StealthCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(StealthModTextBox, StealthResultBox, result, modifier);
        }

        private void SurvivalCheckButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(SurvivalModTextBox, SurvivalResultBox, result, modifier);
        }

        private void Weapon1AttackButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(Weapon1AttackModBox, Weapon1AttackResultBox, result, modifier);
        }

        private void Weapon2AttackButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(Weapon2AttackModBox, Weapon2AttackResultBox, result, modifier);
        }

        private void Weapon3AttackButton_Click(object sender, EventArgs e)
        {
            int result = DnD.Helpers.RollDice(1, 21);
            int modifier = 0;
            ApplyModifier(Weapon3AttackModBox, Weapon3AttackResultBox, result, modifier);
        }

        private void Weapon1DamageButton_Click(object sender, EventArgs e)
        {
            int damageRoll = GetSelectedDice(Weapon1AtkDieBox);
            ApplyModifier(Weapon1DamageModBox, Weapon1DamageResultBox, damageRoll, 0, false);
        }

        private void Weapon2DamageButton_Click(object sender, EventArgs e)
        {
            int damageRoll = GetSelectedDice(Weapon2AtkDieBox);
            ApplyModifier(Weapon2DamageModBox, Weapon2DamageResultBox, damageRoll, 0, false);
        }

        private void Weapon3DamageButton_Click(object sender, EventArgs e)
        {
            int damageRoll = GetSelectedDice(Weapon3AtkDieBox);
            ApplyModifier(Weapon3DamageModBox, Weapon3DamageResultBox, damageRoll, 0, false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Rolls the generic dice should they been needed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollDice(object sender, EventArgs e)
        {
            // Check where the button is in the list
            dieButtons = GetDiceButtons();

            switch (currentActiveDieButton)
            {
                //D4
                case 0:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 5).ToString();
                    break;
                //D6
                case 1:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 7).ToString();
                    break;
                //D8
                case 2:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 9).ToString();
                    break;
                //D10
                case 3:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 11).ToString();
                    break;
                //D12
                case 4:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 13).ToString();
                    break;
                case 5:
                    //D20
                    ResultBox.Text = DnD.Helpers.RollDice(1, 21).ToString();
                    break;
                //D100
                case 6:
                    ResultBox.Text = DnD.Helpers.RollDice(1, 100).ToString();
                    break;
                //No dice 
                case -1:
                    MessageBox.Show("You need to select a dice to roll you fuckhead.", "Twat alert!");
                    break;
                //In case of breakages
                default:
                    MessageBox.Show("Something fucked up. I have no idea what. Have you tried turning it on and off again?");
                    break;

            }
        }

        /// <summary>
        /// Function which gets all the buttons which are currently on the windows form
        /// </summary>
        /// <returns>List<Buttons></Buttons><returns> A list of buttons 
        private List<Button> GetDiceButtons()
        {
            // Create the list object
            List<Button> buttonsToReturn = new List<Button>();

            // Grab all the dice buttons
            foreach (Control child in Controls)
            {
                //If it's a button, then check if it is a die buttons
                if (child is Button)
                {
                    Button newButton = new Button();
                    if (child.Tag.ToString() == "DieButton")
                        buttonsToReturn.Add(newButton);
                }
            }

            return buttonsToReturn;
        }

        /// <summary>
        /// This function looks for the active dice button used for the switch statement
        /// </summary>
        /// <param name="buttonList"></param> The list of buttons in their current state
        /// <returns></returns> An integer indicating what the active dice is
        private Button GetActiveDiceButton(List<Button> buttonList)
        {
            // For every button, check if it has the active colour, if it is then send this number back
            for (int i = 0; i < buttonList.Count; i++)
            {
                // THIS IS RETURNING -1 AS THE COLOURS ARE ALWAYS CHANGING TO CONTROL AGAIN
                if (i == currentActiveDieButton)
                    return buttonList[i];
            }
            //Otherwise just return -1
            return null;
        }

        /// <summary>
        /// Gets the currently active button control rather than list element. 
        /// </summary>
        /// <returns>Button</returns> The button which is currently active
        private Button GetActiveControlDiceButton()
        {
            // Foreach button we find, check if it is the current active button, if it is then return it
            foreach (Control c in ActiveForm.Controls)
            {
                foreach (Control childC in c.Controls)
                {
                    if (childC is Button && childC.Name.Contains("Active"))
                    {
                        return childC as Button;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Used to check to see whether or not there is currently a die active. 
        /// </summary>
        private void IsThereADieActive()
        {
            // If there is a dice active then change its colour to grey and change its name to inactive. 
            if (currentActiveDieButton != -1)
            {
                ChangeDieColourFromGold(GetActiveControlDiceButton());
                GetActiveControlDiceButton().Name = inactiveButtonName;
            }
        }

        /// <summary>
        /// Changes the button which has been pressed to gold (active)
        /// </summary>
        /// <param name="clickedButton"></param> The button which has just been clicked
        private void ChangeDieColourToGold(Button clickedButton)
        {
            clickedButton.BackColor = System.Drawing.Color.DarkGoldenrod;
        }

        /// <summary>
        /// Changes the currently active button to gray (non-active)
        /// </summary>
        /// <param name="activeButton"></param> The currently active button
        private void ChangeDieColourFromGold(Button activeButton)
        {
            activeButton.BackColor = System.Drawing.Color.Gainsboro;
        }

        /// <summary>
        /// A method which converts and then applies the modifier if it can otherwise it just shows a message box saying it cannot do so 
        /// </summary>
        /// <param name="modTextBox"></param> The text box which holds the number to modify by
        /// <param name="resultBox"></param> The result to display the diceroll+modifer
        /// <param name="diceRoll"></param> The result of the dice roll 
        /// <param name="modifier"></param> A temp modifier.
        /// <param name="needsDialogs"></param> Bool to indicate if the result of this roll can be a natural failure/success.
        private async void ApplyModifier(TextBox modTextBox, TextBox resultBox, int diceRoll, int modifier, bool needsDialogs = true)
        {
            // Change the colour back to white
            resultBox.BackColor = System.Drawing.Color.WhiteSmoke;

            // If we can use the modifier then continue on. 
            if (int.TryParse(modTextBox.Text, out modifier))
            {
                int res = diceRoll + modifier;
                resultBox.Text = (res).ToString();

                // If we need dialogs for this roll... 
                if (needsDialogs)
                {
                    // If they we have rolled a nat 1
                    if (diceRoll == 1)
                    {
                        // Open the nat 1 dialog and change the colour of the box to red
                        resultBox.BackColor = System.Drawing.Color.Red;
                        Nat1Dialog dialog = new Nat1Dialog();
                        dialog.Show();
                    }
                    else if (diceRoll == 20)
                    {
                        // Open the nat 20 dialog and change the colour of the box to green
                        resultBox.BackColor = System.Drawing.Color.Green;
                        Nat20Dialog dialog = new Nat20Dialog();
                        dialog.Show();
                    }
                }

                var payload = new DiscordMessageObject
                {
                    Content = $"Rolled a {diceRoll} with modifier of {modifier} for a total of {res}"
                };

                var webhookUrl = "https://discordapp.com/api/webhooks/614870234654048289/HUUAliWpSPnse8LU8oIpQflHhYDb9GIA1VC08z2aiXp64tjLl52J9MibwzfG71D1iiZ9";

                var stringPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                await Task.Run(async () => await _Client.PostAsync(webhookUrl, httpContent));

            }
            else
            {
                MessageBox.Show("Could not roll using that modifier.");
            }
        }

        /// <summary>
        /// Used to determine what damage dice the weapon should be rolling
        /// </summary>
        /// <param name="weaponAttackDie"></param> The combo box which has the selected dice
        /// <returns></returns> Returns the dice roll 
        private int GetSelectedDice(ComboBox weaponAttackDie)
        {
            int result = 0;
            switch (weaponAttackDie.SelectedIndex)
            {
                case 0:
                    result = DnD.Helpers.RollDice(1, 5);
                    break;
                case 1:
                    result = DnD.Helpers.RollDice(1, 7);
                    break;
                case 2:
                    result = DnD.Helpers.RollDice(1, 9);
                    break;
                case 3:
                    result = DnD.Helpers.RollDice(1, 11);
                    break;
                case 4:
                    result = DnD.Helpers.RollDice(1, 13);
                    break;
                case 5:
                    result = DnD.Helpers.RollDice(1, 21);
                    break;
                case -1:
                    MessageBox.Show("You need to select a dice. Are you a retard or did you just forget?");
                    break;
                default:
                    MessageBox.Show("Something went wrong. No idea what. Sucks to be you.");
                    break;

            }
            return result;
        }

        #region Program Maintenence

        /// <summary>
        /// Used to save all the information which the user has put in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Sets the saving throw properties
            Properties.Settings.Default.StrMod = StrModTextBox.Text;
            Properties.Settings.Default.DexMod = DexModTextBox.Text;
            Properties.Settings.Default.ConMod = ConModTextBox.Text;
            Properties.Settings.Default.IntMod = IntModTextBox.Text;
            Properties.Settings.Default.WisMod = WisModTextBox.Text;
            Properties.Settings.Default.CharMod = CharModTextBox.Text;

            // Sets the skill check modifiers
            Properties.Settings.Default.AcrobaticsMod = AcrobaticsModTextBox.Text;
            Properties.Settings.Default.AnimalHandlingMod = AnimalHandlingModTextBox.Text;
            Properties.Settings.Default.ArcanaMod = ArcanaModTextBox.Text;
            Properties.Settings.Default.AthleticsMod = AthleticsModTextBox.Text;
            Properties.Settings.Default.DeceptionMod = DeceptionModTextBox.Text;
            Properties.Settings.Default.HistoryMod = HistoryModTextBox.Text;
            Properties.Settings.Default.InsightMod = InsightModTextBox.Text;
            Properties.Settings.Default.IntimidationMod = IntimidationModTextBox.Text;
            Properties.Settings.Default.InvestigationMod = InvestigationModTextBox.Text;
            Properties.Settings.Default.MedicineMod = MedicineModTextBox.Text;
            Properties.Settings.Default.NatureMod = NatureModTextBox.Text;
            Properties.Settings.Default.PerceptionMod = PerceptionModTextBox.Text;
            Properties.Settings.Default.PerformanceMod = PerformanceModTextBox.Text;
            Properties.Settings.Default.PersuasionMod = PersuasionModTextBox.Text;
            Properties.Settings.Default.ReligionMod = ReligionModTextBox.Text;
            Properties.Settings.Default.SleightOfHandMod = SleightOfHandModTextBox.Text;
            Properties.Settings.Default.StealthMod = StealthModTextBox.Text;
            Properties.Settings.Default.SurvivalMod = SurvivalModTextBox.Text;

            // Sets the weapon modifiers. 
            Properties.Settings.Default.Weapon1AttackMod = Weapon1AttackModBox.Text;
            Properties.Settings.Default.Weapon2AttackMod = Weapon2AttackModBox.Text;
            Properties.Settings.Default.Weapon3AttackMod = Weapon3AttackModBox.Text;

            // Set the weapon name properties
            Properties.Settings.Default.Weapon1Name = WeaponOneTextBox.Text;
            Properties.Settings.Default.Weapon2Name = WeaponTwoTextBox.Text;
            Properties.Settings.Default.Weapon3Name = WeaponThreeTextBox.Text;

            // Set the damage modifiers
            Properties.Settings.Default.Weapon1DamageMod = Weapon1DamageModBox.Text;
            Properties.Settings.Default.Weapon2DamageMod = Weapon2DamageModBox.Text;
            Properties.Settings.Default.Weapon3DamageMod = Weapon3DamageModBox.Text;

            // Sets the weapon attack dice
            Properties.Settings.Default.Weapon1DamageDie = Weapon1AtkDieBox.SelectedIndex;
            Properties.Settings.Default.Weapon2DamageDie = Weapon2AtkDieBox.SelectedIndex;
            Properties.Settings.Default.Weapon3DamageDie = Weapon3AtkDieBox.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Used to load all of the previously input fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainApp_Load(object sender, EventArgs e)
        {
            // Sets the saving throw properties
            StrModTextBox.Text = Properties.Settings.Default.StrMod;
            DexModTextBox.Text = Properties.Settings.Default.DexMod;
            ConModTextBox.Text = Properties.Settings.Default.ConMod;
            IntModTextBox.Text = Properties.Settings.Default.IntMod;
            WisModTextBox.Text = Properties.Settings.Default.WisMod;
            CharModTextBox.Text = Properties.Settings.Default.CharMod;

            // Sets the skill check modifiers
            AcrobaticsModTextBox.Text = Properties.Settings.Default.AcrobaticsMod;
            AnimalHandlingModTextBox.Text = Properties.Settings.Default.AnimalHandlingMod;
            ArcanaModTextBox.Text = Properties.Settings.Default.ArcanaMod;
            AthleticsModTextBox.Text = Properties.Settings.Default.AthleticsMod;
            DeceptionModTextBox.Text = Properties.Settings.Default.DeceptionMod;
            HistoryModTextBox.Text = Properties.Settings.Default.HistoryMod;
            InsightModTextBox.Text = Properties.Settings.Default.InsightMod;
            IntimidationModTextBox.Text = Properties.Settings.Default.IntimidationMod;
            InvestigationModTextBox.Text = Properties.Settings.Default.InvestigationMod;
            MedicineModTextBox.Text = Properties.Settings.Default.MedicineMod;
            NatureModTextBox.Text = Properties.Settings.Default.NatureMod;
            PerceptionModTextBox.Text = Properties.Settings.Default.PerceptionMod;
            PerformanceModTextBox.Text = Properties.Settings.Default.PerformanceMod;
            PersuasionModTextBox.Text = Properties.Settings.Default.PersuasionMod;
            ReligionModTextBox.Text = Properties.Settings.Default.ReligionMod;
            SleightOfHandModTextBox.Text = Properties.Settings.Default.SleightOfHandMod;
            StealthModTextBox.Text = Properties.Settings.Default.StealthMod;
            SurvivalModTextBox.Text = Properties.Settings.Default.SurvivalMod;

            // Sets the weapon attack modifiers
            Weapon1AttackModBox.Text = Properties.Settings.Default.Weapon1AttackMod;
            Weapon2AttackModBox.Text = Properties.Settings.Default.Weapon2AttackMod;
            Weapon3AttackModBox.Text = Properties.Settings.Default.Weapon3AttackMod;

            // Set the weapon name properties
            WeaponOneTextBox.Text = Properties.Settings.Default.Weapon1Name;
            WeaponTwoTextBox.Text = Properties.Settings.Default.Weapon2Name;
            WeaponThreeTextBox.Text = Properties.Settings.Default.Weapon3Name;

            // Set the attack dice box properties
            Weapon1AtkDieBox.SelectedIndex = Properties.Settings.Default.Weapon1DamageDie;
            Weapon2AtkDieBox.SelectedIndex = Properties.Settings.Default.Weapon2DamageDie;
            Weapon3AtkDieBox.SelectedIndex = Properties.Settings.Default.Weapon3DamageDie;

            // Sets the damage modifiers
            Weapon1DamageModBox.Text = Properties.Settings.Default.Weapon1DamageMod;
            Weapon2DamageModBox.Text = Properties.Settings.Default.Weapon2DamageMod;
            Weapon3DamageModBox.Text = Properties.Settings.Default.Weapon3DamageMod;

        }

        #endregion

        #endregion
    }
}
