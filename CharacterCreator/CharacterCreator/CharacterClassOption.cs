using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class CharacterClassOption
  {
    Random rnd = new Random();
    public CharacterClassOption(string[] ClassInfo)
    {
      ClassName = ClassInfo[0];
      Description = ClassInfo[1];
      HitDice = int.Parse(ClassInfo[2]);
      FavoredStats = ClassInfo[3];
      ClassProficiencies = ClassInfo[4];
      SavingThrows = ClassInfo[5];
      ClassSkillOptions = ClassInfo[6];
      NumberOfSkills = int.Parse(ClassInfo[7]);

      GetSavingThrows();
  }

    public void GetClassSkills(string SelectedSkills)
    {
      
        if (SelectedSkills.Contains("Acrobatics"))
        {
          Acrobatics = true;
        }
        if (SelectedSkills.Contains("Animal Handling"))
        {
          AnimalHandling = true;
        }
        if (SelectedSkills.Contains("Arcana"))
        {
          Arcana = true;
        }
        if (SelectedSkills.Contains("Athletics"))
        {
          Athletics = true;
        }
        if (SelectedSkills.Contains("Deception"))
        {
          Deception = true;
        }
        if (SelectedSkills.Contains("History"))
        {
          History = true;
        }
        if (SelectedSkills.Contains("Insight"))
        {
          Insight = true;
        }
        if (SelectedSkills.Contains("Intimidation"))
        {
          Intimidation = true;
        }
        if (SelectedSkills.Contains("Investigation"))
        {
          Investigation = true;
        }
        if (SelectedSkills.Contains("Medicine"))
        {
          Medicine = true;
        }
        if (SelectedSkills.Contains("Nature"))
        {
          Nature = true;
        }
        if (SelectedSkills.Contains("Perception"))
        {
          Perception = true;
        }
        if (SelectedSkills.Contains("Performance"))
        {
          Performance = true;
        }
        if (SelectedSkills.Contains("Persuasion"))
        {
          Persuasion = true;
        }
        if (SelectedSkills.Contains("Religion"))
        {
          Religion = true;
        }
        if (SelectedSkills.Contains("Sleight of Hand"))
        {
          SleightOfHand = true;
        }
        if (SelectedSkills.Contains("Stealth"))
        {
          Stealth = true;
        }
        if (SelectedSkills.Contains("Survival"))
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

    public int SetGold()
    {
      int gold;
      int[] rolls = { 0, 0, 0, 0, 0 };
      int factor = 10;
      int diceNum;
      string classname = ClassName;
      switch (classname)
      {
        case "Barbarian":
          diceNum = 2;
          break;
        case "Bard":
          diceNum = 5;
          break;
        case "Cleric":
          diceNum = 5;
          break;
        case "Druid":
          diceNum = 2;
          break;
        case "Fighter":
          diceNum = 5;
          break;
        case "Monk":
          factor = 1;
          diceNum = 5;
          break;
        case "Paladin":
          diceNum = 5;
          break;
        case "Ranger":
          diceNum = 5;
          break;
        case "Rogue":
          diceNum = 4;
          break;
        case "Sorcerer":
          diceNum = 3;
          break;
        case "Warlock":
          diceNum = 4;
          break;
        case "Wizard":
          diceNum = 4;
          break;
        default:
          diceNum = 1;
          break;
      }
      for (int i = 0; i < diceNum; i++)
      {
        rolls[i] = rnd.Next(1, 5);
      }

      gold = rolls.Sum() * factor;
      return gold;
    }

    public string ClassName { get; set; }
    public string Description { get; set; }
    public int HitDice { get; set; }
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
