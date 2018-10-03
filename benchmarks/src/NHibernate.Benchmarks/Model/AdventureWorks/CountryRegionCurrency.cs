// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class CountryRegionCurrency
    {
		public virtual string CountryRegionCode { get; set; }
		public virtual string CurrencyCode { get; set; }
		public virtual DateTime ModifiedDate { get; set; }

        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
