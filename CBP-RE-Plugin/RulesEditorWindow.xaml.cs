/* 
 * This file is part of CBP Rules Editor Plugin (CBP-RE-Plugin).
 *
 * CBP Rules Editor Plugin (CBP-RE-Plugin) is free software: you can
 * redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either
 * version 3 of the License, or (at your option) any later version.
 *
 * CBP Rules Editor Plugin (CBP-RE-Plugin) is distributed in the hope
 * that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
 * PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CBP Rules Editor Plugin (CBP-RE-Plugin). If not, see
 * <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CBP_RE_Plugin
{
    public partial class RulesEditorWindow : INotifyPropertyChanged
    {
        private readonly string RulesXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "rules.xml");
        private XmlDocument doc = new XmlDocument();

        private bool adjustPop = false;
        public bool AdjustPop
        {
            get => adjustPop;
            set
            {
                adjustPop = value;
                OnPropertyChanged();
            }
        }

        private string stringCBP;
        public string StringCBP
        {
            get => stringCBP;
            set
            {
                stringCBP = value;
                OnPropertyChanged();
            }
        }

        private int currentPop0;
        public int CurrentPop0
        {
            get => currentPop0;
            set
            {
                if (currentPop0 != value)
                {
                    currentPop0 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop1;
        public int CurrentPop1
        {
            get => currentPop1;
            set
            {
                if (currentPop1 != value)
                {
                    currentPop1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop2;
        public int CurrentPop2
        {
            get => currentPop2;
            set
            {
                if (currentPop2 != value)
                {
                    currentPop2 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop3;
        public int CurrentPop3
        {
            get => currentPop3;
            set
            {
                if (currentPop3 != value)
                {
                    currentPop3 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop4;
        public int CurrentPop4
        {
            get => currentPop4;
            set
            {
                if (currentPop4 != value)
                {
                    currentPop4 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop5;
        public int CurrentPop5
        {
            get => currentPop5;
            set
            {
                if (currentPop5 != value)
                {
                    currentPop5 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop6;
        public int CurrentPop6
        {
            get => currentPop6;
            set
            {
                if (currentPop6 != value)
                {
                    currentPop6 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPop7;
        public int CurrentPop7
        {
            get => currentPop7;
            set
            {
                if (currentPop7 != value)
                {
                    currentPop7 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentCol;
        public int CurrentCol
        {
            get => currentCol;
            set
            {
                if (currentCol != value)
                {
                    currentCol = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentBantuBonus;
        public int CurrentBantuBonus
        {
            get => currentBantuBonus;
            set
            {
                if (currentBantuBonus != value)
                {
                    currentBantuBonus = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentBantuExceed;
        public int CurrentBantuExceed
        {
            get => currentBantuExceed;
            set
            {
                if (currentBantuExceed != value)
                {
                    currentBantuExceed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentPeacocks;
        public int CurrentPeacocks
        {
            get => currentPeacocks;
            set
            {
                if (currentPeacocks != value)
                {
                    currentPeacocks = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentMax;
        public int CurrentMax
        {
            get => currentMax;
            set
            {
                if (currentMax != value)
                {
                    currentMax = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentNukeBase;
        public int CurrentNukeBase
        {
            get => currentNukeBase;
            set
            {
                if (currentNukeBase != value)
                {
                    currentNukeBase = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentNukeNation;
        public int CurrentNukeNation
        {
            get => currentNukeNation;
            set
            {
                if (currentNukeNation != value)
                {
                    currentNukeNation = value;
                    OnPropertyChanged();
                }
            }
        }

        private int currentNukeTeam;
        public int CurrentNukeTeam
        {
            get => currentNukeTeam;
            set
            {
                if (currentNukeTeam != value)
                {
                    currentNukeTeam = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop0;
        public int NewPop0
        {
            get => newPop0;
            set
            {
                if (newPop0 != value)
                {
                    newPop0 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop1;
        public int NewPop1
        {
            get => newPop1;
            set
            {
                if (newPop1 != value)
                {
                    newPop1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop2;
        public int NewPop2
        {
            get => newPop2;
            set
            {
                if (newPop2 != value)
                {
                    newPop2 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop3;
        public int NewPop3
        {
            get => newPop3;
            set
            {
                if (newPop3 != value)
                {
                    newPop3 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop4;
        public int NewPop4
        {
            get => newPop4;
            set
            {
                if (newPop4 != value)
                {
                    newPop4 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop5;
        public int NewPop5
        {
            get => newPop5;
            set
            {
                if (newPop5 != value)
                {
                    newPop5 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop6;
        public int NewPop6
        {
            get => newPop6;
            set
            {
                if (newPop6 != value)
                {
                    newPop6 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPop7;
        public int NewPop7
        {
            get => newPop7;
            set
            {
                if (newPop7 != value)
                {
                    newPop7 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newCol;
        public int NewCol
        {
            get => newCol;
            set
            {
                if (newCol != value)
                {
                    newCol = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newBantuBonus;
        public int NewBantuBonus
        {
            get => newBantuBonus;
            set
            {
                if (newBantuBonus != value)
                {
                    newBantuBonus = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newBantuExceed;
        public int NewBantuExceed
        {
            get => newBantuExceed;
            set
            {
                if (newBantuExceed != value)
                {
                    newBantuExceed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newPeacocks;
        public int NewPeacocks
        {
            get => newPeacocks;
            set
            {
                if (newPeacocks != value)
                {
                    newPeacocks = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newMax;
        public int NewMax
        {
            get => newMax;
            set
            {
                if (newMax != value)
                {
                    newMax = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newNukeBase;
        public int NewNukeBase
        {
            get => newNukeBase;
            set
            {
                if (newNukeBase != value)
                {
                    newNukeBase = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newNukeNation;
        public int NewNukeNation
        {
            get => newNukeNation;
            set
            {
                if (newNukeNation != value)
                {
                    newNukeNation = value;
                    OnPropertyChanged();
                }
            }
        }

        private int newNukeTeam;
        public int NewNukeTeam
        {
            get => newNukeTeam;
            set
            {
                if (newNukeTeam != value)
                {
                    newNukeTeam = value;
                    OnPropertyChanged();
                }
            }
        }

        public RulesEditorWindow()
        {
            DataContext = this;
            InitializeComponent();

            GetCurrentValues();
            PrefillNewValues();
            CheckCBP();
        }

        private void GetCurrentValues()
        {
            try
            {
                doc.Load(RulesXML);

                // each of the mil tech pop values
                XmlNode popCap = doc.SelectSingleNode(@"ROOT/CONSTANTS/POP_CAP");
                CurrentPop0 = int.Parse(popCap.Attributes["entry0"].Value);
                CurrentPop1 = int.Parse(popCap.Attributes["entry1"].Value);
                CurrentPop2 = int.Parse(popCap.Attributes["entry2"].Value);
                CurrentPop3 = int.Parse(popCap.Attributes["entry3"].Value);
                CurrentPop4 = int.Parse(popCap.Attributes["entry4"].Value);
                CurrentPop5 = int.Parse(popCap.Attributes["entry5"].Value);
                CurrentPop6 = int.Parse(popCap.Attributes["entry6"].Value);

                // have to trim off the extra text first
                string pop7 = CleanXML(popCap.Attributes["entry7"].Value);
                CurrentPop7 = int.Parse(pop7);

                // col
                XmlNode popCol = doc.SelectSingleNode(@"ROOT/CONSTANTS/COLOSSUS_POP_CAP");
                CurrentCol = int.Parse(popCol.Attributes["value"].Value);

                // bantu
                XmlNode popBantu1 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_POP_CAP");
                string bantu1 = CleanXML(popBantu1.Attributes["value"].Value);
                CurrentBantuBonus = int.Parse(bantu1);

                XmlNode popBantu2 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_FINAL_POP_CAP");
                string bantu2 = CleanXML(popBantu2.Attributes["value"].Value);
                CurrentBantuExceed = int.Parse(bantu2);

                // peacocks
                XmlNode popPeacocks = doc.SelectSingleNode(@"ROOT/CONSTANTS/PEACOCKS_POP");
                string peacocks = CleanXML(popPeacocks.Attributes["value"].Value);
                CurrentPeacocks = int.Parse(peacocks);

                // max (not 100% sure if it actually gets used though)
                XmlNode popMax = doc.SelectSingleNode(@"ROOT/CONSTANTS/MAX_POP_LIMIT");
                string max = CleanXML(popMax.Attributes["value"].Value);
                CurrentMax = int.Parse(max);

                // armageddon
                XmlNode nukeBase = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON");
                string nBase = CleanXML(nukeBase.Attributes["value"].Value);
                CurrentNukeBase = int.Parse(nBase);

                XmlNode nukeNation = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_NATION");
                string nNation = CleanXML(nukeNation.Attributes["value"].Value);
                CurrentNukeNation = int.Parse(nNation);

                XmlNode nukeTeam = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_TEAM");
                string nTeam = CleanXML(nukeTeam.Attributes["value"].Value);
                CurrentNukeTeam = int.Parse(nTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading current rules.xml values:\n\n" + ex);
            }
        }

        private void PrefillNewValues()
        {
            try
            {
                // mil tech pop
                NewPop0 = CurrentPop0;
                NewPop1 = CurrentPop1;
                NewPop2 = CurrentPop2;
                NewPop3 = CurrentPop3;
                NewPop4 = CurrentPop4;
                NewPop5 = CurrentPop5;
                NewPop6 = CurrentPop6;
                NewPop7 = CurrentPop7;

                // other pop
                NewCol = CurrentCol;
                NewBantuBonus = CurrentBantuBonus;
                NewBantuExceed = CurrentBantuExceed;
                NewPeacocks = CurrentPeacocks;
                NewMax = CurrentMax;

                // armageddon
                NewNukeBase = CurrentNukeBase;
                NewNukeNation = CurrentNukeNation;
                NewNukeTeam = CurrentNukeTeam;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error prefilling new values:\n\n" + ex);
            }
        }

        private void CheckCBP()
        {
            if (CheckIfCBPFile(RulesXML))
            {
                stringCBP = "The loaded rules.xml file is from CBP.";
            }
            else
            {
                stringCBP = "The loaded rules.xml file is not from CBP.";
            }
        }

        private void SetPopPrimary(int zero, int one, int two, int three, int four, int five, int six, int seven)
        {
            NewPop0 = zero;
            NewPop1 = one;
            NewPop2 = two;
            NewPop3 = three;
            NewPop4 = four;
            NewPop5 = five;
            NewPop6 = six;
            NewPop7 = seven;
        }

        private void SetPopSecondary(int col, int bantuBonus, int bantuExceed, int peacocks, int max)
        {
            NewCol = col;
            NewBantuBonus = bantuBonus;
            NewBantuExceed = bantuExceed;
            NewPeacocks = peacocks;
            NewMax = max;
        }

        private void SetArmageddon(int nukeBase, int nukeNation, int NukeTeam)
        {
            NewNukeBase = nukeBase;
            NewNukeNation = nukeNation;
            NewNukeTeam = NukeTeam;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string CleanXML(string text) //https://stackoverflow.com/questions/3977497/stripping-out-non-numeric-characters-in-string
        {
            var numericChars = "0123456789".ToCharArray();
            return new String(text.Where(c => numericChars.Any(n => n == c)).ToArray());
        }

        private bool CheckIfCBPFile(string filename) // code adapted from CBP Launcher
        {
            // go to line 3, read 1 line, from start, then skip the (potentially) "<!-- " XML comment part and read what's there
            string text = File.ReadLines(filename).Skip(2).Take(1).First();
            if (text.Substring(5).StartsWith("CBP"))
                return true;
            else
                return false;
        }

        private void ResetToDefaults()
        {
            SetPopPrimary(25, 50, 75, 100, 125, 150, 175, 200);
            SetArmageddon(4, 1, 2);

            if (CheckIfCBPFile(RulesXML))
            {
                SetPopSecondary(35, 100, 25, 10, 300);
            }
            else //not CBP
            {
                SetPopSecondary(50, 100, 25, 10, 300);
            }
        }

        private void DiscardValues()
        {
            // mil tech pop
            NewPop0 = CurrentPop0;
            NewPop1 = CurrentPop1;
            NewPop2 = CurrentPop2;
            NewPop3 = CurrentPop3;
            NewPop4 = CurrentPop4;
            NewPop5 = CurrentPop5;
            NewPop6 = CurrentPop6;
            NewPop7 = CurrentPop7;

            // other pop
            NewCol = CurrentCol;
            NewBantuBonus = CurrentBantuBonus;
            NewBantuExceed = CurrentBantuExceed;
            NewPeacocks = CurrentPeacocks;
            NewMax = CurrentMax;

            // armageddon
            NewNukeBase = CurrentNukeBase;
            NewNukeNation = CurrentNukeNation;
            NewNukeTeam = CurrentNukeTeam;
        }

        private void SaveValues()
        {
            //remember that saving the values will be different!!!! because of the text portions at the end of the numeric values

            try
            {
                //save primary pop cap values (0-6 are fine, entry7 is "X pop cap")
                doc.Load(RulesXML);
                XmlNode popCap = doc.SelectSingleNode(@"ROOT/CONSTANTS/POP_CAP");

                popCap.Attributes["entry0"].Value = NewPop0.ToString();
                popCap.Attributes["entry1"].Value = NewPop1.ToString();
                popCap.Attributes["entry2"].Value = NewPop2.ToString();
                popCap.Attributes["entry3"].Value = NewPop3.ToString();
                popCap.Attributes["entry4"].Value = NewPop4.ToString();
                popCap.Attributes["entry5"].Value = NewPop5.ToString();
                popCap.Attributes["entry6"].Value = NewPop6.ToString();

                string entry7 = NewPop7.ToString() + " pop cap";
                popCap.Attributes["entry7"].Value = entry7;

                //we also want to save the pop values to the pop selection options in the game lobby
                XmlNode poplimit1 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[1]/DATA");
                XmlAttribute pop1string = poplimit1.ParentNode.Attributes["name"];
                poplimit1.InnerText = NewPop1.ToString();
                pop1string.Value = NewPop1.ToString();

                XmlNode poplimit2 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[2]/DATA");
                XmlAttribute pop2string = poplimit2.ParentNode.Attributes["name"];
                poplimit2.InnerText = NewPop2.ToString();
                pop2string.Value = NewPop2.ToString();

                XmlNode poplimit3 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[3]/DATA");
                XmlAttribute pop3string = poplimit3.ParentNode.Attributes["name"];
                poplimit3.InnerText = NewPop3.ToString();
                pop3string.Value = NewPop3.ToString();

                XmlNode poplimit4 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[4]/DATA");
                XmlAttribute pop4string = poplimit4.ParentNode.Attributes["name"];
                poplimit4.InnerText = NewPop4.ToString();
                pop4string.Value = NewPop4.ToString();

                XmlNode poplimit5 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[5]/DATA");
                XmlAttribute pop5string = poplimit5.ParentNode.Attributes["name"];
                poplimit5.InnerText = NewPop5.ToString();
                pop5string.Value = NewPop5.ToString();

                XmlNode poplimit6 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[6]/DATA");
                XmlAttribute pop6string = poplimit6.ParentNode.Attributes["name"];
                poplimit6.InnerText = NewPop7.ToString();
                pop6string.Value = NewPop7.ToString();//the file only has 1-5 then 7, it skips pop6 and has no pop0 equivalent

                //save secondary pop cap  (colo is fine, bantu is "X%", peacocks is "X%", max is "X pop cap")
                XmlNode popCol = doc.SelectSingleNode(@"ROOT/CONSTANTS/COLOSSUS_POP_CAP");
                popCol.Attributes["value"].Value = NewCol.ToString();

                XmlNode popBantu1 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_POP_CAP");
                string bantu1 = NewBantuBonus.ToString() + "%";
                popBantu1.Attributes["value"].Value = bantu1;

                XmlNode popBantu2 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_FINAL_POP_CAP");
                string bantu2 = NewBantuExceed.ToString() + "%";
                popBantu2.Attributes["value"].Value = bantu2;

                XmlNode popPeacocks = doc.SelectSingleNode(@"ROOT/CONSTANTS/PEACOCKS_POP");
                string peacocks = NewPeacocks.ToString() + "%";
                popPeacocks.Attributes["value"].Value = peacocks;

                XmlNode popMax = doc.SelectSingleNode(@"ROOT/CONSTANTS/MAX_POP_LIMIT");
                string max = NewMax.ToString() + " pop cap";
                popMax.Attributes["value"].Value = max;

                //save armageddon values (all are "X nukes")
                XmlNode nukeBase = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON");
                string nBase = NewNukeBase.ToString() + " nukes";
                nukeBase.Attributes["value"].Value = nBase;

                XmlNode nukeNation = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_NATION");
                string nNation = NewNukeNation.ToString() + " nukes";
                nukeNation.Attributes["value"].Value = nNation;

                XmlNode nukeTeam = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_TEAM");
                string nTeam = NewNukeTeam.ToString() + " nukes";
                nukeTeam.Attributes["value"].Value = nTeam;

                //save file, re-add BHG's weird XML formatting, then reload values
                doc.Save(RulesXML);
                FixXML();
                GetCurrentValues();

                MessageBox.Show("New values written to rules.xml.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving rules.xml:\n\n" + ex);
            }
        }

        private void FixXML()
        {
            // gotta fix the wonky default values: TERRA_COTTA_DELAY, ATTRITION, PEACE_ATTRITION, and ASSASSIN_ATTRITION
            string rules = File.ReadAllText(RulesXML);

            rules = rules.Replace("\"7 fifteenths of a second (but 7 == &quot;half a second&quot;)\"", "'7 fifteenths of a second (but 7 == \"half a second\")'");
            rules = rules.Replace("<ATTRITION value=\"", "<ATTRITION value='");//part 1 of first attrition
            rules = rules.Replace("&quot;regular&quot; attrition\"", "\"regular\" attrition'");//part 2 of first attrition (split up from below because combined it didn't work, idk why)
            //rules = rules.Replace("\"48 frames -> this is the baseline level for &quot;regular&quot; attrition\"", "'48 frames -> this is the baseline level for \"regular\" attrition'");
            rules = rules.Replace("-&gt;", "->");//fixes both of the last two attritions

            // and just to make file compares easier, we can do this one too
            rules = rules.Replace("/ >", "/>");
            rules = rules.Replace(" />", "/>");
            File.WriteAllText(RulesXML, rules);

            // SHOULD MAYBE ALSO REMOVE (or re-align) THE SALT COMMENT IN CBP FILES?
        }

        private void Pop2Button_Click(object sender, RoutedEventArgs e)
        {
            SetPopPrimary(50, 100, 150, 200, 250, 300, 350, 400);

            if (CheckIfCBPFile(RulesXML))
            {
                if (AdjustPop)//no difference right now at 2x with CBP on
                {
                    SetPopSecondary(70, 100, 25, 10, 600);
                }
                else
                {
                    SetPopSecondary(70, 100, 25, 10, 600);
                }
            }
            else //not CBP
            {
                if (AdjustPop)
                {
                    SetPopSecondary(80, 100, 25, 10, 600);
                }
                else
                {
                    SetPopSecondary(100, 100, 25, 10, 600);
                }
            }
        }

        private void Pop5Button_Click(object sender, RoutedEventArgs e)
        {
            SetPopPrimary(125, 250, 375, 500, 625, 750, 875, 1000);

            if (CheckIfCBPFile(RulesXML))
            {
                if (AdjustPop)
                {
                    SetPopSecondary(150, 50, 20, 10, 1500);
                }
                else
                {
                    SetPopSecondary(175, 100, 25, 10, 1500);
                }
            }
            else //not CBP
            {
                if (AdjustPop)
                {
                    SetPopSecondary(200, 50, 20, 10, 1500);
                }
                else
                {
                    SetPopSecondary(250, 100, 25, 10, 1500);
                }
            }
        }

        private void Pop10Button_Click(object sender, RoutedEventArgs e)
        {
            SetPopPrimary(250, 500, 750, 1000, 1250, 1500, 1750, 2000);

            if (CheckIfCBPFile(RulesXML))
            {
                if (AdjustPop)
                {
                    SetPopSecondary(250, 20, 10, 10, 3000);
                }
                else
                {
                    SetPopSecondary(350, 100, 25, 10, 3000);
                }
            }
            else //not CBP
            {
                if (AdjustPop)
                {
                    SetPopSecondary(300, 20, 10, 10, 3000);
                }
                else
                {
                    SetPopSecondary(500, 100, 25, 10, 3000);
                }
            }
        }

        private void Nuke2Button_Click(object sender, RoutedEventArgs e)
        {
            SetArmageddon(8, 2, 4);
        }

        private void Nuke10Button_Click(object sender, RoutedEventArgs e)
        {
            SetArmageddon(40, 10, 20);
        }

        private void Nuke1000Button_Click(object sender, RoutedEventArgs e)
        {
            SetArmageddon(400, 100, 200);
        }

        private void DefaultsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetToDefaults();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveValues();
        }

        private void DiscardButton_Click(object sender, RoutedEventArgs e)
        {
            DiscardValues();
        }
    }
}
