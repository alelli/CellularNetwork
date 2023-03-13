using System;
using System.Collections;
using System.Collections.Generic;

namespace CellularNetwork
{
    public class Vertex : IComparable<Vertex>
    {
        public int Id,
            Degree,
            Color;

        public Vertex()
        {
            Degree = 0;
            Color = 0;
        }

        public int CompareTo(Vertex other)
        {
            return Id.CompareTo(other.Id);
        }

        public class DegreeDescengingComparer : IComparer<Vertex>
        {
            public int Compare(Vertex x, Vertex y)
            {
                return -(x.Degree - y.Degree);
            }
        }

        public class VertexComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var downX = (Vertex)x;
                var downY = (Vertex)y;
                if (downX.Id == downY.Id && downX.Degree == downY.Degree && downX.Color == downY.Color)
                {
                    return 0;
                }
                return -1;
            }
        }
    }
}
