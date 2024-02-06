using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    const float RESPAWNOFFSET = 4f; // ������ ������ 

    private float width;    // ����� ���� ����
    private void Awake()
    {
        // BoxColiider2D ������Ʈ�� size �ʵ��� x ���� ���� ���̷� ���
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
    }

    private void Update()
    {
        // ���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        if (transform.position.x <= -width * 2)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� * ������ ��ŭ �̵�
        Vector2 offset = new Vector2(width * RESPAWNOFFSET, 0);

        // transform.position = (Vector2)transform.position + offset; ������
        transform.position = transform.position.AddVector(offset);
    }
}
