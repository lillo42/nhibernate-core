using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Util;

namespace NHibernate.Hql
{
	public class CollectionSubqueryFactory
	{
		public static string CreateCollectionSubquery(
			JoinSequence joinSequence,
			IDictionary<string, IFilter> enabledFilters,
			String[] columns)
		{
			try
			{
				JoinFragment join = joinSequence.ToJoinFragment(enabledFilters, true);
				var buf = PooledStringBuilder.GetInstance();
				
				buf.Builder.Append("select ")
					.Append(string.Join(", ", columns))
					.Append(" from ")
					.Append(join.ToFromFragmentString.Substring(2)) // remove initial ", "
					.Append(" where ")
					.Append(join.ToWhereFragmentString.Substring(5)) // remove initial " and "
					;

				return buf.ToStringAndFree();
			}
			catch (MappingException me)
			{
				throw new QueryException(me);
			}
		}
	}
}
