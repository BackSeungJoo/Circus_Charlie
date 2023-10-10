using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject fireRingPrefab;   // ������ �� ������
    public GameObject bonusScorePrefab; // ������ ���ʽ��ָӴ� ������
    public GameObject scoreUpPrefab;    // ������ ������� �ݶ��̴� ������

    public float timeSpawnMin = 0.2f;   // ������ �ð����� �ּ�
    public float timeSpawnMax = 1.0f;   // ������ �ð����� �ִ�
    private float timeSpawn;            // ���� ��ġ������ �ð� ����
    private float lastSpawnTime;        // ������ ��ġ ����

    private float yPos = -1.5f;         // ������ y�� ��
    private float xPos = 25f;           // ������ x�� ��

    private float bonusScore_Ypos = -0.6f;       // ���ʽ� �ָӴ� y�� ��
    private float bonusScore_Xpos = 25.25f;       // ���ʽ� �ָӴ� x�� ��

    // Start is called before the first frame update
    void Start()
    {
        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;

        // ������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ
        timeSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� �ð� 7�� ������ �������� �ʱ�
        if(GameManager_Scene1.instance.gameTime > 7)
        {
            // ������ ��ġ �������� �ð������� �����ٸ�
            if (Time.time >= lastSpawnTime + timeSpawn)
            {
                // ��ϵ� ������ ��ġ ������ ���� �������� ����
                lastSpawnTime = Time.time;

                // ���� ��ġ������ �ð� ������ timeSpawnMin ~ timeSpawnMax ���� ���� ����
                timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);

                // �� ����
                GameObject newRing = Instantiate(fireRingPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                GameObject newScore = Instantiate(scoreUpPrefab, new Vector3(xPos, 0f, 0f), Quaternion.identity);

                // Ȯ���� ���ʽ��ָӴ� ����
                if (Random.Range(0, 10) <= 3)
                {
                    // ���ʽ� �ָӴ� ����
                    GameObject newBonusScore = Instantiate(bonusScorePrefab, new Vector3(bonusScore_Xpos, bonusScore_Ypos, 0f), Quaternion.identity);
                }
            }
        }

        else { return; }

        
    }
}
