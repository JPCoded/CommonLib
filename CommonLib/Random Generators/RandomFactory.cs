using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CommonLib
{
    /// <summary>
    /// RandomFactory class generates different random numbers, characters, colors, etc..
    /// </summary>
    public class RandomFactory
    {
        private Random _Gen;

        /// <summary>
        /// Initializes Random generator variable
        /// </summary>
        public void New()
        {
            
            _Gen = new Random();
        }

        /// <summary>
        /// Generates random integer
        /// </summary>
        /// <returns></returns>
        public int GetRandomInt() => _Gen.Next();

        /// <summary>
        /// Generates random integer less than Max
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int GetRandomInt(int max)
        {
            if (max < 1)
            {
                max = 1;
            }
            
            return _Gen.Next(max * 100) / 100;
        }

        /// <summary>
        /// Generates Integer random between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int GetRandomInt(int min, int max) => _Gen.Next(min * 100, max * 100) / 100;

        /// <summary>
        /// Generates next double random between 0 and 1
        /// </summary>
        /// <returns></returns>
        public double GetRandomDbl() => _Gen.NextDouble();

        /// <summary>
        /// Generates next double random between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double GetRandomDbl(double min, double max) => Convert.ToDouble(
            (_Gen.NextDouble() - 0) * (max - min) / (1 - 0) + max);

        /// <summary>
        /// Generates next single random between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public float GetRandomSngl(double min, double max) => Convert.ToSingle(
            (_Gen.NextDouble() - 0) * (max - min) / (1 - 0) + max);
       
        /// <summary>
        /// Generates next random color by generating 4 random integers Alpha, red, green and blue
        /// </summary>
        /// <returns></returns>
        public Color GetRandomColor()
        {
            var MyAlpha = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyRed = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyGreen = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);
            var MyBlue = Convert.ToInt32(254 * _Gen.Next(0, 1) + 0);

            return Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue);
        }

        /// <summary>
        /// Generates next random character as per ASCII codes, from 32 to 122
        /// </summary>
        /// <returns></returns>
        public char GetRandomChar() => GetRandomChar(32, 122);

        /// <summary>
        /// Generates next random char as per ASCII between min to max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Equally likely to return true or false
        /// </summary>
        /// <returns></returns>
        public bool NextBoolean() => _Gen.Next(2) > 0;

        /// <summary>
        ///  Generates normally distributed numbers using Box-Muller transform by generating 2 random doubles
        /// Gaussian noise is statistical noise having a probability density function (PDF) equal to that of the normal distribution, 
        /// which is also known as the Gaussian distribution.
        /// In other words, the values that the noise can take on are Gaussian-distributed.
        /// </summary>
        /// <param name="Mean">Mean of the distribution, default = 0</param>
        /// <param name="StdDeviation">Standard deviation, default = 1</param>
        /// <returns></returns>
        public double NextGaussian(double Mean = 0, double StdDeviation = 1)
        {
            var X1 = _Gen.NextDouble();
            var X2 = _Gen.NextDouble();
            var StdDistribution = Math.Sqrt(-2.0 * Math.Log(X1)) * Math.Sin(2.0 * Math.PI * X2);
            var GaussianRnd = Mean + StdDeviation * StdDistribution;
            return GaussianRnd;
        }
        /// <summary>
        ///  Generates values from a triangular distribution
        ///   Triangular distribution is a continuous probability distribution with:
        ///       lower limit a
        ///       upper limit b 
        ///       mode c
        ///   where a less than b 
        ///   c is higher than or equal a but lessthan or equal b
        /// </summary>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="mode">Mode (most frequent value)</param>
        /// <returns></returns>
        public double NextTriangular(double min, double max, double mode)
        {
            var u = _Gen.NextDouble();
            if (u < (mode - min) / (max - min))
            {
                return min + Math.Sqrt(u * (max - min) * (mode - min));
            }
            return max - Math.Sqrt((1 - u) * (max - min) * (max - mode));
        }
        /// <summary>
        /// Shuffles a list in O(n) time by using the Fisher-Yates/Knuth algorithm
        /// </summary>
        /// <param name="list"></param>
        public void Shuffle(ref IList<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var j = _Gen.Next(0, i + 1);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
        }
    }
}
