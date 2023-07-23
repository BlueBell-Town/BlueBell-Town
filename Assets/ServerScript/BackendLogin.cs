using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendLogin : MonoBehaviour
{
    private Text ID_Text, PW_Text;
    private Text SignUpID_Text, SignUpPW_Text, SignUpVerifyPW_Text;

    private static BackendLogin _instance = null;


    #region MonoBehaviour
    private void Awake()
    {
        ID_Text = GameObject.Find("ID_text").GetComponent<Text>();
        PW_Text = GameObject.Find("PW_text").GetComponent<Text>();
    }

    public void PanelActived()
    {
        SignUpID_Text = GameObject.Find("SignUpID_text").GetComponent<Text>();
        SignUpPW_Text = GameObject.Find("SignUpPW_text").GetComponent<Text>();
        SignUpVerifyPW_Text = GameObject.Find("SignUpPWVerify_text").GetComponent<Text>();
    }

    #endregion

    #region Backend
    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
            }

            return _instance;
        }
    }

    public void CustomSignUp(/*string id, string pw*/) // Step 2. ȸ������ �����ϱ� ����
    {
        Debug.Log("ȸ�������� ��û�մϴ�.");

        if (SignUpPW_Text.text != SignUpVerifyPW_Text.text)
        {
            Debug.Log("�н����� Ȯ��!\n" + "ȸ�����Կ� �����߽��ϴ�.");
        }

        var bro = Backend.BMember.CustomSignUp(SignUpID_Text.text, SignUpPW_Text.text);

        if (bro.IsSuccess())
        {
            Debug.Log("ȸ�����Կ� �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.LogError("ȸ�����Կ� �����߽��ϴ�. : " + bro);
        }
    }

    public void CustomLogin(/*string id, string pw*/) // Step 3. �α��� �����ϱ� ����
    {
        Debug.Log("�α����� ��û�մϴ�.");

        var bro = Backend.BMember.CustomLogin(ID_Text.text, PW_Text.text);

        if (bro.IsSuccess())
        {
            Debug.Log("�α����� �����߽��ϴ�. : " + bro);
            SceneManager.LoadScene("JiHunScene");
        }
        else
        {
            Debug.LogError("�α����� �����߽��ϴ�. : " + bro);
        }
    }

    public void UpdateNickname(string nickname) // Step 4. �г��� ���� �����ϱ� ����
    {
        Debug.Log("�г��� ������ ��û�մϴ�.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
        else
        {
            Debug.LogError("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
    }
    #endregion
}