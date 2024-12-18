using NUnit.Framework;
using System;
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
    public List<PoolObject> poolList = new List<PoolObject>();


    public static List<PoolObject> PoolList { get; set; }
    
    
    private void Awake()
    {
        PoolList = poolList;

        for (int i = 0; i < PoolList.Count; i++)
        {
            for(int _ = 0; _ < PoolList[i].poolCount; _++)
            {
                var temp = Instantiate(PoolList[i].poolObject, transform);
                PoolList[i].poolStack.Push(temp);
                temp.SetActive(false);
            }
            
        }
    }

    public static void Spawn(int num, Transform owner)
    {
        switch (num)
        {
            case 0:
                if (PoolList[num].poolStack.Count != 0)
                {
                    var bulletpool = PoolList[num].poolStack.Pop();
                    bulletpool.transform.position = owner.position;
                    bulletpool.transform.rotation = owner.rotation;
                    bulletpool.GetComponent<Projectile>().owner = owner;
                    bulletpool.SetActive(true);
                }
                break;

            default:
                var pool = PoolList[num].poolStack.Pop();
                pool.transform.position = owner.position;
                pool.transform.rotation = Quaternion.identity;
                pool.SetActive(true);
                break;
        }
        
    }

    public static void Return(int num, GameObject poolObj)
    {
        PoolList[num].poolStack.Push(poolObj);
        poolObj.SetActive(false);
    }


    
}
