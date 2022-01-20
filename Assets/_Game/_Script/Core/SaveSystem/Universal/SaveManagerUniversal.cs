using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerUniversal 
{
	public static void Save(GameDataUniversal data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Create);
		formatter.Serialize(fs, data);
		fs.Close();
	}
	public static GameDataUniversal Load()
	{
		if (!File.Exists(GetPath()))
		{
			GameDataUniversal emptyData = new GameDataUniversal();
			Save(emptyData);
			return emptyData;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Open);
		GameDataUniversal data = formatter.Deserialize(fs) as GameDataUniversal;
		fs.Close();
		return data;
	}
	private static string GetPath()
	{
		return Application.persistentDataPath + "/universal_data.txt";
	}
}
