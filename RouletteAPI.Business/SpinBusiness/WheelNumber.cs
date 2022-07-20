using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteAPI.Business.SpinBusiness;
public static class WheelNumber
{
    public static int Generate()
    {
        return Random.Shared.Next(1, 36);
    }
}
