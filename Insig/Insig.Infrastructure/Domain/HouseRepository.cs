using EnsureThat;
using Insig.ApplicationServices.Boundaries;
using Insig.Common.Exceptions;
using Insig.Domain.Houses;
using Insig.Infrastructure.DataModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.Infrastructure.Domain
{
    public class HouseRepository : IHouseRepository
    {
        private readonly InsigContext _context;
        public HouseRepository(InsigContext context)
        {
            EnsureArg.IsNotNull(context, nameof(context));
            _context = context;
        }

        public void EnsureThatHouseDoesNotExist(string name)
        {
            var sample = _context.Houses.FirstOrDefault(r => r.Name == name);
            if (sample != null)
            {
                throw new DomainException($"Provided house name: \"{name}\" already exist.");
            }
        }

        public void Store(House house)
        {
            _context.Houses.Add(house);
        }
    }
}
