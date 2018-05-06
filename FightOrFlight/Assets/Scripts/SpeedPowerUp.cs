using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SpeedPowerUp : APowerUp
{
	public float Value;
	public float Duration;
	public override void Apply(Player player)
	{
		player.ApplyEffect(new SpeedBoost() { Value = Value, Duration = Duration });
	}
}

