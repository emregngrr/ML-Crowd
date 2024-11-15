using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float CloneSpeed = 5;
    public int Gap = 10;

    public ObjectPool objectPool;

    private List<GameObject> Clones = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    void Awake()
    {
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool is not assigned!");
        }
        else
        {
            Debug.Log("CrowdController initialized.");
        }
    }

    void Update()
    {

        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;

        PositionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var clone in Clones)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];
            Vector3 moveDirection;

            switch (index % 3)
            {
                case 0:
                    // Sað arka sýra
                    moveDirection = point - clone.transform.position + new Vector3(3, 0, -3);
                    break;
                case 1:
                    // Orta arka sýra
                    moveDirection = point - clone.transform.position + new Vector3(0, 0, -3);
                    break;
                case 2:
                    // Sol arka sýra
                    moveDirection = point - clone.transform.position + new Vector3(-3, 0, -3);
                    break;
                default:
                    moveDirection = point - clone.transform.position;
                    break;
            }

            clone.transform.position += moveDirection * CloneSpeed * Time.deltaTime;
            clone.transform.rotation = Quaternion.identity;

            index++;
        }
    }

    public void AddClone()
    {
        int a = objectPool.poolQueue.Count;
        Debug.Log("PoolSize******=" + a);

        GameObject clone = objectPool.GetObject();

        if (clone != null) 
        {
            clone.transform.position = transform.position;
            clone.transform.rotation = Quaternion.identity;
            clone.SetActive(true);

            if (!Clones.Contains(clone)) 
            {
                Clones.Add(clone);
                Debug.Log("Clone added. Current count: " + Clones.Count);
            }
        }
        else
        {
            Debug.LogWarning("No available objects in the pool!");
        }
    }

    public void RemoveClone(GameObject clone)
    {
        Clones.Remove(clone);
        objectPool.ReturnObject(clone); 
    }
}
