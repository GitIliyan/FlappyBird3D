using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore(int highScore)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/FlappyBirdSave";
        var stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, highScore);
        stream.Close();
    }

    public static int LoadScore()
    {
        var path = Application.persistentDataPath + "/FlappyBirdSave";
        if(File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var highScore =  (int)formatter.Deserialize(stream);

            stream.Close();
            return highScore;
        }
        else
        {
            return 0;
        }
    }
}
