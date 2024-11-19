using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform stackingPoint; // Klonlarýn sýralanacaðý nokta
    public float verticalOffset = 1.5f; // Klonlarýn üst üste yerleþme mesafesi


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Helal La :D");
            StackClones();
        }
    }
    public void StackClones()
    {
        // Aktif klonlarýn listesini al
        List<GameObject> activeClones = new List<GameObject>();

        foreach (var clone in CrowdController.Clones)
        {
            if (clone.activeSelf)
            {
                activeClones.Add(clone);
            }
        }

        // Klonlarý sýrayla yerleþtir
        for (int i = 0; i < activeClones.Count; i++)
        {
            GameObject clone = activeClones[i];
            Vector3 newPosition = stackingPoint.position + new Vector3(0, i * verticalOffset, 0);
            clone.transform.position = newPosition;
            clone.transform.rotation = Quaternion.identity;
        }

        // En üste ana karakteri yerleþtir
        if (CrowdController.instance.player != null)
        {
            Vector3 playerPosition = stackingPoint.position + new Vector3(0, activeClones.Count * verticalOffset, 0);
            CrowdController.instance.player.transform.position = playerPosition;
            CrowdController.instance.player.transform.rotation = Quaternion.identity;
        }
    }
}
