
global using Shared.DDD;
global using Shared.Data;
global using Ordering.Data;
global using Shared.Pagination;
global using Shared.Interceptor;
global using Ordering.Orders.DTOS;
global using Shared.Contracts.CQRS;
global using Ordering.Orders.Events;
global using Ordering.Orders.Models;
global using Ordering.Orders.Exceptions;
global using Ordering.Orders.ValueObjects;
global using Ordering.Orders.Features.GetOrders;
global using Ordering.Orders.Features.DeleteOrder;

global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Logging;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using System.Reflection;

global using Carter;
global using MediatR;
global using Mapster;
global using FluentValidation;