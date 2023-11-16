using AutoMapper;
using SportsManagement.DTOs.Requests;
using SportsManagement.DTOs.Responses;
using SportsManagement.Models;
using SportsManagement.Repositories.Abstract;
using SportsManagement.Services.Abstract;

namespace SportsManagement.Services.Concrete;

public class PlayerService : IPlayerService
{
    private readonly IPlayerReposiroty _playerRepository;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerReposiroty playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public ReturnModel<PlayerResponseDTO> Add(CreatePlayerRequestDTO requestDTO)
    {

        var player = _mapper.Map<Player>(requestDTO);
        _playerRepository.Add(player);
        PlayerResponseDTO response = _mapper.Map<PlayerResponseDTO>(player);
        return new ReturnModel<PlayerResponseDTO>()
        {
            Data = response,
            Message = "Başarıyla eklendi!",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public ReturnModel<PlayerResponseDTO> Delete(int id)
    {
        try
        {
            var player = _playerRepository.GetById(id);
            _playerRepository.Delete(id);
            var response = _mapper.Map<PlayerResponseDTO>(player);
            return new ReturnModel<PlayerResponseDTO>()
            {
                Data = response,
                Message = $"Id : {id} oyuncu başarıyla silindi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };

        }
        catch (Exception e)
        {

            return new ReturnModel<PlayerResponseDTO>()
            {
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }
    }

    public ReturnModel<PlayerResponseDTO> GetById(int id)
    {
        try
        {
            var player = _playerRepository.GetById(id);
            PlayerResponseDTO response = _mapper.Map<PlayerResponseDTO>(player);
            return new ReturnModel<PlayerResponseDTO>
            {
                Data = response,
                Message = $"Id : {id} oyuncu başarıyla getirildi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception e)
        {

            return new ReturnModel<PlayerResponseDTO>()
            {
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }

    }

    public ReturnModel<List<PlayerResponseDTO>> GetList()
    {
        var playerList = _playerRepository.GetAll();
        List<PlayerResponseDTO> response = _mapper.Map<List<PlayerResponseDTO>>(playerList);
        return new ReturnModel<List<PlayerResponseDTO>>()
        {
            Data = response,
            Message = "Oyuncular listelendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<PlayerResponseDTO> Update(UpdatePlayerRequestDTO requestDTO)
    {
        var player = _mapper.Map<Player>(requestDTO);
        _playerRepository.Update(player);
        PlayerResponseDTO response = _mapper.Map<PlayerResponseDTO>(player);
        return new ReturnModel<PlayerResponseDTO>()
        {
            Data = response,
            Message = "Oyuncu güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
