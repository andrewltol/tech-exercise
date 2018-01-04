using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownPeak_3
{
    public class SpiralCountdown
    {
        // Denotes direction of the spiral.
        enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        const Direction FIRST_DIRECTION = Direction.Right;
        const int NO_PRINT_INT = -1;

        private int _rows = 0;
        public int Rows
        {
            get
            {
                return _rows;
            }
        }

        private int _columns = 0;
        public int Columns
        {
            get
            {
                return _columns;
            }
        }

        protected int _spiralNumber;
        protected int[,] _spiralValue;

        public SpiralCountdown(int number)
        {
            _spiralNumber = number;
        }

        /// <summary>
        /// Configures and prints the spiral to console.
        /// </summary>
        public void CalculateAndPrintSpiral()
        {
            CalculateSpiralDimensions();
            DetermineNumberLocations();
            PrintSpiral();
        }

        /// <summary>
        /// Determines the dimensions of the spiral array.
        /// </summary>
        /// <param name="number">Number to spiral to.</param>
        protected void CalculateSpiralDimensions()
        {
            if (_spiralNumber < 0)
            {
                Console.WriteLine("Cannot spiral a negative number");
                throw new InvalidOperationException();
            }

            int rows = 1, columns = 1;
            Direction currentDirection = FIRST_DIRECTION;

            // Calculate the width and height of spiral
            int i = 0;
            while (i < _spiralNumber)
            {
                switch (currentDirection)
                {
                    case Direction.Up:
                    case Direction.Down:
                        {
                            i += rows;
                            if (i <= _spiralNumber)
                            {
                                rows++;
                            }
                            break;
                        }
                    case Direction.Left:
                    case Direction.Right:
                        {
                            i += columns;
                            if (i <= _spiralNumber)
                            {
                                columns++;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                // Lock enumeration to valid values.
                currentDirection = ChangeSpiralDirection(currentDirection);
            }

            // Set member variables for setup.
            _rows = rows;
            _columns = columns;
        }

        /// <summary>
        /// Populates an array to know location of each number in spiral.
        /// </summary>
        protected void DetermineNumberLocations()
        {
            _spiralValue = new int[_columns, _rows];

            // Set 'no print' value for all elements of array.
            for (int j = 0; j < _rows; ++j)
            {
                for (int k = 0; k < _columns; ++k)
                {
                    _spiralValue[k, j] = NO_PRINT_INT;
                }
            }

            // Determine starting point.  Note: More code would be needed if FIRST_DIRECTION was variable.
            int cursorX = (Columns - 1) / 2;
            int cursorY = (Rows - 1) / 2;

            // Init first value.
            _spiralValue[cursorX, cursorY] = 0;

            Direction currentDirection = FIRST_DIRECTION;
            int columns = 1, rows = 1;
            int i = 1;      // Start at 1, 0 done in initialization.
            while (i < _spiralNumber)
            {
                // Basic setup for writing in direction.
                int startIndex;
                switch (currentDirection)
                {
                    case Direction.Left:
                        {
                            startIndex = cursorX;
                            while (cursorX > startIndex - columns && i <= _spiralNumber)
                            {
                                --cursorX;
                                _spiralValue[cursorX, cursorY] = i++;
                            }
                            ++columns;
                            break;
                        }
                    case Direction.Right:
                        {
                            startIndex = cursorX;
                            while (cursorX < startIndex + columns && i <= _spiralNumber)
                            {
                                ++cursorX;
                                _spiralValue[cursorX, cursorY] = i++;
                            }
                            ++columns;
                            break;
                        }
                    case Direction.Up:
                        {
                            startIndex = cursorY;
                            while(cursorY > startIndex - rows && i <= _spiralNumber)
                            {
                                --cursorY;
                                _spiralValue[cursorX, cursorY] = i++;
                            }
                            ++rows;
                            break;
                        }
                    case Direction.Down:
                        {
                            startIndex = cursorY;
                            while (cursorY < startIndex + rows && i <= _spiralNumber)
                            {
                                ++cursorY;
                                _spiralValue[cursorX, cursorY] = i++;
                            }
                            ++rows;
                            break;
                        }
                    default:
                        break;
                }

                currentDirection = ChangeSpiralDirection(currentDirection);
            }
        }

        /// <summary>
        /// Prints spiral to console output.
        /// </summary>
        protected void PrintSpiral()
        {
            for (int i = 0; i < _rows; ++i)
            {
                for (int j = 0; j < _columns; ++j)
                {
                    if (_spiralValue[j, i] != NO_PRINT_INT)
                    {
                        OutputNumberAsString(_spiralValue[j, i]);
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Writes number to the console.
        /// </summary>
        /// <param name="number">Number to write.</param>
        virtual protected void OutputNumberAsString(int number)
        {
            Console.Write(number.ToString() + "\t");
        }

        /// <summary>
        /// Updates the direction of the spiral to conform to enum.
        /// </summary>
        /// <param name="currentDirection">Direction before update.</param>
        /// <returns>Direction after update.</returns>
        private Direction ChangeSpiralDirection(Direction direction)
        {
            // Lock enumeration to valid values.
            if (++direction > Direction.Left)
            {
                direction = 0;
            }

            return direction;
        }
    }
}
