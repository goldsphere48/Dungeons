using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	interface IObjectPool<TKey, TValue> where TValue : IPoolable
	{
		void AddToPool(TKey key, TValue value);
		TValue GetFromPool(TKey key);
	}
}
