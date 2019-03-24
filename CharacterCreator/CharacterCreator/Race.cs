using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class Race
  {
    public Race(string[] raceInfo)
    {
      RaceName = raceInfo[0];
      Size = raceInfo[1];
      Speed = int.Parse(raceInfo[2]);
      Language = raceInfo[3];
      StrengthBonus = int.Parse(raceInfo[4]);
      DexterityBonus = int.Parse(raceInfo[5]);
      ConstitutionBonus = int.Parse(raceInfo[6]);
      InteligenceBonus = int.Parse(raceInfo[7]);
      WisdomBonus = int.Parse(raceInfo[8]);
      CharismaBonus = int.Parse(raceInfo[9]);
      AssignableBonus = int.Parse(raceInfo[10]);
      DarkVision = int.Parse(raceInfo[11]);

    }

    public String RaceName { get; set; }
    public String Size { get; set; }
    public int Speed { get; set; }
    public String Language { get; set; }
    public int StrengthBonus { get; set; }
    public int DexterityBonus { get; set; }
    public int ConstitutionBonus { get; set; }
    public int InteligenceBonus { get; set; }
    public int WisdomBonus { get; set; }
    public int CharismaBonus { get; set; }
    public int AssignableBonus { get; set; }
    public int DarkVision { get; set; }

    
  }
}
