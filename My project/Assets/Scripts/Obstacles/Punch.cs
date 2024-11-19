using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Punch : MonoBehaviour
{
    public GameController gameController;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Clone"))
        {
            Debug.Log("Tag == Clone");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tag == Player");
            Debug.Log("LastCLone:" + GameController.instance.lastClone);

            if (GameController.instance.lastClone)
            {
                Debug.Log("Last Clone Has Been Eliminated");
                collision.gameObject.SetActive(false);
                GameController.instance.gameLost = true;
            }

        }

    }
}
