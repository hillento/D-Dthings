using System;
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
      GetClassSKills();
  }

    private void GetClassSKills()
    {
      
        if (ClassSkillOptions.Contains("Acrobatics"))
        {
          Acrobatics = true;
        }
        if (ClassSkillOptions.Contains("Animal Handling"))
        {
          AnimalHandling = true;
        }
        if (ClassSkillOptions.Contains("Arcaba"))
        {
          Arcana = true;
        }
        if (ClassSkillOptions.Contains("Athletics"))
        {
          Athletics = true;
        }
        if (ClassSkillOptions.Contains("Deception"))
        {
          Deception = true;
        }
        if (ClassSkillOptions.Contains("History"))
        {
          History = true;
        }
        if (ClassSkillOptions.Contains("Insight"))
        {
          Insight = true;
        }
        if (ClassSkillOptions.Contains("Intimidation"))
        {
          Intimidation = true;
        }
        if (ClassSkillOptions.Contains("Investigation"))
        {
          Investigation = true;
        }
        if (ClassSkillOptions.Contains("Medicine"))
        {
          Medicine = true;
        }
        if (ClassSkillOptions.Contains("Nature"))
        {
          Nature = true;
        }
        if (ClassSkillOptions.Contains("Perception"))
        {
          Perception = true;
        }
        if (ClassSkillOptions.Contains("Performance"))
        {
          Performance = true;
        }
        if (ClassSkillOptions.Contains("Persuasion"))
        {
          Persuasion = true;
        }
        if (ClassSkillOptions.Contains("Religion"))
        {
          Religion = true;
        }
        if (ClassSkillOptions.Contains("Sleight of Hand"))
        {
          SleightOfHand = true;
        }
        if (ClassSkillOptions.Contains("Stealth"))
        {
          Stealth = true;
        }
        if (ClassSkillOptions.Contains("Survival"))
        {
          Survival = true;
        }
      
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

    public bool Acrobatics { get; set; }
    public bool AnimalHandling { get; set; }
    public bool Arcana { get; set; }
    public bool Athletics { get; set; }
    public bool Deception { get; set; }
    public bool History { get; set; }
    public bool Insight { get; set; }
    public bool Intimidation { get; set; }
    public bool Investigation { get; set; }
    public bool Medicine { get; set; }
    public bool Nature { get; set; }
    public bool Perception { get; set; }
    public bool Performance { get; set; }
    public bool Persuasion { get; set; }
    public bool Religion { get; set; }
    public bool SleightOfHand { get; set; }
    public bool Stealth { get; set; }
    public bool Survival { get; set; }



  }
}
