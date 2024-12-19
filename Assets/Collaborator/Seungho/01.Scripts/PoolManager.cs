using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
            for (int _ = 0; _ < PoolList[i].poolCount; _++)
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

    public static void ProjectileSpawn(Transform owner, float bulletSpeed, bool isPenetration,
        bool isDiffuse, int bulletCount)
    {
        if (PoolList[0].poolStack.Count != 0)
        {
            if (isDiffuse)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    var bulletpool = PoolList[0].poolStack.Pop();
                    bulletpool.transform.position = owner.position;
                    Debug.Log(owner.parent);
                    bulletpool.transform.eulerAngles = owner.eulerAngles + new Vector3(0,0,Random.Range(-20, 20));

                    var bullet = bulletpool.GetComponent<Projectile>();

                    bullet.speed = bulletSpeed;
                    bullet.isPenetration = isPenetration;
                    bullet.isDiffuse = isDiffuse;



                    bulletpool.SetActive(true);
                }
            }
            else
            {
                var bulletpool = PoolList[0].poolStack.Pop();
                bulletpool.transform.position = owner.position;
                bulletpool.transform.rotation = owner.rotation;

                var bullet = bulletpool.GetComponent<Projectile>();

                bullet.speed = bulletSpeed;
                bullet.isPenetration = isPenetration;
                bullet.isDiffuse = isDiffuse;



                bulletpool.SetActive(true);
            }
            
            



            // bulletpool.GetComponent<Projectile>().owner = owner;
        }
    }

    public static void Return(int num, GameObject poolObj)
    {
        PoolList[num].poolStack.Push(poolObj);
        poolObj.SetActive(false);
    }
}