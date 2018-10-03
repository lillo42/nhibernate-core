// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class BusinessEntityAddress
    {
		public virtual int BusinessEntityID { get; set; }
		public virtual int AddressID { get; set; }
		public virtual int AddressTypeID { get; set; }
		public virtual DateTime ModifiedDate { get; set; }
#pragma warning disable IDE1006 // Naming Styles
		public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
