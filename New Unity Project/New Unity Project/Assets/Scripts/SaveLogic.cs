using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLogic
{
    public static void SaveWorld(WorldSystem worldScript)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/world.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        WorldData data = new WorldData(worldScript);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static WorldData LoadWorld()
    {
        string path = Application.persistentDataPath + "/world.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WorldData data = formatter.Deserialize(stream) as WorldData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }
}
