using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Midi;
using NAudio.Wave.SampleProviders;
using System.Security.Policy;

namespace NaudioTests2
{
    public partial class Form1 : Form
    {
        int octave = 0;
        double frequency = 0;
        double gain = 0.5;

        private WaveOutEvent[] waveOut = new WaveOutEvent[36];
        private bool[] isPlaying = new bool[36];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 36; i++)
            {
                waveOut[i] = new WaveOutEvent();
            }
            List<string> waves = new List<string>();
            waves.Add("Sin");
            waves.Add("Triangle");
            waves.Add("Square");
            waves.Add("SawTooth");
            waves.Add("PinkNoise");
            waves.Add("WhiteNoise");
            waves.Add("Sweep");
            cb_waveType.DataSource = waves;

            btn_a1.Text = "";
            btn_ag1.Text = "";
            btn_b1.Text = "";
            btn_c1.Text = "";
            btn_cg1.Text = "";
            btn_d1.Text = "";
            btn_dg1.Text = "";
            btn_e1.Text = "";
            btn_f1.Text = "";
            btn_fg1.Text = "";
            btn_g1.Text = "";
            btn_gg1.Text = "";
            btn_a2.Text = "";
            btn_ag2.Text = "";
            btn_b2.Text = "";
            btn_c2.Text = "";
            btn_cg2.Text = "";
            btn_d2.Text = "";
            btn_dg2.Text = "";
            btn_e2.Text = "";
            btn_f2.Text = "";
            btn_fg2.Text = "";
            btn_g2.Text = "";
            btn_gg2.Text = "";
            btn_a3.Text = "";
            btn_ag3.Text = "";
            btn_b3.Text = "";
            btn_c3.Text = "";
            btn_cg3.Text = "";
            btn_d3.Text = "";
            btn_dg3.Text = "";
            btn_e3.Text = "";
            btn_f3.Text = "";
            btn_fg3.Text = "";
            btn_g3.Text = "";
            btn_gg3.Text = "";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 81:
                    PlayTone(sender, Globals.c/2,0);
                    break;
                case 50:
                    PlayTone(sender, Globals.cg/2, 1);
                    break;
                case 87:
                    PlayTone(sender, Globals.d/2, 2);
                    break;
                case 51:
                    PlayTone(sender, Globals.dg/2, 3);
                    break;
                case 69:
                    PlayTone(sender, Globals.e/2, 4);
                    break;
                case 82:
                    PlayTone(sender, Globals.f/2, 5);
                    break;
                case 53:
                    PlayTone(sender, Globals.fg/2, 6);
                    break;
                case 84:
                    PlayTone(sender, Globals.g/2, 7);
                    break;
                case 54:
                    PlayTone(sender, Globals.gg/2, 8);
                    break;
                case 89:
                    PlayTone(sender, Globals.a/2, 9);
                    break;
                case 55:
                    PlayTone(sender, Globals.ag/2, 10);
                    break;
                case 85:
                    PlayTone(sender, Globals.b/2, 11);
                    break;
                case 226:
                    PlayTone(sender, Globals.c, 12);
                    break;
                case 65:
                    PlayTone(sender, Globals.cg, 13);
                    break;
                case 90:
                    PlayTone(sender, Globals.d, 14);
                    break;
                case 83:
                    PlayTone(sender, Globals.dg, 15);
                    break;
                case 88:
                    PlayTone(sender, Globals.e, 16);
                    break;
                case 67:
                    PlayTone(sender, Globals.f, 17);
                    break;
                case 70:
                    PlayTone(sender, Globals.fg, 18);
                    break;
                case 86:
                    PlayTone(sender, Globals.g, 19);
                    break;
                case 71:
                    PlayTone(sender, Globals.gg, 20);
                    break;
                case 66:
                    PlayTone(sender, Globals.a, 21);
                    break;
                case 72:
                    PlayTone(sender, Globals.ag, 22);
                    break;
                case 78:
                    PlayTone(sender, Globals.b, 23);
                    break;
                case 74:
                    PlayTone(sender, Globals.c * 2, 24);
                    break;
                case 73:
                    PlayTone(sender, Globals.cg * 2, 25);
                    break;
                case 75:
                    PlayTone(sender, Globals.d * 2, 26);
                    break;
                case 79:
                    PlayTone(sender, Globals.dg * 2, 27);
                    break;
                case 76:
                    PlayTone(sender, Globals.e * 2, 28);
                    break;
                case 186:
                    PlayTone(sender, Globals.f * 2, 29);
                    break;
                case 219:
                    PlayTone(sender, Globals.fg * 2, 30);
                    break;
                case 222:
                    PlayTone(sender, Globals.g * 2, 31);
                    break;
                case 221:
                    PlayTone(sender, Globals.gg * 2, 32);
                    break;
                case 220:
                    PlayTone(sender, Globals.a * 2, 33);
                    break;
                default:
                    break;
            }
        }
        private void sb_octave_Scroll(object sender, ScrollEventArgs e)
        {
            octave = sb_octave.Value;
            lb_oct.Text = octave.ToString();
        }
        private void sb_frequency_Scroll(object sender, ScrollEventArgs e)
        {
            if (sb_frequency.Value != 0)
            {
                frequency = Convert.ToSingle(sb_frequency.Value) / 100;
            }
            else
            {
                frequency = 0;
            }
            lb_freq.Text = frequency.ToString();
        }
        private void sb_gain_Scroll(object sender, ScrollEventArgs e)
        {
            gain = Convert.ToDouble(sb_gain.Value) / 10;
            lb_gain.Text = gain.ToString();
        }
        private void cb_keyTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_keyTitle.Checked == true)
            {
                btn_a1.Text = "A1";
                btn_ag1.Text = "A#1";
                btn_b1.Text = "B1";
                btn_c1.Text = "C1";
                btn_cg1.Text = "C#1";
                btn_d1.Text = "D";
                btn_dg1.Text = "D#1";
                btn_e1.Text = "E1";
                btn_f1.Text = "F1";
                btn_fg1.Text = "F#1";
                btn_g1.Text = "G1";
                btn_gg1.Text = "G#1";
                btn_a2.Text = "A2";
                btn_ag2.Text = "A#2";
                btn_b2.Text = "B2";
                btn_c2.Text = "C2";
                btn_cg2.Text = "C#2";
                btn_d2.Text = "D2";
                btn_dg2.Text = "D#2";
                btn_e2.Text = "E2";
                btn_f2.Text = "F2";
                btn_fg2.Text = "F#2";
                btn_g2.Text = "G2";
                btn_gg2.Text = "G#2";
                btn_a3.Text = "A3";
                btn_ag3.Text = "A#3";
                btn_b3.Text = "B3";
                btn_c3.Text = "C3";
                btn_cg3.Text = "C#3";
                btn_d3.Text = "D3";
                btn_dg3.Text = "D#3";
                btn_e3.Text = "E3";
                btn_f3.Text = "F3";
                btn_fg3.Text = "F#3";
                btn_g3.Text = "G3";
                btn_gg3.Text = "G#3";
            }
            else
            {
                btn_a1.Text = "";
                btn_ag1.Text = "";
                btn_b1.Text = "";
                btn_c1.Text = "";
                btn_cg1.Text = "";
                btn_d1.Text = "";
                btn_dg1.Text = "";
                btn_e1.Text = "";
                btn_f1.Text = "";
                btn_fg1.Text = "";
                btn_g1.Text = "";
                btn_gg1.Text = "";
                btn_a2.Text = "";
                btn_ag2.Text = "";
                btn_b2.Text = "";
                btn_c2.Text = "";
                btn_cg2.Text = "";
                btn_d2.Text = "";
                btn_dg2.Text = "";
                btn_e2.Text = "";
                btn_f2.Text = "";
                btn_fg2.Text = "";
                btn_g2.Text = "";
                btn_gg2.Text = "";
                btn_a3.Text = "";
                btn_ag3.Text = "";
                btn_b3.Text = "";
                btn_c3.Text = "";
                btn_cg3.Text = "";
                btn_d3.Text = "";
                btn_dg3.Text = "";
                btn_e3.Text = "";
                btn_f3.Text = "";
                btn_fg3.Text = "";
                btn_g3.Text = "";
                btn_gg3.Text = "";
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < 36; i++) 
            { 
                waveOut[i].Stop();
                waveOut[i].Dispose();
                waveOut[i] = null;
            }
        }
        private void cb_waveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_c1.Focus();
        }

        //---------------------------- PLAY ----------------------------

        private void PlayTone(object sender, double tone, int i)
        {
            if (isPlaying[i] == true) return;

            isPlaying[i] = true;
            tone += frequency;
            switch (octave)
            {
                case -3:
                    tone = tone / 2 / 2 / 2;
                    break;
                case -2:
                    tone = tone / 2 / 2;
                    break;
                case -1:
                    tone = tone / 2;
                    break;
                case 1:
                    tone = tone * 2;
                    break;
                case 2:
                    tone = tone * 2 * 2;
                    break;
                case 3:
                    tone = tone * 2 * 2 * 2;
                    break;
                default:
                    break;
            }
            if (tone < 27.5f) tone = 27.5f;
            if (tone > 4186) tone = 4186;
            SignalGenerator signal = new SignalGenerator();
            switch (cb_waveType.SelectedIndex)
            {
                case 0:
                    signal = WaveCreator.Sin(gain, tone);
                    break;
                case 1:
                    signal = WaveCreator.Triangle(gain, tone);
                    break;
                case 2:
                    signal = WaveCreator.Square(gain, tone);
                    break;
                case 3:
                    signal = WaveCreator.SawTooth(gain, tone);
                    break;
                case 4:
                    signal = WaveCreator.Pink(gain, tone);
                    break;
                case 5:
                    signal = WaveCreator.White(gain, tone);
                    break;
                case 6:
                    signal = WaveCreator.Sweep(gain, tone, 800f, 1);
                    break;
                default:
                    signal = WaveCreator.Sin(gain, tone);
                    break;
            }
            waveOut[i].Init(signal);
            waveOut[i].Play();
            if (sender is Button)
            {
                Button btn = (Button)sender;
                btn.MouseUp += (s, a) =>
                {
                    if ((waveOut != null) && (waveOut[i].PlaybackState == PlaybackState.Playing))
                    {
                        waveOut[i].Stop();
                        isPlaying[i] = false;
                    }
                };
            }
            else
            {
                Form1 form = (Form1)sender;
                form.KeyUp += (s, a) =>
                {
                    if ((waveOut != null) && (waveOut[i].PlaybackState == PlaybackState.Playing))
                    {
                        waveOut[i].Stop();
                        isPlaying[i] = false;
                    }
                };
            }
        }


        //---------------------------- KEYS ----------------------------

        private void btn_c1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.c/2, 0);
        }
        private void btn_cg1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.cg/2, 1);
        }
        private void btn_d1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.d / 2, 2);
        }
        private void btn_dg1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.dg / 2, 3);
        }
        private void btn_e1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.e / 2, 4);
        }
        private void btn_f1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.f / 2, 5);
        }
        private void btn_fg1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.fg / 2, 6);
        }
        private void btn_g1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.g / 2, 7);
        }
        private void btn_gg1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.gg / 2, 8);
        }
        private void btn_a1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.a / 2, 9);
        }
        private void btn_ag1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.ag / 2, 10);
        }
        private void btn_b1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.b / 2, 11);
        }
        private void btn_c_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.c, 12);
        }
        private void btn_cg_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.cg, 13);
        }
        private void btn_d_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.d, 14);
        }
        private void btn_dg_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.dg, 15);
        }
        private void btn_e_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.e, 16);
        }
        private void btn_f_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.f, 17);
        }
        private void btn_fg_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.fg, 18);
        }
        private void btn_g_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.g, 19);
        }
        private void btn_gg_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.gg, 20);
        }
        private void btn_a_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.a, 21);
        }
        private void btn_ag_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.ag, 22);
        }
        private void btn_b_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.b, 23);
        }
        private void btn_c3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.c*2, 24);
        }
        private void btn_cg3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.cg * 2, 25);
        }
        private void btn_d3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.d * 2, 26);
        }
        private void btn_dg3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.dg * 2, 27);
        }
        private void btn_e3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.e * 2, 28);
        }
        private void btn_f3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.f * 2, 29);
        }
        private void btn_fg3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.fg * 2, 30);
        }
        private void btn_g3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.g * 2, 31);
        }
        private void btn_gg3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.gg * 2, 32);
        }
        private void btn_a3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.a * 2, 33);
        }
        private void btn_ag3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.ag * 2, 34);
        }
        private void btn_b3_MouseDown(object sender, MouseEventArgs e)
        {
            PlayTone(sender, Globals.b * 2, 35);
        }

        
    }
}



