using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class application_feffisWheel : MonoBehaviour
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
        clueTitle.text = "�������� �ڵ���";
        clueContent.text = "- �������� ���̴� ���� ����.\r\n- ��Ŀ�� �ܿ��� ������ �־�δ�.";
    }
    public void Find_bg_right_clue1Btn()
    {
        go_clueImg.SetActive(false);
        clueImgs.sprite = clueImg[1];
        clueTitle.text = "Ŀ�� Ű��";
        clueContent.text = "- ������ �귣���� ������ Ŀ��Ű���̴�.\r\n- ������ Ű���� ���� ���ϱ�?";
    }
}
