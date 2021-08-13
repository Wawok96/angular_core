using EnsureThat;
using Insig.ApplicationServices.Boundaries;
using Insig.Common.CQRS;
using Insig.PublishedLanguage.Dtos;
using Insig.PublishedLanguage.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insig.ApplicationServices.UseCases
{
    public class GetHouseUseCase : IQueryHandler<HouseParameter, List<HouseDTO>>
    {
        private readonly IHouseQuery _houseQuery;

        public GetHouseUseCase(IHouseQuery houseQuery)
        {
            EnsureArg.IsNotNull(houseQuery, nameof(houseQuery));
            _houseQuery = houseQuery;
        }

        public async Task<List<HouseDTO>> Handle(HouseParameter query)
        {
            return await _houseQuery.GetHouseData(query);   
        }
    }
}
