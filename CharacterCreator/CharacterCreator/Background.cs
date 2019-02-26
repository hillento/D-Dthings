using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  class Background
  {
    public Background(string[] BgInfo)
    {
      BackgroundName = BgInfo[0];
      Source = BgInfo[1];
      Skills = BgInfo[2];
      Languages = BgInfo[3];
      Tools = BgInfo[4];
    }

    public string BackgroundName { get; set; }
    public string Source { get; set; }
    public string Skills { get; set; }
    public string Languages { get; set; }
    public string Tools { get; set; }

  }
}
