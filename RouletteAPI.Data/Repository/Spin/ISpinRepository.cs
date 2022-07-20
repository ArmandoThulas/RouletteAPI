using RouletteAPI.Model;

namespace RouletteAPI.Data.Repository.Spin;
public interface ISpinRepository
{
    Task<PreviousSpinsModel> GetSpins(int pageNumber, int pageSize);
    Task InsertSpin(int wheelNumber);
}