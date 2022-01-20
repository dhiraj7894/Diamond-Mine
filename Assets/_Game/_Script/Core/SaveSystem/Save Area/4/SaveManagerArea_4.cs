using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerArea_4 : MonoBehaviour
{
	public static void Save(GameDataArea_4 data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Create);
		formatter.Serialize(fs, data);
		fs.Close();
	}
	public static GameDataArea_4 Load()
	{
		if (!File.Exists(GetPath()))
		{
			GameDataArea_4 emptyData = new GameDataArea_4();
			Save(emptyData);
			return emptyData;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Open);
		GameDataArea_4 data = formatter.Deserialize(fs) as GameDataArea_4;
		fs.Close();
		return data;
	}
	private static string GetPath()
	{
		return Application.persistentDataPath + "/area_data_4.txt";
	}
}
