using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HpPowerUp : APowerUp
{
	public int Value;
	public override void Apply(Player player)
	{
		player.AddHp(Value);
	}
}
