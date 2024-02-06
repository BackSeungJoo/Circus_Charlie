using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontColorChange : MonoBehaviour
{
    public GameObject[] scoreTexts;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 1�ʸ��� ChnageColor �Լ��� ȣ���մϴ�.
        InvokeRepeating("ChangeColor", 0f, 0.5f);
    }

    private void ChangeColor()
    {
        // ���� ������ �����ϰ� ���� �������� ��ȯ�մϴ�.

        if (currentIndex % 3 == 0)
        {
            scoreTexts[0].gameObject.SetActive(true);
            scoreTexts[1].gameObject.SetActive(false);
            scoreTexts[2].gameObject.SetActive(false);
        }
        else if (currentIndex % 3 == 1)
        {
            scoreTexts[0].gameObject.SetActive(false);
            scoreTexts[1].gameObject.SetActive(true);
            scoreTexts[2].gameObject.SetActive(false);
        }
        else
        {
            scoreTexts[0].gameObject.SetActive(false);
            scoreTexts[1].gameObject.SetActive(false);
            scoreTexts[2].gameObject.SetActive(true);
        }

        currentIndex++;
    }
}
