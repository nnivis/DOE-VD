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
        private OpenLevelChecker _openLevelChecker;
        private LevelPasser _levelPasser;
        private SelectedLocationChecker _selectedLocationChecker;
        private LocationSelector _locationSelector;
        private LocationType _currentLocationType;
        private int _numberofLevels;

        public void Initialize(IDataProvider dataProvider, OpenLevelChecker openLevelChecker, LevelPasser levelPasser, SelectedLocationChecker selectedLocationChecker, LocationSelector locationSelector)
        {
            _dataProvider = dataProvider;
            _openLevelChecker = openLevelChecker;
            _levelPasser = levelPasser;
            _selectedLocationChecker = selectedLocationChecker;
            _locationSelector = locationSelector;

            _locationPanel.Initialize(_openLevelChecker, _selectedLocationChecker);

            SetSelectedLocation();
        }
        public void StartWork()
        {
            _locationPanel.Show(_locationContent.Location);
        }

        private void SetSelectedLocation()
        {
            foreach (Location location in _locationContent.Location)
            {
                _selectedLocationChecker.Visit(location.LocationType);
                if (_selectedLocationChecker.IsSelected)
                {
                    _currentLocationType = location.LocationType;
                    Debug.Log(_currentLocationType);
                }
            }
        }
    }
}
