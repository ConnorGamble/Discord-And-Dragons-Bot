using MyDick.Discord;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        // Access to the Discord bot, used to send DM's
        public Connection DiscordConnection;

        public bool IsPrivateRoll;

        #endregion

        #region Private global variables

        private CurrentHealthState CurrentHealthState;
        private List<CheckBox> SuccessBoxes;
        private List<CheckBox> FailureBoxes;


        #endregion

        /// <summary>
        /// Used for initialisation
        /// </summary>
        public MainApp()
        {
            InitializeComponent();
            dieButtons = GetDiceButtons();
            DiscordConnection = new Connection();
            SuccessBoxes = GetCheckBoxes("DeathSaveSuccessContainer");
            FailureBoxes = GetCheckBoxes("DeathSaveFailureContainer");
        }

        #region Events

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

        #region Saving throw events

        private void StrSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void CharSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void DexSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void ConSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void IntSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void WisSavButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        #endregion

        #region Skill check

        private void AcrobaticCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void AnimalHandlingCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void ArcanaCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void AthleticsCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);

        }

        private void DeceptionCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void HistoryCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void InsightCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void IntimidationCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void InvestigationCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void MedicineCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void NatureCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void PerceptionCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void PerformanceCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void PersuasionCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);

        }

        private void ReligionCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void SleightOfHandCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void StealthCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        private void SurvivalCheckButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender);
        }

        #endregion

        #region Attacks

        private void Weapon1AttackButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender, false);
        }

        private void Weapon2AttackButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender, false);
        }

        private void Weapon3AttackButton_Click(object sender, EventArgs e)
        {
            RollWithModifier(sender, false);
        }

        #endregion

        #region Damage

        private void Weapon1DamageButton_Click(object sender, EventArgs e)
        {
            var selectedDiceType = GetSelectedDice(Weapon1AtkDieBox);
            RollWithModifier(sender, false, selectedDiceType);
        }

        private void Weapon2DamageButton_Click(object sender, EventArgs e)
        {
            var selectedDiceType = GetSelectedDice(Weapon2AtkDieBox);
            RollWithModifier(sender, false, selectedDiceType);
        }

        private void Weapon3DamageButton_Click(object sender, EventArgs e)
        {
            var selectedDiceType = GetSelectedDice(Weapon3AtkDieBox);
            RollWithModifier(sender, false, selectedDiceType);
        }

        #endregion

        #region HP and death saves

        private void HPIncreaseButton_Click(object sender, EventArgs e)
        {
            HandleHealthChange(true);
        }

        private void HPDecreaseButton_Click(object sender, EventArgs e)
        {
            HandleHealthChange(false);
        }

        private void DeathSaveButton_Click(object sender, EventArgs e)
        {
            var roll = DnD.Helpers.RollDice(DiceType.D20);


            var successes = SuccessBoxes.Where(x => x.Checked).Count();
            var failures = FailureBoxes.Where(x => x.Checked).Count();
            if (successes == 3 || failures == 3)
                ResetDeathSavingBoxes();

            GetControlWithName("DeathSaveRollBox").Text = roll.ToString();

            // uncheck all as stable
            if (roll == 20)
            {
                SuccessBoxes.ForEach(x => x.Checked = true);
            }
            else if (roll == 1)
            {
                // add two because you done fucked
                var i = 2;
                foreach (CheckBox box in FailureBoxes)
                {
                    if (i == 0)
                        break;

                    if (box.Checked)
                        continue;

                    box.Checked = true;
                    i--;
                }
            }
            else if (roll >= 10)
            {
                foreach (CheckBox box in SuccessBoxes)
                {
                    if (box.Checked)
                        continue;

                    box.Checked = true;
                    break;
                }
            }
            else
            {
                foreach (CheckBox box in FailureBoxes)
                {
                    if (box.Checked)
                        continue;

                    box.Checked = true;
                    break;
                }
            }

            var updatedSuccesses = SuccessBoxes.Where(x => x.Checked).Count();
            var updatedFailures = FailureBoxes.Where(x => x.Checked).Count();

            CurrentHealthState?.UpdateCurrentHealthState(updatedSuccesses, updatedFailures);

            DiscordConnection.SendToCorrectTextChat(new MessageRequest
            {
                Content = Helpers.DetermineContentToSendToDiscord(new RollInformation
                {
                    CharacterName = CharacterNameTextBox.Text,
                    DiceRoll = roll,
                    RollType = RollType.DeathSave,
                    CurrentHealthState = CurrentHealthState == null ? CurrentHealthState = new CurrentHealthState(updatedSuccesses, updatedFailures) : CurrentHealthState,
                    DiceType = DiceType.D20

                }),
                IsPrivateRoll = IsPrivateRoll,
                Ids = new ChannelIds
                {
                    ChannelID = Properties.Settings.Default.ChannelID,
                    DMUserID = Properties.Settings.Default.DMUserID,
                    ServerID = Properties.Settings.Default.ServerID
                }
            });

            DetermineBecomingStableOrDying(roll == 20);
        }

        #endregion

        #region Discord integration info changes

        private void BotTokenTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BotToken = BotTokenTextBox.Text;
        }

        private void ChannelIDTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChannelID = ChannelDTextBox.Text;
        }

        private void ServerIDTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerID = ServerIDTextBox.Text;
        }

        private void DMUserIDTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DMUserID = DMUserIDTextBox.Text;
        }

        #endregion

        private void PrivateRoll_CheckedChanged(object sender, EventArgs e)
        {
            if (PrivateRollCheckBox.Checked)
                IsPrivateRoll = true;
            else
                IsPrivateRoll = false;
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

            var content = "";

            switch (currentActiveDieButton)
            {
                //D4
                case 0:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D4).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D4 and got a result of {ResultBox.Text}";
                    break;
                //D6
                case 1:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D6).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D6 and got a result of {ResultBox.Text}";
                    break;
                //D8
                case 2:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D8).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D8 and got a result of {ResultBox.Text}";
                    break;
                //D10
                case 3:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D10).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D10 and got a result of {ResultBox.Text}";
                    break;
                //D12
                case 4:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D12).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D12 and got a result of {ResultBox.Text}";
                    break;
                case 5:
                    //D20
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D20).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D20 and got a result of {ResultBox.Text}";
                    break;
                //D100
                case 6:
                    ResultBox.Text = DnD.Helpers.RollDice(DiceType.D100).ToString();
                    content = $"{CharacterNameTextBox.Text} rolled a D100 and got a result of {ResultBox.Text}";
                    break;
                //No dice 
                case -1:
                    MessageBox.Show("You need to select a dice to roll you fuckhead.", "Twat alert!");
                    break;
                //In case of breakages
                default:
                    MessageBox.Show("Something fucked up. I have no idea what. Have you tried turning it on and off again?");
                    return;
            }

            if (String.IsNullOrEmpty(content))
                return;

            var requestChannelIds = new ChannelIds
            {
                ChannelID = Properties.Settings.Default.ChannelID,
                ServerID = Properties.Settings.Default.ServerID,
                DMUserID = Properties.Settings.Default.DMUserID
            };

            var idVerification = requestChannelIds.VerifyIds();

            if (!idVerification.Item1)
            {
                MessageBox.Show($"Could not convert {idVerification.Item2} correctly. Double check the value which has been input.");
                return;
            }

            DiscordConnection.SendToCorrectTextChat(new MessageRequest
            {
                Content = content,
                IsPrivateRoll = IsPrivateRoll,
                Ids = new ChannelIds
                {
                    ChannelID = Properties.Settings.Default.ChannelID,
                    DMUserID = Properties.Settings.Default.DMUserID,
                    ServerID = Properties.Settings.Default.ServerID
                }
            });
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
            foreach (Control c in MainForm.TabPages[0].Controls)
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
            activeButton.BackColor = System.Drawing.Color.DimGray;
        }

        /// <summary>
        /// Handles the health to be incremented or decremented
        /// </summary>
        /// <param name="increase"></param>
        private void HandleHealthChange(bool increase)
        {
            var newHp = 0;
            try
            {
                newHp = int.Parse(HPTextBox.Text);
            }
            catch
            {
                MessageBox.Show("No characters other than whole numbers allowed as health. Maybe use a number like literally any other person playing this game?");
                return;
            }

            if (increase)
                newHp++;
            else
                newHp--;

            HPTextBox.Text = newHp.ToString();
        }

        /// <summary>
        /// Send the given content to Discord
        /// </summary>
        /// <param name="newResult">Information about the new roll result</param>
        private void SendToDiscord(RollInformation newResult)
        {
            if (newResult.HasError)
                return;

            var discordContent = Helpers.DetermineContentToSendToDiscord(newResult);

            var requestChannelIds = new ChannelIds
            {
                ChannelID = Properties.Settings.Default.ChannelID,
                ServerID = Properties.Settings.Default.ServerID,
                DMUserID = Properties.Settings.Default.DMUserID
            };

            var idVerification = requestChannelIds.VerifyIds();

            if (!idVerification.Item1)
            {
                MessageBox.Show($"Could not convert {idVerification.Item2} correctly. Double check the value which has been input.");
                return;
            }

            DiscordConnection.SendToCorrectTextChat(new MessageRequest
            {
                Content = discordContent,
                IsPrivateRoll = IsPrivateRoll,
                Ids = requestChannelIds
            });
        }

        private void RollWithModifier(object sender, bool isSkill = true, DiceType diceType = DiceType.D20)
        {
            var rollInfo = new RollInformation();
            var button = sender as Button;
            var tags = button.Tag?.ToString().Split(',');

            var diceRoll = DnD.Helpers.RollDice(diceType);

            var modifier = 0;

            var skillType = SkillType.Unknown;
            var weaponTag = tags[0];

            if (isSkill)
                skillType = (SkillType)Enum.Parse(typeof(SkillType), tags[0]);

            var rollType = (RollType)Enum.Parse(typeof(RollType), tags[1]);
            var modifierBox = GetModifierBoxFromRollType(skillType, rollType, tags[0]);

            if (int.TryParse(modifierBox.Text, out modifier))
            {
                var result = diceRoll + modifier;

                var resultBox = new TextBox();

                if (isSkill)
                    resultBox = GetSkillResultBox(skillType);
                else
                    resultBox = GetAttackResultBox(weaponTag);

                resultBox.Text = result.ToString();

                if (rollType == RollType.SavingThrow || rollType == RollType.SkillCheck || rollType == RollType.Attack)
                    resultBox.BackColor = ChangeResultColour(diceRoll);

                rollInfo = new RollInformation
                {
                    DiceRoll = diceRoll,
                    Modifier = modifier,
                    Result = result,
                    SkillType = skillType,
                    RollType = rollType,
                    DiceType = diceType,
                    CharacterName = CharacterNameTextBox.Text,
                    WeaponName = GetWeaponName(weaponTag)
                };
            }
            else
            {
                MessageBox.Show("Cannot roll using that modifier. Please ensure this is a number.");
                rollInfo = new RollInformation
                {
                    HasError = true
                };
            }


            // Handle Discord content
            SendToDiscord(rollInfo);
        }

        private TextBox GetAttackResultBox(string weaponTag)
        {
            var modifierTag = $"{weaponTag}AttackResultBox";
            foreach (Control c in MainForm.TabPages[0].Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        if (childControl is TextBox)
                        {
                            if (childControl.Tag?.ToString() == modifierTag)
                            {
                                return (TextBox)childControl;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private TextBox GetModifierBoxFromRollType(SkillType skillType, RollType rollType, string weaponTag)
        {
            switch (rollType)
            {
                case RollType.SavingThrow:
                case RollType.SkillCheck:
                    return GetSkillModifierBox(skillType);
                case RollType.Damage:
                case RollType.Attack:
                    return GetAttackModifierBox(weaponTag, rollType);
                default:
                    return null;
            }
        }

        private TextBox GetSkillModifierBox(SkillType skillType)
        {
            var modifierTag = $"{skillType.ToString()}ModBox";
            foreach (Control c in MainForm.TabPages[0].Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        if (childControl is TextBox)
                        {
                            if (childControl.Tag?.ToString() == modifierTag)
                            {
                                return (TextBox)childControl;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private TextBox GetAttackModifierBox(string weaponTag, RollType rollType)
        {
            // Weapon1DamageModBox
            var modifierTag = $"{weaponTag}AttackModBox";

            if (rollType == RollType.Damage)
                modifierTag = $"{weaponTag}DamageModBox";

            foreach (Control c in MainForm.TabPages[0].Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        if (childControl is TextBox)
                        {
                            if (childControl.Tag?.ToString() == modifierTag)
                            {
                                return (TextBox)childControl;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private TextBox GetSkillResultBox(SkillType skillType)
        {
            foreach (Control c in MainForm.TabPages[0].Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        if (childControl is TextBox)
                        {
                            if (childControl.Tag?.ToString() == $"{skillType.ToString()}ResultBox")
                            {
                                return (TextBox)childControl;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private string GetWeaponName(string weaponTag)
        {
            //Weapon1Name
            foreach (Control c in MainForm.TabPages[0].Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        if (childControl is TextBox)
                        {
                            if (childControl.Tag?.ToString() == $"{weaponTag}Name")
                            {
                                return childControl.Text;
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Used to determine what damage dice the weapon should be rolling
        /// </summary>
        /// <param name="weaponAttackDie"></param> The combo box which has the selected dice
        /// <returns></returns> Returns the dice roll 
        private DiceType GetSelectedDice(ComboBox weaponAttackDie)
        {
            switch (weaponAttackDie.SelectedIndex)
            {
                case 0:
                    return DiceType.D4;
                case 1:
                    return DiceType.D6;
                case 2:
                    return DiceType.D8;
                case 3:
                    return DiceType.D10;
                case 4:
                    return DiceType.D12;
                case 5:
                    return DiceType.D20;
                case -1:
                    // Need to return on these or something so that we aren't sending a janky request to Discord
                    MessageBox.Show("You need to select a dice. Are you a retard or did you just forget?");
                    return DiceType.Unknown;
                default:
                    MessageBox.Show("Something went wrong. No idea what. Sucks to be you.");
                    return DiceType.Unknown;
            }
        }

        private Color ChangeResultColour(int diceRoll)
        {
            switch (diceRoll)
            {
                case 1:
                    return Color.Red;
                case 20:
                    return Color.Green;
                default: return Color.DimGray;
            }
        }

        private void DetermineBecomingStableOrDying(bool rolledNat20 = false)
        {
            var successContainer = MainForm.Controls.Find("DeathSaveSuccessContainer", true).First();
            var failureContainer = MainForm.Controls.Find("DeathSaveFailureContainer", true).First();

            if (rolledNat20)
            {
                successContainer.BackColor = Color.Green;
                successContainer.ForeColor = Color.White;
            }

            switch (CurrentHealthState.State)
            {
                case State.Unconscious:
                    successContainer.BackColor = Color.FromArgb(50, 50, 50);
                    successContainer.ForeColor = Color.White;
                    failureContainer.BackColor = Color.FromArgb(50, 50, 50);
                    failureContainer.ForeColor = Color.White;
                    break;
                case State.Stable:
                    successContainer.BackColor = Color.Green;
                    successContainer.ForeColor = Color.White;
                    failureContainer.BackColor = Color.FromArgb(50, 50, 50);
                    failureContainer.ForeColor = Color.White;
                    break;
                case State.Dead:
                    successContainer.BackColor = Color.FromArgb(50, 50, 50);
                    successContainer.ForeColor = Color.White;
                    failureContainer.BackColor = Color.Red;
                    failureContainer.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }

            if (CurrentHealthState.TransitionState == TransitionState.RemainsUnconscious)
            {
                successContainer.BackColor = Color.FromArgb(50, 50, 50);
                successContainer.ForeColor = Color.White;
                failureContainer.BackColor = Color.FromArgb(50, 50, 50);
                failureContainer.ForeColor = Color.White;
            }
        }

        private void ResetDeathSavingBoxes()
        {
            SuccessBoxes.ForEach(x => x.Checked = false);
            FailureBoxes.ForEach(x => x.Checked = false);
        }

        private Control GetControlWithName(string name)
        {
            return MainForm.Controls.Find(name, true).First();
        }

        private List<CheckBox> GetCheckBoxes(string containerName)
        {
            var successContainer = MainForm.Controls.Find(containerName, true).First();
            var boxList = new List<CheckBox>();

            //DeathSaveSuccessContainer
            //DeathSaveFailureContainer
            foreach (Control c in successContainer.Controls)
            {
                boxList.Add(c as CheckBox);
            };

            return boxList;
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

            // Character information
            Properties.Settings.Default.CharacterName = CharacterNameTextBox.Text;
            Properties.Settings.Default.Class = ClassTextBox.Text;
            Properties.Settings.Default.Background = BackgroundTextBox.Text;
            Properties.Settings.Default.Race = RaceTextBox.Text;
            Properties.Settings.Default.Alignment = AlignmentDropDown.SelectedIndex;
            Properties.Settings.Default.ExperiencePoints = RaceTextBox.Text;
            Properties.Settings.Default.Level = LevelCounterBox.Value;

            // Personality
            Properties.Settings.Default.PersonalityTraits = PersonalityTraitsTextBox.Text;
            Properties.Settings.Default.Ideals = IdealsTextBox.Text;
            Properties.Settings.Default.Bonds = BondsCheckBox.Text;
            Properties.Settings.Default.Flaws = FlawsTextBox.Text;

            // Health state
            Properties.Settings.Default.DeathRollSuccesses = SuccessBoxes.Where(x => x.Checked).Count();
            Properties.Settings.Default.DeathRollFailures = FailureBoxes.Where(x => x.Checked).Count();
            Properties.Settings.Default.HealthState = (int)CurrentHealthState.State;
            Properties.Settings.Default.HealthTransistionState = (int)CurrentHealthState.TransitionState;

            Properties.Settings.Default.HP = HPTextBox.Text;

            Properties.Settings.Default.Save();

            DiscordConnection.LogoutBot();
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

            // Character information
            CharacterNameTextBox.Text = Properties.Settings.Default.CharacterName;
            ClassTextBox.Text = Properties.Settings.Default.Class;
            BackgroundTextBox.Text = Properties.Settings.Default.Background;
            RaceTextBox.Text = Properties.Settings.Default.Race;
            AlignmentDropDown.SelectedIndex = Properties.Settings.Default.Alignment;
            RaceTextBox.Text = Properties.Settings.Default.ExperiencePoints;
            LevelCounterBox.Value = Properties.Settings.Default.Level;

            // Personality
            PersonalityTraitsTextBox.Text = Properties.Settings.Default.PersonalityTraits;
            IdealsTextBox.Text = Properties.Settings.Default.Ideals;
            BondsCheckBox.Text = Properties.Settings.Default.Bonds;
            FlawsTextBox.Text = Properties.Settings.Default.Flaws;

            BotTokenTextBox.Text = Properties.Settings.Default.BotToken;
            ChannelDTextBox.Text = Properties.Settings.Default.ChannelID;
            ServerIDTextBox.Text = Properties.Settings.Default.ServerID;
            DMUserIDTextBox.Text = Properties.Settings.Default.DMUserID;

            var healthState = (State)Properties.Settings.Default.HealthState;
            var transitionState = (TransitionState)Properties.Settings.Default.HealthTransistionState;
            var deathRollSuccesses = Properties.Settings.Default.DeathRollSuccesses;
            var deathRollFailures = Properties.Settings.Default.DeathRollFailures;

            CurrentHealthState = new CurrentHealthState(healthState, transitionState, deathRollSuccesses, deathRollFailures);
            DetermineBecomingStableOrDying();
            CheckDeathSaveBoxesWhereNeeded(deathRollSuccesses, deathRollFailures);
            // Update the check boxes to have the correct amount ticked

            HPTextBox.Text = Properties.Settings.Default.HP;
        }

        private void CheckDeathSaveBoxesWhereNeeded(int deathRollSuccesses, int deathRollFailures)
        {
            for (int i = deathRollSuccesses; i > 0; i--)
            {
                SuccessBoxes[i-1].Checked = true;
            }

            for (int i = deathRollFailures; i > 0; i--)
            {
                FailureBoxes[i-1].Checked = true;
            }
        }

        #endregion

        #endregion
    }
}
