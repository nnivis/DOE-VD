using UnityEngine;

namespace VD
{
    public class LocationHandler : MonoBehaviour, ILocationProvaider
    {
        public RollDiceConfig rollDiceConfig => _currentLocation.RollDiceConfig;
        public EnemyFactory enemyFactory => _currentLocation.EnemyFactory;
        public DiceFactory diceFactory => _currentLocation.DiceFactory;
        [SerializeField] private LocationContent _locationContent;
        [SerializeField] private LocationPanel _locationPanel;
        [SerializeField] private GameFightHandler _gameFightHandler;
       private TransitionSceneMediator _transitionSceneMediator;
        private IDataProvider _dataProvider;
        private PassedLevelChecker _passedLevelChecker;
        private LevelPasser _levelPasser;
        private SelectedLocationChecker _selectedLocationChecker;
        private LocationSelector _locationSelector;
        private Location _currentLocation;
        private int _currentLevelIndex;

        public void Initialize(IDataProvider dataProvider, PassedLevelChecker passedLevelChecker, LevelPasser levelPasser, SelectedLocationChecker selectedLocationChecker, LocationSelector locationSelector, TransitionSceneMediator transitionSceneMediator)
        {
            _dataProvider = dataProvider;
            _passedLevelChecker = passedLevelChecker;
            _levelPasser = levelPasser;
            _selectedLocationChecker = selectedLocationChecker;
            _locationSelector = locationSelector;
            _transitionSceneMediator = transitionSceneMediator;

            _locationPanel.Initialize(_passedLevelChecker);
        }
        public void StartWork()
        {
            SetSelectedLocation();
            UpdateLocationView();
        }

        public void ActiveLevel(int indexLevel)
        {
            _currentLevelIndex = indexLevel;
            _transitionSceneMediator.ChangeState(SceneType.LevelProgress);
        }

        public void PassLevel()
        {
            _levelPasser.Visit(_currentLocation.LocationType, _currentLevelIndex);
            _dataProvider.Save();

            _currentLevelIndex++;
            UpdateLocationView();

        }
        private void SetSelectedLocation()
        {
            foreach (Location location in _locationContent.Locations)
            {
                _selectedLocationChecker.Visit(location.LocationType);
                if (_selectedLocationChecker.IsSelected)
                {
                    _currentLocation = location;
                }
            }
        }

        private void UpdateLocationView()
        {
            _locationPanel.Show(_currentLocation);
        }
    }
}
