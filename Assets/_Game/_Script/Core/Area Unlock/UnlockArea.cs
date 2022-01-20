using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Core
{
	public class UnlockArea : MonoBehaviour
	{
		public GameObject unlocableObject;
		public GameObject ParticalEffect;
		public Animator cam;
		public string cinematicCam;

		public int levelToUnlock;

		public bool isUnlocked;
		public bool isCinematicCam;

		LevelManager lv;
		void Start()
		{
			lv = FindObjectOfType<LevelManager>();
		}

		
		void Update()
		{
			if(lv.level >= levelToUnlock && !isUnlocked)
			{
				StartCoroutine(Unlock(1.5f));
				if (!isCinematicCam)
				{
					FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().UnlockMachine);
					cam.Play(cinematicCam);
					isCinematicCam = true;
				}
				
			}
			if(lv.level>=levelToUnlock && isUnlocked)
			{
				unlocableObject.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}

		IEnumerator Unlock(float t)
		{
			yield return new WaitForSeconds(t);
			Destroy(Instantiate(ParticalEffect, transform.position + new Vector3(0, 2, 0), Quaternion.identity), 2);
			unlocableObject.SetActive(true);
			this.gameObject.SetActive(false);
			isUnlocked = true;
			
		}
	}
}
