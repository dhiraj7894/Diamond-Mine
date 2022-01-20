using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadArea_4 : MonoBehaviour
{
	public Diamond.Control.MineMachine IronMachine;
	public Diamond.Control.MineMachine DiamondMachine;
	public Diamond.Control.FilterMachine FilterMachine;

	[Header("Iron Machine")]
	public Diamond.Core.speedButton IMSB;
	public Diamond.Core.capacityButton IMCB;

	[Header("Diamond Mine")]
	public Diamond.Core.speedButton DMSB;
	public Diamond.Core.capacityButton DMCB;

	[Header("Filter Machine")]
	public Diamond.Core.speedFilterButton SFB;
	public Diamond.Core.capacityButton FMCB;


	public GameDataArea_4 data;

	private void Awake()
	{
		data = SaveManagerArea_4.Load();
		LoadGame();
	}

	public void SaveGame()
	{
		data.IronMachine = IronMachine.RequreObjects;
		data.DiamondOreMachine = DiamondMachine.RequreObjects;
		data.FilterMachine = FilterMachine.RequreObjects;

		data.ironMachineSpeed = IMSB.ProductionSpeed;
		data.ironMachineSpeedCost = IMSB.CostToUpdate;

		data.DiamondMachineSpeed = DMSB.ProductionSpeed;
		data.DiamondMachineSpeedCost = DMSB.CostToUpdate;

		data.FilterMachineSpeed = SFB.waitTime;
		data.FilterMachineSpeedCost = SFB.CostToUpdate;

		data.ironMachineCapacity = IronMachine.MaxMinedObjectCanStore;
		data.ironMachineCapacityCost = IMCB.CostToUpdate;

		data.DiamondMachineCapacity = DiamondMachine.MaxMinedObjectCanStore;
		data.DiamondMachineCapacityCost = DMCB.CostToUpdate;

		data.FilterMachineCapacity = FilterMachine.MaxMinedObjectCanStore;
		data.FilterMachineCapacityCost = FMCB.CostToUpdate;


		SaveManagerArea_4.Save(data);
		print("AREA_2 DATA SAVED");
	}
	public void LoadGame()
	{
		IronMachine.RequreObjects = data.IronMachine;
		DiamondMachine.RequreObjects = data.DiamondOreMachine;
		FilterMachine.RequreObjects = data.FilterMachine;

		IMSB.ProductionSpeed = data.ironMachineSpeed;
		IMSB.CostToUpdate = data.ironMachineSpeedCost;

		DMSB.ProductionSpeed = data.DiamondMachineSpeed;
		DMSB.CostToUpdate = data.DiamondMachineSpeedCost;

		FilterMachine.GetComponent<Diamond.Control.FilterationProcess>().WaitTimer = data.FilterMachineSpeed;
		SFB.CostToUpdate = data.FilterMachineSpeedCost;


		IronMachine.MaxMinedObjectCanStore = (int)data.ironMachineCapacity;
		IMCB.CostToUpdate = data.ironMachineCapacityCost;

		DiamondMachine.MaxMinedObjectCanStore = (int)data.DiamondMachineCapacity;
		DMCB.CostToUpdate = data.DiamondMachineCapacityCost;

		FilterMachine.MaxMinedObjectCanStore = (int)data.FilterMachineCapacity;
		FMCB.CostToUpdate = data.FilterMachineCapacityCost;


		print("AREA_2 DATA LOADED");
	}
}
