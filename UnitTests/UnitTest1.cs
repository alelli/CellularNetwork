using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CellularNetwork;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerticesSortDescendingDegrees()
        {
            List<Vertex> vertices = new List<Vertex>
            {
                new Vertex() { Id = 0, Degree = 2 },
                new Vertex() { Id = 1, Degree = 2 },
                new Vertex() { Id = 2, Degree = 3 },
                new Vertex() { Id = 3, Degree = 1 },
            };
            List<Vertex> sortedVertices = new List<Vertex>
            {
                new Vertex() { Id = 2, Degree = 3 },
                new Vertex() { Id = 0, Degree = 2 },
                new Vertex() { Id = 1, Degree = 2 },
                new Vertex() { Id = 3, Degree = 1 },
            };

            vertices.Sort(new Vertex.DegreeDescengingComparer());
            var resultVertices = vertices;

            int[] resultIds = new int[vertices.Count];
            int[] sortedIds = new int[vertices.Count];
            for (int i = 0; i < resultVertices.Count; i++)
            {
                resultIds[i] = resultVertices[i].Id;
                sortedIds[i] = sortedVertices[i].Id;
                Console.WriteLine("{0} - {1}", sortedIds[i], resultIds[i]);
            }
            
            var comparer = new Vertex.VertexComparer();
            CollectionAssert.AreEqual(sortedVertices, resultVertices, comparer);
            CollectionAssert.AreEqual(new int[] { 2, 0, 1, 3 }, resultIds);
        }
    }
}
 