using System;
using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public class LocationPanel : MonoBehaviour
    {
        [SerializeField] private Transform _locationParent;
        private LocationView _locationView;
        private PassedLevelChecker _passedLevelChecker;
        private SelectedLocationChecker _selectedLocationChecker;
        private ILevelActivator _levelActivator;
        public void Initialize(PassedLevelChecker passedLevelChecker, SelectedLocationChecker selectedLocationChecker)
        {
            _passedLevelChecker = passedLevelChecker;
            _selectedLocationChecker = selectedLocationChecker;
        }

        public void Show(IEnumerable<Location> locations)
        {

            Clear();

            Location selectedLocation = SetSelectedLocation(locations);
            _locationView = SpawnLocationView(selectedLocation);
            _levelActivator = GetLevelActivator(selectedLocation.LocationType);
            _levelActivator.ActivateLevels(_locationView.LevelViews, selectedLocation);

        }

        private void Clear()
        {
            if (_locationView != null)
                Destroy(_locationView.gameObject);
        }

        private Location SetSelectedLocation(IEnumerable<Location> locations)
        {
            foreach (Location location in locations)
            {
                _selectedLocationChecker.Visit(location.LocationType);
                if (_selectedLocationChecker.IsSelected)
                {
                    return location;
                }
            }
            throw new InvalidOperationException("No location was selected.");
        }
        private LocationView SpawnLocationView(Location selectedLocation)
        {
            LocationView locationView = Instantiate(selectedLocation.LocationView, _locationParent);
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
