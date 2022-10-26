using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Dtos.Character;
using RPG.Dtos.Weapon;

namespace RPG.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}