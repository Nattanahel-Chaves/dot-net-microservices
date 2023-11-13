using System.ComponentModel.DataAnnotations;

namespace BestBank.AccountService.dtos;

public record UpdateAccount ([Required]string FirstName, [Required]string LastName, [Range(0,500)]decimal Amount);