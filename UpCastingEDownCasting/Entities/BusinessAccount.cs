namespace UpCastingEDownCasting.Entities
{
    class BusinessAccount : Account //Aplicando a herança de uma superclasse (Account) para a Subclasse (BusinessAccount) nesse exemplo
    {
        public double LoanLimit { get; set; }

        public BusinessAccount() {}

        public BusinessAccount(int number, string holder, double balance, double loanLimit) : base(number, holder, balance) //Utilizando os atributos e construtores da Super classe que foi extendida para essa Sub classe
        {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount)
        {
            if (amount <= LoanLimit)
            {
                Balance += amount;
            }
        }
    }
}