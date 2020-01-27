﻿using System;

namespace Cadmus.Core.Config
{
    /// <summary>
    /// Definition of a part in an <see cref="FacetDefinition"/>.
    /// </summary>
    public class PartDefinition
    {
        /// <summary>
        /// Gets or sets the part's type identifier.
        /// </summary>
        public string TypeId { get; set; }

        /// <summary>
        /// Gets or sets the part's role identifier.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Human-readable name for part.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this part is required
        /// in the facet.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the color key, which can be used to visually mark
        /// parts when presenting them.
        /// </summary>
        /// <value>The color key, with format RRGGBB.</value>
        public string ColorKey { get; set; }

        /// <summary>
        /// Gets or sets the optional group key, which can be used to group
        /// parts when presenting them.
        /// </summary>
        public string GroupKey { get; set; }

        /// <summary>
        /// Gets or sets the sort key, which can be used to sort parts when
        /// presenting them.
        /// </summary>
        public string SortKey { get; set; }

        /// <summary>
        /// Gets or sets the editor key, which can be used to group parts
        /// according to the frontend editors organization. Whereas
        /// <see cref="GroupKey"/> is a purely presentational feature,
        /// <see cref="EditorKey"/> is related to how the frontend organizes
        /// its editing components in different modules. For instance,
        /// the same frontend module might include two parts whose definitions
        /// have different <see cref="GroupKey"/>'s, so that they get
        /// displayed in different groups, but their editors are found in the
        /// same component.
        /// This is a property used by frontend only, and has no usage in
        /// the database or in the backend.
        /// </summary>
        public string EditorKey { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Part: {Name}{(IsRequired ? "*" : "")}";
        }
    }
}
