using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "LocationContent", menuName = "Location/LocationContent")]
    public class LocationContent : ScriptableObject
    {
        [SerializeField] private List<Location> _location;
        public IEnumerable<Location> Location => _location;
        public Location GetLocationByType(LocationType type)
        {
            return _location.FirstOrDefault(location => location.LocationType == type);
        }




        private void OnValidate()
        {
            var charaterSkinsDuplicates = _location.GroupBy(location => location.LocationType)
                .Where(array => array.Count() > 1);

            if (charaterSkinsDuplicates.Count() > 0)
                throw new InvalidOperationException(nameof(_location));
        }
    }
}
