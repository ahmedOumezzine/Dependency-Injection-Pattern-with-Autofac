using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Model
{
    public class Team : BaseModel<int>
    {
        public String Username { get; set; }
    }
}
