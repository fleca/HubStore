using AutoMapper;
using HubStore.Application.Common.Mappings;
using HubStore.Domain.Entities;
using System.Collections.Generic;

namespace HubStore.Application.Dtos
{
	public class UserDto : BaseDto, IMapFrom<User>
	{
		public string FullName { get; set; }
		public string Email { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<User, UserDto>();
		}
	}
}
