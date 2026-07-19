using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EndpointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterEndpointsAsync(Assembly assembly)
        {
            var controllers = assembly.GetTypes()
                .Where(x =>
                    typeof(ControllerBase).IsAssignableFrom(x) &&
                    !x.IsAbstract)
                .ToList();

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.IsPublic &&
                                !x.IsDefined(typeof(NonActionAttribute)))
                    .ToList();

                foreach (var action in actions)
                {
                    var authorizeAttribute =
                    action.GetCustomAttribute<AuthorizeAttribute>() ??
                    controller.GetCustomAttribute<AuthorizeAttribute>();

                    if (authorizeAttribute == null)
                        continue;

                    var controllerName = controller.Name.Replace("Controller", "");

                    var actionName = action.Name;

                    var httpMethodAttribute = action.GetCustomAttributes()
                        .OfType<HttpMethodAttribute>()
                        .FirstOrDefault();

                    if (httpMethodAttribute == null)
                        continue;

                    var httpMethod = httpMethodAttribute.HttpMethods.First();

                    var controllerRoute = controller.GetCustomAttribute<RouteAttribute>()?.Template ?? "";

                    var actionRoute = httpMethodAttribute.Template ?? "";

                    var route = $"{controllerRoute}/{actionRoute}"
                        .Replace("[controller]", controllerName)
                        .Trim('/');

                    var code = $"{controllerName}.{actionName}";

                    var existingEndpoint = await _unitOfWork.EndpointRepository.GetAsync(x => x.Code == code);

                    if (existingEndpoint != null)
                        continue;

                    var endpoint = new Endpoint
                    {
                        Code = code,
                        HttpMethod = httpMethod,
                        Route = route,
                        Definition = actionName,
                        Menu = controllerName,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.EndpointRepository.AddAsync(endpoint);
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
