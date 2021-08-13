using Insig.PublishedLanguage.Dtos;
using Insig.PublishedLanguage.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.ApplicationServices.Boundaries
{
    public interface IHouseQuery
    {
        Task<List<HouseDTO>> GetHouseData(HouseParameter query);
    }
}
