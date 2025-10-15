using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// WayPoint(���� �������� ���� �б���)���� �����ϴ� Ŭ����
    /// </summary>
    public class WayPoints : MonoBehaviour
    {
        #region Variables
        //WayPoint(���� �������� ���� �б���)���� ������Ʈ�� �����ϴ� �迭
        public static Transform[] points;
        #endregion

        #region Unity Event Method
        private void Awake()
        { 
            //�ʱ�ȭ
            //WayPoint �迭 ��Ҽ� ���� - WayPoint ���� ��������
            points = new Transform[this.transform.childCount];
            //Debug.Log($"WayPoint�� ����: {this.transform.childCount}");
            for (int i = 0; i < points.Length; i++)
            {
                //WayPoint�� transform�� ������� �����ͼ� �迭�� �����ϱ� 
                points[i] = this.transform.GetChild(i);
            }
        }
        #endregion
    }
}
