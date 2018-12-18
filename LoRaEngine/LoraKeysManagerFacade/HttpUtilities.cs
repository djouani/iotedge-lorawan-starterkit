﻿//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//
using LoRaWan.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoraKeysManagerFacade
{
    /// <summary>
    /// Http utilities
    /// </summary>
    public static class HttpUtilities
    {
        /// <summary>
        /// Gets requested <see cref="ApiVersion"/> from a <see cref="HttpRequest"/>
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static ApiVersion GetRequestedVersion(this HttpRequest req)
        {
            string versionText = req.Query[ApiVersion.QueryStringParamName];
            if (string.IsNullOrEmpty(versionText))
            {
                if (req.Headers.TryGetValue(ApiVersion.HttpHeaderName, out var headerValues))
                {
                    if (headerValues.Any())
                    {
                        versionText = headerValues.First();
                    }
                }
            }

            if (versionText == null)
                return ApiVersion.DefaultVersion;

            return ApiVersion.Parse(versionText);
        }
    }
}
