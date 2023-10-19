using System;
using UnityEngine;

public class NewCubesController : MonoBehaviour
{
    [SerializeField] private long _lowestScoreValue = 32;

    private NewCubeDisplay _displayCube;

    private void Start() =>
        _displayCube = FindObjectOfType<NewCubeDisplay>();

    public void CheckNewCube(long value)
    {
        if (value <= _lowestScoreValue) return;

        long currentHighCube = 0;
        if (PlayerPrefs.HasKey("Highest_Cube_Value"))
            currentHighCube = (long)Convert.ToDouble(PlayerPrefs.GetString("Highest_Cube_Value"));

        if (value > currentHighCube)  // set new score
        {
            PlayerPrefs.SetString("Highest_Cube_Value", value.ToString());

            _displayCube.Display(value);
        }
    }
}
