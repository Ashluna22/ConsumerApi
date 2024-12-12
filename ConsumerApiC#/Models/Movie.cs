using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace moviesAPI.Models;

public partial class Movie
{
    [JsonPropertyName("movieId")]
    public int     MovieId     { get; set; }

    public string  Title       { get; set; } = null!;

    public int?    ReleaseYear { get; set; }

    public string? Director    { get; set; }
}
