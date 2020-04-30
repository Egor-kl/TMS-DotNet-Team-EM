using System;
using Xunit;
using ExchangeCurrency.BL;
using System.Net.Http;
using NbrbAPI.Models;

namespace Shop_Simulator_Test
{
    public class ExchangeCurrencyTest
    {
        readonly HttpClient client = new HttpClient();

        [Fact]
        public void GetCurrencyListAsync_WhenSendRequestWithExistingUrl_ReturnTrue()
        {
            // Arrange
            string rootUrl = "https://www.nbrb.by/api/exrates/currencies";
            bool isTrue = false;

            // Act
            HttpResponseMessage response = client.GetAsync(rootUrl).GetAwaiter().GetResult();
            string responseMessage = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (responseMessage != null)
            {
                isTrue = true;
            }

            // Assert
            Assert.True(isTrue);
        }

        [Fact]
        public void GetRateAsync_WhenSendRequestWithNonExistingID_ReturnException()
        {
            // Arrange
            int cur_id = -1;
            string rootUrl = $"https://www.nbrb.by/api/exrates/rates/ {cur_id}";
            bool isException = false;

            // Act
            try
            {
                HttpResponseMessage response = client.GetAsync(rootUrl).GetAwaiter().GetResult();
                string responseMessage = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
            }
            catch(Exception)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        //[Fact]
        //public void SaveData_WhenSaveTheEmptyRateObject_ReturnArgumentNullException()
        //{
        //    // Arrange
        //    var controller = new ExchangeCurrencyController();
        //    Rate rate = null;
        //    bool isException = false;

        //    // Act
        //    try
        //    {
        //        controller.SaveDataAsync(rate);
        //    }
        //    catch(Exception)
        //    {
        //        isException = true;
        //    }

        //    // Assert
        //    Assert.True(isException);
        //}



    }
    
}
