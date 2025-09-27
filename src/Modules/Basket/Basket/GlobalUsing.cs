
global using Shared.DDD;
global using Basket.Data;
global using Shared.CQRS;
global using Shared.Data;
global using System.Reflection;
global using Shared.Exceptions;
global using Shared.Interceptor;
global using Basket.Basket.Dtos;
global using Basket.Basket.Models;
global using Basket.Basket.Exceptions;
global using Basket.Basket.Features.GetBasket;
global using Basket.Basket.Features.DeleteBasket;
global using Basket.Basket.Features.CreateBasket;
global using Basket.Basket.Features.AddItemIntoBasket;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using Mapster;
global using MediatR;
global using FluentValidation;