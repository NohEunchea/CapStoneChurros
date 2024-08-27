using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoteInteraction_CleanRoom : MonoBehaviour
{
    public static bool isCleanRoom;

    public GameObject FindEvidence_CleanRoom;

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

    public bool isFind_bg_center_clue1 = false;

    private void Start()
    {
        noteinside.SetActive(false);
        noteOpen.SetActive(true);
        noteClose.SetActive(false);
        //go_clueImg.SetActive(false);
    }
    public void NoteOpen()
    {
        noteinside.SetActive(true);
        noteOpen.SetActive(false);
        Find_bg_center_clue1();
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
    public void Find_bg_center_clue1()
    {
        clueImgs.sprite = clueImg[0];
        clueTitle.text = "���";
        clueContent.text = "- ���� ������ �������� ������ ���.\r\n- ������ �������� ����.";
    }

    public void isAllCheck()
    {

        if(FindEvidence_CleanRoom.GetComponent<FindEvidence_CleanRoom>().bg_center_clue1_isClick == true &&
          FindEvidence_CleanRoom.GetComponent<FindEvidence_CleanRoom>().bg_right_clue1_isClick == true)
        {
            goToMap.SetActive(true);
        }

    }

    public void GoToMap()
    {
        isCleanRoom = true;
        SceneManager.LoadScene("LoadScene_GoMap");
    }
}
