using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factory
    {
        public static IDAL getDAL() { return new Dal_with_DB(); }
    }
}
