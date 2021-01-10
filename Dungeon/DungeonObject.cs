using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	abstract class DungeonObject : IPoolable
	{
		public bool IsActive { get; set; }
		private IntVector2 _position;
		private Image _image;

		public void Initialize(IntVector2 position, Image image)
		{
			_position = position;
			_image = image;
		}

		public abstract void InteractWith(Character character);
	}

	class PassableDungeonObject : DungeonObject
	{
		public override void InteractWith(Character character)
		{
			
		}
	}

	class Chest : DungeonObject
	{
		public override void InteractWith(Character character)
		{

		}
	}

	class Trap : DungeonObject
	{
		private Effect _effect;

		public Trap(Effect effect)
		{
			_effect = effect;
		}

		public override void InteractWith(Character ch)
		{
			ch.ApplyEffect(_effect);
		}
	}
}
