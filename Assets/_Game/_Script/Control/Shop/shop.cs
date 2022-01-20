using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Diamond.Control
{
	public class shop : MonoBehaviour
	{
		public int TargetIDBlue;
		public int TargetIDRed;
		public int TargetIDYellow;
		public int TargetIDBlack;
		public float countdownTimer;

		public float WaitTimer = 0.5f;

		public bool isPlayerNear;
		public bool isPlayerOnSlot;

		public bool isMachineUnlocked;

		private _PlayerStacking playerStacking;
		private Diamond.Core.GameManager gm;
		private Diamond.Core.AudioManager Am;

		private void Start()
		{
			gm = FindObjectOfType<Diamond.Core.GameManager>();
			playerStacking = FindObjectOfType<_PlayerStacking>();
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
		}
		private void Update()
		{
			TakeItemFromPlayer();
			
		}

		void TakeItemFromPlayer()
		{
			if (isPlayerNear && playerStacking.ClothObject.Count > 0 && countdownTimer >= 0)
			{				
				countdownTimer -= Time.deltaTime;
				if (countdownTimer <= 0 && gm.RequreBlueGem > 0 && playerStacking.RemovebleDiamond(TargetIDBlue))
				{
					Am.source.PlayOneShot(Am.DropItem);
					playerStacking.RemoveCloth(this.gameObject, TargetIDBlue);					
					countdownTimer = WaitTimer;
				}

				if (countdownTimer <= 0 && gm.RequreRedGem > 0 && playerStacking.RemovebleDiamond(TargetIDRed))
				{
					Am.source.PlayOneShot(Am.DropItem);
					playerStacking.RemoveCloth(this.gameObject, TargetIDRed);					
					countdownTimer = WaitTimer;
				}

				if (countdownTimer <= 0 && gm.RequreYellowGem > 0 && playerStacking.RemovebleDiamond(TargetIDYellow))
				{
					Am.source.PlayOneShot(Am.DropItem);
					playerStacking.RemoveCloth(this.gameObject, TargetIDYellow);					
					countdownTimer = WaitTimer;
				}

				if (countdownTimer <= 0 && gm.RequreBlackGem > 0 && playerStacking.RemovebleDiamond(TargetIDBlack))
				{
					Am.source.PlayOneShot(Am.DropItem);
					playerStacking.RemoveCloth(this.gameObject, TargetIDBlack);					
					countdownTimer = WaitTimer;
				}
			}
		}
		
		private void OnCollisionStay(Collision other)
		{
			if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Diamond.Movement._PlayerMovment>().direction.magnitude <= 0)
			{
				isPlayerNear = true;
				isPlayerOnSlot = true;
			}
		}
		private void OnCollisionExit(Collision other)
		{
			if (isPlayerNear)
				isPlayerNear = false;
			if (isPlayerOnSlot)
				isPlayerOnSlot = false;
			countdownTimer = WaitTimer;
		}
	}
}
