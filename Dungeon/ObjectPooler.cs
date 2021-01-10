using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	public class ObjectPooler<T> where T : class, IPoolable
	{
		public static ObjectPooler<T> Instance =>
			_instance ??= new ObjectPooler<T>();

		private static ObjectPooler<T> _instance;

		private Dictionary<Type, ObjectPool<string, T>> _pools;

		public ObjectPooler()
		{
			_pools = new Dictionary<Type, ObjectPool<string, T>>();
		}

		public T Get(string key)
		{
			if (!_pools.TryGetValue(typeof(T), out var pool))
			{
				pool = new ObjectPool<string, T>(1);
				_pools.Add(typeof(T), pool);
			}

			return pool.GetFromPool(key);
		}

		public void Add(string key, T value)
		{
			if (!_pools.TryGetValue(typeof(T), out var pool))
			{
				pool = new ObjectPool<string, T>(1);
				_pools.Add(typeof(T), pool);
				pool.AddToPool(key, value);
			}
		}
	}
}
