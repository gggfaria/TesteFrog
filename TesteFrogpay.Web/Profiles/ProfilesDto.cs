using AutoMapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Services.DTOs.Pessoa;

namespace TesteFrogpay.Web.Profiles;

public class ProfilesDto : Profile
{
    public ProfilesDto()
    {
        //domain para dto
        CreateMap<Pessoa, ViewPessoaDto>();
        
        //dto to doamin
        CreateMap<CreatePessoaDto, Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();

    }
}