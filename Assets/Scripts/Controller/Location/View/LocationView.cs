using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] private List<LevelView> _levelViewsList;
        public List<LevelView> LevelViews => _levelViewsList;
    }
}
