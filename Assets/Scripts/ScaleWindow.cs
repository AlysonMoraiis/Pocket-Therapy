using UnityEngine;
using DG.Tweening;

public class ScaleWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Transform _windowToTransform;
    [SerializeField] private float _scaleTime = 0.3f;

    public void OpenWindow()
    {
        _windowToTransform.localScale = new Vector3(0, 0, 0);

        _window.SetActive(true);
        _windowToTransform.DOScale(new Vector3(1, 1, 1), _scaleTime).SetUpdate(true);
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