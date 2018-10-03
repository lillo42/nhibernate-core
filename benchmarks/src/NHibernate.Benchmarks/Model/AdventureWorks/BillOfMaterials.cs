// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class BillOfMaterials
    {
        public virtual int BillOfMaterialsID { get; set; }
		public virtual short BOMLevel { get; set; }
		public virtual int ComponentID { get; set; }
		public virtual DateTime? EndDate { get; set; }
		public virtual DateTime ModifiedDate { get; set; }
		public virtual decimal PerAssemblyQty { get; set; }
		public virtual int? ProductAssemblyID { get; set; }
		public virtual DateTime StartDate { get; set; }
		public virtual string UnitMeasureCode { get; set; }

        public virtual Product Component { get; set; }
        public virtual Product ProductAssembly { get; set; }
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
