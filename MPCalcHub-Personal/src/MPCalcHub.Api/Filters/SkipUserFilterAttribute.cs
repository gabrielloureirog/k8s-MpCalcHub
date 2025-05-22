using Microsoft.AspNetCore.Mvc.Filters;

namespace MPCalcHub.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SkipUserFilterAttribute : Attribute, IFilterMetadata { }
