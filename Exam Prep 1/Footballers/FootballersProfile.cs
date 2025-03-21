﻿namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.DTOs.Import;

    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public class FootballersProfile : Profile
    {
        public FootballersProfile()
        {
            this.CreateMap<ImportFootballerDto, Footballer>();
            this.CreateMap<ImportCoachDto, Coach>()
                .ForSourceMember(s => s.Footballers, opt => opt.DoNotValidate());

        }
    }
}
