using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese
{
    public class ManagerHandler: AbstractHandler
    {
        public override string Handle(int request)
        {
            if (request <= 400)
                return $"Spesa di {request} APPROVATA";
            else
                return base.Handle(request);
        }
    }
}
