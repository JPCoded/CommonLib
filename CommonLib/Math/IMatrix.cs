namespace CommonLib
{
    public interface IMatrix
    {
        int Size { get; }
        Matrix1D Product(Matrix1D m2);
        Matrix1D Product(Matrix1D m1, Matrix1D m2);
        Matrix1D Product(Matrix1D m1, int Scalar);
        Matrix1D Product(Matrix1D m1, float Scalar);
        Matrix1D Product(Matrix1D m1, double Scalar);
        Matrix1D Product(int Scalar);
        Matrix1D Product(float Scalar);
        Matrix1D Product(double Scalar);

        Matrix1D Divide(Matrix1D m2);
        Matrix1D Divide(Matrix1D m1, Matrix1D m2);
        Matrix1D Divide(Matrix1D m1, int Scalar);
        Matrix1D Divide(Matrix1D m1, float Scalar);
        Matrix1D Divide(Matrix1D m1, double Scalar);
        Matrix1D Divide(int Scalar);
        Matrix1D Divide(float Scalar);
        Matrix1D Divide(double Scalar);

        Matrix1D Add(Matrix1D m2);
        Matrix1D Add(Matrix1D m1, Matrix1D m2);
        Matrix1D Add(Matrix1D m1, int Scalar);
        Matrix1D Add(Matrix1D m1, float Scalar);
        Matrix1D Add(Matrix1D m1, double Scalar);
        Matrix1D Add(int Scalar);
        Matrix1D Add(float Scalar);
        Matrix1D Add(double Scalar);

        Matrix1D Sub(Matrix1D m2);
        Matrix1D Sub(Matrix1D m1, Matrix1D m2);
        Matrix1D Sub(Matrix1D m1, int Scalar);
        Matrix1D Sub(Matrix1D m1, float Scalar);
        Matrix1D Sub(Matrix1D m1, double Scalar);
        Matrix1D Sub(int Scalar);
        Matrix1D Sub(float Scalar);
        Matrix1D Sub(double Scalar);

        float Sum();

        Matrix1D Copy(Matrix1D m1);
        Matrix1D Copy(Matrix1D m1, int StartingIndex);
        Matrix1D Copy(int StartingIndex);


        void ForceValues(float ForcedValue);
        float GetValue(int Index);

        void SetValue(int Index, float Value);
        string ToString();
    }
}
