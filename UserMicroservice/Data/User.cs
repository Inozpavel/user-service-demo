using System;

namespace UserMicroservice.Data;

public class User
{
    public User(string firstName, string lastName, string patronymic) : this()
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public User()
    {
        Id = Guid.NewGuid();
        Created = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public DateTimeOffset Created { get; set; }
}
