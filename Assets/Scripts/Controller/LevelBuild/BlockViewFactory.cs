using UnityEngine;

namespace VD
{
   [CreateAssetMenu(fileName = "LevelBuildFactory", menuName = "LevelBuild/LevelBuildFactory", order = 3)]
   public class BlockViewFactory : ScriptableObject
   {
      [SerializeField] private BlockView _blockView;

      public BlockView Get(BlockConfig block, Transform parent)
      {

         BlockView instance = Instantiate(_blockView, parent);
         instance.Initialize(block);
         return instance;
      }

   }
}
