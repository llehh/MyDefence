using UnityEngine;

namespace Sample
{   
    /// <summary>
    /// UI ��ư ȣ�� �Լ� ����
    /// </summary>
    public class UITest : MonoBehaviour
    {
        #region Custom Method
        //Fire ��ư Ŭ���� ȣ��Ǵ� �Լ�
        //Fire ��ư�� ��ϵǴ� �Լ�
        public void Fire()
        {
            Debug.Log("�߻� �Ͽ����ϴ�.");
        }

        //���� ��ư Ŭ���� ȣ��Ǵ� �Լ�
        public void Jump()
        {
            Debug.Log("�÷��̾ �����Ͽ����ϴ�.");
        }
        #endregion
    }
}
