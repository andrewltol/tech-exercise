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
        private int _spiralNumber;
        private string[,] _spiralText;

        public SpiralCountdown(int number)
        {
            _spiralNumber = number;
            CalculateSpiralDimensions(number);
        }

        public void PrintSpiral()
        {
            CreateSpiralText();

            
        }

        private void CalculateSpiralDimensions(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Cannot spiral a negative number");
                throw new InvalidOperationException();
            }

            int rows = 1, columns = 1;
            Direction currentDirection = FIRST_DIRECTION;

            // Calculate the width and height of spiral
            int i = 0;
            while (i < number)
            {
                switch (currentDirection)
                {
                    case Direction.Up:
                    case Direction.Down:
                        {
                            i += rows;
                            if (i <= number)
                            {
                                rows++;
                            }
                            break;
                        }
                    case Direction.Left:
                    case Direction.Right:
                        {
                            i += columns;
                            if (i <= number)
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

        private void CreateSpiralText()
        {
            _spiralText = new string[Rows, Columns];

            // Determine starting point.  Note: More code would be needed if FIRST_DIRECTION was variable.
            int cursorX = Columns / 2;
            int cursorY = Rows / 2;

            Direction currentDirection = FIRST_DIRECTION;
            int columnLength = 1, rowLength = 1;
            int i = 0;
            while (i < _spiralNumber)
            {
                // Basic setup for writing in direction.
                int startIndex = 0;
                switch (currentDirection)
                {
                    case Direction.Left:
                        {
                            for (startIndex = cursorX; cursorX >= startIndex - rowLength; --cursorX)
                            {
                                _spiralText[cursorX, cursorY] = i++.ToString();
                            }
                            break;
                        }
                    case Direction.Right:
                        {
                            
                            for (startIndex = cursorX; cursorX <= startIndex + rowLength; ++cursorX)
                            {
                                _spiralText[cursorX, cursorY] = i++.ToString();
                            }
                            break;
                        }
                    case Direction.Up:
                        {
                            
                            for (startIndex = cursorY; cursorY >= startIndex - rowLength; --cursorY)
                            {
                                _spiralText[cursorX, cursorY] = i++.ToString();
                            }
                            break;
                        }
                    case Direction.Down:
                        {
                            for (startIndex = cursorY; cursorY <= startIndex + columnLength; ++cursorY)
                            {
                                _spiralText[cursorX, cursorY] = i++.ToString();
                            }
                            break;
                        }
                    default:
                        break;
                }

                currentDirection = ChangeSpiralDirection(currentDirection);
            }
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
