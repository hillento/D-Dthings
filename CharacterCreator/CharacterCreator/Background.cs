using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class Background
  {
    public Background(string[] BgInfo)
    {
      BackgroundName = BgInfo[0];
      Source = BgInfo[1];
      Skills = BgInfo[2];
      Languages = BgInfo[3];
      Tools = BgInfo[4];

      GetSkills();
    }

    private void GetSkills()
    {
      if (Skills.Contains("Acrobatics"))
      {
        Acrobatics = true;
      }
      if (Skills.Contains("Animal Handling"))
      {
        AnimalHandling = true;
      }
      if (Skills.Contains("Arcaba"))
      {
        Arcana = true;
      }
      if (Skills.Contains("Athletics"))
      {
        Athletics = true;
      }
      if (Skills.Contains("Deception"))
      {
        Deception = true;
      }
      if (Skills.Contains("History"))
      {
        History = true;
      }
      if (Skills.Contains("Insight"))
      {
        Insight = true;
      }
      if (Skills.Contains("Intimidation"))
      {
        Intimidation = true;
      }
      if (Skills.Contains("Investigation"))
      {
        Investigation = true;
      }
      if (Skills.Contains("Medicine"))
      {
        Medicine = true;
      }
      if (Skills.Contains("Nature"))
      {
        Nature = true;
      }
      if (Skills.Contains("Perception"))
      {
        Perception = true;
      }
      if (Skills.Contains("Performance"))
      {
        Performance = true;
      }
      if (Skills.Contains("Persuasion"))
      {
        Persuasion = true;
      }
      if (Skills.Contains("Religion"))
      {
        Religion = true;
      }
      if (Skills.Contains("Sleight of Hand"))
      {
        SleightOfHand = true;
      }
      if (Skills.Contains("Stealth"))
      {
        Stealth = true;
      }
      if (Skills.Contains("Survival"))
      {
        Survival = true;
      }
    }

    public string BackgroundName { get; set; }
    public string Source { get; set; }
    public string Skills { get; set; }
    public string Languages { get; set; }
    public string Tools { get; set; }

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
