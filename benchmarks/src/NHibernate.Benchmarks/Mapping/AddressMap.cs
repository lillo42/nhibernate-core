using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Benchmarks.Models.AdventureWorks;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Benchmarks.Mapping
{
	public class AddressMap : ClassMapping<Address>
	{
		public AddressMap()
		{
			Schema("Person");
			Table("Address");


			Property(x => x.AddressLine1, map => map.NotNullable(true));
			/*
			 *   entity.ToTable("Address", "Person");

                        entity.Property(e => e.AddressLine1).IsRequired();

                        entity.Property(e => e.City).IsRequired();

                        entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                        entity.Property(e => e.PostalCode).IsRequired();

                        entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");

                        entity.HasOne(d => d.StateProvince)
                            .WithMany(p => p.Address)
                            .HasForeignKey(d => d.StateProvinceID);
			 */
		}
	}
}
