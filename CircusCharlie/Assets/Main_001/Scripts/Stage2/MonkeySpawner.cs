using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawner : MonoBehaviour
{
    public GameObject monkey_Prefab;        // ������ ������ ������
    public GameObject blueMonkey_Prefab;    // ������ �Ķ������� ������
    public GameObject scoreUp_Prefab;       // ������ ������� �ݶ��̴� ������
    public GameObject scoreUp2_Prefab;      // ������ ������� �ݶ��̴� ������ 2

    public GameObject endLinePrefab;        // ����� ������ ����

    public float timeSpawnMin = 0.2f;       // ������ �ð����� �ּ�
    public float timeSpawnMax = 1.0f;       // ������ �ð����� �ִ�
    private float timeSpawn;                // ���� ��ġ������ �ð� ����
    private float lastSpawnTime;            // ������ ��ġ ����

    private float yPos = 1f;                // ������ y�� ��
    private float xPos = 25f;               // ������ x�� ��

    private bool isEndSpawn = false;        // ������� ���� ����� üũ

    void Start()
    {
        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;

        // ������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ
        timeSpawn = 0f;
    }

    void Update()
    {
        // ���� ���� �ð� 10�� ������ �������� �ʱ�
        if (GameManager_Scene2.instance.gameTime > 10)
        {
            // ������ ��ġ �������� �ð������� �����ٸ�
            if (Time.time >= lastSpawnTime + timeSpawn)
            {
                // ��ϵ� ������ ��ġ ������ ���� �������� ����
                lastSpawnTime = Time.time;

                // ���� ��ġ������ �ð� ������ timeSpawnMin ~ timeSpawnMax ���� ���� ����
                timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);

                // ������ ���� & ���� Ȯ�ο� �ݶ��̴� ����
                GameObject newMonkey = Instantiate(monkey_Prefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                GameObject newScoreUp = Instantiate(scoreUp_Prefab, new Vector3(xPos, 0f, 0f), Quaternion.identity);

                // Ȯ���� �Ķ������� ����
                if (Random.Range(0, 10) <= 4)
                {
                    // �Ķ� ������ ���� & ���� Ȯ�ο� �ݶ��̴� 2 ����
                    GameObject newBonusScore = Instantiate(blueMonkey_Prefab, new Vector3(xPos - 5, yPos, 0f), Quaternion.identity);
                    GameObject newScoreUp2 = Instantiate(scoreUp2_Prefab, new Vector3(xPos - 5, 0f, 0f), Quaternion.identity);
                }
            }
        }

        // �������� 5�� ������ ������� �����մϴ�.
        else if (GameManager_Scene2.instance.gameTime < 5 && isEndSpawn == false)
        {
            // ����� ����
            GameObject endLine = Instantiate(endLinePrefab, new Vector3(xPos, 0f, 0f), Quaternion.identity);
            isEndSpawn = true;
        }

        else { return; }


    }
}


