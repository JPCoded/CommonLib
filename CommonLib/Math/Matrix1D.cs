#region

using System;
using System.Collections.Generic;

#endregion

namespace CommonLib
{
    public class Matrix1D : IMatrix
    {
        private readonly RandomFactory _rnd = new RandomFactory();

        /// <summary>
        ///     Size or capacity of matrix - Simply number of stored elements in Values arrary
        /// </summary>
        private int _size;

        /// <summary>
        ///     Array to hold matrix values - 1D array
        /// </summary>
        private float[] _values;

        /// <summary>
        ///     Constructor - Redim Array to only 1 element
        /// </summary>
        public Matrix1D()
        {
            _values = new float[2];
        }

        /// <summary>
        ///     Constructor that receives values array
        /// </summary>
        /// <param name="initialValues">Initial Elements array</param>
        public Matrix1D(float[] initialValues)
        {
            _values = new float[initialValues.Length];
            Values = initialValues;
            _size = _values.Length;
        }

        /// <summary>
        ///     Constructor that receives values integer array
        ///     All elements are converted to Single type
        /// </summary>
        /// <param name="initialValues">Initial Elements array</param>
        public Matrix1D(IReadOnlyList<int> initialValues)
        {
            _values = new float[initialValues.Count];
            for (var I = 0; I <= _values.Length - 1; I++)
            {
                Values[I] = Convert.ToSingle(initialValues[I]);
            }
            _size = _values.Length;
        }

        /// <summary>
        ///     Constructor, receives size of matrix
        ///     All elements will be randomized for values between 1 and -1
        /// </summary>
        /// <param name="reqCapacity">Matrix size</param>
        public Matrix1D(int reqCapacity)
        {
            _values = new float[reqCapacity];
            RandomizeValues(-1, 1);
            _size = _values.Length;
        }

        /// <summary>
        ///     Array to hold matrix values - 1D array
        /// </summary>
        /// <returns></returns>
        public float[] Values
        {
            get => _values;
            set
            {
                _values = new float[value.Length];
                _values = value;
            }
        }

        /// <summary>
        ///     Size or capacity of matrix - Simply number of stored elements in Values arrary
        /// </summary>
        /// <returns></returns>
        public int Size => _values.Length;

        /// <summary>
        ///     Implement Matrix Product method between 2 metrices m1 and m2
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Product(Matrix1D m1, Matrix1D m2)
        {
            var output = new Matrix1D(Math.Min(m1.Size, m2.Size));

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] * m2.Values[index];
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix Product method between current object and m2
        /// </summary>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Product(Matrix1D m2) => Product(this, m2);

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(Matrix1D m1, int scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] * scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(Matrix1D m1, float scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] * scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(Matrix1D m1, double scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] * (float) scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(int scalar) => Product(this, scalar);

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(float scalar) => Product(this, scalar);

        /// <summary>
        ///     Implement Matrix Product method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Product(double scalar) => Product(this, scalar);

        /// <summary>
        ///     Implement Matrix addition method between 2 metrices m1 and m2
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Add(Matrix1D m1, Matrix1D m2)
        {
            var output = new Matrix1D(Math.Min(m1.Size, m2.Size));

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] + m2.Values[index];
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix addition method between current object and m2
        /// </summary>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Add(Matrix1D m2) => Add(this, m2);

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar addition of matrix elements</returns>
        public Matrix1D Add(Matrix1D m1, int scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] + scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar addition of matrix elements</returns>
        public Matrix1D Add(Matrix1D m1, float scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] + scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar addition of matrix elements</returns>
        public Matrix1D Add(Matrix1D m1, double scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] + (float) scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar addition of matrix elements</returns>
        public Matrix1D Add(int scalar) => Add(this, scalar);

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar addition of matrix elements</returns>
        public Matrix1D Add(float scalar) => Add(this, scalar);

        /// <summary>
        ///     Implement Matrix addition method between matrix m1 and scalar value
        /// </summary>
        /// <param name="scalar">scalar (single) value</param>
        /// <returns>scalar product of matrix elements</returns>
        public Matrix1D Add(double scalar) => Add(this, scalar);

        /// <summary>
        ///     Implement Matrix subtraction method between 2 metrices m1 and m2
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Sub(Matrix1D m1, Matrix1D m2)
        {
            var output = new Matrix1D(Math.Min(m1.Size, m2.Size));

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] - m2.Values[index];
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix subtraction method between object and m2
        /// </summary>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Sub(Matrix1D m2) => Sub(this, m2);


        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(Matrix1D m1, int scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] - scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(Matrix1D m1, float scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] - scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(Matrix1D m1, double scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] - (float) scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(int scalar) => Sub(this, scalar);

        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(float scalar) => Sub(this, scalar);

        /// <summary>
        ///     Implement Matrix subtraction method between matrix and scalar
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>scalar subtract of matrix elements</returns>
        public Matrix1D Sub(double scalar) => Sub(this, scalar);

        /// <summary>
        ///     Sum of all matrix elements
        /// </summary>
        /// <returns>sum of all matrix elements</returns>
        public float Sum()
        {
            float result = 0;

            for (var index = 0; index <= Size - 1; index++)
            {
                result += Values[index];
            }
            return result;
        }

        /// <summary>
        ///     Implement Matrix divide method between 2 metrices m1 and m2
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Divide(Matrix1D m1, Matrix1D m2)
        {
            var output = new Matrix1D(Math.Min(m1.Size, m2.Size));

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] / m2.Values[index];
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix divide method between object and m2
        /// </summary>
        /// <param name="m2">2nd matrix</param>
        /// <returns>New matrix of same size of min size between m1 and m2</returns>
        public Matrix1D Divide(Matrix1D m2) => Divide(this, m2);


        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(Matrix1D m1, int scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] / scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(Matrix1D m1, float scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] / scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="m1">matrix</param>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(Matrix1D m1, double scalar)
        {
            var output = new Matrix1D(m1.Size);

            for (var index = 0; index <= output.Size - 1; index++)
            {
                output.Values[index] = m1.Values[index] / (float) scalar;
            }
            return output;
        }

        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(int scalar) => Divide(this, scalar);

        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(float scalar) => Divide(this, scalar);

        /// <summary>
        ///     Implement Matrix divide method between matrix and scalar value
        /// </summary>
        /// <param name="scalar">scalar value</param>
        /// <returns>new matrix same size as m1</returns>
        public Matrix1D Divide(double scalar) => Divide(this, scalar);

        /// <summary>
        ///     Overrides ToString function of base object
        /// </summary>
        /// <returns>String represents matric contents [v1,v2,v3,....,vn]</returns>
        public override string ToString()
        {
            var result = "Values[";

            for (var I = 0; I <= Size - 1; I++)
            {
                result += Values[I].ToString();
                if (I != Size - 1)
                {
                    result += ",";
                }
            }
            result += "]";
            return result;
        }

        /// <summary>
        ///     Copy contents of m1 into object starting from starting index
        /// </summary>
        /// <param name="m1">matrix to be copied</param>
        /// <param name="startingindex">starting index of copy</param>
        /// <returns>new instance of object</returns>
        public Matrix1D Copy(Matrix1D m1, int startingindex)
        {
            
            for (var I = startingindex; I <= _values.Length - 1; I++)
            {
                if (I - startingindex > m1.Values.Length - 1)
                {
                    break;

                }
                _values[I] = m1.Values[I - startingindex];
            }
            return this;
        }


        /// <summary>
        ///     Copy contents of m1 into object starting from starting index = 0
        /// </summary>
        /// <param name="m1">matrix to be copied</param>
        /// <returns>new instance of object</returns>
        public Matrix1D Copy(Matrix1D m1) => Copy(m1, 0);

        /// <summary>
        ///     Copy contents of object into itself starting from starting index = 0
        /// </summary>
        /// <returns>new instance of object</returns>
        public Matrix1D Copy(int startingindex) => Copy(this, startingindex);

        /// <summary>
        ///     Forces all elements of matrix to ForcedValue
        /// </summary>
        /// <param name="forcedValue"></param>
        public void ForceValues(float forcedValue)
        {
            for (var I = 0; I <= _values.Length - 1; I++)
            {
                _values[I] = forcedValue;
            }
        }

        /// <summary>
        ///     Return index element of matrix
        ///     index starts with 0
        /// </summary>
        /// <param name="index">0 indexed element</param>
        /// <returns>Element value at index of index</returns>
        public float? GetValue(int index)
        {
            if (index > Values.Length)
                return null;
            return _values[index];
        }

        /// <summary>
        ///     Set value of matrix element at position index
        ///     0 indexed positions
        /// </summary>
        /// <param name="index">index (Poistion) starting from 0</param>
        /// <param name="value">New value</param>
        public void SetValue(int index, float value)
        {
            if (index > Values.Length)
            {
                return;
            }

            _values[index] = value;
        }

        /// <summary>
        ///     Randomize matrix elements between min and max values
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void RandomizeValues(double min, double max)
        {
            for (var I = 0; I <= _values.Length - 1; I++)
            {
                _values[I] = (float)_rnd.GetRandomSngl(min, max);
            }
        }
    }
}