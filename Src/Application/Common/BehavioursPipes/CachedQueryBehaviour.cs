using Application.Contracts;
using Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.BehavioursPipes
{
    public class CachedQueryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheQuery, IRequest<TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDistributedCache _cache;

        public CachedQueryBehaviour(IHttpContextAccessor httpContextAccessor, IDistributedCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            var cachedRespone=await _cache.GetAsync(GenerateKey(),cancellationToken);
            if (cachedRespone != null)
            { 
                response=JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedRespone));
            }
            else
            {
                response = await next();
                var serialized=Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await CreateNewCache(request, cancellationToken, serialized);
            }
            return response;
        }
        private Task CreateNewCache(TRequest request,CancellationToken cancellationToken, byte[] serialized)
        {
            return _cache.SetAsync(GenerateKey(),serialized,new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow=TimeToLove(request)
            },cancellationToken);//task
        }

        private static TimeSpan TimeToLove(TRequest request) 
        {
            return new TimeSpan(request.HoursSaveData, 0, 0, 0);
        }

        private string GenerateKey()
        {
            return IDGenerator.GenerateCacheKeyFromRequest(_httpContextAccessor.HttpContext.Request);
        }


    }
}
