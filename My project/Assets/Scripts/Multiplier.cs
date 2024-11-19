using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public float minRandomValue = 2;
    public float maxRandomValue = 5;
    public int totalClones;
    public CrowdController crowdController;

    private int randomValue;
    private bool isMultiply;
    private bool isTriggered; 
    private string symbol;

    void Start()
    {
        randomValue = Random.Range((int)minRandomValue, (int)maxRandomValue + 1);
        isMultiply = Random.value > 0.5f;
        symbol = isMultiply ? "x" : "+";

        this.GetComponentInChildren<TextMeshPro>().text = randomValue.ToString() + symbol;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isTriggered) return;

        if (!other.CompareTag("Player")) return;

        isTriggered = true;

        if (isMultiply)
        {
            if (CrowdController.Clones.Count == 0)
            {
                totalClones = randomValue - 1;
            }
            else
            {
                totalClones = (CrowdController.Clones.Count + 1) * randomValue;
            }
        }
        else
        {
            totalClones = CrowdController.Clones.Count + randomValue;
        }

        while (CrowdController.Clones.Count < totalClones)
        {
            crowdController.AddClone();
            CrowdController.instance.totalClone++;
        }

    }
}
