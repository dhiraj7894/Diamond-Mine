using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
	public class SellExtraItem : MonoBehaviour
	{		
		public float countdownTimer;
		public float WaitTimer = 0.5f;

		public bool isPlayerNear;
		public bool isPlayerOnSlot;

		private _PlayerStacking playerStacking;
		

		private void Start()
		{
			playerStacking = FindObjectOfType<_PlayerStacking>();
			
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
				if (countdownTimer <= 0)
				{
					playerStacking.RemoveStoneForSell(this.gameObject);
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
		}
	}
}
