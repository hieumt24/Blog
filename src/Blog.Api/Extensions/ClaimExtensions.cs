using System.ComponentModel;
using System.Reflection;
using System.Security.Claims;
using Blog.Core.Domain.Identity;
using Blog.Core.Models.System;
using Microsoft.AspNetCore.Identity;

namespace Blog.Api.Extensions;

public static class ClaimExtensions
{
    public static void GetPermisions(this List<RoleClaimsDto> allPermissions, Type policy)
    {
        FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
        foreach (var field in fields)
        {
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            string displayName = field.GetValue(null).ToString();
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attribute.Length > 0)
            {
                var description = (DescriptionAttribute)attributes[0];
                displayName = description.Description;
            }
            allPermissions.Add(new RoleClaimsDto{Value = field.GetValue(null).ToString(), Type = "Permission", DisplayName = displayName});
        }
    }
    
    public static async Task AddPermissionClaim(this RoleManager<AppRole> roleManager, AppRole role, string permission)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        if(!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
        {
            await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
        }
    }
   
}