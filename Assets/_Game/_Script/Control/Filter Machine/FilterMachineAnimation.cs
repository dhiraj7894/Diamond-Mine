using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class FilterMachineAnimation : MonoBehaviour
    {
		public int stoneID;
        public Transform ParantTransform;
        public GameObject MiningObject;
        public Transform spwanPos;
        public FilterMachine machine;

        public Vector3 firstMinedObject;

        private void Update()
        {
            /*if (machine.MinedObjects.Count < machine.MaxMinedObjectCanStore && !machine.isPlayerOnSlot)
            {
                GetComponent<Animator>().SetBool("machineActivate", true);
            }
            if (machine.MinedObjects.Count > machine.MaxMinedObjectCanStore)
            {
                GetComponent<Animator>().SetBool("machineActivate", false);
            }*/
        }
        public void Spwan()
        {
            GameObject filter = Instantiate(MiningObject);
			filter.GetComponent<StackingObejcts>().ObjectId = stoneID;
            filter.transform.position = spwanPos.position;
            filter.transform.parent = ParantTransform;
            filter.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
        }
        public void positionAdjustment()
        {
            if (machine.MinedObjects.Count == 1)
            {
                machine.MinedObjects[0].GetComponent<StackingObejcts>().TargetPos = firstMinedObject;
            }
            if (machine.MinedObjects.Count >= 2 && machine.MinedObjects.Count % 5 != 0)
            {
                
                machine.MinedObjects[machine.MinedObjects.Count - 1].GetComponent<StackingObejcts>().TargetPos = 
                    new Vector3(firstMinedObject.x, 
                    machine.MinedObjects[machine.MinedObjects.Count - 2].transform.localPosition.y, 
                    machine.MinedObjects[machine.MinedObjects.Count - 2].transform.localPosition.z + 1);
            }
        }

		public void reset()
		{
			machine.GetComponent<FilterationProcess>().x = false;
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

