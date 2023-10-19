using UnityEngine;

public class ZAxisController : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField, Range(15, 45)] private float _impulseForce = 25f;
    [SerializeField] private SwipeDetector _swipeDetector;

    private Rigidbody _cubeRigidbody;

    private void Start() => _swipeDetector.OnSwipeEnd += OnSwipeEnd;

    public void SetNewCube(GameObject cube) => _cubeRigidbody = cube.GetComponent<Rigidbody>();

    private void OnSwipeEnd(Vector2 temp)
    {
        if (_cubeRigidbody == null) return;

        if (_cubeRigidbody.gameObject.TryGetComponent(out TrailController _trailController)) 
            _trailController.DisableTrail();

        _cubeRigidbody.AddForce(_cubeRigidbody.transform.forward * _impulseForce, ForceMode.Impulse);

        _cubeRigidbody = null;
    }

    private void OnDestroy() => _swipeDetector.OnSwipeEnd -= OnSwipeEnd;
}
