using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RouletteAPI.Data.DbAccess;
using RouletteAPI.Model;
using RouletteAPI.Service;

namespace RouletteAPI.Data.Repository.Spin;
public class SpinRepository : ISpinRepository
{
    private readonly ISqlDataAccess _db;

    public SpinRepository()
    {
        _db = new SqlDataAccess();
    }

    public Task InsertSpin(int wheelNumber)
    {
        return _db.SaveData("dbo.PI_InsertSpin", new { wheelNumber });
    }

    public async Task<PreviousSpinsModel> GetSpins(int pageNumber, int pageSize)
    {
        using IDbConnection connection = new SqlConnection(RouletteAppSettings.GetConnectionString("Default"));
        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@pageNumber", pageNumber);
        parameter.Add("@pageSize", pageNumber);
        parameter.Add("@totalNumber", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
        var spins = await connection.QueryAsync<SpinModel>("dbo.PS_PreviousSpin", parameter, commandType: CommandType.StoredProcedure);
        var model = new PreviousSpinsModel
        {
            spins = spins.ToList(),
            totalSpins = int.Parse(parameter.Get<string>("@totalNumber")),
            page = pageNumber,
            pageSize = pageSize
        };
        return model;
    }
}
