using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CommonLib
{
    internal class MathFunctions
    {
        /// <summary>
        /// Re-maps a number from one range to another. In the example above,
        /// </summary>
        /// <param name="value">the incoming value to be converted</param>
        /// <param name="start1">lower bound of the value's current range</param>
        /// <param name="stop1">upper bound of the value's current range </param>
        /// <param name="start2">lower bound of the value's target range</param>
        /// <param name="stop2">upper bound of the value's target range</param>
        /// <returns></returns>
        public static float Map(float value, float start1, float stop1, float start2, float stop2)
        {
            var Output = start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
            var errMessage = "";
            if (Output != Output)
            {
                errMessage = "NaN (not a number)";
                throw new Exception(errMessage);
            }
            if (Output == float.NegativeInfinity || Output == float.PositiveInfinity)
            {
                errMessage = "infinity";
                throw new Exception(errMessage);
            }

            return Output;
        }

        /// <summary>
        /// Normalizes a number from another range into a value between 0 and 1.
        /// Identical to map(value, low, high, 0, 1);
        /// Numbers outside the range are not clamped to 0 and 1, because
        /// out-of-range values are often intentional and useful.
        /// </summary>
        /// <param name="value"> the incoming value to be converted</param>
        /// <param name="start">lower bound of the value's current range</param>
        /// <param name="stop"> upper bound of the value's current range</param>
        /// <returns></returns>
        public float Norm(float value, float start, float stop) => (value - start) / (stop - start);

        /// <summary>
        ///  Calculates a number between two numbers at a specific increment. 
        /// Amount parameter is the amount to interpolate between the two values
        /// </summary>
        /// <param name="start">first value</param>
        /// <param name="stop">second value</param>
        /// <param name="interpAmount">float between 0.0 and 1.0</param>
        /// <returns></returns>
        public static float Lerp(float start, float stop, float interpAmount) => start + (stop - start) * interpAmount;


        /// <summary>
        /// Constrains value between min and max values
        ///   if less than min, return min
        ///   more than max, return max
        ///  otherwise return same value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Constraint(float value, float min, float max)
        {
            if (value <= min)
            {
                return min;
            }
            else if (value >= max)
            {
                return max;
            }
            return value;
        }

        /// <summary>
        /// Generates 8 bit array of an integer, value from 0 to 255
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetBitArray(int value)
        {
            var result = new int[8];

            value = Convert.ToInt32(Constraint(value, 0, 255));
           var sValue = Convert.ToString(value, 2).PadLeft(8, '0');
            var cValue = sValue.ToCharArray();
            for (var i = 0; i <= cValue.Length - 1; i++)
            {
                result[i] = (cValue[i] == '1') ? 1 : 0; 
            }
            return result;
        }

        /// <summary>
        /// Generates 8 bit array of an integer, value from 0 to 255
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int[] GetBits(int value)
        {
            int[] result = {0,0,0,0,0,0,0,0};

            var arr = new BitArray(new[] { value });
            arr.CopyTo(result, 0);
            return result;
        }

        public string GetBitsString(int value)
        {
            var array = GetBitArray(value);

            return array.Aggregate("", (current, i) => current + i.ToString());
        }
    }
}
