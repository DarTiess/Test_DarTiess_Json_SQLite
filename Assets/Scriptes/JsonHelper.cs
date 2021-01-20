using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static List<T> FromJson<T>(string jsonArray)
    {
        jsonArray = WrapArray(jsonArray);
        return FromJsonWrapped<T>(jsonArray);
    }

    public static List<T> FromJsonWrapped<T>(string jsonObject)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonObject);
        return wrapper.items;
    }

    private static string WrapArray(string jsonArray)
    {
        return  jsonArray ;
       
    }

    public static string ToJson<T>(List<T> array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(List<T> array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public List<T> items;
    }

}
