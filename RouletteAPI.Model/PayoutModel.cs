using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteAPI.Model;
public class PayoutModel
{
    public string payoutUrl { get; set; }

    public PayoutModel()
    {
        payoutUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
    }
}
