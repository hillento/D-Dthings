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
     
      
      LoadSheet();
    }

    private void LoadSheet()
    {
      if (myCharacter.CharacterStrSavingThrow == true)
      {
        ckbxSavingStr.IsChecked = true;
      }

      if (myCharacter.CharacterDexSavingThrow == true)
      {
        ckbxSavingDex.IsChecked = true;
      }

      if (myCharacter.CharacterConSavingThrow == true)
      {
        ckbxSavingCon.IsChecked = true;
      }

      if (myCharacter.CharacterIntSavingThrow == true)
      {
        ckbxSavingInt.IsChecked = true;
      }

      if (myCharacter.CharacterWisSavingThrow == true)
      {
        ckbxSavingWis.IsChecked = true;
      }

      if (myCharacter.CharacterChaSavingThrow == true)
      {
        ckbxSavingCha.IsChecked = true;
      }


    }
  }
}
