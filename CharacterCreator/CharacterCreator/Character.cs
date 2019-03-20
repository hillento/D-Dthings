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
       
      
      CharacterLevel = 1;
      SetProficiencyBonusBool();
      SavingThrowBoolArray = SetSavingThrows(myCharacterClass);
      




    }

    private void SetProficiencyBonusBool()
    {
      if(CharacterLevel < 5)
      {
        ProficiencyBonus = 2;
      }
      else if(CharacterLevel >= 5 && CharacterLevel < 9)
      {
        ProficiencyBonus = 3;
      }
      else if(CharacterLevel >= 9 && CharacterLevel < 13)
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

      statBonusArray[0] = (Strength - 10) / 2;
      statBonusArray[1] = (Dexterity - 10) / 2;
      statBonusArray[2] = (Constitution- 10) / 2;
      statBonusArray[3] = (Intelligence - 10) / 2;
      statBonusArray[4] = (Wisdom - 10) / 2;
      statBonusArray[5] = (Charisma - 10) / 2;

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
      bool[] SavingThrowBools = { false, false, false, false, false, false } ;

      SavingThrowBools[0] = myCharacterClass.StrSavingThrow;
      SavingThrowBools[1] = myCharacterClass.DexSavingThrow;
      SavingThrowBools[2] = myCharacterClass.ConSavingThrow;
      SavingThrowBools[3] = myCharacterClass.IntSavingThrow;
      SavingThrowBools[4] = myCharacterClass.WisSavingThrow;
      SavingThrowBools[5] = myCharacterClass.ChaSavingThrow;

      return SavingThrowBools;
    }

   

    public int CharacterLevel { get; set; }
    public int ProficiencyBonus { get; set; }

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







  }
}
