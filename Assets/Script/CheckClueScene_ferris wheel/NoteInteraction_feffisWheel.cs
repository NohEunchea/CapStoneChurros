using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoteInteraction_feffisWheel : MonoBehaviour
{
    public static bool isfeffisWheel;

    public GameObject FindEvidence_feffisWheel;

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
        if (FindEvidence_feffisWheel.GetComponent<FindEvidence_feffisWheel>().bg_right_clue1_isClick == true && 
            FindEvidence_feffisWheel.GetComponent<FindEvidence_feffisWheel>().bg_center_clue1_isClick == true)
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
        if (FindEvidence_feffisWheel.GetComponent<FindEvidence_feffisWheel>().bg_right_clue1_isClick == true && 
            FindEvidence_feffisWheel.GetComponent<FindEvidence_feffisWheel>().bg_center_clue1_isClick == true)
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
            if (iskatalkLoveMan && !iskeyring)
            {
                Find_bg_center_clue1();
            }
            else
            {
                Find_bg_right_clue1Btn();
            }
        }
    }
    bool iskatalkLoveMan = false;
    bool iskeyring = false;
    public void Find_bg_center_clue1()
    {
        NoteInside(true);
        clueImgs.sprite = clueImg[0];
        clueTitle.text = "�������� �ڵ���";
        clueContent.text = "- �������� ���̴� ���� ����.\r\n- ��Ŀ�� �ܿ��� ������ �־�δ�.";
        iskatalkLoveMan = false;
        iskeyring = true;
    }
    public void Find_bg_right_clue1Btn()
    {
        NoteInside(true);
        clueImgs.sprite = clueImg[1];
        clueTitle.text = "Ŀ�� Ű��";
        clueContent.text = "- ������ �귣���� ������ Ŀ��Ű���̴�.\r\n- ������ Ű���� ���� ���ϱ�?";

        iskatalkLoveMan = true;
        iskeyring = false;
    }

    public void GoToMap()
    {
        isfeffisWheel = true;
        SceneManager.LoadScene("LoadScene_GoMap");
    }
}
