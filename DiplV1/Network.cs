using System;


namespace DiplV1
{
    class Network
    {

        double z;
        double[,] init;
        double[,] b, a, output;
        double[,] input;

        int m, negm;
        private readonly int widht;
        private readonly int height;

        public double Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }
        public double[,] B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }
        public double[,] A
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }
        public double[,] Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }
        public double[,] Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }
        public double[,] Init
        {
            get
            {
                return init;
            }

            set
            {
                init = value;
            }
        }

        public Network(int widht, int height)
        {
            this.widht = widht;
            this.height = height;
            output = new double[height, widht];

        }

        public double CoutOutput(double state)
        {
            double ret = 0;

            ret = (Math.Abs(state + 1.0) - Math.Abs(state - 1.0)) / 2.0;

            return ret;
        }

        public double[,] Start(double t, double dt)
        {
            m = ((A.Length / 3) - 1) / 2;
            negm = 0 - m;

            double[,] ffi = CalculateFFI();
            double[,] cellOutputs;
            double[,] cellDeltas;
            for (double i = 0; i < t; i += dt)
            {
                cellOutputs = CalculateCellOutputs();
                cellDeltas = CalculateCellDeltas(ffi, cellOutputs);
                for (int x = 1; x <= widht - 2; x++)
                {
                    for (int y = 1; y <= height - 2; y++)
                    {
                        init[y, x] += dt * cellDeltas[y, x];
                    }
                }

            }
            return init;
        }

        private double[,] CalculateCellDeltas(double[,] ffi, double[,] cellOutputs)
        {
            double[,] cellDeltas = new double[height, widht];
            for (int x = 1; x <= widht - 2; x++)
            {
                for (int y = 1; y <= height - 2; y++)
                {
                    cellDeltas[y, x] = -init[y, x] + ffi[y, x];
                    for (int i = negm; i <= m; i++)
                    {
                        for (int e = negm; e <= m; e++)
                        {
                            cellDeltas[y, x] += A[e + 1, i + 1] * cellOutputs[y + e, x + i];

                        }
                    }
                }
            }
            return cellDeltas;
        }

        private double[,] CalculateCellOutputs()
        {
            double[,] cellOutputs = new double[height, widht];
            for (int x = 1; x <= widht - 2; x++)
            {
                for (int y = 1; y <= height - 2; y++)
                {
                    cellOutputs[y, x] = CoutOutput(init[y, x]);
                }
            }
            return cellOutputs;
        }

        private double[,] CalculateFFI()
        {
            double[,] ffi = new double[height, widht];
            for (int x = 1; x <= widht - 2; x++)
            {
                for (int y = 1; y <= height - 2; y++)
                {
                    ffi[y, x] = z;
                    for (int i = negm; i <= m; i++)
                    {
                        for (int e = negm; e <= m; e++)
                        {
                            ffi[y, x] += B[e + 1, i + 1] * Input[y + e, x + i];

                        }
                    }
                }
            }
            return ffi;
        }
    }
}
