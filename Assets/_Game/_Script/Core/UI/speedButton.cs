using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Diamond.Core
{
	public class speedButton : MonoBehaviour
	{
		public ParticleSystem upgrade;
		public Animator miningSpeed;

		public TextMeshProUGUI updateAmount;
		public TextMeshProUGUI currentSpeed;

		public float speedMultiplier;
		public int CostToUpdate;
		private GameManager gm;
		private Diamond.Core.AudioManager Am;

		[SerializeField]public float ProductionSpeed = 1;
		void Start()
		{
			miningSpeed.SetFloat("speed",ProductionSpeed);
			gm = FindObjectOfType<GameManager>();
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
		}

		private void Update()
		{
			updateAmount.text = CostToUpdate.ToString();
			currentSpeed.text = ((miningSpeed.GetFloat("speed") + speedMultiplier) - 1).ToString();

		}

		public void speedUp()
		{
			if (gm.MaxMoney >= CostToUpdate)
			{
				Am.source.PlayOneShot(Am.Upgrade);
				upgrade.Play();
				ProductionSpeed += speedMultiplier;
				gm.MaxMoney -= CostToUpdate;
				CostToUpdate += 20;
				miningSpeed.SetFloat("speed", ProductionSpeed);
			}			
		}		
	}
}
