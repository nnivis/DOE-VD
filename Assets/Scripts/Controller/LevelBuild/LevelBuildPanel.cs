using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public class LevelBuildPanel : MonoBehaviour
    {
        [SerializeField] private Transform _spawnParent;
        [SerializeField] private BlockViewFactory _blockBuildFactory;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private LevelBuildMediator _levelBuildMediator;
        private BlockContent _blockContent;
        private List<BlockView> _blockViews = new List<BlockView>();

        public void Initialization(BlockContent blockContent)
        {
            _blockContent = blockContent;
        }

        public void BuildLevel(int numberOfLevel)
        {
            Clear();

            SpawnBlocksOfType(BlockType.Start);
            StartCoroutine(SpawnOtherBlocks(numberOfLevel));
        }
        private void Clear()
        {
            foreach (BlockView blockView in _blockViews)
            {
                Destroy(blockView);
            }

            _blockViews.Clear();
        }

        private void SpawnBlocksOfType(BlockType blockType)
        {
            foreach (var block in _blockContent.Blocks)
            {
                if (block.BlockType == blockType)
                {
                    SpawnBlock(block);
                }
            }
        }

        private IEnumerator SpawnOtherBlocks(int numberOfLevel)
        {
            yield return new WaitForSeconds(0.5f);
            int spawnCount = 0;

            List<BlockConfig> otherBlocks = new List<BlockConfig>();

            foreach (var block in _blockContent.Blocks)
            {
                if (block.BlockType != BlockType.Start && block.BlockType != BlockType.Finish)
                {
                    otherBlocks.Add(block);
                }
            }

            while (spawnCount < numberOfLevel && otherBlocks.Count > 0)
            {
                int randomIndex = Random.Range(0, otherBlocks.Count);
                BlockConfig randomBlock = otherBlocks[randomIndex];
                SpawnBlock(randomBlock);
                spawnCount++;
                //otherBlocks.RemoveAt(randomIndex);
                yield return new WaitForSeconds(0.5f);
            }

            SpawnBlocksOfType(BlockType.Finish);
        }

        private void SpawnBlock(BlockConfig blockConfig)
        {
            BlockView blockView = _blockBuildFactory.Get(blockConfig, _spawnParent);
            _blockViews.Add(blockView);
        }
    }
}
