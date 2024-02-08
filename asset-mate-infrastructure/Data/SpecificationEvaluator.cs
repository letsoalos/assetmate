using asset_mate_core.Entities;
using asset_mate_core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        ///  The initial query (inputQuery) is assigned to the query variable.
        ///  If there are criteria defined in the specification (spec.Criteria is not null), the criteria are applied to the query using the Where method.
        ///  The includes specified in the specification (spec.Includes) are applied to the query using the Include method.
        /// </summary>
        /// <param name="inputQuery">The initial query to be modified</param>
        /// <param name="spec"> An instance of ISpecification<TEntity> that encapsulates criteria and includes.</param>
        /// <returns></returns>/
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}