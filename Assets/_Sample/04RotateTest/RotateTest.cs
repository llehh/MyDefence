using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        #region Variable
        //�� ȸ�� ���� ���� �����ϴ� ����
        float x = 0f;

        //ȸ�� �ӵ�
        public float rotateSpeed = 10f;

        //�̵� �ӵ�
        public float moveSpeed = 5f;

        //Ÿ��
        public Transform target;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //ȸ���� ����
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        private void Update()
        {
            //x��, y��, z������ ȸ�� ����
            //x += 1;
            //this.transform.rotation = Quaternion.Euler(x, 0, 0);   //x��
            //this.transform.rotation = Quaternion.Euler(0, x, 0);   //y��
            //this.transform.rotation = Quaternion.Euler(0, 0, x);   //z��

            //[1] Rotate (����)
            //this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            //[1-2] RotateAround (Ÿ�� �������� ����)
            //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 20f);

            /* //Ÿ���� ���� ȸ��
             //Ÿ���� ���� ������ ���Ѵ� : Ÿ����ġ - ������ġ
             Vector3 dir = target.position - this.transform.position;

             //Ÿ�� ���⿡ ���� ȸ���� ���ϱ�
             Quaternion lookRotation = Quaternion.LookRotation(dir);
             Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

             //ȸ����(x,y,z,w)���� euler ��(x,y,z) ������
             Vector3 eulerValue = lerpRotation.eulerAngles;
             //euler ��(x,y,z)���� ȸ����(x,y,z,w) ������ - y�� ���� ȸ���� ����
             this.transform.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);*/

            //Ÿ���� ���� ȸ���� �̵�
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);

            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

        }
        #endregion
    }
}
