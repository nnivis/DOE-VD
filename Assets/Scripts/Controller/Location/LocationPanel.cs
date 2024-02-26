using System;
using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public class LocationPanel : MonoBehaviour
    {
        [SerializeField] private Transform _locationParent;
        private LocationView _locationView;
        private OpenLevelChecker _openLevelChecker;
        private SelectedLocationChecker _selectedLocationChecker;
        public void Initialize(OpenLevelChecker openLevelChecker, SelectedLocationChecker selectedLocationChecker)
        {
            _openLevelChecker = openLevelChecker;
            _selectedLocationChecker = selectedLocationChecker;
        }

        public void Show(IEnumerable<Location> locations)
        {

            Clear();

            Location selectedLocation = SetSelectedLocation(locations);
            _locationView = SpawnLocationView(selectedLocation);

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

    }
}
