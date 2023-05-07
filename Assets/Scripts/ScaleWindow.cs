using UnityEngine;
using DG.Tweening;

public class ScaleWindow : MonoBehaviour
{
    [SerializeField] private Transform _windowToTransform;
    [SerializeField] private Vector3 _scaleTo;
    [SerializeField] private float _scaleTime;

    [SerializeField] private GameObject _window;

    public void OpenWindow()
    {
        _window.SetActive(true);
        _windowToTransform.DOScale(_scaleTo, _scaleTime).SetUpdate(true);
    }

    public void CloseWindowCall()
    {
        _windowToTransform.DOScale(new Vector3(0, 0, 0), _scaleTime).OnComplete(CloseWindow).SetUpdate(true);
    }

    private void CloseWindow()
    {
        _window.SetActive(false);
    }
}