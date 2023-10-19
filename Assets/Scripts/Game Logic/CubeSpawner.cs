using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("General Spawner Setup")]
    [SerializeField] private float _spawnDelay = 0.3f;
    [SerializeField] private GameObject _cubePrefab;

    private GameObject _startCube;

    private SwipeDetector _swipeDetector;
    private XAxisController _swipeHandler;
    private ZAxisController _forceYMovementHandler;

    private void Awake()
    {
        _startCube = FindObjectOfType<PointsController>().gameObject;

        _swipeDetector = FindObjectOfType<SwipeDetector>();
        _swipeHandler = FindObjectOfType<XAxisController>();
        _forceYMovementHandler = FindObjectOfType<ZAxisController>();
    }

    private void Start()
    {
        SetNewCube(_startCube);

        _swipeDetector.OnSwipeEnd += OnSwipeEnd;
    }

    private void OnSwipeEnd(Vector2 delta) => StartCoroutine(Spawn());

    private void SetNewCube(GameObject cube)
    {
        _swipeHandler.SetNewCube(cube);
        _forceYMovementHandler.SetNewCube(cube);
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnDelay);

        GameObject newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
        SetNewCube(newCube);
    }

    private void OnDestroy() => _swipeDetector.OnSwipeEnd -= OnSwipeEnd;
}
