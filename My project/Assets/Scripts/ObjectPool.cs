using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 30;

    [SerializeField] private GameObject clonePrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i<amountToPool; i++)
        {
            GameObject obj = Instantiate(clonePrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count ;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }



    /*public GameObject objectPrefab;  // Clone prefab'ýný buraya ekleyin
    public int poolSize = 30;
    private List<GameObject> objectPool = new List<GameObject>();

    private void Awake()
    {
        // Havuzun düzgün bir þekilde baþlatýlmasýný kontrol edelim
        if (objectPool.Count == 0)
        {
            Debug.Log("Object pool is being initialized...");

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(objectPrefab);
                obj.SetActive(false); // Nesneleri baþlangýçta pasif yap
                objectPool.Add(obj);  // Nesneleri havuza ekle
            }

            Debug.Log($"Object pool initialized. Pool size: {objectPool.Count}");
        }
        else
        {
            Debug.LogWarning("Object pool was already initialized.");
        }
    }

    // Havuzdaki nesneleri döndüren fonksiyon
    public List<GameObject> GetObjectPool()
    {
        if (objectPool == null || objectPool.Count == 0)
        {
            Debug.LogError("Object pool is not initialized or is empty!");
        }
        return objectPool;
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        Debug.LogWarning("No objects available in the pool!");
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }*/
}
