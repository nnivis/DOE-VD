using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "BlockCongif", menuName = "LevelBuild/BlockConfig", order = 1)]
    public class BlockConfig : ScriptableObject
    {
        [SerializeField] private Sprite _eventIcon;
        [SerializeField] private Sprite _blockIcon;
        [SerializeField] private BlockType _blockType;

        public Sprite EventIcon => _eventIcon;
        public Sprite BlockIcon => _blockIcon;
        public BlockType BlockType => _blockType;
    }
}
