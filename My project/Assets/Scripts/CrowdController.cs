using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float CloneSpeed = 5;
    public int Gap = 10;

    public GameObject objectPrefab;
    public int poolSize = 30;
    private List<GameObject> objectPool = new List<GameObject>();

    public static List<GameObject> Clones = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private ObjectPool objectPoolScript;

    private void Awake()
    {
        // ObjectPool'u bulma ve baþlatma iþlemini doðru yapalým
        objectPoolScript = FindObjectOfType<ObjectPool>();

        if (objectPoolScript != null)
        {
            //objectPool = objectPoolScript.GetObjectPool();
            Debug.Log($"ObjectPool reference found. Pool size: {objectPool.Count}");
        }
        else
        {
            Debug.LogError("ObjectPool script not found in the scene!");
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
                    moveDirection = point - clone.transform.position + new Vector3(3, 0, -3);
                    break;
                case 1:
                    moveDirection = point - clone.transform.position + new Vector3(0, 0, -3);
                    break;
                case 2:
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

        GameObject clone = ObjectPool.instance.GetPooledObject();

        if(clone != null)
        {
            clone.SetActive(true);
        }

        /*// Eðer havuz boþsa, hatayý logla
        if (objectPool == null || objectPool.Count == 0)
        {
            Debug.LogError("Object pool is not initialized or is empty!");
            return;
        }

        GameObject availableObj = objectPool.Find(obj => !obj.activeInHierarchy);
        if (availableObj != null)
        {
            availableObj.SetActive(true);
            availableObj.transform.position = transform.position;
            availableObj.transform.rotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("No objects available in the pool!");
        }*/
    }
}
