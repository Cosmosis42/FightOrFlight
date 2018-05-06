using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class APowerUpEffect
{
	public float Value { get; set; }
	public float Duration { get; set; }

	public abstract string GetDisplayString();
}

public class DamageBoost : APowerUpEffect
{
	public override string GetDisplayString()
	{
		return "DOUBLE DAMAGE";
	}
}

public class SpeedBoost : APowerUpEffect
{
	public override string GetDisplayString()
	{
		return "SUPER SPEED";
	}
}
