using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] private GameObject _trail;

    private void Start() => EnableTrail();

    public void EnableTrail() => _trail.SetActive(true);
    public void DisableTrail() => _trail.SetActive(false);
}
