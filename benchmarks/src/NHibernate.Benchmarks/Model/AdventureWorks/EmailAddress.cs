// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class EmailAddress
    {
        public virtual int BusinessEntityID { get; set; }
        public virtual int EmailAddressID { get; set; }
        public virtual string EmailAddress1 { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public virtual Person BusinessEntity { get; set; }
    }
}
