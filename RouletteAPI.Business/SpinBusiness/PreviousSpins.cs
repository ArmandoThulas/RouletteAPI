using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Data.Repository.Spin;
using RouletteAPI.Model;
using RouletteAPI.Service;

namespace RouletteAPI.Business.SpinBusiness;
public class PreviousSpins
{
    private readonly ISpinRepository _spinRepository;

    public PreviousSpins()
    {
        _spinRepository = new SpinRepository();
    }

    public async Task<PreviousSpinsModel> GetSpins(int? page, int? pageSize)
    {
        var pageNumber = page is null || page < 1 ? 1 : (int)page;
        var pSize = int.Parse(RouletteAppSettings.GetAppSetting("DefaultPageSize"));
        return await _spinRepository.GetSpins(pageNumber, pSize);
    }
}
