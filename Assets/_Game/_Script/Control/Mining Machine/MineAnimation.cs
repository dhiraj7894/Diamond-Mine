using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class MineAnimation : MonoBehaviour
    {
		public int StoneID;
        public Transform ParantTransform;
        public GameObject MiningObject;
        public Transform spwanPos;
        public MineMachine machine;

        public Vector3 firstMinedObject;

        private void Update()
        {
            if(machine.MinedObjects.Count < machine.MaxMinedObjectCanStore && !machine.isPlayerOnSlot)
            {
                GetComponent<Animator>().SetBool("machineActivate", true);
            }
            if (machine.MinedObjects.Count > machine.MaxMinedObjectCanStore)
            {
                GetComponent<Animator>().SetBool("machineActivate", false);
            }
        }
        public void Spwan()
        {
            GameObject mine = Instantiate(MiningObject);
			mine.GetComponent<StackingObejcts>().ObjectId = StoneID;
            mine.transform.position = spwanPos.position;
            mine.transform.parent = ParantTransform;
            mine.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
        }
        public void positionAdjustment()
        {
            if(machine.MinedObjects.Count == 1)
            {
                machine.MinedObjects[0].GetComponent<StackingObejcts>().TargetPos = firstMinedObject;
            }
            if(machine.MinedObjects.Count >= 2 && machine.MinedObjects.Count % 5 != 0)
            {
				machine.MinedObjects[machine.MinedObjects.Count - 1].GetComponent<StackingObejcts>().TargetPos =
					new Vector3(firstMinedObject.x,
					machine.MinedObjects[machine.MinedObjects.Count - 2].transform.localPosition.y,
					machine.MinedObjects[machine.MinedObjects.Count - 2].transform.localPosition.z + 1);                
            }
        }
        public void positionYAdjustment()
        {
            if (machine.MinedObjects.Count % 5 == 0)
            {
                machine.MinedObjects[machine.MinedObjects.Count - 1].GetComponent<StackingObejcts>().TargetPos = new Vector3(firstMinedObject.x, firstMinedObject.y + 1, firstMinedObject.z);
            }
        }
    }
}
