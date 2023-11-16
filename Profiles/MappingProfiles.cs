using AutoMapper;
using SportsManagement.DTOs.Requests;
using SportsManagement.DTOs.Responses;
using SportsManagement.Models;

namespace SportsManagement.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePlayerRequestDTO, Player>();
        CreateMap<UpdatePlayerRequestDTO, Player>();

        CreateMap<CreateBranchRequestDTO, Branch>();
        CreateMap<UpdateBranchRequestDTO, Branch>();

        CreateMap<CreateTeamRequestDTO, Team>();
        CreateMap<UpdateTeamRequestDTO, Team>();

        CreateMap<CreateOutfitRequestDTO, Outfit>();
        CreateMap<UpdateOutfitRequestDTO,Outfit>();

        CreateMap<Player, PlayerResponseDTO>();
        CreateMap<Branch, BranchResponseDTO>();
        CreateMap<Team, TeamResponseDTO>();
        CreateMap<Outfit, OutfitResponseDTO>();


    }
}
