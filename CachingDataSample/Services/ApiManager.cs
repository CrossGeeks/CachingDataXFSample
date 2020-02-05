using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CachingDataSample.Models;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace CachingDataSample.Services
{
    public class ApiManager: IApiManager
    {
        const string url = "https://makeup-api.herokuapp.com/api/v1/products.json";

        public ApiManager()
        {
            Barrel.ApplicationId = "CachingDataSample";
        }

        public async Task<IEnumerable<MakeUp>> GetMakeUpsAsync()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Please check your internet connection", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<IEnumerable<MakeUp>>(key: url);
                }

                var client = new HttpClient();
                var json = await client.GetStringAsync(url);
                var makeUps = JsonConvert.DeserializeObject<IEnumerable<MakeUp>>(json);

                //Saves the cache and pass it a timespan for expiration
                Barrel.Current.Add(key: url, data: makeUps, expireIn: TimeSpan.FromDays(1));

                return makeUps;
            }
            catch (Exception ex)
            {
                //Handle exception here
            }
            return null;
        }
    }
}
