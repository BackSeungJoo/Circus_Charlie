using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public float cameraSpeed = 2.0f;

    private Vector3 pos;         // ��ġ ���� ���/ �Ǵ��� ���� �ӽ� ����
    public float maxXPosition;  // x�� �ִ밪
    public float minXPosition;  // x�� �ּҰ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;   // ���� position ��

        //if (pos.x >= maxXPosition)
        //{
        //    pos.x = maxXPosition;   // x�� �ִ밪 �̻��̸� x�� �ִ밪���� ����
        //}

        //if (pos.x <= minXPosition)
        //{
        //    pos.x = minXPosition;   // x�� �ִ밪 �̻��̸� x�� �ִ밪���� ����
        //}


        // pos.x ���� �ּҰ� ~ �ִ밪 ���̷� �߶󳽴�.
        pos.x = Mathf.Clamp(pos.x, minXPosition, maxXPosition);
        transform.position = pos;

        // x��ǥ���� ���� �ٵ�� ������.
        // transform.position.x = Mathf.Clamp(transform.position.x, minXPosition, maxXPosition);

        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3((dir.x) * cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
        this.transform.Translate(moveVector);
    }
}
