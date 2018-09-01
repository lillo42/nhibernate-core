using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.GH1079
{
	[TestFixture]
	public class Fixture : BugTestCase
	{
		protected override void OnSetUp()
		{
			base.OnSetUp();
			using (var session = OpenSession())
			{
				var order = new Order();
				order.OrderLines.Add(new OrderLine { LineNumber = 1 });
				order.OrderLines.Add(new OrderLine { LineNumber = 2 });
				session.Save(order);
				session.Flush();
			}
		}

		[Test]
		public void Test()
		{
			using (var session = OpenSession())
			{
				var criteria = session.CreateCriteria<Order>()
				                      .CreateAlias("OrderLines", "OL", JoinType.LeftOuterJoin, Restrictions.Eq("LineNumber", 1));

				var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

				Assert.AreEqual(1, criteria.List<Order>().Count, "Expected 1 order matching criteria.");
				Assert.AreEqual(1, countCriteria.UniqueResult<int>(), "Expected row count to be 1.");
			}
		}

		protected override void OnTearDown()
		{
			base.OnTearDown();
			using (var session = OpenSession())
			{
				session.Delete("from System.Object");
				session.Flush();
			}
		}
	}
}
