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

      InspirationPoints = 0;
      CharacterLevel = 1;
      SetProficiencyBonusBool();
      SavingThrowBoolArray = SetSavingThrows(myCharacterClass);
      SkillProfsArray = SetSkillProfs(myBackground);


    }

    
    private bool[] SetSkillProfs(Background myBackground)
    {

      bool[] SkillProfsArray = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

      Acrobatics = myBackground.Acrobatics;
      AnimalHandling = myBackground.AnimalHandling;
      Arcana = myBackground.Arcana;
      Athletics = myBackground.Athletics;
      Deception = myBackground.Deception;
      History = myBackground.History;
      Insight = myBackground.Insight;
      Intimidation = myBackground.Intimidation;
      Investigation = myBackground.Investigation;
      Medicine = myBackground.Medicine;
      Nature = myBackground.Nature;
      Perception = myBackground.Perception;
      Performance = myBackground.Performance;
      Persuasion = myBackground.Persuasion;
      Religion = myBackground.Religion;
      SleightOfHand = myBackground.SleightOfHand;
      Stealth = myBackground.Stealth;
      Survival = myBackground.Survival;


      SkillProfsArray[0] = Acrobatics;
      SkillProfsArray[1] = AnimalHandling;
      SkillProfsArray[2] = Arcana;
      SkillProfsArray[3] = Athletics;
      SkillProfsArray[4] = Deception;
      SkillProfsArray[5] = History;
      SkillProfsArray[6] = Insight;
      SkillProfsArray[7] = Intimidation;
      SkillProfsArray[8] = Investigation;
      SkillProfsArray[9] = Medicine;
      SkillProfsArray[10] = Nature;
      SkillProfsArray[11] = Perception;
      SkillProfsArray[12] = Performance;
      SkillProfsArray[13] = Persuasion;
      SkillProfsArray[14] = Religion;
      SkillProfsArray[15] = SleightOfHand;
      SkillProfsArray[16] = Stealth;
      SkillProfsArray[17] = Survival;

      return SkillProfsArray;
    }

    private void SetProficiencyBonusBool()
    {
      if (CharacterLevel < 5)
      {
        ProficiencyBonus = 2;
      }
      else if (CharacterLevel >= 5 && CharacterLevel < 9)
      {
        ProficiencyBonus = 3;
      }
      else if (CharacterLevel >= 9 && CharacterLevel < 13)
      {
        ProficiencyBonus = 4;
      }
      else if (CharacterLevel >= 13 && CharacterLevel < 17)
      {
        ProficiencyBonus = 5;
      }
      else if (CharacterLevel >= 17 && CharacterLevel < 20)
      {
        ProficiencyBonus = 4;
      }
      else
      {
        ProficiencyBonus = -1;
      }
    }

    public int[] SetSkillBonuses()
    {
      int[] SkillBonuses = { DexBonus, WisBonus, IntBonus, StrBonus, ChaBonus, IntBonus, WisBonus, ChaBonus, IntBonus, WisBonus, IntBonus, WisBonus, ChaBonus, ChaBonus, IntBonus, DexBonus, DexBonus, WisBonus};

      for (int i = 0; i < SkillBonuses.Length; i++)
      {
        if (SkillProfsArray[i])
          SkillBonuses[i] = SkillBonuses[i] + ProficiencyBonus;
        else
        {
          SkillBonuses[i] = SkillBonuses[i];
        }
      }
      return SkillBonuses;
    }



    public int[] SetSaveValues()
    {
      int[] savingThrowBonusArray = { 0, 0, 0, 0, 0, 0 };

      for (int i = 0; i < SavingThrowBoolArray.Length; i++)
      {
        if (SavingThrowBoolArray[i])
        {
          savingThrowBonusArray[i] = ProficiencyBonus + StatBonusArray[i];
        }
        else
        {
          savingThrowBonusArray[i] = StatBonusArray[i];
        }
      }
      StrSavingThrowBonus = savingThrowBonusArray[0];
      DexSavingThrowBonus = savingThrowBonusArray[1];
      ConSavingThrowBonus = savingThrowBonusArray[2];
      IntSavingThrowBonus = savingThrowBonusArray[3];
      WisSavingThrowBonus = savingThrowBonusArray[4];
      ChaSavingThrowBonus = savingThrowBonusArray[5];

      return savingThrowBonusArray;
    }


    public int[] SetStatMods()
    {
      int[] statBonusArray = { 0, 0, 0, 0, 0, 0 };


      statBonusArray[0] = (int)Math.Floor(((double)Strength - (double)10) / (double)2);
      statBonusArray[1] = (int)Math.Floor(((double)Dexterity - (double)10) / (double)2);
      statBonusArray[2] = (int)Math.Floor(((double)Constitution - (double)10) / (double)2);
      statBonusArray[3] = (int)Math.Floor(((double)Intelligence - (double)10) / (double)2);
      statBonusArray[4] = (int)Math.Floor(((double)Wisdom - (double)10) / (double)2);
      statBonusArray[5] = (int)Math.Floor(((double)Charisma - (double)10) / (double)2);

      StrBonus = statBonusArray[0];
      DexBonus = statBonusArray[1];
      ConBonus = statBonusArray[2];
      IntBonus = statBonusArray[3];
      WisBonus = statBonusArray[4];
      ChaBonus = statBonusArray[5];

      return statBonusArray;
    }

    private bool[] SetSavingThrows(CharacterClassOption myCharacterClass)
    {
      bool[] SavingThrowBools = { false, false, false, false, false, false };

      SavingThrowBools[0] = myCharacterClass.StrSavingThrow;
      SavingThrowBools[1] = myCharacterClass.DexSavingThrow;
      SavingThrowBools[2] = myCharacterClass.ConSavingThrow;
      SavingThrowBools[3] = myCharacterClass.IntSavingThrow;
      SavingThrowBools[4] = myCharacterClass.WisSavingThrow;
      SavingThrowBools[5] = myCharacterClass.ChaSavingThrow;

      StrSavingThrowBool = SavingThrowBools[0];
      DexSavingThrowBool = SavingThrowBools[1];
      ConSavingThrowBool = SavingThrowBools[2];
      IntSavingThrowBool = SavingThrowBools[3];
      WisSavingThrowBool = SavingThrowBools[4];
      ChaSavingThrowBool = SavingThrowBools[5];

      return SavingThrowBools;
    }



    public int CharacterLevel { get; set; }
    public int ProficiencyBonus { get; set; }
    public int InspirationPoints { get; set; }
    public int PassivePerception { get; set; }

    public bool StrSavingThrowBool { get; set; }
    public bool DexSavingThrowBool { get; set; }
    public bool ConSavingThrowBool { get; set; }
    public bool IntSavingThrowBool { get; set; }
    public bool WisSavingThrowBool { get; set; }
    public bool ChaSavingThrowBool { get; set; }
    public bool[] SavingThrowBoolArray { get; set; }

    public int StrSavingThrowBonus { get; set; }
    public int DexSavingThrowBonus { get; set; }
    public int ConSavingThrowBonus { get; set; }
    public int IntSavingThrowBonus { get; set; }
    public int WisSavingThrowBonus { get; set; }
    public int ChaSavingThrowBonus { get; set; }
    public int[] SavingThrowBonusArray { get; set; }



    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }

    public int StrBonus { get; set; }
    public int DexBonus { get; set; }
    public int ConBonus { get; set; }
    public int IntBonus { get; set; }
    public int WisBonus { get; set; }
    public int ChaBonus { get; set; }
    public int[] StatBonusArray { get; set; }


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
    public bool[] SkillProfsArray { get; set; }

    public int[] SkillBonuses { get; set; }




  }
}
