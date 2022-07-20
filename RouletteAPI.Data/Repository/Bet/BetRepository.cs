using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Data.DbAccess;
using RouletteAPI.Model;

namespace RouletteAPI.Data.Repository.Bet;
public class BetRepository : IBetRepository
{
    private readonly ISqlDataAccess _db;

    public BetRepository()
    {
        _db = new SqlDataAccess();
    }

    public Task InsertBet(BetResultModel result)
    {
        return _db.SaveData("dbo.PI_InsertBet", new { result.bet.betType, result.bet.straightNumber, result.wheelNumber, result.result });
    }
}
