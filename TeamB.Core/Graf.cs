using System.Collections.Generic;
using System.Linq;

namespace TeamB.Core
{
	/// <summary>
	/// Граф
	/// </summary>
	public class Graph
	{
		/// <summary>
		/// Список вершин графа
		/// </summary>
		public List<GraphVertex> VertexList { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public Graph()
		{
			VertexList = new List<GraphVertex>();
		}

		/// <summary>
		/// Добавление вершины
		/// </summary>
		/// <param name="mapPoint">Имя вершины</param>
		public GraphVertex AddVertex(MapPoint mapPoint)
		{
			var grafVertex = new GraphVertex(mapPoint);
			VertexList.Add(grafVertex);
			return grafVertex;
		}

		/// <summary>
		/// Поиск вершины по точке
		/// </summary>
		/// <param name="point">Точка вершины</param>
		/// <returns>Найденная вершина</returns>
		public GraphVertex FindVertex(MapPoint point)
		{
			return VertexList.FirstOrDefault(v => v.Point.Equals(point));
		}


		/// <summary>
		/// Поиск вершины по названию точки
		/// </summary>
		/// <param name="pointName">Точка вершины</param>
		/// <returns>Найденная вершина</returns>
		public GraphVertex FindVertex(string pointName)
		{
			return VertexList.FirstOrDefault(v => v.Point.Name == pointName);
		}

		/// <summary>
		/// Добавление ребра
		/// </summary>
		/// <param name="pointA">Точка А начала.</param>
		/// <param name="pointB">Точка B окончания.</param>
		/// <param name="weight">Вес ребра соединяющего вершины</param>
		public void AddEdge(MapPoint pointA, MapPoint pointB, int weight)
		{
			var v1 = FindVertex(pointA);
			var v2 = FindVertex(pointB);
			if (v2 == null || v1 == null) return;

			v1.AddEdge(v2, weight);
			v2.AddEdge(v1, weight);
		}
	}
}
