using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class Character
  {
     public Character(Background myBackground, CharacterClassOption myCharacterClass, Race myRace)
    {


      CharacterStrSavingThrow = myCharacterClass.StrSavingThrow;
      CharacterDexSavingThrow = myCharacterClass.DexSavingThrow;
      CharacterConSavingThrow = myCharacterClass.ConSavingThrow;
      CharacterIntSavingThrow = myCharacterClass.IntSavingThrow;
      CharacterWisSavingThrow = myCharacterClass.WisSavingThrow;
      CharacterChaSavingThrow = myCharacterClass.ChaSavingThrow;
    }

    public bool CharacterStrSavingThrow { get; set; }
    public bool CharacterDexSavingThrow { get; set; }
    public bool CharacterConSavingThrow { get; set; }
    public bool CharacterIntSavingThrow { get; set; }
    public bool CharacterWisSavingThrow { get; set; }
    public bool CharacterChaSavingThrow { get; set; }


  }
}
