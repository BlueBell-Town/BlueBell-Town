using UnityEngine;
using System.Threading.Tasks; // [����] async ����� �̿��ϱ� ���ؼ��� �ش� namepsace�� �ʿ��մϴ�.

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendManager : MonoBehaviour
{

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
        DontDestroyOnLoad(this);
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

    }
}