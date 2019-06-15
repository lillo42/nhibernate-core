// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0

using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace NHibernate
{
	/// <summary>
	/// The usage is:
	///        var inst = PooledStringBuilder.GetInstance();
	///        var sb = inst.builder;
	///        ... Do Stuff...
	///        ... sb.ToString() ...
	///        inst.Free();
	/// </summary>
	internal sealed class PooledStringBuilder
	{
		public readonly StringBuilder Builder;
		private readonly ObjectPool<PooledStringBuilder> _pool;

		private PooledStringBuilder(ObjectPool<PooledStringBuilder> pool)
		{
			_pool = pool;
			Builder = new StringBuilder();
		}
		
		private PooledStringBuilder(int capacity, ObjectPool<PooledStringBuilder> pool)
		{
			_pool = pool;
			Builder = new StringBuilder(capacity);
		}
		
		private PooledStringBuilder(int capacity, int maxCapacity, ObjectPool<PooledStringBuilder> pool)
		{
			_pool = pool;
			Builder = new StringBuilder(capacity, maxCapacity);
		}


		public int Length => Builder.Length;

		public void Free()
		{
			StringBuilder builder = Builder;

			if (builder.Capacity <= 1024)
			{
				builder.Clear();
				_pool.Free(this);
			}
		}

		//[Obsolete("Consider calling ToStringAndFree instead.")]
		public override string ToString()
			=> Builder.ToString();

		public string ToStringAndFree()
		{
			string result = Builder.ToString();
			Free();

			return result;
		}

		// global pool
		private static readonly ObjectPool<PooledStringBuilder> s_poolInstance = CreatePool(64);

		// if someone needs to create a private pool;
		/// <summary>
		/// If someone need to create a private pool
		/// </summary>
		/// <param name="size">The size of the pool.</param>
		/// <returns></returns>
		public static ObjectPool<PooledStringBuilder> CreatePool(int size = 32)
		{
			ObjectPool<PooledStringBuilder> pool = null;
			pool = new ObjectPool<PooledStringBuilder>(() => new PooledStringBuilder(pool), size);
			return pool;
		}
		
		// if someone needs to create a private pool;
		/// <summary>
		/// If someone need to create a private pool
		/// </summary>
		/// <param name="size">The size of the pool.</param>
		/// <param name="capacity"></param>
		/// <returns></returns>
		public static ObjectPool<PooledStringBuilder> CreatePool(int capacity, int size)
		{
			ObjectPool<PooledStringBuilder> pool = null;
			pool = new ObjectPool<PooledStringBuilder>(() => new PooledStringBuilder(capacity, pool), size);
			return pool;
		}
		
		// if someone needs to create a private pool;
		/// <summary>
		/// If someone need to create a private pool
		/// </summary>
		/// <param name="size">The size of the pool.</param>
		/// <param name="capacity"></param>
		/// <param name="maxCapacity"></param>
		/// <returns></returns>
		public static ObjectPool<PooledStringBuilder> CreatePool(int capacity, int maxCapacity, int size)
		{
			ObjectPool<PooledStringBuilder> pool = null;
			pool = new ObjectPool<PooledStringBuilder>(() => new PooledStringBuilder(pool), size);
			return pool;
		}

		public static PooledStringBuilder GetInstance()
		{
			PooledStringBuilder builder = s_poolInstance.Allocate();
			Debug.Assert(builder.Builder.Length == 0);
			return builder;
		}

		public static implicit operator StringBuilder(PooledStringBuilder obj)
			=> obj.Builder;
	}
}
