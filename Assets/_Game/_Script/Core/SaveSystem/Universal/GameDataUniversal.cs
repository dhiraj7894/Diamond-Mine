[System.Serializable]
public class GameDataUniversal
{
	public int TotalMoney;
	public int Level;

	public bool Level_2;
	public bool Level_2_Cam;

	public bool Level_3;
	public bool Level_3_Cam;

	public bool Level_4;
	public bool Level_4_Cam;
	public GameDataUniversal()
	{
		TotalMoney = 0;
		Level = 0;

		Level_2 = false;
		Level_3 = false;
		Level_4 = false;

		Level_2_Cam = false;
		Level_3_Cam = false;
		Level_4_Cam = false;

	}
}
