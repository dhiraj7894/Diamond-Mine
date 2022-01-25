using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAVE : MonoBehaviour
{
	public float save;
	[HideInInspector]public float saveCounter;
	private void Start()
	{
		saveCounter = save;
	}
	private void Update()
	{
		if (saveCounter > 0)
		{
			saveCounter -= Time.deltaTime;
			if (saveCounter <= 0)
			{
				try
				{
					saveCounter = save;
					FindObjectOfType<SaveAndLoadUniversal>().SaveGame();
					FindObjectOfType<SaveAndLoadArea_1>().SaveGame();
					FindObjectOfType<SaveAndLoadArea_2>().SaveGame();
					FindObjectOfType<SaveAndLoadArea_3>().SaveGame();
					FindObjectOfType<SaveAndLoadArea_4>().SaveGame();
				}
				catch
				{

				}
			}
		}
	}
}
