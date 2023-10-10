using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControl : MonoBehaviour
{
    public GameData gameData;

    public Animator playerAnim;
    public Animator lionAnim;
    public SpriteRenderer playerSpriteRenderer;
    public SpriteRenderer lionSpriteRenderer;

    private Rigidbody2D playerRigid;

    public float moveSpeed = 0.01f;
    public float jumpForce = 2f;

    private int jumpCount = 0;

    private bool move = false;
    private bool jump = false;

    // ȿ����
    // ���� ȿ����
    public AudioSource playerAudioSource;
    public AudioClip jumpAudio;

    // ���ʽ� �ָӴ� ȿ����
    public AudioSource bonusAudioSource;
    public AudioClip bonusAudio;

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
        // �ƹ�Ű�� �Է¹��� �ʰ� ������ �÷��̾� idle ����� ���ϴ�.
        if ((Input.anyKey == false) && (jump == false))
        {
            move = false;

            // �ٲ��ݴϴ�.
            playerAnim.SetBool("isMove", false);
            playerAnim.SetBool("isJump", false);
        }

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
    public void Move_Right()
    {
        if(GameManager_Scene1.instance.isDead == false)
        {
            // �¿� ����
            playerSpriteRenderer.flipX = false;
            lionSpriteRenderer.flipX = false;

            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isMove", true);
            lionAnim.SetBool("isMove", true);

            // �÷��̾ �̵���Ŵ
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // ���������� üũ
            move = true;
        }
    }
    
    public void Move_Left()
    {
        if (GameManager_Scene1.instance.isDead == false)
        {
            // �¿� ����
            playerSpriteRenderer.flipX = true;
            lionSpriteRenderer.flipX = true;

            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isMove", true);
            lionAnim.SetBool("isMove", true);

            // �÷��̾ �̵���Ŵ
            transform.Translate(Vector3.left * (moveSpeed * 0.5f) * Time.deltaTime);

            // ���������� üũ
            move = true;
        }
            
    }

    public void Jump()
    {
        if (GameManager_Scene1.instance.isDead == false)
        {
            if (jumpCount < 1)
            {
                // ȿ������ �����
                playerAudioSource.PlayOneShot(jumpAudio);

                // �ִϸ��̼��� �ٲ���
                playerAnim.SetBool("isJump", true);
                lionAnim.SetBool("isJump", true);
                playerAnim.SetBool("isMove", false);
                lionAnim.SetBool("isMove", false);

                // ������ٵ� �������� ���ֱ�
                // playerRigidbody.velocity = new Vector2(0, jumpForce);
                playerRigid.AddForce(new Vector2(0, jumpForce));

                jump = true;
                jumpCount++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� �����ߴ�.
        if (collision.gameObject.tag == "Ground")
        {
            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isJump", false);
            lionAnim.SetBool("isJump", false);
            lionAnim.SetBool("isMove", true);

            jump = false;

            jumpCount = 0;
        }

        // ����ο� �����ߴ�.
        if ((collision.gameObject.tag == "End" && transform.position.y > -3.2f) &&
            (transform.position.x - 1f <= collision.transform.position.x) && (collision.transform.position.x <= transform.position.x + 1f))
        {
            // �ִϸ��̼��� �ٲ���
            playerAnim.SetBool("isJump", false);
            lionAnim.SetBool("isJump", false);
            lionAnim.SetBool("isMove", true);

            // ���� Ŭ����
            Debug.Log("���� Ŭ����");
            SceneManager.LoadScene("Stage1_Clear");
        }
        else { return; }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��Ҵ�!
        if (collision.gameObject.tag == "Ring")
        {
            DieAudioSource.PlayOneShot(DieAudio);

            playerAnim.SetTrigger("Die");
            lionAnim.SetTrigger("Die");

            playerRigid.velocity = Vector3.zero;
            playerRigid.gravityScale = 0f;

            // �������� ���ҽ�Ű�� �����մϴ�.
            gameData.life--;

            GameManager_Scene1.Instance.isDead = true;
        }

        // ���ʽ� ������ ȹ���ߴ�!
        if (collision.gameObject.tag == "Bonus")
        {
            // ȿ���� ���!
            bonusAudioSource.PlayOneShot(bonusAudio);

            GFunc.Log("���ʽ����� ȹ��");
            collision.gameObject.SetActive(false);

            gameData.score_Stage1 += 5000;
        }

        // �� �Ǵ� ������ ������� �� ���� ����
        if (collision.gameObject.tag == "ScoreUp")
        {
            gameData.score_Stage1 += 1000;
        }
    }
}
