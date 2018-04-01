using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Factory
    {
        public static IBL getBL() { return new BL_imp(); }
    }
}
