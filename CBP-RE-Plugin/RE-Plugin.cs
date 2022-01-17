using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using CBPSDK;

namespace CBP_RE_Plugin
{
    public class RE_Plugin : IPluginCBP
    {
        public string PluginTitle => "Rules.xml Editor (pop / armageddon limit)";

        public string PluginVersion => "0.3.1";

        public string PluginAuthor => "MHLoppy";

        public bool CBPCompatible => true;

        public bool DefaultMultiplayerCompatible => false;

        public string PluginDescription => "A basic user interface (GUI) to edit rules.xml values, mainly the pop limit and/or armageddon limit."
            + "\n\nSource code: < L I N K   H E R E > ";

        public bool IsSimpleMod => false;

        public string LoadResult { get; set; }

        private string rulesXML;
        private string REFolder;
        private string loadedRE;

        public bool CheckIfLoaded()
        {
            if (File.ReadAllText(loadedRE) != "0")
            {
                if (!LoadResult.Contains("is loaded"))
                {
                    LoadResult += "\n\n" + PluginTitle + " is loaded.";
                }
                return true;
            }
            else
            {
                if (!LoadResult.Contains("is not loaded"))
                {
                    LoadResult += "\n\n" + PluginTitle + " is not loaded.";
                }
                return false;
            }
        }

        public void DoSomething(string workshopModsPath, string localModsPath)
        {
            rulesXML = Path.GetFullPath(Path.Combine(localModsPath, @"..\", "Data", "rules.xml"));
            REFolder = Path.GetFullPath(Path.Combine(localModsPath, @"..\", "CBP", "RE"));
            loadedRE = Path.Combine(REFolder, "ruleseditorplugin.txt");

            //if folder doesn't exist, make it
            if (!Directory.Exists(REFolder))
            {
                try
                {
                    Directory.CreateDirectory(REFolder);
                    LoadResult = (PluginTitle + " detected for first time. Doing first-time setup.");
                }
                catch (Exception ex)
                {
                    LoadResult = (PluginTitle + ": error writing first-time file:\n\n" + ex);
                }
            }
            else
            {
                LoadResult = (REFolder + " already exists; no action taken.");
            }

            //if file doesn't exist, make one
            if (!File.Exists(loadedRE))
            {
                try
                {
                    File.WriteAllText(loadedRE, "0");
                    LoadResult = (PluginTitle + " completed first time setup successfully. Created file:\n" + loadedRE);
                    //MessageBox.Show(PluginTitle + ": Created file:\n" + loadedMTP);//removed to reduce number of popups for first-time CBP users
                }
                catch (Exception ex)
                {
                    LoadResult = (PluginTitle + ": error writing first-time file:\n\n" + ex);
                }
            }
            else
            {
                LoadResult = (loadedRE + " already exists; no action taken.");
            }

            CheckIfLoaded();//this can be important to do here, otherwise the bool might be accessed without a value depending on how other stuff is set up
        }

        public void LoadPlugin(string workshopModsPath, string localModsPath)
        {
            try
            {
                BackupRulesXML();
                new RulesEditorWindow().Show();
                MessageBox.Show("This plugin will modify the CURRENTLY LOADED rules.xml file. Please ensure that the file you want to edit is currently loaded (CBP is loaded / unloaded)."
                    + "\n\nWhen the plugin is unloaded, default values are written onto the currently loaded rules.xml file (CBP values used if CBP file)."
                    + "\n\nCBP updates may reset values to defaults (even while plugin is loaded).", "", MessageBoxButton.OK, MessageBoxImage.Information);

                File.WriteAllText(loadedRE, "1");
                CheckIfLoaded();
                LoadResult = (PluginTitle + " was loaded.");
            }
            catch (Exception ex)
            {
                LoadResult = (PluginTitle + " had an error while loading: " + ex);
                MessageBox.Show("Error while loading:\n\n" + ex);
            }
        }

        public void UnloadPlugin(string workshopModsPath, string localModsPath)
        {
            try
            {
                RestoreDefaultValues();

                File.WriteAllText(loadedRE, "0");
                CheckIfLoaded();
                LoadResult = (PluginTitle + ": Default rules.xml values written.");
                //MessageBox.Show("Previous rules.xml file has been restored.");
            }
            catch (Exception ex)
            {
                LoadResult = (PluginTitle + " had an error while unloading: " + ex);
                MessageBox.Show("Error while unloading:\n\n" + ex);
            }
        }

        public void UpdatePlugin(string workshopModsPath, string localModsPath)
        {
            //potentially could implement it so that it modifies whatever the current rules.xml file is (semi-responsive to CBP load/unload), but it would be a lot more work for imo not much gain
        }

        private void BackupRulesXML()
        {
            File.Copy(rulesXML, Path.Combine(REFolder, "rules.xml"), true);
        }

        private void RestoreDefaultValues()
        {
            try
            {
                //reset pop limits etc - I hate having to duplicate code like this, but it's faster/easier than rewriting the functions to work seamlessly both here and with the window code
                XmlDocument doc = new XmlDocument();
                doc.Load(rulesXML);
                XmlNode popCap = doc.SelectSingleNode(@"ROOT/CONSTANTS/POP_CAP");

                int pop0 = 25;
                int pop1 = 50;
                int pop2 = 75;
                int pop3 = 100;
                int pop4 = 125;
                int pop5 = 150;
                int pop6 = 175;
                int pop7 = 200;

                int nukeBase = 4;
                int nukeNation = 1;
                int nukeTeam = 2;

                int popCol = 50;
                int popBantuBonus = 100;
                int popBantuExceed = 25;
                int popPeacocks = 10;
                int popMax = 300;

                if (CheckIfCBPFile(rulesXML))
                {
                    popCol = 35;
                    //popBantuBonus = 100;
                    //popBantuExceed = 25;
                    //popPeacocks = 10;
                    //popMax = 300;
                    //the non-Col values are currently the same as of Alpha 7/8 so don't need to be re-assigned
                }

                popCap.Attributes["entry0"].Value = pop0.ToString();
                popCap.Attributes["entry1"].Value = pop1.ToString();
                popCap.Attributes["entry2"].Value = pop2.ToString();
                popCap.Attributes["entry3"].Value = pop3.ToString();
                popCap.Attributes["entry4"].Value = pop4.ToString();
                popCap.Attributes["entry5"].Value = pop5.ToString();
                popCap.Attributes["entry6"].Value = pop6.ToString();

                string entry7 = pop7.ToString() + " pop cap";
                popCap.Attributes["entry7"].Value = entry7;

                //we also want to save the pop values to the pop selection options in the game lobby
                XmlNode poplimit1 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[1]/DATA");
                XmlAttribute pop1string = poplimit1.ParentNode.Attributes["name"];
                poplimit1.InnerText = pop1.ToString();
                pop1string.Value = pop1.ToString();

                XmlNode poplimit2 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[2]/DATA");
                XmlAttribute pop2string = poplimit2.ParentNode.Attributes["name"];
                poplimit2.InnerText = pop2.ToString();
                pop2string.Value = pop2.ToString();

                XmlNode poplimit3 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[3]/DATA");
                XmlAttribute pop3string = poplimit3.ParentNode.Attributes["name"];
                poplimit3.InnerText = pop3.ToString();
                pop3string.Value = pop3.ToString();

                XmlNode poplimit4 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[4]/DATA");
                XmlAttribute pop4string = poplimit4.ParentNode.Attributes["name"];
                poplimit4.InnerText = pop4.ToString();
                pop4string.Value = pop4.ToString();

                XmlNode poplimit5 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[5]/DATA");
                XmlAttribute pop5string = poplimit5.ParentNode.Attributes["name"];
                poplimit5.InnerText = pop5.ToString();
                pop5string.Value = pop5.ToString();

                XmlNode poplimit6 = doc.SelectSingleNode(@"ROOT/CATEGORIES[@id='poplimits']/CATEGORY[6]/DATA");
                XmlAttribute pop6string = poplimit6.ParentNode.Attributes["name"];
                poplimit6.InnerText = pop7.ToString();
                pop6string.Value = pop7.ToString();//the file only has 1-5 then 7, it skips pop6 and has no pop0 equivalent

                //save secondary pop cap  (colo is fine, bantu is "X%", peacocks is "X%", max is "X pop cap")
                XmlNode xmlCol = doc.SelectSingleNode(@"ROOT/CONSTANTS/COLOSSUS_POP_CAP");
                xmlCol.Attributes["value"].Value = popCol.ToString();

                XmlNode xmlBantu1 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_POP_CAP");
                string bantu1 = popBantuBonus.ToString() + "%";
                xmlBantu1.Attributes["value"].Value = bantu1;

                XmlNode xmlBantu2 = doc.SelectSingleNode(@"ROOT/CONSTANTS/BANTU_FINAL_POP_CAP");
                string bantu2 = popBantuExceed.ToString() + "%";
                xmlBantu2.Attributes["value"].Value = bantu2;

                XmlNode xmlPeacocks = doc.SelectSingleNode(@"ROOT/CONSTANTS/PEACOCKS_POP");
                string peacocks = popPeacocks.ToString() + "%";
                xmlPeacocks.Attributes["value"].Value = peacocks;

                XmlNode xmlMax = doc.SelectSingleNode(@"ROOT/CONSTANTS/MAX_POP_LIMIT");
                string max = popMax.ToString() + " pop cap";
                xmlMax.Attributes["value"].Value = max;

                //save armageddon values (all are "X nukes")
                XmlNode xmlBase = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON");
                string nBase = nukeBase.ToString() + " nukes";
                xmlBase.Attributes["value"].Value = nBase;

                XmlNode xmlNation = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_NATION");
                string nNation = nukeNation.ToString() + " nukes";
                xmlNation.Attributes["value"].Value = nNation;

                XmlNode xmlTeam = doc.SelectSingleNode(@"ROOT/CONSTANTS/ARMAGEDDON_PER_TEAM");
                string nTeam = nukeTeam.ToString() + " nukes";
                xmlTeam.Attributes["value"].Value = nTeam;

                //save file, then re-add BHG's weird XML formatting, then reload values
                doc.Save(rulesXML);
                FixXML();

                MessageBox.Show("Default values written to rules.xml.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing default values to rules.xml file:\n\n" + ex);
                LoadResult += "Error writing default values to rules.xml file: " + ex;
            }
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

        private void FixXML()
        {
            // gotta fix the wonky default values: TERRA_COTTA_DELAY, ATTRITION, PEACE_ATTRITION, and ASSASSIN_ATTRITION
            string rules = File.ReadAllText(rulesXML);

            rules = rules.Replace("\"7 fifteenths of a second (but 7 == &quot;half a second&quot;)\"", "'7 fifteenths of a second (but 7 == \"half a second\")'");
            rules = rules.Replace("<ATTRITION value=\"", "<ATTRITION value='");//part 1 of first attrition
            rules = rules.Replace("&quot;regular&quot; attrition\"", "\"regular\" attrition'");//part 2 of first attrition (split up from below because combined it didn't work, idk why)
            //rules = rules.Replace("\"48 frames -> this is the baseline level for &quot;regular&quot; attrition\"", "'48 frames -> this is the baseline level for \"regular\" attrition'");
            rules = rules.Replace("-&gt;", "->");//fixes both of the last two attritions

            // and just to make file compares easier, we can do this one too
            rules = rules.Replace("/ >", "/>");
            rules = rules.Replace(" />", "/>");
            File.WriteAllText(rulesXML, rules);

            // SHOULD MAYBE ALSO REMOVE (or re-align) THE SALT COMMENT IN CBP FILES?
        }
    }
}
