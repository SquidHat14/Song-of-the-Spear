using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.beep";
        FileStream FileWrite = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(FileWrite, data);

        FileWrite.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.beep";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream FileRead = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(FileRead) as PlayerData;

            FileRead.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not Found" + path);
            return null;
        }
    }
}

