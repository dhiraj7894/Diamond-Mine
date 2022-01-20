using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Diamond.Control
{
    public class MachineUnlocker : MonoBehaviour
    {
        public MineMachine Machine;

        public GameObject LockedGFX;
        public GameObject UnlockedGFX;

        public TextMeshPro priceText;
		private Diamond.Core.AudioManager AM;

		private void Start()
		{
			AM = FindObjectOfType<Diamond.Core.AudioManager>();
		}

		void Update()
        {
            if(Machine.RequreObjects <= 0 && !Machine.isMachineUnlocked)
            {
                Unlock();
            }
            if (Machine.RequreObjects > 0)
            {
                priceText.text = Machine.RequreObjects.ToString();
                Lock();
            }
            
        }
        public void Unlock()
        {
			AM.source.PlayOneShot(AM.UnlockMachine);
            LockedGFX.SetActive(false);
            UnlockedGFX.SetActive(true);
            Machine.isMachineUnlocked = true;
            Machine.isUnlocked = true;
            Machine.isMachineLocked = false;
        }
        public void Lock()
        {
            LockedGFX.SetActive(true);
            UnlockedGFX.SetActive(false);
            Machine.isMachineUnlocked = false;
            Machine.isUnlocked = false;
            Machine.isMachineLocked = true;
        }
    }
}
