using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlaceCardOnSlot : MonoBehaviour
{
    private GameObject _cardPrefab;

    [SerializeField] private GameObject _thisGameObject;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private PromptsPages _promptsPage;

    [SerializeField] private GameObject _cardToSetInactive;

    private Card _card;

    private void Start()
    {
        _saveButton.onClick.AddListener(HandleSaveButton);
        _deleteButton.onClick.AddListener(HandleDeleteButton);
    }

    public void InstantiateCardPrefab(GameObject cardPrefab)
    {
        GameObject newCardPrefab = Instantiate(cardPrefab, transform);
        _card = newCardPrefab.GetComponent<Card>();
        OpenWindow();
    }

    private void OpenWindow()
    {
        _thisGameObject.SetActive(true);
    }

    private void HandleSaveButton()
    {
        _card.Save();
        StartCoroutine(TimerToDestroy());
    }

    public void HandleDeleteButton()
    {
        _card.Delete();
        StartCoroutine(TimerToDestroy());
    }

    IEnumerator TimerToDestroy()
    {
        _card.CloseWindowCall();
        _promptsPage.SetActive();
        yield return new WaitForSeconds(0.31f);
        _promptsPage.DestroyAllCards();
        _cardToSetInactive.SetActive(false);
    }
}
