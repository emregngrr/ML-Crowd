using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Ground"))
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
