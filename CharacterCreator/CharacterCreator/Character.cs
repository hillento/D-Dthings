using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CharacterCreator
{
  public class Character
  {


    public Character(Background myBackground, CharacterClassOption myCharacterClass, Race myRace)
    {

      
      CharacterLevel = 1;
      SetProficiencyBonusBool();
      SavingThrowBoolArray = SetSavingThrows(myCharacterClass);
      SkillProfsArray = SetSkillProfs(myBackground, myCharacterClass);
      
      


    }

    public void SetPassiveStats(CharacterClassOption myCharacterClass)
    {
      HitPoints = myCharacterClass.HitDice + ConBonus;
      Initiative = DexBonus;
      if (Perception)
      {
        PassivePerception = 10 + WisBonus + ProficiencyBonus;
      }
      else
      {
        PassivePerception = 10 + WisBonus;
      }
    }

    private bool[] SetSkillProfs(Background myBackground, CharacterClassOption characterClass
      )
    {

      bool[] BackgroundSkillProfsArray = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

      BackgroundSkillProfsArray[0] = myBackground.Acrobatics;
      BackgroundSkillProfsArray[1] = myBackground.AnimalHandling;
      BackgroundSkillProfsArray[2] = myBackground.Arcana;
      BackgroundSkillProfsArray[3] = myBackground.Athletics;
      BackgroundSkillProfsArray[4] = myBackground.Deception;
      BackgroundSkillProfsArray[5] = myBackground.History;
      BackgroundSkillProfsArray[6] = myBackground.Insight;
      BackgroundSkillProfsArray[7] = myBackground.Intimidation;
      BackgroundSkillProfsArray[8] = myBackground.Investigation;
      BackgroundSkillProfsArray[9] = myBackground.Medicine;
      BackgroundSkillProfsArray[10] = myBackground.Nature;
      BackgroundSkillProfsArray[11] = myBackground.Perception;
      BackgroundSkillProfsArray[12] = myBackground.Performance;
      BackgroundSkillProfsArray[13] = myBackground.Persuasion;
      BackgroundSkillProfsArray[14] = myBackground.Religion;
      BackgroundSkillProfsArray[15] = myBackground.SleightOfHand;
      BackgroundSkillProfsArray[16] = myBackground.Stealth;
      BackgroundSkillProfsArray[17] = myBackground.Survival;

      bool[] ClassSkillProfsArray = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

      ClassSkillProfsArray[0] = characterClass.Acrobatics;
      ClassSkillProfsArray[1] = characterClass.AnimalHandling;
      ClassSkillProfsArray[2] = characterClass.Arcana;
      ClassSkillProfsArray[3] = characterClass.Athletics;
      ClassSkillProfsArray[4] = characterClass.Deception;
      ClassSkillProfsArray[5] = characterClass.History;
      ClassSkillProfsArray[6] = characterClass.Insight;
      ClassSkillProfsArray[7] = characterClass.Intimidation;
      ClassSkillProfsArray[8] = characterClass.Investigation;
      ClassSkillProfsArray[9] = characterClass.Medicine;
      ClassSkillProfsArray[10] = characterClass.Nature;
      ClassSkillProfsArray[11] = characterClass.Perception;
      ClassSkillProfsArray[12] = characterClass.Performance;
      ClassSkillProfsArray[13] = characterClass.Persuasion;
      ClassSkillProfsArray[14] = characterClass.Religion;
      ClassSkillProfsArray[15] = characterClass.SleightOfHand;
      ClassSkillProfsArray[16] = characterClass.Stealth;
      ClassSkillProfsArray[17] = characterClass.Survival;


      bool[] SkillProfsArray = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
      for (int i = 0; i < ClassSkillProfsArray.Length; i++)
      {
        if (ClassSkillProfsArray[i] || BackgroundSkillProfsArray[i])
        {
          SkillProfsArray[i] = true;
        }
        else
        {
          SkillProfsArray[i] = false;
        }
      }
      Acrobatics = SkillProfsArray[0];
      AnimalHandling = SkillProfsArray[1];
      Arcana = SkillProfsArray[2];
      Athletics = SkillProfsArray[3];
      Deception = SkillProfsArray[4];
      History = SkillProfsArray[5];
      Insight = SkillProfsArray[6];
      Intimidation = SkillProfsArray[7];
      Investigation = SkillProfsArray[8];
      Medicine = SkillProfsArray[9];
      Nature = SkillProfsArray[10];
      Perception = SkillProfsArray[11];
      Performance = SkillProfsArray[12];
      Persuasion = SkillProfsArray[13];
      Religion = SkillProfsArray[14];
      SleightOfHand = SkillProfsArray[15];
      Stealth = SkillProfsArray[16];
      Survival = SkillProfsArray[17];



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
      int[] SkillBonuses = { DexBonus, WisBonus, IntBonus, StrBonus, ChaBonus, IntBonus, WisBonus, ChaBonus, IntBonus, WisBonus, IntBonus, WisBonus, ChaBonus, ChaBonus, IntBonus, DexBonus, DexBonus, WisBonus };

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


      statBonusArray[0] = (int)Math.Floor((Strength - (double)10) / 2);
      statBonusArray[1] = (int)Math.Floor((Dexterity - (double)10) / 2);
      statBonusArray[2] = (int)Math.Floor((Constitution - (double)10) / 2);
      statBonusArray[3] = (int)Math.Floor((Intelligence - (double)10) / 2);
      statBonusArray[4] = (int)Math.Floor((Wisdom - (double)10) / 2);
      statBonusArray[5] = (int)Math.Floor((Charisma - (double)10) / 2);

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
    public int Initiative { get; set; }
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
    public int HitPoints { get; set; }
  }
}
