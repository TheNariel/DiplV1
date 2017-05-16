using System;
using System.Diagnostics;
using System.Drawing;

namespace DiplV1
{
    class Network
    {
        double[,] networkStates;
        double z;
        double[,] b, a, i, o, newNetworkStates;
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
        public double[,] O
        {
            get
            {
                return o;
            }

            set
            {
                o = value;
            }
        }
        public double[,] I
        {
            get
            {
                return i;
            }

            set
            {
                i = value;
            }
        }

        public double[,] NewNetworkStates
        {
            get
            {
                return  newNetworkStates;
            }

            set
            {
                 newNetworkStates = value;
            }
        }
        public double[,] NetworkStates
        {
            get
            {
                return networkStates;
            }

            set
            {
                networkStates = value;
            }
        }

        public Network(int widht, int height)
        {
            this.widht = widht;
            this.height = height;
            networkStates = new double[height, widht];
            inicializeNetwork();
        }

        private void inicializeNetwork()
        {
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    networkStates[y, x] = 0;
                }
            }
            newNetworkStates = (double[,])networkStates.Clone();
        }

        public double[,] ProcessNetwork()
        {
            for (int x = 1; x < widht - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    newNetworkStates[y, x] = newState(x, y);
                    O[y, x] = coutOutput(newNetworkStates[y, x]);
                    Debug.Write(O[y, x] + "|");
                }
                Debug.WriteLine(" ");
            }
            return O;
        }

        private double newState(int x, int y)
        {
            double ret = 0;
            double feedback = 0, feedforward = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int e = -1; e <= 1; e++)
                {
                    feedforward += B[i + 1, e + 1] * I[y + i, x + e];
                  
                }
               
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int e = -1; e <= 1; e++)
                {
                    feedback += A[e + 1, i + 1] * coutOutput(networkStates[y + e, x + i]);
                }
            }

            //ret = 0 + z + 0 + feedforward;
            ret = -networkStates[y, x] + z + feedback + feedforward;

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
