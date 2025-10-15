using UnityEngine;
using System.Collections;
namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //������ ������Ʈ
        public GameObject prefab;

        //�� Ÿ�ϵ��� �θ� ������Ʈ
        //public Transform parent;

        //�� Ÿ�� ���� üũ
        bool isCreate = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1]
            //Instantiate(prefab);
            //��ġ: (5f, 0f, 8f) ��Ÿ�� �����ϱ�
            //Instantiate(prefab, ��ġ, ����);
            //Vector3 position = new Vector3(5f, 0f, 8f);
            //Instantiate(prefab, position, Quaternion.identity);
            //Instantiate(prefab, new Vector3(5f, 0f, 8f), Quaternion.identity);

            //row(10)�� x column(10)�� Ÿ�Ը� ���
            //GenerateMap(10, 10);
            //GenerateMapTile(10, 10);

            //���� Ÿ�� ���
            //GenerateRandomMapTile();

            //���� Ÿ���� 1�� �������� 10�� ��´�
            //Ÿ�� �ϳ���� -> 1�� ������ -> Ÿ�� �ϳ���� -> 1�� ������
            //Debug.Log("[0] �ڷ�ƾ ����");
            //StartCoroutine(CreatMapTile());

            //Debug.Log("[4] Ÿ�� ���� �Ϸ�");
        }
        IEnumerator CreatMapTile()
        {
            //GenerateRandomMapTile();
            //Debug.Log("[1] ù��° Ÿ�� ����");
            //yield return new WaitForSeconds(1.0f);

            //GenerateRandomMapTile();
            //Debug.Log("[2] �ι�° Ÿ�� ����");
            //yield return new WaitForSeconds(1.0f);

            //GenerateRandomMapTile();
            //Debug.Log("[3] ����° Ÿ�� ����");
            //yield return new WaitForSeconds(1.0f);

            for (int i = 0; i < 10; i++)
            {
               GenerateRandomMapTile();
               Debug.Log($"{i+1}��° Ÿ�� ����");
               yield return new WaitForSeconds(1.0f);
            }

        }


        private void Update()
        {
            if (isCreate == false)
            {
                //���� Ÿ���� 1�� �������� 10�� ��´�
                //Ÿ�� �ϳ���� -> 1�� ������ -> Ÿ�� �ϳ���� -> 1�� ������
                Debug.Log("[0] �ڷ�ƾ ����");
                StartCoroutine(CreatMapTile());

                isCreate = true;
                Debug.Log($"[4] Ÿ�� ���� �Ϸ�: {isCreate}");
            }

            Debug.Log($"[99] ������Ʈ ���� ����");

        }
        #endregion

        #region Custom Method
        void GenerateMap(int row, int column)
        {
            //row�� x column�� Ÿ�Ը� ���, Ÿ�ϰ� ������  1�̴�
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 positoion = new Vector3(i * 5f, 0f, j * -5f);
                    Instantiate(prefab, positoion, Quaternion.identity);
                }
            }

        }

        //�� ���׷����͸� �θ�� �����ϸ� �� Ÿ�� ���
        void GenerateMapTile(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //�ν��Ͻ��� ��ġ ����
                    //Vector3 positoion = new Vector3(i * 5f, 0f, j * -5f);
                    //Instantiate(prefab, positoion, Quaternion.identity, this.transform);

                    //�ν��Ͻ� �� ��ġ ���� - ������ ���ӿ�����Ʈ(Transform) ��ü ��������
                    GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0f, j * -5f);
                }
            }
        }

        //raw(10)�� x column(10)�� �߿� ������ ��ġ�� Ÿ�� �ϳ� ���
        void GenerateRandomMapTile()
        {

            //int row = Random.Range(0, 10);
            //int column = Random.Range(0, 10);

            //0 1 2 3.... => r:0, c:0~9
            //10 11 12 13.... => r:1 c:0~9
            //20 21 22 23.... => r:2, c:0~9
            int randNumber = Random.Range(0, 100);
            int row = randNumber / 10;
            int column = randNumber % 10;


            Vector3 positoion = new Vector3(row * 5f, 0f, column * -5f);
            Instantiate(prefab, positoion, Quaternion.identity, this.transform);
        }

        /*IEnumerator CreatMapTile()
        {
            GenerateRandomMapTile();
            Debug.Log("[1] ù��° Ÿ�� ����");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[2] �ι�° Ÿ�� ����");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[3] ����° Ÿ�� ����");
            yield return new WaitForSeconds(1.0f);
        }
        */
        #endregion

    }
}

/*
�ڷ�ƾ �Լ� : ���� �Լ�

-�ϳ� �̻��� yield return ���� �� �־�� �Ѵ�
-yield return ������ ���� �ð� �����Ѵ�
-�ð�(��) ����: yield return new WaitForSeconds(�����ð�(��));

����
IEnumerator �Լ��̸�()
{
    //...
    yield return .. // �ϳ� �̻��� yield return ���� �� �־�� �Ѵ�
}

�ڷ�ƾ �Լ� ȣ��
StartCoroutine(�ڷ�ƾ�Լ��̸�);
*/