using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Controller controllerscript;
    float runningSpeed;
    private void Start()
    {
        runningSpeed = controllerscript.runningSpeed;
    }
    void Update()
    {
        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
    }
}
