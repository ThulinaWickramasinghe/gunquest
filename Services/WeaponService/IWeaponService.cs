using RPG.Dtos.Character;
using RPG.Dtos.Weapon;

namespace RPG.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}