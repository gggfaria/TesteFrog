using AutoMapper;
using TesteFrogpay.Domain;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Services.DTOs.DadosBancarios;
using TesteFrogpay.Services.DTOs.Endereco;
using TesteFrogpay.Services.DTOs.Loja;
using TesteFrogpay.Services.DTOs.Pessoa;

namespace TesteFrogpay.Web.Profiles;

public class ProfilesDto : Profile
{
    public ProfilesDto()
    {
        //domain para dto
        CreateMap<Pessoa, ViewPessoaDto>();
        CreateMap<Loja, ViewLojaDto>();
        CreateMap<Endereco, ViewEnderecoDto>();
        CreateMap<DadosBancarios, ViewDadosBancariosDto>();

        //dto to doamin
        CreateMap<CreatePessoaDto, Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();
        
        CreateMap<UpdateLojaDto, Loja>();
        CreateMap<CreateLojaDto, Loja>();
        
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        
        CreateMap<CreateDadosBancariosDto, DadosBancarios>();
        CreateMap<UpdateDadosBancariosDto, DadosBancarios>();

    }
}