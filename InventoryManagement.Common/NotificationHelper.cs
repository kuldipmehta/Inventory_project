using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entity;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using InventoryManagement.Common;

namespace InventoryManagement.Common
{
    public class NotificationHelper
    {
        private static string FCMSendUrl = "https://fcm.googleapis.com/fcm/send";
        private static string FCMServerKey = "AAAAh_plXU0:APA91bH-FD4YjlyxE4m9YTCS2qtid3E3H7X2yEeOHsmSZfUlwow69yBZDVzUgYj8zoNcWokZ1-7fwyQrwyHA7nyZs9Hd-sbnb2GAOdnkIg0nSXgRe0SU_9fi8jWmTIMespoBGZEElmlG";

        public static NotificationResponse SendNotification(NotificationRequest request, Nullable<short> appId)
        {
            NotificationResponse response = new NotificationResponse();

            using (var client = new WebClient())
            {
                string serverKey = "";
                //InventoryManagement ApplicationID
                serverKey = FCMServerKey;
                client.Headers.Add("Content-Type:application/json");
                string AuthorizationValue = "key=" + serverKey;
                client.Headers.Add("Authorization", AuthorizationValue);
                try
                {
                    var result = client.UploadString(FCMSendUrl, JsonConvert.SerializeObject(request,
                        new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }));
                    response = JsonConvert.DeserializeObject<NotificationResponse>(result);
                    return response;
                }
                catch (WebException ex)
                {
                    var result = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    var webResponse = ex.Response as HttpWebResponse;
                    switch (webResponse.StatusCode)
                    {
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                            CommonHelper.LogError(ex);
                            break;
                        case HttpStatusCode.BadRequest:
                            CommonHelper.LogError(ex);
                            break;
                        case HttpStatusCode.RequestTimeout:
                            CommonHelper.LogError(ex);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    CommonHelper.LogError(ex);
                }
            }
            return response;
        }
    }
}
