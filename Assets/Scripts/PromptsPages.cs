using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptsPages : MonoBehaviour
{
    [SerializeField] private GameObject[] _prompts;
    [SerializeField] private GameObject _default;

    private void OnEnable()
    {
        _default.SetActive(true);
        for (int i = 0; i < _prompts.Length; i++)
        {
            _prompts[i].SetActive(false);
            _prompts[i].transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
