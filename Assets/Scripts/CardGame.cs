using UnityEngine;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{
    [Tooltip("페어 개수 (각 숫자별로 2장의 카드가 생성됩니다)")]
    public int pairCount = 6;

    [Tooltip("카드 프리팹 (CardController 포함)")]
    public GameObject cardPrefab;

    [Tooltip("생성된 카드를 담을 부모(예: GridLayoutGroup이 붙은 UI 오브젝트)")]
    public Transform cardParent;

    private List<int> deck = new List<int>();

    void Start()
    {
        GenerateDeck();
        CreateCards();
    }

    // 페어별로 숫자를 생성하고 섞음
    public void GenerateDeck()
    {
        deck.Clear();
        for (int i = 1; i <= Mathf.Max(0, pairCount); i++)
        {
            deck.Add(i);
            deck.Add(i);
        }
        Shuffle(deck);
    }

    // 카드 인스턴스 생성 및 초기화
    public void CreateCards()
    {
        if (cardPrefab == null)
        {
            Debug.LogError("CardGame: cardPrefab이 할당되지 않았습니다.");
            return;
        }

        if (cardParent == null)
        {
            Debug.LogError("CardGame: cardParent가 할당되지 않았습니다.");
            return;
        }

        // 기존 자식 제거
        for (int i = cardParent.childCount - 1; i >= 0; i--)
        {
            Destroy(cardParent.GetChild(i).gameObject);
        }

        // 덱 크기만큼 카드 생성
        for (int i = 0; i < deck.Count; i++)
        {
            GameObject go = Instantiate(cardPrefab, cardParent);
            CardController cc = go.GetComponent<CardController>();
            if (cc != null)
            {
                cc.cardGame = this;
                cc.SetCardNumber(deck[i]);
                // 초기 상태(뒷면 보이기 등) 설정 원하면 조정
                cc.Flip(false);
                cc.isMatched = false;
            }
        }
    }

    // 단순 섞기 (Fisher-Yates)
    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }

    // CardController에서 클릭 시 호출됩니다 (간단 예시)
    public void OnClickCard(CardController clicked)
    {
        // 여기서 매칭 로직을 구현하세요.
        Debug.Log($"Card clicked: {clicked.number}");
    }

    // 런타임에 재생성이 필요하면 호출
    public void Regenerate()
    {
        GenerateDeck();
        CreateCards();
    }
}
