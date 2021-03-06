using System.Collections.Generic;
using NzbDrone.Common.Http;

namespace NzbDrone.Core.ImportLists.LastFm
{
    public class LastFmTagRequestGenerator : IImportListRequestGenerator
    {
        public LastFmTagSettings Settings { get; set; }

        public int MaxPages { get; set; }
        public int PageSize { get; set; }

        public LastFmTagRequestGenerator()
        {
            MaxPages = 1;
            PageSize = 1000;
        }

        public virtual ImportListPageableRequestChain GetListItems()
        {
            var pageableRequests = new ImportListPageableRequestChain();

            pageableRequests.Add(GetPagedRequests());

            return pageableRequests;
        }

        private IEnumerable<ImportListRequest> GetPagedRequests()
        {
            yield return new ImportListRequest(string.Format("{0}&tag={1}&limit={2}&api_key={3}&format=json", Settings.BaseUrl.TrimEnd('/'), Settings.TagId, Settings.Count, Settings.ApiKey), HttpAccept.Json);
        }
    }
}
