using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication15.Repositories
{
    interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Delete(int id);
        bool Insert(T entity);
        bool Update(T entity);
    }
}
