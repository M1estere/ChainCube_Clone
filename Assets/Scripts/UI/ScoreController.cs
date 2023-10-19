using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private long _score = 0;

    private void Start() => IncreaseScore(0);

    public void IncreaseScore(long increment)
    {
        _score += increment;

        _scoreText.text = _score.ToString("00000");
    }
}
