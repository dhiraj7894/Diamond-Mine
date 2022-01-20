using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Diamond.Core
{
	public class LevelManager : MonoBehaviour
	{
		GameManager gm;
		public GameObject LevelEndUI;
		public TextMeshProUGUI LevelText;
		public TextMeshProUGUI BonusText;
		public int BonusAmount;
		public int level;
		private Diamond.Core.AudioManager Am;
		private void Awake()
		{
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
			gm = GetComponent<GameManager>();
			LevelGenrator();
			bonusAmount();
		}
		void Start()
		{
			gm.TotalGem = gm.CurrentGem;
		}

		void Update()
		{		
			if(gm.TotalGem>=0)
				gm.CurrentGem = gm.RequreBlueGem + gm.RequreRedGem + gm.RequreYellowGem + gm.RequreBlackGem;

			LevelText.text = (level + 1).ToString();
			LevelManage();

			if (level == 1 && !isCamDone)
			{
				StartCoroutine(delayCam(2));
			}
		}

		public Animator Cam;
		public bool isCamDone = false;
		IEnumerator delayCam(float t)
		{
			yield return new WaitForSeconds(t);
			Cam.Play("T1");
			isCamDone = true;
		}
		public void LevelManage()
		{
			if (gm.CurrentGem <= 0)
			{				
				LevelEndUI.SetActive(true);				
				BonusText.text = BonusAmount.ToString();
			}
		}

		public void LevelGenrator()
		{			
			if(level == 0)
			{
				gm.RequreBlueGem = 5;
				gm.RequreRedGem = 0;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 1)
			{
				gm.RequreBlueGem = 10;
				gm.RequreRedGem = 0;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 2)
			{
				gm.RequreBlueGem = 8;
				gm.RequreRedGem = 0;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 3)
			{
				gm.RequreBlueGem = 12;
				gm.RequreRedGem = 0;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 4)
			{
				gm.RequreBlueGem = 15;
				gm.RequreRedGem = 0;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 5)
			{
				gm.RequreBlueGem = 25;
				gm.RequreRedGem = 20;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 6)
			{
				gm.RequreBlueGem = 25;
				gm.RequreRedGem = 25;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 7)
			{
				gm.RequreBlueGem = 45;
				gm.RequreRedGem = 35;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 8)
			{
				gm.RequreBlueGem = 35;
				gm.RequreRedGem = 15;
				gm.RequreYellowGem = 0;
				gm.RequreBlackGem = 0;
			}
			if (level == 9)
			{
				gm.RequreBlueGem = 25;
				gm.RequreRedGem = 25;
				gm.RequreYellowGem = 10;
				gm.RequreBlackGem = 0;
			}
			if (level == 10)
			{
				gm.RequreBlueGem = 55;
				gm.RequreRedGem = 35;
				gm.RequreYellowGem = 20;
				gm.RequreBlackGem = 0;
			}
			if (level == 11)
			{
				gm.RequreBlueGem = 45;
				gm.RequreRedGem = 45;
				gm.RequreYellowGem = 25;
				gm.RequreBlackGem = 0;
			}
			if (level == 12)
			{
				gm.RequreBlueGem = 55;
				gm.RequreRedGem = 25;
				gm.RequreYellowGem = 30;
				gm.RequreBlackGem = 0;
			}
			if (level == 13)
			{
				gm.RequreBlueGem = 15;
				gm.RequreRedGem = 15;
				gm.RequreYellowGem = 40;
				gm.RequreBlackGem = 0;
			}
			if (level == 14)
			{
				gm.RequreBlueGem = 35;
				gm.RequreRedGem = 15;
				gm.RequreYellowGem = 10;
				gm.RequreBlackGem = 20;
			}
			if (level == 15)
			{
				gm.RequreBlueGem = 25;
				gm.RequreRedGem = 25;
				gm.RequreYellowGem = 20;
				gm.RequreBlackGem = 30;
			}
			if (level >= 16)
			{
				gm.RequreBlueGem = Random.Range(15,50);
				gm.RequreRedGem = Random.Range(15, 50);
				gm.RequreYellowGem = Random.Range(15, 50);
				gm.RequreBlackGem = Random.Range(15, 50);
			}
			gm.CurrentGem = gm.RequreBlueGem + gm.RequreRedGem + gm.RequreYellowGem + gm.RequreBlackGem;						
		}


		public void bonusAmount()
		{
			if (level == 0)
			{
				BonusAmount = 250;
			}
			if (level == 1)
			{
				BonusAmount = 250;
			}
			if (level == 2)
			{
				BonusAmount = 270;
			}
			if (level == 3)
			{
				BonusAmount = 300;
			}
			if (level == 4)
			{
				BonusAmount = 330;
			}
			if (level == 5)
			{
				BonusAmount = 350;
			}
			if (level == 6)
			{
				BonusAmount = 350;
			}
			if (level == 7)
			{
				BonusAmount = 370;
			}
			if (level == 8)
			{
				BonusAmount = 380;
			}
			if (level == 9)
			{
				BonusAmount =390;
			}
			if (level == 10)
			{
				BonusAmount = 410;
			}
			if (level == 11)
			{
				BonusAmount = 420;
			}
			if (level == 12)
			{
				BonusAmount = 450;
			}
			if (level == 13)
			{
				BonusAmount = 500;
			}
			if (level == 14)
			{
				BonusAmount = 550;
			}
			if (level == 15)
			{
				BonusAmount = 600;
			}
			if (level >= 16)
			{
				BonusAmount =650;
			}
		}
		public void LevelUpButton()
		{			
			bonusAmount();
			level++;
			LevelGenrator();			
			LevelEndUI.transform.GetChild(0).GetComponent<Animator>().Play("Out");
			gm.MaxMoney += BonusAmount;
			gm.TotalGem = gm.CurrentGem;
			FindObjectOfType<Diamond.Control.shop>().countdownTimer = 0.5f;
		}


	}
}
