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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
