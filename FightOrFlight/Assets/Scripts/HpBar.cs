using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
	public GameObject LifeIndicator;

	public Sprite RemainingLife;

	public Sprite SpentLife;

	public Transform Container;

	private Image[] _lives;

	public void Initialize(int maxLife)
	{
		Clear();
		_lives = new Image[maxLife];

		for (int i = 0; i < _lives.Length; i++)
		{
			GameObject indicator = Instantiate(LifeIndicator);
			indicator.transform.SetParent(Container, false);
			Image image = indicator.GetComponent<Image>();
			image.sprite = RemainingLife;
			_lives[i] = image;
		}
	}

	public void SetCurrentLife(int currentLife)
	{
		for (int i = currentLife; i < _lives.Length; i++)
		{
			_lives[i].sprite = SpentLife;
		}
	}

	void Clear()
	{
		_lives = null;
		foreach (Transform child in Container)
		{
			Destroy(child.gameObject);
		}
	}

}
