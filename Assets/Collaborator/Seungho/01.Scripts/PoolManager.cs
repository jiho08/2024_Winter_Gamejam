using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObject
{
    public GameObject poolObject;
    public int poolCount;
}

public class PoolManager : MonoBehaviour
{
    public static List<PoolObject> PoolList = new List<PoolObject>();

    private void Awake()
    {
        for (int i = 0; i < PoolList.Count; i++)
        {
            for(int _ = 0; _ < PoolList[i].poolCount; _++)
            {
                Instantiate(PoolList[i].poolObject, transform);
            }
            
        }
    }

    public void Spawn(int num, Vector2 position)
    {
        if (transform.GetChild(PoolList[num].poolCount * num) != null)
        {
            PoolList[num].poolObject.SetActive(true);

            
        }
    }
}
