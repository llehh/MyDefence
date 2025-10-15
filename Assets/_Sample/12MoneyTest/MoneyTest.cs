using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.Serialization;
namespace Sample
{ 
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    public class MoneyTest : MonoBehaviour
    {
        #region Variables
        //������
        private int gold;

        //�ʱ� ������
        [SerializeField]
        private int stratGold = 1000;

        // ������ UI Text
        public TextMeshProUGUI goldText;

        //���Ź�ư UI
        public Button button1000;
        public Button button9000;   
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //�ʱ�ȭ
            //������ ���������� ����� �����͸� �����ͼ� �������� �ʱ�ȭ

            //������ �ٿ�ε� �ް� ó�� �����ϸ� ����
            gold = stratGold;  //�ʱ� ������ ����
        }

        private void Update()
        {
            //������ üũ�Ͽ� ��ư �� ����
            if (HasGold(1000))
            {
                //button1000.image.color = Color.white;
                button1000.interactable = true;
            }
            else
            {
                //button1000.image.color = Color.red;
                button1000.interactable = false;
            }

            if (HasGold(9000))
            {
                //button9000.image.color = Color.white;
                button9000.interactable = true;
            }
            else
            {
                //button9000.image.color = Color.red;
                button9000.interactable = false;
            }

            //�����ݰ� UI Text ����
            goldText.text = gold.ToString() + "GOLD";

        }
        #endregion

        #region Custom Method
        public void Save1000()
        {
            Debug.Log("1000 Gold Save");
            AddGold(1000);
        }

        public void Purchase1000()
        {
            if (UseGold(1000) == true)
            {
                Debug.Log("1000 Item Purchase");
            }
        }

        public void Purchase9000()
        {
            if (UseGold(9000))
            {
                Debug.Log("9000 Item Purchase");
            }
        }

        //��, Gold 
        //���� ����: ���, ����Ʈ, ĳ��, �ʱ� ������, �����ޱ�
        public void AddGold(int amount)
        { 
            gold += amount;
        }

        //���� ����: ������ ����, �ⱸ ���, �Ǽ� ���, �����ϱ�...
        //���� �����ϸ� ���� ������� �ʰ� return false;
        //���� ����ϸ� ���� ����ϰ� return true;
        public bool UseGold(int amount)
        {
            //������ üũ
            if (gold < amount)
            {
                Debug.Log("�������� �����մϴ�");
                return false;
            }

            gold -= amount;      
            return true;
        }

        //������ üũ, �ܰ� Ȯ��
        public bool HasGold(int amount)
        {
            return gold >= amount;
        }
        #endregion
    }

}
