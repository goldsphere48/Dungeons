using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	class Character
	{
		private List<Effect> _activeEffects = new List<Effect>();
		private int _health;

		public Character(int health)
		{
			_health = health;
		}

		public void ApplyDamage(int damage)
		{
			_health -= damage;
			if (_health <= 0)
			{
				_health = 0;
				Console.WriteLine("You are dead");
			}
			else
			{
				Console.WriteLine($"-{damage} HP");
			}
		}

		public void ApplyEffect(Effect effect)
		{
			effect.InitialEffect(this);
			_activeEffects.Add(effect);
		}

		public void UpdateEffects()
		{
			var effectsToRemove = new List<Effect>();
			foreach (var effect in _activeEffects)
			{
				if (effect.Ticks > 0)
				{
					effect.EffectPerTick(this);
				}
				else
				{
					effect.FinishedEffect(this);
					effectsToRemove.Add(effect);
				}
			}

			foreach (var effect in effectsToRemove)
			{
				_activeEffects.Remove(effect);
			}
		}
	}
}
