using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    public int poolSize = 30; 
    public Queue<GameObject> poolQueue = new Queue<GameObject>();

    void Awake()
    {
        if (objectPrefab == null)
        {
            Debug.LogError("ObjectPrefab is not assigned!");
        }
        else
        {
            Debug.Log("ObjectPool initialized.");
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false); 
            poolQueue.Enqueue(obj);
            Debug.Log("Object created and added to pool. Current pool size: " + poolQueue.Count);
        }
        PrintQueue(poolQueue);
    }
    void PrintQueue(Queue<GameObject> queue)
    {
        List<GameObject> queueList = new List<GameObject>(queue); 
        foreach (var obj in queueList)
        {
            Debug.Log("Object in queue: " + obj.name); 
        }
    }
    public GameObject GetObject()
    {

        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogWarning("Pool is empty! No objects available.");
            return null; 
        }
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        poolQueue.Enqueue(obj); 
    }
}
