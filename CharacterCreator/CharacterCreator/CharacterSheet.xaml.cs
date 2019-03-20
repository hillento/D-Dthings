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

namespace CharacterCreator
{
  /// <summary>
  /// Interaction logic for CharacterSheet.xaml
  /// </summary>
  public partial class CharacterSheet : Window
  {
    Character myCharacter;
    public CharacterSheet(Character character)
    {

      myCharacter = character;
      InitializeComponent();

      SavingThrows();

     
      
      
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
