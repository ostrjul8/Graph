using Exsample;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        private int[,] adjacencyMatrix;
        private Dictionary<int, int> colors;
        private int numVertex;
        private int numColors;
        private int SelectedMethod;
        private TextBox messageBox;
        private GraphVisualizer graphVisualizer;

        private void Form1_Resize(object sender, EventArgs e)
        {
            VisualizeGraph();
        }

        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeMatrix(numVertex);
            messageBox = new TextBox();
            comboBoxColoringMethod = new ComboBox();
            this.Text = "Розфарбовування графа";
            this.Resize += new EventHandler(Form1_Resize);
        }

        public void StartColoringProcess()
        {
            adjacencyMatrix = ReadMatrix(numVertex);

            var matrix = adjacencyMatrix;
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

            for (int i = 0; i < numVertex; i++)
            {
                List<int> neighbors = new List<int>();
                for (int j = 0; j < numVertex; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        neighbors.Add(j);
                    }
                }
                adjacencyList[i] = neighbors;
            }

            Graph graph = new Graph(adjacencyList);

            IGraphColoring graphColoring = null;
            int operationsCount = 0;

            switch (SelectedMethod)
            {
                case 0:
                    graphColoring = new GreedyColoring(numColors);
                    break;
                case 1:
                    graphColoring = new MRVColoring(numColors);
                    break;
                case 2:
                    graphColoring = new BacktrackingColoring(numColors);
                    break;
                default:
                    MessageBox.Show("Невірний вибір методу.");
                    return;
            }

            colors = graphColoring.ColorGraph(graph);
            operationsCount = graphColoring.GetOperationsCount();

            if (colors != null)
            {
                messageBox.Text = string.Join(Environment.NewLine, colors.Select(c => $"Вершина {c.Key}: Колір {c.Value}"));
            }
            else
            {
                messageBox.Text = "Неможливо ініціалізувати кольори.";
                //pictureBoxGraph.Image = null;
                //buttonFile.Visible = false;
            }
            MessageBox.Show($"Кількість операцій: {operationsCount}");
        }

        private void VisualizeGraph()
        {
            graphVisualizer = new GraphVisualizer(adjacencyMatrix, colors);
            graphVisualizer.VisualizeGraph(pictureBoxGraph, numVertex);
        }

        private void comboBoxVertix_SelectedIndexChanged(object sender, EventArgs e)
        {
            numVertex = int.Parse(comboBoxVertix.SelectedItem.ToString());
            InitializeMatrix(numVertex);
            buttonFile.Visible = false;
            pictureBoxGraph.Image = null;

            if (numVertex <= 6)
            {
                dataGridView1.Height = 25 * numVertex + 3;
                dataGridView1.Width = 25 * numVertex + 3;
            }
            else
            {
                dataGridView1.Height = 6 * 25 + SystemInformation.HorizontalScrollBarHeight;
                dataGridView1.Width = 6 * 25 + SystemInformation.VerticalScrollBarWidth;

            }
        }

        private void comboBoxColorNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            numColors = int.Parse(comboBoxColorNum.SelectedItem.ToString());
        }

        private void InitializeMatrix(int size)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = size;
            dataGridView1.RowCount = size;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 25;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 25;
            }

        }

        private int[,] ReadMatrix(int size)
        {
            var matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    matrix[i, j] = value != null ? Convert.ToInt32(value) : 0;
                }
            }

            return matrix;
        }

        private void InitializeComboBoxes()
        {
            for (int i = 3; i <= 30; i++)
            {
                comboBoxVertix.Items.Add($"{i}");
                comboBoxColorNum.Items.Add($"{i}");
            }

            comboBoxColoringMethod.Items.Add("Жадібний метод");
            comboBoxColoringMethod.Items.Add("MRV, пошук з поверненням");
            comboBoxColoringMethod.Items.Add("Степенева евристика, пошук з поверненням");

            comboBoxVertix.SelectedIndex = 0;
            comboBoxColorNum.SelectedIndex = 0;
            comboBoxColoringMethod.SelectedIndex = 0;
        }

        private void comboBoxColoringMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem != null)
            {
                SelectedMethod = comboBox.SelectedIndex;
                string selectedMethod = comboBox.SelectedItem.ToString();
            }
            pictureBoxGraph.Image = null;
            buttonFile.Visible = false;
        }

        private void labelNumVertices_Click(object sender, EventArgs e) { }

        private void buttonColorGraph_Click(object sender, EventArgs e)
        {
            if (!IsValidGrid(numVertex))
            {
                MessageBox.Show("Будь ласка, введіть валідну матрицю суміжності.");
                return;
            }

            StartColoringProcess();

            if (colors == null)
            {
                MessageBox.Show("Недостатньо кольорів.");
                pictureBoxGraph.Image = null;
                buttonFile.Visible = false;
                return;
            }

            VisualizeGraph();
            buttonFile.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void generateMatrix_Click(object sender, EventArgs e)
        {
            numVertex = int.Parse(comboBoxVertix.SelectedItem.ToString());
            InitializeMatrix(numVertex);

            var matrix = GenerateMatrix(numVertex);

            for (var i = 0; i < numVertex; i++)
            {
                for (var j = 0; j < numVertex; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            buttonFile.Visible = false;
            pictureBoxGraph.Image = null;
        }

        private static int[,] GenerateMatrix(int size)
        {
            var matrix = new int[size, size];
            var random = new Random();

            for (var i = 0; i < size; i++)
            {
                for (var j = i; j < size; j++)
                {
                    matrix[i, j] = random.Next(0, 2);
                }
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    matrix[i, j] = matrix[j, i];
                }
            }

            return matrix;
        }

        private bool IsValidGrid(int size)
        {
            var isValidMatrix = true;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                    if (cellValue != null && (cellValue.ToString() == "0" || cellValue.ToString() == "1"))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        continue;
                    }

                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    isValidMatrix = false;
                }
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = i + 1; j < size; j++)
                {
                    var cellValue1 = dataGridView1.Rows[i].Cells[j].Value;
                    var cellValue2 = dataGridView1.Rows[j].Cells[i].Value;

                    if (cellValue1 == null || cellValue2 == null || cellValue1.ToString() != cellValue2.ToString())
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Red;
                        isValidMatrix = false;
                    }
                }
            }

            return isValidMatrix;
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (adjacencyMatrix == null || colors == null)
            {
                MessageBox.Show("Graph data is not available.");
                return;
            }
            try
            {
                using (var writer = new StreamWriter(@"D:\yuliia\Курсова ОП 2 сем\ip32_ostrovytska_output.txt"))
                {
                    writer.WriteLine("Матриця суміжності:");
                    for (int i = 0; i < numVertex; i++)
                    {
                        for (int j = 0; j < numVertex; j++)
                        {
                            writer.Write(adjacencyMatrix[i, j] + " ");
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();

                    writer.WriteLine("Кольори вершин:");
                    foreach (var color in colors)
                    {
                        writer.WriteLine($"Вершина {color.Key + 1}: Колір {color.Value}");
                    }
                }

                MessageBox.Show("Дані успішно збережені до файлу.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while saving graph data: {ex.Message}");
            }
        }

        private void buttonClearMatrix_Click(object sender, EventArgs e)
        {
            InitializeMatrix(numVertex);
            pictureBoxGraph.Image = null;
            buttonFile.Visible = false;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxGraph_Click_1(object sender, EventArgs e) { }
    }
}
