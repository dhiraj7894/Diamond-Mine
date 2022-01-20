using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Diamond.Core
{
	public class capacityButton : MonoBehaviour
	{
		public GameObject StorageArea;
		public ParticleSystem upgrade;

		public TextMeshProUGUI updateAmount;
		public TextMeshProUGUI capacity;

		public int capacityMultiplier;
		public int TotalCapacity;
		public int CostToUpdate;

		private GameManager gm;
		private Diamond.Core.AudioManager Am;
		private void Start()
		{
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
			gm = FindObjectOfType<GameManager>();
			try
			{
				TotalCapacity = StorageArea.GetComponent<Diamond.Control.MineMachine>().MaxMinedObjectCanStore;
			}
			catch
			{
				TotalCapacity = StorageArea.GetComponent<Diamond.Control.FilterMachine>().MaxMinedObjectCanStore;
			}
		}

		private void Update()
		{
			try
			{
				updateAmount.text = CostToUpdate.ToString();
				capacity.text = (StorageArea.GetComponent<Diamond.Control.MineMachine>().MaxMinedObjectCanStore + 1).ToString();
				
			}
			catch
			{
				capacity.text = (StorageArea.GetComponent<Diamond.Control.FilterMachine>().MaxMinedObjectCanStore + 1).ToString();
			}
		}
		public void capacityUp()
		{
			if (gm.MaxMoney >= CostToUpdate)
			{
				upgrade.Play();
				try
				{

					Am.source.PlayOneShot(Am.Upgrade);
					gm.MaxMoney -= CostToUpdate;					
					TotalCapacity += capacityMultiplier;					
					StorageArea.GetComponent<Diamond.Control.MineMachine>().MaxMinedObjectCanStore = TotalCapacity;					
					CostToUpdate += 10;
				}
				catch
				{
					Am.source.PlayOneShot(Am.Upgrade);
					gm.MaxMoney -= CostToUpdate;					
					TotalCapacity += TotalCapacity;
					StorageArea.GetComponent<Diamond.Control.FilterMachine>().MaxMinedObjectCanStore = TotalCapacity;
					CostToUpdate += 10;
				}
			}			
		}
	}
}
