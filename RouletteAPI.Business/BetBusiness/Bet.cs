using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Business.BetBusiness.BetType;
using RouletteAPI.Business.SpinBusiness;
using RouletteAPI.Data.Repository.Bet;
using RouletteAPI.Enum;
using RouletteAPI.Model;

namespace RouletteAPI.Business.BetBusiness;

public class Bet
{
    private IBetType? _betType;
    private readonly IBetRepository _betRepository;

    public Bet()
    {
        _betRepository = new BetRepository();
    }

    public async Task<BetResultModel> PlaceBet(PlaceBetModel bet)
    {
        var wheelNumber = WheelNumber.Generate();
        _betType = bet.betType switch
        {
            BetTypeEnum.P12 => new P12Bet(bet, wheelNumber),
            BetTypeEnum.M12 => new M12Bet(bet, wheelNumber),
            BetTypeEnum.D12 => new D12Bet(bet, wheelNumber),
            BetTypeEnum.FirstHalf => new FirstHalfBet(bet, wheelNumber),
            BetTypeEnum.Secondhalf => new SecondHalfBet(bet, wheelNumber),
            BetTypeEnum.Even => new EvenNumbersBet(bet, wheelNumber),
            BetTypeEnum.Odd => new OddNumbersBet(bet, wheelNumber),
            BetTypeEnum.Straight => new StraightBet(bet, wheelNumber),
            _ => throw new ArgumentOutOfRangeException(nameof(bet.betType)),
        };
        var result = _betType.BetResult();
        await _betRepository.InsertBet(result);
        return result;
    }
}
