using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerArea_1 
{
	public static void Save(GameDataArea_1 data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Create);
		formatter.Serialize(fs, data);
		fs.Close();
	}
	public static GameDataArea_1 Load()
	{
		if (!File.Exists(GetPath()))
		{
			GameDataArea_1 emptyData = new GameDataArea_1();
			Save(emptyData);
			return emptyData;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Open);
		GameDataArea_1 data = formatter.Deserialize(fs) as GameDataArea_1;
		fs.Close();
		return data;
	}
	private static string GetPath()
	{
		return Application.persistentDataPath + "/area_data_1.txt";
	}
}
