using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Ÿ���� �����ϴ� Ŭ����
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Vairables
        //���� Ÿ���� �� Enemy - ���� ����� ��
        private GameObject target;

        //ȸ��
        public Transform partToRotate;   //ȸ���� �����ϴ� ������Ʈ
        public float ratateSpeed = 10f;  //ȸ�� �ӵ�

        //���� ����
        public float attackRange = 7f;
        
        //ã�� Ÿ�̸�
        public float searchTimer = 0.2f;
        private float countdown = 0f;

        //�߻� Ÿ�̸�
        public float fireTimer = 1f;
        private float fireCountdown = 0f;

        //�Ѿ� ������ ������Ʈ
        public GameObject bulletPrefab;
        public Transform firePoint;
        #endregion


        #region Unity Event Method

        private void Start()
        {
            //�ʱ�ȭ
            countdown = searchTimer;
        }

        private void Update()
        {
            //0.2�ʸ��� ���� ����� �� ã��
            if (countdown <= 0f)
            {
                //Ÿ�̸� ���  ���� ����� �� ã��
                UpdateTarget();

                //Ÿ�̸� �ʱ�ȭ
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            //Ÿ���� ���� �� ã������
            if (target == null)
                return;
            
                //Ÿ���� ���ؼ� partToRotate ȸ��
                LockOn();
                
                //1�ʸ��� �Ѿ��� �߻�
                fireCountdown += Time.deltaTime;
                if(fireCountdown >= fireTimer)
                {
                //Ÿ�̸� ���
                Shoot();

                //Ÿ�̸� �ʱ�ȭ
                fireCountdown = 0f;

                }
            
        }
        private void OnDrawGizmosSelected()
        {
            //Ÿ���߽ɿ� attackRange ���� Ȯ��
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
        #endregion

        #region Custom Method
        //Ÿ������ ���� ����� �� ã��
        void UpdateTarget()
        {
            //�� ���� �ִ� ��� enemy ���ӿ�����Ʈ ��������
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //�ּҰŸ� ���� �ʱ�ȭ
            float minDistance = float.MaxValue;
            //�ּҰŸ��� �ִ� ���ӿ�����Ʈ ����
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy���� �Ÿ� ���ϱ�
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                { 
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //���� ����� ���� ã�Ҵ�, �̶� �ּҰŸ��� ���� �������� �۾�� �Ѵ�
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }
        }

        //Ÿ���� ���� �ͷ� ��� ������
        void LockOn()
        {
            //������ ���ϱ�
            Vector3 dir = target.transform.position - this.transform.position;
            //���⿡ ȸ������ ���ϱ�
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * ratateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;
            //Y�����θ� ȸ���ϱ�
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
        }

        //�߻�
        void Shoot()
        {
            //Debug.Log("�߻�!!!");
            //�ѱ�(Fire Point) ��ġ�� źȯ ��ü ����(Instiate �ϱ�)
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Bullet bullet = bullotGo.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target.transform);
            }

            //�����ð� ������ �ڵ����� ų
            //Destroy(bullotGo, 3f);
            
        }
        #endregion
    }
}
