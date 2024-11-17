using UnityEngine;

public class GameController : MonoBehaviour
{
    private ObjectPool objectPool;

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
        if (objectPool != null)
        {
            int activeClones = objectPool.GetActiveCloneCount();
            //Debug.Log($"Active Clones: {activeClones+1}");
        }
    }
}
