using UnityEngine;

namespace Sample
{
    //MonoBehaviour�� ��ӹ��� Ŭ���� �̱��� ���� ������
    //����Ƽ���� ���ӿ�����Ʈ�� �����Ǵ� Ŭ������ �̱��� ���� ������
    public class SingletonMono : MonoBehaviour
   {
        //Ŭ������ �ν��Ͻ�(��ü)�� ����(static) ���� ����
        private static SingletonMono instance;

        //public�� �Ӽ����� instance�� ���������� �����ϱ�
        public static SingletonMono Instance
        {
            get 
            { 
                return instance;
            }
        }

        private void Awake()
        {
            //instance�� �����ϸ� this ������Ʈ ų�Ѵ�
            if(instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;

            //�� ����� �� ��ũ��Ʈ�� �����Ǿ� �ִ� ������Ʈ�� �������� �ʴ´� 
            //DontDestroyOnLoad(this.gameObject);
        }

        //�ʵ�
        public int number;
    }
}
