using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	class ObjectPool<TKey, TValue> : IObjectPool<TKey, TValue> where TValue : class, IPoolable
	{
		private List<KeyValuePair<TKey, TValue>> _pool;

		public ObjectPool(int capacity)
		{
			_pool = new List<KeyValuePair<TKey, TValue>>(capacity);
		}

		public void AddToPool(TKey id, TValue value)
		{
			_pool.Add(new KeyValuePair<TKey, TValue>(id, value));
			value.IsActive = false;
		}

		public TValue GetFromPool(TKey id)
		{
			var item = _pool.Find(e => e.Key.Equals(id) && e.Value.IsActive == false);
			if (item.Value == null)
			{
				item = new KeyValuePair<TKey, TValue>(id, Activator.CreateInstance<TValue>());
				_pool.Add(item);
			}
			item.Value.IsActive = true;

			return item.Value;
		}
	}
}
