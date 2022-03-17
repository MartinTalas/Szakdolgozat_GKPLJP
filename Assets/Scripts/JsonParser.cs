using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public sealed class JsonParser
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ SINGLETON PATTERN ]--------------------------------------------------------------------

    private static readonly Lazy<JsonParser> lazy = new Lazy<JsonParser>(() => new JsonParser());

    public static JsonParser Instance { get { return lazy.Value; } }

    private JsonParser()
    {
        
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ PARSING FUNCTIONS ]--------------------------------------------------------------------

    public void toJson<T>(T obj, string filename) //DEBUG WITH STRING RETURN
    {
        string json = JsonUtility.ToJson(obj, true);

        string path = Application.persistentDataPath + "/" +filename + ".json";
        File.WriteAllText(path, json);
    }

    public T toObject<T>(string filename) //DEBUG WITH STRING RETURN
    {
        string json;
        string path = Application.persistentDataPath + "/" + filename + ".json";


        json = File.ReadAllText(path);

        T obj;
        obj = JsonUtility.FromJson<T>(json);
        
        return obj;
    }


    // [ DEGUG ]            [ DEGUG ]            [ DEGUG ]            [ DEGUG ]            [ DEGUG ]            [ DEGUG ]            [ DEGUG ]            [ DEGUG ]
    /*
    public string getTESTText()
    {
        string json = "{ \"test\": \"test1\"}";
        /*string path = "test.json";//Path.Combine(Application.persistentDataPath, "test" + ".json");
        //File.WriteAllText(Application.dataPath + path, json);
        using (StreamReader stream = new StreamReader(Application.dataPath + path))
        {
            json = stream.ReadToEnd();
        }

        
        string pt = Path.Combine(Application.dataPath, "test" + ".json");
        File.WriteAllText(pt, json);
        string result = File.ReadAllText(pt); *./


        string pt = Application.persistentDataPath + "/test" + ".json";
        File.WriteAllText(pt, json);
        string result = File.ReadAllText(pt);

        return pt;
    }
    */
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
