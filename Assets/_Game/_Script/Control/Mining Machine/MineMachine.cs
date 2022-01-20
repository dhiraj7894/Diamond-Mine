using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class MineMachine : MonoBehaviour
    {
        public int TargetID;
        public int RequreObjects;
        public int MaxMinedObjectCanStore;
        public float countdownTimer;
        public float WaitTimer = 0.5f;

        public bool isPlayerNear;
        public bool isPlayerOnSlot;
        public bool isMachineLocked;
        public bool isMachineUnlocked;
        public bool isUnlocked;

        public List<GameObject> MinedObjects = new List<GameObject>();
        public Transform StorageObject;
        private _PlayerStacking playerStacking;
        private Diamond.Core.GameManager gm;
        private Diamond.Core.AudioManager Am;
		
		public Animator UI;
        // Start is called before the first frame update
        void Start()
        {

            playerStacking = FindObjectOfType<_PlayerStacking>();
            gm = FindObjectOfType<Diamond.Core.GameManager>();
            Am = FindObjectOfType<Diamond.Core.AudioManager>();
			
            foreach (Transform T in StorageObject)
            {
                if (!MinedObjects.Contains(T.gameObject))
                {
                    MinedObjects.Add(T.gameObject);
                }
            }
        }


        void Update()
        {
            foreach (Transform T in StorageObject)
            {
                if (!MinedObjects.Contains(T.gameObject))
                {
                    MinedObjects.Add(T.gameObject);
                }
            }

            if (isUnlocked)
                GiveItemToPlayer();
            if (isMachineLocked)
                TakeItemFromPlayer();

        }

        void GiveItemToPlayer()
        {
            if (isPlayerNear && countdownTimer >= 0 && MinedObjects.Count > 0 && playerStacking.ClothObject.Count <= gm.StackingLimit)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0)
                {
					
                    playerStacking.addClothToStack(MinedObjects[MinedObjects.Count-1].gameObject);
                    if (playerStacking.ClothObject.Count <= 0)
                        MinedObjects[MinedObjects.Count - 1].GetComponent<Diamond.Control.StackingObejcts>().TargetPos = new Vector3(0, 0.15f, -0.5f);
                    if (playerStacking.ClothObject.Count > 0)
                        MinedObjects[MinedObjects.Count - 1].GetComponent<Diamond.Control.StackingObejcts>().TargetPos = new Vector3(0, Mathf.Abs(playerStacking.ClothObject[playerStacking.ClothObject.Count - 1].transform.localPosition.y + 0.29f), -0.5f);
                    MinedObjects.Remove(MinedObjects[MinedObjects.Count - 1]);
					Am.source.PlayOneShot(Am.CollectItem);
                    isPlayerNear = false;
                    countdownTimer = WaitTimer;
                }
            }
        }
        void TakeItemFromPlayer()
        {
            if (isPlayerNear && playerStacking.ClothObject.Count > 0 && countdownTimer >= 0 && RequreObjects > 0)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0)
                {
					playerStacking.RemoveCloth(this.gameObject, TargetID);
					Am.source.PlayOneShot(Am.DropItem);
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
				UI.gameObject.SetActive(true);
            }
        }
        private void OnCollisionExit(Collision other)
        {
			UI.Play("Out");


			if (isPlayerNear)
                isPlayerNear = false;
            if (isPlayerOnSlot)
                isPlayerOnSlot = false;
        }
    }
}
