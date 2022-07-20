using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Enum;

namespace RouletteAPI.Model;

public class PlaceBetModel
{
    [Required(ErrorMessage = "Kindly provide the Bet Type to proceed."), Range(1,8, ErrorMessage = "Bet Type must be a number between 1 and 8")]
    public BetTypeEnum betType { get; set; }

    [Range(0,36, ErrorMessage ="Straigth number must be a number between 0 and 36")]
    public int? straightNumber { get; set; }
}
