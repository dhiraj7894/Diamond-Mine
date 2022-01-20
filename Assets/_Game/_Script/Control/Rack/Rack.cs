using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class Rack : MonoBehaviour
    {
		public Diamond.Control.MineMachine mineMachine;
        public List<GameObject> Obj = new List<GameObject>();
		
		public bool isPlayerNear;
		public bool LevelComplete;
        public float WaitTimer = 0.5f;


        private float countdownTimer;
        private _PlayerStacking playerStacking;		
		private Diamond.Core.GameManager gm;
		private Diamond.Core.AudioManager Am;

		void Start()
        {
            playerStacking = FindObjectOfType<_PlayerStacking>();
            gm = FindObjectOfType<Diamond.Core.GameManager>();
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
			foreach (Transform T in transform)
            {
                if (!Obj.Contains(T.gameObject))
                {
                    Obj.Add(T.gameObject);
                }
            }
        }
        void Update()
        {
			if (Obj.Count <= 0 || LevelComplete)
			{
				Destroy(this.gameObject);
			}
			if (mineMachine.isUnlocked)
			{
				Destroy(this.gameObject,0.2f);
			}

            GiveObjectToPlayer();
            foreach (Transform T in transform)
            {
                if (!Obj.Contains(T.gameObject))
                {
                    Obj.Add(T.gameObject);
                }
            }
        }


        public void GiveObjectToPlayer()
        {
            if (isPlayerNear && countdownTimer >= 0 && Obj.Count>0 && playerStacking.ClothObject.Count<=gm.StackingLimit)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0)
                {
                    playerStacking.addClothToStack(Obj[0].gameObject);
                    if(playerStacking.ClothObject.Count <= 0)
                        Obj[0].GetComponent<Diamond.Control.StackingObejcts>().TargetPos = new Vector3(0, 0.15f, -0.5f);
                    if (playerStacking.ClothObject.Count > 0)
                        Obj[0].GetComponent<Diamond.Control.StackingObejcts>().TargetPos = new Vector3(0, Mathf.Abs(playerStacking.ClothObject[playerStacking.ClothObject.Count - 1].transform.localPosition.y + 0.29f), -0.5f);
                    Obj.Remove(Obj[0]);
					Am.source.PlayOneShot(Am.CollectItem);
					isPlayerNear = false;
                    countdownTimer = WaitTimer;
                }
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Diamond.Movement._PlayerMovment>().direction.magnitude <= 0)
            {
                isPlayerNear = true;                
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (isPlayerNear)
                isPlayerNear = false;
        }
    }
}
