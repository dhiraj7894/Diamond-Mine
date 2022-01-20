using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YellowText : MonoBehaviour
{
	private Diamond.Core.ShopeGoalText SGT;
	void Start()
	{
		SGT = transform.GetComponentInParent<Diamond.Core.ShopeGoalText>();
		SGT.requreYellowGemUI = GetComponent<TextMeshProUGUI>();
	}
}
