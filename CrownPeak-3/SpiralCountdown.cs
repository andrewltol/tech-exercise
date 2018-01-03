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

        public SpiralCountdown(int startNumber)
        {
            CalculateSpiralDimensions(startNumber);
        }

        public void PrintSpiral()
        {

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
                if (++currentDirection > Direction.Left)
                {
                    currentDirection = 0;
                }
            }

            // Set member variables for setup.
            _rows = rows;
            _columns = columns;
        }
    }
}
