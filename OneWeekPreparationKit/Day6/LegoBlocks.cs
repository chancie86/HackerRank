using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    class LegoBlocks
    {
        private static readonly int[] _availableBlockWidths = new[]
        {
            1,2,3,4
        };


        public static void Run()
        {
            var testNumber = 1;
            foreach (var test in TestCases())
            {
                var start = DateTime.UtcNow;
                Console.WriteLine($"Test {testNumber++}, n: {test.height}, m: {test.width}");
                var result = legoBlocks(test.height, test.width);
                Console.WriteLine($"Answer: {result}, Completed in: {DateTime.UtcNow - start}");
            }
        }

        public static int legoBlocks(int height, int width)
        {
            var validRows = new List<Row>();
            GetValidRows(new Row(width), validRows);
            return GetValidWalls(validRows, new Wall(height));
        }

        public static int GetValidWalls(IList<Row> validRows, Wall wall)
        {
            if (wall.IsFull)
            {
                return 0;
            }

            var result = 0;

            foreach (var row in validRows)
            {
                var newWall = new Wall(wall);
                newWall.AddRow(row);

                if (newWall.IsSolid(newWall.CurrentHeight - 1))
                {
                    var remainingRows = newWall.MaxHeight - newWall.CurrentHeight;
                    result += (int)Math.Pow(validRows.Count, remainingRows);
                }
                else
                {
                    result += GetValidWalls(validRows, newWall);
                }
            }

            return result;
        }

        public static void GetValidRows(Row row, IList<Row> result)
        {
            if (row.IsFull)
            {
                result.Add(row);
                return;
            }

            foreach (var block in _availableBlockWidths)
            {
                if (row.CanFitBlock(block))
                {
                    var newRow = new Row(row);
                    newRow.Add(block);
                    GetValidRows(newRow, result);
                }
            }
        }

        private static IList<(int height, int width)> TestCases()
        {
            return new List<(int, int)>()
            {
                //(2, 2),
                //(3, 2),
                //(2, 3),
                //(4, 4),
                //(4, 5),
                //(4, 6),
                    (4, 7),
                //(5, 4),
                //(6, 4),
                //(7, 4)
            };
        }

        public class Block
        {
            public Block(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public int Left { get; }
            public int Right { get; }
            public int Width => Right - Left;
        }

        public class BlockMeta
        {
            public BlockMeta(Block block)
            {
                Block = block;
            }

            public Block Block { get; }
            public bool LeftEdgeCovered { get; set; }
            public bool RightEdgeCovered { get; set; }

            public bool CoversLeftEdge(Block topBlock)
            {
                if (Block.Left == 0)
                {
                    return true;
                }

                if (topBlock.Left < Block.Left
                    && topBlock.Right > Block.Left)
                {
                    return true;
                }

                return false;
            }

            public bool CoversRightEdge(Block topBlock, Row row)
            {
                if (Block.Right == row.MaxWidth)
                {
                    return true;
                }

                if (topBlock.Left < Block.Right
                    && topBlock.Right > Block.Right)
                {
                    return true;
                }

                return false;
            }
        }

        public class Row
        {
            private readonly List<Block> _blocks;
            private readonly int _maxWidth;
            
            public Row(int maxWidth)
            {
                _blocks = new List<Block>();
                _maxWidth = maxWidth;
            }

            public Row(Row row)
                : this(row._maxWidth)
            {
                _blocks.AddRange(row._blocks);
                CurrentWidth = _blocks.Sum(b => b.Width);
            }

            public int CurrentWidth { get; private set; }

            public int MaxWidth => _maxWidth;

            public bool IsFull => CurrentWidth == _maxWidth;

            public IReadOnlyList<Block> Blocks => new ReadOnlyCollection<Block>(_blocks);

            public void Add(int blockWidth)
            {
                if (!CanFitBlock(blockWidth))
                {
                    throw new InvalidOperationException();
                }

                _blocks.Add(new Block(CurrentWidth, CurrentWidth + blockWidth));
                CurrentWidth += blockWidth;
            }

            public bool CanFitBlock(int blockWidth)
            {
                return CurrentWidth + blockWidth <= _maxWidth;
            }

            public override string ToString()
            {
                return string.Join(',', _blocks.Select(b => b.Width));
            }
        }

        public class Wall
        {
            private readonly List<Row> _rows;
            private readonly int _maxHeight;
            private List<BlockMeta> _firstRowBlockMeta;

            public Wall(int maxHeight)
            {
                _maxHeight = maxHeight;
                _rows = new List<Row>(_maxHeight);
                _firstRowBlockMeta = new List<BlockMeta>(_maxHeight);
            }

            public Wall(Wall wall)
                : this(wall._maxHeight)
            {
                _rows.AddRange(wall._rows);
                _firstRowBlockMeta.AddRange(wall._firstRowBlockMeta.Select(bm => new BlockMeta(bm.Block)
                {
                    LeftEdgeCovered = bm.LeftEdgeCovered,
                    RightEdgeCovered = bm.RightEdgeCovered
                }));
            }

            public int CurrentHeight => _rows.Count;

            public bool IsFull => _rows.Count == _maxHeight;

            public int MaxHeight => _maxHeight;

            public void AddRow(Row row)
            {
                if (CurrentHeight + 1 > _maxHeight)
                {
                    throw new InvalidOperationException();
                }

                _rows.Add(row);

                if (CurrentHeight == 1)
                {
                    _firstRowBlockMeta.AddRange(row.Blocks.Select(b => new BlockMeta(b)));
                }
            }

            public bool IsSolid(int startRowIndex)
            {
                if (_rows.First().Blocks.Count == 1)
                {
                    return true;
                }

                var uncoveredBlocks = _firstRowBlockMeta;

                for (var rowNumber = startRowIndex; rowNumber < _rows.Count; rowNumber++)
                {
                    var currentRow = _rows[rowNumber];
                    if (currentRow.Blocks.Count == 1)
                    {
                        // Block covers entire width of the wall
                        return true;
                    }

                    foreach (var block in currentRow.Blocks)
                    {
                        var idx = 0;
                        while (idx < uncoveredBlocks.Count)
                        {
                            if (block.Width == 1)
                            {
                                // Blocks of width 1 cannot cover any edges
                                idx++;
                                continue;
                            }

                            var uncoveredBlock = uncoveredBlocks[idx];

                            uncoveredBlock.LeftEdgeCovered |= uncoveredBlock.CoversLeftEdge(block);
                            uncoveredBlock.RightEdgeCovered |= uncoveredBlock.CoversRightEdge(block, currentRow);

                            if (uncoveredBlock.LeftEdgeCovered
                                && uncoveredBlock.RightEdgeCovered)
                            {
                                uncoveredBlocks.Remove(uncoveredBlock);
                                if (uncoveredBlocks.Count == 0)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                idx++;
                            }
                        }
                    }
                }

                return false;
            }

            public override string ToString()
            {
                return string.Join('\n', _rows);
            }
        }
    }
}
