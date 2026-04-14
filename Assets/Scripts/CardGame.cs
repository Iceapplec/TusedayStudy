using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{

    public List<CardController> cards = new List<CardController>();
    private CardController firstCard = null;
    private CardController SecondCard = null;
    private bool isChecking = false;

    void Start()
    {
        StartGgame();
       
    }

    //카드 섞고, 다 뒤집기
    void StartGgame()
    {
        List<int> pairNumbers = GeneratePairNumbers(cards.Count);

        for (int i = 0; i < pairNumbers.Count; ++i)
        {
            cards[i].SetCardNumber(pairNumbers[i]);


        }
        for(int i = 0; i < cards.Count; ++i)
        {
            cards[i].isFront = false;

        }
    }

    void CheckCard()
    {
        isChecking = true;

        if (firstCard.number == SecondCard.number)
        {
            firstCard.ChangeColor(Color.red);
            SecondCard.ChangeColor(Color.red);

            firstCard.isMatched = true;
            SecondCard.isMatched = true;

            firstCard = null;
            SecondCard = null;

            isChecking = false;
        }
        else
        {
            Invoke("HideCard", 1.0f);
            //다시 뒤집기
        }
    }

    public void OnClickCard(CardController cardController)
    {
        if (isChecking)
        {
            return;
        }

        
        if (firstCard == null)
        {
            firstCard = cardController;
            firstCard.Flip(true);
        }
        else
        {
            SecondCard = cardController;
            SecondCard.Flip(true);
        }

        if(firstCard != null &&  SecondCard != null)
        {
            CheckCard();
        }
    
    }
    //다시 숨기기
    void HideCard()
    {
        firstCard.isFront = false;
        SecondCard.isFront = false;

        firstCard.Flip(false);
        SecondCard.Flip(false);

        isChecking = false;

        firstCard = null;
        SecondCard = null;
    

        
    }

    //무작위 페어 넘버 알고리즘
    List<int> GeneratePairNumbers(int cardCount)
    {
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();

        for (int i = 0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        for(int i = newCardNumbers.Count -1; i > 0; i--)
        {

            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;

        }

        return newCardNumbers;
    }
}
