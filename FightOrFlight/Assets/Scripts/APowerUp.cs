using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class APowerUp : MonoBehaviour
{
	public abstract void Apply(Player player);
}
