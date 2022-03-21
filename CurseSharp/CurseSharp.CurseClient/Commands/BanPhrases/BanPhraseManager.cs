using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.BotModels;
using System;
using System.Collections.Generic;

namespace CurseSharp.CurseClient.Commands.BanPhrases
{
    public static class BanPhraseManager
    {
        private static HashSet<BanPhraseModel> BanPhrases = new HashSet<BanPhraseModel> ();

        public static void LoadBanPhrases()
        {
            // Load sample
            var banPhrase1 = new BanPhraseModel()
            {
                IsHomoglyphParent = true,
                BadPhraseID = 1,
                BadPhraseHomoglyphID = 1,
                BadPhrase = "fuckedit",
                Response = BanPhraseResponse.Edit,
                CheckType = BanPhraseCheckType.ExactMatch,
                ResponseDuration = 0
            };
            BanPhrases.Add(banPhrase1);

            var banPhrase2 = new BanPhraseModel()
            {
                IsHomoglyphParent = true,
                BadPhraseID = 1,
                BadPhraseHomoglyphID = 1,
                BadPhrase = "fuckdelete",
                Response = BanPhraseResponse.Delete,
                CheckType = BanPhraseCheckType.ExactMatch,
                ResponseDuration = 0
            };
            BanPhrases.Add(banPhrase2);

            var banPhrase3 = new BanPhraseModel()
            {
                IsHomoglyphParent = true,
                BadPhraseID = 1,
                BadPhraseHomoglyphID = 1,
                BadPhrase = "fuckeditcontains",
                Response = BanPhraseResponse.Edit,
                CheckType = BanPhraseCheckType.ContainsMatch,
                ResponseDuration = 0
            };
            BanPhrases.Add(banPhrase3);

            var banPhrase4 = new BanPhraseModel()
            {
                IsHomoglyphParent = true,
                BadPhraseID = 1,
                BadPhraseHomoglyphID = 1,
                BadPhrase = "fuckdeletecontains",
                Response = BanPhraseResponse.Delete,
                CheckType = BanPhraseCheckType.ContainsMatch,
                ResponseDuration = 0
            };
            BanPhrases.Add(banPhrase4);
        }

        public static void SaveBanPhrases()
        {

        }

        public static void CreateBanPhrase(BanPhraseModel phraseDetails)
        {

        }

        public static BanWordHandlerModel CompareToBanWords(this string source)
        {
            BanWordHandlerModel result = null;
            foreach(var phrase in BanPhrases)
            {
                if(phrase.CheckType == BanPhraseCheckType.ExactMatch)
                {
                    if(source == phrase.BadPhrase)
                    {
                        // No previous data available
                        if(result == null)
                        {
                            result = new BanWordHandlerModel();
                            result.ActionRequired = phrase.Response;
                            result.ActionDuration = phrase.ResponseDuration;
                            result.IsBadWord = true;
                        }
                        // Previous data available, add any missing flags
                        if(result != null)
                        {
                            if(!phrase.Response.HasFlag(phrase.Response))
                            {
                                result.ActionRequired &= phrase.Response;
                            }

                            if(result.ActionDuration < phrase.ResponseDuration)
                            {
                                result.ActionDuration = phrase.ResponseDuration;
                            }
                        }
                    }
                }
                else if(phrase.CheckType == BanPhraseCheckType.ContainsMatch)
                {
                    if(source.Contains(phrase.BadPhrase))
                    {
                        // No previous data available
                        if(result == null)
                        {
                            result = new BanWordHandlerModel();
                            result.ActionRequired = phrase.Response;
                            result.ActionDuration = phrase.ResponseDuration;
                            result.IsBadWord = true;
                        }
                        // Previous data available, add any missing flags
                        if(result != null)
                        {
                            if(!phrase.Response.HasFlag(phrase.Response))
                            {
                                result.ActionRequired &= phrase.Response;
                            }

                            if(result.ActionDuration < phrase.ResponseDuration)
                            {
                                result.ActionDuration = phrase.ResponseDuration;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
