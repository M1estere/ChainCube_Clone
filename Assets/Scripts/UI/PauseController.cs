using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool GetState => _pauseMenu.activeSelf || _newCubeMenu.activeSelf;

    [Header("Screens Setup")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _newCubeMenu;

    private void Start() => Time.timeScale = 1;

    public void TogglePause()
    {
        if (_pauseMenu.activeSelf == false) Pause();
        else UnPause();
    }

    private void Pause()
    {
        Time.timeScale = 0;

        _pauseMenu.SetActive(true);
    }

    private void UnPause()
    {
        Time.timeScale = 1;

        _pauseMenu.SetActive(false);
    }
}
