using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class FilterMachine : MonoBehaviour
    {
        public int TargetID;
        public int TargetUnlockID;
        public int OutputID;
        public int RequreObjects;
        public int MaxMinedObjectCanStore;
        public float countdownTimer;
        public float WaitTimer = 0.5f;

        public bool isPlayerNear;
        public bool isPlayerOnSlot;
        public bool isMachineLocked;
        public bool isMachineUnlocked;
        public bool isUnlocked;
		public bool isOreAvailable;
        public List<GameObject> MinedObjects = new List<GameObject>();
        public List<GameObject> oreStored = new List<GameObject>();
        public Transform StorageObject;
        public Transform oreStorage;
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
            foreach (Transform T in oreStorage)
            {
                if (!oreStored.Contains(T.gameObject))
                {
                    oreStored.Add(T.gameObject);
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
            foreach (Transform T in oreStorage)
            {
                if (!oreStored.Contains(T.gameObject))
                {
                    oreStored.Add(T.gameObject);
                }
            }

			if (isMachineLocked)
				takeForUnlock();
			if (isUnlocked)
                GiveItemToPlayer();
            if (oreStored.Count <= MaxMinedObjectCanStore && !isOreAvailable)
                TakeItemFromPlayer();

			oreChecker();

		}

		void oreChecker()
		{
			if(isUnlocked)
			{
				if (playerStacking.ClothObject.Count > 0 && MinedObjects.Count > 0)
				{
					isOreAvailable = true;
				}
				if(MinedObjects.Count <= 0)
				{
					isOreAvailable = false;
				}
				/*{
					for (int i = 0; i <= playerStacking.ClothObject.Count - 1;)
					{
						if (i >= playerStacking.ClothObject.Count - 1 && playerStacking.ClothObject[i].GetComponent<StackingObejcts>().ObjectId != TargetID)
						{
							isOreAvailable = false;
							return;
						}

						if (playerStacking.ClothObject[i].GetComponent<StackingObejcts>().ObjectId != TargetID)
						{
							isOreAvailable = false;
							i++;
						}

						if (playerStacking.ClothObject[i].GetComponent<StackingObejcts>().ObjectId == TargetID)
						{
							isOreAvailable = true;
							break;
						}
					}
				}
				if (playerStacking.ClothObject.Count <= 0)
					isOreAvailable = false;*/
			}
		}
        
        void GiveItemToPlayer()
        {
            if (isPlayerNear && countdownTimer >= 0 && MinedObjects.Count > 0 && playerStacking.ClothObject.Count < gm.StackingLimit && RequreObjects <= 0)
            {
                countdownTimer -= Time.deltaTime;
				if (countdownTimer <= 0)
				{
					playerStacking.addClothToStack(MinedObjects[MinedObjects.Count - 1].gameObject);

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
        Vector3 pos;
        void TakeItemFromPlayer()
        {
            if (isPlayerNear && playerStacking.ClothObject.Count > 0 && countdownTimer >= 0 && RequreObjects<=0)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0)
                {
                    orePosGenrator();					
					countdownTimer = WaitTimer;
                }
            }
        }


        void orePosGenrator()
        {
            if (oreStored.Count <= 0)
			{
                pos = new Vector3(1.38f, 1.85f, -0.39f);
				playerStacking.RemoveOreForFilter(oreStorage, pos, TargetID);				
			}
            if (oreStored.Count > 0 && oreStored.Count % 3 != 0)
			{
                pos = new Vector3(oreStored[oreStored.Count - 1].transform.localPosition.x - 0.8f, oreStored[oreStored.Count - 1].transform.localPosition.y, -0.39f);
				playerStacking.RemoveOreForFilter(oreStorage, pos, TargetID);				
			}

            if (oreStored.Count > 0 && oreStored.Count % 3 == 0)
			{
                pos = new Vector3(1.38f, oreStored[oreStored.Count - 1].transform.localPosition.y + 2f, -0.39f);
				playerStacking.RemoveOreForFilter(oreStorage, pos, TargetID);				
			}
        }

		void takeForUnlock()
		{
			if (isPlayerNear && playerStacking.ClothObject.Count > 0 && countdownTimer >= 0 && RequreObjects > 0)
			{
				countdownTimer -= Time.deltaTime;
				if (countdownTimer <= 0)
				{
					playerStacking.RemoveCloth(this.gameObject, TargetUnlockID);
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
				UI.gameObject.SetActive(true);
			}
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerOnSlot = true;
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
