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
  /// Interaction logic for WeaponSelect.xaml
  /// </summary>
  public partial class StartItemSelect : Window
  {
    Character myCharacter;
    Dictionary<string, Weapon> WeaponDict = new Dictionary<string, Weapon>();
    Dictionary<string, Armor> ArmorDict = new Dictionary<string, Armor>();
    string myRace;
    List<string> LightArmorList = new List<string>();
    List<string> MediumArmorList = new List<string>();
    List<string> HeavyArmorList = new List<string>();

    List<string> SimpleMeleeList = new List<string>();
    List<string> SimpleRangedList = new List<string>();
    List<string> MartialRangedList = new List<string>();
    List<string> MartialMeleeList = new List<string>();


    public StartItemSelect(string ClassName, Character Character)
    {
      InitializeComponent();
      myCharacter = Character;
      myRace = ClassName;

      LoadWeapons();
      LoadArmor();
      WeaponSelect();

    }

    private void WeaponSelect()
    {
      switch (myRace)
      {
        case "Barbarian":
          cbItemSelect1.Visibility = Visibility.Visible;
          cbItemSelect2.Visibility = Visibility.Visible;
          foreach (string weapon in MartialMeleeList)
          {
            cbItemSelect1.Items.Add(weapon);
          }
          cbItemSelect2.Items.Add("Two Handaxes");
          foreach(string weapon in SimpleMeleeList)
          {
            cbItemSelect2.Items.Add(weapon);
          }
          break;
        case "Bard":
          cbItemSelect1.Visibility = Visibility.Visible;
          cbItemSelect1.Items.Add("Rapier");
          cbItemSelect1.Items.Add("Longsword");
          foreach (string weapon in SimpleMeleeList)
          {
            cbItemSelect2.Items.Add(weapon);
          }
          break;
        case "Cleric":
          cbItemSelect1.Visibility = Visibility.Visible;
          cbItemSelect2.Visibility = Visibility.Visible;
          cbItemSelect3.Visibility = Visibility.Visible;
          cbItemSelect1.Items.Add("Mace");
          cbItemSelect1.Items.Add("Warhammer");
          cbItemSelect2.Items.Add("Scale mail");
          cbItemSelect2.Items.Add("Leather Armor");
          cbItemSelect2.Items.Add("Chain mail");
          foreach (string weapon in SimpleMeleeList)
          {
            cbItemSelect3.Items.Add(weapon);
          }
          foreach (string weapon in SimpleRangedList)
          {
            cbItemSelect3.Items.Add(weapon);
          }
          break;
        case "Druid":
          cbItemSelect1.Visibility = Visibility.Visible;
          cbItemSelect2.Visibility = Visibility.Visible;
          cbItemSelect1.Items.Add("Shield");
          foreach (string weapon in SimpleMeleeList)
          {
            cbItemSelect1.Items.Add(weapon);
          }
          foreach (string weapon in SimpleRangedList)
          {
            cbItemSelect1.Items.Add(weapon);
          }
          cbItemSelect2.Items.Add("Scimitar");
          foreach (string weapon in SimpleMeleeList)
          {
            cbItemSelect2.Items.Add(weapon);
          }
          break;
        case "Fighter":
          cbItemSelect1.Visibility = Visibility.Visible;
          cbItemSelect2.Visibility = Visibility.Visible;
          cbItemSelect3.Visibility = Visibility.Visible;
          cbItemSelect4.Visibility = Visibility.Visible;

          cbItemSelect1.Items.Add("Chain mail");
          cbItemSelect1.Items.Add("Leather Armor, longbow and 20 arrows");
          foreach (string weapon in MartialMeleeList)
          {
            cbItemSelect2.Items.Add(weapon + " and Shield");
          }
          foreach (string weapon in MartialRangedList)
          {
            cbItemSelect2.Items.Add(weapon + " and Shield");
          }
          foreach (string weapon in MartialMeleeList)
          {
            cbItemSelect2.Items.Add("2 " + weapon);
          }
          foreach (string weapon in MartialRangedList)
          {
            cbItemSelect2.Items.Add("2 " + weapon);
          }
          cbItemSelect3.Items.Add("Light Crossbow and 20 bolts");
          cbItemSelect3.Items.Add("2 Hand axes");
          break;



      }
    }

    private void LoadArmor()
    {
      StreamReader Armorfile;
      string[] tempArmor;
      try
      {
        Armorfile = File.OpenText("Armors.txt");
        Armorfile.ReadLine();
        while (!Armorfile.EndOfStream)
        {
          tempArmor = Armorfile.ReadLine().Split('\t');
          ArmorDict.Add(tempArmor[1], new Armor(tempArmor));

          switch (tempArmor[0])
          {
            case "Light Armor":
              LightArmorList.Add(tempArmor[1]);
              break;
            case "Medium Armor":
              MediumArmorList.Add(tempArmor[1]);
              break;
            case "Heavy Armor":
              HeavyArmorList.Add(tempArmor[1]);
              break;

            default:
              break;
          }   
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    private void LoadWeapons()
    {

      StreamReader Weaponfile;
      string[] tempWeapon;
      try
      {
        Weaponfile = File.OpenText("Weapons.txt");
        Weaponfile.ReadLine();
        while (!Weaponfile.EndOfStream)
        {
          tempWeapon = Weaponfile.ReadLine().Split('\t');
          WeaponDict.Add(tempWeapon[1], new Weapon(tempWeapon));

          switch (tempWeapon[0])
          {
            case "Simple Melee":
              SimpleMeleeList.Add(tempWeapon[1]);
                break;
            case "Simple Ranged":
              SimpleRangedList.Add(tempWeapon[1]);
                break;
            case "Martial Melee":
              MartialMeleeList.Add(tempWeapon[1]);
              break;
            case "Martial Ranged":
              MartialRangedList.Add(tempWeapon[1]);
              break;

            default:
              break;
          }
        }
      }
      catch (Exception)
      {

        throw;
      }

    }
  }
}
