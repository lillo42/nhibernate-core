// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SpecialOffer
    {
        public SpecialOffer()
        {
            SpecialOfferProduct = new HashSet<SpecialOfferProduct>();
        }

        public virtual int SpecialOfferID { get; set; }
        public virtual string Category { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal DiscountPct { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int? MaxQty { get; set; }
        public virtual int MinQty { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual DateTime StartDate { get; set; }
        public virtual string Type { get; set; }

        public virtual ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }
    }
}
