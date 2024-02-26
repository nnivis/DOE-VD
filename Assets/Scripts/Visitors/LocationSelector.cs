
namespace VD
{
    public class LocationSelector : ILocationSelectedVisitor
    {
        private IPersistentData _persistentData;

        public LocationSelector(IPersistentData persistentData)
        {
            _persistentData = persistentData;
        }
        public void Visit(LocationType locationType) => _persistentData.PlayerData.SelectedLocation = locationType;
    }
}
