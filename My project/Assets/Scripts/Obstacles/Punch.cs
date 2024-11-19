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
            collision.gameObject.SetActive(false);
            CrowdController.instance.totalClone--;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameController.instance.lastClone)
            {
                Debug.Log("Last Clone Has Been Eliminated");
                collision.gameObject.SetActive(false);
                CrowdController.instance.totalClone--;
                GameController.instance.gameLost = true;
            }

        }

    }
}
