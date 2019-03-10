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

    public void CharacterMods()
    {
      
    }

    public bool CharacterStrSavingThrow { get; set; }
    public bool CharacterDexSavingThrow { get; set; }
    public bool CharacterConSavingThrow { get; set; }
    public bool CharacterIntSavingThrow { get; set; }
    public bool CharacterWisSavingThrow { get; set; }
    public bool CharacterChaSavingThrow { get; set; }

    public int CharacterStr { get; set; }
    public int CharacterDex { get; set; }
    public int CharacterCon { get; set; }
    public int CharacterInt { get; set; }
    public int CharacterWis { get; set; }
    public int CharacterCha { get; set; }





  }
}
