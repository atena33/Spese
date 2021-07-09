using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese
{
    class CEOHandler : AbstractHandler
    {
        public override string Handle(int request)
        {
            if (request <= 2500 && request > 1000)
                return $"Spesa di {request} APPROVATA";
            else
                return base.Handle(request);
        }
    }
}
