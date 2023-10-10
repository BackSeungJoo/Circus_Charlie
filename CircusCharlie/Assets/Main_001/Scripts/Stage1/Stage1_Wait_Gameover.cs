using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Stage1_Wait_Gameover : MonoBehaviour
{
    public GameData gameData;
    public Text Stage1_Wait_Text;

    // Start is called before the first frame update
    void Start()
    {
        int life_ = gameData.life;

        // ������ ���� �Ǿ��� ��
        if (life_ == 0)
        {
            Stage1_Wait_Text.text = string.Format("GameOver");
        }
        
        // ������ �������� �ʾ��� ��
        else
        {
            Stage1_Wait_Text.text = string.Format("Stage1 ...");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
