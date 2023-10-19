using UnityEngine;

[RequireComponent(typeof(PointsController))]
public class RandomPointsGiver : MonoBehaviour
{
    [Header("Limit Values Setup")]
    [SerializeField] private int _minValue = 1;
    [SerializeField] private int _maxValue = 4;
        
    private PointsController _pointsContainer;

    private void Start()
    {
        _pointsContainer = GetComponent<PointsController>();
        _pointsContainer.Points = (int)Mathf.Pow(2, Random.Range(_minValue, _maxValue));
    }
}
