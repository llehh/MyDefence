using UnityEngine;
using TMPro;

namespace Sample
{
    /// <summary>
    /// Old Input �׽�Ʈ 
    /// </summary>
    public class InputTest : MonoBehaviour
    {
        #region Variables
        float centerX;  //ȭ�� �߾� ��ġ x��ǥ 
        float centerY;  //ȭ�� �߾� ��ġ y��ǥ 

        //���콺 ��ġ ��
        public TextMeshProUGUI positionText;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //��ũ���� ũ��
            Debug.Log($"Screen Width: {Screen.width}");
            Debug.Log($"Screen Height: {Screen.height}");
            centerX = Screen.width / 2;
            centerY = Screen.height / 2;
            Debug.Log($"Sereen Center: {centerX}, {centerY}");
        }

        // Update is called once per frame
        void Update()
        {
            /*//GetKey
            if(Input.GetKey("w"))
            {
                Debug.Log("wŰ�� ������ �ֽ��ϴ�");  
            }
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("wŰ�� �������ϴ�");
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("wŰ�� �����ٰ� �������ϴ�");
            }

            //GetButton - InputManager ���ǵ� Axes(��ư) �̸��� �����ͼ� ����Ѵ�
            if(Input.GetButton("Jump"))
            {
                Debug.Log("���� ��ư(�����̽���)�� ������ �ֽ��ϴ�");
            }
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("���� ��ư(�����̽���)�� �������ϴ�");
            }
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("���� ��ư(�����̽���)�� �����ٰ� ������ϴ�");
            }*/

            //GetAxis - InputManager ���ǵ� Axis(��ư) �̸��� �����ͼ� ����Ѵ�
            //if (Input.GetButton("Horizontal"))
            {
                //a, left : -1 ~ 0
                //d, right : 0 ~ 1
                //�Է��� ������ : 0
                //float hValue = Input.GetAxis("Horizontal");
                //Debug.Log($"Horizontal GetAxis: {hValue}");

                //a, left : -1 
                //d, right : 1
                //�Է��� ������ : 0 
                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal GetAxisRaw: {hValue}");
            }

            /*if(Input.GetButton("Vertical"))
            {
                //s, down : -1 ~ 0
                //w, up : 0 ~ 1
                //�Է��� ������ : 0
                float vValue = Input.GetAxis("Vertical");
                Debug.Log($"Vertical GetAxis: {vValue}");
            }*/

            //s, down : -1 
            //w, up : 1
            //�Է��� ������ : 0
            float vValue = Input.GetAxisRaw("Vertical");
            Debug.Log($"Horizontal GetAxisRaw: {vValue}");

            //��ũ���󿡼� ���콺 ��ġ�� ��������
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //Debug.Log($"Mouse Position: {mouseX}, {mouseY}");
            positionText.text = $"{(int)mouseX}, {(int)mouseY}";
            positionText.rectTransform.position = new Vector2(mouseX, mouseY);

        }


        #endregion
    }

}
