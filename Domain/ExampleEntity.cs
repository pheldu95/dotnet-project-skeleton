using System;

namespace Domain;

public class ExampleEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string Title { get; set; }
}
