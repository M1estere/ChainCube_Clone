using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake() => Application.targetFrameRate = -1;
}
