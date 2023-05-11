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

    [Header("Colors Buttons")]
    [SerializeField] private Button _brownButton;
    [SerializeField] private Button _blueButton;
    [SerializeField] private Button _greenButton;
    [SerializeField] private Button _orangeButton;


    private Color _brown = new Color(135 / 255f, 115 / 255f, 91 / 255f);
    private Color _blue = new Color(162 / 255f, 203 / 255f, 196 / 255f);
    private Color _green = new Color(132 / 255f, 161 / 255f, 114 / 255f);
    private Color _orange = new Color(245 / 255f, 120 / 255f, 80 / 255f);

    private Card _card;

    private void Start()
    {
        _saveButton.onClick.AddListener(HandleSaveButton);
        _deleteButton.onClick.AddListener(HandleDeleteButton);

        _brownButton.onClick.AddListener(() => HandleChangeColorsButton(_brown));
        _blueButton.onClick.AddListener(() => HandleChangeColorsButton(_blue));
        _greenButton.onClick.AddListener(() => HandleChangeColorsButton(_green));
        _orangeButton.onClick.AddListener(() => HandleChangeColorsButton(_orange));
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

    public void HandleChangeColorsButton(Color color)
    {
        _card.ChangeColor(color);
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
