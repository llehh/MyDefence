using Unity.VisualScripting;
using UnityEngine;

namespace Sample
{
    public class SingletonTest : MonoBehaviour
    {
        private void Start()
        {
            //����(static) ��� ���� ����ϱ�(������ ����)
            StaticTest.number = 20;
            Debug.Log(StaticTest.number.ToString());

            
            //�̱��� ���� Ŭ���� �ν��Ͻ� ����
            //�̱��� Ŭ������ new�ؼ� ������� �ʴ´�
            /*Singleton singleton = new Singleton();
            Debug.Log(singleton.ToString());*/

            var singletonA = Singleton.Instance;
            var singletonB = Singleton.Instance;
            if (singletonA == singletonB)
            {
                Debug.Log(singletonA.ToString());
            }

            Singleton.Instance.number = 10;
            Debug.Log(singletonA.number.ToString());

            //MonoBehaviour�� ��ӹ��� Ŭ���� �̱��� ����
            SingletonMono.Instance.number = 30;
            Debug.Log(SingletonMono.Instance.number.ToString());

        }
    }

}

/*
����������  
�̱���(Singleton) ����
: �ϳ��� �ν��Ͻ��� ���� : new�� �ѹ��� �Ѵ�
: Ŭ������ �ν��Ͻ��� ������ ������ �����ϴ� : �ν��Ͻ� ������ static ����

:�̱����� Ŭ������ �ν��Ͻ� ������ �ڽ� Ŭ���� �ڵ��� �ȿ��� �����Ѵ�
*/
