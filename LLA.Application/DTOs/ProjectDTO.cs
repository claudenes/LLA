using LLA.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LLA.Application.DTOs;

public class ProjectDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Titulo is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Titulo")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "The Descricao is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Descricao")]
    public string? Descricao { get; set; }

    public DateTime DtCriacao { get; set; }
}
