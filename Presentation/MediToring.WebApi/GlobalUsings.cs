global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Reflection;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.OpenApi.Models;
global using Microsoft.IdentityModel.Tokens;
global using AutoMapper;
global using MediatR;
global using MediToring.Domain.Models.Request;
global using MediToring.Domain.Models.Response;
global using MediToring.Application;
global using MediToring.Application.Common.Mappings;
global using MediToring.Application.Common.Exceptions;
global using MediToring.Application.Features.Medications.Commands.CreateMedication;
global using MediToring.Application.Features.Medications.Commands.DeleteMedication;
global using MediToring.Application.Features.Medications.Commands.UpdateMedication;
global using MediToring.Application.Features.Medications.Queries.GetMedicationDetails;
global using MediToring.Application.Features.Medications.Queries.GetMedicationList;
global using MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;
global using MediToring.Application.Features.MedicationSchedules.Commands.DeleteScheduleCommand;
global using MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;
global using MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;
global using MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;
global using MediToring.Application.Features.MedicationSchedules.Queries.Models;
global using MediToring.Application.Features.MedicationSchedules.Commands.Models;
global using MediToring.Application.Features.Profiles.Commands.CreateProfile;
global using MediToring.Infrastructure;
global using MediToring.WebApi;
global using MediToring.WebApi.Filters;
global using MediToring.WebApi.Models.Request.Medications;
global using MediToring.WebApi.Models.Request.MedicationSchedules;