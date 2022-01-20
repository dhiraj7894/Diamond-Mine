[System.Serializable]
public class GameDataArea_1
{
	public int IronMachine;
	public int DiamondOreMachine;
	public int FilterMachine;


	public float ironMachineSpeed;
	public int ironMachineSpeedCost;
	public float ironMachineCapacity;
	public int ironMachineCapacityCost;

	public float DiamondMachineSpeed;
	public int DiamondMachineSpeedCost;
	public float DiamondMachineCapacity;
	public int DiamondMachineCapacityCost;

	public float FilterMachineSpeed;
	public int FilterMachineSpeedCost;
	public float FilterMachineCapacity;
	public int FilterMachineCapacityCost;

	public GameDataArea_1()
	{
		IronMachine = 6;
		DiamondOreMachine = 5;
		FilterMachine = 7;

		ironMachineSpeed = 1;
		ironMachineSpeedCost = 5;

		ironMachineCapacity = 4;
		ironMachineCapacityCost = 5;

		DiamondMachineSpeed = 1;
		DiamondMachineSpeedCost = 5;

		DiamondMachineCapacity = 4;
		DiamondMachineCapacityCost = 5;

		FilterMachineSpeed = 1;
		FilterMachineSpeedCost = 20;

		FilterMachineCapacity=6;
		FilterMachineCapacityCost = 20;
	}
}
