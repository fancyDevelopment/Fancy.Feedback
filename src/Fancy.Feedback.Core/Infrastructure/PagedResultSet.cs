using System.Collections.Generic;
using AutoMapper;

namespace Fancy.Feedback.Core.Infrastructure
{
    public class PagedResultSet<TDto>
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total items count.
        /// </summary>
        /// <value>
        /// The total items.
        /// </value>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<TDto> Items { get; set; }

        /// <summary>
        /// Converts the items in this paged result to a different type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <returns>A paged result with a different target.</returns>
        /// <remarks>This method works only if a valid automapper mapping profile is registred mapping from <typeparamref name="TDto" /> to <typeparamref name="TTarget"/></remarks>
        public PagedResultSet<TTarget> ConvertTo<TTarget>()
        {
            PagedResultSet<TTarget> result = new PagedResultSet<TTarget>();

            result.Page = Page;
            result.PageSize = PageSize;
            result.TotalItems = TotalItems;
            result.Items = Mapper.Map<IEnumerable<TTarget>>(Items);

            return result;
        } 
    }
}