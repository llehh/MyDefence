using TMPro;
using UnityEngine;
using UnityEngine.VFX;

namespace MyDefence
{
    /// <summary>
    /// źȯ �߻�ü�� �����ϴ� Ŭ����
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //Ÿ�� ������Ʈ
        private Transform target;

        //�̵� �ӵ�
        public float moveSpeed = 70f;

        //Ÿ�� ����Ʈ ������ ������Ʈ
        public GameObject impactPrefab;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Ÿ���� ų �Ǹ�
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            //Ÿ�ٱ��� �̵��ϱ�
            Vector3 dir = target.position - transform.position;
            //�����Ÿ� (dir.magnitude �� �����ϴ�)
            float distance = Vector3.Distance(target.position, transform.position);
            //�̹� �����ӿ� �̵��� �Ÿ�
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //Ÿ�� �������� �ٶ󺸱�
            transform.LookAt(target);
        }
        #endregion

        #region Custom Method
        //�Ű������� ���� Ÿ������ ����
        public void SetTarget(Transform _target)
        { 
            target = _target;
        }

        //Ÿ�� ����
        protected virtual void HitTarget()
        {
            //Ÿ����ġ�� ����Ʈ�� ����(Instiate)�� �� 3�ʵڿ� Ÿ�� ����Ʈ ������Ʈ kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //Ÿ�� ų
            Damage(target);

            //źȯ ų
            Destroy(this.gameObject);
        }

        //Ÿ�ݴ��� ������ ������ �ֱ�
        protected void Damage(Transform enemy)
        {
            //Ÿ�� ų
            Destroy(enemy.gameObject);
        }
        #endregion


    }

}
