using LLA.Domain.Validation;

namespace LLA.Domain.Entities;

public sealed class Projeto : Entity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DtCriacao { get; private set; }

    public Projeto(string titulo, string descricao, DateTime dtCriacao)
    {
        ValidateDomain(titulo, descricao, dtCriacao);
    }

    public Projeto(int id, string titulo, string descricao, DateTime dtCriacao)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(titulo, descricao, dtCriacao);
    }

    public void Update(string titulo, string descricao, DateTime dtCriacao)
    {
        ValidateDomain(titulo, descricao, dtCriacao);
        
    }

    private void ValidateDomain(string titulo, string descricao, DateTime dtCriacao)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(titulo),
            "Invalid name. Name is required");

        DomainExceptionValidation.When(titulo.Length < 3,
            "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
            "Invalid description. Description is required");

        DomainExceptionValidation.When(descricao.Length < 5,
            "Invalid description, too short, minimum 5 characters");



        Titulo = titulo;
        Descricao = descricao;
        DtCriacao = dtCriacao;

    }
}
