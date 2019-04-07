using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Armor
    {

    public Armor(string[] ArmorInfo)
    {
      ArmorType = ArmorInfo[0];
      Name = ArmorInfo[1];
      Cost = ArmorInfo[2];
      DexMod = ArmorInfo[3];
      ACModMax = ArmorInfo[4];
      AC = ArmorInfo[5];
      StealthDis = ArmorInfo[6];
      Weight = ArmorInfo[7];
    }

    public string ArmorType { get; set; }
    public string Name { get; set; }
    public string Cost { get; set; }
    public string DexMod  { get; set; }
    public string ACModMax { get; set; }
    public string AC { get; set; }
    public string StealthDis { get; set; }
    public string Weight { get; set; }
  }

}
