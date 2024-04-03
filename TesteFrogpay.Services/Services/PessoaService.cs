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

        if (resposta != 1)
            return new ResponseDto<ViewPessoaDto>((int)HttpStatusCode.InternalServerError, "Erro ao criar novo usuário");
        else
        {
            var viewPessoa = _mapper.Map<ViewPessoaDto>(pessoa);
            return new ResponseDto<ViewPessoaDto>((int) HttpStatusCode.Created, viewPessoa);
        }
    }
    
    public async Task<ResponseDto<ViewPessoaDto>> Atualizar(UpdatePessoaDto dto)
    {
        var pessoa = _mapper.Map<Pessoa>(dto);
        var resposta = await _pessoaRepository.Atualizar(pessoa);

        if (resposta != 1)
            return new ResponseDto<ViewPessoaDto>((int)HttpStatusCode.InternalServerError, "Erro ao atualizar usuário");
        else
        {
            var viewPessoa = _mapper.Map<ViewPessoaDto>(pessoa);
            return new ResponseDto<ViewPessoaDto>((int) HttpStatusCode.OK, viewPessoa);
        }
    }
    
    public async Task<ResponseDto<bool>> Deletar(Guid id)
    {
        var resultado = await _pessoaRepository.Deletar(id);
        if (resultado != 1)
            return new ResponseDto<bool>((int)HttpStatusCode.NotFound, "Não foi possível excluir por esse código");
        
        return new ResponseDto<bool>((int)HttpStatusCode.OK, true);
    }
}