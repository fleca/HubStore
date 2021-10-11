using HubStore.Application.Common.Interfaces;
using System;

namespace HubStore.Infrastructure.Services
{
	public class DateTimeService : IDateTime
	{
		public DateTime Now => DateTime.Now;
	}
}
