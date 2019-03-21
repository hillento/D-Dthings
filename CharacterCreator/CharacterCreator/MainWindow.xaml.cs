using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;

namespace CharacterCreator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Dictionary<String, Background> BackgroundDict = new Dictionary<string, Background>();
    Dictionary<String, CharacterClassOption> CharacterClassDict = new Dictionary<string, CharacterClassOption>();
    Dictionary<String, Race> RaceDict = new Dictionary<string, Race>();
    Rollers uRollType = new Rollers();
    Character myCharacter;
    CharacterSheet sheetform;
    bool SuicideRoll = false;
    bool ComputerRoll = false;
    bool SelfRoll = false;
    int[] uStatBlock= { 0, 0, 0, 0, 0, 0 };
    public MainWindow()
    {
      InitializeComponent();

      LoadBackground();
      LoadClasses();
      LoadRaces();

      LoadRollAssignment();

    }

    private void LoadRollAssignment()
    {
      string[] StatNames = { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma", "Select... " };

      for (int i = 0; i < StatNames.Length; i++)
      {
        cbStat1.Items.Add(StatNames[i]);
        cbStat2.Items.Add(StatNames[i]);
        cbStat3.Items.Add(StatNames[i]);
        cbStat4.Items.Add(StatNames[i]);
        cbStat5.Items.Add(StatNames[i]);
        cbStat6.Items.Add(StatNames[i]);
      }
      cbStat1.SelectedIndex = 6;
      cbStat2.SelectedIndex = 6;
      cbStat3.SelectedIndex = 6;
      cbStat4.SelectedIndex = 6;
      cbStat5.SelectedIndex = 6;
      cbStat6.SelectedIndex = 6;

    }

    private void LoadBackground()
    {
      StreamReader backgroundsfile;
      string[] tempBackground;
      try
      {
        backgroundsfile = File.OpenText("Backgrounds.txt");
        backgroundsfile.ReadLine();
        while (!backgroundsfile.EndOfStream)
        {
          tempBackground = backgroundsfile.ReadLine().Split('\t');
          cbBackgrounds.Items.Add(tempBackground[0]);
          BackgroundDict.Add(tempBackground[0], new Background(tempBackground));
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    private void LoadClasses()
    {
      StreamReader CharacterClassFile;
      string[] tempClasse;
      try
      {
        CharacterClassFile = File.OpenText("CharacterClasses.txt");
        CharacterClassFile.ReadLine();
        while (!CharacterClassFile.EndOfStream)
        {
          tempClasse = CharacterClassFile.ReadLine().Split('\t');
          cbCharacterClasses.Items.Add(tempClasse[0]);
          CharacterClassDict.Add(tempClasse[0], new CharacterClassOption(tempClasse));
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    private void LoadRaces()
    {
      StreamReader RaceFile;
      string[] tempRace;
      try
      {
        RaceFile = File.OpenText("Races.txt");
        RaceFile.ReadLine();
        while (!RaceFile.EndOfStream)
        {
          tempRace = RaceFile.ReadLine().Split('\t');
          cbRaces.Items.Add(tempRace[0]);
          RaceDict.Add(tempRace[0], new Race(tempRace));
        }
      }
      catch (Exception)
      {

        throw;
      }

    }


    private void CbBackgrounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (BackgroundDict.TryGetValue(cbBackgrounds.SelectedItem.ToString(), out Background background))
      {
        UpdateBackgroundInfo(background); 
      }
    }

    private void UpdateBackgroundInfo(Background background)
    {
      txtblkBackgroundSkills.Text = background.Skills;
      txtblkBackgroundLangs.Text = background.Languages;
      txtblkBackgroundTools.Text = background.Tools;
    }

    private void CbCharacterClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (CharacterClassDict.TryGetValue(cbCharacterClasses.SelectedItem.ToString(), out CharacterClassOption characterClass))
      {
        UpdateClassInfo(characterClass);
      }
    }

    private void UpdateClassInfo(CharacterClassOption characterClass)
    {
      cbSkill1.Items.Clear();
      cbSkill2.Items.Clear();
      cbSkill3.Items.Clear();
      cbSkill4.Items.Clear();

      txtblkClassDesc.Text = characterClass.Description;
      txtblkHitDice.Text = "d" + characterClass.HitDiceName;
      txtblkFavoredStats.Text = characterClass.FavoredStats;
      txtblkClassProficiencies.Text = characterClass.ClassProficiencies;
      txtblkClassSavingThrows.Text = characterClass.SavingThrows;
      txtblkClassSkillProfs.Text = "Choose " + characterClass.NumberOfSkills + " from: " + characterClass.ClassSkillOptions;

      
      cbSkill1.Items.Add(characterClass.ClassSkillOptions.Split(','));
      cbSkill2.Items.Add(characterClass.ClassSkillOptions.Split(','));
      cbSkill3.Items.Add(characterClass.ClassSkillOptions.Split(','));
      cbSkill4 .Items.Add(characterClass.ClassSkillOptions.Split(','));

      string skills = characterClass.ClassSkillOptions;
      string[] skillarray = skills.Split(',');

      /*cbSkill1.ItemsSource = skillarray;
      cbSkill1.SelectedIndex = 0;
      cbSkill2.ItemsSource = skillarray;
      cbSkill2.SelectedIndex = 0;
      cbSkill3.ItemsSource = skillarray;
      cbSkill3.SelectedIndex = 0;
      cbSkill4.ItemsSource = skillarray;
      cbSkill4.SelectedIndex = 0;*/


      for (int i = 0; i < skillarray.Length; i++)
      {
        if(skillarray[i].Trim() != "")
        {
          cbSkill1.Items.Add(skillarray[i].Trim());
          cbSkill2.Items.Add(skillarray[i].Trim());
          cbSkill3.Items.Add(skillarray[i].Trim());
          cbSkill4.Items.Add(skillarray[i].Trim());
        }
        
      }

      if (characterClass.NumberOfSkills == 2)
      {
        cbSkill1.Visibility = Visibility.Visible;
        cbSkill2.Visibility = Visibility.Visible;
        cbSkill3.Visibility = Visibility.Hidden;
        cbSkill4.Visibility = Visibility.Hidden;
      }
      if (characterClass.NumberOfSkills == 3)
      {
        cbSkill1.Visibility = Visibility.Visible;
        cbSkill2.Visibility = Visibility.Visible;
        cbSkill3.Visibility = Visibility.Visible;
        cbSkill4.Visibility = Visibility.Hidden;
      }
      if (characterClass.NumberOfSkills == 4)
      {
        cbSkill1.Visibility = Visibility.Visible;
        cbSkill2.Visibility = Visibility.Visible;
        cbSkill3.Visibility = Visibility.Visible;
        cbSkill4.Visibility = Visibility.Visible;
      }

    }

    private void CbRaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (RaceDict.TryGetValue(cbRaces.SelectedItem.ToString(), out Race race))
      {
        UpdateRaceInfo(race);
      }

    }

    private void UpdateRaceInfo(Race race)
    {
      txtblkSize.Text = race.Size;
      txtblkSpeed.Text = race.Speed.ToString() + "ft";
      txtblkLanguage.Text = race.Language;
      txtblkDarkVision.Text = race.DarkVision.ToString() + "ft";
      txtblkAssignable.Text = race.AssignableBonus.ToString();
      txtblkStrBonus.Text = race.StrengthBonus.ToString();
      txtblkDexBonus.Text = race.DexterityBonus.ToString();
      txtblkConBonus.Text = race.ConstitutionBonus.ToString();
      txtblkIntBonus.Text = race.InteligenceBonus.ToString();
      txtblkDarkWisBonus.Text = race.WisdomBonus.ToString();
      txtblkChaBonus.Text = race.CharismaBonus.ToString();

    }

    private void BtnSuicideRoll_Click(object sender, RoutedEventArgs e)
    {
      SuicideRoll = true;
      ComputerRoll = false;
      SelfRoll = false;

      

      uStatBlock = uRollType.SuicideRoller();
      lblStat1.Content = uStatBlock[0];
      lblStat2.Content = uStatBlock[1];
      lblStat3.Content = uStatBlock[2];
      lblStat4.Content = uStatBlock[3];
      lblStat5.Content = uStatBlock[4];
      lblStat6.Content = uStatBlock[5];

      lblStat1.Visibility = Visibility.Visible;
      lblStat2.Visibility = Visibility.Visible;
      lblStat3.Visibility = Visibility.Visible;
      lblStat4.Visibility = Visibility.Visible;
      lblStat5.Visibility = Visibility.Visible;
      lblStat6.Visibility = Visibility.Visible;

      btnSuicideRoll.Visibility = Visibility.Hidden;
      btnComputerRoll.Visibility = Visibility.Hidden;

      cbStat1.Visibility = Visibility.Hidden;
      cbStat2.Visibility = Visibility.Hidden;
      cbStat3.Visibility = Visibility.Hidden;
      cbStat4.Visibility = Visibility.Hidden;
      cbStat5.Visibility = Visibility.Hidden;
      cbStat6.Visibility = Visibility.Hidden;

      lblStatName1.Visibility = Visibility.Visible;
      lblStatName2.Visibility = Visibility.Visible;
      lblStatName3.Visibility = Visibility.Visible;
      lblStatName4.Visibility = Visibility.Visible;
      lblStatName5.Visibility = Visibility.Visible;
      lblStatName6.Visibility = Visibility.Visible;

      txtbxSelfRolledStr.Visibility = Visibility.Hidden;
      txtbxSelfRolledDex.Visibility = Visibility.Hidden;
      txtbxSelfRolledCon.Visibility = Visibility.Hidden;
      txtbxSelfRolledInt.Visibility = Visibility.Hidden;
      txtbxSelfRolledWis.Visibility = Visibility.Hidden;
      txtbxSelfRolledCha.Visibility = Visibility.Hidden;

      cbStat1.SelectedIndex = 0;
      cbStat2.SelectedIndex = 1;
      cbStat3.SelectedIndex = 2;
      cbStat4.SelectedIndex = 3;
      cbStat5.SelectedIndex = 4;
      cbStat6.SelectedIndex = 5;



    }

    private void BtnComputerRoll_Click(object sender, RoutedEventArgs e)
    {

      ComputerRoll = true;
      SuicideRoll = false;
      SelfRoll = false;

      cbStat1.SelectedIndex = 6;
      cbStat2.SelectedIndex = 6;
      cbStat3.SelectedIndex = 6;
      cbStat4.SelectedIndex = 6;
      cbStat5.SelectedIndex = 6;
      cbStat6.SelectedIndex = 6;

      cbStat1.Visibility = Visibility.Visible;
      cbStat2.Visibility = Visibility.Visible;
      cbStat3.Visibility = Visibility.Visible;
      cbStat4.Visibility = Visibility.Visible;
      cbStat5.Visibility = Visibility.Visible;
      cbStat6.Visibility = Visibility.Visible;

      uStatBlock = uRollType.ComputerRoller();
      lblStat1.Content = uStatBlock[0];
      lblStat2.Content = uStatBlock[1];
      lblStat3.Content = uStatBlock[2];
      lblStat4.Content = uStatBlock[3];
      lblStat5.Content = uStatBlock[4];
      lblStat6.Content = uStatBlock[5];


      txtbxSelfRolledStr.Visibility = Visibility.Hidden;
      txtbxSelfRolledDex.Visibility = Visibility.Hidden;
      txtbxSelfRolledCon.Visibility = Visibility.Hidden;
      txtbxSelfRolledInt.Visibility = Visibility.Hidden;
      txtbxSelfRolledWis.Visibility = Visibility.Hidden;
      txtbxSelfRolledCha.Visibility = Visibility.Hidden;

      lblStatName1.Visibility = Visibility.Hidden;
      lblStatName2.Visibility = Visibility.Hidden;
      lblStatName3.Visibility = Visibility.Hidden;
      lblStatName4.Visibility = Visibility.Hidden;
      lblStatName5.Visibility = Visibility.Hidden;
      lblStatName6.Visibility = Visibility.Hidden;


      btnComputerRoll.Visibility = Visibility.Hidden;
    }

    private void BtnSelfRolled_Click(object sender, RoutedEventArgs e)
    {
      SelfRoll = true;
      ComputerRoll = false;
      SuicideRoll = false;

      cbStat1.SelectedIndex = 0;
      cbStat2.SelectedIndex = 1;
      cbStat3.SelectedIndex = 2;
      cbStat4.SelectedIndex = 3;
      cbStat5.SelectedIndex = 4;
      cbStat6.SelectedIndex = 5;

      cbStat1.Visibility = Visibility.Hidden;
      cbStat2.Visibility = Visibility.Hidden;
      cbStat3.Visibility = Visibility.Hidden;
      cbStat4.Visibility = Visibility.Hidden;
      cbStat5.Visibility = Visibility.Hidden;
      cbStat6.Visibility = Visibility.Hidden;

      lblStatName1.Visibility = Visibility.Visible;
      lblStatName2.Visibility = Visibility.Visible;
      lblStatName3.Visibility = Visibility.Visible;
      lblStatName4.Visibility = Visibility.Visible;
      lblStatName5.Visibility = Visibility.Visible;
      lblStatName6.Visibility = Visibility.Visible;

      txtbxSelfRolledStr.Visibility = Visibility.Visible;
      txtbxSelfRolledDex.Visibility = Visibility.Visible;
      txtbxSelfRolledCon.Visibility = Visibility.Visible;
      txtbxSelfRolledInt.Visibility = Visibility.Visible;
      txtbxSelfRolledWis.Visibility = Visibility.Visible;
      txtbxSelfRolledCha.Visibility = Visibility.Visible;


    }

    private void BtnGenerateCharacter_Click(object sender, RoutedEventArgs e)
    {
      if (cbBackgrounds.SelectedIndex != -1)
      {
        if (cbCharacterClasses.SelectedIndex != -1)
        {
          if (cbRaces.SelectedIndex != -1)
          {
            if (cbStat1.SelectedIndex != 6 && cbStat2.SelectedIndex != 6 && cbStat3.SelectedIndex != 6 && cbStat4.SelectedIndex != 6 && cbStat5.SelectedIndex != 6 && cbStat6.SelectedIndex != 6)
            {
                CreateMyCharacter();
                
            }
            else
            {
              MessageBox.Show("Please assign stats");
            }
          }
          else
          {
            MessageBox.Show("Please select a Race");
          }
        }
        else
        {
          MessageBox.Show("Please select a Class");
        }
      }
      else
      {
        MessageBox.Show("Please select a Background");
      }
    }

    private void CreateMyCharacter()
    {
      BackgroundDict.TryGetValue(cbBackgrounds.SelectedItem.ToString(), out Background background);
      CharacterClassDict.TryGetValue(cbCharacterClasses.SelectedItem.ToString(), out CharacterClassOption characterClass);
      RaceDict.TryGetValue(cbRaces.SelectedItem.ToString(), out Race race);

      myCharacter = new Character(background, characterClass, race);

      if (ComputerRoll)
      {

        if (cbStat1.SelectedIndex != cbStat2.SelectedIndex && cbStat1.SelectedIndex != cbStat3.SelectedIndex && cbStat1.SelectedIndex != cbStat4.SelectedIndex
                 && cbStat1.SelectedIndex != cbStat5.SelectedIndex && cbStat1.SelectedIndex != cbStat6.SelectedIndex && cbStat2.SelectedIndex != cbStat3.SelectedIndex
                 && cbStat2.SelectedIndex != cbStat4.SelectedIndex && cbStat2.SelectedIndex != cbStat5.SelectedIndex && cbStat2.SelectedIndex != cbStat6.SelectedIndex
                 && cbStat3.SelectedIndex != cbStat4.SelectedIndex && cbStat3.SelectedIndex != cbStat5.SelectedIndex && cbStat3.SelectedIndex != cbStat6.SelectedIndex
                 && cbStat4.SelectedIndex != cbStat5.SelectedIndex && cbStat4.SelectedIndex != cbStat6.SelectedIndex && cbStat5.SelectedIndex != cbStat6.SelectedIndex)
        {

          uStatBlock[cbStat1.SelectedIndex] = (int)lblStat1.Content;
          uStatBlock[cbStat2.SelectedIndex] = (int)lblStat2.Content;
          uStatBlock[cbStat3.SelectedIndex] = (int)lblStat3.Content;
          uStatBlock[cbStat4.SelectedIndex] = (int)lblStat4.Content;
          uStatBlock[cbStat5.SelectedIndex] = (int)lblStat5.Content;
          uStatBlock[cbStat6.SelectedIndex] = (int)lblStat6.Content;

          myCharacter.Strength = uStatBlock[0];
          myCharacter.Dexterity = uStatBlock[1];
          myCharacter.Constitution = uStatBlock[2];
          myCharacter.Intelligence = uStatBlock[3];
          myCharacter.Wisdom = uStatBlock[4];
          myCharacter.Charisma = uStatBlock[5];
          myCharacter.StatBonusArray = myCharacter.SetStatMods();

          sheetform = new CharacterSheet(myCharacter);
          sheetform.Show();
        }
        else
        {
          MessageBox.Show("Please assign each roll value to a unique stat.");
        }

      }

      if (SuicideRoll)
      {

        myCharacter.Strength = uStatBlock[0];
        myCharacter.Dexterity = uStatBlock[1];
        myCharacter.Constitution = uStatBlock[2];
        myCharacter.Intelligence = uStatBlock[3];
        myCharacter.Wisdom = uStatBlock[4];
        myCharacter.Charisma = uStatBlock[5];
        myCharacter.StatBonusArray = myCharacter.SetStatMods();

        sheetform = new CharacterSheet(myCharacter);
        sheetform.Show();
      }

      if (SelfRoll)
      {
        if (txtbxSelfRolledStr.Text != "" && txtbxSelfRolledDex.Text != "" && txtbxSelfRolledCon.Text != "" && txtbxSelfRolledInt.Text != "" && txtbxSelfRolledWis.Text != "" && txtbxSelfRolledCha.Text != "")
        {

          if (int.Parse(txtbxSelfRolledStr.Text) >= 3 && int.Parse(txtbxSelfRolledStr.Text) <= 18 &&
              int.Parse(txtbxSelfRolledDex.Text) >= 3 && int.Parse(txtbxSelfRolledDex.Text) <= 18 &&
              int.Parse(txtbxSelfRolledCon.Text) >= 3 && int.Parse(txtbxSelfRolledCon.Text) <= 18 &&
              int.Parse(txtbxSelfRolledInt.Text) >= 3 && int.Parse(txtbxSelfRolledInt.Text) <= 18 &&
              int.Parse(txtbxSelfRolledWis.Text) >= 3 && int.Parse(txtbxSelfRolledWis.Text) <= 18 &&
              int.Parse(txtbxSelfRolledCha.Text) >= 3 && int.Parse(txtbxSelfRolledCha.Text) <= 18)


          {
            uStatBlock[0] = int.Parse(txtbxSelfRolledStr.Text);
            uStatBlock[1] = int.Parse(txtbxSelfRolledDex.Text);
            uStatBlock[2] = int.Parse(txtbxSelfRolledStr.Text);
            uStatBlock[3] = int.Parse(txtbxSelfRolledStr.Text);
            uStatBlock[4] = int.Parse(txtbxSelfRolledStr.Text);
            uStatBlock[5] = int.Parse(txtbxSelfRolledStr.Text);

            myCharacter.Strength = uStatBlock[0];
            myCharacter.Dexterity = uStatBlock[1];
            myCharacter.Constitution = uStatBlock[2];
            myCharacter.Intelligence = uStatBlock[3];
            myCharacter.Wisdom = uStatBlock[4];
            myCharacter.Charisma = uStatBlock[5];
            myCharacter.StatBonusArray = myCharacter.SetStatMods();

            sheetform = new CharacterSheet(myCharacter);
            sheetform.Show();
          }

          else
          {
            MessageBox.Show("Please enter a number between 3 and 18 for all stats");
          }
        }
        else
        {
          MessageBox.Show("Please enter a number between 3 and 18 for all stats");
        }
      }
    }
  }
}
