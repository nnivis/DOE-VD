using UnityEngine;

namespace VD
{
    public class LocationHandler : MonoBehaviour
    {
        [SerializeField] private LocationContent _locationContent;
        [SerializeField] private LocationPanel _locationPanel;
        [SerializeField] private GameFightHandler _gameFightHandler;
        [SerializeField] private GameHandler gameHandler;
        private LocationMediator _locationMediator;
        private IDataProvider _dataProvider;
        private PassedLevelChecker _passedLevelChecker;
        private LevelPasser _levelPasser;
        private SelectedLocationChecker _selectedLocationChecker;
        private LocationSelector _locationSelector;
        private LocationType _currentLocationType;
        private int _numberofLevels;

        public void Initialize(IDataProvider dataProvider, PassedLevelChecker passedLevelChecker, LevelPasser levelPasser, SelectedLocationChecker selectedLocationChecker, LocationSelector locationSelector)
        {
            _dataProvider = dataProvider;
            _passedLevelChecker = passedLevelChecker;
            _levelPasser = levelPasser;
            _selectedLocationChecker = selectedLocationChecker;
            _locationSelector = locationSelector;

            _locationPanel.Initialize(_passedLevelChecker, _selectedLocationChecker);
        }
        public void StartWork()
        {
            _locationPanel.Show(_locationContent.Location);
        }
    }
}
