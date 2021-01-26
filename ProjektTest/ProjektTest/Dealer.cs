using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektTest
{
        class Dealer : Player
        {
            public bool ShouldDraw(int sum2)
            {
                if (sum2 <= 16)
                {
                    return true;
                }
                else return false;
            }
        }
    }
