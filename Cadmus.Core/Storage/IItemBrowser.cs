﻿using Fusi.Tools.Data;
using System.Threading.Tasks;

namespace Cadmus.Core.Storage
{
    /// <summary>
    /// A browser for items. An items browser provides a specialized paged view
    /// of the database items. It is a sort of little, specialized repository,
    /// as it has direct access to the underlying database. This allows it
    /// to take advantage of the database-specific features and aggregation
    /// capabilities, beyond the limits defined by the standardized functions
    /// provided by an <see cref="ICadmusRepository"/>.
    /// </summary>
    public interface IItemBrowser
    {
        /// <summary>
        /// Browses the items using the specified options.
        /// </summary>
        /// <param name="options">The paging and filtering options.</param>
        /// <returns>Page of items.</returns>
        Task<DataPage<ItemInfo>> BrowseAsync(IPagingOptions options);
    }
}
