using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�}�[�N
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
    //�J�[�h�T�C�Y
    public const float Width = 0.06f;
    public const float Height = 0.09f;

    //���̃J�[�h�̃}�[�N
    public SuitType Suit;

    //�ԍ�
    public int No;

    //�ǂ̃v���C���[�̃J�[�h��
    public int PlayerNo;

    //�_�o�����J�b�v���ŕ��ׂ����̓����ԍ�
    public int Index;

    //��D�����l�i�R�c�j
    public Vector3 HandPosition;

    //��D�����l�ix,y�j
    public Vector2Int IndexPosition;

    //�F�@�Ԃ�����
    public Color SuitColor;

    //�\�ʂ���ɂȂ��Ă��邩
    public bool isFrontUp;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    //�J�[�h���߂���i���������ŕ\���ɂ���j
    public void FripCard(bool frontup = true)
    //������bool�Ȃ̂�true��false�B���������Ȃ�frontup��true�ɂ���A�Ƃ��������������Ă���
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
