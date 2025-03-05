using TMPro;
using UnityEngine;
using UnityFigmaBridge;

public class CodeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _Count = 0;

    [BindFigmaButtonPress("AddButton")]
    public void IncrementCount()
    {
        _Count++;
        _text.text = _Count.ToString();
    }
}