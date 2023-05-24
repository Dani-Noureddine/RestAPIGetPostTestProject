public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public Company? Company { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        else
        {
            User otherUser = (User)obj;
            return (
                Id == otherUser.Id
                && Name == otherUser.Name
                && Username == otherUser.Username
                && Email == otherUser.Email
                && Address!.Street == otherUser.Address!.Street
                && Address.Suite == otherUser.Address.Suite
                && Address.City == otherUser.Address.City
                && Address.Zipcode == otherUser.Address.Zipcode
                && Address.Geo!.Lat == otherUser.Address.Geo!.Lat
                && Address.Geo.Lng == otherUser.Address.Geo.Lng
                && Phone == otherUser.Phone
                && Website == otherUser.Website
                && Company!.Name == otherUser.Company!.Name
                && Company.CatchPhrase == otherUser.Company.CatchPhrase
                && Company.Bs == otherUser.Company.Bs
                );
        }
    }

}