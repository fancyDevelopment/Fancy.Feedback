using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Fancy.Feedback.Core.Infrastructure
{
    public static class QueryableExtensions
    {
        public static PagedResultSet<TDto> CreateResultPage<TEntiy, TDto>(this IQueryable<TEntiy> events, int page, int pageSize)
        {
            IEnumerable<TEntiy> pagedEvents = events.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PagedResultSet<TDto> result = new PagedResultSet<TDto>
            {
                Items = Mapper.Map<IEnumerable<TDto>>(pagedEvents),
                TotalItems = events.Count(),
                Page = page,
                PageSize = pageSize
            };

            return result;
        }
    }
}