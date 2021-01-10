using System;

namespace Dungeons
{
	enum EffectType
	{
		Fire,
		Poison,
		Frost
	}

	abstract class Effect : ICloneable
	{
		public string Name { get; set; }
		public int Ticks { get; set; }
		public Animation Animation { get; set; }
		public EffectType EffectType { get; set; }
		public abstract void InitialEffect(Character ch);
		public abstract void EffectPerTick(Character ch);
		public abstract void FinishedEffect(Character ch);
		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	class Frost : Effect
	{
		public int Damage { get; set; }

		public override void InitialEffect(Character ch)
		{
			Console.WriteLine("You are frozen!");
		}

		public override void EffectPerTick(Character ch)
		{
			ch.ApplyDamage(Damage);
		}

		public override void FinishedEffect(Character ch)
		{
			Console.WriteLine("You are unfrozen");
		}
	}
}
