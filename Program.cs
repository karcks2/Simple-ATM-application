using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstname;
    string lastname;
    double balance;

    public cardHolder(string cardnum, int pin, string firstname, string lastname, double balance)
    {
        this.cardNum = cardnum;
        this.pin = pin;
        this.firstname = firstname;
        this.lastname = lastname;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstname()
    {
        return firstname;
    }

    public string getLastname()
    {
        return lastname;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newcardnum)
    {
        cardNum = newcardnum;
    }

    public void setPin(int newpin)
    {
        pin = newpin;
    }

    public void setFirstname(string newfirstname)
    {
        firstname = newfirstname;
    }

    public void setLastname(string newlastname)
    {
        lastname = newlastname;
    }

    public void setBalance(double newbalance)
    {
        balance = newbalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is:" + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw");
            double withdrawl = double.Parse(Console.ReadLine());
            //Check if the user has inof money
            if(currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("you don t have that much money:(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("Thank you have a nice day");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234", 11, "John", "Griffith", 150.31));

        // Promt User
        Console.WriteLine("Wlcome to SimpleATM");
        Console.WriteLine("Please inset your depit card:");
        string depitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                depitCardNum = Console.ReadLine();
                // cehck against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == depitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("PLease enter your pin: ");
        int userPin = 0;
        while (true)
        {

            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome" + currentUser.getFirstname());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1 ) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if( option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you have a nice day");
    }   

}