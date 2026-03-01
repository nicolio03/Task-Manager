using System;

namespace gradeCheck
{
	public class Semester
	{
		private int year;
		private string season;
		public Semester()
		{
			year = 0;
			season = null;
		}
		public Semester(int year, string season)
		{
			this.year = year;
			this.season = season;
		}
		//getters
		public int getYear() { return year; }
		public string getSeason() { return season; }

		//
	}
}