using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class FilterationProcess : MonoBehaviour
    {
        public FilterMachine machine;
        public Animator FilterAnimation;
        public Vector3 targetPoint;
        public float filterSpwanDelay = 0.3f;
        public float countdownTimer;
        public float WaitTimer = 0.5f;
        void Start()
        {

        }

		public bool x;

        void Update()
        {
            filterationOpration();
        }

        void filterationOpration()
        {
            if(!machine.isPlayerOnSlot && machine.oreStored.Count > 0 && !x)
            {
                if (countdownTimer >= 0)
                {
                    countdownTimer -= Time.deltaTime;
                    if (countdownTimer <= 0)
                    {
                        StartCoroutine(triggerAmimation(filterSpwanDelay));
                        machine.oreStored[machine.oreStored.Count - 1].GetComponent<StackingObejcts>().TargetPos = targetPoint;
                        machine.oreStored[machine.oreStored.Count - 1].GetComponent<StackingObejcts>().isDestroy = true;
                        countdownTimer = WaitTimer;
						x = true;
                    }
                    
                }
            }
            if (machine.oreStored.Count > 0)
            {
                for (int i = 0; i <= machine.oreStored.Count - 1; i++)
                {
                    if (machine.oreStored[i] == null)
                    {
                        machine.oreStored.Remove(machine.oreStored[i]);
                    }
                }
            }
        }


        IEnumerator triggerAmimation(float t)
        {
            yield return new WaitForSeconds(t);
            FilterAnimation.SetTrigger("filter");
        }
    }
}
