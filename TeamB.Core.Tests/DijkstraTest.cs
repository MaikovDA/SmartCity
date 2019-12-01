using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamB.Core.Tests
{
	[TestClass]
	public class DijkstraTest
	{
		[TestMethod]
		public void Graf_Dijkstra_Ok()
		{
			var g = new Graph();
			var pointA = new MapPoint(1, 1, "A");
			var pointB = new MapPoint(2, 2, "B");
			var pointC = new MapPoint(3, 3, "C");
			var pointD = new MapPoint(4, 4, "D");
			var pointE = new MapPoint(5, 5, "E");
			var pointF = new MapPoint(6, 6, "F");
			var pointG = new MapPoint(7, 7, "G");
			//добавление вершин
			var vertexA = g.AddVertex(pointA);
			var vertexB = g.AddVertex(pointB);
			var vertexC = g.AddVertex(pointC);
			var vertexD = g.AddVertex(pointD);
			var vertexE = g.AddVertex(pointE);
			var vertexF = g.AddVertex(pointF);
			var vertexG = g.AddVertex(pointG);


			//добавление ребер
			g.AddEdge(pointA, pointB, 22);
			g.AddEdge(pointA, pointC, 33);
			g.AddEdge(pointA, pointD, 61);
			g.AddEdge(pointB, pointC, 47);
			g.AddEdge(pointB, pointE, 93);
			g.AddEdge(pointC, pointD, 11);
			g.AddEdge(pointC, pointE, 79);
			g.AddEdge(pointC, pointF, 63);
			g.AddEdge(pointD, pointF, 41);
			g.AddEdge(pointE, pointF, 17);
			g.AddEdge(pointE, pointG, 58);
			g.AddEdge(pointF, pointG, 84);

			var dijkstra = new Dijkstra(g);
			var path = dijkstra.FindShortestPath(vertexA, vertexG);

			var pointList = dijkstra.FindShortestPointListPath(vertexA, vertexG);
		}
	}
}
