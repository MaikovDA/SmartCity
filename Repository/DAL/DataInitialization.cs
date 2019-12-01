using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;
using CsvHelper;
using Repository.Models;
using Repository.Models.Odh;

namespace Repository.DAL
{
    public class DataInitialization : DropCreateDatabaseAlways<DataContext>
    {
	    private string GetFilePath(string fileName)
		    => Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\..\TeamB\App_Data\{fileName}");

	    private CsvReader CreateCsvReader(StreamReader reader)
	    {
			var result = new CsvReader(reader);
			result.Configuration.Delimiter = ",";
			result.Configuration.MissingFieldFound = null;
			result.Configuration.Encoding = Encoding.UTF8;

		    return result;
	    }

	    #region Csv Models.

	    private class CsvNamedRecord
	    {
		    public string Name { get; set; }
	    }

	    private class CsvOdhCatergoryRecord : CsvNamedRecord
	    {
		    public int Priority { get; set; }
	    }

	    private class CsvMachineTypeRecord : CsvNamedRecord
	    {
		    public int FreeSpeed { get; set; }

		    public int WorkSpeed { get; set; }

		    public int GazolineVol { get; set; }

		    public int GazolineConsumption { get; set; }

		    public int? BunkerVol { get; set; }
	    }

	    #endregion

		private IEnumerable<CsvNamedRecord> GetFromCsvNamedRecords(string fileName)
	    {
			var result = new List<CsvNamedRecord>();
			using (var reader = File.OpenText(GetFilePath(fileName)))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<CsvNamedRecord>();
					result.Add(record);
				}
			}

		    return result;
	    }

		protected override void Seed(DataContext context)
		{
			
			foreach (var odhType in GetFromCsvNamedRecords("ODH_TYPE.csv"))
				context.OdhTypes.Add(new OdhType { Name = odhType.Name });

			using (var reader = File.OpenText(GetFilePath("ODH_CATEGORY.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<CsvOdhCatergoryRecord>();
					context.OdhsCategories.Add(new OdhCategory { Name = record.Name, Priority = record.Priority});
				}
			}

			using (var reader = File.OpenText(GetFilePath("BD - MACHINE_TYPE.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<CsvMachineTypeRecord>();
					context.MachineTypes.Add(new MachineType
					{
						Name = record.Name,
						GazolineConsumption = record.GazolineConsumption,
						BunkerVol = record.BunkerVol,
						FreeSpeed = record.FreeSpeed,
						WorkSpeed = record.WorkSpeed,
						GazolineVol = record.GazolineVol
					});
				}
			}

			foreach (var odhType in GetFromCsvNamedRecords("BD - ATTACHMENT.csv"))
				context.Attachments.Add(new Attachment { Name = odhType.Name });

			var gbu1 = new Gbu
			{
				Name = "АвД ВАО",
				Address = "г. Москва, ул. Проспект Мира д.12",
				CleanSquare = 213243.52d,
				Lat = 55.774024d,
				Lon = 37.632722d
			};

			context.Gbus.Add(gbu1);
			context.CleanMethods.Add(new CleanMethod {Name = "Ручной"});
			context.CleanMethods.Add(new CleanMethod { Name = "Механизированный" });
			context.CleanMethods.Add(new CleanMethod { Name = "Комбинированный" });

			context.SaveChanges();
		}
	}
}
