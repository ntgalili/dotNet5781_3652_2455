using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace BLAPI
{
    /// <summary>
    /// factory class to BL
    /// </summary>
    public static class BLFactory
    {
        //creates the unit BL layer
        public static IBL GetBL()
        {
            return new BLImp();
        }
    }
}
