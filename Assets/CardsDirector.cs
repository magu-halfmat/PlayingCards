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
        for (int i = 0; i < cards.Count; i++)//�n���ꂽ�J�[�h�̐�����for���񂵂܂�
        {
            int rnd = Random.Range(0, cards.Count);  //0����J�[�h�̐��̊Ԃ̃����_������rnd�ɑ��
            CardController tmp = cards[i];  //CardContrlooer�^��tmp�����̃J�[�h�Ƃ��܂�

            cards[i] = cards[rnd];  //���Ԗڂ̃J�[�h�̃f�[�^��rnd�Ԗڂ̃J�[�h�̃f�[�^���������܂�
            cards[rnd] = tmp;  //rnd�Ԗڂ̃J�[�h�̃f�[�^�����̃J�[�h�̃f�[�^�ƌ������܂�
        }
    }

    List<CardController> CreateCards(SuitType suittype)
    {
        List<CardController> ret = new List<CardController>();

        //�J�[�h�̎�ށi�f�t�H���g�j
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

        //��������J�[�h����
        for (int i = 0; i < prefabcards.Count; i++)  //���X�g�̐�����for����
        {
            GameObject obj = Instantiate(prefabcards[i]);  //GameObject�^��obj�����̉��@���X�gprefabcards��i�Ԗڂ����

            BoxCollider bc = obj.AddComponent<BoxCollider>();  //�����蔻����邽�߂�BoxCollider����
            Rigidbody rb = obj.AddComponent<Rigidbody>();  //�����蔻�茟�m�̂��߂�RigidBody����
            bc.isTrigger = true;  //�J�[�h�̓����蔻��͎g��Ȃ��̂�isTrigger������
            rb.isKinematic = true;  //�������Z�g��Ȃ��̂�isTrigger������

            CardController ctrl = obj.AddComponent<CardController>();  //obj��CardController�R���|�[�l���g�i�X�N���v�g�j����ctrl�Ɋi�[

            ctrl.Suit = suittype;  //�p�����[�^�ݒ�
            ctrl.SuitColor = suitcolor;  //�p�����[�^�ݒ�
            ctrl.PlayerNo = -1;  //�p�����[�^�ݒ�
            ctrl.No = i + 1;  //�p�����[�^�ݒ�

            ret.Add(ctrl);  //�߂�l�p���X�g�ɏo���オ�������̂�������
        }

        return ret;
    }
}
