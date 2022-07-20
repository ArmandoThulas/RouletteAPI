using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteAPI.Enum;

public enum BetTypeEnum
{
    P12 = 1, //Dozen bet. 1 to 12
    M12 = 2, //Dozen bet. 13 to 24
    D12 = 3, //Dozen bet. 25 to 36
    FirstHalf = 4, //Low or Manque. 1 to 18
    Secondhalf = 5, //High or Passe. 19 to 36
    Even = 6, //Even Numbers,
    Odd = 7, //Odd Numbers
    Straight = 8,//Bet on a sinle number
}
