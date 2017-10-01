#region

using System;

#endregion

namespace CommonLib
{
    /// <summary>
    ///     A class to describe a two or three dimensional vector
    ///     Normally vector holds poistion and direction information
    /// </summary>
    [Serializable]
    internal class Vector
    {
        [NonSerialized] private readonly RandomFactory _RandGenerator;

        /// <summary>
        ///     The x component of the vector
        /// </summary>
        public float x;

        /// <summary>
        ///     The y component of the vector
        /// </summary>
        public float y;

        /// <summary>
        ///     The z component of the vector
        /// </summary>
        public float z;

        /// <summary>
        ///     Constructor for an empty vector: x, y, and z are set to 0.
        /// </summary>
        public Vector()
        {
            x = 0;
            y = 0;
            z = 0;
            _RandGenerator = new RandomFactory();
        }


        /// <summary>
        ///     Constructor for a 3D vector.
        /// </summary>
        /// <param name="x"> the x coordinate. </param>
        /// <param name="y"> the y coordinate. </param>
        /// <param name="z"> the z coordinate. </param>
        public Vector(float x, float y, float z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        /// <summary>
        ///     Constructor for a 2D vector: z coordinate is set to 0.
        /// </summary>
        public Vector(float x, float y) : this()
        {
            this.x = x;
            this.y = y;
        }


        /// <summary>
        ///     Sets the x, y, and z component of the vector using two or three separate
        ///     variables, the data from a vector, or the values from a float array.
        /// </summary>
        /// <param name="x"> the x component of the vector </param>
        /// <param name="y"> the y component of the vector </param>
        /// <param name="z"> the z component of the vector </param>
        public virtual Vector Set(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            return this;
        }


        /// <summary>
        ///     Sets the x, y, and z component of the vector using two or three separate
        ///     variables, the data from a vector, or the values from a float array.
        /// </summary>
        /// <param name="x"> the x component of the vector </param>
        /// <param name="y"> the y component of the vector </param>
        public virtual Vector Set(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
            return this;
        }


        /// <summary>
        ///     Sets the x, y, and z component of the vector from another vector
        /// </summary>
        /// <param name="v"> vector to copy from </param>
        public virtual Vector Set(Vector v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            return this;
        }


        /// <summary>
        ///     Set the x, y (and maybe z) coordinates using a float[] array as the source.
        /// </summary>
        /// <param name="source"> array to copy from </param>
        public virtual Vector Set(float[] source)
        {
            if (source.Length >= 2)
            {
                x = source[0];
                y = source[1];
            }
            z = source.Length >= 3 ? source[2] : 0;
            return this;
        }

        /// <summary>
        ///     Randmize X, Y and Z components of vector between 0 and 1
        /// </summary>
        public void Randomize()
        {
            x = (float)_RandGenerator.GetRandomDbl();
            y = (float)_RandGenerator.GetRandomDbl();
            z = (float)_RandGenerator.GetRandomDbl();
        }

        /// <summary>
        ///     Make a new 2D unit vector from an angle
        /// </summary>
        /// <param name="target"> the target vector (if null, a new vector will be created) </param>
        /// <returns> the vector </returns>
        public Vector FromAngle(float angle, Vector target)
        {
            var Output = new Vector();

            Output.Set(Convert.ToSingle(Math.Cos(angle)), Convert.ToSingle(Math.Sin(angle)), 0);
            return Output;
        }

        /// <summary>
        ///     Make a new 2D unit vector from an angle.
        /// </summary>
        /// <param name="angle"> the angle in radians </param>
        /// <returns> the new unit vector </returns>
        public Vector FromAngle(float angle) => FromAngle(angle, this);


        /// <summary>
        ///     Gets a copy of the vector, returns a vector object.
        /// </summary>
        public virtual Vector Copy() => new Vector(x, y, z);


        /// <summary>
        ///     Return vector values as array
        /// </summary>
        /// <returns></returns>
        public virtual float[] GetArray()
        {
            var Output = new float[3];

            Output[0] = x;
            Output[1] = y;
            Output[2] = z;

            return Output;
        }


        /// <summary>
        ///     Calculates the magnitude (length) of the vector and returns the result
        /// </summary>
        /// <returns> magnitude (length) of the vector </returns>
        public virtual float Magnitude() => Convert.ToSingle(Math.Sqrt(x * x + y * y + z * z));


        /// <summary>
        ///     Calculates the squared magnitude of the vector and returns the result
        /// </summary>
        /// <returns> squared magnitude of the vector </returns>
        public virtual float MagSq() => x * x + y * y + z * z;


        /// <summary>
        ///     Adds x, y, and z components to a vector, adds one vector to another, or
        ///     adds two independent vectors together
        /// </summary>
        /// <param name="v"> the vector to be added </param>
        public virtual Vector Add(Vector v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
            return this;
        }


        /// <param name="x"> x component of the vector </param>
        /// <param name="y"> y component of the vector </param>
        public virtual Vector Add(float x, float y)
        {
            this.x += x;
            this.y += y;
            return this;
        }


        /// <param name="z"> z component of the vector </param>
        public virtual Vector Add(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
            return this;
        }


        /// <summary>
        ///     Add two vectors into a target vector
        /// </summary>
        public static Vector Add(Vector v1, Vector v2)
        {
            var target = new Vector();

            target.Set(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            return target;
        }


        /// <summary>
        ///     Subtracts x, y, and z components from a vector, subtracts one vector
        ///     from another, or subtracts two independent vectors
        /// </summary>
        /// <param name="v"> any variable of type vector </param>
        public virtual Vector Sub(Vector v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
            return this;
        }


        /// <param name="x"> the x component of the vector </param>
        /// <param name="y"> the y component of the vector </param>
        public virtual Vector Sub(float x, float y)
        {
            this.x -= x;
            this.y -= y;
            return this;
        }


        /// <param name="z"> the z component of the vector </param>
        public virtual Vector Sub(float x, float y, float z)
        {
            this.x -= x;
            this.y -= y;
            this.z -= z;
            return this;
        }


        /// <summary>
        ///     Subtract one vector from another and store in another vector
        /// </summary>
        public static Vector Sub(Vector v1, Vector v2)
        {
            var target = new Vector();

            target.Set(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
            return target;
        }


        /// <summary>
        ///     Multiplies a vector by a scalar or multiplies one vector by another.
        /// </summary>
        /// <param name="n"> the number to multiply with the vector </param>
        public virtual Vector Mult(float n)
        {
            x *= n;
            y *= n;
            z *= n;
            return this;
        }


        /// <summary>
        ///     Multiply a vector by a scalar, and write the result into a target vector.
        /// </summary>
        public static Vector Mult(Vector v, float n)
        {
            var target = new Vector();

            target.Set(v.x * n, v.y * n, v.z * n);
            return target;
        }


        /// <summary>
        ///     Divides a vector by a scalar or divides one vector by another.
        /// </summary>
        /// <param name="n"> the number by which to divide the vector </param>
        public virtual Vector Div(float n)
        {
            x /= n;
            y /= n;
            z /= n;
            return this;
        }

        /// <summary>
        ///     Divide a vector by a scalar and store the result in another vector.
        /// </summary>
        public static Vector Div(Vector v, float n)
        {
            var target = new Vector();

            target.Set(v.x / n, v.y / n, v.z / n);

            return target;
        }


        /// <summary>
        ///     Calculates the Euclidean distance between two vectors
        /// </summary>
        /// <param name="v"> the x, y, and z coordinates of a vector</param>
        public virtual float Distance(Vector v)
        {
            var dx = x - v.x;
            var dy = y - v.y;
            var dz = z - v.z;
            return Convert.ToSingle(Math.Sqrt(dx * dx + dy * dy + dz * dz));
        }


        /// <param name="v1"> any variable of type vector </param>
        /// <param name="v2"> any variable of type vector </param>
        /// <returns> the Euclidean distance between v1 and v2 </returns>
        public static float Distance(Vector v1, Vector v2)
        {
            var dx = v1.x - v2.x;
            var dy = v1.y - v2.y;
            var dz = v1.z - v2.z;
            return Convert.ToSingle(Math.Sqrt(dx * dx + dy * dy + dz * dz));
        }


        /// <summary>
        ///     Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="v"> any variable of type vector </param>
        /// <returns> the dot product </returns>
        public virtual float Dot(Vector v) => x * v.x + y * v.y + z * v.z;


        /// <param name="x"> x component of the vector </param>
        /// <param name="y"> y component of the vector </param>
        /// <param name="z"> z component of the vector </param>
        public virtual float Dot(float x, float y, float z) => this.x * x + this.y * y + this.z * z;


        /// <param name="v1"> any variable of type vector </param>
        /// <param name="v2"> any variable of type vector </param>
        public static float Dot(Vector v1, Vector v2) => v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;


        /// <summary>
        ///     Calculates and returns a vector composed of the cross product between two vectors
        /// </summary>
        /// <param name="v"> 2nd vector vector </param>
        public virtual Vector Cross(Vector v)
        {
            var target = new Vector();
            var crossX = y * v.z - v.y * z;
            var crossY = z * v.x - v.z * x;
            var crossZ = x * v.y - v.x * y;

            target.Set(crossX, crossY, crossZ);
            return target;
        }


        /// <param name="v1"> any variable of type vector </param>
        /// <param name="v2"> any variable of type vector </param>
        public static Vector Cross(Vector v1, Vector v2)
        {
            var target = new Vector();
            var crossX = v1.y * v2.z - v2.y * v1.z;
            var crossY = v1.z * v2.x - v2.z * v1.x;
            var crossZ = v1.x * v2.y - v2.x * v1.y;

            target.Set(crossX, crossY, crossZ);
            return target;
        }


        /// <summary>
        ///     Normalize the vector to length 1 (make it a unit vector).
        /// </summary>
        public virtual Vector Normalize()
        {
            var m = Magnitude();

            if (m != 0 && m != 1)
            {
                Div(m);
            }
            return this;
        }


        /// <param name="target"> Set to null to create a new vector </param>
        /// <returns> a new vector (if target was null), or target </returns>
        public virtual Vector Normalize(Vector target)
        {
            if (target == null)
            {
                target = new Vector();
            }
            var m = Magnitude();
            if (m > 0)
            {
                target.Set(x / m, y / m, z / m);
            }
            else
            {
                target.Set(x, y, z);
            }
            return target;
        }


        /// <summary>
        ///     Limit the magnitude of this vector to the value passed as max parameter
        /// </summary>
        /// <param name="max"> the maximum magnitude for the vector </param>
        public virtual Vector Limit(float max)
        {
            if (MagSq() > max * max)
            {
                Normalize();
                Mult(max);
            }
            return this;
        }


        /// <summary>
        ///     Set the magnitude of this vector to the value passed as len parameter
        /// </summary>
        /// <param name="len"> the new length for this vector </param>
        public virtual Vector SetMag(float len)
        {
            Normalize();
            Mult(len);
            return this;
        }


        /// <summary>
        ///     Sets the magnitude of this vector, storing the result in another vector.
        /// </summary>
        /// <param name="target"> Set to null to create a new vector </param>
        /// <param name="len"> the new length for the new vector </param>
        /// <returns> a new vector (if target was null), or target </returns>
        public virtual Vector SetMag(Vector target, float len)
        {
            target = Normalize(target);
            target.Mult(len);
            return target;
        }


        /// <summary>
        ///     Calculate the angle of rotation for this vector (only 2D vectors)
        /// </summary>
        /// <returns> the angle of rotation </returns>
        public virtual float Heading()
        {
            var angle = Convert.ToSingle(Math.Atan2(y, x));

            return angle;
        }

        /// <summary>
        ///     Rotate the vector by an angle (only 2D vectors), magnitude remains the same
        /// </summary>
        /// <param name="theta"> the angle of rotation </param>
        public virtual Vector Rotate(float theta)
        {
            var temp = x;

            x = x * (float) Math.Cos(theta) - y * (float) Math.Sin(theta);
            y = temp * (float) Math.Sin(theta) + y * (float) Math.Cos(theta);
            return this;
        }


        /// <summary>
        ///     Linear interpolate the vector to another vector
        /// </summary>
        /// <param name="v"> the vector to lerp to </param>
        /// <param name="Amount">
        ///     The amount of interpolation; some value between 0.0 (old vector) and 1.0 (new vector). 0.1 is
        ///     very near the old vector; 0.5 is halfway in between.
        /// </param>
        public virtual Vector Lerp(Vector v, float Amount)
        {
            x = MathFunctions.Lerp(x, v.x, Amount);
            y = MathFunctions.Lerp(y, v.y, Amount);
            z = MathFunctions.Lerp(z, v.z, Amount);
            return this;
        }


        /// <summary>
        ///     Linear interpolate between two vectors (returns a new vector object)
        /// </summary>
        /// <param name="v1"> the vector to start from </param>
        /// <param name="v2"> the vector to lerp to </param>
        public static Vector Lerp(Vector v1, Vector v2, float Amount)
        {
            var v = v1.Copy();
            v.Lerp(v2, Amount);
            return v;
        }


        /// <summary>
        ///     Linear interpolate the vector to x,y,z values
        /// </summary>
        /// <param name="x"> the x component to lerp to </param>
        /// <param name="y"> the y component to lerp to </param>
        /// <param name="z"> the z component to lerp to </param>
        public virtual Vector Lerp(float x, float y, float z, float Amount)
        {
            this.x = MathFunctions.Lerp(this.x, x, Amount);
            this.y = MathFunctions.Lerp(this.y, y, Amount);
            this.z = MathFunctions.Lerp(this.z, z, Amount);
            return this;
        }


        /// <summary>
        ///     Calculates and returns the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="v1"> 1st vector </param>
        /// <param name="v2"> 2nd vector </param>
        public static float AngleBetween(Vector v1, Vector v2)
        {
            double dot = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
            double V1Mag = v1.Magnitude();
            double V2Mag = v2.Magnitude();
            var Amount = dot / (V1Mag * V2Mag);

            if (v1.x == 0 && v1.y == 0 && v1.z == 0)
            {
                return 0f;
            }
            if (v2.x == 0 && v2.y == 0 && v2.z == 0)
            {
                return 0f;
            }
            if (Amount <= -1)
            {
                return (float) Math.PI;
            }
            if (Amount >= 1)
            {
                return 0;
            }
            return Convert.ToSingle(Math.Acos(Amount));
        }

        /// <summary>
        ///     Returns coordinates of vector [x,y,z]
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "[ " + x + ", " + y + ", " + z + " ]";


        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
            {
                return false;
            }
            var p = (Vector) obj;
            return x == p.x && y == p.y && z == p.z;
        }


        public override int GetHashCode()
        {
            var result = 1;
            result = 31 * result;
            result = 31 * result;
            result = 31 * result;
            return result;
        }
    }
}