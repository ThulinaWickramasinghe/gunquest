using AutoMapper;
using RPG.Dtos.Character;
using RPG.Dtos.Fight;
using RPG.Dtos.Skill;
using RPG.Dtos.Weapon;

namespace RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character,HighScoreDto>();
        }
    }
}