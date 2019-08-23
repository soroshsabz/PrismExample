using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fa-IR");
			PersianCalendar persianCalender = new PersianCalendar();
			Console.WriteLine(DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("fa-IR")));
			Console.WriteLine(PersianDateTime.Now.ToString());
			Console.WriteLine("سلام علیکم");
			Console.ReadKey();
		}
	}
}
