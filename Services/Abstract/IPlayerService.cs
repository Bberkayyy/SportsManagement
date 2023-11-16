using SportsManagement.DTOs.Requests;
using SportsManagement.DTOs.Responses;
using SportsManagement.Models;

namespace SportsManagement.Services.Abstract;

public interface IPlayerService
{
    ReturnModel<List<PlayerResponseDTO>> GetList();
    ReturnModel<PlayerResponseDTO> Add(CreatePlayerRequestDTO requestDTO);
    ReturnModel<PlayerResponseDTO> Update(UpdatePlayerRequestDTO requestDTO);
    ReturnModel<PlayerResponseDTO> Delete(int id);
    ReturnModel<PlayerResponseDTO> GetById(int id);
}
