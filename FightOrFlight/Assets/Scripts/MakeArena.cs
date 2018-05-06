using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeArena : MonoBehaviour
{

	public float leftBounds, rightBounds, topBounds, botBounds;
	public float minSizeX, maxSizeX, minSizeY, maxSizeY;
	private float platLocX, platLocY, platSizeX, platSizeY;
	GameObject[] plat = new GameObject[4];
	public GameObject platFab, player1, player2, hedge;
	private Vector3 platSize;
	private float hedgeHeightAdjustment = 1.8f;

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < plat.Length - 1; i++)
		{
			platLocX = Random.Range(leftBounds, rightBounds);
			platLocY = Random.Range(topBounds, botBounds);

			plat[i] = Instantiate(platFab, new Vector2(platLocX, platLocY), Quaternion.identity);

			platSizeX = Random.Range(minSizeX, maxSizeX);
			platSizeY = Random.Range(minSizeY, maxSizeY);

			platSize = new Vector3(platSizeX, platSizeY, 1.0f);

			plat[i].transform.localScale = platSize;

			switch (i)
			{
				case 0:
					player1.transform.position = new Vector2(platLocX, platLocY + player1.transform.localScale.y);
					break;
				case 1:
					player2.transform.position = new Vector2(platLocX, platLocY + player1.transform.localScale.y);
					break;
				case 2:
					hedge.transform.position = new Vector2(platLocX, platLocY + hedge.transform.localScale.y * hedgeHeightAdjustment);
					hedge.GetComponent<Spike>().left = (platLocX - platSizeX / 2) + (hedge.transform.localScale.x * 2);
					hedge.GetComponent<Spike>().right = (platLocX + platSizeX / 2) - (hedge.transform.localScale.x * 2);
					break;
			}
		}

		platLocX = Random.Range(leftBounds, rightBounds);
		platLocY = Random.Range(topBounds, botBounds);

		plat[plat.Length - 1] = Instantiate(platFab, new Vector2(platLocX, platLocY), Quaternion.identity);

		platSize = new Vector3(Random.Range(minSizeY, maxSizeY), Random.Range(minSizeX, maxSizeX), 1.0f);

		plat[plat.Length - 1].transform.localScale = platSize;
	}
}
