using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Diamond.Core
{
    public class GameManager : MonoBehaviour
    {
        public int StackingLimit;

		public int moneyCountingSpeed;
		public int MaxMoney;




		private float currentMoney;

		[Header("UI")]
		public TextMeshProUGUI maxMoney;

		[Header("Goal Diamond Text")]
		public int RequreBlueGem;
		public int RequreRedGem;
		public int RequreYellowGem;
		public int RequreBlackGem;

		public int CurrentGem;
		public int TotalGem;

		[Header("Gem Diamond UI")]
		public TextMeshProUGUI requreGemUI;		
		public TextMeshProUGUI requreBlueGemUI;
		public TextMeshProUGUI requreRedGemUI;
		public TextMeshProUGUI requreYellowGemUI;
		public TextMeshProUGUI requreBlackGemUI;

		[Header("Gem UI")]
		public GameObject UI1;
		public GameObject UI2;
		public GameObject UI3;
		public GameObject UI4;

		void Update()
        {
			maxMoney.text = currentMoney.ToString("F0");
			currentMoney = MaxMoney;
			preventFromNegativeVal();
			MoneyCounter();
			requreGemUI.text = (TotalGem - CurrentGem) + "/" + TotalGem;
		}

		public void preventFromNegativeVal()
		{
			RequreBlueGem = (int)Mathf.Clamp(RequreBlueGem, 0, Mathf.Infinity);
			RequreRedGem = (int)Mathf.Clamp(RequreRedGem, 0, Mathf.Infinity);
			RequreYellowGem = (int)Mathf.Clamp(RequreYellowGem, 0, Mathf.Infinity);
			RequreBlackGem = (int)Mathf.Clamp(RequreBlackGem, 0, Mathf.Infinity);
		}
		public void ShopUI()
		{
			if(RequreBlueGem>0 && RequreRedGem<=0 && RequreYellowGem<=0&& RequreBlackGem <= 0)
			{
				UI1.SetActive(true);
				UI2.SetActive(false);
				UI3.SetActive(false);
				UI4.SetActive(false);
			}
			if (RequreBlueGem > 0 && RequreRedGem > 0 && RequreYellowGem <= 0 && RequreBlackGem <= 0)
			{
				UI1.SetActive(false);
				UI2.SetActive(true);
				UI3.SetActive(false);
				UI4.SetActive(false);
			}
			if (RequreBlueGem > 0 && RequreRedGem > 0 && RequreYellowGem >0 && RequreBlackGem <= 0)
			{
				UI1.SetActive(false);
				UI2.SetActive(false);
				UI3.SetActive(true);
				UI4.SetActive(false);
			}
			if (RequreBlueGem > 0 && RequreRedGem > 0 && RequreYellowGem > 0 && RequreBlackGem > 0)
			{
				UI1.SetActive(false);
				UI2.SetActive(false);
				UI3.SetActive(false);
				UI4.SetActive(true);
			}
		}
		public void textFinder()
		{
			try
			{			
				requreBlueGemUI = GameObject.FindGameObjectWithTag("BlueDiamond").GetComponent<TextMeshProUGUI>();
				
				requreRedGemUI = GameObject.FindGameObjectWithTag("RedDiamond").GetComponent<TextMeshProUGUI>();
				requreRedGemUI.text = (RequreRedGem).ToString();
				requreYellowGemUI = GameObject.FindGameObjectWithTag("YellowDiamond").GetComponent<TextMeshProUGUI>();
				
				requreBlackGemUI = GameObject.FindGameObjectWithTag("BlackDiamond").GetComponent<TextMeshProUGUI>();
				
			}
			catch
			{

			}
		}
		public void MoneyCounter()
		{
			if (currentMoney <= MaxMoney)
			{
				currentMoney += moneyCountingSpeed * Time.deltaTime;
				if (currentMoney >= MaxMoney)
				{
					currentMoney = MaxMoney;
				}
			}
			if (currentMoney >= MaxMoney)
			{
				currentMoney -= moneyCountingSpeed * Time.deltaTime;
				if (currentMoney <= MaxMoney)
				{
					currentMoney = MaxMoney;
				}
			}
		}
	}
}
