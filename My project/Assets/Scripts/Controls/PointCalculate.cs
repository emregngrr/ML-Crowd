using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCalculate : MonoBehaviour
{

    public CrowdController crowdController;
    public GameController gameController;
    public int updatedCloneCount;
    public int pointRatio;
    public int totalPoint;
    public Image winner;
    public TextMeshProUGUI cloneCountText;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("PointRatio=" + pointRatio);
        Debug.Log("TotalPoint=" + totalPoint);

        if (collision.gameObject.CompareTag("Player"))
        {
            totalPoint = GameController.instance.tempScore * pointRatio;
            winner.gameObject.SetActive(true);
            winner.transform.GetChild(0).GetComponent<TextMeshPro>().text = "You WIN! \r\nSCORE:" + totalPoint;

        }
    }
}
