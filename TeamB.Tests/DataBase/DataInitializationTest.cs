using System;
using System.Data.Entity;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DAL;

namespace TeamB.Tests.DataBase
{
	[TestClass]
	public class DataInitializationTest
	{
		
		[TestInitialize]
		public void TestInitialize()
		{
			var dbFilePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\TeamB\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", dbFilePath);
		}

		/// <summary>
		/// Перед запуском теста необходимо закрыть все подключения к БД.
		/// </summary>
		[TestMethod]
		public void CreateTestDataBase()
		{
			using (var dbContext = new DataContext())
			{
				Database.SetInitializer(new DataInitialization());
				dbContext.Database.Initialize(true);
			}
		}
	}
}
