using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Enum;

namespace RouletteAPI.Model;
public class BetResultModel
{
    public PlaceBetModel bet { get; set; }
    public int wheelNumber { get; set; }
    public bool result { get; set; }

    public BetResultModel()
    {
        bet = new PlaceBetModel();
    }
}
