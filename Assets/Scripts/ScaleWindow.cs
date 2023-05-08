using UnityEngine;
using DG.Tweening;

public class ScaleWindow : MonoBehaviour
{
    [SerializeField] private Transform _windowToTransform;
    private Vector3 _scaleTo = new Vector3(1, 1, 1);
    private float _scaleTime = 0.3f;

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