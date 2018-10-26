/*
--------------------------------------------------------------------------
  Namespace:      <LPSolve>
  Class:          <LPApplication>
  Description:    <Solving Linear Programming using Simplex Method>
  Author:         <Le Trong Hieu>                    Date: <2017-11-01>
  School:         <Da Nang University of Technology>
--------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPApplication
{
    public partial class Form1 : Form
    {
        static string pathInput = @"c:\temp\LPInput.txt";
        static string pathOutput = @"c:\temp\LPOutput.txt";
        static List<string> lines = new List<string>();
        static int countTable = 1;



        static bool isMax;
        static int numberOfVars, numberOfConstraints;
        static int numberOfSlackVars = 0;
        static double[] coEfficent;
        static double[,] matrix;
        static string[] sign;

        static double[,] extendedMatrix;
        static double[] lambda;
        static double[] indicators;
        static double pivot;
        static int pivotColumn = 0;
        static int pivotRow = 0;
        static double pivotOfIndicators, pivotOfLambda;
        static double targetValue = 0;

        static double[] vars;

        public static void ReadFile(string address)
        {
            try
            {
                StreamReader sr = new StreamReader(address);
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Khong the doc du lieu tu file da cho: ");
                Console.WriteLine(e.Message);
            }
        }

        public static void ShowProblem()
        {
            if (isMax == false) Console.WriteLine("The given minimization problem corresponding to the dual maximization problem");
            Console.WriteLine("Objective function");
            for (int i = 0; i < coEfficent.Length; i++)
            {
                Console.Write(String.Format("{0,10:0.###}", coEfficent[i]));
            }

            Console.WriteLine("\nCoefficient constraints matrix");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,10:0.###}", matrix[i, j]));
                }
                Console.Write(String.Format("{0,10:0.###}", lambda[i]));

                Console.WriteLine();
            }
        }

        public static void GenerateInfomation()
        {
            isMax = (lines[0].ToLower().Contains("max")) ? true : false;

            string[] temp = lines[1].Split(' ');
            numberOfVars = int.Parse(temp[0]);
            numberOfConstraints = int.Parse(temp[1]);

            if (isMax) GenerateMaxProblem();
            else GenerateMinProblem();
        }

        public static void GenerateMaxProblem()
        {
            coEfficent = new double[numberOfVars];
            matrix = new double[numberOfConstraints, numberOfVars];
            lambda = new double[numberOfConstraints];
            sign = new string[numberOfConstraints];

            //Put values into an coefficent of objective function Array
            string[] tempLineObjectiveFunc = lines[2].Split(' ');
            for (int i = 0; i < numberOfVars; i++)
            {
                coEfficent[i] = double.Parse(tempLineObjectiveFunc[i]);
            }

            for (int i = 3; i < lines.Count; i++)
            {
                string[] tempLine = lines[i].Split(' ');

                //Change sign to <= or =; Count how many slack variables will be generated
                int checkSign = (tempLine[numberOfVars] == ">=") ? -1 : 1;
                sign[i - 3] = (tempLine[numberOfVars] == "=") ? "=" : "<=";
                numberOfSlackVars = (tempLine[numberOfVars] == "=") ? numberOfSlackVars : numberOfSlackVars + 1;

                //Put coefficent from Constraints into matrix
                for (int j = 0; j < numberOfVars; j++)
                {
                    matrix[i - 3, j] = checkSign * double.Parse(tempLine[j]);
                }

                //Put values into lambda column
                lambda[i - 3] = checkSign * double.Parse(tempLine[numberOfVars + 1]);

            }
            InitiateTableau();
        }

        public static void GenerateMinProblem()
        {
            double[] minCoEfficent = new double[numberOfVars];
            double[,] minMatrix = new double[numberOfConstraints, numberOfVars];
            double[] minLambda = new double[numberOfConstraints];

            string[] tempLineObjectiveFunc = lines[2].Split(' ');
            for (int i = 0; i < numberOfVars; i++)
            {
                minCoEfficent[i] = double.Parse(tempLineObjectiveFunc[i]);
            }
            for (int i = 3; i < lines.Count; i++)
            {
                string[] tempLine = lines[i].Split(' ');

                //Count how many slack variables will be generated
                int checkSign = (tempLine[numberOfVars] == "<=") ? -1 : 1;
                numberOfSlackVars = numberOfVars;

                //Put coefficent from Constraints into minMatrix
                for (int j = 0; j < numberOfVars; j++)
                {
                    minMatrix[i - 3, j] = checkSign * double.Parse(tempLine[j]);
                }

                //Put values into minLambda column
                minLambda[i - 3] = checkSign * double.Parse(tempLine[numberOfVars + 1]);
            }

            //Change to max problem
            coEfficent = new double[numberOfConstraints];
            matrix = new double[numberOfVars, numberOfConstraints];
            lambda = new double[numberOfVars];
            sign = new string[numberOfVars];
            for (int i = 0; i < sign.Length; i++)
            {
                sign[i] = "<=";
            }

            minLambda.CopyTo(coEfficent, 0);
            minCoEfficent.CopyTo(lambda, 0);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = minMatrix[j, i];
                }
            }

            int temp = numberOfVars;
            numberOfVars = numberOfConstraints;
            numberOfConstraints = temp;

            InitiateTableau();

        }

        public static void InitiateTableau()
        {
            extendedMatrix = new double[numberOfConstraints, numberOfVars + numberOfSlackVars];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    extendedMatrix[i, j] = matrix[i, j];
                }
            }

            int indexOfSlackVar = 0;
            for (int i = 0; i < extendedMatrix.GetLength(0); i++)
            {
                if (sign[i] == "<=")
                {
                    extendedMatrix[i, matrix.GetLength(1) + indexOfSlackVar] = 1;
                    indexOfSlackVar++;
                }
            }

            indicators = new double[numberOfVars + numberOfSlackVars];
            for (int i = 0; i < coEfficent.Length; i++)
            {
                indicators[i] = -coEfficent[i];
            }
        }

        public static void ShowTableau()
        {
            FindPivot();
            if (!isFinalTableau())
                Console.WriteLine("Pivot a[" + pivotRow + "," + pivotColumn + "] =" + String.Format("{0,8:0.###}", pivot));
            else Console.WriteLine("Final Tableau");
            int countName = 1;

            for (int i = 0; i < numberOfVars + numberOfSlackVars; i++)
            {
                string varName = ((isMax == true) ? "x" : "y") + countName;
                Console.Write(String.Format("{0,10:[0.###]}", varName));
                countName++;
            }
            Console.Write(String.Format("{0,10:[0.###]}", "λ"));
            Console.WriteLine();
            for (int i = 0; i < numberOfSlackVars + numberOfVars + 1; i++)
            {
                Console.Write("__________");
            }
            Console.WriteLine();

            for (int i = 0; i < extendedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < extendedMatrix.GetLength(1); j++)
                {
                    if (i == pivotRow && j == pivotColumn && !isFinalTableau())
                    {
                        Console.Write(String.Format("{0,10:[0.###]}", extendedMatrix[i, j]));
                    }
                    else
                        Console.Write(String.Format("{0,10:0.###}", extendedMatrix[i, j]));
                }
                Console.Write(String.Format("{0,10:0.###}", lambda[i]));
                Console.WriteLine();
            }
            for (int i = 0; i < numberOfSlackVars + numberOfVars + 1; i++)
            {
                Console.Write("__________");
            }
            Console.WriteLine();
            foreach (double indicator in indicators)
            {
                Console.Write(String.Format("{0,10:0.###}", indicator));
            }

            Console.WriteLine(String.Format("{0,10:0.###}", targetValue));
        }

        public static void FindPivot()
        {
            pivotOfIndicators = pivotOfLambda = double.PositiveInfinity;

            for (int i = 0; i < indicators.Length; i++)
            {
                if (indicators[i] < 0 && indicators[i] < pivotOfIndicators)
                {
                    pivotOfIndicators = indicators[i];
                    pivotColumn = i;
                }
            }

            for (int i = 0; i < lambda.Length; i++)
            {
                double ratio = lambda[i] / extendedMatrix[i, pivotColumn];
                if (ratio > 0 && ratio < pivotOfLambda)
                {
                    pivotOfLambda = ratio;
                    pivotRow = i;
                }
            }

            pivot = extendedMatrix[pivotRow, pivotColumn];
        }

        public static void ChangeTableau()
        {

            for (int i = 0; i < extendedMatrix.GetLength(0); i++)
            {
                if (i != pivotRow)
                {
                    double delta = -(extendedMatrix[i, pivotColumn] / pivot);
                    lambda[i] += delta * lambda[pivotRow];
                    for (int j = 0; j < extendedMatrix.GetLength(1); j++)
                    {
                        extendedMatrix[i, j] += delta * extendedMatrix[pivotRow, j];
                    }
                }
            }
            //Change indicator
            double deltaLambda = -indicators[pivotColumn] / pivot;
            for (int j = 0; j < indicators.Length; j++)
            {
                indicators[j] += deltaLambda * extendedMatrix[pivotRow, j];
            }
            targetValue += deltaLambda * lambda[pivotRow];
        }

        public static bool isFinalTableau()
        {
            foreach (double indicator in indicators)
            {
                if (indicator < 0) return false;
            }
            return true;
        }

        public static bool isSolutionExist()
        {
            for (int i = 0; i < lambda.Length; i++)
            {
                if (lambda[i] / extendedMatrix[i, pivotColumn] > 0) return true;
            }
            return false;
        }

        public static void FindVars()
        {
            Console.WriteLine("\n*** Final Solution ***");
            if (isMax == true)
            {
                vars = new double[numberOfVars + numberOfSlackVars];
                bool[] checkValue = new bool[numberOfVars + numberOfSlackVars];
                for (int i = 0; i < indicators.Length; i++)
                {
                    if (indicators[i] != 0)
                    {
                        vars[i] = 0;
                        checkValue[i] = true;
                    }
                }

                for (int i = 0; i < extendedMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < extendedMatrix.GetLength(1); j++)
                    {
                        if (checkValue[j] == false && extendedMatrix[i, j] != 0)
                        {
                            vars[j] = lambda[i] / extendedMatrix[i, j];
                            checkValue[j] = true;
                        }
                    }
                }
            }
            else
            {
                vars = new double[numberOfSlackVars];
                for (int i = numberOfVars; i < indicators.Length; i++)
                {
                    vars[i - numberOfVars] = indicators[i];
                }
            }


        }

        public static void FinalOutput()
        {
            if (double.IsPositiveInfinity(targetValue))
            {
                Console.WriteLine("Objective function is unbounded. No solution exist !");
            }
            else
            {
                int countVarName = 1;
                foreach (double value in vars)
                {
                    Console.Write(String.Format("{0,10:0.###}", "x" + countVarName + " = " + value));
                    countVarName++;
                }
                Console.WriteLine(String.Format("{0,18:0.###}", "f(" + ((isMax == true) ? "max) = " : "min) = ") + targetValue));
            }
        }

        public static void SolveProcedure()
        {
            GenerateInfomation();
            ShowProblem();
            Console.WriteLine("\nTableau #" + countTable);
            ShowTableau();
            while (!isFinalTableau())
            {
                if (!isSolutionExist())
                {
                    Console.WriteLine("No solution exists !");
                    break;
                }
                countTable++;
                Console.WriteLine("\nTableau #" + countTable);
                FindPivot();
                ChangeTableau();
                ShowTableau();
            }
            if (countTable == 1) Console.WriteLine("No Solution exists !");
            else
            {
                FindVars();
                FinalOutput();
            }
        }

        public static void ConsoleToTextFile()
        {
            FileStream fs = File.Create(pathOutput);
            TextWriter tmp = Console.Out;
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
            SolveProcedure();
            Console.SetOut(tmp);
            sw.Close();
        }

        public Form1()
        {
            InitializeComponent();
            radioButtonOpen.Checked = true;
        }

        private void radioButtonGetInput_CheckedChanged(object sender, EventArgs e)
        {
            buttonOpen.Enabled = false;
            numericUpDownVars.Enabled = true;
            numericUpDownConstraints.Enabled = true;
            buttonOK.Enabled = true;
        }

        private void radioButtonOpen_CheckedChanged(object sender, EventArgs e)
        {
            buttonOpen.Enabled = true;
            numericUpDownVars.Enabled = false;
            numericUpDownConstraints.Enabled = false;
            buttonOK.Enabled = false;
            buttonGenerate.Enabled = false;
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = File.ReadAllText(pathOutput);
                dataGridView1.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                buttonGenerate.Enabled = true;
                buttonOK.Enabled = false;
                int cols = int.Parse(numericUpDownVars.Value.ToString());
                int rows = int.Parse(numericUpDownConstraints.Value.ToString());
                dataGridView1.Columns.Add("x", "Objective func");
                for (int i = 0; i < cols + 2; i++)
                {
                    if (i < cols)
                    {
                        dataGridView1.Columns.Add("x" + (i + 1), "   x" + (i + 1));
                    }
                    else dataGridView1.Columns.Add("x" + (i + 1), " ");
                }

                for (int i = 0; i < rows + 3; i++)
                {
                    if (i <= 2)
                        dataGridView1.Rows.Add(" ");
                    else dataGridView1.Rows.Add("Constraint " + (i - 2));
                }

                dataGridView1.Rows[2].Cells[0].Value = "Constraints";
                for (int i = 0; i < cols; i++)
                {
                    dataGridView1.Rows[2].Cells[i + 1].Value = "x" + (i + 1);
                }
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Rows[1].ReadOnly = true;
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.Rows[2].Cells[cols + 1].Value = "Sign";
                dataGridView1.Rows[2].Cells[cols + 2].Value = "λ";
                dataGridView1.Rows[2].ReadOnly = true;
                dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Orange;
                foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            string text = "By Le Trong Hieu - 15TCLC2 - Da Nang University of Technology";
            MessageBox.Show(text, "About");
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int cols = int.Parse(numericUpDownVars.Value.ToString());
                int rows = int.Parse(numericUpDownConstraints.Value.ToString());

                List<string> myList = new List<string>();
                int countLine = rows + 3;

                string line3 = "";
                for (int i = 0; i < cols; i++)
                {
                    line3 += dataGridView1.Rows[0].Cells[i + 1].Value.ToString() + " ";
                }
                myList.Add(comboBoxType.SelectedItem.ToString());
                myList.Add(cols.ToString() + " " + rows.ToString());
                myList.Add(line3);

                for (int i = 0; i < rows; i++)
                {
                    string myLine = "";
                    for (int j = 0; j < cols + 2; j++)
                    {
                        myLine += dataGridView1.Rows[i + 3].Cells[j + 1].Value.ToString() + " ";
                    }
                    myList.Add(myLine);
                }

                FileStream fs = File.Create(pathInput);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string s in myList)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
                MessageBox.Show(fs.Name);
                ReadFile(fs.Name);
                ConsoleToTextFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadFile(openFileDialog1.FileName);
                    ConsoleToTextFile();
                    int cols = int.Parse(lines[1].Split(' ')[0]);
                    int rows = int.Parse(lines[1].Split(' ')[1]);
                    numericUpDownVars.Value = cols;
                    numericUpDownConstraints.Value = rows;
                    dataGridView1.Columns.Add("x", "Objective func");

                    //Configure Rows 0
                    for (int i = 0; i < cols + 2; i++)
                    {
                        if (i < cols)
                        {
                            dataGridView1.Columns.Add("x" + (i + 1), "   x" + (i + 1));
                        }
                        else dataGridView1.Columns.Add("x" + (i + 1), " ");
                    }
                    for (int i = 0; i < rows + 3; i++)
                    {
                        if (i <= 2)
                            dataGridView1.Rows.Add(" ");
                        else dataGridView1.Rows.Add("Constraint " + (i - 2));
                    }

                    //Configure Row 1
                    string[] tempLine = lines[2].Split(' ');
                    dataGridView1.Rows[0].Cells[0].Value = (lines[0].ToString().Contains("max") ? "Maximize " : "Minimize ") + "of";
                    for (int i = 0; i < tempLine.Length; i++)
                    {
                        dataGridView1.Rows[0].Cells[i + 1].Value = tempLine[i];
                    }

                    //Configure Rows 3
                    dataGridView1.Rows[2].Cells[0].Value = "Constraints";
                    for (int i = 0; i < cols; i++)
                    {
                        dataGridView1.Rows[2].Cells[i + 1].Value = "x" + (i + 1);
                    }
                    dataGridView1.Rows[2].Cells[cols + 1].Value = "Sign";
                    dataGridView1.Rows[2].Cells[cols + 2].Value = "λ";

                    for (int i = 0; i < rows; i++)
                    {
                        string[] tempCons = lines[i + 3].Split(' ');
                        for (int j = 0; j < cols; j++)
                        {
                            dataGridView1.Rows[i + 3].Cells[j + 1].Value = tempCons[j];
                        }
                        dataGridView1.Rows[i + 3].Cells[cols + 1].Value = tempCons[cols];
                        dataGridView1.Rows[i + 3].Cells[cols + 2].Value = tempCons[cols + 1];
                    }

                    dataGridView1.Rows[1].ReadOnly = true;
                    dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Gray;
                    dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Orange;
                    dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                    foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                    {
                        dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
