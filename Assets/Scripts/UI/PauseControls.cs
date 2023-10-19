using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
