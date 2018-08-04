using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Interfaces
{

    public interface IEntity
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
    }

    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}