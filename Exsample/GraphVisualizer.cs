using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Example
{
    public class GraphVisualizer
    {
        private int[,] adjacencyMatrix;
        private Dictionary<int, int> colors;
        private Dictionary<int, Point> vertexPositions;
        private const int vertexRadius = 20;

        public GraphVisualizer(int[,] adjacencyMatrix, Dictionary<int, int> colors)
        {
            this.adjacencyMatrix = adjacencyMatrix;
            this.colors = colors;
            this.vertexPositions = new Dictionary<int, Point>();
        }

        public void VisualizeGraph(PictureBox pictureBoxGraph, int numVertices)
        {
            vertexPositions = new Dictionary<int, Point>();

            Random rand = new Random();
            int padding = vertexRadius * 3;

            if (pictureBoxGraph.Width <= 0 || pictureBoxGraph.Height <= 0)
            {
                Console.WriteLine("Invalid pictureBoxGraph dimensions.");
                return;
            }

            pictureBoxGraph.Image = new Bitmap(pictureBoxGraph.Width, pictureBoxGraph.Height);
            Graphics g = Graphics.FromImage(pictureBoxGraph.Image);

            for (int i = 0; i < numVertices; i++)
            {
                Point position;
                do
                {
                    position = new Point(rand.Next(padding, pictureBoxGraph.Width - padding), rand.Next(padding, pictureBoxGraph.Height - padding));
                } while (vertexPositions.Values.Any(p => Distance(p, position) < vertexRadius * 3));
                vertexPositions[i] = position;
                Console.WriteLine($"Position of vertex {i + 1}: {position}");
            }

            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (adjacencyMatrix != null && adjacencyMatrix[i, j] == 1)
                    {
                        g.DrawLine(Pens.Black, vertexPositions[i], vertexPositions[j]);
                        Console.WriteLine($"Draw line between {i + 1} and {j + 1}");
                    }
                }
            }

            for (int i = 0; i < numVertices; i++)
            {
                if (colors != null && vertexPositions != null && colors.ContainsKey(i) && vertexPositions.ContainsKey(i))
                {
                    Color color = GetColorByIndex(colors[i]);
                    Brush brush = new SolidBrush(color);
                    Point position = vertexPositions[i];
                    g.FillEllipse(brush, position.X - vertexRadius, position.Y - vertexRadius, vertexRadius * 2, vertexRadius * 2);
                    g.DrawString((i + 1).ToString(), SystemFonts.DefaultFont, Brushes.Black, position);
                    Console.WriteLine($"Draw vertex {i + 1} at {position}");
                }
                else
                {
                    Console.WriteLine($"Cannot draw vertex {i + 1}. Colors or positions are not properly initialized.");
                }
            }

            pictureBoxGraph.Invalidate();

            DrawLoops(pictureBoxGraph, g, numVertices);
        }

        private void DrawLoops(PictureBox pictureBoxGraph, Graphics g, int numVertices)
        {
            for (int i = 0; i < numVertices; i++)
            {
                if (vertexPositions != null && vertexPositions.ContainsKey(i))
                {
                    if (adjacencyMatrix != null && adjacencyMatrix[i, i] == 1)
                    {
                        Point position = vertexPositions[i];
                        int loopSize = vertexRadius * 2;
                        Pen pen = new Pen(Color.Black, 4);

                        g.DrawEllipse(pen, position.X - loopSize / 2, position.Y - loopSize / 2, loopSize, loopSize);

                        Console.WriteLine($"Draw loop for vertex {i} at {position}");
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot draw loop for vertex {i}. Vertex positions are not properly initialized.");
                }
            }
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private Color GetColorByIndex(int index)
        {
            Color[] colorsArray = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange,
                                    Color.Purple, Color.Pink, Color.Cyan, Color.Magenta, Color.Turquoise,
                                    Color.Lime, Color.Brown, Color.Gray, Color.Gold, Color.Silver,
                                    Color.Black, Color.White, Color.DarkMagenta, Color.DarkCyan, Color.DarkOrange
            };
            return colorsArray[index % colorsArray.Length];
        }
    }
}
