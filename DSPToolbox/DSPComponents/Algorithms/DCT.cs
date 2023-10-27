using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            float a,y,result;
            List<float> output = new List<float>();
            float n = InputSignal.Samples.Count;
            for (int i = 0; i < n ; i++)
            {
                
                result = 0;
                if (i == 0)
                {

                    a = (float)Math.Sqrt(1.0 / n);
                }
                else
                {
                    a = (float)Math.Sqrt(2.0 / n);

                }

                for (int k = 0; k < n; k++)
                {
                    result += InputSignal.Samples[k] * (float)Math.Cos(((Math.PI * i * ((2 * k) + 1)) / (2 * n)));
                }
                y = a * result;
                output.Add(y);
            }
            OutputSignal = new Signal(output, false);
        }
    }
}

