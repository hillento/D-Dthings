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

    }

    public string ClassName { get; set; }
    public string Description { get; set; }
    public string HitDiceName { get; set; }
    public string FavoredStats { get; set; }
    public string ClassProficiencies { get; set; }

  }
}
