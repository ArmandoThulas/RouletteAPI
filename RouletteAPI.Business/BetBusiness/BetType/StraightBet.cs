using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Model;

namespace RouletteAPI.Business.BetBusiness.BetType;
public class StraightBet : IBetType
{
    public int wheelNumber { get; set; }
    public PlaceBetModel bet { get; set; }

    public StraightBet(PlaceBetModel bet, int wheelNumber)
    {
        this.bet = bet;
        this.wheelNumber = wheelNumber;
    }

    public BetResultModel BetResult()
    {
        var isvalid = wheelNumber == bet.straightNumber;
        var betResult = new BetResultModel
        {
            bet = bet,
            wheelNumber = wheelNumber,
            result = isvalid
        };
        return betResult;
    }
}
