using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteAPI.Business.SpinBusiness;

namespace RouletteAPI.Test;
public class SpinTest
{

    [Test]
    public void Wheel_Number_Not_Null()
    {
        var wheelNumber = WheelNumber.Generate();
        Assert.IsNotNull(wheelNumber);
    }

    [Test]
    public void Is_Wheel_Number_Valid()
    {
        var wheelNumber = WheelNumber.Generate();
        var isValid = wheelNumber is <= 36 and >= 1;
        Assert.IsTrue(isValid);
    }

}
