namespace Medico.Core.Entities
{
    /// <summary>
    /// Determines whether an entity will be auditable
    /// (i.e. whether it will have Created, Modified, etc.)
    /// </summary>
    /// <remarks>
    /// These properties will be added as Shadow Properties.
    /// That way we don't need them to be declared on the model
    /// definitions.
    /// In the words of Scott Hanselman: "I only have so many
    /// key presses in my fingers"
    /// </remarks>
    public interface IAuditable
    {
        
    }
}