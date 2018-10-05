using System;
using System.Linq;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.ToStringMoreThan100
{
	[TestFixture]
	public class Fixture : TestCaseMappingByCode
	{
		protected override HbmMapping GetMappings()
		{
			var mapper = new ModelMapper();
			mapper.Class<Entity>(rc =>
			{
				rc.Id(x => x.Id);
				rc.Property(x => x.Name);
			});
			return mapper.CompileMappingForAllExplicitlyAddedEntities();
		}

		private const string NAME = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean quis cursus nisl, non consectetur er";
		protected override void OnSetUp()
		{
			using (var session = OpenSession())
			{
				session.Save(new Entity { Id = Guid.NewGuid(), Name = NAME });
				session.Flush();
			}
		}


		protected override void OnTearDown()
		{
			using (var session = OpenSession())
			{
				using (var transaction = session.BeginTransaction())
				{
					session.Delete("from System.Object");
					session.Flush();
					transaction.Commit();
				}
			}
		}

		[Test]
		public void SelectString()
		{
			using (var session = OpenSession())
			{
				var list = session.Query<Entity>()
					.Select(x => new { Name = x.Name.ToString() })
					.ToList();
				Assert.AreEqual(NAME.ToUpper(), list[0].Name.ToUpper());
			}
		}
	}
}
