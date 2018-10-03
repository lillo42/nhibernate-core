// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductReview
    {
        public virtual int ProductReviewID { get; set; }
        public virtual string Comments { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int Rating { get; set; }
        public virtual DateTime ReviewDate { get; set; }
        public virtual string ReviewerName { get; set; }

        public virtual Product Product { get; set; }
    }
}
