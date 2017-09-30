using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace CommonLib
{
    public class RandomFactory
    {
        private Random _Gen;

        public void New()
        {
            
            _Gen = new Random();
        }

        public int GetRandomInt() => _Gen.Next();

        public int GetRandomInt(int max)
        {
            if (max < 1)
            {
                max = 1;
            }
            return _Gen.Next(max * 100) / 100;
        }

        public int GetRandomInt(int min, int max) => _Gen.Next(min * 100, max * 100) / 100;

        public double GetRandomDbl() => _Gen.NextDouble();

        public double GetRandomDbl(double min, double max) => Convert.ToDouble(
            (_Gen.NextDouble() - 0) * (max - min) / (1 - 0) + max);

        public float GetRandomSngl(double min, double max) => Convert.ToSingle(
            (_Gen.NextDouble() - 0) * (max - min) / (1 - 0) + max);

        public Color GetRandomColor()
        {
            var MyAlpha = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyRed = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyGreen = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyBlue = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);

            return Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue);
        }

        public char GetRandomChar() => GetRandomChar(32, 122);

        public char GetRandomChar(int min, int max)
        {
            var allNumbers = new List<int>(Enumerable.Range(min, max - min + 1));
            var selectedNumbers = new List<int>();
            for (var i = 0; i < allNumbers.Count - 1; i++)
            {
                var index = _Gen.Next(0, allNumbers.Count);
                var selectedNumber = allNumbers[index];
                selectedNumbers.Add(selectedNumber);
                allNumbers.RemoveAt(index);
            }
            return Convert.ToChar(selectedNumbers[0]);
        }

        public bool NextBoolean() => _Gen.Next(2) > 0;
    }
}
