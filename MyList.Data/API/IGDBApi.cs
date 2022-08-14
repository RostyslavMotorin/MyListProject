using IGDB;
using IGDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Data.API
{
    public class IGDBApi
    {
        private const string CLIENT_ID = "yw44q8nuv81dcw0l16m5wif8su08k3";
        private const string CLIENT_SECRET = "sbziyv83embgolexhta47v93rv0qbk";
        public async Task<IEnumerable<Game>> GetGameCollection(string search)
        {
            var igdb = new IGDBClient(CLIENT_ID,CLIENT_SECRET);
            try
            {
                var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields *;search \"" + search + "\";");
                return games;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return null;
        }
    }
}
