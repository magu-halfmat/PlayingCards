using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabSpades;
    [SerializeField] List<GameObject> prefabClubs;
    [SerializeField] List<GameObject> prefabDiamonds;
    [SerializeField] List<GameObject> prefabHearts;
    [SerializeField] List<GameObject> prefabJokers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<CardController> GetHighLowCards()
    {
        List<CardController> ret = new List<CardController>();

        ret.AddRange(CreateCards(SuitType.Spade));
        ret.AddRange(CreateCards(SuitType.Club));
        ret.AddRange(CreateCards(SuitType.Diamond));
        ret.AddRange(CreateCards(SuitType.Heart));

        ShuffleCards(ret);

        return ret;
    }
    
    public void ShuffleCards(List<CardController> cards)
    {
        for (int i = 0; i < cards.Count; i++)//渡されたカードの数だけforを回します
        {
            int rnd = Random.Range(0, cards.Count);  //0からカードの数の間のランダム数をrndに代入
            CardController tmp = cards[i];  //CardContrlooer型のtmpを今のカードとします

            cards[i] = cards[rnd];  //今番目のカードのデータとrnd番目のカードのデータを交換します
            cards[rnd] = tmp;  //rnd番目のカードのデータを今のカードのデータと交換します
        }
    }

    List<CardController> CreateCards(SuitType suittype)
    {
        List<CardController> ret = new List<CardController>();

        //カードの種類（デフォルト）
        List<GameObject> prefabcards = prefabSpades;
        Color suitcolor = Color.black;

        if (SuitType.Club == suittype)
        {
            prefabcards = prefabClubs;
        }
        else if(SuitType.Diamond == suittype)
        {
            prefabcards = prefabDiamonds;
            suitcolor = Color.red;
        }
        else if (SuitType.Heart == suittype)
        {
            prefabcards = prefabHearts;
            suitcolor = Color.red;
        }

        //ここからカード生成
        for (int i = 0; i < prefabcards.Count; i++)  //リストの数だけforを回す
        {
            GameObject obj = Instantiate(prefabcards[i]);  //GameObject型のobjを実体化　リストprefabcardsのi番目を基に

            BoxCollider bc = obj.AddComponent<BoxCollider>();  //当たり判定つけるためにBoxColliderつける
            Rigidbody rb = obj.AddComponent<Rigidbody>();  //当たり判定検知のためにRigidBodyつける
            bc.isTrigger = true;  //カードの当たり判定は使わないのでisTriggerをつける
            rb.isKinematic = true;  //物理演算使わないのでisTriggerをつける

            CardController ctrl = obj.AddComponent<CardController>();  //objにCardControllerコンポーネント（スクリプト）つけてctrlに格納

            ctrl.Suit = suittype;  //パラメータ設定
            ctrl.SuitColor = suitcolor;  //パラメータ設定
            ctrl.PlayerNo = -1;  //パラメータ設定
            ctrl.No = i + 1;  //パラメータ設定

            ret.Add(ctrl);  //戻り値用リストに出来上がったものを加える
        }

        return ret;
    }
}
