using System.Linq;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Criterion;
using NHibernate.Mapping.ByCode;
using NHibernate.Test.Linq;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2477
{
	[TestFixture]
	public class Fixture : TestCaseMappingByCode
	{
		protected override HbmMapping GetMappings()
		{
			var mapper = new ConventionModelMapper();
			mapper.BeforeMapClass += (t, mi, map) => map.Id(idm => idm.Generator(Generators.Native));
			return mapper.CompileMappingFor(new[] {typeof(Entity)});
		}

		protected override void OnSetUp()
		{
			using (ISession session = OpenSession())
			{
				for (int i = 0; i < 5; i++)
				{
					session.Save(
						new Entity
						{
							Name = i.ToString()
						});
				}

				session.Flush();
			}
		}

		protected override void OnTearDown()
		{
			using (ISession session = OpenSession())
			{
				session.Delete($"from {nameof(Entity)}");
				session.Flush();
			}
		}

		[Test]
		public void WhenTakeBeforeCountShouldApplyTake()
		{
			using (ISession session = OpenSession())
			{
				var actual = session.Query<Entity>()
										.Take(3)
										.AsEnumerable()
										.Count();
				Assert.That(actual, Is.EqualTo(3));
			}
		}
	}
}
