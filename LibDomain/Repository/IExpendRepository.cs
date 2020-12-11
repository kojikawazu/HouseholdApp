using LibDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Repository
{
    public interface IExpendRepository
    {
        IReadOnlyList<ExpendEntity> selectAll();

        ExpendEntity select_byName(string name);
    }
}
