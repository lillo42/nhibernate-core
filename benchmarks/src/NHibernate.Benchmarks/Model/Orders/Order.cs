// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.Orders
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string SpecialRequests { get; set; }
        public virtual decimal OrderDiscount { get; set; }
        public virtual string DiscountReason { get; set; }
        public virtual decimal Tax { get; set; }

        public virtual string Addressee { get; set; }
        public virtual string AddressLineOne { get; set; }
        public virtual string AddressLineTwo { get; set; }
        public virtual string City { get; set; }
        public virtual string StateOrProvince { get; set; }
        public virtual string ZipOrPostalCode { get; set; }
        public virtual string Country { get; set; }

        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
