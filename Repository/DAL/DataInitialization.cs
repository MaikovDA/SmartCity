using System;
using System.Collections.Generic;
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

		private class NamedCsvModel
		{
			public string Name { get; set; }
		}

		private class OdhCatergoryCsvModel : NamedCsvModel
		{
			public int Priority { get; set; }
		}

		private class MachineTypesAttachmentsCsvModel
		{
			public int MachineTypeId { get; set; }

			public int AttachmentId { get; set; }
		}

		private class OdhCsvModel : NamedCsvModel
		{
			public int CategoryId { get; set; }

			public int TypeId { get; set; }

			public int SquareOnMetr { get; set; }
		}

		private class MachineCsvModel
		{
			public int MachineTypeId { get; set; }

			public int InventoryNum { get; set; }

			public string RegNum { get; set; }

			public string BnsoCode { get; set; }
		}

		private class WeatherConditionsCsvModel
		{
			public int? TempMin { get; set; }

			public int? TempMax { get; set; }

			public int? WeatherEvent { get; set; }

			public int? PrecMin { get; set; }

			public int? PrecMax { get; set; }
		}

		private class MachineTypeCsvModel : NamedCsvModel
		{
			public int FreeSpeed { get; set; }

			public int WorkSpeed { get; set; }

			public int GazolineVol { get; set; }

			public int GazolineConsumption { get; set; }

			public int? BunkerVol { get; set; }
		}

		private class WorkTypeCsvModel : NamedCsvModel
		{
			public int? OdhId { get; set; }

			public int? SeasonCode { get; set; }

			public int CleanMethodId { get; set; }

			public TimeSpan? RegTimeStart { get; set; }

			public TimeSpan? RegTimeEnd { get; set; }

			public int? WeatherConditionId { get; set; }

			public int? Weigth { get; set; }

			public int DayOperationCount { get; set; }

			public int? AttachmentId { get; set; }

			public int CheckTypeId { get; set; }

			public int? MachineTypeId { get; set; }
		}

		#endregion

		private IEnumerable<NamedCsvModel> GetFromCsvNamedRecords(string fileName)
		{
			var result = new List<NamedCsvModel>();
			using (var reader = File.OpenText(GetFilePath(fileName)))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<NamedCsvModel>();
					result.Add(record);
				}
			}

			return result;
		}

		protected override void Seed(DataContext context)
		{
			foreach (var checkType in GetFromCsvNamedRecords("CHECK_TYPE.csv"))
				context.CheckTypes.Add(new CheckType { Name = checkType.Name });

			foreach (var odhType in GetFromCsvNamedRecords("ODH_TYPE.csv"))
				context.OdhTypes.Add(new OdhType { Name = odhType.Name });

			using (var reader = File.OpenText(GetFilePath("ODH_CATEGORY.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<OdhCatergoryCsvModel>();
					context.OdhsCategories.Add(new OdhCategory { Name = record.Name, Priority = record.Priority });
				}
			}

			context.SaveChanges();

			using (var reader = File.OpenText(GetFilePath("ODH.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<OdhCsvModel>();
					context.Odhs.Add(new Odh
					{
						CategoryId = record.CategoryId,
						TypeId = record.TypeId,
						Name = record.Name,
						SquareOnMetr = record.SquareOnMetr
					});
				}
			}

			using (var reader = File.OpenText(GetFilePath("MACHINE_TYPE.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<MachineTypeCsvModel>();
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
			context.SaveChanges(); 

			using (var reader = File.OpenText(GetFilePath("MACHINE.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<MachineCsvModel>();
					context.Machines.Add(new Machine()
					{
						RegNum = record.RegNum,
						MachineTypeId = record.MachineTypeId,
						BnsoCode = record.BnsoCode,
						InventoryNum = record.InventoryNum
					});
				}
			}

			using (var reader = File.OpenText(GetFilePath("WEATHER_CONDITION.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<WeatherConditionsCsvModel>();
					context.WeatherConditions.Add(new WeatherCondition
					{
						TempMin = record.TempMin,
						TempMax = record.TempMax,
						WeatherEvent = (WeatherEvent?)record.WeatherEvent,
						PrecMin = record.PrecMin,
						PrecMax = record.PrecMax
					});
				}
			}

			context.SaveChanges();

			foreach (var odhType in GetFromCsvNamedRecords("ATTACHMENT.csv"))
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
			context.CleanMethods.Add(new CleanMethod { Name = "Механизированный" });
			context.CleanMethods.Add(new CleanMethod { Name = "Ручной" });
			context.CleanMethods.Add(new CleanMethod { Name = "Комбинированный" });

			context.Employees.Add(new Employee { Code = 100, Fio = "Иванов Иван Иванович", Gbu = gbu1 });
			context.Employees.Add(new Employee { Code = 101, Fio = "Петров Иван Иванович", Gbu = gbu1 });
			context.Employees.Add(new Employee { Code = 102, Fio = "Сидоров Иван Иванович", Gbu = gbu1 });

			context.SaveChanges();

			using (var reader = File.OpenText(GetFilePath("WORK_TYPE.csv")))
			{
				var csv = CreateCsvReader(reader);
				while (csv.Read())
				{
					var record = csv.GetRecord<WorkTypeCsvModel>();
					var workType = new WorkType
					{
						CleanMethodId = record.CleanMethodId,
						OdhId = record.OdhId,
						DayOperationCount = record.DayOperationCount,
						RegTimeEnd = record.RegTimeEnd,
						RegTimeStart = record.RegTimeStart,
						Name = record.Name,
						WeatherConditionId = record.WeatherConditionId,
						Weigth = record.Weigth,
						SeasonCode = (Season?) record.SeasonCode,
						CheckTypeId = record.CheckTypeId
					};

					if(record.AttachmentId.HasValue)
						workType.Attachments = new List<Attachment>(context.Attachments.Where(e=>e.Id == record.AttachmentId.Value));

					if (record.MachineTypeId.HasValue)
						workType.MachineTypes = new List<MachineType>(context.MachineTypes.Where(e => e.Id == record.MachineTypeId.Value));

					context.WorkTypes.Add(workType);
				}
			}

			context.SaveChanges();

			var results = new List<MachineTypesAttachmentsCsvModel>();
			using (var reader = File.OpenText(GetFilePath("MACHINE_TYPE_ATTACHMENT.csv")))
			{
				var csv = CreateCsvReader(reader);
				
				while (csv.Read())
				{
					results.Add(csv.GetRecord<MachineTypesAttachmentsCsvModel>());
				}
			}

			foreach (var machineTypeId in results.Select(e=>e.MachineTypeId).Distinct())
			{
				var mt = context.MachineTypes.Single(e=>e.Id == machineTypeId);
				var attIds = results.Where(e => e.MachineTypeId == machineTypeId).Select(e => e.AttachmentId);
				mt.Attachments = new List<Attachment>(context.Attachments.Where(d => attIds.Contains(d.Id)));
				context.SaveChanges();
			}
		}
	}
}
