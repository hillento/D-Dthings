using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  class CharacterClassOption
  {
    public CharacterClassOption(string[] ClassInfo)
    {
      ClassName = ClassInfo[0];
      Description = ClassInfo[1];
      HitDiceName = ClassInfo[2];
      FavoredStats = ClassInfo[3];
      ClassProficiencies = ClassInfo[4];
      SavingThrows = ClassInfo[5];

      SetSavingThrows();
    }

 

    public string ClassName { get; set; }
    public string Description { get; set; }
    public string HitDiceName { get; set; }
    public string FavoredStats { get; set; }
    public string ClassProficiencies { get; set; }
    public string SavingThrows { get; set; }

    public bool StrSavingThrow { get; set; }
    public bool DexSavingThrow { get; set; }
    public bool ConSavingThrow { get; set; }
    public bool IntSavingThrow { get; set; }
    public bool WisSavingThrow { get; set; }
    public bool ChaSavingThrow { get; set; }

    private void SetSavingThrows()
    {
      if(SavingThrows == "*Strength*")
      {
        StrSavingThrow = true;
      }
      if (SavingThrows == "*Dexterity*")
      {
        DexSavingThrow = true;
      }
      if (SavingThrows == "*Constitution*")
      {
        ConSavingThrow = true;
      }
      if (SavingThrows == "*Intelligence*")
      {
        IntSavingThrow = true;
      }
      if (SavingThrows == "*Wisdom*")
      {
        WisSavingThrow = true;
      }
      if (SavingThrows == "*Charisma*")
      {
        ChaSavingThrow = true;
      }
    }

  }
}
