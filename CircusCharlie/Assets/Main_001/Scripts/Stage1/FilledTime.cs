using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledTime : MonoBehaviour
{
    public Image timeGauge;

    // Start is called before the first frame update
    void Start()
    {
        timeGauge.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ʾҴٸ�
        if (GameManager_Scene1.Instance.isDead == false)
        {
            // 30�� ���� ������ ä���
            if (timeGauge.fillAmount < 1)
            {
                timeGauge.fillAmount += Time.deltaTime * 0.035f;
            }
        }
        
    }
}
