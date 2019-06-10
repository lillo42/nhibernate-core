using System;
using System.Text;
using Antlr.Runtime;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// Convenience implementation of Statement to centralize common functionality.
	/// Author: Steve Ebersole
	/// Ported by: Steve Strong
	/// </summary>
	[CLSCompliant(false)]
	public abstract class AbstractStatement : HqlSqlWalkerNode, IDisplayableNode, IStatement
	{
		protected AbstractStatement(IToken token) : base(token)
		{
		}

		public abstract bool NeedsExecutor
		{ 
			get;
		}

		public abstract int StatementType
		{ 
			get;
		}

		/// <summary>
		/// Returns additional display text for the AST node.
		/// </summary>
		/// <returns>The additional display text.</returns>
		public String GetDisplayText()
		{
			var buf = PooledStringBuilder.GetInstance();
			if (Walker.QuerySpaces.Count > 0)
			{
				buf.Builder.Append(" querySpaces (");
				bool first = true;

				foreach (string space in Walker.QuerySpaces)
				{
					if (!first)
					{
						buf.Builder.Append(',');
					}

					buf.Builder.Append(space);
					first = false;
				}

				buf.Builder.Append(")");
			}
			return buf.ToStringAndFree();
		}
	}
}
