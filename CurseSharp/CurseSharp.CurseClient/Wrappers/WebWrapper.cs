using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.Models.BotModels;
using CurseSharp.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace CuseSharp
{
    /// <summary>
    /// Convienent wrapper for doing anything web related.
    /// </summary>
    public static class WebWrapper
    {
        static string UserAgentString = $"CurseSharp (https://github.com/TournyMasterBot/CurseSharp, {typeof(CurseSharp.CurseClient.Bot.BotManager).Assembly.GetName().Version.ToString()})";

        /// <summary>
        /// Sends a DELETE HTTP request to the specified URL using the specified token.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string Delete(string url, string token, bool isBotAccount = false)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Headers["AuthenticationToken"] = token;
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "DELETE";
            httpRequest.UserAgent += $" {UserAgentString}";
            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                }
            }
            catch(WebException ex)
            {
                var response = ex.Response as HttpWebResponse;

                bool success = false;
                int currentretry = 0;
                int maxretries = 3;
                if((int)response.StatusCode == 404)
                {
                    while(currentretry < maxretries && !success)
                    {
                        Thread.Sleep(1000);
                        currentretry++;
                        try
                        {
                            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                            using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var result = sr.ReadToEnd();
                                if(!string.IsNullOrEmpty(result))
                                {
                                    return result;
                                }
                            }
                            success = true;
                        }
                        catch(Exception)
                        {
                            success = false;
                        }
                    }
                    if(!success)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Sends a PUT HTTP request to the specified URL using the specified token.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string Put(string url, string token)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Headers["AuthenticationToken"] = token;
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = "PUT";
            httpRequest.UserAgent += $" {UserAgentString}";
            httpRequest.ContentLength = 0;
            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                }
            }
            catch(WebException)
            {
                throw;
            }
            return "";
        }

        /// <summary>
        /// Sends a POST HTTP request to the specified URL, using the specified token, sending the specified message.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Post(string url, AccountModel account, string message = "")
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Headers.Add($"AuthenticationToken: {account.SessionData.Session.Token}");
                httpRequest.ContentLength = message.Length;
                httpRequest.ContentType = "application/json";
                httpRequest.Method = "POST";
                httpRequest.UserAgent += $" {UserAgentString}";

                if(!string.IsNullOrEmpty(message))
                {
#if VERBOSE_LOGGING
                    Log.Verbose($">> {message}");
#endif
                    using(var sw = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        sw.Write(message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                if(httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("401");
                }
                using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(result))
                    {
#if VERBOSE_LOGGING
                        Log.Verbose($"<< {result}");
#endif
                        return result;
                    }
                }
            }
            catch(WebException ex)
            {
                var response = ex.Response as HttpWebResponse;

                if((int)response.StatusCode == 404)
                {
                    bool success = false;
                    int currentretry = 0;
                    int maxretries = 3;
                    while(currentretry < maxretries && !success)
                    {
                        Thread.Sleep(1000);
                        currentretry++;
                        try
                        {
                            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                            httpRequest.Headers.Add($"AuthenticationToken: {account.SessionData.Session.Token}");
                            httpRequest.ContentLength = message.Length;
                            httpRequest.ContentType = "application/json";
                            httpRequest.Method = "POST";
                            httpRequest.UserAgent += $" {UserAgentString}";

                            if(!string.IsNullOrEmpty(message))
                            {
#if VERBOSE_LOGGING
                                Log.Verbose($">> {message}");
#endif
                                using(var sw = new StreamWriter(httpRequest.GetRequestStream()))
                                {
                                    sw.Write(message);
                                    sw.Flush();
                                    sw.Close();
                                }
                            }
                            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                            if(httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                throw new UnauthorizedAccessException("401");
                            }
                            using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var result = sr.ReadToEnd();
                                if(!string.IsNullOrEmpty(result))
                                {
#if VERBOSE_LOGGING
                                    Log.Verbose($"<< {result}");
#endif
                                    return result;
                                }
                            }
                            success = true;
                        }
                        catch(Exception)
                        {
                            success = false;
                        }
                    }
                    if(!success)
                    {
                        Log.Error(ex.ToString());
                    }
                }
                else
                {
                    using(var sr = new StreamReader(response.GetResponseStream()))
                    {
                        var result = sr.ReadToEnd();
                        if(!string.IsNullOrEmpty(result))
                        {
                            throw new InvalidDataException(result);
                        }
                    }

                    if((int)response.StatusCode == 400)
                    {
                    }
                    if((int)response.StatusCode == 401)
                    {
                        // Invalid token was passed.
                        throw;
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            catch(Exception ex)
            {
                Log.Error($"{ex}");
            }
            return "";
        }

        public static string HttpUploadFile(string url, string token, string file, string paramName, string contentType, NameValueCollection nvc, bool isBotAccount = false)
        {
            throw new NotImplementedException();
            /*
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Headers["authenticationtoken"] = isBotAccount ? "Bot " + token : token;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.UserAgent += UserAgentString;
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            System.IO.Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            if(nvc != null)
            {
                foreach(string key in nvc.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            fileStream.CopyTo(rs);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            wresp = wr.GetResponse();
            System.IO.Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            string returnVal = reader2.ReadToEnd();

            reader2.Close();
            stream2.Close();
            fileStream.Close();
            return returnVal;*/
        }

        public static string HttpUploadFile(string url, string token, System.IO.Stream file, string paramName, string contentType, NameValueCollection nvc, bool isBotAccount = false)
        {
            throw new NotImplementedException();
            /*string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Headers["authenticationtoken"] = isBotAccount ? "Bot " + token : token;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.UserAgent += UserAgentString;
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            System.IO.Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            if(nvc != null)
            {
                foreach(string key in nvc.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            file.CopyTo(rs);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            wresp = wr.GetResponse();
            System.IO.Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            string returnVal = reader2.ReadToEnd();

            reader2.Close();
            stream2.Close();
            return returnVal;*/
        }

        /// <summary>
        /// Sends a POST HTTP request to the specified URL, without a token, sending the specified message.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Post(string url, string message)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";
            httpRequest.UserAgent += $" {UserAgentString}";

            using(var sw = new StreamWriter(httpRequest.GetRequestStream()))
            {
#if VERBOSE_LOGGING
                Log.Verbose($">> {message}");
#endif
                sw.Write(message);
                sw.Flush();
                sw.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(result))
                    {
#if VERBOSE_LOGGING
                        Log.Verbose($"<< {result}");
#endif
                        return result;
                    }
                }
            }
            catch(WebException e)
            {
                try
                {
                    using(StreamReader s = new StreamReader(e.Response.GetResponseStream()))
                    {
                        var result = s.ReadToEnd();
                        return result;
                    }
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return "";
        }

        /// <summary>
        /// Sends a GET Request to the specified url using the provided token.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns>The raw string returned. Or, an error.</returns>
        public static string Get(string url, string token)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Headers["authenticationtoken"] = token;
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "GET";
            httpRequest.UserAgent += $" {UserAgentString}";

            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                if(httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("401");
                }
                using(var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(result))
                    {
#if VERBOSE_LOGGING
                        Log.Verbose($"<< {result}");
#endif
                    }
                    return result;
                }
            }
            catch(WebException e)
            {
                try
                {
                    using(StreamReader s = new StreamReader(e.Response.GetResponseStream()))
                    {
                        var result = s.ReadToEnd();
                        return result;
                    }
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

    }
}