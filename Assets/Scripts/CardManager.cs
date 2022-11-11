using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
    [SerializeField]
    private List<Card> _cardList;

    [SerializeField]
    private List<CardObject> _cardObjects;

    [SerializeField]
    private CardObject _cardBigView;

    private int _currentPage=0;

    private List<Card> _currentCardList;

    private void Start()
    {
        _currentCardList = new List<Card>(_cardList);
        _currentPage = 0;
        ShowBigCard(_currentCardList[0]);
        UpdatePageList();
    }

    public void UpdatePageList()
    {
        int startId = _currentPage * _cardObjects.Count;
        for (int i =0; i < _cardObjects.Count; i++)
        {
            if (startId + i >= _currentCardList.Count) _cardObjects[i].gameObject.SetActive(false);
            else
            {
                _cardObjects[i].gameObject.SetActive(true);
                _cardObjects[i].SetCardInfo(_currentCardList[startId + i]);
            }
        }

    }

    public void NextPage()
    {
        if (_currentPage  == (int)_currentCardList.Count / _cardObjects.Count) return;

        _currentPage += 1;
        UpdatePageList();
    }

    public void PrevPage()
    {
        if (_currentPage == 0) return;

        _currentPage -= 1;
        UpdatePageList();
    }

    public void ShowBigCard(Card card)
    {
        _cardBigView.SetCardInfo(card);
    }

    public void SetFilter(int i)
    {
        if (i == -1)
        {
            _currentCardList = new List<Card>(_cardList);


            _currentPage = 0;
            ShowBigCard(_currentCardList[0]);
            UpdatePageList();
        }
        else
        {
            SetFilter((CardTag)i);
        }
    }

    public void SetFilter(CardTag tag)
    { _currentCardList = new List<Card>();
        for (int i =0; i < _cardList.Count; i++)
        {
            if (_cardList[i].CardTags.IndexOf(tag) != -1) _currentCardList.Add(_cardList[i]);
        }
        _currentPage = 0;
        ShowBigCard(_currentCardList[0]);
        UpdatePageList();
    }

    [Serializable]
    public class Card
    {
        /* public string CardName;
         public string CardTypeText;
         public string  CardDescriptionText;

         public int CardAttack;
         public int CardArmor;
         public int CardHitPoint;

         public Sprite CardTypeLabel;
         public Sprite CardImage;
         public Sprite CardBG;*/

        public Sprite CardImage;

        public List<CardTag> CardTags;

    }

    public enum CardTag
    {
        Test,
        Dark,
        none
    }
}
