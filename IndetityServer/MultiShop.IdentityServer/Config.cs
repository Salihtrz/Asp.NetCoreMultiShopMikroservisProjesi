// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImage"){Scopes={"ImageFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            // Bu sayede Token değerini aldığımız kullanıcının hangi bilgilerine erişim sağlayacağını yazdık
            new IdentityResources.OpenId(), // Herkese açık olan id'ye erişim sağlayacak
            new IdentityResources.Email(), // Herkese açık olan email'e erişim sağlayacak
            new IdentityResources.Profile() // Herkese açık olan profil'e erişim sağlayacak
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            // Token'ı alan kişi CatalogFullPermission yetkisine sahip ise o yetkiye sahip olan kişinin yapabileceği işlemler
            // new ApiScope("Sahip olunan yetki","Bu yetkinin yapabildiği")
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("CommentFullPermission","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client()
            {
                ClientId = "MultiShopVisitorID",
                ClientName = "MultiShopVisitorUser",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha512())},
                AllowedScopes = {
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "ImageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName
                },
                AllowAccessTokensViaBrowser = true
            },

            // Manager
            new Client()
            {
                ClientId = "MultiShopManagerID",
                ClientName = "MultiShopManagerUser",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha512()) },
                AllowedScopes = {
                    "CatalogFullPermission",
                    "CatalogReadPermission",
                    "BasketFullPermission",
                    "OrderFullPermission",
                    "DiscountFullPermission",
                    "MessageFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "ImageFullPermission",
                    "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                }
            },

            // Admin
            new Client()
            {
                ClientId = "MultiShopAdminID",
                ClientName = "MultiShopAdminUser",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha512()) },
                AllowedScopes = {
                    "CatalogFullPermission",
                    "CatalogReadPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "MessageFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "ImageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600
            }
        };
    }
}