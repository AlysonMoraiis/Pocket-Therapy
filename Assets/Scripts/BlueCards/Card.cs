using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] _inputField;

    private Transform _windowToTransform;


    void Start()
    {
        Load();
        OpenWindow();
    }

    public void Save()
    {
        for (int i = 0; i < _inputField.Length; i++)
        {
            PlayerPrefs.SetString(gameObject.name + i, _inputField[i].text);
        }

        Debug.Log("Save: " + gameObject.name);
    }

    public void Load()
    {
        for (int i = 0; i < _inputField.Length; i++)
        {
            _inputField[i].text = PlayerPrefs.GetString(gameObject.name + i);
        }

        Debug.Log("Load: " + gameObject.name);
    }

    public void Delete()
    {
        for (int i = 0; i < _inputField.Length; i++)
        {
            PlayerPrefs.DeleteKey(gameObject.name + i);
        }

        Debug.Log("Delete: " + gameObject.name);
    }

    public void ChangeColor()
    {
        
    }

    private void OpenWindow()
    {
        _windowToTransform = GetComponent<Transform>();

        transform.localScale = new Vector3(0, 0, 0);
        _windowToTransform.DOScale(new Vector3(1, 1, 1), 0.3f).SetUpdate(true);
    }

    public void CloseWindowCall()
    {
        _windowToTransform.DOScale(new Vector3(0, 0, 0), 0.3f).OnComplete(CloseWindow).SetUpdate(true);
    }

    private void CloseWindow()
    {
        GameObject windowToClose = GetComponent<GameObject>();
        windowToClose.SetActive(false);
    }
}
