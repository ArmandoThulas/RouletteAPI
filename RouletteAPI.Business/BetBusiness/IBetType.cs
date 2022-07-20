using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Model;

namespace RouletteAPI.Business.BetBusiness;
public interface IBetType
{
    int wheelNumber { get; set; }
    PlaceBetModel bet { get; set; }
    BetResultModel BetResult();
}
