using UnityEngine;

public class Stage1_ButtonController : MonoBehaviour
{
    public bool isLeft_Downing;     // ���� �̵��� ���� ����
    public bool isRight_Downing;    // ������ �̵��� ���� ����
    public bool isJump_Downing;     // ���� �̵��� ���� ����
    public PlayerControl playerControl;

    void Update()
    {
        // ���� ��ư�� ������ �ִٸ�
        if(isLeft_Downing)
        {
            playerControl.Move_Left();
        }

        // ������ ��ư�� ������ �ִٸ�
        if(isRight_Downing)
        {
            playerControl.Move_Right();
        }

        // ���� ��ư�� ������ �ִٸ�
        if(isJump_Downing)
        {
            playerControl.Jump();
        }
    }

    // ���� Ŭ��
    public void LeftDown()
    {
        isLeft_Downing = true;
    }

    public void LeftUp()
    {
        isLeft_Downing = false;
    }

    // ������ Ŭ��
    public void RightDown()
    {
        isRight_Downing = true;
    }

    public void RightUp()
    {
        isRight_Downing = false;
    }

    // ���� Ŭ��
    public void JumpDown()
    {
        isJump_Downing = true;
    }

    public void JumpUp()
    {
        isJump_Downing = false;
    }
}
