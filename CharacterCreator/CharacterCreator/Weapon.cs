using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
  public class Weapon
    

  {
    public Weapon(string[] weaponInfo)
    {
      WeaponType = weaponInfo[0];
      Name = weaponInfo[1];
      Cost = weaponInfo[2];
      Damage = weaponInfo[3];
      Weight = weaponInfo[4];
      Properties = weaponInfo[5];
      Range = weaponInfo[6];
    }
    public string WeaponType { get; set; }
    public string Name { get; set; }
    public string Cost { get; set; }
    public string Damage { get; set; }
    public string Weight { get; set; }
    public string Properties { get; set; }
    public string Range { get; set; }

  }
}
