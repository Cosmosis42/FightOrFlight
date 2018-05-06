using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
	public GameObject PowerUpPrefab;

	public float SpawnInterval = 10;
	private float _countDown;

	void Start()
	{
		_countDown = SpawnInterval;
	}

	void Update()
	{
		if (_countDown >= 0)
		{
			_countDown -= Time.deltaTime;

			if (_countDown <= 0)
			{
				SpawnPowerUp();
			}
		}
	}

	public void ResetTimer()
	{
		_countDown = SpawnInterval;
	}

	public void SpawnPowerUp()
	{
		GameObject obj = Instantiate(PowerUpPrefab);
		obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
		var powerUp = obj.GetComponent<APowerUp>();
		Debug.Log(powerUp);
		powerUp.Spawner = this;

	}
}
