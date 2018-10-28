using Newtonsoft.Json;
using RestSharp;
using System;

namespace TMDBClassLibrary.Service
{
    public class MovieService
    {
        private const string LIST_POPULAR = @"https://api.themoviedb.org/3/movie/popular?api_key={0}&language=en-US&page={1}";

        private const string LIST_TOP_RATED = @"https://api.themoviedb.org/3/movie/top_rated?api_key={0}&language=en-US&region=CA|US&page={1}";

        private const string LIST_IN_THEATERS = @"https://api.themoviedb.org/3/movie/now_playing?api_key={0}&language=en-US&page={1}"; 

        private const string LIST_UPCOMING = @"https://api.themoviedb.org/3/movie/upcoming?api_key={0}&language=en-US&region=CA|US&page={1}";

        private const string MOVIE_INFO = @"https://api.themoviedb.org/3/movie/{1}?api_key={0}&language=en-US&append_to_response=credits,videos";

        private const string LIST_RECOMMENDATIONS = @"https://api.themoviedb.org/3/movie/{2}/recommendations?api_key={0}&language=en-US&page={1}";

        private const string LIST_MOVIE_SEARCH = @"https://api.themoviedb.org/3/search/movie?api_key={0}&language=en-US&query={2}&page={1}&include_adult=false";


        public RootObject FindMovieSearch(int page, string searchText, string ApiKey)
        {
            var url = string.Format(LIST_MOVIE_SEARCH, ApiKey, page, searchText);
            string jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }

        public RootObject FindRecommendations(int page, int id, string ApiKey)
        {
            var url = string.Format(LIST_RECOMMENDATIONS, ApiKey, page, id);
            string jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }


        public RootObject FindPopularMovies(int page, string ApiKey)
        {

            var url = string.Format(LIST_POPULAR, ApiKey, page);
            string jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }

        public RootObject FindTopRatedMovies(int page, string ApiKey)
        {
            var url = string.Format(LIST_TOP_RATED, ApiKey, page);
            string jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }

        public RootObject FindMoviesInTheaterList(int page, string ApiKey)
        {
            var url = string.Format(LIST_IN_THEATERS, ApiKey, page);
            string jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }


        public RootObject FindUpcomingMoviesList(int page, string ApiKey)
        {
            var url = string.Format(LIST_UPCOMING, ApiKey, page);
            var jsonResponse = GetJsonResponse(url);
            RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return results;
        }


        public Movie MovieInfo(int MovieID, string ApiKey)
        {
            var url = string.Format(MOVIE_INFO, ApiKey, MovieID);
            var jsonResponse = GetJsonResponse(url);
            Movie results = JsonConvert.DeserializeObject<Movie>(jsonResponse);
            return results;
        }


        private static string GetJsonResponse(string url)
        {

            var client = new RestClient();

            client.BaseUrl = new Uri(url);

            var request = new RestRequest();

            return client.Execute(request).Content;

        }

    }
}