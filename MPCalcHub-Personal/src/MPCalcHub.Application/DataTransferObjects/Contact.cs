using MPCalcHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MPCalcHub.Application.DataTransferObjects
{
    public class Contact : BaseModel
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ddd")]
        public int DDD { get; set; }

        [Phone(ErrorMessage = "O número de telefone inserido não é válido.")]
        [Required(ErrorMessage = "O campo de telefone é obrigatório.")]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "O campo de e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]
        public string Email { get; set; }

        public Contact() : base() { }

        public Contact(Guid? id, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool removed, DateTime? removedAt, Guid? removedBy, string name, string phoneNumber, string email)
        {
            Id = id;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            Removed = removed;
            RemovedAt = removedAt;
            RemovedBy = removedBy;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

}
