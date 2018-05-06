using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HpPowerUp : APowerUp
{
	public int Value;

	public override void Apply(Player player)
	{
		player.AddHp(Value);
	}
}
