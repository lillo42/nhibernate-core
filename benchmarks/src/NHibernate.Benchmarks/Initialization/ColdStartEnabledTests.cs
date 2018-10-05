using System;
using System.Linq;
using NHibernate.Benchmarks.Models.AdventureWorks;

namespace NHibernate.Benchmarks.Initialization
{
	public abstract class ColdStartEnabledTests : MarshalByRefObject
	{
		protected abstract ISession CreateSession();

		public void CreateAndDisposeUnusedContext(int count)
		{
			for (var i = 0; i < count; i++)
			{
				// ReSharper disable once UnusedVariable
				using (var session = CreateSession())
				{
				}
			}
		}

		public void InitializeAndQuery_AdventureWorks(int count)
		{
			for (var i = 0; i < count; i++)
			{
				using (var session = CreateSession())
				{
					// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
					session.Query<Department>().First();
				}
			}
		}

		public void InitializeAndSaveChanges_AdventureWorks(int count)
		{
			for (var i = 0; i < count; i++)
			{
				using (var session = CreateSession())
				{
					session.Save(
						new Currency
						{
							CurrencyCode = "TMP",
							Name = "Temporary"
						});

					using (session.BeginTransaction())
					{
						session.Flush();

						// TODO: Don't mesure transaction rollback
					}
				}
			}
		}
	}
}
