using UnityEngine;

public class CharacterColor : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    public Color CurrentColor;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            CurrentColor = skinnedMeshRenderer.material.color;
        }
    }
}
