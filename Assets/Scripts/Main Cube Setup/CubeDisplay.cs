using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeDisplay : MonoBehaviour
{
    [Header("Changing Elements Setup")]
    [SerializeField] private TextMeshPro[] _texts;
    [Space(5)]

    [SerializeField] private List<MaterialProps> _props = new();

    private MeshRenderer _renderer;

    private void Awake() => _renderer = GetComponent<MeshRenderer>();

    public void SetPoints(long points)
    {
        foreach (TextMeshPro text in _texts)
        {
            text.text = points.ToString();

            MaterialProps props = new();
            foreach (MaterialProps materialProps in _props)
                if (materialProps.Points == points) props = materialProps;
                
            if (props == null) _renderer.material = default;
            else _renderer.material = props.PointsMaterial;
        }
    }
}