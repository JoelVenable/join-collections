using System;
using System.Collections.Generic;
using System.Linq;

namespace join_collections
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
            };

      List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"},
        };


      IEnumerable<ReportItem> millionaireReport = from customer in customers
                                                  where customer.Balance >= 1000000
                                                  orderby customer.Name.Split(' ')[1] ascending
                                                  join bank in banks on customer.Bank equals bank.Symbol into bankJoin
                                                  from bank in bankJoin
                                                  select new ReportItem()
                                                  {
                                                    CustomerName = customer.Name,
                                                    BankName = bank.Name,
                                                  };

      millionaireReport.ToList().ForEach(millionaire =>
      {
        System.Console.WriteLine($"{millionaire.CustomerName} at {millionaire.BankName}");
      });
    }
  }
}
