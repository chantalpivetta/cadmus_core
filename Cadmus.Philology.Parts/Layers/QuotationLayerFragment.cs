﻿using System.Collections.Generic;
using System.Linq;
using Cadmus.Core;
using Cadmus.Core.Layers;
using Fusi.Tools.Config;

namespace Cadmus.Philology.Parts.Layers
{
    /// <summary>
    /// Quotation layer fragment, used to mark literary quotations in the text.
    /// Tag: <c>fr.net.fusisoft.quotation</c>.
    /// </summary>
    /// <seealso cref="ITextLayerFragment" />
    [Tag("fr.net.fusisoft.quotation")]
    public sealed class QuotationLayerFragment : ITextLayerFragment
    {
        /// <summary>
        /// Gets or sets the location of this fragment.
        /// </summary>
        /// <remarks>
        /// The location can be expressed in different ways according to the
        /// text coordinates system being adopted. For instance, it might be a
        /// simple token-based coordinates system (e.g. 1.2=second token of
        /// first block), or a more complex system like an XPath expression.
        /// </remarks>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the author (e.g. <c>Hom.</c>).
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the work (e.g. <c>Il.</c>).
        /// </summary>
        public string Work { get; set; }

        /// <summary>
        /// Gets or sets the work's passage citation (e.g. <c>3.24</c>).
        /// </summary>
        public string Citation { get; set; }

        /// <summary>
        /// Gets or sets the original quotation text, when the text this layer
        /// fragment refers to  is a variant of it.
        /// </summary>
        public string VariantOf { get; set; }

        /// <summary>
        /// Gets or sets an optional note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Get all the pins exposed by the implementor.
        /// Pins: <c>fr.author</c>=author, <c>fr.work</c>=work, in this order.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>Pins.</returns>
        public IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            if (Author == null || Work == null)
                return Enumerable.Empty<DataPin>();

            return new[]
            {
                new DataPin
                {
                    Name = PartBase.FR_PREFIX + "author",
                    Value = Author
                },
                new DataPin
                {
                    Name = PartBase.FR_PREFIX + "work",
                    Value = Work
                }
            };
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"[Quotation] {Location} {Author} {Work} {Citation}".TrimEnd();
        }
    }
}
