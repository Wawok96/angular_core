using Insig.Domain.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.ApplicationServices.Boundaries
{
    public interface IHouseRepository
    {
        void EnsureThatHouseDoesNotExist(string name);
        void EnsureThatHouseExist(string name);
        void Store(House house);
        void Delete(string name);
    }
}
