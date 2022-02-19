using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMSystem.Web.Models
{
	
		public class WeatherDataModel
	{
			public string queryCost { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string resolvedAddress { get; set; }
			public string address { get; set; }
			public string timezone { get; set; }
			public string tzoffset { get; set; }
			public Day[] days { get; set; }
			public Stations stations { get; set; }
		}

		public class Stations
		{
			public _72278903192 _72278903192 { get; set; }
			public _72278403184 _72278403184 { get; set; }
			public MADC MADC { get; set; }
			public KSDL KSDL { get; set; }
			public KDVT KDVT { get; set; }
			public _72278023183 _72278023183 { get; set; }
			public KPHX KPHX { get; set; }
		}

		public class _72278903192
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class _72278403184
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class MADC
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class KSDL
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class KDVT
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class _72278023183
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class KPHX
		{
			public string distance { get; set; }
			public string latitude { get; set; }
			public string longitude { get; set; }
			public string useCount { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string quality { get; set; }
			public string contribution { get; set; }
		}

		public class Day
		{
			public string datetime { get; set; }
			public string datetimeEpoch { get; set; }
			public string tempmax { get; set; }
			public string tempmin { get; set; }
			public string temp { get; set; }
			public string feelslikemax { get; set; }
			public string feelslikemin { get; set; }
			public string feelslike { get; set; }
			public string dew { get; set; }
			public string humidity { get; set; }
			public string precip { get; set; }
			public object precipprob { get; set; }
			public string precipcover { get; set; }
			public object preciptype { get; set; }
			public string snow { get; set; }
			public string snowdepth { get; set; }
			public string windgust { get; set; }
			public string windspeed { get; set; }
			public string winddir { get; set; }
			public string pressure { get; set; }
			public string cloudcover { get; set; }
			public string visibility { get; set; }
			public string solarradiation { get; set; }
			public string solarenergy { get; set; }
			public double uvindex { get; set; }
			public string sunrise { get; set; }
			public string sunriseEpoch { get; set; }
			public string sunset { get; set; }
			public string sunsetEpoch { get; set; }
			public string moonphase { get; set; }
			public string conditions { get; set; }
			public string description { get; set; }
			public string icon { get; set; }
			public string[] stations { get; set; }
			public string source { get; set; }
			public Hour[] hours { get; set; }
		}

		public class Hour
		{
			public string datetime { get; set; }
			public string datetimeEpoch { get; set; }
			public string temp { get; set; }
			public string feelslike { get; set; }
			public string humidity { get; set; }
			public string dew { get; set; }
			public string precip { get; set; }
			public object precipprob { get; set; }
			public string snow { get; set; }
			public string snowdepth { get; set; }
			public object preciptype { get; set; }
			public object windgust { get; set; }
			public string windspeed { get; set; }
			public string winddir { get; set; }
			public string pressure { get; set; }
			public string visibility { get; set; }
			public string cloudcover { get; set; }
			public string solarradiation { get; set; }
			public string solarenergy { get; set; }
			public double uvindex { get; set; }
			public string conditions { get; set; }
			public string icon { get; set; }
			public string[] stations { get; set; }
			public string source { get; set; }
		}

	}
