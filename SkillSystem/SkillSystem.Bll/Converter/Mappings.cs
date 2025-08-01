﻿using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Bll.Converter;

public static class Mappings
{
    public static UserGetDto ConvertToUserGetDto(User user)
    {
        return new UserGetDto()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            SkillDtos = user.Skills == null ? new List<SkillGetDto>() : user.Skills.Select(s => ConvertToSkillGetDto(s)).ToList(),
        };
    }

    public static User ConvertToUser(UserCreateDto userCreateDto)
    {
        return new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            Email = userCreateDto.Email,
            Password = userCreateDto.Password,
            UserName = userCreateDto.UserName,
        };
    }
    public static SkillGetDto ConvertToSkillGetDto(Skill skill)
    {
        return new SkillGetDto()
        {
            SkillId = skill.SkillId,
            Type = skill.Type,
            Name = skill.Name,
            Description = skill.Description,
            UserId = skill.UserId,
            Level = (SkillLevelDto)skill.Level
        };
    }

    public static Skill ConvertToSkill(SkillCreateDto skillCreateDto)
    {
        return new Skill()
        {
            Type = skillCreateDto.Type,
            Name = skillCreateDto.Name,
            Description = skillCreateDto.Description,
            Level = (SkillLevel)skillCreateDto.Level,
        };
    }
}

