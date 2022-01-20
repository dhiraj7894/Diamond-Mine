using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadUniversal : MonoBehaviour
{
	public Diamond.Core.LevelManager lv;
	public Diamond.Core.GameManager gm;

	[Header("Unlock Area")]
	public Diamond.Core.UnlockArea Level2;
	public Diamond.Core.UnlockArea Level3;
	public Diamond.Core.UnlockArea Level4;





	public GameDataUniversal data;
	private void Awake()
	{
		data = SaveManagerUniversal.Load();
		LoadGame();
	}

	public void SaveGame()
	{
		data.TotalMoney = gm.MaxMoney;
		data.Level = lv.level;

		data.Level_2 = Level2.isUnlocked;
		data.Level_2_Cam = Level2.isCinematicCam;

		data.Level_3 = Level3.isUnlocked;
		data.Level_3_Cam = Level3.isCinematicCam;

		data.Level_4 = Level4.isUnlocked;
		data.Level_4_Cam = Level4.isCinematicCam;

		SaveManagerUniversal.Save(data);
		print("UNIVERSAL DATA SAVED");
	}
	public void LoadGame()
	{
		gm.MaxMoney = data.TotalMoney;
		lv.level = data.Level;

		Level2.isUnlocked = data.Level_2;
		Level2.isCinematicCam = data.Level_2_Cam;

		Level3.isUnlocked = data.Level_3;
		Level3.isCinematicCam = data.Level_3_Cam;

		Level4.isUnlocked = data.Level_4;
		Level4.isCinematicCam = data.Level_4_Cam;

		print("UNIVERSAL DATA LOADED");
	}
}
