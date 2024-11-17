using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;

    public Material colorMaterial;


    private void OnTriggerEnter(Collider other)
    {
        skinnedMeshRenderer=other.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer == null)
        {
            Debug.Log("SkinnedMesh Renderer Componenti Ayarlanamadý");
        }
        else
        {
            skinnedMeshRenderer.materials = new Material[4] { colorMaterial, colorMaterial, colorMaterial, colorMaterial };
        }
    }

}
