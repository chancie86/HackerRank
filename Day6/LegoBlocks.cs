using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HackerRank.Day6
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
                Console.WriteLine($"Test {testNumber++}, n: {test.height}, m: {test.width}");
                var result = legoBlocks(test.height, test.width);
                Console.WriteLine(result);
            }
        }

        public static int legoBlocks(int height, int width)
        {
            var validRows = new List<Row>();
            GetValidRows(new Row(width), validRows);

            //foreach (var row in validRows)
            //{
            //    Console.WriteLine($"Valid row: {row}");
            //}

            var validWalls = new List<Wall>();
            GetValidWalls(validRows, new Wall(height), validWalls);

            //foreach (var wall in validWalls)
            //{
            //    Console.WriteLine($"Valid wall:\n{wall}");
            //}

            return validWalls.Count();
        }

        public static void GetValidWalls(IList<Row> validRows, Wall wall, IList<Wall> result)
        {
            if (wall.IsFull)
            {
                if (wall.IsSolid())
                {
                    result.Add(wall);
                }
                
                return;
            }

            foreach (var row in validRows)
            {
                if (!wall.IsFull)
                {
                    var newWall = new Wall(wall);
                    newWall.AddRow(row);
                    GetValidWalls(validRows, newWall, result);
                }
            }
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
                (3,3)
                //(2, 2),
                //(3, 2),
                //(2, 3),
                //(4, 4),
                //(4, 5),
                //(4, 6),
                    //(4, 7),
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

            public Wall(int maxHeight)
            {
                _rows = new List<Row>();
                _maxHeight = maxHeight;
            }

            public Wall(Wall wall)
                : this(wall._maxHeight)
            {
                _rows.AddRange(wall._rows);
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
            }

            public bool IsSolid()
            {
                var uncoveredBlocks = _rows.First().Blocks.Select(b => new BlockMeta(b)).ToList();

                for (var rowNumber = 1; rowNumber < _rows.Count; rowNumber++)
                {
                    var currentRow = _rows[rowNumber];

                    foreach (var block in currentRow.Blocks)
                    {
                        var idx = 0;
                        while (idx < uncoveredBlocks.Count)
                        {
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
