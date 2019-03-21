﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class CharacterClassOption
  {
    public CharacterClassOption(string[] ClassInfo)
    {
      ClassName = ClassInfo[0];
      Description = ClassInfo[1];
      HitDiceName = ClassInfo[2];
      FavoredStats = ClassInfo[3];
      ClassProficiencies = ClassInfo[4];
      SavingThrows = ClassInfo[5];
      ClassSkillOptions = ClassInfo[6];
      NumberOfSkills = int.Parse(ClassInfo[7]);

      GetSavingThrows();
  }

    private void GetSavingThrows()
    {
      if(SavingThrows.Contains("Str"))
      {
        StrSavingThrow = true;
      }
      if (SavingThrows.Contains("Dex"))
      {
        DexSavingThrow = true;
      }
      if (SavingThrows.Contains("Con"))
      {
        ConSavingThrow = true;
      }
      if (SavingThrows.Contains("Int"))
      {
        IntSavingThrow = true;
      }
      if (SavingThrows.Contains("Wis"))
      {
        WisSavingThrow = true;
      }
      if (SavingThrows.Contains("Cha"))
      {
        ChaSavingThrow = true;
      }
    }

    public string ClassName { get; set; }
    public string Description { get; set; }
    public string HitDiceName { get; set; }
    public string FavoredStats { get; set; }
    public string ClassProficiencies { get; set; }
    public string SavingThrows { get; set; }
    public string ClassSkillOptions { get; set; }
    public int NumberOfSkills { get; set; }

    public bool StrSavingThrow { get; set; }
    public bool DexSavingThrow { get; set; }
    public bool ConSavingThrow { get; set; }
    public bool IntSavingThrow { get; set; }
    public bool WisSavingThrow { get; set; }
    public bool ChaSavingThrow { get; set; }

    

  }
}
