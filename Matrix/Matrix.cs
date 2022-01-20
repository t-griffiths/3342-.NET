using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix2
{
    class Matrix
    {
        //matrix is a 2D array of double
        private double[,] matrix;

        //Cols is a read-only property that returns the number of columns in the matrix
        public int Cols => this.matrix.GetLength(1);
        //Rows is a read-only property that returns the number of rows in the matrix
        public int Rows => this.matrix.GetLength(0);

        //this is an indexer for a matrix. Note that for a matrix you need this[int i, int j] for both dimensions
        public double this[int i, int j]
        {
            get { return this.matrix[i, j]; }
            set { this.matrix[i, j] = value; }
        }

        //Matrix is a constructor that instantiates the matrix of desired size
        public Matrix(int x, int y)
        {
            matrix = new double[x, y];
        }

        //The add, subtract, and multiply methods perform their repsctive op on the A and B matrices,
        //returning a C result matrix. Note that they are called as C = A.add(B);
        public Matrix add(Matrix temp)
        {
            Matrix result = new Matrix(this.Rows, this.Cols);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    //called by C = A.add(B)
                    //this referes to A, temp refers to B
                    result[i, j] = this[i, j] + temp[i, j];
                }
            }
            return result;
        }

        //C = A.subtract(B)
        public Matrix subtract(Matrix temp)
        {
            Matrix result = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    //this referes to A, temp refers to B
                    result[i, j] = this[i, j] - temp[i, j];
                }
            }
            return result;
        }

        //C = A.multiply(B)
        public Matrix multiply(Matrix temp)
        {
            Matrix result = new Matrix(this.Rows, Cols);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    for (int k = 0; k < this.Cols; k++)
                    {
                        result[i, j] += this[i, k] * temp[k, j];
                    }
                }
                //return result
            }
            return result;
        }


        //The colsEqual, rowsEqual, and dimsEqual methods compare the number of columns, rows and
        //dimensions between two matrtices for equality. 
        //Note bool b = A.dimsEqual(B); returns true if the matrices have the same dimensions
        public bool colsEqual(Matrix temp)
        {
            if (temp.Cols == Cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool rowsEqual(Matrix temp)
        {
            if (temp.Rows == Rows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool dimsEquals(Matrix temp)
        {
            if (temp.Cols == Cols && temp.Rows == Rows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Equals is an override method that compares two matrices for equality. They are equal
        //if both are null, or both have the saem numeric values in the same element positions
        // A.Equals(B)
        public override bool Equals(object temp)
        {
            Matrix m = (Matrix)temp;
            if (!this.rowsEqual(m) || !this.colsEqual(m))
            {
                return false;
            }
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (m[i, j] != this.matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //GetHashCode is an override method that is implemented as:
        //Overrides the GetHashCode method
        public override int GetHashCode()
        {
            return sum().GetHashCode(); //Note that double overrides this too
        }

        //sum calculates the sum of all elements in the matrix
        public double sum()
        {
            double temp = 0.0;
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    temp += this.matrix[i, j];
                }
            }
            return temp;
        }

        //makeId makes an n x n identity matrix
        public static Matrix makeID(int n)
        {
            Matrix temp = new Matrix(n, n);
            for (int i = 0; i < temp.Rows; i++)
            {
                for (int j = 0; j < temp.Cols; j++)
                {
                    if (i != j)
                    {
                        temp[i, j] = 0.0;
                    }
                    else if (i == j)
                    {
                        temp[i, j] = 1.0;
                    }
                }
            }
            return temp;
        }

        //clone returns a copy of the matrix
        public Matrix clone()
        {
            Matrix matrix = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrix[i, j] = this.matrix[i, j];
                }
            }
            return matrix;
        }

        //copy accepts a matrix and copied its elements to this.
        public void copy(Matrix temp)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.matrix[i, j] = temp[i, j];
                }
            }
        }

        //populateRand populates this matrix with random doubles
        public void populateRand()
        {
            Random rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrix[i, j] = rand.NextDouble() * 10.0;
                }
            }
        }

        //populateOrd populates this matrix with sequential doubles from 1.0 in the first element
        //to d in the last, as traversed by a nested loop.
        public void populateOrd()
        {
            double num = 1.0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrix[i, j] = num;
                    num += 1.0;
                }

            }
        }

        //ToString
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    //f1 formats string to one decimal place
                    s += matrix[i, j].ToString("F1") + " ";
                }
                s += Environment.NewLine;
            }
            return s;
        }

        //overload == operator
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (object.Equals(a, null))
            {
                if (object.Equals(b, null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return a.Equals(b);
        }

        //overload != operator
        public static bool operator !=(Matrix a, Matrix b)
        {
            return (a != b);
        }

        //overload multiply operator
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return a.multiply(b);
        }

        //overload add operator
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return a.add(b);
        }

        //overload subtract operrator
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return a.subtract(b);
        }
    }
}

