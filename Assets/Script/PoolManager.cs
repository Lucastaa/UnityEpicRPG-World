using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        //truy cap cac doi tuong nhan roi trong nhom da chon
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //neu tim thay gan cho bien select
                select = item;
                select.SetActive(true);
                break;

            }
        }

        //neu khong tim thay
        if (!select)
        {
            //tao mot cai moi va gan cho no select
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
