using LibDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Repository
{
    public interface ITypeRepository
    {
        IReadOnlyList<TypeEntity> selectAll();

        TypeEntity Select_byName(string name);
    }
}
