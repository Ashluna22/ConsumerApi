using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using moviesAPI.Models;

namespace ConsumerApiC_.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7223/api/MovieApi/");
        }

        // Method to get all movies
        public async Task<List<Movie>> AllTheMovies() => await _httpClient.GetFromJsonAsync<List<Movie>>("movies");

        public async Task<Movie> AddMovieAsync(Movie newMovie)
        {
            var response = await _httpClient.PostAsJsonAsync("movies", newMovie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Movie>();
        }

        
        public async Task<Movie> UpdateMovieAsync(Movie updatedMovie)
        {
            var response = await _httpClient.PutAsJsonAsync($"movies/{updatedMovie.MovieId}", updatedMovie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Movie>();
        }

        public async Task DeleteMovieAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"movies/" + id);
            response.EnsureSuccessStatusCode();
        }
    }
}
