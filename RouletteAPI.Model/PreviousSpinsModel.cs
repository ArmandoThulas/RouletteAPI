using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteAPI.Model;
public class PreviousSpinsModel
{
    public List<SpinModel> spins { get; set; }
    public int totalSpins { get; set; }
    public int page { get; set; }
    public int pageSize { get; set; }

    public PreviousSpinsModel()
    {
        spins = new List<SpinModel>();
    }
}
