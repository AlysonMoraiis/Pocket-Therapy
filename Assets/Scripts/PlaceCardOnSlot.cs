using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaceCardOnSlot : MonoBehaviour
{
    private GameObject _cardPrefab;

    [SerializeField] private GameObject _thisGameObject;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _deleteButton;

    private Card _teste;

    private void Start()
    {
        _saveButton.onClick.AddListener(HandleSaveButton);
        _deleteButton.onClick.AddListener(HandleDeleteButton);
    }

    public void InstantiateCardPrefab(GameObject cardPrefab)
    {
        GameObject newCardPrefab = Instantiate(cardPrefab, transform);
        _teste = newCardPrefab.GetComponent<Card>();
        OpenWindow();
    }

    private void OpenWindow()
    {
        _thisGameObject.SetActive(true);
    }

    private void HandleSaveButton()
    {
        _teste.Save();
    }

    public void HandleDeleteButton()
    {
        _teste.Delete();
    }
}
