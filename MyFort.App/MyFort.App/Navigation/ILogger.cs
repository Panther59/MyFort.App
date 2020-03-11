using System;
using System.Collections.Generic;
using System.Text;

namespace MyFort.App.Navigation
{
	public interface ILogger
	{
		void LogException(Exception ex);
	}
}
