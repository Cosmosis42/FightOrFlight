using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeArena : MonoBehaviour
{

	public float leftBounds, rightBounds, topBounds, botBounds;
	public float minSizeX, maxSizeX, minSizeY, maxSizeY;
	private float platLocX, platLocY, platSizeX, platSizeY, leafLocY, leafLocX;
	GameObject[] plat = new GameObject[4];
	public GameObject platFab, player1, player2, hedge;
	private Vector3 platSize;
	private float hedgeHeightAdjustment = 1.8f;
	public GameObject[] spawners;
	public GameObject leaf;
	public int numLeaves = 100;

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < plat.Length - 1; i++)
		{
			platLocX = Random.Range(leftBounds, rightBounds);
			platLocY = Random.Range(topBounds, botBounds);

			platSizeX = Random.Range(minSizeX, maxSizeX);
			platSizeY = Random.Range(minSizeY, maxSizeY);

			for (int j = 0; j < i; j++)
			{
				float platDist = platLocY - plat[j].transform.position.y;

				Debug.Log(Mathf.Abs(platDist) + " " + j);

				if (Mathf.Abs(platDist) < (player1.transform.localScale.y + 1.0))
				{
					if (platDist > 0)
					{
						platLocY = platLocY + 2;
					}
					else
					{
						platLocY = platLocY - 2;
					}
				}
			}

			plat[i] = Instantiate(platFab, new Vector2(platLocX, platLocY), Quaternion.identity);

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

			for (int j = 0; j < numLeaves; j++)
			{
				leafLocX = Random.Range(platLocX - platSizeX / 2, platLocX + platSizeX / 2);
				leafLocY = Random.Range(platLocY - platSizeY / 2, platLocY + platSizeY / 2);

				Instantiate(leaf, new Vector2(leafLocX, leafLocY), Quaternion.identity);
			}
		}

		for (int i = 0; i < spawners.Length; i++)
		{
			platLocX = Random.Range(leftBounds, rightBounds);
			platLocY = Random.Range(topBounds, botBounds);

			Instantiate(spawners[i], new Vector2(platLocX, platLocY), Quaternion.identity);
		}

		platLocX = Random.Range(leftBounds, rightBounds);
		platLocY = Random.Range(topBounds, botBounds);

		platSizeX = Random.Range(minSizeY, maxSizeY);
		platSizeY = Random.Range(minSizeX, maxSizeX);

		plat[plat.Length - 1] = Instantiate(platFab, new Vector2(platLocX, platLocY), Quaternion.identity);

		platSize = new Vector3(platSizeX, platSizeY, 1.0f);

		plat[plat.Length - 1].transform.localScale = platSize;

		for (int i = 0; i < numLeaves; i++)
		{
			leafLocX = Random.Range(platLocX - platSizeX / 2, platLocX + platSizeX / 2);
			leafLocY = Random.Range(platLocY - platSizeY / 2, platLocY + platSizeY / 2);

			Instantiate(leaf, new Vector2(leafLocX, leafLocY), Quaternion.identity);
		}
	}
}
