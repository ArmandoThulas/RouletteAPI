using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteAPI.Model;
public class SpinModel
{
    public int spinId { get; set; }
    public int wheelNumber { get; set; }
    public DateTime createdDate { get; set; }
}
