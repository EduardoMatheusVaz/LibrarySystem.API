namespace LibrarySystem.Core.Exceptions;

public class BookAlreadyRented : Exception
{
    
    public BookAlreadyRented() : base("Sorry man, but the book already rented...")
    {

    }

}
