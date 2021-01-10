using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	class Dungeon
	{
		private HashSet<DungeonObject> _dungeonObjects;
		private IObjectPool<Type, DungeonObject> _pool;

		public Dungeon()
		{
			_dungeonObjects = new HashSet<DungeonObject>();
			_pool = new ObjectPool<Type, DungeonObject>(100);
			GenerateDungeon();
		}

		private void GenerateDungeon()
		{
			CreateDungeonObject(typeof(PassableDungeonObject), "", new IntVector2());
		}

		private void CreateDungeonObject(Type dungeonObjectType, string image, IntVector2 position)
		{
			var obj = _pool.GetFromPool(dungeonObjectType);
			obj.Initialize(position, ImagePool.GetImage(image));
			_dungeonObjects.Add(obj);
		}

		private void RemoveDungeonObject(DungeonObject dungeonObject)
		{
			_dungeonObjects.Remove(dungeonObject);
			dungeonObject.IsActive = false;
		}
	}
}
