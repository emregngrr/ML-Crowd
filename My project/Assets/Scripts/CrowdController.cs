using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float CloneSpeed = 5;
    public int Gap = 10;

    public GameObject BodyPrefab;

    private List<GameObject> Clones = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    void Start()
    {
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
        AddClone();
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

            // Rotate body towards the point along the path
            //clone.transform.LookAt(point);
            clone.transform.rotation = Quaternion.identity;

            index++;
        }
    }

    private void AddClone()
    {
        GameObject clone = Instantiate(BodyPrefab, new Vector3(0,0,-2),Quaternion.identity);
        Clones.Add(clone);
    }
}
