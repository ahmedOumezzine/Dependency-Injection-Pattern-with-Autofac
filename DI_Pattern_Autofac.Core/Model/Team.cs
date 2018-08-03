using System.Collections.Generic;

namespace DI_Pattern_Autofac.Core.Model
{
    public class Team : BaseModel<int>
    {
        public virtual IEnumerable<User> Users { get; set; }
    }
}
