using UnityEngine;

public class AutoHandOffsetRotation : MonoBehaviour
{
    [Tooltip("Target for offset targets.")]
    public Transform[] targetOffsets;

    [Tooltip("Additional Euler offset applied.")]
    public Vector3 eulerOffset = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in targetOffsets)
        {
            item.transform.localEulerAngles = eulerOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
