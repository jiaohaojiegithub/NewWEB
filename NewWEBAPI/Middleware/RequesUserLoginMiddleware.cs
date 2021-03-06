﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace NewWEBAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequesUserLoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApiAuthorizedOptions _options;
        public RequesUserLoginMiddleware(RequestDelegate next, IOptions<ApiAuthorizedOptions> options)
        {
            _next = next;
            _options = options.Value;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            switch (httpContext.Request.Method.ToUpper())
            {
                case "POST":
                    if (httpContext.Request.HasFormContentType)
                    {
                        await PostInvoke(httpContext);
                    }
                    else
                    {
                        await ReturnNoAuthorized(httpContext);
                    }
                    break;
                case "GET":
                    await GetInvoke(httpContext);
                    break;
                default:
                    await GetInvoke(httpContext);
                    break;
            }
            await _next.Invoke(httpContext);
        }
        #region private method
        /// <summary>
        /// not authorized request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task ReturnNoAuthorized(HttpContext context)
        {
            BaseResponseResult response = new BaseResponseResult
            {
                Code = "401",
                Message = "You are not authorized!"
            };
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        /// <summary>
        /// timeout request 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task ReturnTimeOut(HttpContext context)
        {
            BaseResponseResult response = new BaseResponseResult
            {
                Code = "408",
                Message = "Time Out!"
            };
            context.Response.StatusCode = 408;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        /// <summary>
        /// check the application
        /// </summary>
        /// <param name="context"></param>
        /// <param name="applicationId"></param>
        /// <param name="applicationPassword"></param>
        /// <returns></returns>
        private async Task CheckApplication(HttpContext context, string applicationId, string applicationPassword)
        {
            var application = GetAllApplications().Where(x => x.ApplicationId == applicationId).FirstOrDefault();
            if (application != null)
            {
                if (application.ApplicationPassword != applicationPassword)
                {
                    await ReturnNoAuthorized(context);
                }
            }
            else
            {
                await ReturnNoAuthorized(context);
            }
        }
        /// <summary>
        /// check the expired time
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="expiredSecond"></param>
        /// <returns></returns>
        private bool CheckExpiredTime(double timestamp, double expiredSecond)
        {
            double now_timestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return (now_timestamp - timestamp) > expiredSecond;
        }
        /// <summary>
        /// http get invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task GetInvoke(HttpContext context)
        {
            var queryStrings = context.Request.Query;
            RequestInfo requestInfo = new RequestInfo
            {
                ApplicationId = queryStrings["applicationId"].ToString(),
                ApplicationPassword = queryStrings["applicationPassword"].ToString(),
                Timestamp = queryStrings["timestamp"].ToString(),
                Nonce = queryStrings["nonce"].ToString(),
                Sinature = queryStrings["signature"].ToString()
            };
            await Check(context, requestInfo);
        }
        /// <summary>
        /// http post invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task PostInvoke(HttpContext context)
        {
            var formCollection = context.Request.Form;
            RequestInfo requestInfo = new RequestInfo
            {
                ApplicationId = formCollection["applicationId"].ToString(),
                ApplicationPassword = formCollection["applicationPassword"].ToString(),
                Timestamp = formCollection["timestamp"].ToString(),
                Nonce = formCollection["nonce"].ToString(),
                Sinature = formCollection["signature"].ToString()
            };
            await Check(context, requestInfo);
        }
        /// <summary>
        /// the main check method
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestInfo"></param>
        /// <returns></returns>
        private async Task Check(HttpContext context, RequestInfo requestInfo)
        {
            string computeSinature = HMACMD5Helper.GetEncryptResult($"{requestInfo.ApplicationId}-{requestInfo.Timestamp}-{requestInfo.Nonce}", _options.EncryptKey);
            double tmpTimestamp;
            if (computeSinature.Equals(requestInfo.Sinature) &&
                double.TryParse(requestInfo.Timestamp, out tmpTimestamp))
            {
                if (CheckExpiredTime(tmpTimestamp, _options.ExpiredSecond))
                {
                    await ReturnTimeOut(context);
                }
                else
                {
                    await CheckApplication(context, requestInfo.ApplicationId, requestInfo.ApplicationPassword);
                }
            }
            else
            {
                await ReturnNoAuthorized(context);
            }
        }
        /// <summary>
        /// return the application infomations
        /// </summary>
        /// <returns></returns>
        private IList<ApplicationInfo> GetAllApplications()
        {
            return new List<ApplicationInfo>()
            {
                new ApplicationInfo { ApplicationId="1", ApplicationName="Member", ApplicationPassword ="123"},
                new ApplicationInfo { ApplicationId="2", ApplicationName="Order", ApplicationPassword ="123"}
            };
        }
        #endregion
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequesUserLoginMiddlewareExtensions
    {
        //public static IApplicationBuilder UseRequesUserLoginMiddleware(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<RequesUserLoginMiddleware>();
        //}
        public static IApplicationBuilder UseApiAuthorized(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseMiddleware<RequesUserLoginMiddleware>();
        }

        public static IApplicationBuilder UseApiAuthorized(this IApplicationBuilder builder, ApiAuthorizedOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return builder.UseMiddleware<RequesUserLoginMiddleware>(Options.Create(options));
        }
    }
}
