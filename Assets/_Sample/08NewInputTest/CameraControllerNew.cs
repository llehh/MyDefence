using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    /// <summary>
    /// ī�޶� ����: �̵� = ����ǲ�ý���
    /// </summary>
    public class CameraControllerNew : MonoBehaviour
    {
        #region Variables
        //new inputsystem class ��ü ����
        private InputActionsTest inputActions;

        //ī�޶� �̵��ӵ�
        public float moveSpeed = 10f;

        //ī�޶� �̵� �Է°� ����
        Vector2 inputVector;

        //���콺 ��ġ ��� ����
        public float border = 10f;

        #endregion

        #region Unity Event Test
         private void Awake()
         {
             //����
             //new inputsystem class ��ü ����
             inputActions = new InputActionsTest();
         }

         private void OnEnable()
         {
             //new inputsystem class ��ü Ȱ��ȭ
             inputActions.Enable();
             inputActions.Camera.Jump.performed += Jump;
            //inputActions.Camera.Jump.started += Jump;
            //inputActions.Camera.Jump.cancleled += Jump;
        }

        private void OnDisable()
         {
             //new inputsystem class ��ü ��Ȱ��ȭ
             inputActions.Disable();
             inputActions.Camera.Jump.performed += Jump;
        }

         private void Update()
         {
             //wsad(arrow) �Է� ���� ���� ī�޶� �̵� : new inputsystem class ��ü.�׼Ǹ��̸�.�׼��̸�.ReadValue
             Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
             //inputVector.x : a, d �Է°�
             //inputVector.y : w, s �Է°�
             //�̵�: ���� * Time.deltaTime * moveSpeed
             Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y );
             transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

             //MousePosition ���� �о ī�޶� �̵� ����
             //Vector2 mousePosition = inputActions.Camera.MousePosition.ReadValue<Vector2>();
             Vector2 mousePosition = Mouse.current.position.ReadValue();
             float mouseX = mousePosition.x;
             float mouseY = mousePosition.y;
             Debug.Log($"���콺 Position: {mouseX}, {mouseY}");

             //������ �̵� - height, height-border
             if (mouseY >= (Screen.height - border) && mouseY <= Screen.height)
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

         }
         #endregion  

        
                //#region Unity Event Method
                //private void Update()
                //{
                //    //ī�޶� �̵�
                //    //�̵�: ���� * Time.deltaTime * moveSpeed
                //    Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
                //    transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
                //}
                //#endregion
               

                #region Custom Method
                public void OnMove(InputValue value)
                {
                    inputVector = value.Get<Vector2>();
                }

                public void OnJump(InputValue value)
                {
                    if (value.isPressed)
                    {
                        Debug.Log("���� ��ư�� �������ϴ�");
                    }
                }
                #endregion
   

        #region Custom Method

        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            //context.started ������ ����������
            //context.performed �������� (1�� ȣ��)
            //context.canceled �����ٰ� ����

            if (context.performed)
            {
                Debug.Log("���� ��ư�� �������ϴ�");
            }
        }
        
        #endregion

    }
}

/*
1. Input Actions Editor â �����ϱ�
-Action Map ���� (ex: Camera)
-Action ����  (ex: Move, Jump)

2.New Input System ���� ���� ��ǲ�� �������� - 3���� ���
1) ��ũ��Ʈ�� �̿��Ͽ� �� �������� 
-Input Actions ������ Class ���Ϸ� ���� ó���Ѵ�
-������� Class�� ��ü�� �����ؼ� ��ǲ �� ó�� 

2) Send Message ���
- Player Input ������Ʈ �߰� : �׼Ǹ� ���ε� - �巡��
- Behaviour�� SendMessage ����
- ��ǲ ��� �Լ� ����� 
: �Լ� �̸� ��Ģ: On + �׼��̸� (Input value) 

3) Unity Event ��� ���
- Player Input ������Ʈ �߰� : �׼Ǹ� ���ε� - �巡��
-Behaviour�� Unity Event ����
-��ǲ ���� �Լ� �����
-�̸� ��Ģ ����, �Ű����� ��Ģ �ִ�
public void �Լ��̸� (InputAction.CallbackContext context)
-���� �Լ��� �����Ǵ� �̺�Ʈ�� ����Ѵ�
*/
