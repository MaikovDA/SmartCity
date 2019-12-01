using System.Collections.Generic;

namespace TeamB.Core
{
	/// <summary>
	/// Вершина графа
	/// </summary>
	public class GraphVertex
	{
		/// <summary>
		/// Точка вершины.
		/// </summary>
		public MapPoint Point { get; }

		/// <summary>
		/// Список ребер
		/// </summary>
		public List<GraphEdge> Edges { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="mapPoint">точка вершины</param>
		public GraphVertex(MapPoint mapPoint)
		{
			Point = mapPoint;
			Edges = new List<GraphEdge>();
		}

		/// <summary>
		/// Добавить ребро
		/// </summary>
		/// <param name="newEdge">Ребро</param>
		public void AddEdge(GraphEdge newEdge)
		{
			Edges.Add(newEdge);
		}

		/// <summary>
		/// Добавить ребро
		/// </summary>
		/// <param name="vertex">Вершина</param>
		/// <param name="edgeWeight">Вес</param>
		public void AddEdge(GraphVertex vertex, int edgeWeight)
		{
			AddEdge(new GraphEdge(vertex, edgeWeight));
		}

		/// <summary>
		/// Преобразование в строку
		/// </summary>
		/// <returns>Имя вершины</returns>
		public override string ToString() => $"{Point.Lat},{Point.Lon}({Point.Name})";
	}
}
