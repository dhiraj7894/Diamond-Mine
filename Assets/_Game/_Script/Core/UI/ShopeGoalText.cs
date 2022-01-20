using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Diamond.Core
{
	public class ShopeGoalText : MonoBehaviour
	{
		[Header("Gem Diamond UI")]

		public TextMeshProUGUI requreBlueGemUI;
		public TextMeshProUGUI requreRedGemUI;
		public TextMeshProUGUI requreYellowGemUI;
		public TextMeshProUGUI requreBlackGemUI;

		[Header("Gem UI")]
		public GameObject UI1;
		public GameObject UI2;
		public GameObject UI3;
		public GameObject UI4;

		private GameManager gm;
		void Start()
		{
			gm = FindObjectOfType<GameManager>();
		}

		void Update()
		{
			TextFinder();
			ShopUI();
		}

		public void ShopUI()
		{
			if (gm.RequreBlueGem >= 1 && gm.RequreRedGem <= 0 && gm.RequreYellowGem <= 0 && gm.RequreBlackGem <= 0)
			{
				UI1.SetActive(true);
				UI2.SetActive(false);
				UI3.SetActive(false);
				UI4.SetActive(false);
			}
			if (gm.RequreBlueGem >= 1 && gm.RequreRedGem >= 1 && gm.RequreYellowGem <= 0 && gm.RequreBlackGem <= 0)
			{
				UI1.SetActive(false);
				UI2.SetActive(true);
				UI3.SetActive(false);
				UI4.SetActive(false);
			}
			if (gm.RequreBlueGem >= 1 && gm.RequreRedGem >= 1 && gm.RequreYellowGem >= 1 && gm.RequreBlackGem <= 0)
			{
				UI1.SetActive(false);
				UI2.SetActive(false);
				UI3.SetActive(true);
				UI4.SetActive(false);
			}
			if (gm.RequreBlueGem >= 1 && gm.RequreRedGem >= 1 && gm.RequreYellowGem >= 1 && gm.RequreBlackGem >= 1)
			{
				UI1.SetActive(false);
				UI2.SetActive(false);
				UI3.SetActive(false);
				UI4.SetActive(true);
			}
		}

		public void TextFinder()
		{
			try
			{
				requreBlueGemUI.text = (gm.RequreBlueGem).ToString();
				requreRedGemUI.text = (gm.RequreRedGem).ToString();
				requreYellowGemUI.text = (gm.RequreYellowGem).ToString();
				requreBlackGemUI.text = (gm.RequreBlackGem).ToString();
			}
			catch
			{

			}
		}
	}

}
