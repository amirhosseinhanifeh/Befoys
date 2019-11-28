using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;

namespace BEFOYS.Common.Utilities
{
    public class SmsPortal
    {
        public static async Task<bool> SendSmsAsync(string sender = "10008445", string reciver = null, string message = "")
        {
            try
            {
                //KavenegarApi api = new Kavenegar.KavenegarApi("6b78484e4a46694f4334594d6e34306d58304b446e636e2f2f5272634b50744e");
                //var result =await api.Send(sender, reciver, message);
                using (WebClient webClient = new WebClient())
                {
                    Uri url = new Uri($"https://api.kavenegar.com/v1/6B78484E4A46694F4334594D6E34306D58304B446E636E2F2F5272634B50744E/verify/lookup.json?receptor={reciver}&token={message}&template=Verification");
                    await webClient.DownloadStringTaskAsync(url);
                    return true;
                }
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.Write("Message : " + ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.Write("Message : " + ex.Message);
            }
            return false;
        }
    }
}
