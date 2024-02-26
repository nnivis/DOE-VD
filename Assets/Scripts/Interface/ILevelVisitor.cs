namespace VD
{
    public interface ILevelVisitor
    {
        void Visit(LocationType locationType, int level);
    }
}
