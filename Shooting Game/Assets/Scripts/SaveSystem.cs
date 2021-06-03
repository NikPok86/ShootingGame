/*using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void SaveWave (EnemySpawner enemySpawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/waves.BSG";
        FileStream stream = new FileStream(path, FileMode.Create);

        WavesData data = new WavesData(enemySpawner);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static WavesData LoadWaves()
    {
        string path = Application.persistentDataPath + "waves.BSG";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WavesData data = formatter.Deserialize(stream) as WavesData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}*/
