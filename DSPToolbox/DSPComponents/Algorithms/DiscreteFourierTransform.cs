using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }


        public override void Run()
        {


         List<float> phase = new List<float>();
         List<float> amp = new List<float>();
         float phi = 0;

        //Given sequence of Numbers

        List<float> X = InputTimeDomainSignal.Samples;
          //  List<float> Y = InputTimeDomainSignal.FrequenciesAmplitudes;
            float N = InputTimeDomainSignal.Samples.Count;

                
            for (int k = 0; k < N; k++)
            {
                float re = 0;
                float im = 0;
                //The discrete Fourier transform, lists of Re & Im instead of a+ib
                for (int n = 0; n < N; n++)
                {
                     phi = (2*(float)Math.PI * k * n) / N;
                    re += X[n] * (float)Math.Cos(phi) ;
                    im += -X[n] * (float)Math.Sin(phi);
                }
                var ampp = Math.Sqrt(re * re + im * im);
                var phasse = Math.Atan2(im,re);

                phase.Add((float)phasse);
                amp.Add((float)ampp);
            }

            OutputFreqDomainSignal = new Signal(X, false);
            OutputFreqDomainSignal.FrequenciesAmplitudes = amp;
            
            OutputFreqDomainSignal.FrequenciesPhaseShifts = phase;
            using (StreamWriter sw = File.CreateText(@".\amer.txt")) 
            {
                for(int i=0;i<N;i++)
                {
                    sw.WriteLine(OutputFreqDomainSignal.FrequenciesAmplitudes[i] + " " + OutputFreqDomainSignal.FrequenciesPhaseShifts[i]);
                }
            }

            OutputFreqDomainSignal.Frequencies = new List<float>();
            for(int i=0;i<N;i++)
            {
                phi = (2 * (float)Math.PI * InputSamplingFrequency) / N;
                OutputFreqDomainSignal.Frequencies.Add(phi * i);
            }
        }
    }
    
}
