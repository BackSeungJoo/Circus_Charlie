using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_Stage1 : MonoBehaviour
{
    // ���� ������
    public GameData gameData;

    // ����Ʈ ���ھ� text
    public Text bestScore1;
    public Text bestScore2;

    // ��ư�� �Ҵ��� ��ư ������Ʈ
    public Button button1;
    public Button button2;
    public string waitingSceneName1 = "Stage1_Waiting";
    public string waitingSceneName2 = "Stage2_Waiting";
    public string stageName1 = "Stage1";
    public string stageName2 = "Stage2";

    // ���ð�
    public float waitTime = 1.5f;

    private void Start()
    {
        // ����Ʈ ���ھ� stage 1 ����
        if (gameData.score_Stage1 > gameData.bestScore_Stage1)
        {
            gameData.bestScore_Stage1 = gameData.score_Stage1;
        }

        // ����Ʈ ���ھ� stage 2 ����
        if (gameData.score_Stage2 > gameData.bestScore_Stage2)
        {
            gameData.bestScore_Stage2 = gameData.score_Stage2;
        }

        // ����Ʈ ���ھ� ���
        bestScore1.text = string.Format("{0}", gameData.bestScore_Stage1);
        bestScore2.text = string.Format("{0}", gameData.bestScore_Stage2);

        // ��ư Ŭ�� �̺�Ʈ�� Load_Scene1 �Լ��� �����մϴ�.
        button1.onClick.AddListener(LoadScene1);
        button2.onClick.AddListener(LoadScene2);

        // ���� �����͸� �ʱ�ȭ�մϴ�.
        gameData.score_Stage1 = 0;
        gameData.score_Stage2 = 0;
        gameData.life = 3;
    }

    // �������� 1 �ε��մϴ�.
    private void LoadScene1()
    {
        SceneManager.LoadScene(waitingSceneName1);
    }

    // �������� 2 �ε��մϴ�.
    private void LoadScene2()
    {
        SceneManager.LoadScene(waitingSceneName2);
    }
}
