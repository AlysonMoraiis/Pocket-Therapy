using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptsPages : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject _default;

    private void OnEnable()
    {
        DestroyAllCards();
    }

    private void OnDisable()
    {
        DestroyAllCards();
    }

    public void DestroyAllCards()
    {
        _default.SetActive(true);
        //SetActive();
        // for (int i = 0; i < _prompts.Length; i++)
        // {
        //     _prompts[i].SetActive(false);
        //     _prompts[i].transform.localScale = new Vector3(0, 0, 0);
        // }
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetActive()
    {
        _default.SetActive(true);
    }
}
