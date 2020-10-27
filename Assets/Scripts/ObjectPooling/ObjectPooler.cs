using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefeb);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.SetParent(this.transform);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string _tag, Vector3 _position, Quaternion _rotation)
    {
        if(!poolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning($"Pool with tag {_tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[_tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = _position;
        objectToSpawn.transform.rotation = _rotation;

        poolDictionary[_tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

[System.Serializable]
public struct Pool{
    public string tag;
    public GameObject prefeb;
    public int size;
}
