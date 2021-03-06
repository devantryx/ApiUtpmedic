﻿using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Mapper
{
    //AutoMapper permite vincular DTO con mi objeto
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Cita, CitaDto>().ReverseMap();

            CreateMap<Clinica, ClinicaDto>().ReverseMap();

            CreateMap<Especialidad, EspecialidadDto>().ReverseMap();

            CreateMap<Medico, MedicoDto>().ReverseMap();

            //CreateMap<Paciente, PacienteDto>().ReverseMap();

            CreateMap<Paciente, PacienteUsuarioDto>().ReverseMap();

            CreateMap<Paciente, PacientePersonaDto>().ReverseMap();

            CreateMap<Paciente, PersonaUsuarioDto>().ReverseMap();

            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();

            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();

            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Publicacion, PublicacionDto>().ReverseMap();

            CreateMap<Persona, PersonaDto>().ReverseMap();

            CreateMap<Medicamento, MedicamentoDto>().ReverseMap();

            CreateMap<Horario, HorarioDto>().ReverseMap();

            

            

        }
    }
}
