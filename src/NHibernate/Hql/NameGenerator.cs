using System;
using System.Text;
using Microsoft.Extensions.ObjectPool;
using NHibernate.Engine;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql
{
	/// <summary>
	/// Provides utility methods for generating HQL / SQL names.
	/// Shared by both the 'classic' and 'new' query translators.
	/// </summary>
	public class NameGenerator
	{
		public static string[][] GenerateColumnNames(IType[] types, ISessionFactoryImplementor f)
		{
			string[][] columnNames = new string[types.Length][];
			for (int i = 0; i < types.Length; i++)
			{
                int span = types[i] != null ? types[i].GetColumnSpan(f) : 1;
				columnNames[i] = new string[span];
				for (int j = 0; j < span; j++)
				{
					columnNames[i][j] = ScalarName(i, j);
				}
			}
			return columnNames;
		}

		private static ObjectPool<PooledStringBuilder> _pool = PooledStringBuilder.CreatePool(16, 32);
		public static string ScalarName(int x, int y)
		{
			var buf = _pool.Allocate();
			buf.Builder
				.Append("col_")
				.Append(x)
				.Append(StringHelper.Underscore)
				.Append(y)
				.Append(StringHelper.Underscore);

			return buf.ToStringAndFree();
		}
	}
}