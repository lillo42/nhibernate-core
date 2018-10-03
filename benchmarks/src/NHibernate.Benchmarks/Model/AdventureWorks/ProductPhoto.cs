// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductPhoto
    {
        public ProductPhoto()
        {
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
        }

        public virtual int ProductPhotoID { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
        public virtual byte[] LargePhoto { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public virtual string LargePhotoFileName { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
        public virtual byte[] ThumbNailPhoto { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public virtual string ThumbnailPhotoFileName { get; set; }

        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
    }
}
