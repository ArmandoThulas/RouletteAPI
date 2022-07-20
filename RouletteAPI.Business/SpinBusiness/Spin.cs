using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Data.Repository.Spin;
using RouletteAPI.Model;

namespace RouletteAPI.Business.SpinBusiness;
public class Spin
{
    private readonly ISpinRepository _spinRepository;

    public Spin()
    {
        _spinRepository = new SpinRepository();
    }

    public async Task<SpinResultModel> Run()
    {
        var spin = new SpinResultModel{wheelNumber = WheelNumber.Generate()};
        await _spinRepository.InsertSpin(spin.wheelNumber);
        return spin;
    }
}
