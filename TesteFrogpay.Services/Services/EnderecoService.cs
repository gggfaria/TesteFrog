using System.Net;
using AutoMapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.DTOs.Endereco;

namespace TesteFrogpay.Services.Services;

public class EnderecoService
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly IMapper _mapper;

    public EnderecoService(IMapper mapper, IEnderecoRepository enderecoRepository)
    {
        _mapper = mapper;
        _enderecoRepository = enderecoRepository;
    }

    public async Task<ResponseDto<ViewEnderecoDto>> SelecionarPorId(Guid id)
    {
        var endereco = await _enderecoRepository.Selecionar(id);
        if (endereco == null)
            return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.NotFound,
                "Nenhum dado encontrado com esse código");
        var dto = _mapper.Map<ViewEnderecoDto>(endereco);
        return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<IEnumerable<ViewEnderecoDto>>> SelecionarTodos()
    {
        var endereco = await _enderecoRepository.SelecionarTodos();
        if (endereco?.Count() < 1)
            return new ResponseDto<IEnumerable<ViewEnderecoDto>>((int)HttpStatusCode.NoContent,
                "Nenhum dado encontrado");

        var dto = _mapper.Map<IEnumerable<ViewEnderecoDto>>(endereco);
        return new ResponseDto<IEnumerable<ViewEnderecoDto>>((int)HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<ViewEnderecoDto>> Adicionar(CreateEnderecoDto dto)
    {
        var endereco = _mapper.Map<Endereco>(dto);
        var resposta = await _enderecoRepository.Adicionar(endereco);

        if (resposta != 1)
            return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.InternalServerError,
                "Erro ao criar cadastro");

        var viewEnderecoDto = _mapper.Map<ViewEnderecoDto>(endereco);
        return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.Created, viewEnderecoDto);
    }

    public async Task<ResponseDto<ViewEnderecoDto>> Atualizar(UpdateEnderecoDto dto)
    {
        var endereco = _mapper.Map<Endereco>(dto);
        var resposta = await _enderecoRepository.Atualizar(endereco);

        if (resposta != 1)
            return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.InternalServerError, "Erro ao atualizar dados");

        var viewEnderecoDto = _mapper.Map<ViewEnderecoDto>(endereco);
        return new ResponseDto<ViewEnderecoDto>((int)HttpStatusCode.OK, viewEnderecoDto);
    }

    public async Task<ResponseDto<bool>> Deletar(Guid id)
    {
        var resultado = await _enderecoRepository.Deletar(id);
        if (resultado != 1)
            return new ResponseDto<bool>((int)HttpStatusCode.NotFound, "Não foi possível excluir");

        return new ResponseDto<bool>((int)HttpStatusCode.OK, true);
    }
}