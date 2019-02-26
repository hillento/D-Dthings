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

namespace CharacterCreator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Dictionary<String, Background> BackgroundDict = new Dictionary<string, Background>();
    Dictionary<String, CharacterClass> CharacterClassDict = new Dictionary<string, CharacterClass>();
    Dictionary<String, Race> RaceDict = new Dictionary<string, Race>();
    public MainWindow()
    {
      InitializeComponent();

      LoadBackground();
      LoadClasses();
      LoadRaces();
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
          CharacterClassDict.Add(tempClasse[0], new CharacterClass(tempClasse));
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
      if (CharacterClassDict.TryGetValue(cbCharacterClasses.SelectedItem.ToString(), out CharacterClass characterClass))
      {
        UpdateClassInfo(characterClass);
      }
    }

    private void UpdateClassInfo(CharacterClass characterClass)
    {
      txtblkClassDesc.Text = characterClass.Description;
      txtblkHitDice.Text = characterClass.HitDice;
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
  }
}
