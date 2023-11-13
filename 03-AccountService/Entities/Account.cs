namespace BestBank.AccountService.Entities{
    public class Account
    {
        public Guid Id {get;set;}
        public string ?FirstName {get;set;}
        public string ?LastName {get;set;}
        public decimal Balance {get;set;}
        public DateTimeOffset CreatedDate {get;set;}
    } 
}