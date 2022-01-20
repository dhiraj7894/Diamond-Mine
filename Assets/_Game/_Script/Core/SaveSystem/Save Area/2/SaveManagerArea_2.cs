using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerArea_2 
{
	public static void Save(GameDataArea_2 data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Create);
		formatter.Serialize(fs, data);
		fs.Close();
	}
	public static GameDataArea_2 Load()
	{
		if (!File.Exists(GetPath()))
		{
			GameDataArea_2 emptyData = new GameDataArea_2();
			Save(emptyData);
			return emptyData;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Open);
		GameDataArea_2 data = formatter.Deserialize(fs) as GameDataArea_2;
		fs.Close();
		return data;
	}
	private static string GetPath()
	{
		return Application.persistentDataPath + "/area_data_2.txt";
	}
}
