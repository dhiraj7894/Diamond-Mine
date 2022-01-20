using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueText : MonoBehaviour
{
	private Diamond.Core.ShopeGoalText SGT;
	void Start()
	{
		SGT = transform.GetComponentInParent<Diamond.Core.ShopeGoalText>();
		SGT.requreBlueGemUI = GetComponent<TextMeshProUGUI>();
	}
}
