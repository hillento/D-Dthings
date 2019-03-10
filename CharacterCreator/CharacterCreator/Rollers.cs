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

    /// <summary>
    /// Creates 4 random numbers and sums the top 3. This is repeated 6 times and put into an array to assign to the 6 basic stats
    /// </summary>
    /// <returns></returns>
    public int[] ComputerRoller()
    {
      for (int m = 0; m < 6; m++)
      {
        int min = 99;
        int[] rolls = { 0, 0, 0, 0 };
        for (int n = 0; n < 4; n++)
        {
          rolls[n] = rnd.Next(1, 7);
          if (min > rolls[n])
          {
            min = rolls[n];
          }
        }
        rolledStats[m] = rolls[0] + rolls[1] + rolls[2] + rolls[3] - min;
      }
      
      return rolledStats;
    }


    /// <summary>
    /// Rolls the stats in order Str, Dex, Con, Int, Wis, Cha. The rolls are random 1-20 (as if you rolled a d20). The player does not get to assign them.
    /// </summary>
    /// <returns></returns>
    public int[] SuicideRoller()
    {
      for (int m = 0; m < 6; m++)
      {
        int min = 7;
        int roll = 0;
        roll = rnd.Next(1, 21);
        if (min > roll)
        {
          min = roll;
        }
        rolledStats[m] = roll;
      }
      return rolledStats;
    }
  }
}