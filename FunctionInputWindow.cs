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
    public partial class FunctionInputWindow : Form
    {
        public string func;

        private char[] commands = new char[]
{
            '+',
            '-',
            '*',
            '/',
            '^'
};


        public FunctionInputWindow()
        {
            InitializeComponent();
        }


        private string GetValidFunc(string input)
        {
            string ret = "";

            short bracketsCounter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    if (input[i] == '[' || input[i] == '{' || input[i] == '(')
                    {
                        bracketsCounter++;
                        ret += '(';
                    }
                    else if (input[i] == ']' || input[i] == '}' || input[i] == ')')
                    {
                        bracketsCounter--;
                        ret += ')';
                    }
                    else if (Char.IsLetter(input[i]))
                        ret += Char.ToLower(input[i]);
                    else if (Char.IsNumber(input[i]))
                        ret += input[i];
                    else if (commands.Contains(input[i]))
                        ret += input[i];
                }
            }

            if (bracketsCounter > 0)
            {
                MessageBox.Show("')' Missing.");
                ret = "";
            }
            else if (bracketsCounter < 0)
            {
                MessageBox.Show("'(' Missing.");
                ret = "";
            }

            return ret;
        }

        private bool IsWrappedWithBrackets(string s)
        {
            if (s.Length < 2)
                return false;

            if (s[0] != '(' || s[s.Length - 1] != ')')
                return false;

            int bracketsCounter = 0;

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '(')
                    bracketsCounter++;
                else if (s[i] == ')')
                    bracketsCounter--;

                if (bracketsCounter < 0)
                    return false;
            }

            return true;
        }

        private void MakeTree(BinTreeNode<string> tree)
        {
            short bracketsCounter = 0;
            string s;
            string tempS = tree.GetInfo();

            if (IsWrappedWithBrackets(tempS))
            {
                tempS = tempS.Substring(1, tempS.Length - 2);
                tree.SetInfo(tempS);
            }

            // +, -
            for (int i = 0; i < tempS.Length; i++)
            {
                if (tempS[i] == '(')
                    bracketsCounter++;
                else if (tempS[i] == ')')
                    bracketsCounter--;

                else if (bracketsCounter == 0)
                {
                    s = "";
                    s += tempS[i];

                    if (s == "+" || s == "-")
                    {
                        if (i == 0)
                        {
                            tempS = '0' + tempS;
                            i++;
                        }

                        tree.SetLeft(new BinTreeNode<string>(tempS.Substring(0, i)));
                        MakeTree(tree.GetLeft());
                        tree.SetRight(new BinTreeNode<string>(tempS.Substring(i + 1)));
                        MakeTree(tree.GetRight());

                        tree.SetInfo(s);
                        i = tempS.Length;
                        tempS = s;
                    }
                }
            }

            // *, /, ^
            for (int i = 0; i < tempS.Length; i++)
            {
                if (tempS[i] == '(')
                    bracketsCounter++;
                else if (tempS[i] == ')')
                    bracketsCounter--;

                else if (bracketsCounter == 0)
                {
                    s = "";
                    s += tempS[i];

                    if (s == "*" || s == "/" || s == "^")
                    {
                        if (i == 0)
                        {
                            tempS = '0' + tempS;
                            i++;
                        }

                        tree.SetLeft(new BinTreeNode<string>(tempS.Substring(0, i)));
                        MakeTree(tree.GetLeft());
                        tree.SetRight(new BinTreeNode<string>(tempS.Substring(i + 1)));
                        MakeTree(tree.GetRight());

                        tree.SetInfo(s);
                        i = tempS.Length;
                        tempS = s;
                    }
                }
            }

            // 
            for (int i = 0; i < tempS.Length; i++)
            {
                if (tempS[i] == '(')
                    bracketsCounter++;
                else if (tempS[i] == ')')
                    bracketsCounter--;

                else if (bracketsCounter == 0)
                {
                    s = "";
                    s += tempS[i];

                    //if (s == "*" || s == "/" || s == "^")
                    //{
                    //    tree.SetLeft(new BinTreeNode<string>(tempS.Substring(0, i)));
                    //    MakeTree(tree.GetLeft());
                    //    tree.SetRight(new BinTreeNode<string>(tempS.Substring(i + 1)));
                    //    MakeTree(tree.GetRight());

                    //    tree.SetInfo(s);
                    //    i = tempS.Length;
                    //}


                    //else
                    if (tempS.Length > i + 3)
                    {
                        s = tempS.Substring(i, 3);

                        if (s == "sin" || s == "cos" || s == "tan" || s == "abs" || s == "log")
                        {
                            tree.SetLeft(new BinTreeNode<string>(tempS.Substring(i + 3)));
                            MakeTree(tree.GetLeft());

                            tree.SetInfo(s);
                            i = tempS.Length;
                        }
                        else if (s == "max" || s == "min" || s == "pow")
                        {
                            int g = i + 3;
                            for (; g < tempS.Length && tempS[g] != ','; g++) ;

                            tree.SetLeft(new BinTreeNode<string>(tempS.Substring(i + 4, g - i - 4)));
                            MakeTree(tree.GetLeft());
                            tree.SetRight(new BinTreeNode<string>(tempS.Substring(g + 1)));
                            MakeTree(tree.GetRight());

                            tree.SetInfo(s);
                            i = tempS.Length;
                        }


                        else if (tempS.Length > i + 4)
                        {
                            s = tempS.Substring(i, 4);

                            if (s == "sqrt")
                            {
                                tree.SetLeft(new BinTreeNode<string>(tempS.Substring(i + 4)));
                                MakeTree(tree.GetLeft());

                                tree.SetInfo(s);
                                i = tempS.Length;
                            }
                        }
                    }




                }
            }
        }

        private float SolveTree(float x, float y, BinTreeNode<string> tree)
        {
            switch (tree.GetInfo())
            {
                case "x":
                    return x;

                case "y":
                    return y;

                case "+":
                    return SolveTree(x, y, tree.GetLeft()) + SolveTree(x, y, tree.GetRight());

                case "-":
                    return SolveTree(x, y, tree.GetLeft()) - SolveTree(x, y, tree.GetRight());

                case "*":
                    return SolveTree(x, y, tree.GetLeft()) * SolveTree(x, y, tree.GetRight());

                case "/":
                    return SolveTree(x, y, tree.GetLeft()) / SolveTree(x, y, tree.GetRight());

                case "^":
                    return (float)Math.Pow(SolveTree(x, y, tree.GetLeft()), SolveTree(x, y, tree.GetRight()));

                case "sin":
                    return (float)Math.Sin(SolveTree(x, y, tree.GetLeft()));

                case "cos":
                    return (float)Math.Cos(SolveTree(x, y, tree.GetLeft()));

                case "tan":
                    return (float)Math.Tan(SolveTree(x, y, tree.GetLeft()));

                case "abs":
                    return (float)Math.Abs(SolveTree(x, y, tree.GetLeft()));

                case "pow":
                    return (float)Math.Pow(SolveTree(x, y, tree.GetLeft()), SolveTree(x, y, tree.GetRight()));

                case "max":
                    return (float)Math.Max(SolveTree(x, y, tree.GetLeft()), SolveTree(x, y, tree.GetRight()));

                case "min":
                    return (float)Math.Min(SolveTree(x, y, tree.GetLeft()), SolveTree(x, y, tree.GetRight()));

                case "sqrt":
                    return (float)Math.Sqrt(SolveTree(x, y, tree.GetLeft()));



                default:
                    return float.Parse(tree.GetInfo());
            }
        }


        //public Mesh FromFunction()
        //{
        //    float range = 100;
        //    float range_Offset = range / 2;

        //    float jumpSize = 0.1f;
        //    float xx, yy;

        //    Mesh ret = new Mesh("func");

        //    for (int y = 0; y < range; y++)
        //    {
        //        for (int x = 0; x < range; x++)
        //        {
        //            xx = (x - range_Offset) * jumpSize;
        //            yy = (y - range_Offset) * jumpSize;
        //            //Z[x, y] = Math.Sin(x - 50) * Math.Sin(y - 50);

        //            ret.Points.Add(new Point3D(xx, yy, (float)(Math.Sin(Math.Pow(xx, 2) + Math.Pow(yy, 2)))));
        //            //ret.Points.Add(new Vector3(xx, yy, (float)((Math.Pow((Math.Pow(xx, 2) + Math.Pow(yy, 2)), 0.5)))));
        //            //ret.Points.Add(new Vector3(xx, yy, (float)(1 / (15 * ((Math.Pow(xx, 2) + Math.Pow(yy, 2)))))));
        //            //ret.Points.Add(new Vector3(xx, yy, (float)(1 - (Math.Abs(yy)))));

        //            if (x < range - 1)
        //                ret.Lines.Add(new Vector3(ret.Points.Count - 1, ret.Points.Count, -1));
        //            if (y < range - 1)
        //                ret.Lines.Add(new Vector3(ret.Points.Count - 1, ret.Points.Count - 1 + range, -1));

        //            if (x < range - 1 && y < range - 1)
        //            {
        //                ret.Polygons.Add(new Polygon(ret.Points.Count - 1, ret.Points.Count - 1 + range, ret.Points.Count));
        //                ret.Polygons.Add(new Polygon(ret.Points.Count + range, ret.Points.Count, ret.Points.Count - 1 + range));
        //            }
        //        }
        //    }

        //    return ret;
        //}


        private void selectBU_Click(object sender, EventArgs e)
        {
            func = GetValidFunc(inputCOBO.Text);
            //BinTreeNode<string> tree = new BinTreeNode<string>(func);
            //MakeTree(tree);


            //int range = 100;
            //float range_Offset = range / 2;
            //float jumpSize = 0.1f;
            //float xx, yy;

            //Mesh tempMesh = new Mesh(func);

            //int[,] vert_index = new int[range, range];

            //for (int y = 0; y < range; y++)
            //    for (int x = 0; x < range; x++)
            //    {
            //        xx = (x - range_Offset) * jumpSize;
            //        yy = (y - range_Offset) * jumpSize;

            //        tempMesh.Vertices.Add(new Vertex(xx, SolveTree(xx, yy, tree), yy));
            //        tempMesh.Vertices[tempMesh.Vertices.Count - 1].Texel = new Vector3(x, y, 0);
            //        vert_index[x, y] = tempMesh.Vertices.Count - 1;
            //    }

            //for (int y = 0; y < range - 1; y++)
            //    for (int x = 0; x < range - 1; x++)
            //    {
            //        tempMesh.Faces.Add(new Face(tempMesh.Vertices[vert_index[x, y]], tempMesh.Vertices[vert_index[x, y + 1]], tempMesh.Vertices[vert_index[x + 1, y]]));
            //        tempMesh.Faces[tempMesh.Faces.Count - 1].Set_Parent(tempMesh);
            //        tempMesh.Faces.Add(new Face(tempMesh.Vertices[vert_index[x + 1, y + 1]], tempMesh.Vertices[vert_index[x + 1, y]], tempMesh.Vertices[vert_index[x, y + 1]]));
            //        tempMesh.Faces[tempMesh.Faces.Count - 1].Set_Parent(tempMesh);
            //    }


            //foreach (Vertex vertex in tempMesh.Vertices)
            //    vertex.Normal_Calculate();


            //Mesh = tempMesh;
            Close();
        }

        public Mesh GetMesh()
        {
            //func = GetValidFunc(inputCOBO.Text);
            BinTreeNode<string> tree = new BinTreeNode<string>(func);
            MakeTree(tree);


            int range = 100;
            float range_Offset = range / 2;
            float jumpSize = 0.1f;
            float xx, yy;

            Mesh ret = new Mesh(func);

            int[,] vert_index = new int[range, range];

            for (int y = 0; y < range; y++)
                for (int x = 0; x < range; x++)
                {
                    xx = (x - range_Offset) * jumpSize;
                    yy = (y - range_Offset) * jumpSize;

                    ret.Vertices.Add(new Vertex(xx, SolveTree(xx, yy, tree), yy));
                    ret.Vertices[ret.Vertices.Count - 1].Texel = new Vector3(x, y, 0);
                    vert_index[x, y] = ret.Vertices.Count - 1;
                }

            for (int y = 0; y < range - 1; y++)
                for (int x = 0; x < range - 1; x++)
                {
                    ret.Faces.Add(new Face(ret.Vertices[vert_index[x, y]], ret.Vertices[vert_index[x, y + 1]], ret.Vertices[vert_index[x + 1, y]]));
                    ret.Faces[ret.Faces.Count - 1].Set_Parent(ret);
                    ret.Faces.Add(new Face(ret.Vertices[vert_index[x + 1, y + 1]], ret.Vertices[vert_index[x + 1, y]], ret.Vertices[vert_index[x, y + 1]]));
                    ret.Faces[ret.Faces.Count - 1].Set_Parent(ret);
                }


            foreach (Vertex vertex in ret.Vertices)
                vertex.Normal_Calculate();


            return ret;
        }

        private void cancelBU_Click(object sender, EventArgs e)
        {
            func = "";

            Close();
        }
    }
}

