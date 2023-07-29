using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // [����] async ����� �̿��ϱ� ���ؼ��� �ش� namepsace�� �ʿ��մϴ�.

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendManager : MonoBehaviour
{
    public InputField input;

    void Start()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻� 
        }
        Test();
        DontDestroyOnLoad(this);
    }

    public void GetGoogleHash()
    {
        string googlehash = Backend.Utils.GetGoogleHash();
        Debug.Log("Hash");
        if(!string.IsNullOrEmpty(googlehash))
        {
            Debug.Log(googlehash);
            if(input != null)
            {
                input.text = googlehash;
            }
        }
    }

    // =======================================================
    // [�߰�] ���� �Լ��� �񵿱⿡�� ȣ���ϰ� ���ִ� �Լ�(����Ƽ UI ���� �Ұ�)
    // =======================================================
    async void Test()
    {
        // [�߰�] �ڳ� ȸ������ �Լ�
        //await Task.Run(() => {
        //    BackendLogin.Instance.CustomSignUp("user1", "1234");
        //    Debug.Log("�׽�Ʈ�� �����մϴ�.");
        //});

        // [�߰�] �ڳ� ȸ������ �Լ�
        //await Task.Run(() => {
        //    BackendLogin.Instance.CustomLogin("user1", "1234"); 
        //    Debug.Log("�׽�Ʈ�� �����մϴ�.");
        //});

        // [�߰�] �г��� ����
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1", "1234"); // [�߰�] �ڳ� �α���
        //});

        // [�߰�] ������ �����Լ�
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1","1234");
        //    BackendGameData.Instance.GameDataInsert();
        //    Debug.Log("�׽�Ʈ ����");
        //});

        // [�߰�] ������ �ҷ����� �Լ�
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1", "1234");
        //    BackendGameData.Instance.GameDataInsert();
        //    BackendGameData.Instance.GameDataGet();
        //    Debug.Log("�׽�Ʈ ����");
        //});

        // [�߰�] ������ ���� �� ����� �Լ�
        await Task.Run(() =>
        {
            BackendLogin.Instance.CustomLogin("user1", "1234");

            BackendGameData.Instance.GameDataGet();
            
            if(BackendGameData.userData == null)
            {
                BackendGameData.Instance.GameDataInsert();
            }

            BackendGameData.Instance.LevelUp();
            BackendGameData.Instance.GamedataUpdate();

            Debug.Log("�׽�Ʈ ����");
        });

    }
}