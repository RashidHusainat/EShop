using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BuildingBlocks.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string name ,object id) :base ($"{name} not found id={id}")
        {
                
        }
    }
}
