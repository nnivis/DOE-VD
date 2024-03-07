using System.Collections.Generic;

namespace VD
{
    public interface ILevelActivator
    {
        public void ActivateLevels(List<LevelView> levelViewsList, Location location);
    }
}
