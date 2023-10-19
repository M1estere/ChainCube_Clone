using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PointsController), typeof(Rigidbody))]
public class PointsCollisionDetection : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField] private float _upImpulseForce = 2;
    [Space(5)]

    [Header("Scaling Effect Setup")]
    [SerializeField] private float _newScaleValue = 1.1f;
    [SerializeField] private float _animationDelay = .3f;

    private float _defaultScaleValue;

    private PointsController _pointsContainer;
    private Rigidbody _rigidbody;

    private void Awake() 
    { 
        _pointsContainer = GetComponent<PointsController>(); 
        _rigidbody = GetComponent<Rigidbody>();

        _defaultScaleValue = transform.localScale.x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PointsController colContainer) == false) return;

        if (colContainer.Points != _pointsContainer.Points) return;

        if (_pointsContainer.CubesCollisions > 0 || colContainer.CubesCollisions > 0) return;

        _pointsContainer.CubesCollisions++;
        colContainer.CubesCollisions++;

        _pointsContainer.IncreasePoints();
        _pointsContainer.CubesCollisions--;

        StartCoroutine(ScalingRoutine());

        _rigidbody.AddForce(Vector3.up * _upImpulseForce, ForceMode.Impulse);

        Destroy(colContainer.gameObject);
    }

    private IEnumerator ScalingRoutine()
    {
        GameObject cube = _rigidbody.gameObject;

        yield return new WaitForSeconds(.1f);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(cube.transform.DOScale(new Vector3(_newScaleValue, _newScaleValue, _newScaleValue), _animationDelay));
        sequence.Append(cube.transform.DOScale(new Vector3(_defaultScaleValue, _defaultScaleValue, _defaultScaleValue), _animationDelay));

        yield return null;
    }
}
