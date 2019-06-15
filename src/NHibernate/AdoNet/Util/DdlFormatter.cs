using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.ObjectPool;
using NHibernate.Util;

namespace NHibernate.AdoNet.Util
{
	public class DdlFormatter: IFormatter
	{
		private const string Indent1 = "\n    ";
		private const string Indent2 = "\n      ";
		private const string Indent3 = "\n        ";

		/// <summary> Format an SQL statement using simple rules:
		/// a) Insert newline after each comma;
		/// b) Indent three spaces after each inserted newline;
		/// If the statement contains single/double quotes return unchanged,
		/// it is too complex and could be broken by simple formatting.
		/// </summary>
		public virtual string Format(string sql)
		{
			if (sql.StartsWith("create table", StringComparison.OrdinalIgnoreCase))
			{
				return FormatCreateTable(sql);
			}
			else if (sql.StartsWith("alter table", StringComparison.OrdinalIgnoreCase))
			{
				return FormatAlterTable(sql);
			}
			else if (sql.StartsWith("comment on", StringComparison.OrdinalIgnoreCase))
			{
				return FormatCommentOn(sql);
			}
			else
			{
				return Indent1 + sql;
			}
		}


		private static ObjectPool<PooledStringBuilder> _pool = PooledStringBuilder.CreatePool(60, 32);

		protected virtual string FormatCommentOn(string sql)
		{
			var result = _pool.Allocate();
			result.Builder.Append(Indent1);
			var quoted = false;
			foreach (var token in new StringTokenizer(sql, " '[]\"", true))
			{
				result.Builder.Append(token);
				if (IsQuote(token))
				{
					quoted = !quoted;
				}
				else if (!quoted)
				{
					if ("is".Equals(token))
					{
						result.Builder.Append(Indent2);
					}
				}
			}

			return result.ToStringAndFree();
		}

		protected virtual string FormatAlterTable(string sql)
		{
			var result = _pool.Allocate();
			result.Builder.Append(Indent1);
			var quoted = false;
			foreach (var token in new StringTokenizer(sql, " (,)'[]\"", true))
			{
				if (IsQuote(token))
				{
					quoted = !quoted;
				}
				else if (!quoted)
				{
					if (IsBreak(token))
					{
						result.Builder.Append(Indent3);
					}
				}
				result.Builder.Append(token);
			}

			return result.ToStringAndFree();
		}

		protected virtual string FormatCreateTable(string sql)
		{
			var result = _pool.Allocate();
			result.Builder.Append(Indent1);
			var depth = 0;
			var quoted = false;
			foreach (var token in new StringTokenizer(sql, "(,)'[]\"", true))
			{
				if (IsQuote(token))
				{
					quoted = !quoted;
					result.Builder.Append(token);
				}
				else if (quoted)
				{
					result.Builder.Append(token);
				}
				else
				{
					if (")".Equals(token))
					{
						depth--;
						if (depth == 0)
						{
							result.Builder.Append(Indent1);
						}
					}
					result.Builder.Append(token);
					if (",".Equals(token) && depth == 1)
					{
						result.Builder.Append(Indent2);
					}
					if ("(".Equals(token))
					{
						depth++;
						if (depth == 1)
						{
							result.Builder.Append(Indent3);
						}
					}
				}
			}

			return result.ToStringAndFree();
		}

		private static bool IsBreak(string token)
		{
			return "drop".Equals(token) || "add".Equals(token) || "references".Equals(token) || "foreign".Equals(token)
			       || "on".Equals(token);
		}

		private static bool IsQuote(string token)
		{
			return "\"".Equals(token) || "`".Equals(token) || "]".Equals(token) || "[".Equals(token) || "'".Equals(token);
		}
	}
}
