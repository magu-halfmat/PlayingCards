using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マーク
public enum SuitType
{
    Spade,
    Club,
    Diamond,
    Heart,
    Joker,
}
public class CardController : MonoBehaviour
{
    //カードサイズ
    public const float Width = 0.06f;
    public const float Height = 0.09f;

    //このカードのマーク
    public SuitType Suit;

    //番号
    public int No;

    //どのプレイヤーのカードか
    public int PlayerNo;

    //神経衰弱やカップルで並べた時の内部番号
    public int Index;

    //手札初期値（３Ｄ）
    public Vector3 HandPosition;

    //手札初期値（x,y）
    public Vector2Int IndexPosition;

    //色　赤か黒か
    public Color SuitColor;

    //表面が上になっているか
    public bool isFrontUp;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    //カードをめくる（引数無しで表側にする）
    public void FripCard(bool frontup = true)
    //引数はboolなのでtrueかfalse。引数無しならfrontupをtrueにする、という書き方をしている
    {
        float anglez = 0;
        if (!frontup)
        {
            anglez = 180;
        }

        isFrontUp = frontup;
        transform.eulerAngles = new Vector3(0, 0, anglez);
    }
}
