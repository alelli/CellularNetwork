using System.Collections.Generic;

namespace CellularNetwork
{
    public class GraphColoringAlgorithm
    {
        public static List<Vertex> UseAlgorithm(int[,] estimationsMatrix)
        {
            List<Vertex> vertices = VerticesInitialization(estimationsMatrix);
            ColorizeVertices(vertices, estimationsMatrix);
            return vertices;
        }

        private static List<Vertex> VerticesInitialization(int[,] estimationsMatrix)
        {
            int vertexNumber = estimationsMatrix.GetLength(0);
            List<Vertex> vertices = new List<Vertex>();
            
            for (int i = 0; i < vertexNumber; i++)
            {
                vertices.Add(new Vertex() { Id = i, Degree = CountDegree(estimationsMatrix, i) });
            }
            return vertices;
        }

        private static int CountDegree(int[,] estimationsMatrix, int rowNumber)
        {
            int vertexNumber = estimationsMatrix.GetLength(0);
            int degree = 0;
            for (int j = 0; j < vertexNumber && j != rowNumber; j++)
            {
                if (estimationsMatrix[rowNumber, j] == 1)
                    degree++;
            }
            return degree;
        }

        private static void ColorizeVertices(List<Vertex> vertices, int[,] estimationsMatrix)
        {
            vertices.Sort(new Vertex.DegreeDescengingComparer());

            int vertexNumber = vertices.Count;
            int currentColor = 1;
            for (int i = 0; i < vertexNumber; i++)
            {
                if (vertices[i].Color == 0)
                {
                    vertices[i].Color = currentColor;
                    for (int j = i + 1; j < vertexNumber; j++)
                    {
                        if (estimationsMatrix[vertices[i].Id, vertices[j].Id] == 0 && vertices[j].Color == 0)
                            vertices[j].Color = currentColor;
                    }
                    currentColor++;
                }
            }
        }
    }
}
