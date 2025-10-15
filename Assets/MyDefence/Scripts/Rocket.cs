using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// �̻��� �߻�ü�� �����ϴ� Ŭ����, Bullet�� ��� �޴´�
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables
        //�Ÿ� �ȿ� �ִ� ������ ������ �ִ� ����
        public float damageRange = 3.5f;
        #endregion

        #region Unity Event Method
        //������ ���� ǥ���ϱ�
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
        #endregion

        #region Custom Method
        protected override void HitTarget()
        {
            //Ÿ����ġ�� ����Ʈ�� ����(Instiate)�� �� 3�ʵڿ� Ÿ�� ����Ʈ ������Ʈ kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //damageRange�ȿ� �ִ� ��� ������ ������ �ִ� ����
            Explosion();

            //źȯ ų
            Destroy(this.gameObject);
        }

        //damageRange�ȿ� �ִ� ��� ������ ������ �ִ� ����
        private void Explosion()
        {
            //������ ���� �ȿ� �ִ� ��� �浹ü ��������
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRange);

            //��� �浹ü �߿��� enemy ã��
            foreach (Collider collider in hitColliders)
            {
                //enemy ã�� - tag �˻�
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }
        #endregion
    }
}
