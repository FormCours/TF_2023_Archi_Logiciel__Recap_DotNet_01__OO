using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Enums
{
    [Flags]
    public enum TransportTypeEnum
    {
        CAR = 1,
        TRAIN = 2,
        BUS = 4,
        WALK = 8,
        BIKE = 16,
        COMMUN = TRAIN | BUS
    }
}

/*
 Enum  | Valeur | Binaire
 ------+--------+-----------
 CAR   |  1     | 0000 0001
 TRAIN |  2     | 0000 0010
 BUS   |  4     | 0000 0100
 WALK  |  8     | 0000 1000
 BIKE  | 16     | 0001 0000


 Riri => TRAIN 
        : 2     → 0000 0010

 Zaza => CAR | BUS
        : 5     → 0000 0101
*/