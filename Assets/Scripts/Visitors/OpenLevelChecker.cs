namespace VD
{
    public class OpenLevelChecker : ILevelVisitor
    {
        private IPersistentData _persistentData;
        public bool IsLevelOpen { get; private set; }
        public OpenLevelChecker(IPersistentData persistentData) => _persistentData = persistentData;
        public void Visit(LocationType locationType, int level) => IsLevelOpen = _persistentData.PlayerData.PassedLevels.ContainsKey(locationType) && _persistentData.PlayerData.PassedLevels[locationType].Contains(level);


    }
}
