// <copyright file="StartupService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-15</date>

using System.Threading.Tasks;

namespace MyFort.App.Services
{
	public interface IStartupService
	{
		Task Initialize();
	}
}