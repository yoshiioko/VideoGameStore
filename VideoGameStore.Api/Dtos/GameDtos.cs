using System.ComponentModel.DataAnnotations;

namespace VideoGameStore.Api.Dtos;

public record GameDtoV1(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record GameDtoV2(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    decimal RetailPrice,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    [StringLength(20)]
    string Genre,

    [Range(1, 100)]
    decimal Price,
    DateTime ReleaseDate,

    [Url]
    [StringLength(100)]
    string ImageUri
);

public record UpdateGameDto(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    [StringLength(20)]
    string Genre,

    [Range(1, 100)]
    decimal Price,
    DateTime ReleaseDate,

    [Url]
    [StringLength(100)]
    string ImageUri
);
