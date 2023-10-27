using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DC_Component: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            float x = 0;
            float y = 0;
            float n = InputSignal.Samples.Count;
            List<float> output = new List<float>();
            for (int i = 0; i < n; i++)
            {
                x += InputSignal.Samples[i];
            }
            float avg = x / n;
            for (int i = 0; i < n; i++)
            {
                y =  InputSignal.Samples[i]-avg;
                output.Add(y);
               
            }

            OutputSignal = new Signal(output, false);
        }
    }
}
