using System.Net;
using AutoMapper;
using TesteFrogpay.Domain;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.DTOs.DadosBancarios;


namespace TesteFrogpay.Services.Services;

public class DadosBancariosService
{
    private readonly IDadosBancariosRespository _dadosBancariosRepository;
    private readonly IMapper _mapper;

    public DadosBancariosService(IMapper mapper, IDadosBancariosRespository dadosBancariosRepository)
    {
        _mapper = mapper;
        _dadosBancariosRepository = dadosBancariosRepository;
    }

    public async Task<ResponseDto<ViewDadosBancariosDto>> SelecionarPorId(Guid id)
    {
        var dadosBancarios = await _dadosBancariosRepository.Selecionar(id);
        if (dadosBancarios == null)
            return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.NotFound,
                "Nenhum dado encontrado com esse código");
        var dto = _mapper.Map<ViewDadosBancariosDto>(dadosBancarios);
        return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<IEnumerable<ViewDadosBancariosDto>>> SelecionarTodos()
    {
        var dadosBancarios = await _dadosBancariosRepository.SelecionarTodos();
        if (dadosBancarios?.Count() < 1)
            return new ResponseDto<IEnumerable<ViewDadosBancariosDto>>((int)HttpStatusCode.NoContent,
                "Nenhum dado encontrado");

        var dto = _mapper.Map<IEnumerable<ViewDadosBancariosDto>>(dadosBancarios);
        return new ResponseDto<IEnumerable<ViewDadosBancariosDto>>((int)HttpStatusCode.OK, dto);
    }

    public async Task<ResponseDto<ViewDadosBancariosDto>> Adicionar(CreateDadosBancariosDto dto)
    {
        var dadosBancarios = _mapper.Map<DadosBancarios>(dto);
        var resposta = await _dadosBancariosRepository.Adicionar(dadosBancarios);

        if (resposta != 1)
            return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.InternalServerError,
                "Erro ao criar cadastro");

        var viewDadosBancarios = _mapper.Map<ViewDadosBancariosDto>(dadosBancarios);
        return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.Created, viewDadosBancarios);
    }

    public async Task<ResponseDto<ViewDadosBancariosDto>> Atualizar(UpdateDadosBancariosDto dto)
    {
        var dadosBancarios = _mapper.Map<DadosBancarios>(dto);
        var resposta = await _dadosBancariosRepository.Atualizar(dadosBancarios);

        if (resposta != 1)
            return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.InternalServerError, "Erro ao atualizar dados");

        var viewDadosBancarios = _mapper.Map<ViewDadosBancariosDto>(dadosBancarios);
        return new ResponseDto<ViewDadosBancariosDto>((int)HttpStatusCode.OK, viewDadosBancarios);
    }

    public async Task<ResponseDto<bool>> Deletar(Guid id)
    {
        var resultado = await _dadosBancariosRepository.Deletar(id);
        if (resultado != 1)
            return new ResponseDto<bool>((int)HttpStatusCode.NotFound, "Não foi possível excluir");

        return new ResponseDto<bool>((int)HttpStatusCode.OK, true);
    }
}