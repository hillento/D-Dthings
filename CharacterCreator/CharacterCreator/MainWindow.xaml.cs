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
    int[] uStatBlock;
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
      string[] StatNames = {"Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma", "Select... " };

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
      if(BackgroundDict.TryGetValue(cbBackgrounds.SelectedItem.ToString(), out Background background))
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
      txtblkClassDesc.Text = characterClass.Description;
      txtblkHitDice.Text = "d" + characterClass.HitDiceName;
      txtblkFavoredStats.Text = characterClass.FavoredStats;
      txtblkClassProficiencies.Text = characterClass.ClassProficiencies;
    }

    private void CbRaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(RaceDict.TryGetValue(cbRaces.SelectedItem.ToString(), out Race race))
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
      uStatBlock = uRollType.SuicideRoller();
      lblStat1.Content = uStatBlock[0];
      lblStat2.Content = uStatBlock[1];
      lblStat3.Content = uStatBlock[2];
      lblStat4.Content = uStatBlock[3];
      lblStat5.Content = uStatBlock[4];
      lblStat6.Content = uStatBlock[5];

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

      cbStat1.Visibility = Visibility.Hidden;
    }

    private void BtnComputerRoll_Click(object sender, RoutedEventArgs e)
    {
      uStatBlock = uRollType.ComputerRoller();
      lblStat1.Content = uStatBlock[0];
      lblStat2.Content = uStatBlock[1];
      lblStat3.Content = uStatBlock[2];
      lblStat4.Content = uStatBlock[3];
      lblStat5.Content = uStatBlock[4];
      lblStat6.Content = uStatBlock[5];

     
      btnComputerRoll.Visibility = Visibility.Hidden;
    }

    private void BtnGenerateCharacter_Click(object sender, RoutedEventArgs e)
    {
      if(cbBackgrounds.SelectedIndex != -1)
      {
        if (cbCharacterClasses.SelectedIndex != -1)
        {
          if (cbRaces.SelectedIndex != -1)
          {
            if (cbStat1.SelectedIndex != 6 && cbStat2.SelectedIndex != 6 && cbStat3.SelectedIndex != 6 && cbStat4.SelectedIndex != 6 && cbStat5.SelectedIndex != 6 && cbStat6.SelectedIndex != 6 )
            {


              if (cbStat1.SelectedIndex != cbStat2.SelectedIndex && cbStat1.SelectedIndex != cbStat3.SelectedIndex && cbStat1.SelectedIndex != cbStat4.SelectedIndex
                 && cbStat1.SelectedIndex != cbStat5.SelectedIndex && cbStat1.SelectedIndex != cbStat6.SelectedIndex && cbStat2.SelectedIndex != cbStat3.SelectedIndex
                 && cbStat2.SelectedIndex != cbStat4.SelectedIndex && cbStat2.SelectedIndex != cbStat5.SelectedIndex && cbStat2.SelectedIndex != cbStat6.SelectedIndex
                 && cbStat3.SelectedIndex != cbStat4.SelectedIndex && cbStat3.SelectedIndex != cbStat5.SelectedIndex && cbStat3.SelectedIndex != cbStat6.SelectedIndex
                 && cbStat4.SelectedIndex != cbStat5.SelectedIndex && cbStat4.SelectedIndex != cbStat6.SelectedIndex && cbStat5.SelectedIndex != cbStat6.SelectedIndex)
              {
                CharacterSheet sheetform = new CharacterSheet();
                sheetform.Show();
              }
              else
              {
                MessageBox.Show("Please assign each roll value to a unique stat.");
              }
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
  }
}
