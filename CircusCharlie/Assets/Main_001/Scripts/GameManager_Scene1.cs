using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Scene1 : MonoBehaviour
{
    //���ӵ����Ϳ� �����մϴ�.
    public GameData gameData;

    // �̱��� �ν��Ͻ��� ������ ���� ����
    public static GameManager_Scene1 instance;

    // �ؽ�Ʈ�� ��� �̹����� �����ɴϴ�.
    public Text timeText;
    public Text scoreText;
    public Image life_1;
    public Image life_2;
    public Image life_3;

    
    // ���� ���� ������
    // private float waitTime_ = 0f;   // ���ð�
    private int gameScore;          // ����
    private int life;               // ���
    public float gameTime = 30;     // �ð�
    public bool gameEnd = false;    // ��������
    public bool isDead = false;     // ���üũ

    private float waitTime = 0f; // ��� �ð�

    // GameManager �̱��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ
    public static GameManager_Scene1 Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // �ν��Ͻ��� �̹� �����ϴ� ��� �ߺ� ������ �����ϱ� ����
        // ���� ������Ʈ�� �ı��մϴ�.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // �̱��� �ν��Ͻ��� ���� �ν��Ͻ��� �����մϴ�.
        instance = this;

        // ���ӸŴ��� ������Ʈ�� �ı����� �ʰ� ���� ��ü�� �����մϴ�.
        //DontDestroyOnLoad(gameObject);

        // ����� �������� �����ɴϴ�.
        life = gameData.life;

        // �������� 0�� ��,
        if (gameData.life <= 0)
        {
            // ����� 0�� �Ǹ� Ÿ��Ʋ ������ ������
            SceneManager.LoadScene("TitleScene");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GetComponent<Text>();

        if (scoreText == null)
        {
            Debug.LogError("ScoreText�� ã�� �� �����ϴ�!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �ǽð� �����մϴ�.
        gameScore = gameData.score_Stage1;

        // ������ ����մϴ�.
        UpdateScoreText();

        // �ð��� ����մϴ�.
        UpdateTimeText();

        // ����� �پ��� �� ǥ��
        if (life == 2)
        {
            life_1.gameObject.SetActive(false);
        }
        else if (life == 1)
        {
            life_1.gameObject.SetActive(false);
            life_2.gameObject.SetActive(false);
        }
        
        else if (life == 0)
        {
            life_1.gameObject.SetActive(false);
            life_2.gameObject.SetActive(false);
            life_3.gameObject.SetActive(false);
        }

        // ��������
        if (gameTime < 0)
        {
            gameEnd = true;
        }

        // ��� 1 �پ��
        if(isDead == true)
        {
            waitTime += Time.deltaTime;
        }

        // �����
        if (waitTime > 1.5f)
        {
            if (life > 0)
            {
                gameData.score_Stage1 = 0;
                SceneManager.LoadScene("Stage1_Waiting");
            }
        }
    }

    // ���ھ� �ؽ�Ʈ ������Ʈ
    void UpdateScoreText()
    {
        if(isDead != true)
        {
            if (scoreText != null)
            {
                scoreText.text = string.Format("{0}", gameScore);
            }
        }
    }

    // Ÿ�� �ؽ�Ʈ ������Ʈ
    void UpdateTimeText()
    {
        if (isDead != true)
        {
            gameTime -= Time.deltaTime;

            if (timeText != null && gameTime >= 0)
            {
                timeText.text = string.Format("{0}", (int)gameTime);
            }

            else { return; }
        }
    }
}
