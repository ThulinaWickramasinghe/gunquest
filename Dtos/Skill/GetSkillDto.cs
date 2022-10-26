using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Dtos.Skill
{
    public class GetSkillDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
}