﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Tuple.Entity;
using NUnit.Framework;

namespace NHibernate.Test.GhostProperty
{
	using System.Threading.Tasks;
	[TestFixture]
	public class GhostPropertyFixtureAsync : TestCase
	{
		private string log;

		protected override string MappingsAssembly
		{
			get { return "NHibernate.Test"; }
		}

		protected override string[] Mappings
		{
			get { return new[] { "GhostProperty.Mappings.hbm.xml" }; }
		}

		protected override void Configure(Cfg.Configuration configuration)
		{
			configuration.DataBaseIntegration(x=> x.LogFormattedSql = false);
		}

		protected override void OnSetUp()
		{
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				var wireTransfer = new WireTransfer
				{
					Id = 1
				};
				s.Persist(wireTransfer);
				var creditCard = new CreditCard
				{
					Id = 2
				};
				s.Persist(creditCard);
				s.Persist(new Order
				{
					Id = 1,
					Payment = wireTransfer
				});
				tx.Commit();
			}

		}

		protected override void OnTearDown()
		{
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				s.Delete("from Order");
				s.Delete("from Payment");
				tx.Commit();
			}
		}

		protected override DebugSessionFactory BuildSessionFactory()
		{
			using (var logSpy = new LogSpy(typeof(EntityMetamodel)))
			{
				var factory = base.BuildSessionFactory();
				log = logSpy.GetWholeLog();
				return factory;
			}
		}

		[Test]
		public async Task CanGetActualValueFromLazyManyToOneAsync()
		{
			using (ISession s = OpenSession())
			{
				var order = await (s.GetAsync<Order>(1));

				Assert.IsTrue(order.Payment is WireTransfer);
			}
		}

		[Test]
		public async Task CanGetInitializedLazyManyToOneAfterClosedSessionAsync()
		{
			Order order;
			Payment payment;

			using (var s = OpenSession())
			{
				order = await (s.GetAsync<Order>(1));
				payment = order.Payment; // Initialize Payment
			}

			Assert.That(order.Payment, Is.EqualTo(payment));
			Assert.That(order.Payment is WireTransfer, Is.True);
		}

		[Test]
		public async Task InitializedLazyManyToOneBeforeParentShouldNotBeAProxyAsync()
		{
			Order order;
			Payment payment;

			using (var s = OpenSession())
			{
				payment = await (s.LoadAsync<Payment>(1));
				await (NHibernateUtil.InitializeAsync(payment));
				order = await (s.GetAsync<Order>(1));
				// Here the Payment property should be unwrapped
				payment = order.Payment;
			}

			Assert.That(order.Payment, Is.EqualTo(payment));
			Assert.That(order.Payment is WireTransfer, Is.True);
		}

		[Test]
		public async Task SetUninitializedProxyShouldNotTriggerPropertyInitializationAsync()
		{
			using (var s = OpenSession())
			{
				var order = await (s.GetAsync<Order>(1));
				Assert.That(order.Payment is WireTransfer, Is.True); // Load property
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.True);
				order.Payment = await (s.LoadAsync<Payment>(2));
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.True);
				Assert.That(NHibernateUtil.IsInitialized(order.Payment), Is.False);
				Assert.That(order.Payment is WireTransfer, Is.False);
			}
		}

		[Test]
		public async Task SetInitializedProxyShouldNotResetPropertyInitializationAsync()
		{
			using (var s = OpenSession())
			{
				var order = await (s.GetAsync<Order>(1));
				var payment = await (s.LoadAsync<Payment>(2));
				Assert.That(order.Payment is WireTransfer, Is.True); // Load property
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.True);
				await (NHibernateUtil.InitializeAsync(payment));
				order.Payment = payment;
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.True);
			}
		}

		[Test]
		public async Task WillNotLoadGhostPropertyByDefaultAsync()
		{
			using (ISession s = OpenSession())
			{
				var order = await (s.GetAsync<Order>(1));
				Assert.IsFalse(NHibernateUtil.IsPropertyInitialized(order, "Payment"));
			}
		}

		[Test]
		public async Task GhostPropertyMaintainIdentityMapAsync()
		{
			using (ISession s = OpenSession())
			{
				var order = await (s.GetAsync<Order>(1));

				Assert.AreSame(order.Payment, await (s.LoadAsync<Payment>(1)));
			}
		}

		[Test, Ignore("This shows an expected edge case")]
		public async Task GhostPropertyMaintainIdentityMapUsingGetAsync()
		{
			using (ISession s = OpenSession())
			{
				var payment = await (s.LoadAsync<Payment>(1));
				var order = await (s.GetAsync<Order>(1));

				Assert.AreSame(order.Payment, payment);
			}
		}

		[Test]
		public async Task WillLoadGhostAssociationOnAccessAsync()
		{
			// NH-2498
			using (ISession s = OpenSession())
			{
				Order order;
				using (var ls = new SqlLogSpy())
				{
					order = await (s.GetAsync<Order>(1));
					var logMessage = ls.GetWholeLog();
					Assert.That(logMessage, Does.Not.Contain("FROM Payment"));
				}
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.False);

				// trigger on-access lazy load 
				var x = order.Payment;
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "Payment"), Is.True);
			}
		}

		[Test]
		public async Task WhenGetThenLoadOnlyNoLazyPlainPropertiesAsync()
		{
			using (ISession s = OpenSession())
			{
				Order order;
				using (var ls = new SqlLogSpy())
				{
					order = await (s.GetAsync<Order>(1));
					var logMessage = ls.GetWholeLog();
					Assert.That(logMessage, Does.Not.Contain("ALazyProperty"));
					Assert.That(logMessage, Does.Contain("NoLazyProperty"));
				}
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "NoLazyProperty"), Is.True);
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "ALazyProperty"), Is.False);

				using (var ls = new SqlLogSpy())
				{
					var x = order.ALazyProperty;
					var logMessage = ls.GetWholeLog();
					Assert.That(logMessage, Does.Contain("ALazyProperty"));
				}
				Assert.That(NHibernateUtil.IsPropertyInitialized(order, "ALazyProperty"), Is.True);
			}
		}

		[Test]
		public async Task AcceptPropertySetWithTransientObjectAsync()
		{
			Order order;
			using (var s = OpenSession())
			{
				order = await (s.GetAsync<Order>(1));
			}

			var newPayment = new WireTransfer();
			order.Payment = newPayment;

			Assert.That(order.Payment, Is.EqualTo(newPayment));
		}

		[Test]
		public async Task WillFetchJoinInSingleHqlQueryAsync()
		{
			Order order = null;

			using (ISession s = OpenSession())
			{
				order = (await (s.CreateQuery("from Order o left join fetch o.Payment where o.Id = 1").ListAsync<Order>()))[0];
			}

			Assert.DoesNotThrow(() => { var x = order.Payment; });
		}
	}
}
