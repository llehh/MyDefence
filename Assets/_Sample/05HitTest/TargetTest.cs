using UnityEngine;

namespace Sample
{
    public class TargetTest : MonoBehaviour
    {
        #region Variables
        public int a = 10;
        private int b= 20;
        #endregion

        #region Unity Event Method
        void Start()
        {
            //�ʵ� �ʱ�ȭ
            b = 30;
        }
        #endregion

        #region Custom Method
        public int GetB()
        { 
            return b;
        }
        #endregion
    }

}
