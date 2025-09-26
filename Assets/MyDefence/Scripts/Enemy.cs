using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy �� �����ϴ� Ŭ����
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region Variables
        //�̵� ��ǥ ��ġ�� ������ �ִ� ������Ʈ 
        public Transform target;

        //�̵� �ӵ�
        public float speed = 10f;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            //Ÿ���� ���� �̵�
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //���� ����
            //Ÿ�ٰ� Enemy�� �Ÿ��� ���ؼ� �����Ÿ� �ȿ� ������ �����̶�� �����Ѵ�
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.5f)
            {
                Arrive();
            }

        }
        #endregion

        #region Custom Method
        private void Arrive()
        {
            Destroy(this.gameObject);
            Debug.Log("�����ߴ�");
        }
        #endregion
    }

}