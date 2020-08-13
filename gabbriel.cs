using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Member
{
    private string name;
    private int numMonths;
    private double fee;
    private bool offer;
    

    public Member(string name, int numMonths, double fee, bool offer)
    {
        this.name = name;
        this.numMonths = numMonths;
        this.offer = offer;
        this.fee = fee;
    }

    // getter for all the values
    public int getIntNumMonths()
    {
        return numMonths;
    }

    public bool isOffer()
    {
        return offer;
    }

    public string getName()
    {
        return name;
    }

    public double getFee()
    {
        return fee;
    }
    public double getNumMonths()
    {
        return numMonths;
    }
}

class Program
{
    // method to calculate the fee for the number of months
    static double calculateFee(int numMonths)
    {
        // use if else to calculate fee based on the number of months
        if (numMonths <= 6)
            return numMonths * 30.0;
        else if (numMonths <= 12)
            return numMonths * 27.5;
        else
            return numMonths * 25.0;
    }


    static void Main(string[] args)
    {
        // show welcome message
        Console.WriteLine("Welcome to use Sport Membership calculator.");

        // change line 
        Console.WriteLine();

        // the number of customers
        int M = 4;
        // 6 months
        double lessmonths =0;
        double moremonths =0;

        // array to store the members
        Member[] members = new Member[M];

        // loop for M number of values
        for (int i = 1; i <= M; i++)
        {
            // ask for customer name
            Console.Write("Enter the customer name " + i + " : ");

            // read the name
            string name = Console.ReadLine();

            // change line 
            Console.WriteLine();

            // ask for the number of months
            Console.Write("Enter the number of months : ");

            // read the number of months
            int numMonths = Convert.ToInt32(Console.ReadLine());

            // change line 
            Console.WriteLine();

            // read number of months as long as not valid
            while (numMonths < 1 || numMonths > 60)
            {
                // Ask to re enter
                Console.WriteLine("Number of months must be between 1-60.");

                // ask for the number of months
                Console.Write("Enter the number of months : ");

                // read the number of months
                numMonths = Convert.ToInt32(Console.ReadLine());

                // change line 
                Console.WriteLine();
            }

            // ask if user wishes special discount
            Console.Write("Enter yes or no to indicate a special offer : ");

            // to check offer
            string offer = Console.ReadLine();

            // calculate the fee
            double fee = calculateFee(numMonths);


            // change line 
            Console.WriteLine();

            // print
            Console.WriteLine("        The membership of fee from " + name + " is $" + fee);
            Console.WriteLine("------------------------------------------------------------");

            // add member to the array
            members[i - 1] = new Member(name, numMonths, fee, (offer == "no" ? false : true));



        }

        // print the summary 
        Console.WriteLine("              Summary of Mmebership Fee              ");
        Console.WriteLine("=====================================================");
        Console.WriteLine(string.Format("{0,-10} {1,-10} {2,-20} {3,-10} ", "Name", "Months", "Special Offer", "Charge"));
        Console.WriteLine("-----------------------------------------------------");

        // stroe largest
        double maxFee = members[0].getFee();
        string maxFeeName = members[0].getName();

        double minFee = members[0].getFee();
        string minFeeName = members[0].getName();



        // print the details
        for (int i = 0; i < M; i++)
        {
            Console.WriteLine(string.Format("{0,-10} {1,-10} {2,-20} ${3,-10} ", members[i].getName(),
                members[i].getIntNumMonths(), (members[i].isOffer() ? "yes" : "no"), members[i].getFee()));

            // update max 
            if (maxFee < members[i].getFee())
            {
                maxFee = members[i].getFee();
                maxFeeName = members[i].getName();
            }

            if (minFee > members[i].getFee())
            {
                minFee = members[i].getFee();
                minFeeName = members[i].getName();
            }
            if (members[i].getNumMonths() < 6)
            {
                lessmonths = lessmonths+1;
            }
            if (members[i].getNumMonths() >= 6)
            {
                moremonths = moremonths+1;
            }

        }
        Console.WriteLine("-----------------------------------------------------");


        // show min and max spending
        Console.WriteLine("The customer spending most is " + maxFeeName + " $" + maxFee);
        Console.WriteLine();
        Console.WriteLine("The customer spending least is " + minFeeName + " $" + minFee);

        // show 6 months
        Console.WriteLine("The number of member with less than 6 months: " + lessmonths);
        Console.WriteLine();
        Console.WriteLine("The number of member with 6 or more months: " + moremonths);

        Console.ReadLine();
    }
}
