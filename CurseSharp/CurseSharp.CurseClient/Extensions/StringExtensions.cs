using System.Text;

namespace CurseSharp.CurseClient.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Normalizes a word to improve string comparison matches when substitutions occur. Intended to help resolve
        /// issues stemming from umlauts and other trouble characters
        /// </summary>
        /// <param name="sourceString">Word that needs normalization</param>
        /// <param name="form">Normalization Form</param>
        /// <param name="toLower">Bool y/n if the string needs to have ToLower called</param>
        /// <param name="removePunctuation">Bool y/n if the string needs to have punctuation removed</param>
        /// <returns></returns>
        public static string NormalizeForComparison(this string sourceString, NormalizationForm form = NormalizationForm.FormC, bool toLower = true, bool removePunctuation = true)
        {
            string result = sourceString.Normalize(form);
            
            if(toLower)
            {
                result = sourceString.ToLower();
            }

            if(removePunctuation)
            {
                var sb = new StringBuilder();

                foreach(char c in result)
                {
                    if(!char.IsPunctuation(c))
                    {
                        sb.Append(c);
                    }
                }

                result = sb.ToString();
                sb.Clear();
                sb = null;
            }

            return result;
        }
    }
}
