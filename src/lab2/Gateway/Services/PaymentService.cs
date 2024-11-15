﻿using Gateway.Models;
using Gateway.ServiceInterfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://payment:8060/")
        };

        public async Task<Payment?> GetPaymentByUidAsync(Guid paymentUid)
        {
            using HttpRequestMessage req = new(HttpMethod.Get, $"api/v1/payments/{paymentUid}");
            using var res = await _httpClient.SendAsync(req);
            var response = await res.Content.ReadFromJsonAsync<Payment>();
            return response;
        }

        public async Task<Payment?> CancelPaymentByUidAsync(Guid paymentUid)
        {
            using HttpRequestMessage req = new(HttpMethod.Delete, $"api/v1/payments/{paymentUid}");
            using var res = await _httpClient.SendAsync(req);
            var response = await res.Content.ReadFromJsonAsync<Payment>();
            return response;
        }

        public async Task<Payment?> CreatePaymentAsync(Payment request)
        {
            using HttpRequestMessage req = new(HttpMethod.Post, "api/v1/payments");
            req.Content = JsonContent.Create(request, typeof(Payment));
            using var res = await _httpClient.SendAsync(req);
            var response = await res.Content.ReadFromJsonAsync<Payment>();
            return response;
        }
    }
}
