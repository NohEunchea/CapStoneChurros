using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class application_BackStage : MonoBehaviour
{
    [SerializeField] private GameObject go_clueImg;
    [SerializeField] private Image clueImgs;
    [SerializeField] private Sprite[] clueImg;
    [SerializeField] private TextMeshProUGUI clueTitle;
    [SerializeField] private TextMeshProUGUI clueContent;


    public void Find_bg_center_clue1()
    {
        go_clueImg.SetActive(true);
        clueImgs.sprite = clueImg[0];
        clueTitle.text = "����";
        clueContent.text = "- ���̰������� �Ĵ� �����̴�.\r\n- ���뿡 ����ƽ �ڱ�ó�� ���̴� ���� �����ִ�.\r\n- ����ƽ�� ������?";
    }
    public void Find_bg_center_clue1_1()
    {
        go_clueImg.SetActive(false);
        clueImgs.sprite = clueImg[1];
        clueTitle.text = "�뿡 ��� ����";
        clueContent.text = "- �� ���簡 �뿡 ��� �ִ�.\r\n- ���� �����ϱ�?.";
    }
    public void Find_bg_right_clue1Btn()
    {
        go_clueImg.SetActive(false);
        clueImgs.sprite = clueImg[2];
        clueTitle.text = "������";
        clueContent.text = "- �򷯽��� ������ �������̴�.";

    }
}
