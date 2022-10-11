using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Calculators
{
    /// <summary>
    /// 行列計算
    /// </summary>
    public static class Matrix
    {
        /// <summary>
        /// 指定配列を転置する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[,] Transpose(double[,] data)
        {
            double[,] result = new double[data.GetLength(1), data.GetLength(0)];

            for (int i = 0; i < data.GetLength(1); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    result[i, j] = data[j, i];
                }
            }

            return result;

        }

        /// <summary>
        /// 行列同士の積
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static double[,] MatrixTimesMatrix(double[,] data1, double[,] data2)
        {

            double[,] result = new double[data1.GetLength(0), data2.GetLength(1)];

            for (int i = 0; i < data1.GetLength(0); i++)
            {
                for (int j = 0; j < data2.GetLength(1); j++)
                {
                    for (int k = 0; k < data1.GetLength(1); k++)
                    {
                        result[i, j] += data1[i, k] * data2[k, j];
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// 逆行列
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static double[,] Inverse(double[,] data)
        {

            int n = data.GetLength(0);
            int m = data.GetLength(1);

            double[,] inv = new double[n, m];

            if (n == m)
            {

                int max;
                double tmp;

                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        inv[j, i] = (i == j) ? 1 : 0;
                    }
                }

                for (int k = 0; k < n; k++)
                {
                    max = k;
                    for (int j = k + 1; j < n; j++)
                    {
                        if (Math.Abs(data[j, k]) > Math.Abs(data[max, k]))
                        {
                            max = j;
                        }
                    }

                    if (max != k)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            // 入力行列側
                            tmp = data[max, i];
                            data[max, i] = data[k, i];
                            data[k, i] = tmp;
                            // 単位行列側
                            tmp = inv[max, i];
                            inv[max, i] = inv[k, i];
                            inv[k, i] = tmp;
                        }
                    }

                    tmp = data[k, k];

                    for (int i = 0; i < n; i++)
                    {
                        data[k, i] /= tmp;
                        inv[k, i] /= tmp;
                    }

                    for (int j = 0; j < n; j++)
                    {
                        if (j != k)
                        {
                            tmp = data[j, k] / data[k, k];
                            for (int i = 0; i < n; i++)
                            {
                                data[j, i] = data[j, i] - data[k, i] * tmp;
                                inv[j, i] = inv[j, i] - inv[k, i] * tmp;
                            }
                        }
                    }

                }


                //逆行列が計算できなかった時の措置
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (double.IsNaN(inv[j, i]))
                        {
                            Console.WriteLine("Error : Unable to compute inverse matrix");
                            inv[j, i] = 0;//ここでは，とりあえずゼロに置き換えることにする
                        }
                    }
                }

                return inv;
            }
            else
            {
                Console.WriteLine("Error : It is not a square matrix");
                return inv;
            }

        }
    }
}
