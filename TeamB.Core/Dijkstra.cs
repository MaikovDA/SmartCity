﻿using System.Collections.Generic;
using System.Linq;

namespace TeamB.Core
{
	/// <summary>
	/// Алгоритм Дейкстры
	/// </summary>
	public class Dijkstra
	{
		readonly Graph graph;

		List<GraphVertexInfo> _infos;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="graph">Граф</param>
		public Dijkstra(Graph graph)
		{
			this.graph = graph;
		}

		/// <summary>
		/// Инициализация информации
		/// </summary>
		void InitInfo()
		{
			_infos = new List<GraphVertexInfo>();
			foreach (var v in graph.VertexList)
			{
				_infos.Add(new GraphVertexInfo(v));
			}
		}

		/// <summary>
		/// Получение информации о вершине графа
		/// </summary>
		/// <param name="v">Вершина</param>
		/// <returns>Информация о вершине</returns>
		GraphVertexInfo GetVertexInfo(GraphVertex v)
		{
			return _infos.FirstOrDefault(i => i.Vertex.Equals(v));
		}

		/// <summary>
		/// Поиск непосещенной вершины с минимальным значением суммы
		/// </summary>
		/// <returns>Информация о вершине</returns>
		public GraphVertexInfo FindUnvisitedVertexWithMinSum()
		{
			var minValue = int.MaxValue;
			GraphVertexInfo minVertexInfo = null;
			foreach (var i in _infos)
			{
				if (i.IsUnvisited && i.EdgesWeightSum < minValue)
				{
					minVertexInfo = i;
					minValue = i.EdgesWeightSum;
				}
			}

			return minVertexInfo;
		}

		/// <summary>
		/// Поиск кратчайшего пути по названиям вершин
		/// </summary>
		/// <param name="startName">Название стартовой вершины</param>
		/// <param name="finishName">Название финишной вершины</param>
		/// <returns>Кратчайший путь</returns>
		public string FindShortestPath(string startName, string finishName)
		{
			return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
		}

		/// <summary>
		/// Поиск кратчайшего пути по вершинам
		/// </summary>
		/// <param name="startVertex">Стартовая вершина</param>
		/// <param name="finishVertex">Финишная вершина</param>
		/// <returns>Кратчайший путь</returns>
		public string FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
		{
			InitInfo();
			var first = GetVertexInfo(startVertex);
			first.EdgesWeightSum = 0;
			while (true)
			{
				var current = FindUnvisitedVertexWithMinSum();
				if (current == null)
				{
					break;
				}

				SetSumToNextVertex(current);
			}

			return GetPath(startVertex, finishVertex);
		}

		/// <summary>
		/// Поиск кратчайшего пути по вершинам
		/// </summary>
		/// <param name="startVertex">Стартовая вершина</param>
		/// <param name="finishVertex">Финишная вершина</param>
		/// <returns>Кратчайший путь</returns>
		public List<MapPoint> FindShortestPointListPath(GraphVertex startVertex, GraphVertex finishVertex)
		{
			InitInfo();
			var first = GetVertexInfo(startVertex);
			first.EdgesWeightSum = 0;
			while (true)
			{
				var current = FindUnvisitedVertexWithMinSum();
				if (current == null)
				{
					break;
				}

				SetSumToNextVertex(current);
			}

			return GetPointListPath(startVertex, finishVertex);
		}
		/// <summary>
		/// Вычисление суммы весов ребер для следующей вершины
		/// </summary>
		/// <param name="info">Информация о текущей вершине</param>
		void SetSumToNextVertex(GraphVertexInfo info)
		{
			info.IsUnvisited = false;
			foreach (var e in info.Vertex.Edges)
			{
				var nextInfo = GetVertexInfo(e.ConnectedVertex);
				var sum = info.EdgesWeightSum + e.EdgeWeight;
				if (sum < nextInfo.EdgesWeightSum)
				{
					nextInfo.EdgesWeightSum = sum;
					nextInfo.PreviousVertex = info.Vertex;
				}
			}
		}

		/// <summary>
		/// Формирование пути
		/// </summary>
		/// <param name="startVertex">Начальная вершина</param>
		/// <param name="endVertex">Конечная вершина</param>
		/// <returns>Путь</returns>
		string GetPath(GraphVertex startVertex, GraphVertex endVertex)
		{
			var path = endVertex.ToString();
			while (startVertex != endVertex)
			{
				endVertex = GetVertexInfo(endVertex).PreviousVertex;
				path = endVertex + path;
			}

			return path;
		}

		List<MapPoint> GetPointListPath(GraphVertex startVertex, GraphVertex endVertex)
		{
			var restlt = new List<MapPoint> {endVertex.Point};
			// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
			while (startVertex != endVertex)
			{
				endVertex = GetVertexInfo(endVertex).PreviousVertex;
				restlt.Add(endVertex.Point);
			}

			return restlt;
		}
	}
}
