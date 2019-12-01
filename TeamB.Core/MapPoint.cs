namespace TeamB.Core
{
	public class MapPoint
	{
		public MapPoint(double lat, double lon, string name)
		{
			Lat = lat;
			Lon = lon;
			Name = name;
		}

		public string Name { get; set; }

		public double Lat { get; set; }

		public double Lon { get; set; }

		public override bool Equals(object obj)
		{
			var point = obj as MapPoint;

			if (point == null)
			{
				return false;
			}

			return Lat.CompareTo(point.Lat) == 0 && Lon.CompareTo(point.Lon) == 0;
		}

		public override int GetHashCode()
		{
			return Lat.GetHashCode() + Lon.GetHashCode();
		}
	}
}


