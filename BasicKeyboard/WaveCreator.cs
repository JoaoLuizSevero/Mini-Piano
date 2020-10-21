using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Midi;
using NAudio.Wave.SampleProviders;

namespace NaudioTests2
{
    class WaveCreator
    {
        public static SignalGenerator Sin(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.Sin,
            };
            return wave;
        }
        public static SignalGenerator Triangle(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.Triangle,
            };
            return wave;
        }
        public static SignalGenerator Square(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.Square,
            };
            return wave;
        }
        public static SignalGenerator SawTooth(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.SawTooth,
            };
            return wave;
        }
        public static SignalGenerator Pink(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.Pink,
            };
            return wave;
        }
        public static SignalGenerator White(double g, double f)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                Type = SignalGeneratorType.White,
            };
            return wave;
        }
        public static SignalGenerator Sweep(double g, double f, double fe, double s)
        {
            SignalGenerator wave = new SignalGenerator()
            {
                Gain = g,
                Frequency = f,
                FrequencyEnd = fe,
                SweepLengthSecs = s,
                Type = SignalGeneratorType.Sweep,
            };
            return wave;
        }
    }
}
