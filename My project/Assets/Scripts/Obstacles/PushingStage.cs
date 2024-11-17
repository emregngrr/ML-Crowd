using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingStage : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Clone"))
        {
            Debug.Log("Tag == Clone");
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tag == Player");
            this.gameObject.SetActive(false);
            
        }
        
    }

}
