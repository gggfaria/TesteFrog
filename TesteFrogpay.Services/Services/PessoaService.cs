using System.Net;
using AutoMapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.DTOs.Pessoa;

namespace TesteFrogpay.Services.Services;

public class PessoaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IMapper _mapper;

    public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
    {
        _pessoaRepository = pessoaRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<ViewPessoaDto>> SelecionarPorId(Guid id)
    {
        var pessoa = await _pessoaRepository.Selecionar(id);
        if (pessoa == null)
            return new ResponseDto<ViewPessoaDto>((int)HttpStatusCode.NotFound, "Nenhuma pessoa encontrada com esse código");
        var dto = _mapper.Map<ViewPessoaDto>(pessoa);
        return new ResponseDto<ViewPessoaDto>((int)HttpStatusCode.OK, dto);
    }

    //todo paginacao
    public async Task<IEnumerable<ViewPessoaDto>> SelecionarTodos()
    {
        var pessoas = await _pessoaRepository.SelecionarTodos();
        var dto = _mapper.Map<IEnumerable<ViewPessoaDto>>(pessoas);

        return dto;
    }

    public async Task<ResponseDto<ViewPessoaDto>> Adicionar(CreatePessoaDto dto)
    {
        var pessoa = _mapper.Map<Pessoa>(dto);
        var resposta = await _pessoaRepository.Adicionar(pessoa);
        var viewPessoa = _mapper.Map<ViewPessoaDto>(pessoa);

        if (resposta != 1)
            return new ResponseDto<ViewPessoaDto>((int)HttpStatusCode.InternalServerError, "Erro ao criar novo usuário");
        else
        {
            return new ResponseDto<ViewPessoaDto>((int) HttpStatusCode.Created, viewPessoa);
        }

    }
}