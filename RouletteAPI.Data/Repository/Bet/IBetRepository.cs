using RouletteAPI.Model;

namespace RouletteAPI.Data.Repository.Bet;
public interface IBetRepository
{
    Task InsertBet(BetResultModel result);
}
