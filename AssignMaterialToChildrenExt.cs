using NaughtyAttributes;
using UnityEngine;

public class AssignMaterialToChildrenExt : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject targetGhost;
    [SerializeField] private Material material;
    [SerializeField] private Material ghostMaterial;
    [SerializeField] private bool includeParent = true;
    [SerializeField] private bool createGhostOnStart = false;

    void Start()
    {
       if(target == null) target = gameObject;

        if (createGhostOnStart) CreateGhost();
    }

    void SetGhostActive(bool show)
    {
        foreach (Transform g in targetGhost.transform)
        {
            g.gameObject.SetActive(show);
        }
    }

    [Button]
    void HideGhost()
    {
        SetGhostActive(false);
    }

    [Button]
    void ShowGhost()
    {
        SetGhostActive(true);
    }

    [Button]
    void CreateGhost()
    {
        if (target == null) target = gameObject;

        targetGhost = Instantiate(target, transform);
        targetGhost.name = target.name + " GHOST";
        AssignMaterial(targetGhost, ghostMaterial);
    }

    [Button]
    void RemoveGhost()
    {
        if (targetGhost == null) return;
        DestroyImmediate(targetGhost);
        targetGhost = null;
    }

    [Button]
    void AssignMaterial(GameObject g, Material m)
    {
        if (m == null)
        {
            Debug.LogWarning("No material assigned in " + g.name);
            return;
        }

        // Get all MeshRenderers in children (and optionally in the parent)
        MeshRenderer[] renderers = g.GetComponentsInChildren<MeshRenderer>(includeParent);

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = m; // assigns the material
        }

        Debug.Log($"Assigned {m.name} to {renderers.Length} MeshRenderer(s).");
    }

    [Button]
    void Assign()
    {
        if (target == null) target = gameObject;

        if (material == null)
        {
            Debug.LogWarning("No material assigned in " + target.name);
            return;
        }

        // Get all MeshRenderers in children (and optionally in the parent)
        MeshRenderer[] renderers = target.GetComponentsInChildren<MeshRenderer>(includeParent);

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = material; // assigns the material
        }

        Debug.Log($"Assigned {material.name} to {renderers.Length} MeshRenderer(s).");
    }
}
