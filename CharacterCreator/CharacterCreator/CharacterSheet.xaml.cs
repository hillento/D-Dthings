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
using System.Windows.Shapes;
using System.IO;

namespace CharacterCreator
{
  /// <summary>
  /// Interaction logic for CharacterSheet.xaml
  /// </summary>
  public partial class CharacterSheet : Window
  {
    Dictionary<string, Weapon> WeaponDict = new Dictionary<string, Weapon>();
    Character myCharacter;
    
    public CharacterSheet(Character character)
    {

      myCharacter = character;
      InitializeComponent();

      //LoadWeapons();
      SavingThrows();
      SetStats();
      SetPassives();
      SetSkills();

     
      
      
    }

    private void LoadWeapons()
    {
      StreamReader weaponsfile;
      string[] tempWeapon;
      try
      {
        weaponsfile = File.OpenText("Weapons.txt");
        weaponsfile.ReadLine();
        while (!weaponsfile.EndOfStream)
        {
          tempWeapon = weaponsfile.ReadLine().Split('\t');
          WeaponDict.Add(tempWeapon[1], new Weapon(tempWeapon));
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    private void SetSkills()
    {

      myCharacter.SkillBonuses = myCharacter.SetSkillBonuses();

      cbAcrobatics.IsChecked = myCharacter.Acrobatics;
      cbAnimalHandling.IsChecked = myCharacter.AnimalHandling;
      cbArcana.IsChecked = myCharacter.Arcana;
      cbAthletics.IsChecked = myCharacter.Athletics;
      cbDeception.IsChecked = myCharacter.Deception;
      cbHistory.IsChecked = myCharacter.History;
      cbInsight.IsChecked = myCharacter.Insight;
      cbIntimidation.IsChecked = myCharacter.Intimidation;
      cbInvestigation.IsChecked = myCharacter.Investigation;
      cbMedicine.IsChecked = myCharacter.Medicine;
      cbNature.IsChecked = myCharacter.Nature;
      cbPerception.IsChecked = myCharacter.Perception;
      cbPerformance.IsChecked = myCharacter.Performance;
      cbPersuasion.IsChecked = myCharacter.Persuasion;
      cbReligion.IsChecked = myCharacter.Religion;
      cbSlightOfHand.IsChecked = myCharacter.SleightOfHand;
      cbStealth.IsChecked = myCharacter.Stealth;
      cbSurvival.IsChecked = myCharacter.Survival;

     

      lblAcrobatics.Content = myCharacter.SkillBonuses[0];
      lblAnimalHandling.Content = myCharacter.SkillBonuses[1];
      lblArcana.Content = myCharacter.SkillBonuses[2];
      lblAthletics.Content = myCharacter.SkillBonuses[3];
      lblDeception.Content = myCharacter.SkillBonuses[4];
      lblHistory.Content = myCharacter.SkillBonuses[5];
      lblInsight.Content = myCharacter.SkillBonuses[6];
      lblIntimidation.Content = myCharacter.SkillBonuses[7];
      lblInvestigation.Content = myCharacter.SkillBonuses[8];
      lblMedicine.Content = myCharacter.SkillBonuses[9];
      lblNature.Content = myCharacter.SkillBonuses[10];
      lblPerception.Content = myCharacter.SkillBonuses[11];
      lblPerformance.Content = myCharacter.SkillBonuses[12];
      lblPersuasion.Content = myCharacter.SkillBonuses[13];
      lblReligion.Content = myCharacter.SkillBonuses[14];
      lblSleightOfHand.Content = myCharacter.SkillBonuses[15];
      lblStealth.Content = myCharacter.SkillBonuses[16];
      lblSurvival.Content = myCharacter.SkillBonuses[17];
    }

    private void SetPassives()
    {
      lblProficiencyBonus.Content = myCharacter.ProficiencyBonus;
      lblInitiative.Content = myCharacter.DexBonus;
      lblPassivePerception.Content = myCharacter.PassivePerception;
      lblHitPoints.Content = myCharacter.HitPoints;
      lblSpeed.Content = myCharacter.Speed;
      lblGoldPieces.Content = myCharacter.Gold;
    }

    private void SetStats()
    {
      
      lblStr.Content = myCharacter.Strength;
      lblDex.Content = myCharacter.Dexterity;
      lblCon.Content = myCharacter.Constitution;
      lblInt.Content = myCharacter.Intelligence;
      lblWis.Content = myCharacter.Wisdom;
      lblCha.Content = myCharacter.Charisma;

      lblStrMod.Content = myCharacter.StrBonus;
      lblDexMod.Content = myCharacter.DexBonus;
      lblConMod.Content = myCharacter.ConBonus;
      lblIntMod.Content = myCharacter.IntBonus;
      lblWisMod.Content = myCharacter.WisBonus;
      lblChaMod.Content = myCharacter.ChaBonus;
    }

    private void SavingThrows()
    {
      

      myCharacter.SetSaveValues();

      chkbxSavingStr.IsChecked = myCharacter.StrSavingThrowBool;
      chkbxSavingDex.IsChecked = myCharacter.DexSavingThrowBool;
      chkbxSavingCon.IsChecked = myCharacter.ConSavingThrowBool;
      chkbxSavingInt.IsChecked = myCharacter.IntSavingThrowBool;
      chkbxSavingWis.IsChecked = myCharacter.WisSavingThrowBool;
      chkbxSavingCha.IsChecked = myCharacter.ChaSavingThrowBool;

      lblSavingStr.Content = myCharacter.StrSavingThrowBonus.ToString();
      lblSavingDex.Content = myCharacter.DexSavingThrowBonus.ToString();
      lblSavingCon.Content = myCharacter.ConSavingThrowBonus.ToString();
      lblSavingInt.Content = myCharacter.IntSavingThrowBonus.ToString();
      lblSavingWis.Content = myCharacter.WisSavingThrowBonus.ToString();
      lblSavingCha.Content = myCharacter.ChaSavingThrowBonus.ToString();
    }
  }
}
