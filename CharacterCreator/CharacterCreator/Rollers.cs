using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class Rollers
  {
    Random rnd = new Random();
    private int[] rolledStats = new int[6];


    private int[] AutoRoller()
    {
      for(int m=0; m<6; m++)
      {
        int min = 100;
        int[] initialroll = { 0, 0, 0, 0 };
        for(int n=0; n<4; n++)
        {
          initialroll[n] = rnd.Next(1, 7);
          if (min > rolledStats[n])
          {
            min = rolledStats[n];
          }
        }
        rolledStats[m] = rolledStats[0] + rolledStats[1] + rolledStats[2] + rolledStats[3] - min;
      }
      return rolledStats;
    }
  }

}
