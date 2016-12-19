using System.DirectoryServices;

namespace IdeaTinder.Models
{
    public class Utils
    {
        public static SearchResult FindAccountByType(string searchKey, string searchVal)
        {
            if (string.IsNullOrEmpty(searchVal))
                return null;

            string filter = string.Format(searchKey, searchVal);

            using (var gc = new DirectoryEntry("GC:"))
            {
                foreach (DirectoryEntry z in gc.Children)
                {
                    using (var root = z)
                    {
                        using (var searcher = new DirectorySearcher(root, filter, new string[] { "samAccountName", "displayName" }))
                        {
                            searcher.ReferralChasing = ReferralChasingOption.All;
                            var result = searcher.FindOne();
                            return result;
                        }
                    }
                }
            }
            return null;
        }
    }
}