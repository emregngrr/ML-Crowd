using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private ObjectPool objectPool;
    public static GameController instance;
    public bool lastClone;
    public bool gameLost=false;
    public TextMeshProUGUI cloneCountText;
    public Image menu;
    public int tempScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();

        if (objectPool == null)
        {
            Debug.LogError("ObjectPool script not found in the scene!");
        }
    }

    private void Update()
    {
        cloneCountText.text = (CrowdController.instance.totalClone-1).ToString();
        tempScore = CrowdController.instance.totalClone - 1;

        if (objectPool != null)
        {
            int activeClones = objectPool.GetActiveCloneCount();
            //Debug.Log($"Active Clones: {activeClones+1}");
            if (activeClones==0)
            {
                lastClone = true;
            }
            else 
            { 
                lastClone= false;
            }


            if (gameLost == true)
            {
                menu.gameObject.SetActive(true);
            }
        }
       
    }
}
