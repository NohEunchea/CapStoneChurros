using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoteInteraction_BackStage : MonoBehaviour
{
    public static bool iSBackStage;

    public GameObject findEvidence_BackStage;

    public bool isAllClear = false;

    public Animator animator;
    public Animator animator_NoteBtn;

    //��Ʈ ������
    public GameObject noteinside;

    public GameObject goToMap;

    [SerializeField] private GameObject noteOpen;
    [SerializeField] private GameObject noteClose;

    public GameObject go_clueImg;
    public Image clueImgs;
    public Sprite[] clueImg;
    public TextMeshProUGUI clueTitle;
    public TextMeshProUGUI clueContent;

    private void Start()
    {
        noteinside.SetActive(false);
        noteOpen.SetActive(true);
        noteClose.SetActive(false);
        go_clueImg.SetActive(false);

        isAllClear = true;
    }
    public void NoteOpen()
    {
        noteinside.SetActive(true);
        noteOpen.SetActive(false);
        noteClose.SetActive(true);
    }

    public void NoteClose()
    {
        noteinside.SetActive(false);
        noteOpen.SetActive(true);
        noteClose.SetActive(false);
    }

    public void FindClueNoteInteraction()
    {
        StartCoroutine(ChangeNoteBtn());
    }

    IEnumerator ChangeNoteBtn()
    {
        animator_NoteBtn.SetBool("isChange", true);
        yield return new WaitForSeconds(0.5f);
        animator_NoteBtn.SetBool("isChange", false);
    }

    //��Ʈ ������ ���콺�� ��� ������ �ִϸ��̼�
    public void NextRightHover()
    {
        animator.SetBool("isRightClick", true);
    }
    //��Ʈ ������ ���콺�� ���� ������ �ִϸ��̼�
    public void NextRightHoverExit()
    {
        animator.SetBool("isRightClick", false);
    }

    bool isNext = false;
    //��Ʈ Ŭ���� ������ ��Ʈ �ѱ� �ִϸ��̼�
    public void NextNoteClick()
    {
        if (findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_right_clue1_isClick == true &&
            findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_center_clue1_isClick == true &&
            findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_center_clue1_1_isClick == true)
        {
            Debug.Log("��� ���Ÿ� ã��");
            animator.SetBool("isNext", true);
            NoteInside(false);
            goToMap.SetActive(true);
            isNext = true;
        }
    }
    //��Ʈ ���� ���� Ŵ
    private void NoteInside(bool isopen)
    {
        go_clueImg.SetActive(isopen);
        clueTitle.text = " ";
        clueContent.text = " ";
    }
    public void NextNoteClickExit()
    {
        if (findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_right_clue1_isClick == true &&
            findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_center_clue1_isClick == true &&
            findEvidence_BackStage.GetComponent<FindEvidence_BackStage>().bg_center_clue1_1_isClick == true)
        {
            StartCoroutine(enumerator());
        }
    }
    IEnumerator enumerator()
    {
        animator.SetBool("isNext", false);
        clueTitle.text = " ";
        clueContent.text = " ";

        yield return new WaitForSeconds(0.4f);

        if (isNext)
        {
            if (!isCokPop && isPowder && !ischurrosReceipt)
            {
                Find_bg_center_clue1_1();
            }
            else if (isCokPop && !isPowder && !ischurrosReceipt)
            {
                Find_bg_center_clue1();
            }
            else
            {
                Find_bg_right_clue1Btn();
            }
        }
    }
    public bool isCokPop = false;
    public bool isPowder = false;
    public bool ischurrosReceipt = false;
    public void Find_bg_center_clue1()
    {
        NoteInside(true);
        clueImgs.sprite = clueImg[0];
        clueTitle.text = "����";
        clueContent.text = "- ���̰������� �Ĵ� �����̴�.\r\n- ���뿡 ����ƽ �ڱ�ó�� ���̴� ���� �����ִ�.\r\n- ����ƽ�� ������?";
        isCokPop = false;
        isPowder = true;
        ischurrosReceipt = false;
    }
    public void Find_bg_center_clue1_1()
    {
        NoteInside(true);
        clueImgs.sprite = clueImg[1];
        clueTitle.text = "�뿡 ��� ����";
        clueContent.text = "- �� ���簡 �뿡 ��� �ִ�.\r\n- ���� �����ϱ�?.";
        isCokPop = false;
        isPowder = false;
        ischurrosReceipt = true;
    }
    public void Find_bg_right_clue1Btn()
    {
        NoteInside(true);
        clueImgs.sprite = clueImg[2];
        clueTitle.text = "������";
        clueContent.text = "- �򷯽��� ������ �������̴�.";

        isCokPop = true;
        isPowder = false;
        ischurrosReceipt = false;
    }

    public void GoToMap()
    {
        iSBackStage = true;
        SceneManager.LoadScene("LoadScene_GoMap");
    }
}
