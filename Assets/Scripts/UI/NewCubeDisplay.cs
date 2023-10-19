using UnityEngine;

public class NewCubeDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _displayObject;
    [Space(3)]

    [SerializeField] private TMPro.TMP_Text _valueText;

    public void Display(long value)
    {
        Time.timeScale = 0;
        _displayObject.SetActive(true);

        _valueText.text = value.ToString();
    }

    public void CloseDisplay()
    {
        Time.timeScale = 1;
        _displayObject.SetActive(false);
    }
}
