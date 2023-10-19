using UnityEngine;

public class XAxisController : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField] private SwipeDetector _swipeDetector;
    [SerializeField, Tooltip("Increase to speed up movement")] private float _multiplier = 1;
    [Space(5)]

    [Header("Borders Setup")]
    [SerializeField] private Transform _leftFrontier;
    [SerializeField] private Transform _rightFrontier;
        
    private GameObject _currentCube;

    public void SetNewCube(GameObject dependency) => _currentCube = dependency;

    private void Start()
    {
        _swipeDetector.OnSwipeGoing += OnSwipe;
        _swipeDetector.OnSwipeEnd += OnSwipeEnd;
    }

    private void OnSwipe(Vector2 diff)
    {
        if (_currentCube == null) return;

        if (Mathf.Abs(diff.x - Mathf.Epsilon) <= 0) return;

        float borderDistance = Mathf.Abs(_rightFrontier.position.x - _leftFrontier.position.x);
        float screenOffset = (borderDistance * _multiplier * diff.x) / Screen.width;

        Vector3 currentPos = _currentCube.transform.position;
            
        _currentCube.transform.position = new Vector3(currentPos.x + screenOffset, currentPos.y, currentPos.z);

        if (_currentCube.transform.position.x > _rightFrontier.position.x) PlaceOnX(_currentCube.transform, _rightFrontier);
        else if (_currentCube.transform.position.x < _leftFrontier.position.x) PlaceOnX(_currentCube.transform, _leftFrontier);
    }

    private void OnSwipeEnd(Vector2 delta) => _currentCube = null;

    private void PlaceOnX(Transform objectToPlace, Transform whereToPlace)
    {
        Vector3 newPosition = objectToPlace.position;
        newPosition.x = whereToPlace.position.x;

        objectToPlace.position = newPosition;
    }

    private void OnDestroy()
    {
        _swipeDetector.OnSwipeGoing -= OnSwipe;
        _swipeDetector.OnSwipeEnd -= OnSwipeEnd;
    }
}