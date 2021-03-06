﻿using System.Collections.Generic;
using System.Linq;
using Cadmus.Core;
using Cadmus.Core.Layers;
using Fusi.Tools.Config;

namespace Cadmus.Philology.Parts.Layers
{
    /// <summary>
    /// Quotations layer fragment, used to mark one or more literary quotations
    /// corresponding to a specific portion of the text.
    /// <para>Tag: <c>fr.net.fusisoft.quotations</c>.</para>
    /// </summary>
    /// <seealso cref="ITextLayerFragment" />
    [Tag("fr.net.fusisoft.quotations")]
    public sealed class QuotationsLayerFragment : ITextLayerFragment
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
        /// Gets or sets the quotation entries.
        /// </summary>
        public List<QuotationEntry> Entries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotationsLayerFragment"/>
        /// class.
        /// </summary>
        public QuotationsLayerFragment()
        {
            Entries = new List<QuotationEntry>();
        }

        private static void AddSetToPins(HashSet<string> set, string name,
            List<DataPin> pins)
        {
            pins.AddRange(from s in set
                          select new DataPin
                          {
                              Name = name,
                              Value = s
                          });
        }

        /// <summary>
        /// Get all the pins exposed by the implementor.
        /// Pins: for each entry (avoiding duplicates): <c>fr.author</c>=author
        /// (filtered), <c>fr.work</c>=work (filtered), and optionally
        /// <c>fr.citation-uri</c>=citation URI and <c>fr.tag</c>=tag.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>Pins.</returns>
        public IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            List<DataPin> pins = new List<DataPin>();
            HashSet<string> authors = new HashSet<string>();
            HashSet<string> works = new HashSet<string>();
            HashSet<string> citations = new HashSet<string>();
            HashSet<string> tags = new HashSet<string>();
            string filtered;

            foreach (QuotationEntry entry in Entries)
            {
                if (!string.IsNullOrEmpty(entry.Author))
                {
                    filtered = StandardTextFilter.Apply(entry.Author);
                    if (filtered.Length > 0) authors.Add(filtered);
                }
                if (!string.IsNullOrEmpty(entry.Work))
                {
                    filtered = StandardTextFilter.Apply(entry.Work);
                    if (filtered.Length > 0) works.Add(filtered);
                }
                if (!string.IsNullOrEmpty(entry.CitationUri))
                    citations.Add(entry.CitationUri);
                if (!string.IsNullOrEmpty(entry.Tag))
                    tags.Add(entry.Tag);
            }

            // fr.author
            AddSetToPins(authors, PartBase.FR_PREFIX + "author", pins);

            // fr.work
            AddSetToPins(works, PartBase.FR_PREFIX + "work", pins);

            // fr.citation-uri
            AddSetToPins(citations, PartBase.FR_PREFIX + "citation-uri", pins);

            // fr.tag
            AddSetToPins(tags, PartBase.FR_PREFIX + "tag", pins);

            return pins;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"[Quotation] {Entries?.Count ?? 0}";
        }
    }
}
