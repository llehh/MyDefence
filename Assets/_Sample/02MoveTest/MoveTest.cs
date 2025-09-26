using UnityEngine;


public class MoveTest : MonoBehaviour
{
    //�̵� ��ǥ ���� ���� ���� �� �ʱ�ȭ
    private Vector3 targetPosition = new Vector3(7f, 1f, 8f);
    //�̵� ��ǥ ��ġ�� �ִ� ������Ʈ�� Ʈ������ �ν��Ͻ�
    public Transform target;

    //�̵� �ӵ��� �����ϴ� ������ �����ϰ� �ʱ�ȭ
    public float speed = 5f;   //1�ʿ� ���� �Ÿ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.gameObject.transform
        //this.transform.gameObject
        //this.transform.position = new Vector3(7f, 1f, 8f);
        //Debug.Log(this.transform.position);

        //this.transform.position = targetPosition;

        //Debug.Log(target.position);
        //this.transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾��� ��ġ�� ������ �̵� : z�� ���� �����Ѵ�
        //this.transform.position �������� ���� - Vector3 �� �̿�
        //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        //this.transform.position += Vector3.forward;

        //��, ��, ��, ��, ��, �Ʒ�, �̵�
        //Vector3(0f, 0f, 1f); Vector3.forward
        //Vector3(0f, 0f, -1f); Vector.back
        //Vector3(-1f, 0f, 0f); Vector3.left
        //Vector3(1f, 0f, 0f); Vector3.rigth
        //Vector3(0f, 1f, 0f); Vector3.under
        //Vector3(0f, -1f, 0f); Vector3.down

        //Vector3(1f, 1f, 1f); Vector3.one -��������
        //Vector3(0f, 0f, 0f); Vector3.zero

        //�� �������� 1�ʿ� 1unit ��ŭ�� �̵��϶�
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
        //this.transform.position += new Vector3.forward * Time.deltaTime;

        //�� �������� 1�ʿ� 5 ��ŭ�� �̵��϶�
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed; 

        //Translate
        //dir(����) �̵��� ���� ����
        //Time.deltaTime : ������ �ð��� ������ �Ÿ��� �̵��ϰ� ���ش�
        //speed : �̵��� ������ ����
        //dir * Time.deltaTime * speed = ������ ����� Vector3
        //transform.Translate(Vector3.forward * Time.deltaTime *  speed);

        //�̵� ���� ���ϱ� : (��ǥ���� - ��������) (������ġ - ������ġ)
        //dir.normalized : ��������, ���̰� 1�� ����, ����ȭ�� ����
        //dir.magnitude : ������ ����, ũ��
        Vector3 dir = target.position - this.transform.position;
        //this.transform.Translate(dir.normalized * Time.deltaTime * speed);
        //this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        //Space.Self, Space.World
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

    }
}

/*
n������ : 1�ʴ� n�� ����
20������

this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);

Time.deltaTime : �� ������ ���ƿ��µ� �ɸ��� �ð�

���� ���� ��
10������ - 1�ʿ� 10 unit �̵� (Time.deltaTime�� ������� �ʾ�����)
Time.deltaTime : 0.1��

10������ - 1�ʿ� 1 unit �̵� (Time.deltaTime�� ���)

this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime;  //0.1�� ����

���� ���� ��
2������ - 1�ʿ� 2 unit �̵� (Time.deltaTime�� ������� �ʾ�����)
Time.deltaTime : 0.5��

2������ - 1�ʿ� 1 unit �̵� (Time.deltaTime�� ���)

this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime; //0.5�� ����
this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f); * Time.deltaTime; //0.5�� ����
 
*/
