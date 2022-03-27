using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;        
        public GameObject objectToPool;
        public int amountToPool;
        public string parentName;
    }
        public Dictionary<string,List<GameObject>> poolDictionary;
        public List<Pool> pools;
        public List<GameObject> objectPool;

    #region Singleton           

    public static ObjectPooler instance;
    
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    { 
        poolDictionary = new Dictionary<string, List<GameObject>>();
        CreatePool();
    }
    
    public void CreatePool()
    {    
        foreach (Pool pool in pools)
        {
            objectPool = new List<GameObject>();
            for (int i = 0; i <pool.amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.objectToPool);
                obj.SetActive(false);
                objectPool.Add(obj);

                GameObject parent = GameObject.Find(pool.parentName);
                obj.transform.SetParent(parent.transform); // set as children of a choosen parent
            }
            poolDictionary.Add(pool.tag,objectPool);
        }
    }

    public GameObject GetPooledObject(string tagFromDictionary)
    {
        List<GameObject> getPoolList = poolDictionary[tagFromDictionary];
        for (int i = 0; i < getPoolList.Count; i++)
        {
            if (!getPoolList[i].activeInHierarchy)
            {
                return getPoolList[i];
            }
        }                   
        return null;
    }
}
