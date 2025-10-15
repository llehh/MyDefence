using UnityEngine;

namespace Sample
{
    //�̱��� ���� Ŭ����
    public class Singleton
    {
        //Ŭ������ �ν��Ͻ�(��ü)�� ����(static) ���� ����
        private static Singleton instance;

       //public�� �Ӽ����� instance�� ������ �����ϱ�
        public static Singleton Instance
        {
            get 
            {
                if(instance == null)
                { 
                   //�ν��Ͻ� ����
                  instance = new Singleton();  
                }

                return instance;
            }
        }

        /*//public�� �޼���� instance�� ������ �����ϱ�
        public static Singleton Instance()
        {
            if (instance == null)
            { 
                //�ν��Ͻ� ����
                instance = new Singleton();
            }

            return instance;
        }
*/

        //�ʵ� : �ν��Ͻ��̸�.number
        public int number;
    }
}

/*
Singleton.Instance.number = 10;

Debug.Log(Singleton.Instance.number.ToString());

*/