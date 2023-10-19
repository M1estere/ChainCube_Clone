using UnityEngine;

[System.Serializable]
public class MaterialProps
{
    [field: SerializeField] public long Points { get; private set; }
    [field: SerializeField] public Material PointsMaterial { get; private set; }
}