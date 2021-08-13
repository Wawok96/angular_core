using EnsureThat;
using Insig.ApplicationServices.Boundaries;
using Insig.Infrastructure.QueryBuilder;
using Insig.PublishedLanguage.Dtos;
using Insig.PublishedLanguage.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.Infrastructure.Queries
{
    public class HouseQuery : IHouseQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public HouseQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            EnsureArg.IsNotNull(sqlQueryBuilder, nameof(sqlQueryBuilder));

            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<HouseDTO>> GetHouseData(HouseParameter query)
        {
            return await _sqlQueryBuilder
                .Select("*")
                .From("House")
                .BuildQuery<HouseDTO>()
                .ExecuteToList();
        }
    }
}
