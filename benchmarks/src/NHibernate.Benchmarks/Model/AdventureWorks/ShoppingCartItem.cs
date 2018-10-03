// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ShoppingCartItem
    {
        public virtual int ShoppingCartItemID { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string ShoppingCartID { get; set; }

        public virtual Product Product { get; set; }
    }
}
