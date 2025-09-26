using UnityEngine;

namespace Sample
{
    //MonoBehaviour Ŭ������ �̺�Ʈ�Լ� ����
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake ����");  //1ȸ ����
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable ����");   //1ȸ ���� - Ȱ��ȭ �Ҷ� ����
        }

        private void Start()
        {
            Debug.Log("[2] Start ����");   //1ȸ ����
        }

        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate ����");   //1�ʿ� 50�� ȣ��, ����
        }

        private void Update()
        {
            Debug.Log("[4] Update ����");     //�� �����Ӹ��� ȣ��, 1�� 60(300, 30) ȣ��
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate ����");     //Update() ���� �ڿ� �ٷ� ���� ����
        }

        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable ����");    //1ȸ ���� - �� Ȱ��ȭ �Ҷ� ����
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestory ����");      // ���̶�Ű â���� �����ɶ�(ų) - 1ȸ ����  
        }



    }
}
