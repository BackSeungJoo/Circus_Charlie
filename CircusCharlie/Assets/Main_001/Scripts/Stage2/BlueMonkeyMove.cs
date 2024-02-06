using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonkeyMove : MonoBehaviour
{
    private Rigidbody2D blueMonkeyRigid;

    // Start is called before the first frame update
    void Start()
    {
        blueMonkeyRigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Ϲ� �����̶� �浹�ϸ�,
        if (GameManager_Scene2.instance.isDead == false)
        {
            if (collision.gameObject.tag == "Monkey")
            {
                // �̵��� �ٲ۴�.
                blueMonkeyRigid.velocity = new Vector2(0f, 20f);
            }
        }
    }
}
