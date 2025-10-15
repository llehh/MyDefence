using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// ī�޶� ����: �̵�, ����,�ƿ�
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //ī�޶� �̵� �ӵ�
        public float moveSpeed = 10f;
        //ī�޶� ���Ʒ� �̵� �ӵ�
        public float scrollSpeed = 10f;

        public float minPosY = 10f;   //ī�޶� �ּ� ����
        public float maxPosY = 40f;   //ī�޶� �ִ� ����

        //���콺 ��ġ ��� ����
        public float border = 10f;

        //ī�޶� �̵� ���� üũ ����
        // true : �̵� �Ұ���, false : �̵� ����
        private bool isCannotMove = false;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //esc key�� �ѹ� ������ ī�޶� �̵��� ���ϰ� ���´� isCannotMove:false -> isCannotMove = true;
            //esc key�� �ٽ� �ѹ� ������ ī�޶� �̵��� �ϰ� �Ѵ� isCannotMove:true -> isCannotMove = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.Escape)");
                if (isCannotMove == false)
                {
                    isCannotMove = true;
                }
                else if(isCannotMove == true) 
                {
                   isCannotMove = false;
                }
            }

            //ī�޶� �̵� ���� üũ : true�̸� return �Ʒ� �ڵ带 �������� ����
            if (isCannotMove)
                return;

            //wŰ(�Ǵ� �� ����Ű)�� �Է��ϸ� ������ �̵�
            //sŰ(�Ǵ� �� ����Ű)�� �Է��ϸ� �ڷ� �̵�
            //aŰ(�Ǵ� �� ����Ű)�� �Է��ϸ� �������� �̵�
            //dŰ(�Ǵ� �� ����Ű)�� �Է��ϸ� ���������� �̵�
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("������ �̵�"); ���� * Time.deltaTime * �ӵ�
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("�ڷ� �̵�");
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("�·� �̵�");
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("��� �̵�");
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }


            //���콺�� ��ũ�� �����¿� �� �κ�(���� ��: 10)�� �������� ���� ��ũ�� ��Ų��
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            Debug.Log($"���콺 Position: {mouseX}, {mouseY}");

            //������ �̵� - height, height-border
            if (mouseY >= (Screen.height - border) && mouseY <=Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseY >= 0f && mouseY <= border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= 0f && mouseX <= border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= (Screen.width - border) && mouseX <= Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //���콺 ��ũ�Ѱ��� �Է¹޾� ����, �ܾƿ� (���� ����)��� ����
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log($"Mouse ScrollWheel: {scroll}");

            Vector3 upDownPosition = this.transform.position;
            //y�� �̵��� ���� - ���� ��� 1000 ����
            upDownPosition.y -= (scroll * 1000) * Time.deltaTime * scrollSpeed;
            //ī�޶� �ּ�,�ִ� ���� ����
            upDownPosition.y = Mathf.Clamp(upDownPosition.y, minPosY, maxPosY);
            this.transform.position = upDownPosition;
        }
        #endregion
    }
}
