using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Diamond.Core
{
	public class speedFilterButton : MonoBehaviour
	{

		public Diamond.Control.FilterationProcess FP;
		public ParticleSystem upgrade;
		public TextMeshProUGUI updateAmount;
		public TextMeshProUGUI currentSpeed;

		public int CostToUpdate;
		public float waitTime;
		private GameManager gm;
		private Diamond.Core.AudioManager Am;
		// Start is called before the first frame update
		void Start()
		{
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
			gm = FindObjectOfType<GameManager>();
			waitTime = FP.WaitTimer;
		}

		// Update is called once per frame
		void Update()
		{
			if (waitTime > 0)
				updateAmount.text = CostToUpdate.ToString();
			if (waitTime <= 0.1)
			{
				updateAmount.text = "Max";
			}
			currentSpeed.text = (1.1f - waitTime).ToString("F1");
		}

		public void speedUp()
		{
			if (gm.MaxMoney >= CostToUpdate && waitTime > 0.1)
			{
				Am.source.PlayOneShot(Am.Upgrade);
				upgrade.Play();
				gm.MaxMoney -= CostToUpdate;
				CostToUpdate += 20;
				waitTime -= 0.1f;
				FP.WaitTimer = waitTime;
			}
		}
	}
}

