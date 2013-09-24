namespace WithFormat.DateTime
{
    public interface IAmPmFormatter
    {
        DateTimeFormatBuilder WithSingleCharacter();
        DateTimeFormatBuilder WithTwoCharacters();
    }
}