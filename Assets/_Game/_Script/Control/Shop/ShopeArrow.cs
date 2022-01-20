using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopeArrow : MonoBehaviour
{
	private void Update()
	{
		if (FindObjectOfType<Diamond.Core.LevelManager>().level >= 1)
		{
			Destroy(this.gameObject);
		}
	}
}
