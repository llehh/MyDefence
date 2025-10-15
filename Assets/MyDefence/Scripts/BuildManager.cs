using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Ÿ���� �Ǽ��� �����ϴ� �̱��� Ŭ����
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get 
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }

        #endregion

        #region Variables
        //Ÿ�Ͽ� ��ġ�� Ÿ�� blueprint(������, ����, ��ġ����...)�� �����ϴ� ����
        //�������� Ÿ�� blueprint�� ���õ� Ÿ�� blueprint�� �����ϴ� ����
        private TowerBluePrint towerToBuild;
        #endregion

        #region Property
        //�Ǽ� �Ұ��� ���� üũ: ���õ��� �ʾ�����
        public bool CannotBuild
        {
            get { return towerToBuild == null; }
        }

        //�Ǽ� ��� ���� üũ
        public bool HasBuildCost
        {
            get 
            {
                //���õ��� �ʾ�����
                if (towerToBuild == null)
                    return false;

                return PlayerStats.HasMoney(towerToBuild.cost);
            }
        }
        #endregion

        #region Unity Event Method
        #endregion

        #region CustomMethod
        public TowerBluePrint GetTurretToBuild()
        { 
            return towerToBuild;
        }

        public void SetTurretToBuild(TowerBluePrint tower)
        {
            towerToBuild = tower;
        }

        #endregion


    }

}
