using UnityEngine;

namespace VD
{
    public class BootstrapGame : MonoBehaviour
    {

        [SerializeField] LocationHandler _locationHandler;
        private IDataProvider _dataProvider;
        private IPersistentData _persistentPlayertData;

        private void Awake()
        {
            InitializeData();
            InitializeLevel();
        }
        private void InitializeData()
        {
            _persistentPlayertData = new PersistentData();
            _dataProvider = new DataLocalProvider(_persistentPlayertData);

            LoadDataOrInit();
        }

        private void InitializeLevel()
        {
            OpenLevelChecker openLevelChecker = new OpenLevelChecker(_persistentPlayertData);
            LevelPasser levelPasser = new LevelPasser(_persistentPlayertData);
            SelectedLocationChecker selectedLocationChecker = new SelectedLocationChecker(_persistentPlayertData);
            LocationSelector locationSelector = new LocationSelector(_persistentPlayertData);

            _locationHandler.Initialize(_dataProvider, openLevelChecker, levelPasser, selectedLocationChecker, locationSelector);

        }

        private void LoadDataOrInit()
        {
            if (_dataProvider.TryLoad() == false)
                _persistentPlayertData.PlayerData = new PlayerData();
        }

    }
}