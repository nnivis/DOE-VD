using System;
using UnityEngine;

namespace VD
{
    public class LocationPanel : MonoBehaviour
    {
        [SerializeField] private Transform _locationParent;
        [SerializeField] private ProgressGameMediator _progressGameMediator;
        private LocationView _locationView;
        private PassedLevelChecker _passedLevelChecker;
        private ILevelActivator _levelActivator;
        public void Initialize(PassedLevelChecker passedLevelChecker)
        {
            _passedLevelChecker = passedLevelChecker;
        }

        public void Show(Location location)
        {

            Clear();

            Location selectedLocation = location;
            _locationView = SpawnLocationView(selectedLocation);
            _levelActivator = GetLevelActivator(selectedLocation.LocationType);
            _levelActivator.ActivateLevels(_locationView.LevelViews, selectedLocation);

            _locationView.LevelViews.ForEach(levelView => levelView.OnActiveLevelClicked += ActiveLevel);
        }

        private void ActiveLevel(int levelIndex)
        {
           _progressGameMediator.ActiveLevel(levelIndex);
        }

        private void Clear()
        {
            if (_locationView != null)
                Destroy(_locationView.gameObject);
        }

        private LocationView SpawnLocationView(Location selectedLocation)
        {
            LocationView locationView = Instantiate(selectedLocation.LocationView, _locationParent);
            locationView.Initialize();
            locationView.transform.localScale = Vector3.one;
            return locationView;
        }

        private ILevelActivator GetLevelActivator(LocationType type)
        {
            switch (type)
            {
                case LocationType.FirstLocation:
                    return new FirstLevelActivator(_passedLevelChecker);
                default:
                    throw new ArgumentException(nameof(type));
            }
        }

    }
}
