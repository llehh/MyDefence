using UnityEngine;

/*
(���̶�Ű â�� �ִ�) ���ӿ�����Ʈ�� gameobject �Ǵ� transform�� ���� �ϴ� ���
gameobject �Ǵ� transform �ν��Ͻ�(��ü)�� �������� ���

[1] ������ ���ӿ�����Ʈ�� ���� ��ũ��Ʈ �ҽ��� ������Ʈ�� �߰��Ͽ� ����(this) �����´� 
[2] ������ �ٸ� ���ӿ�����Ʈ�� gameobject, transform �ν��Ͻ�(��ü) ������ public �� �ʵ��
    ������ �� �ν����� â���� �巡�׷� ���� �����´�
[3] Find - ����Ƽ���� �����ϴ� API�� �̿��Ͽ� gameobject, transform �ν��Ͻ�(��ü)�� ��ȯ�޾�
    �����´� (ex GameObject.FindGameObjectWithTag, GameObject.FindGameObjectsWithTag..)
[4] Prefab ���ӿ�����Ʈ ������ Instantiate �Լ��� ��ȯ������ gameobject ��ü�� �����´�
*/

namespace Sample
{ 
public class GameObjectTest : MonoBehaviour
   {
        //[2]gameobject, transform �ν��Ͻ�(��ü) ������ public �� �ʵ� ����
        public GameObject publicObject;
        public Transform publicTransform;

        //[3] Find API�� tag�� �̿��Ͽ� gameobject, transform �ν��Ͻ�(��ü) ��������
        private GameObject[] tagObjects;
        private GameObject tagObject;

        //[4] Prefab ���ӿ�����Ʈ ������ Instantiate �Լ��� ��ȯ������ gameobject ��ü�� �����´�
        public GameObject gameobjectPrefab;

        //[5] ���� ����, ���� ��ɵ�� ������ �ִ� ���ӿ�����Ʈ�� gameobject, transform �ν��Ͻ�(��ü) ��������
        //�θ� ������Ʈ�� ����� ���� ����, ���� ��� ���� ������Ʈ���� �ڽ� ������Ʈ�� �߰��Ѵ�
        //�θ� ������Ʈ�� ��ü�� ���� �ڽ� ������Ʈ���� gameobject, transform �ν��Ͻ�(��ü)�� ����
        public Transform parentObject;
        private Transform[] childObjects;

        //[6] static ���� �̿� : �̱��� ����,
        // static �ʵ�: Ŭ�����̸�.�ʵ��̸�

        private void Start()
        {
            //[1] ���� ��ũ��Ʈ �ҽ��� ������Ʈ�� �߰��Ͽ� ����(this) �����´� 
            //this.gameObject
            //this.tramsform
            //this.gameObject.transform
            //this.transform.gameObject

            //[2]
            //publicObject.GetComponent<>()
            //publicTransform.position

            //[3] tag�� �̿��Ͽ� gameobject, transform �ν��Ͻ�(��ü) ��������
            tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
            tagObject = GameObject.FindGameObjectWithTag("Enemy");

            //[4] Prefab ���ӿ�����Ʈ ������ Instantiate �Լ��� ��ȯ������ gameobject ��ü�� �����´�
            GameObject prefabGo = Instantiate(gameobjectPrefab, this.transform.position, Quaternion.identity);

            //[5] �θ�� �ڽİ��� ���踦 �̿��Ͽ� �ڽ� ���ӿ�����Ʈ���� transform �ν��Ͻ�(��ü) ��������
            // childCount : �ڽĿ�����Ʈ�� ����, GetChild(index) : index��° �ڽ� �ν��Ͻ� ��ȯ
            childObjects = new Transform[parentObject.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = parentObject.GetChild(i);
            }


        }


    }
}
