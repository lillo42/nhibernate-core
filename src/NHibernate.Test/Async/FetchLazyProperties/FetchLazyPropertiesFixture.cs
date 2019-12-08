﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Linq;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Linq;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;

namespace NHibernate.Test.FetchLazyProperties
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FetchLazyPropertiesFixtureAsync : TestCase
	{
		protected override string MappingsAssembly
		{
			get { return "NHibernate.Test"; }
		}

		protected override string[] Mappings
		{
			get { return new[] { "FetchLazyProperties.Mappings.hbm.xml" }; }
		}

		protected override bool AppliesTo(Dialect.Dialect dialect)
		{
			return dialect.SupportsTemporaryTables;
		}

		protected override void Configure(Configuration configuration)
		{
			base.Configure(configuration);
			configuration.Properties[Environment.CacheProvider] = typeof(HashtableCacheProvider).AssemblyQualifiedName;
			configuration.Properties[Environment.UseSecondLevelCache] = "true";
		}

		protected override void OnSetUp()
		{
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				var currAnimalId = 1;
				Person lastPerson = null;
				for (var i = 2; i > 0; i--)
				{
					var person = lastPerson =  GeneratePerson(i, lastPerson);
					person.Pets.Add(GenerateCat(currAnimalId++, person));
					person.Pets.Add(GenerateDog(currAnimalId++, person));
					s.Save(person);
				}

				tx.Commit();
			}
		}

		protected override void OnTearDown()
		{
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				s.CreateQuery("delete from Animal").ExecuteUpdate();
				s.CreateQuery("update Person set BestFriend = null").ExecuteUpdate();
				s.CreateQuery("delete from Person").ExecuteUpdate();
				s.CreateQuery("delete from Continent").ExecuteUpdate();
				tx.Commit();
			}
		}

		#region FetchComponent

		[Test]
		public async Task TestHqlFetchComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person fetch Address where Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchComponent(person);
		}

		[Test]
		public async Task TestLinqFetchComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().Fetch(o => o.Address).FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchComponent(person);
		}

		private static void AssertFetchComponent(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(person.Address.City, Is.EqualTo("City1"));
			Assert.That(person.Address.Country, Is.EqualTo("Country1"));
		}

		#endregion

		#region FetchFormula

		[Test]
		public async Task TestHqlFetchFormulaAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person fetch Formula where Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchFormula(person);
		}

		[Test]
		public async Task TestLinqFetchFormulaAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().Fetch(o => o.Formula).FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchFormula(person);
		}

		private static void AssertFetchFormula(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(person.Formula, Is.EqualTo(1));
		}

		#endregion

		#region FetchProperty

		[Test]
		public async Task TestHqlFetchPropertyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person fetch Image where Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchProperty(person);
		}

		[Test]
		public async Task TestLinqFetchPropertyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().Fetch(o => o.Image).FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchProperty(person);
		}

		private static void AssertFetchProperty(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(person.Image, Has.Length.EqualTo(1));
		}

		#endregion

		#region FetchComponentAndFormulaTwoQueryReadOnly

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestHqlFetchComponentAndFormulaTwoQueryReadOnlyAsync(bool readOnly)
		{
			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.CreateQuery("from Person fetch Address where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());
				person = await (s.CreateQuery("from Person fetch Formula where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());

				await (tx.CommitAsync());
			}

			AssertFetchComponentAndFormulaTwoQuery(person);
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestLinqFetchComponentAndFormulaTwoQueryAsync(bool readOnly)
		{
			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.Query<Person>().Fetch(o => o.Address).WithOptions(o => o.SetReadOnly(readOnly)).FirstOrDefaultAsync(o => o.Id == 1));
				person = await (s.Query<Person>().Fetch(o => o.Formula).WithOptions(o => o.SetReadOnly(readOnly)).FirstOrDefaultAsync(o => o.Id == 1));

				await (tx.CommitAsync());
			}

			AssertFetchComponentAndFormulaTwoQuery(person);
		}

		private static void AssertFetchComponentAndFormulaTwoQuery(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(person.Address.City, Is.EqualTo("City1"));
			Assert.That(person.Address.Country, Is.EqualTo("Country1"));
			Assert.That(person.Formula, Is.EqualTo(1));
		}

		#endregion

		#region FetchAllProperties

		[Test]
		public async Task TestHqlFetchAllPropertiesAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person fetch all properties where Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchAllProperties(person);
		}

		[Test]
		public async Task TestLinqFetchAllPropertiesAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().FetchLazyProperties().FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchAllProperties(person);
		}

		private static void AssertFetchAllProperties(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(person.Image, Has.Length.EqualTo(1));
			Assert.That(person.Address.City, Is.EqualTo("City1"));
			Assert.That(person.Address.Country, Is.EqualTo("Country1"));
			Assert.That(person.Formula, Is.EqualTo(1));
		}

		#endregion

		#region FetchAllPropertiesIndividually

		[Test]
		public async Task TestHqlFetchAllPropertiesIndividuallyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person fetch Image fetch Address fetch Formula fetch Image where Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchAllProperties(person);
		}

		[Test]
		public async Task TestLinqFetchAllPropertiesIndividuallyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().Fetch(o => o.Image).Fetch(o => o.Address).Fetch(o => o.Formula).FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchAllProperties(person);
		}

		#endregion

		#region FetchFormulaAndManyToOneComponent

		[Test]
		public async Task TestHqlFetchFormulaAndManyToOneComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person p fetch p.Formula left join fetch p.BestFriend bf fetch bf.Address where p.Id = 1")
				          .UniqueResultAsync<Person>());
			}

			AssertFetchFormulaAndManyToOneComponent(person);
		}

		[Test]
		public async Task TestLinqFetchFormulaAndManyToOneComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>()
				          .Fetch(o => o.Formula)
				          .Fetch(o => o.BestFriend).ThenFetch(o => o.Address)
				          .FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchFormulaAndManyToOneComponent(person);
		}

		private static void AssertFetchFormulaAndManyToOneComponent(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(NHibernateUtil.IsInitialized(person.BestFriend), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Formula"), Is.False);

			Assert.That(person.Formula, Is.EqualTo(1));
			Assert.That(person.BestFriend.Address.City, Is.EqualTo("City2"));
			Assert.That(person.BestFriend.Address.Country, Is.EqualTo("Country2"));
		}

		#endregion

		#region FetchFormulaAndManyToOneComponentList

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestHqlFetchFormulaAndManyToOneComponentListAsync(bool descending)
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.CreateQuery("from Person p fetch p.Formula left join fetch p.BestFriend bf fetch bf.Address order by p.Id" + (descending ? " desc" : ""))
							.ListAsync<Person>())).FirstOrDefault(o => o.Id == 1);
			}

			AssertFetchFormulaAndManyToOneComponentList(person);
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestLinqFetchFormulaAndManyToOneComponentListAsync(bool descending)
		{
			Person person;
			using (var s = OpenSession())
			{
				IQueryable<Person> query = s.Query<Person>()
							.Fetch(o => o.Formula)
							.Fetch(o => o.BestFriend).ThenFetch(o => o.Address);
				query = descending ? query.OrderByDescending(o => o.Id) : query.OrderBy(o => o.Id);
				person = (await (query
						.ToListAsync()))
						.FirstOrDefault(o => o.Id == 1);
			}

			AssertFetchFormulaAndManyToOneComponentList(person);
		}

		private static void AssertFetchFormulaAndManyToOneComponentList(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(NHibernateUtil.IsInitialized(person.BestFriend), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Formula"), Is.True);

			Assert.That(person.Formula, Is.EqualTo(1));
			Assert.That(person.BestFriend.Address.City, Is.EqualTo("City2"));
			Assert.That(person.BestFriend.Address.Country, Is.EqualTo("Country2"));
		}

		#endregion

		#region FetchManyToOneAllProperties

		[Test]
		public async Task TestHqlFetchManyToOneAllPropertiesAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.CreateQuery("from Person p left join fetch p.BestFriend fetch all properties")
							.ListAsync<Person>())).FirstOrDefault(o => o.Id == 1);
			}

			AssertFetchManyToOneAllProperties(person);
		}

		[Test]
		public async Task TestLinqFetchManyToOneAllPropertiesAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.Query<Person>()
							.Fetch(o => o.BestFriend).FetchLazyProperties()
							.ToListAsync()))
							.FirstOrDefault(o => o.Id == 1);
			}

			AssertFetchManyToOneAllProperties(person);
		}

		private static void AssertFetchManyToOneAllProperties(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(NHibernateUtil.IsInitialized(person.BestFriend), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person.BestFriend, "Formula"), Is.True);

			Assert.That(person.BestFriend.Formula, Is.EqualTo(2));
			Assert.That(person.BestFriend.Address.City, Is.EqualTo("City2"));
			Assert.That(person.BestFriend.Address.Country, Is.EqualTo("Country2"));
			Assert.That(person.BestFriend.Image, Has.Length.EqualTo(2));
		}

		#endregion

		#region FetchFormulaAndOneToManyComponent

		[Test]
		public async Task TestHqlFetchFormulaAndOneToManyComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.CreateQuery("from Person p fetch p.Formula left join fetch p.Dogs dog fetch dog.Address where p.Id = 1")
							.ListAsync<Person>()))
							.FirstOrDefault();
			}

			AssertFetchFormulaAndOneToManyComponent(person);
		}

		[Test]
		public async Task TestLinqFetchFormulaAndOneToManyComponentAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.Query<Person>()
							.Fetch(o => o.Formula)
							.FetchMany(o => o.Dogs).ThenFetch(o => o.Address)
							.Where(o => o.Id == 1)
							.ToListAsync()))
							.FirstOrDefault();
			}

			AssertFetchFormulaAndOneToManyComponent(person);
		}

		private static void AssertFetchFormulaAndOneToManyComponent(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);

			Assert.That(NHibernateUtil.IsInitialized(person.Dogs), Is.True);
			Assert.That(NHibernateUtil.IsInitialized(person.BestFriend), Is.False);
			Assert.That(NHibernateUtil.IsInitialized(person.Pets), Is.False);

			Assert.That(person.Formula, Is.EqualTo(1));
			Assert.That(person.Dogs, Has.Count.EqualTo(1));
			foreach (var dog in person.Dogs)
			{
				Assert.That(NHibernateUtil.IsPropertyInitialized(dog, "Image"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(dog, "Formula"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(dog, "Address"), Is.True);

				Assert.That(dog.Address.City, Is.EqualTo("City1"));
				Assert.That(dog.Address.Country, Is.EqualTo("Country1"));
			}
		}

		#endregion

		#region FetchOneToManyProperty

		[Test]
		public async Task TestHqlFetchOneToManyPropertyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.CreateQuery("from Person p left join fetch p.Cats cat fetch cat.SecondImage where p.Id = 1")
						.ListAsync<Person>()))
						.FirstOrDefault();
			}

			AssertFetchOneToManyProperty(person);
		}

		[Test]
		public async Task TestLinqFetchOneToManyPropertyAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = (await (s.Query<Person>()
						.FetchMany(o => o.Cats).ThenFetch(o => o.SecondImage)
						.Where(o => o.Id == 1)
						.ToListAsync()))
						.FirstOrDefault();
			}

			AssertFetchOneToManyProperty(person);
		}

		private static void AssertFetchOneToManyProperty(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(NHibernateUtil.IsInitialized(person.BestFriend), Is.False);
			Assert.That(NHibernateUtil.IsInitialized(person.Pets), Is.False);
			Assert.That(NHibernateUtil.IsInitialized(person.Cats), Is.True);

			Assert.That(person.Cats, Has.Count.EqualTo(1));
			foreach (var cat in person.Cats)
			{
				Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Image"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Formula"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Address"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondImage"), Is.True);
				Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondFormula"), Is.False);

				Assert.That(cat.SecondImage, Has.Length.EqualTo(6));
			}
		}

		#endregion

		#region FetchNotMappedProperty

		[Test]
		public void TestHqlFetchNotMappedPropertyAsync()
		{
			using (var s = OpenSession())
			{
				Assert.ThrowsAsync<InvalidOperationException>(
					async () =>
					{
						var person = await (s.CreateQuery("from Person p fetch p.BirthYear where p.Id = 1").UniqueResultAsync<Person>());
					});
			}
		}

		[Test]
		public void TestLinqFetchNotMappedPropertyAsync()
		{
			using (var s = OpenSession())
			{
				Assert.ThrowsAsync<QueryException>(
					async () =>
					{
						var person = await (s.Query<Person>().Fetch(o => o.BirthYear).FirstOrDefaultAsync(o => o.Id == 1));
					});
			}
		}

		#endregion

		#region FetchComponentManyToOne

		[Test]
		public async Task TestHqlFetchComponentManyToOneAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person p fetch p.Address left join fetch p.Address.Continent where p.Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchComponentManyToOne(person);
		}

		[Test]
		public async Task TestLinqFetchComponentManyToOneAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.Query<Person>().Fetch(o => o.Address).ThenFetch(o => o.Continent).FirstOrDefaultAsync(o => o.Id == 1));
			}

			AssertFetchComponentManyToOne(person);
		}

		private static void AssertFetchComponentManyToOne(Person person)
		{
			Assert.That(person, Is.Not.Null);

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(NHibernateUtil.IsInitialized(person.Address.Continent), Is.True);

			Assert.That(person.Address.City, Is.EqualTo("City1"));
			Assert.That(person.Address.Country, Is.EqualTo("Country1"));
			Assert.That(person.Address.Continent.Name, Is.EqualTo("Continent1"));
		}

		#endregion

		#region FetchSubClassFormula

		[Test]
		public async Task TestHqlFetchSubClassFormulaAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.CreateQuery("from Animal a fetch a.SecondFormula where a.Id = 1").UniqueResultAsync<Animal>());
			}

			AssertFetchSubClassFormula(animal);
		}

		[Test]
		public async Task TestLinqFetchSubClassFormulaAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.Query<Animal>().Fetch(o => ((Cat) o).SecondFormula).FirstAsync(o => o.Id == 1));
			}

			AssertFetchSubClassFormula(animal);
		}

		private static void AssertFetchSubClassFormula(Animal animal)
		{
			Assert.That(animal, Is.AssignableTo(typeof(Cat)));
			var cat = (Cat) animal;
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondFormula"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondImage"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Formula"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Image"), Is.False);
		}

		#endregion

		#region FetchSubClassProperty

		[Test]
		public async Task TestHqlFetchSubClassPropertyAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.CreateQuery("from Animal a fetch a.SecondImage where a.Id = 1").UniqueResultAsync<Animal>());
			}

			AssertFetchSubClassProperty(animal);
		}

		[Test]
		public async Task TestLinqFetchSubClassPropertyAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.Query<Animal>().Fetch(o => ((Cat) o).SecondImage).FirstAsync(o => o.Id == 1));
			}

			AssertFetchSubClassProperty(animal);
		}

		private static void AssertFetchSubClassProperty(Animal animal)
		{
			Assert.That(animal, Is.AssignableTo(typeof(Cat)));
			var cat = (Cat) animal;
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondFormula"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondImage"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Formula"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Image"), Is.False);
		}

		#endregion

		#region FetchSubClassAllProperty

		[Test]
		public async Task TestHqlFetchSubClassAllPropertiesAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.CreateQuery("from Animal a fetch all properties where a.Id = 1").UniqueResultAsync<Animal>());
			}

			AssertFetchSubClassAllProperties(animal);
		}

		[Test]
		public async Task TestLinqFetchSubClassAllPropertiesAsync()
		{
			Animal animal;
			using (var s = OpenSession())
			{
				animal = await (s.Query<Animal>().FetchLazyProperties().FirstAsync(o => o.Id == 1));
			}

			AssertFetchSubClassAllProperties(animal);
		}

		private static void AssertFetchSubClassAllProperties(Animal animal)
		{
			Assert.That(animal, Is.AssignableTo(typeof(Cat)));
			var cat = (Cat) animal;
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondFormula"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "SecondImage"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Formula"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(cat, "Image"), Is.True);
		}

		#endregion

		#region FetchAllPropertiesWithFetchProperty

		[Test]
		public void TestHqlFetchAllPropertiesWithFetchPropertyAsync()
		{
			using (var s = OpenSession())
			{
				Assert.ThrowsAsync<QuerySyntaxException>(
					async () =>
					{
						var person = await (s.CreateQuery("from Person p fetch p.Address fetch all properties where p.Id = 1").UniqueResultAsync<Person>());
					});
				Assert.ThrowsAsync<QuerySyntaxException>(
					async () =>
					{
						var person = await (s.CreateQuery("from Person p fetch all properties fetch p.Address where p.Id = 1").UniqueResultAsync<Person>());
					});
			}
		}

		[Test]
		public void TestLinqFetchAllPropertiesWithFetchPropertyAsync()
		{
			using (var s = OpenSession())
			{
				Assert.ThrowsAsync<InvalidCastException>(
					async () =>
					{
						var person = await (s.Query<Person>().Fetch(o => o.Address).FetchLazyProperties().FirstOrDefaultAsync(o => o.Id == 1));
					});
				Assert.ThrowsAsync<QuerySyntaxException>(
					async () =>
					{
						var person = await (s.Query<Person>().FetchLazyProperties().Fetch(o => o.Address).FirstOrDefaultAsync(o => o.Id == 1));
					});
			}
		}

		#endregion

		[Test]
		public async Task TestHqlFetchComponentAliasAsync()
		{
			Person person;
			using (var s = OpenSession())
			{
				person = await (s.CreateQuery("from Person p fetch p.Address where p.Id = 1").UniqueResultAsync<Person>());
			}

			AssertFetchComponent(person);
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestFetchComponentAndFormulaTwoQueryCacheAsync(bool readOnly)
		{
			await (TestLinqFetchComponentAndFormulaTwoQueryAsync(readOnly));

			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.GetAsync<Person>(1));

				await (tx.CommitAsync());
			}

			AssertFetchComponentAndFormulaTwoQuery(person);
		}

		[Test]
		public async Task TestFetchComponentCacheAsync()
		{
			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.Query<Person>().Fetch(o => o.Address).FirstOrDefaultAsync(o => o.Id == 1));
				AssertFetchComponent(person);
				await (tx.CommitAsync());
			}

			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.GetAsync<Person>(1));
				AssertFetchComponent(person);
				// Will reset the cache item
				person.Name = "Test";

				await (tx.CommitAsync());
			}

			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.GetAsync<Person>(1));
				Assert.That(person, Is.Not.Null);

				Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
				Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

				await (tx.CommitAsync());
			}
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestFetchAfterPropertyIsInitializedAsync(bool readOnly)
		{
			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.CreateQuery("from Person fetch Address where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());
				person.Image = new byte[10];
				person = await (s.CreateQuery("from Person fetch Image where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());

				await (tx.CommitAsync());
			}

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);

			Assert.That(person.Image, Has.Length.EqualTo(10));

			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.CreateQuery("from Person where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());
				person.Image = new byte[1];

				await (tx.CommitAsync());
			}

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.False);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.False);
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task TestFetchAfterEntityIsInitializedAsync(bool readOnly)
		{
			Person person;
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				person = await (s.CreateQuery("from Person where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());
				var image = person.Image;
				person = await (s.CreateQuery("from Person fetch Image where Id = 1").SetReadOnly(readOnly).UniqueResultAsync<Person>());

				await (tx.CommitAsync());
			}

			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Image"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Address"), Is.True);
			Assert.That(NHibernateUtil.IsPropertyInitialized(person, "Formula"), Is.True);
		}

		private static Person GeneratePerson(int i, Person bestFriend)
		{
			return new Person
			{
				Id = i,
				Name = $"Person{i}",
				Address = new Address
				{
					City = $"City{i}",
					Country = $"Country{i}",
					Continent = GenerateContinent(i)
				},
				Image = new byte[i],
				BestFriend = bestFriend
			};
		}

		private static Continent GenerateContinent(int i)
		{
			return new Continent
			{
				Id = i,
				Name = $"Continent{i}"
			};
		}

		private static Cat GenerateCat(int i, Person owner)
		{
			return new Cat
			{
				Id = i,
				Address = new Address
				{
					City = owner.Address.City,
					Country = owner.Address.Country
				},
				Image = new byte[i],
				Name = $"Cat{i}",
				SecondImage = new byte[i * 2],
				Owner = owner
			};
		}

		private static Dog GenerateDog(int i, Person owner)
		{
			return new Dog
			{
				Id = i,
				Address = new Address
				{
					City = owner.Address.City,
					Country = owner.Address.Country
				},
				Image = new byte[i * 3],
				Name = $"Dog{i}",
				Owner = owner
			};
		}
	}
}
