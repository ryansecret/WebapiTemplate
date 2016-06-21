using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ryan.Model;

namespace Ryan.Repository
{
    public class RyanRepository: IRyanRepository
    { 
        public string Hello()
        {
            return "Hello from ryan";
        }
    }
}
