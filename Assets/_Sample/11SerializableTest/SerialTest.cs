using UnityEngine;

namespace Sample
{
    //����ȭ�� ����ü
    [System.Serializable]
    public struct TestStruct
    {
        public float value1;
        public int value2;
    }

    /// <summary>
    /// ����ȭ ����, unity���� ����ȭ: �ν�����â���� ���������ϰ� �ϴ� ��
    /// </summary>
    public class SerialTest : MonoBehaviour
    {
        public int number = 10;

        [SerializeField]
        private string name = "Tom";


        public TestStruct testStruct;

    }
}