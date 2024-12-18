using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObject
{
    public GameObject poolObject;
    public int poolCount;
    public Stack<GameObject> poolStack = new Stack<GameObject>();
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
                PoolList[i].poolStack.Push(Instantiate(PoolList[i].poolObject, transform));
            }
            
        }
    }

    public static void Spawn(int num, Vector2 position)
    {
        if (PoolList[num].poolStack.Count != 0)
        {
            var pool = PoolList[num].poolStack.Pop();
            pool.transform.position = position;
            pool.transform.rotation = Quaternion.identity;
            pool.SetActive(true);
        }
    }

    public static void Return(int num, GameObject poolObj)
    {
        PoolList[num].poolStack.Push(poolObj);
        poolObj.SetActive(false);
    }
}
