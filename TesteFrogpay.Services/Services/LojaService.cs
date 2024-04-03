using System.Net;
using AutoMapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.DTOs.Loja;

namespace TesteFrogpay.Services.Services;

public class LojaService
{
    private readonly ILojaRepository _lojaRepository;
    private readonly IMapper _mapper;

    public LojaService(IMapper mapper, ILojaRepository lojaRepository)
    {
        _mapper = mapper;
        _lojaRepository = lojaRepository;
    }

    public async Task<ResponseDto<ViewLojaDto>> SelecionarPorId(Guid id)
    {
        var loja = await _lojaRepository.Selecionar(id);
        if (loja == null)
            return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.NotFound,
                "Nenhuma loja encontrada com esse código");
        var dto = _mapper.Map<ViewLojaDto>(loja);
        return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<IEnumerable<ViewLojaDto>>> SelecionarTodos()
    {
        var loja = await _lojaRepository.SelecionarTodos();
        if (loja?.Count() < 1)
            return new ResponseDto<IEnumerable<ViewLojaDto>>((int)HttpStatusCode.NoContent, "Nenhum dado encontrado");
        var dto = _mapper.Map<IEnumerable<ViewLojaDto>>(loja);
        return new ResponseDto<IEnumerable<ViewLojaDto>>((int) HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<ViewLojaDto>> Adicionar(CreateLojaDto dto)
    {
        var loja = _mapper.Map<Loja>(dto);
        var resposta = await _lojaRepository.Adicionar(loja);

        if (resposta != 1)
            return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.InternalServerError,
                "Erro ao criar cadastro");
        else
        {
            var viewLojadto = _mapper.Map<ViewLojaDto>(loja);
            return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.Created, viewLojadto);
        }
    }

    public async Task<ResponseDto<ViewLojaDto>> Atualizar(UpdateLojaDto dto)
    {
        var loja = _mapper.Map<Loja>(dto);
        var resposta = await _lojaRepository.Atualizar(loja);

        if (resposta != 1)
            return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.InternalServerError, "Erro ao atualizar dados");
        else
        {
            var viewLojaDto = _mapper.Map<ViewLojaDto>(loja);
            return new ResponseDto<ViewLojaDto>((int)HttpStatusCode.OK, viewLojaDto);
        }
    }

    public async Task<ResponseDto<bool>> Deletar(Guid id)
    {
        var resultado = await _lojaRepository.Deletar(id);
        if (resultado != 1)
            return new ResponseDto<bool>((int)HttpStatusCode.NotFound, "Não foi possível excluir");

        return new ResponseDto<bool>((int)HttpStatusCode.OK, true);
    }
}