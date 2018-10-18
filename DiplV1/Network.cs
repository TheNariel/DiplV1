using System;
using System.Diagnostics;
using System.Drawing;

namespace DiplV1
{
    class Network
    {
        double z;
        double[,] netStatus;
        double[,] b, a, output;
        double[,] input;
        int widht, height;

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
        public double[,] I
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

        public double[,] NetStatus
        {
            get
            {
                return netStatus;
            }

            set
            {
                netStatus = value;
            }
        }


        public Network(int widht, int height)
        {
            this.widht = widht;
            this.height = height;
            netStatus = new double[height, widht];
        }

        public void inicializeNetwork(Boolean inputAsOutput)
        {
            if (inputAsOutput)
            {
                for (int x = 0; x < widht; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        netStatus[y, x] = I[y, x];
                    }
                }
            }
            else
            {
                for (int x = 0; x < widht; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        netStatus[y, x] = 0;
                    }
                }
            }
        }

        public double[,] ProcessNetwork()
        {
            for (int x = 0; x <= widht-1; x++)
            {
                for (int y = 0; y <=height-1; y++)
                {
                    Output[y, x] = coutOutput(newState(x, y));
                    Debug.Write(Output[y, x] + "|");
                }
                Debug.WriteLine(" ");
            }
            return Output;
        }

        private double newState(int x, int y)
        {
            double ret = 0;
            double feedback = 0, feedforward = 0;
            int xx, yy;
            for (int i = -1; i <= 1; i++)
            {
                for (int e = -1; e <= 1; e++)
                {
                    xx = x + e;
                    yy = y + i;
                    if (xx < 0) xx = 0;
                    if (yy < 0) yy = 0;
                    if (xx > widht-1) xx = widht - 1;
                    if (yy > height - 1) yy = height - 1;
                    feedforward += B[i + 1, e + 1] * I[yy, xx];

                }

            }
            for (int i = -1; i <= 1; i++)
            {
                for (int e = -1; e <= 1; e++)
                {
                    xx = x + e;
                    yy = y + i;
                    if (xx < 0) xx = 0;
                    if (yy < 0) yy = 0;
                    if (xx > widht - 1) xx = widht - 1;
                    if (yy > height - 1) yy = height - 1;
                    feedback += A[i + 1, e + 1] * netStatus[yy, xx];
                }
            }

            //ret = 0 + z + 0 + feedforward;
            ret = -netStatus[y, x] + z + feedback + feedforward;

            return ret;
        }

        public double coutOutput(double state)
        {
            double ret = 0;

            ret = (Math.Abs(state + 1.0) - Math.Abs(state - 1.0)) / 2.0;

            return ret;
        }
    }
}
