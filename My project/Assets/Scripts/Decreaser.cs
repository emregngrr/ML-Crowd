using TMPro;
using UnityEngine;

public class Decreaser : MonoBehaviour
{
    public int characterCount = 1;
    public float minRandomValue = 2;
    public float maxRandomValue = 5;
    public CrowdController crowdController; 

    private int randomValue;

    private void Start()
    {
        randomValue = Random.Range((int)minRandomValue, (int)maxRandomValue + 1);
        this.GetComponentInChildren<TextMeshPro>().text = randomValue.ToString() + "-";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clone"))
        {
            if (characterCount > 0 && randomValue > 0)
            {
                other.gameObject.SetActive(false);
                CrowdController.instance.totalClone--;
                characterCount--;
                randomValue--;

            }
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            if (GameController.instance.lastClone)
            {
                other.gameObject.SetActive(false);
                CrowdController.instance.totalClone--;
                GameController.instance.gameLost = true;
            }
        }
    }
}