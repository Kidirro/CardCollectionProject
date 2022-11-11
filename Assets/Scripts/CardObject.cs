using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    [Header("Text properties"), SerializeField]
    private TextMeshProUGUI _cardId;

    [SerializeField]
    private TextMeshProUGUI _cardName;

    [SerializeField]
    private TextMeshProUGUI _cardTypeText;

    [SerializeField]
    private TextMeshProUGUI _cardDescriptionText;

    [SerializeField]
    private TextMeshProUGUI _cardAttackText;

    [SerializeField]
    private TextMeshProUGUI _cardArmorText;

    [SerializeField]
    private TextMeshProUGUI _cardHitPointText;

    [Header("Image properties"), SerializeField]
    private Image _cardTypeLabel;

    [SerializeField]
    private Image _cardImage;

    [SerializeField]
    private Image _cardBG;

    [Header("Lazy card properties"), SerializeField]
    private Image _cardMainImage;

    private CardManager.Card _cardInfo;

    public void SetCardInfo(CardManager.Card Card)
    {
        _cardInfo = Card;
        _cardMainImage.sprite = Card.CardImage;
    }

    public void OnPointerDown()
    {
        CardManager.Instance.ShowBigCard(_cardInfo);
    }
}
