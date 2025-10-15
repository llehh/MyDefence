using UnityEngine;
using UnityEngine.Rendering;

namespace Sample
{
    //�簢�� ����ü
    struct cBox
    { 
        public float x;     //x��ǥ
        public float y;     //y��ǥ
        public float w;     //width
        public float h;     //height
    }

    //�� ����ü
    struct cCircle
    { 
        public float x;   //x��ǥ
        public float y;   //y��ǥ  
        public float r;   //������
    }

    public class HitTest : MonoBehaviour
    {
        #region Variables
        public float moveSpeed = 10f;
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //�Ű������� ���� �ΰ��� box�� �浹�ߴ��� üũ
        //�浹������ true, �浹���� �ʾ����� false ��ȯ
        private bool CheckHitBox(cBox a, cBox b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);

            if ((a.w / 2 + b.w / 2) >= xDistance && (a.h / 2 + b.h / 2) >= yDistance)
            {
                return true;
            }
            
                return false;
        }

        //�Ű������� ���� �ΰ��� circle�� �浹�ߴ��� üũ
        //�浹������ true, �浹���� �ʾ����� false ��ȯ
        private bool CheckHitCircle(cCircle a, cCircle b)
        {
            float xDistance = a.x - b.x;
            float yDistance = a.y - b.y;

            float distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

            //�ο� ������ �Ÿ��� �ο��� �������� �պ��� ������ �浹�̶�� ����
            if (distance <= (a.r + b.r))
            {
                return true;
            }

            return false;
        }

        //���� �������� �浹üũ
        //�� ������Ʈ�� �Ÿ��� �����Ÿ�(0.5f)�ȿ� ������ �浹�̶� ����
        private bool CheckArrivePosition(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);

            if (distance < 0.5f)
            {
                return true;
            }

            return false;
        }

        //�̵��� Ÿ�ٱ����� ���� �Ÿ��� �� ������ ���� �̵��ϴ� �Ÿ����� ������ �浹�̶�� ����
        private bool CheckPassPosition(Transform target)
        {
            //���� �Ÿ�
            float distance = Vector3.Distance(this.transform.position, target.position);
            //�� �����Ӹ��� �̵��ϴ� �Ÿ�
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (distance <= distanceThisFrame)
            {
                return true;
            }

            return false;
        }
        #endregion
    }

}
