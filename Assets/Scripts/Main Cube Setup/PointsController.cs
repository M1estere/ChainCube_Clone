using UnityEngine;

[RequireComponent(typeof(CubeDisplay))]
public class PointsController : MonoBehaviour
{
    public int CubesCollisions { get; set; }

    public long Points
    {
        get => _points;
        set
        {
            if (_points == value) return;

            _points = value;
            PointsChanged();
        }
    }

    [SerializeField] private long _points;

    private NewCubesController _newCubesController;
    private ScoreController _scoreController;
    private CubeDisplay _cubeView;

    private void Awake() 
    { 
        _cubeView = GetComponent<CubeDisplay>();
        _scoreController = FindObjectOfType<ScoreController>();
        _newCubesController = FindObjectOfType<NewCubesController>();
    }

    private void Start() => PointsChanged();

    public void IncreasePoints()
    {
        _points *= 2;
        _scoreController.IncreaseScore(_points);
        _newCubesController.CheckNewCube(_points);

        PointsChanged();
    }

    private void PointsChanged() 
    {
        _cubeView.SetPoints(_points);
    }
}
