using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private PauseController _pauseController;

    public event Action<Vector2> OnSwipeStart;
    public event Action<Vector2> OnSwipeGoing;
    public event Action<Vector2> OnSwipeEnd;

    private bool _isSwiping;
    private Vector3 _lastRemPosition = new();

    private void Awake() => _pauseController = FindObjectOfType<PauseController>();

    private void Update()
    {
        if (_pauseController.GetState) return;

        if (Input.GetMouseButton(0) == false)
        {
            if (_isSwiping)
            {
                _isSwiping = false;

                OnSwipeEnd?.Invoke(_lastRemPosition);
            }

            _lastRemPosition = Input.mousePosition;
            return;
        }

        if (!_isSwiping)
        {
            _isSwiping = true;

            _lastRemPosition = Input.mousePosition;
            OnSwipeStart?.Invoke(Input.mousePosition - _lastRemPosition);
        }

        OnSwipeGoing?.Invoke(Input.mousePosition - _lastRemPosition);

        _lastRemPosition = Input.mousePosition;
    }
}
