
global using Shared.DDD;
global using Shared.CQRS;
global using Shared.Data;
global using Catelog.Data;
global using Shared.Behaviors;
global using Shared.Data.Seed;
global using Shared.Pagination;
global using Catelog.Data.Seed;
global using Shared.Exceptions;
global using Shared.Interceptor;
global using Catelog.Products.DTOS;
global using Catelog.Products.Events;
global using Catelog.Products.Models;
global using Catelog.Products.Exceptions;
global using Catelog.Products.Features.UpdateProduct;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using System.Reflection;

global using Carter;
global using Mapster;
global using MediatR;
global using FluentValidation;