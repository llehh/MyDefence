using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// �÷��̾� �Ӽ�,���ӵ����� ������ �����ϴ� Ŭ����
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //������
        private static int money;

        //������ �б� ���� �Ӽ�
        public static int Money
        {
            get { return money; }
        }


        //�ʱ������
        [SerializeField]
        private int startMoney = 400;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //�ʱ�ȭ
            money = startMoney; //�ʱ� ������ ����
            Debug.Log($"�ʱ� ������ {startMoney}��带 �����Ͽ����ϴ�");
        }
        #endregion

        #region Custom Method
        //�� ����
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        //�� ����
        public static bool UseMoney(int amount)
        {
            //������ üũ
            if (money < amount)
            {
                Debug.Log("���� �����մϴ�");
                return false;
            }

            money -= amount;
            return true;
        }

        //������ üũ
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }
        #endregion
    }
}

