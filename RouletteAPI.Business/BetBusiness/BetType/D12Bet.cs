using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Model;

namespace RouletteAPI.Business.BetBusiness.BetType;
public class D12Bet : IBetType
{
    public int wheelNumber { get; set; }
    public PlaceBetModel bet { get; set; }

    public D12Bet(PlaceBetModel bet, int wheelNumber)
    {
        this.bet = bet;
        this.wheelNumber = wheelNumber;
    }

    public BetResultModel BetResult()
    {
        var isvalid = wheelNumber >= 25 && wheelNumber <= 36;
        var betResult = new BetResultModel
        {
            bet = bet,
            wheelNumber = wheelNumber,
            result = isvalid
        };
        return betResult;
    }
}
