using AutoMapper;
using StackOverflow.DTO;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.AutoMapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, PostUserDTO.Request>().ReverseMap();
        CreateMap<User, PostUserDTO.Response>().ReverseMap();
        CreateMap<Question, QuestionDTO.Request>().ReverseMap();
        CreateMap<Question, QuestionDTO.Response>().ReverseMap();
        CreateMap<Answer, GetAnswerDTO.Request>().ReverseMap();
        CreateMap<Answer, GetAnswerDTO.Response>().ReverseMap();
        CreateMap<AnswerLiker, AnswerLikerDTO.Request>().ReverseMap();
        CreateMap<AnswerLiker, AnswerLikerDTO.Response>().ReverseMap();
    }
}