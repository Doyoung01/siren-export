using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class makeHint : MonoBehaviour
{
    private GameManager gm;
    private Objectcount oc;
    public TMP_Text hintText;

    Dictionary<int, string> objectName = new Dictionary<int, string>(); // ��ȣ�ۿ��� �������� �̸�
    Dictionary<string, int> factory = new Dictionary<string, int>();    // ��ȣ�ۿ��� �������� �ε��� �ѹ�
    string[] fhintString = {
        "�ҿ� �� Ÿ�� ������... ���忡?", "���, �� ��ĳ�� ������ ����?", 
        "�ݷ��ݷ�! ���Ⱑ �ʹ� �� ������...", "���� �� ���� ���� �ʾ�? ���� �̷��� �߰��� �ʾҴµ�...",
        "���, �ò�����! �� ��Ҹ��� ����?", "��� Ÿ��Ÿ�� �Ҹ��� ���µ�?",
        "���� �ִ� ��ȭ�� ��𰬾�?"
    };
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        oc = GameObject.Find("GameManager").GetComponent<Objectcount>();

        PlayerPrefs.SetInt("PlayCount", 0);
        PlayerPrefs.SetInt("Loop", 0);

        if(SceneManager.GetActiveScene().buildIndex == 2 )
        {
            factoryObjectNames();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            makeHints(2);
        }
        
    }

    public void makeHints(int scene)
    {
        if(scene == 2)
        {
            // ���� �÷��� �������� �� ��ȣ�ۿ��� �������� �̸��� ����
            if ((gm.getTime() >= 0) && (oc.getCount() < oc.getObcount()))
            {
                var objName = oc.getName();
                if (objName != null && objectName != null && !objectName.ContainsKey(factory[objName]))
                {
                    // Add(�ش� ��ȣ�ۿ� ������Ʈ�� ������ �ѹ�, �׿� ���� ��Ʈ ����)
                    objectName.Add(factory[objName], fhintString[factory[objName]]);
                }
            }
            // ���� Ŭ��� �������� �� ĵ������ ��Ʈ�� ���
            else if (!gm.getIsclear() && gm.getReturnCanvasActive())
            {
                int play = 0;
                int num = PlayerPrefs.GetInt("PlayCount", play); // �÷��� Ƚ���� �ҷ���
                int loop = 0;
                int isloop = PlayerPrefs.GetInt("Loop", loop);

                PlayerPrefs.SetInt("PlayCount", num + 1);
                PlayerPrefs.SetInt("Loop", 1);

                Debug.Log("this is num: " + num);

                if (num < 13 && isloop != 1)
                {
                    for (int i = 0; i < num && i < fhintString.Length; i++)
                    {
                        // ��ȣ�ۿ� ���� �ʾҰ�
                        // �̹� �����ִ� ������ �ƴ�
                        if (!(objectName.ContainsKey(i)))
                        {
                            hintText.text += fhintString[i] + "\n";
                        }
                    }
                }
            }
        }
    }

    public TMP_Text returnHints()
    {
        return hintText;
    }

    private void factoryObjectNames()
    {
        factory.Add("Boxes", 0);
        factory.Add("Boxes1", 0);
        factory.Add("Boxes2", 0);
        factory.Add("rightBoxSet", 0);
        factory.Add("leftBoxSet2", 0);
        factory.Add("leftBoxSet3", 0);

        factory.Add("CigaretteSet", 1);

        factory.Add("DustCollector1", 2);
        factory.Add("DustCollector2", 2);
        factory.Add("DustCollector3", 2);

        factory.Add("OverheatingRobot", 3);
        factory.Add("CollisionRobots", 4);

        factory.Add("weldingTable", 5);

        factory.Add("fireLeft", 6);
        factory.Add("fireRight", 6);
    }
}
