using ExamService.Domain.Seed;
using ExamService.Infrastructure.Seed.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Seed
{
    public static class ProjectionsExtensionMethods
    {
        public static TProjection ProjectedAs<TProjection>(this Entity item)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> ProjectedAs<TProjection>(this IEnumerable<Entity> items)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}
