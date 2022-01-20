using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveManagerArea_3 : MonoBehaviour
{
	public static void Save(GameDataArea_3 data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Create);
		formatter.Serialize(fs, data);
		fs.Close();
	}
	public static GameDataArea_3 Load()
	{
		if (!File.Exists(GetPath()))
		{
			GameDataArea_3 emptyData = new GameDataArea_3();
			Save(emptyData);
			return emptyData;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fs = new FileStream(GetPath(), FileMode.Open);
		GameDataArea_3 data = formatter.Deserialize(fs) as GameDataArea_3;
		fs.Close();
		return data;
	}
	private static string GetPath()
	{
		return Application.persistentDataPath + "/area_data_3.txt";
	}
}
