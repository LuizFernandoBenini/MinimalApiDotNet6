using AutoMapper;
using MinimalApiStudy.Dtos;
using MinimalApiStudy.Models;

namespace MinimalApiStudy.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}