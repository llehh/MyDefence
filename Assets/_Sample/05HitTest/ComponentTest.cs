using NUnit.Framework.Internal.Commands;
using UnityEngine;

namespace Sample
{
    //Ÿ����ġ�� �̵� ���� Ŭ���� 
    public class ComponentTest : MonoBehaviour
    {
        #region Variablse
        private float moveSpeed = 5f;
        private Vector3 targetPosition;

        //[2] Ÿ�� ������Ʈ
        public Transform targetTransform;
        public GameObject targetGameObject;

        public TargetTest cTest;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1] �÷��̾� ������Ʈ
            //ComponentTest ��ũ��Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� ��ü(�ν��Ͻ�) ��������
            //ComponentTest ��ũ��Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� �ٸ� ������Ʈ�� �����ϱ�
            //this.transform
            //this.transform.GetComponent<������Ʈ Ÿ��>()
            //this.gameObject
            //this.gameObject.GetComponent<������Ʈ Ÿ��>()
            //this.GetComponent<������Ʈ Ÿ��>()

            //[2]
            //�̵� ��ǥ ����
            //targetPosition = new Vector3(7f, 1f, 8f);
            //targetPosition = targetGameObject.transform.position;
            //targetPosition = targetTransform.position;

            //TargetTest Ŭ������ �ν��Ͻ� ���� - ����
            //MonoBehaviour�� ��ӹ޴� Ŭ������ new�� �ν��Ͻ��� �����ؼ� ������� �ʴ´�
            //TargetTest tTest = new TargetTest();
            //tTest.a = 50;

            //TargetTest Ŭ������ �پ��ִ� ���ӿ�����Ʈ(Ʈ������) ��ü�� �����ͼ� �ν��Ͻ��� �����ϴ�
            /* TargetTest gTest = targetGameObject.GetComponent<TargetTest>();
             gTest.a = 50;
             Debug.Log(gTest.GetB());

             TargetTest tTest = targetTransform.GetComponent<TargetTest>();
             tTest.a = 70;
             Debug.Log(tTest.GetB()); */

            //TargetTest Ŭ������ �پ��ִ� ���ӿ�����Ʈ���� ���� TargetTest Ŭ���� �ν��Ͻ� ����
            cTest.a = 90;
            Debug.Log(cTest.GetB());
            //targetTransfrom
            //cTest.transform.GetComponent<������ƮŸ��>()
        }
        #endregion
    }
}

/*
���ӿ�����Ʈ(Ʈ������)�� �ν��Ͻ��� �������� ���
 
[1] transform�� �ִ� ������Ʈ�� ��ũ��Ʈ�� �߰��Ͽ� this.gameobject, this.transform���� �����Ѵ�
[2] ���̶�Űâ�� �����ϴ� �ٸ� ������Ʈ�� ���ӿ�����Ʈ (Ʈ������, ������Ʈ)�� �ν��Ͻ��� �����Ϸ���
    public���� ��ü ���� �����ϰ� �ν����� â���� �巡�׷� �����´�
 
������Ʈ(MonoBehaviour�� ��ӹ޴� Ŭ����)�� �ν��Ͻ��� �������� ���
[1] ���ӿ�����Ʈ(Ʈ������)�� �ν��Ͻ�.GetComponet<>()
[2] public���� ������Ʈ(MonoBehaviour�� ��ӹ޴� Ŭ����)�� �ν��Ͻ��� ������� ���� �� 
    �ν����� â���� �巡�׷� �����´�
*/
