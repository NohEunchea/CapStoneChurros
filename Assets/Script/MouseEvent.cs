using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MouseEvent : MonoBehaviour
{
    //public GameObject NoteInteraction_BackStage;

    [SerializeField] GameObject Backstage;
    [SerializeField] GameObject Storage;
    [SerializeField] GameObject Toilet;
    [SerializeField] GameObject CleanRoom;
    [SerializeField] GameObject Ferriswheel;

    [SerializeField] GameObject Selectcriminal;
    public TextMeshProUGUI messageText;


    public TextMeshProUGUI showinfo;
    public AudioSource audioSource;
    public AudioClip[] audioCilp;

    private void Awake()
    {
        showinfo.text = " ";
        bool myBoolValue_Storage = FindEvidence_Storage.isStorage;
        Debug.Log("Storage : "+ myBoolValue_Storage);

        bool myBoolValue_CleanRoom = NoteInteraction_CleanRoom.isCleanRoom;
        Debug.Log("CleanRoom : " + myBoolValue_CleanRoom);

        bool myBoolValue_feffisWheel = NoteInteraction_feffisWheel.isfeffisWheel;
        Debug.Log("CleanRoom : " + myBoolValue_feffisWheel);

        bool myBoolValue_Toilet = NoteInteraction.iSManToilet;
        Debug.Log("CleanRoom : " + myBoolValue_Toilet);

        bool myBoolValue_BackStage = NoteInteraction_BackStage.iSBackStage;
        Debug.Log("CleanRoom : " + myBoolValue_BackStage);

        if (myBoolValue_Storage)
        {
            Storage.SetActive(false);
        }
        if (myBoolValue_CleanRoom)
        {
            CleanRoom.SetActive(false);
        }
        if (myBoolValue_feffisWheel)
        {
            Ferriswheel.SetActive(false);
        }
        if (myBoolValue_Toilet)
        {
            Toilet.SetActive(false);
        }
        if (myBoolValue_BackStage)
        {
            Backstage.SetActive(false);
        }

        if(myBoolValue_Storage && myBoolValue_CleanRoom && myBoolValue_feffisWheel && myBoolValue_Toilet && myBoolValue_BackStage)
        {
            Selectcriminal.SetActive(true);
        }
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnCriSeoButtonClick()
    {
        // �θ� ������Ʈ�� �����Ǿ� ������
        if (Selectcriminal != null)
        {
            SceneManager.LoadScene("FianlScene");
            // �θ� ������Ʈ�� ��Ȱ��ȭ
            Selectcriminal.SetActive(false);
        }
        else
        {
            // ���� ó��: �θ� ������Ʈ�� �����Ǿ� ���� ���� ��
            Debug.LogError("Parent object not assigned!");
        }
    }

    // CriYuButton Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnCriYuButtonClick()
    {
        if (messageText != null)
        {
            messageText.text = "������ �ƴմϴ�.";
        }
        else
        {
            Debug.LogError("UI Text not assigned!");
        }
    }
    public void HoverToilet()
    {
        showinfo.text = " ";
        Debug.Log("toilet");
        showinfo.text = "ȭ���";
        audioSource.clip = audioCilp[0];
        audioSource.Play();
    }
    public void HoverStorage()
    {
        showinfo.text = " ";
        Debug.Log("Storage");
        showinfo.text = "�нǹ� ����";
        audioSource.clip = audioCilp[0];
        audioSource.Play();
    }
    public void HoverBackstage()
    {
        showinfo.text = " ";
        Debug.Log("Backstage");
        showinfo.text = "�齺������";
        audioSource.clip = audioCilp[0];
        audioSource.Play();
    }
    public void HoverCleanRoom()
    {
        showinfo.text = " ";
        Debug.Log("CleanRoom");
        showinfo.text = "û�ҽ�";
        audioSource.clip = audioCilp[0];
        audioSource.Play();
    }
    public void HoverFerriswheel()
    {
        showinfo.text = " ";
        Debug.Log("Ferriswheel");
        showinfo.text = "������";
        audioSource.clip = audioCilp[0];
        audioSource.Play();
    }
    public void HoverExit()
    {
        showinfo.text = " ";
    }
    public void ClickToilet()
    {
        Debug.Log("ȭ��� ������ �̵�");
        SceneManager.LoadScene("LoadScene_GoManToilet");
    }
    public void ClickStorage()
    {
        Debug.Log("�нǹ� ������ ������ �̵�");
        SceneManager.LoadScene("LoadScene_GoStorage");

    }
    public void ClickBackstage()
    {
        //ickBackstage = true;
        Debug.Log("�齺������ ������ �̵�");
        SceneManager.LoadScene("LoadScene_GoBackStage");
    }
    public void ClickCleanRoom()
    {
        Debug.Log("û�ҷ� ������ �̵�");
        SceneManager.LoadScene("LoadScene_GoCleanRoom");
    }
    public void ClickFerriswheel()
    {
        Debug.Log("������ ������ �̵�");
        SceneManager.LoadScene("LoadScene_Goferris wheel");
    }
}
