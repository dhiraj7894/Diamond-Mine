using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class Rack1 : MonoBehaviour
    {
        public int TargetID;
        public int RequreObjects;
        public float countdownTimer;
        public float WaitTimer = 0.5f;

        public bool isPlayerNear;

        private _PlayerStacking playerStacking;
        
        // Start is called before the first frame update
        void Start()
        {
            playerStacking = FindObjectOfType<_PlayerStacking>();
        }

        // Update is called once per frame
        void Update()
        {
            takeObeject();
        }
        public void takeObeject()
        {
            if(isPlayerNear && playerStacking.ClothObject.Count>0 && countdownTimer >= 0 && RequreObjects>0)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0)
                {
                    playerStacking.RemoveCloth(this.gameObject,TargetID);                    
                    countdownTimer = WaitTimer;
                }
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Diamond.Movement._PlayerMovment>().direction.magnitude<=0)
            {
                isPlayerNear = true;
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if (isPlayerNear)
                isPlayerNear = false;
        }
    }
}
