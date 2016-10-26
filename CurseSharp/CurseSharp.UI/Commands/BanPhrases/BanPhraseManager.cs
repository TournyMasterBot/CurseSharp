using CurseSharp.CurseClient.Extensions;
using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.BotModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CurseSharp.UI.Commands.BanPhrases
{
    public static class BanPhraseManager
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static Dictionary<string, BanPhraseModel> BanPhrases = new Dictionary<string, BanPhraseModel>();

        public static void LoadBanPhrases()
        {
            try
            {
                var data = File.ReadAllText($@"{path}Commands\BanPhrases\BanPhraseList.ini", Encoding.UTF8);
                if(!string.IsNullOrWhiteSpace(data))
                {
                    var banPhrases = JsonConvert.DeserializeObject<Dictionary<string, BanPhraseModel>>(data);
                    if(BanPhrases != null && banPhrases.Count > 0)
                    {
                        BanPhrases = banPhrases;
                    }
                    else
                    {
                        LoadEmptyPhrase();
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        public static void LoadEmptyPhrase()
        {
            try
            {
                var data = File.ReadAllText($@"{path}Commands\BanPhrases\EmptyBanPhrase.ini", Encoding.UTF8);
                if(!string.IsNullOrWhiteSpace(data))
                {
                    var banPhrases = JsonConvert.DeserializeObject<Dictionary<string, BanPhraseModel>>(data);
                    if(BanPhrases != null)
                    {
                        BanPhrases = banPhrases;
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        public static BanPhraseModel[] GetBanPhrases()
        {
            var phrases = BanPhrases.Values.ToArray();
            if(phrases.Length == 0)
            {
                LoadEmptyPhrase();
            }
            phrases = BanPhrases.Values.OrderBy(x => x.BadPhrase).ToArray();
            return phrases;
        }

        public static void SaveBanPhrases()
        {
            if(BanPhrases.Keys.Contains(""))
            {
                BanPhrases.Remove("");
            }
            File.WriteAllText($@"{path}Commands\BanPhrases\BanPhraseList.ini", JsonConvert.SerializeObject(BanPhrases, Formatting.Indented));
        }

        public static void CreateBanPhrase(BanPhraseModel phraseDetails)
        {
            if(BanPhrases.Keys.Contains(phraseDetails.BadPhrase))
            {
                BanPhrases[phraseDetails.BadPhrase] = phraseDetails;
            }
            else
            {
                BanPhrases.Add(phraseDetails.BadPhrase, phraseDetails);
            }
        }

        public static void DeleteBanPhrase(BanPhraseModel phraseDetails)
        {
            var itemsToRemove = new HashSet<string>();

            foreach(var pair in BanPhrases)
            {
                if(pair.Key.Equals(phraseDetails.BadPhrase))
                {
                    itemsToRemove.Add(pair.Key);
                }
            }

            foreach(var item in itemsToRemove)
            {
                BanPhrases.Remove(item);
            }

            if(BanPhrases.Count == 0)
            {
                LoadEmptyPhrase();
            }
            SaveBanPhrases();
        }

        public static BanWordHandlerModel CompareToBanWords(this string sourceLine)
        {
            BanWordHandlerModel result = null;
            sourceLine = sourceLine.NormalizeForComparison();
            foreach(var phrase in BanPhrases.Values)
            {
                if(sourceLine.IndexOf(phrase.BadPhrase) > -1)
                {
                    // Match found in some form, apply exact match or contains logic

                    switch(phrase.CheckType)
                    {
                        // Do a regex match to make sure there's an exact match found
                        case BanPhraseCheckType.ExactMatch:
                        {
                            if(Regex.IsMatch(sourceLine, $@"(?:^|\s)({phrase.BadPhrase.NormalizeForComparison()}?)(?:\s|$)"))
                            {
                                if(result == null)
                                {
                                    result = new BanWordHandlerModel();
                                    result.ActionRequired = phrase.Response;
                                    result.ActionDuration = phrase.ResponseDuration;
                                    result.IsBadWord = true;
                                    if(phrase.Response.HasFlag(BanPhraseResponse.Edit))
                                    {
                                        var regexMatch = Regex.Match(sourceLine, $@"(.*)(?:^|\s)({phrase.BadPhrase}?)(?:\s|$)(.*)", RegexOptions.IgnoreCase);
                                        result.EditMessage = $"{regexMatch.Groups[1].Captures[0].Value} {regexMatch.Groups[3].Captures[0].Value}";
                                    }
                                }
                                // Previous data available, add any missing flags
                                if(result != null)
                                {
                                    if(result.ActionRequired < phrase.Response)
                                    {
                                        result.ActionRequired = phrase.Response;
                                    }

                                    if(result.ActionDuration < phrase.ResponseDuration)
                                    {
                                        result.ActionDuration = phrase.ResponseDuration;
                                    }
                                }
                            }
                            
                            break;
                        }
                        // An exact match isn't required since the partial match flag is set
                        case BanPhraseCheckType.ContainsMatch:
                        {
                            if(result == null)
                            {
                                result = new BanWordHandlerModel();
                                result.ActionRequired = phrase.Response;
                                result.ActionDuration = phrase.ResponseDuration;
                                result.IsBadWord = true;
                                if(phrase.Response.HasFlag(BanPhraseResponse.Edit))
                                {
                                    var regexMatch = Regex.Match(sourceLine, $@"(.*)(?:^|\s)(.*{phrase.BadPhrase}.*?)(?:\s|$)(.*)", RegexOptions.IgnoreCase);
                                    result.EditMessage = $"{regexMatch.Groups[1].Captures[0].Value} {regexMatch.Groups[3].Captures[0].Value}"; // Be careful not to return an "" response, use at least one space
                                }

                            }
                            // Previous data available, add any missing flags
                            if(result != null)
                            {
                                if(result.ActionRequired < phrase.Response)
                                {
                                    result.ActionRequired = phrase.Response;
                                }

                                if(result.ActionDuration < phrase.ResponseDuration)
                                {
                                    result.ActionDuration = phrase.ResponseDuration;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
