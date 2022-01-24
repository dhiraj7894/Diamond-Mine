using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desableUI : MonoBehaviour
{
	public bool active;
	public GameObject g;
	private Diamond.Core.AudioManager am;
	private Diamond.Core.LevelManager lv;

	private void Start()
	{
		am = FindObjectOfType<Diamond.Core.AudioManager>();
		lv = FindObjectOfType<Diamond.Core.LevelManager>();
	}
	public void desableGameObject()
	{
		if (active)
		{
			if(g.activeSelf)
				g.SetActive(false);
		}
			

		if (this.gameObject.activeSelf && !active)
			this.gameObject.SetActive(false);
	}

	public void LevelEnd()
	{
		am.source.PlayOneShot(am.LevelComplete);
	}
	public void LevelStart()
	{
		am.source.PlayOneShot(am.MoneyCount);
	}

	public void LevelCompleteSDK()
    {
		FindObjectOfType<Analytics>().LevelCompleteProgression(lv.level);
    }
}
