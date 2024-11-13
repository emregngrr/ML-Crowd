using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{

    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float CloneSpeed = 5;
    public int Gap = 10;
    //D�ng�
    private int temp = 1;


    public GameObject BodyPrefab;

    private List<GameObject> Clones = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private Vector3 moveDirection = new Vector3(0,0,0);

    void Start()
    {
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

            switch (temp)
            {
                case 1:
                    //Sa� arka s�ra
                    Debug.Log("Case 1:"+moveDirection);
                    moveDirection = point - clone.transform.position + new Vector3(3, 0, -1);
                    break;
                case 2:
                    //Orta arka s�ra
                    Debug.Log("Case 2:" + moveDirection);
                    moveDirection = point - clone.transform.position + new Vector3(0, 0, -1);
                    break;
                case 3:
                    //Sol arka s�ra
                    Debug.Log("Case 3:" + moveDirection);
                    moveDirection = point - clone.transform.position + new Vector3(-3, 0, -1);
                    break;

            }
            /*
            //Sa� arka s�ra
            Vector3 moveDirection = point - clone.transform.position + new Vector3(3,0,-1);
            //Orta arka s�ra
            Vector3 moveDirection = point - clone.transform.position + new Vector3(3, 0, -1);
            //Sol arka s�ra
            Vector3 moveDirection = point - clone.transform.position + new Vector3(3, 0, -1);
            */

            clone.transform.position += moveDirection * CloneSpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            clone.transform.LookAt(point);
            temp++;
            if (temp > 3)
                temp = 1;
            index++;
        }
    }

    private void AddClone()
    {
         GameObject clone = Instantiate(BodyPrefab);
         Clones.Add(clone);
    }
}