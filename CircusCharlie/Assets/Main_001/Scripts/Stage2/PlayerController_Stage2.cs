using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController_Stage2 : MonoBehaviour
{
    // ���� ����
    public GameData gameData;

    // �÷��̾� �ִϸ�����
    public Animator playerAnim;

    // �÷��̾� ������ٵ�
    private Rigidbody2D playerRigid;

    public float moveSpeed = 0.01f; // �÷��̾� �̵��ӵ�
    public float jumpForce = 2f;    // �÷��̾� ���� ��

    private int jumpCount = 0;      // ���� Ƚ��

    // �÷��̾� �¿� ����
    public SpriteRenderer playerSpriteRenderer;

    // ȿ����
    // ���� ȿ����
    public AudioSource playerAudioSource;
    public AudioClip jumpAudio;

    // �״� ȿ����
    public AudioSource DieAudioSource;
    public AudioClip DieAudio;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� ������ �̵�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move_Right();
        }

        // �÷��̾� ���� �̵�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move_Left();
        }

        // �÷��̾� ����
        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump();
        }
    }

    // �÷��̾� �̵� ���� �Լ���
    // �÷��̾� ������ �̵�
    public void Move_Right()
    {
        if (GameManager_Scene2.instance.isDead == false)
        {
            // �÷��̾� �¿���� false
            playerSpriteRenderer.flipX = false;

            // �÷��̾ �̵���Ŵ
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    // �÷��̾� ���� �̵�
    public void Move_Left()
    {
        if (GameManager_Scene2.instance.isDead == false)
        {
            // �÷��̾� �¿���� true
            playerSpriteRenderer.flipX = true;

            // �÷��̾ �̵���Ŵ
            transform.Translate(Vector3.left * (moveSpeed * 0.5f) * Time.deltaTime);
        }

    }

    // �÷��̾� ���� ����
    public void Jump()
    {
        if (GameManager_Scene2.instance.isDead == false)
        {
            if (jumpCount < 1)
            {
                // ���� ȿ����
                playerAudioSource.PlayOneShot(jumpAudio);

                // �ִϸ��̼��� �ٲ���
                playerAnim.SetBool("isJump", true); 

                // ������ٵ� �������� ���ֱ�
                // playerRigidbody.velocity = new Vector2(0, jumpForce);
                playerRigid.AddForce(new Vector2(0, jumpForce));
                jumpCount++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �����̶� �浹�ߴ�. => ���
        if ((collision.gameObject.tag == "BlueMonkey") || (collision.gameObject.tag == "Monkey"))
        {
            // �״� ȿ����
            DieAudioSource.PlayOneShot(DieAudio);

            // �ִϸ��̼� ����
            playerAnim.SetTrigger("Die");

            playerRigid.velocity = Vector3.zero;
            playerRigid.gravityScale = 0f;

            // �������� ���ҽ�Ű�� �����մϴ�.
            gameData.life--;

            GameManager_Scene2.Instance.isDead = true;
        }

        // �ٴڿ� �����ߴ�.
        if (collision.gameObject.tag == "Ground")
        {
            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isJump", false);

            jumpCount = 0;
        }

        // ����ο� �����ߴ�.
        if ((collision.gameObject.tag == "End" && transform.position.y > -3.2f) &&
            (transform.position.x - 1f <= collision.transform.position.x) && (collision.transform.position.x <= transform.position.x + 1f))
        {
            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isJump", false);

            // ���� Ŭ����
            Debug.Log("���� Ŭ����");
            SceneManager.LoadScene("Stage2_Clear");
        }
        else { return; }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���ʽ� ������ ȹ���ߴ�!
        if (collision.gameObject.tag == "Bonus")
        {
            GFunc.Log("���ʽ����� ȹ��");
            collision.gameObject.SetActive(false);

            gameData.score_Stage2 += 5000;
        }

        // �� �Ǵ� ������ ������� �� ���� ����
        if (collision.gameObject.tag == "ScoreUp")
        {
            gameData.score_Stage2 += 1000;
        }
    }
}

