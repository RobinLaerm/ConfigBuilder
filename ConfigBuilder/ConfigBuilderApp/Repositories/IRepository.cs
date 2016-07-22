using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Repositories
{
    public interface IRepository<T>
    {
        T Save(T instance);
    }
}
