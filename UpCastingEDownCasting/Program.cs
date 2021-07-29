using System;
using UpCastingEDownCasting.Entities;

namespace UpCastingEDownCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1001, "Alex", 0.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING -> Conversão da Sub-Classe para a Super-Classe:
            Account acc1 = bacc; //Essa conversão é totalmente aceita pelo compilador pois a relação de herança "é 1", sendo então a SubClasse BusinessAccount é também uma Account pois extende(herda) de Account que é sua Super classe
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0); // Mesma regra cabe nesse exemplo e...
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01); // Nesse também pois são sub classes da Super classe account

            //DownCasting -> Conversão da Super-Classe para a Sub-Classe:
            BusinessAccount acc4 = (BusinessAccount)acc2; //Mesma linha de raciocínio do UPCASTING, porém nesse caso é necessário realizar a conversão explícita de Casting.
            acc4.Loan(100.0); //Nesse caso o Método .Loan é possível de se utilizar pois mesmo originalmente a variável "acc2" pertencer a Superclasse Account ela foi convertida para uma subclasse businessAccount tornando possível se utilizar o método.

            // Irá gerar um ERRO -> BusinessAccount acc5 = (BusinessAccount)acc3; -> Nesse caso é importante notar que mesmo a conversão ter sido aceita pelo compilador a Sub-Classe SavingsAccount não é compatível com a outra Sub-Classe BusinessAccount ocasionando um erro apenas quando foi executado o programa criando uma execessão. O compilador não consegue prever esse tipo de erro de conversão pois as duas sub-classe possui métodos diferente uma da outra ao contrário da Super-Classe.
        
            if (acc3 is BusinessAccount) // Para evitar o erro de execução acima devemos  com a palavrinhas "IS" os tipos da variável para conferir se são compatíveis para o DownCasting
            {
                BusinessAccount acc5 = (BusinessAccount)acc3; //Nesse caso não será executado essa conversão pois os tipos não são compatíveis comforme explicação acima.
            } else if (acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = acc3 as SavingsAccount; //Sintaxe alternativa, ou Outra maneira de realizar o casting é utilizando a palavria "AS" ao invés de utilizar os (tipo da variável)
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }
    }
}
