using System;


namespace DiplV1
{
    class Network
    {

        double z;
        double[,] init;
        double[,] b, a, output;
        double[,] input;
        readonly string boundary = "";
        readonly int bValue = 0;
        int m, negm, boundMod;
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

        public Network(int widht, int height, string b, int bv)
        {
            bValue = bv;
            boundary = b;
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
            boundMod = 0;

            m = ((A.Length / 3) - 1) / 2;
            negm = 0 - m;

            if (boundary.Equals("Fixed")) boundMod = m;
            double[,] ffi = CalculateFFI();
            double[,] cellOutputs;
            double[,] cellDeltas;
            for (double i = 0; i < t; i += dt)
            {
                cellOutputs = CalculateCellOutputs();
                cellDeltas = CalculateCellDeltas(ffi, cellOutputs);
                for (int x = 0 + boundMod; x <= widht - (1 + boundMod); x++)
                {
                    for (int y = 0 + boundMod; y <= height - (1 + boundMod); y++)
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
            for (int x = 0 + boundMod; x <= widht - (1 + boundMod); x++)
            {
                for (int y = 0 + boundMod; y <= height - (1 + boundMod); y++)
                {
                    cellDeltas[y, x] = -init[y, x] + ffi[y, x];
                    for (int i = negm; i <= m; i++)
                    {
                        for (int e = negm; e <= m; e++)
                        {
                            cellDeltas[y, x] += A[e + 1, i + 1] * SafeOutput(cellOutputs, x, y, i, e);

                        }
                    }
                }
            }
            return cellDeltas;
        }

        private double[,] CalculateCellOutputs()
        {
            double[,] cellOutputs = new double[height, widht];
            for (int x = 0 + boundMod; x <= widht - (1 + boundMod); x++)
            {
                for (int y = 0 + boundMod; y <= height - (1 + boundMod); y++)
                {
                    cellOutputs[y, x] = CoutOutput(init[y, x]);
                }
            }
            return cellOutputs;
        }

        private double[,] CalculateFFI()
        {
            double[,] ffi = new double[height, widht];
            for (int x = 0 + boundMod; x <= widht - (1 + boundMod); x++)
            {
                for (int y = 0 + boundMod; y <= height - (1 + boundMod); y++)
                {
                    ffi[y, x] = z;
                    for (int i = negm; i <= m; i++)
                    {
                        for (int e = negm; e <= m; e++)
                        {

                            ffi[y, x] += B[e + 1, i + 1] * SafeInput(x, y, i, e);

                        }
                    }
                }
            }
            return ffi;
        }

        private double SafeInput(int x, int y, int i, int e)
        {
            int h = y + e;
            int w = x + i;

            if (boundary.Equals("Fixed"))
            {
                return Input[h, w];
            }

            if (boundary.Equals("Flux"))
            {
                if (w < 0) w = 0;
                if (h < 0) h = 0;
                if (w > widht - 1) w = widht - 1;
                if (h > height - 1) h = height - 1;
                return Input[h, w];
            }

            if (boundary.Equals("Arbitrary"))
            {
                if (w < 0 || h < 0 || w > widht - 1 || h > height - 1) return bValue;

            }

            return Input[h, w];
        }

        private  double SafeOutput(double[,] cellOutputs, int x, int y, int i, int e)
        {
            int h = y + e;
            int w = x + i;

            if (boundary.Equals("Fixed"))
            {
                return cellOutputs[h, w];
            }

            if (boundary.Equals("Flux"))
            {
                if (w < 0) w = 0;
                if (h < 0) h = 0;
                if (w > widht - 1) w = widht - 1;
                if (h > height - 1) h = height - 1;
                return cellOutputs[h, w];
            }

            if (boundary.Equals("Arbitrary"))
            {
                if (w < 0 || h < 0 || w > widht - 1 || h > height - 1) return bValue;

            }

            return cellOutputs[h, w];
        }
    }
}
