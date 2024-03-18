using System;
using UnityEngine;

namespace VD
{
    public class LevelBuildMediator : MonoBehaviour
    {
        [SerializeField] LevelBuildHandler _levelBuildHandler;

        public void UpdateGenereteLevelNumberDone(int numberOfLevel)
        {
           _levelBuildHandler.BuildLevel(numberOfLevel);
        }
    }
}
