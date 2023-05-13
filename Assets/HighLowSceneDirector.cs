using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLowSceneDirector : MonoBehaviour
{
    [SerializeField] CardsDirector cardsDirector;
    [SerializeField] GameObject buttonHigh;
    [SerializeField] GameObject buttonLow;
    [SerializeField] Text textInfo;

    List<CardController> cards;

    int cardIndex;
    int winCount;
    const float NextWaitTimer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        cards = cardsDirector.GetHighLowCards();

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = new Vector3(0, 0, 0.15f);
            cards[i].FripCard(false);
        }

        DealCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DealCards()
    {
        cards[cardIndex].transform.position = new Vector3(-0.05f, 0, 0);
        cards[cardIndex].GetComponent<CardController>().FripCard();
        cards[cardIndex + 1].transform.position = new Vector3(0.05f, 0, 0);
        SetHighLowButtons(true);
    }

    void SetHighLowButtons(bool active)
    {
        buttonHigh.SetActive(active);
        buttonLow.SetActive(active);
    }
}
