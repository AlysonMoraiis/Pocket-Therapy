using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReshuffleCards : MonoBehaviour
{
    [SerializeField] private Transform _windowToTransform;
    [SerializeField] private Button _reshuffleButton;
    [SerializeField] private GameObject[] _chooseCardButton;

    private void Start()
    {
        _reshuffleButton.onClick.AddListener(ReshuffleCardsButtons);
    }

    public void ReshuffleCardsButtons()
    {
        StartCoroutine(Timer());
        Debug.Log("Reshuffle");
    }

    IEnumerator Timer()
    {
        _windowToTransform.DOScale(new Vector3(1, 0, 1), 0.3f).SetUpdate(true);
        yield return new WaitForSeconds(0.3f);
        RandomizeCardButtons();
        _windowToTransform.DOScale(new Vector3(1, 1, 1), 0.3f).SetUpdate(true);
    }

    private void RandomizeCardButtons()
    {
        List<int> randomIndexes = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            while (randomIndexes.Count < 4)
            {
                int randomIndex = UnityEngine.Random.Range(0, _chooseCardButton.Length);
                if (!randomIndexes.Contains(randomIndex))
                {
                    randomIndexes.Add(randomIndex);
                }
            }
        }

        foreach (int index in randomIndexes)
        {
            GameObject randomObject = _chooseCardButton[index];
            randomObject.SetActive(true);
        }

        foreach (GameObject obj in _chooseCardButton)
        {
            if (!randomIndexes.Contains(Array.IndexOf(_chooseCardButton, obj)))
            {
                obj.SetActive(false);
            }
        }
    }
}
