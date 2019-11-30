using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Repository.Models;
using Repository.Models.Odh;

namespace Repository.DAL
{
    public class DataInitialization : DropCreateDatabaseAlways<DataContext>
	{
	    private class CsvSimpleRecord
	    {
		    public string Name { get; set; }
	    }

		protected override void Seed(DataContext context)
		{
			var odhTypePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\TeamB\App_Data\ODH_TYPE.csv");
			using (var reader = File.OpenText(odhTypePath))
			{
				var csv = new CsvReader(reader);
				csv.Configuration.Delimiter = ",";
				csv.Configuration.MissingFieldFound = null;
				csv.Configuration.Encoding = Encoding.UTF8;
				while (csv.Read())
				{
					var record = csv.GetRecord<CsvSimpleRecord>();
					context.OdhTypes.Add(new OdhType() {Name = record.Name});
				}
			}

			context.CleanMethods.Add(new CleanMethod() {Name = "Ручной"});
			context.CleanMethods.Add(new CleanMethod() { Name = "Механизированный" });
			
			context.SaveChanges();
		}
	}
}
