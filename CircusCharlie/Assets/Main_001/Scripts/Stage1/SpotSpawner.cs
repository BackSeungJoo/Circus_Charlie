using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotSpawner : MonoBehaviour
{
    public GameObject fireSpotPrefab;   // ������ ���� ������
    public GameObject scoreUpPrefab;    // ������ ������� �ݶ��̴� ������
    public GameObject endLinePrefab;    // ����� ������

    public float timeSpawnMin = 4f;     // ������ �ð����� �ּ�
    public float timeSpawnMax = 8f;     // ������ �ð����� �ִ�
    private float timeSpawn;            // ���� ��ġ������ �ð� ����
    private float lastSpawnTime;        // ������ ��ġ ����

    private float yPos = -4f;           // ������ y�� ��
    private float xPos = 25f;           // ������ x�� ��

    private bool isEndSpawn = false;    // ������� ���� ����� üũ

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
        // �������� 5�� ������ �������� ����
        if (GameManager_Scene1.instance.gameTime > 7)
        {
            // ������ ��ġ �������� �ð������� �����ٸ�
            if (Time.time >= lastSpawnTime + timeSpawn)
            {
                // ��ϵ� ������ ��ġ ������ ���� �������� ����
                lastSpawnTime = Time.time;

                // ���� ��ġ������ �ð� ������ timeSpawnMin ~ timeSpawnMax ���� ���� ����
                timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);

                // �� ����
                GameObject newRing = Instantiate(fireSpotPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                GameObject newScore = Instantiate(scoreUpPrefab, new Vector3(xPos, 0f, 0f), Quaternion.identity);
            }

        }

        // �������� 5�� ������ ������� �����մϴ�.
        else if (GameManager_Scene1.instance.gameTime < 5 && isEndSpawn == false)
        {
            // ����� ����
            GameObject endLine = Instantiate(endLinePrefab, new Vector3(xPos + 3f, -4.1f, 0f), Quaternion.identity);
            isEndSpawn = true;
        }

        else { return; }

        
    }
}
