using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REngine
{
    public partial class NoiseGenerationWindow : Form
    {
        public bool HasNoise;
        public float[,] NoiseMap;


        private int[] potential_vector_values = new int[2] { -1, 1 };
        private Vector3[] potential_vectors = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, -1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(-1, -1, 0)
            //Vector3.Normalized(new Vector3(1, 1, 0)),
            //Vector3.Normalized(new Vector3(1, -1, 0)),
            //Vector3.Normalized(new Vector3(-1, 1, 0)),
            //Vector3.Normalized(new Vector3(-1, -1, 0))
        };

        public NoiseGenerationWindow()
        {
            InitializeComponent();

            HasNoise = false;
        }


        private void generateBU_Click(object sender, EventArgs e)
        {
            int f = (int)frequencyNUPDO.Value;
            int w = (int)widthNUPDO.Value,
                h = (int)heightNUPDO.Value;

            //NoiseMap = Make_PerlinNoise(f, w, h);
            //HasNoise = true;

            //displayPIBO.BackgroundImage = RE.Array_To_Bitmap(NoiseMap);
            //displayPIBO.Refresh();
            //return;

            NoiseMap = new float[w, h];

            int blockSize_x = NoiseMap.GetLength(0) / f,
                blockSize_y = NoiseMap.GetLength(1) / f;

            Vector3[,] vectors_net = new Vector3[f + 1, f + 1];
            Random rnd = new Random();
            Vector3[,] random_points = new Vector3[f, f]; ;
            float[,] cornerValues = new float[f + 1, f + 1];
            Vector3[] tempDots = new Vector3[4];


            for (int y = 0; y < f + 1; y++)
                for (int x = 0; x < f + 1; x++)
                {
                    vectors_net[x, y] = new Vector3(potential_vectors[rnd.Next(potential_vectors.Length)]);
                    //Vector3.Normalized(vectors_net[x, y]);
                }

            float min = 0, max = 0;
            for (int y = 0; y < f; y++)
                for (int x = 0; x < f; x++)
                {
                    random_points[x, y] = new Vector3(rnd.Next(0, blockSize_x), rnd.Next(0, blockSize_y), 0);

                    tempDots[0] = new Vector3(random_points[x, y]);
                    tempDots[1] = new Vector3(1 - random_points[x, y].X, random_points[x, y].Y, 0);
                    tempDots[2] = new Vector3(random_points[x, y].X, 1 - random_points[x, y].Y, 0);
                    tempDots[3] = new Vector3(1 - random_points[x, y].X, 1 - random_points[x, y].Y, 0);

                    //tempDots[0] = Vector3.Normalized(tempDots[0]);
                    //tempDots[1] = Vector3.Normalized(tempDots[1]);
                    //tempDots[2] = Vector3.Normalized(tempDots[2]);
                    //tempDots[3] = Vector3.Normalized(tempDots[3]);


                    cornerValues[x, y] = Vector3.Dot(tempDots[0], vectors_net[x, y]);
                    cornerValues[x + 1, y] = Vector3.Dot(tempDots[1], vectors_net[x + 1, y]);
                    cornerValues[x, y + 1] = Vector3.Dot(tempDots[2], vectors_net[x, y + 1]);
                    cornerValues[x + 1, y + 1] = Vector3.Dot(tempDots[3], vectors_net[x + 1, y + 1]);
                }

            foreach (float tempVal in cornerValues)
            {
                if (tempVal > max)
                    max = tempVal;
                else if (tempVal < min)
                    min = tempVal;
            }

            float range = max - min;
            for (int y = 0; y < f + 1; y++)
                for (int x = 0; x < f + 1; x++)
                {
                    cornerValues[x, y] = (cornerValues[x, y] - min) / range;
                    //cornerValues[x, y] = RE.EaseCurve_Perlin(cornerValues[x, y]);
                }


            for (int y = 0; y < f; y++)
                for (int x = 0; x < f; x++)
                {
                    int real_x = x * blockSize_x,
                        real_y = y * blockSize_y;

                    //for (int yy = 0; yy < blockSize_y; yy++)
                    //{
                    //    float intrepolation_factor = (float)yy / (float)blockSize_y;

                    //    NoiseMap[real_x, real_y + yy] = RE.Interpolate_Linear(cornerValues[x, y], cornerValues[x, y + 1], intrepolation_factor);
                    //    NoiseMap[real_x, real_y + yy] = RE.EaseCurve_Perlin(NoiseMap[real_x, real_y + yy]);

                    //    NoiseMap[real_x + blockSize_x - 1, real_y + yy] = RE.Interpolate_Linear(cornerValues[x + 1, y], cornerValues[x + 1, y + 1], intrepolation_factor);
                    //    NoiseMap[real_x + blockSize_x - 1, real_y + yy] = RE.EaseCurve_Perlin(NoiseMap[real_x + blockSize_x - 1, real_y + yy]);

                    //    for (int xx = 0; xx < blockSize_x; xx++)
                    //    {
                    //        intrepolation_factor = (float)xx / (float)blockSize_x;

                    //        NoiseMap[real_x + xx, real_y + yy] = RE.Interpolate_Linear(NoiseMap[real_x, real_y + yy], NoiseMap[real_x + blockSize_x - 1, real_y + yy], intrepolation_factor);
                    //        NoiseMap[real_x + xx, real_y + yy] = RE.EaseCurve_Perlin(NoiseMap[real_x + xx, real_y + yy]);
                    //    }

                    //}

                    for (int xx = 0; xx < blockSize_x; xx++)
                    {
                        float intrepolation_factor = 1 - (float)xx / (float)blockSize_x;
                        //intrepolation_factor = RE.EaseCurve_Perlin(intrepolation_factor);

                        NoiseMap[real_x + xx, real_y] = RE.Lerp(cornerValues[x, y], cornerValues[x + 1, y], intrepolation_factor);
                        //NoiseMap[real_x + xx, real_y] = RE.EaseCurve_Perlin(NoiseMap[real_x + xx, real_y]);

                        NoiseMap[real_x + xx, real_y + blockSize_y - 1] = RE.Lerp(cornerValues[x, y + 1], cornerValues[x + 1, y + 1], intrepolation_factor);
                        //NoiseMap[real_x + xx, real_y + blockSize_y - 1] = RE.EaseCurve_Perlin(NoiseMap[real_x + xx, real_y + blockSize_y - 1]);

                        for (int yy = 0; yy < blockSize_y; yy++)
                        {
                            intrepolation_factor = 1 - (float)yy / (float)blockSize_y;
                            //intrepolation_factor = RE.EaseCurve_Perlin(intrepolation_factor);

                            NoiseMap[real_x + xx, real_y + yy] = RE.Lerp(NoiseMap[real_x + xx, real_y], NoiseMap[real_x + xx, real_y + blockSize_y - 1], intrepolation_factor);
                            //NoiseMap[real_x + xx, real_y + yy] = RE.EaseCurve_Perlin(NoiseMap[real_x + xx, real_y + yy]);
                        }

                    }
                }

            for (int y = 0; y < NoiseMap.GetLength(1); y++)
                for (int x = 0; x < NoiseMap.GetLength(0); x++)
                    NoiseMap[x, y] = RE.EaseCurve_Perlin(NoiseMap[x, y]);


            HasNoise = true;

            displayPIBO.BackgroundImage = RE.Array_To_Bitmap(NoiseMap);
            displayPIBO.Refresh();
        }



        private float[,] Make_PerlinNoise(int f, int w, int h)
        {
            float[,] ret = new float[w, h];

            int blockSize_x = ret.GetLength(0) / f,
                blockSize_y = ret.GetLength(1) / f;

            Vector3[,] vectors_net = new Vector3[f + 1, f + 1];
            Random rnd = new Random();
            float[,] cornerValues = new float[f + 1, f + 1];
            Vector3[] tempVecs = new Vector3[4];
            float[] tempDots = new float[4];

            for (int y = 0; y < f + 1; y++)
                for (int x = 0; x < f + 1; x++)
                {
                    vectors_net[x, y] = new Vector3(potential_vectors[rnd.Next(potential_vectors.Length)]);
                    //vectors_net[x, y] = new Vector3(potential_vector_values[rnd.Next(2)], potential_vector_values[rnd.Next(2)], 0);
                    //Vector3.Normalized(vectors_net[x, y]);
                }



            float min = 0, max = 0;
            int currentBlock_X,
                currentBlock_y;

            for (int y = 0; y < h; y++)
            {
                currentBlock_y = y / blockSize_y;

                for (int x = 0; x < w; x++)
                {
                    currentBlock_X = x / blockSize_x;

                    tempVecs[0] = new Vector3(x - currentBlock_X * blockSize_x, y - currentBlock_y * blockSize_y, 0);
                    tempVecs[1] = new Vector3(x - (currentBlock_X + 1) * blockSize_x, y - currentBlock_y * blockSize_y, 0);
                    tempVecs[2] = new Vector3(x - currentBlock_X * blockSize_x, y - (currentBlock_y + 1) * blockSize_y, 0);
                    tempVecs[3] = new Vector3(x - (currentBlock_X + 1) * blockSize_x, y - (currentBlock_y + 1) * blockSize_y, 0);

                    //tempVecs[0] = Vector3.Normalized(tempVecs[0]);
                    //tempVecs[1] = Vector3.Normalized(tempVecs[1]);
                    //tempVecs[2] = Vector3.Normalized(tempVecs[2]);
                    //tempVecs[3] = Vector3.Normalized(tempVecs[3]);

                    tempDots[0] = Vector3.Dot(tempVecs[0], vectors_net[currentBlock_X, currentBlock_y]);
                    tempDots[1] = Vector3.Dot(tempVecs[1], vectors_net[currentBlock_X + 1, currentBlock_y]);
                    tempDots[2] = Vector3.Dot(tempVecs[2], vectors_net[currentBlock_X, currentBlock_y + 1]);
                    tempDots[3] = Vector3.Dot(tempVecs[3], vectors_net[currentBlock_X + 1, currentBlock_y + 1]);

                    //tempDots[0] = (tempDots[0] + 1) / 2;
                    //tempDots[1] = (tempDots[1] + 1) / 2;
                    //tempDots[2] = (tempDots[2] + 1) / 2;
                    //tempDots[3] = (tempDots[3] + 1) / 2;


                    float lerp_weight = 1 - ((float)((x % blockSize_x) / blockSize_x));
                    if (lerp_weight < 0 || lerp_weight > 1)
                        MessageBox.Show(lerp_weight.ToString());
                    lerp_weight = RE.EaseCurve_Perlin(lerp_weight);

                    float tempValue1 = RE.Lerp(tempDots[0], tempDots[1], lerp_weight);
                    float tempValue2 = RE.Lerp(tempDots[2], tempDots[3], lerp_weight);

                    //tempValue1 = (tempValue1 + 18) / 36;
                    //tempValue2 = (tempValue2 + 18) / 36;

                    lerp_weight = 1 - ((float)((y % blockSize_y) / blockSize_y));
                    if (lerp_weight < 0 || lerp_weight > 1)
                        MessageBox.Show(lerp_weight.ToString());
                    lerp_weight = RE.EaseCurve_Perlin(lerp_weight);

                    ret[x, y] = RE.Lerp(tempValue1, tempValue2, lerp_weight);
                    //ret[x, y] = RE.EaseCurve_Perlin(ret[x, y]);


                    ret[x, y] = (ret[x, y] + 20) / 40;

                    for (int i = 0; i < tempDots.Length; i++)
                    {
                        if (tempDots[i] > max)
                            max = tempDots[i];
                        else if (tempDots[i] < min)
                            min = tempDots[i];
                    }

                }
            }

            MessageBox.Show("min = " + min + ", max = " + max);

            //float range = max - min;
            //for (int y = 0; y < h; y++)
            //    for (int x = 0; x < w; x++)
            //    {
            //        ret[x, y] = (ret[x, y] - min) / range;
            //        //ret[x, y] = RE.EaseCurve_Perlin(ret[x, y]);
            //    }

            return ret;
        }



        private void cancelBU_Click(object sender, EventArgs e)
        {
            HasNoise = false;
            Close();
        }

        private void selectBU_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
