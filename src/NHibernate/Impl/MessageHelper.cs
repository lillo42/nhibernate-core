using System;
using System.Text;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Persister.Entity;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Impl
{
	/// <summary>
	/// Helper methods for rendering log messages and exception messages
	/// </summary>
	public static class MessageHelper
	{
		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="clazz">The <see cref="System.Type"/> to create the string from.</param>
		/// <param name="id">The identifier of the object.</param>
		/// <returns>A descriptive <see cref="String" /> in the format of <c>[classname#id]</c></returns>
		public static string InfoString(System.Type clazz, object id)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (clazz == null)
			{
				s.Builder.Append("<null Class>");
			}
			else
			{
				s.Builder.Append(clazz.Name);
			}
			s.Builder.Append('#');

			if (id == null)
			{
				s.Builder.Append("<null>");
			}
			else
			{
				s.Builder.Append(id);
			}
			s.Builder.Append(']');

			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="IEntityPersister" /> for the class in question.</param>
		/// <param name="id">The identifier of the object.</param>
		/// <param name="factory">The <see cref="ISessionFactory" />.</param>
		/// <returns>A descriptive <see cref="String" /> in the format of <c>[classname#id]</c></returns>
		public static string InfoString(IEntityPersister persister, object id, ISessionFactoryImplementor factory)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (persister == null)
			{
				s.Builder.Append("<null Class>");
			}
			else
			{
				s.Builder.Append(persister.EntityName);
			}
			s.Builder.Append('#');

			if (id == null)
			{
				s.Builder.Append("<null>");
			}
			else
			{
				s.Builder.Append(id);
			}
			s.Builder.Append(']');

			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="IEntityPersister" /> for the class in question.</param>
		/// <param name="id">The identifier of the object.</param>
		/// <param name="factory">The <see cref="ISessionFactory" />.</param>
		/// <param name="identifierType">The NHibernate type of the identifier.</param>
		/// <returns>A descriptive <see cref="String" /> in the format of <c>[classname#id]</c></returns>
		public static string InfoString(IEntityPersister persister, object id, IType identifierType,
										ISessionFactoryImplementor factory)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (persister == null)
			{
				s.Builder.Append("<null Class>");
			}
			else
			{
				s.Builder.Append(persister.EntityName);
			}
			s.Builder.Append('#');

			if (id == null)
			{
				s.Builder.Append("<null>");
			}
			else
			{
				s.Builder.Append(identifierType.ToLoggableString(id, factory));
			}
			s.Builder.Append(']');

			return s.ToStringAndFree();
		}

		public static string InfoString(
			IEntityPersister persister,
			object[] ids,
			ISessionFactoryImplementor factory)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');

			if (persister == null)
			{
				s.Builder.Append("<null IEntityPersister>");
			}
			else
			{
				s.Builder.Append(persister.EntityName)
					.Append("#<");

				for (int i = 0; i < ids.Length; i++)
				{
					s.Builder.Append(persister.IdentifierType.ToLoggableString(ids[i], factory));
					if (i < ids.Length - 1)
					{
						s.Builder.Append(StringHelper.CommaSpace);
					}
					s.Builder.Append('>');
				}
			}

			s.Builder.Append(']');
			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="IEntityPersister"/> for the class in question</param>
		/// <param name="id">The id</param>
		/// <returns>A descriptive <see cref="String" /> in the form <c>[FooBar#id]</c></returns>
		public static string InfoString(IEntityPersister persister, object id)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (persister == null)
			{
				s.Builder.Append("<null ClassPersister>");
			}
			else
			{
				s.Builder.Append(persister.EntityName);
			}
			s.Builder.Append('#');

			if (id == null)
			{
				s.Builder.Append("<null>");
			}
			else
			{
				s.Builder.Append(id);
			}

			s.Builder.Append(']');
			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="IEntityPersister"/> for the class in question</param>
		/// <returns>A descriptive <see cref="String" /> in the form <c>[FooBar]</c></returns>
		public static String InfoString(IEntityPersister persister)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (persister == null)
			{
				s.Builder.Append("<null ClassPersister>");
			}
			else
			{
				s.Builder.Append(persister.EntityName);
			}
			s.Builder.Append(']');
			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="ICollectionPersister"/> for the class in question</param>
		/// <param name="id">The id</param>
		/// <returns>A descriptive <see cref="String" /> in the form <c>[collectionrole#id]</c></returns>
		public static String InfoString(ICollectionPersister persister, object id)
		{
			return CollectionInfoString(persister, id);
		}

		/// <summary>
		/// Generate small message that can be used in traces and exception messages.
		/// </summary>
		/// <param name="persister">The <see cref="ICollectionPersister"/> for the class in question</param>
		/// <param name="id">The id</param>
		/// <returns>A descriptive <see cref="String" /> in the form <c>[collectionrole#id]</c></returns>
		internal static string CollectionInfoString(ICollectionPersister persister, object id)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append('[');
			if (persister == null)
			{
				s.Builder.Append("<unreferenced>");
			}
			else
			{
				s.Builder.Append(persister.Role);
				s.Builder.Append('#');

				if (id == null)
				{
					s.Builder.Append("<null>");
				}
				else
				{
					s.Builder.Append(id);
				}
			}
			s.Builder.Append(']');

			return s.ToStringAndFree();
		}

		/// <summary> 
		/// Generate an info message string relating to a given property value
		/// for an entity. 
		/// </summary>
		/// <param name="entityName">The entity name </param>
		/// <param name="propertyName">The name of the property </param>
		/// <param name="key">The property value. </param>
		/// <returns> An info string, in the form [Foo.bars#1] </returns>
		public static string InfoString(string entityName, string propertyName, object key)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder
				.Append('[')
				.Append(entityName)
				.Append('.')
				.Append(propertyName)
				.Append('#')
				.Append((key ?? "<null>"))
				.Append(']');

			return s.ToStringAndFree();
		}

		/// <summary>
		/// Generate an info message string relating to a particular managed
		/// collection.  Attempts to intelligently handle property-refs issues
		/// where the collection key is not the same as the owner key.
		/// </summary>
		/// <param name="persister">The persister for the collection</param>
		/// <param name="collection">The collection itself</param>
		/// <param name="collectionKey">The collection key</param>
		/// <param name="session">The session</param>
		/// <returns>An info string, in the form [Foo.bars#1]</returns>
		internal static String CollectionInfoString(ICollectionPersister persister, IPersistentCollection collection, object collectionKey, ISessionImplementor session)
		{

			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append("[");
			if (persister == null)
			{
				s.Builder.Append("<unreferenced>");
			}
			else
			{
				s.Builder.Append(persister.Role);
				s.Builder.Append("#");

				IType ownerIdentifierType = persister.OwnerEntityPersister.IdentifierType;
				object ownerKey;
				// TODO: Is it redundant to attempt to use the collectionKey,
				// or is always using the owner id sufficient?
				if (ownerIdentifierType.ReturnedClass.IsInstanceOfType(collectionKey))
				{
					ownerKey = collectionKey;
				}
				else
				{
					ownerKey = session.PersistenceContext.GetEntry(collection.Owner).Id;
				}
				s.Builder.Append(ownerIdentifierType.ToLoggableString(ownerKey, session.Factory));
			}
			s.Builder.Append("]");

			return s.ToStringAndFree();
		}

		/// <summary> 
		/// Generate an info message string relating to a particular managed
		/// collection.
		/// </summary>
		/// <param name="persister">The persister for the collection </param>
		/// <param name="id">The id value of the owner </param>
		/// <param name="factory">The session factory </param>
		/// <returns> An info string, in the form [Foo.bars#1] </returns>
		public static string InfoString(ICollectionPersister persister, object id, ISessionFactoryImplementor factory)
		{
			return CollectionInfoString(persister, id, factory);
		}

		/// <summary> 
		/// Generate an info message string relating to a particular managed collection.
		/// </summary>
		/// <param name="persister">The persister for the collection </param>
		/// <param name="id">The id value of the owner </param>
		/// <param name="factory">The session factory </param>
		/// <returns> An info string, in the form [Foo.bars#1] </returns>
		internal static string CollectionInfoString(ICollectionPersister persister, object id, ISessionFactoryImplementor factory)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder.Append("[");
			if (persister == null)
			{
				s.Builder.Append("<unreferenced>");
			}
			else
			{
				s.Builder.Append(persister.Role);
				s.Builder.Append("#");

				if (id == null)
				{
					s.Builder.Append("<null>");
				}
				else
				{
					AddIdToCollectionInfoString(persister, id, factory, s);
				}
			}
			s.Builder.Append("]");

			return s.ToStringAndFree();
		}

		private static void AddIdToCollectionInfoString(ICollectionPersister persister, object id, ISessionFactoryImplementor factory, StringBuilder s)
		{
			// Need to use the identifier type of the collection owner
			// since the incoming is value is actually the owner's id.
			// Using the collection's key type causes problems with
			// property-ref keys.
			// Also need to check that the expected identifier type matches
			// the given ID.  Due to property-ref keys, the collection key
			// may not be the owner key.
			IType ownerIdentifierType = persister.OwnerEntityPersister.IdentifierType;
			if (ownerIdentifierType.ReturnedClass.IsInstanceOfType(id))
			{
				s.Append(ownerIdentifierType.ToLoggableString(id, factory));
			}
			else
			{
				// TODO: This is a crappy backup if a property-ref is used.
				// If the reference is an object w/o toString(), this isn't going to work.
				s.Append(id.ToString());
			}
		}

		/// <summary> 
		/// Generate an info message string relating to a particular entity,
		/// based on the given entityName and id. 
		/// </summary>
		/// <param name="entityName">The defined entity name. </param>
		/// <param name="id">The entity id value. </param>
		/// <returns> An info string, in the form [FooBar#1]. </returns>
		public static string InfoString(string entityName, object id)
		{
			var s = PooledStringBuilder.GetInstance();
			s.Builder
				.Append('[')
				.Append((entityName ?? "<null entity name>"))
				.Append('#')
				.Append((id ?? "<null>"))
				.Append(']');

			return s.ToStringAndFree();
		}
	}
}
