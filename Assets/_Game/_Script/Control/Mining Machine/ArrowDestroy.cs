using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
	public Diamond.Control.MachineUnlocker MC;
	public GameObject otherObject;
	private void Start()
	{
		this.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (MC.Machine.RequreObjects <= 0 || MC.Machine.isMachineUnlocked)
		{
			otherObject.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
