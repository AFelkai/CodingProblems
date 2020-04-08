import java.util.*;

public class StockPortfolio
{
  static int numOfPortfolios = 0;

  String name;
  ArrayList<String> companies;
  ArrayList<Integer> shares;
  ArrayList<Transaction> purchases;
  ArrayList<Transaction> sales;

  public StockPortfolio(String name)
  {
    numOfPortfolios++;
    this.name = name;
    companies = new ArrayList<String>();
    shares = new ArrayList<Integer>();
    purchases = new ArrayList<Transaction>();
    sales = new ArrayList<Transaction>();
  }

  public void purchase(String comp, int amt)
  {
    int company = companies.indexOf(comp);
    if(company != -1) //You already own stock in this company
    {
      shares.set(company, shares.get(company) + amt);
    }
    else //New company
    {
      companies.add(comp);
      shares.add(amt);
    }
    purchases.add(new Transaction(comp, amt, true));
    System.out.println(name + " has successfully purchased " + amt + " shares of " + comp + ".");
  }

  public int sell(String comp, int amt)
  {
    if(companies.isEmpty())
    {
      System.out.println(name + " doesn't own any stocks.");
      return 0;
    }
    int company = companies.indexOf(comp);
    if(company != -1) //You do own this company
    {
      if(amt <= shares.get(company)) { //You have enough shares to sell
        shares.set(company, (shares.get(company) - amt));
        sales.add(new Transaction(comp, amt, false));
        System.out.println(name + " successfully sold " + amt + " shares of " + comp + ".");
        return 1;
      }
      else //You don't have enough shares to sell
      {
        System.out.println(name + " is trying to sell " + amt + " shares of " + comp + ", but " + name + " only owns " + shares.get(company) + " shares.");
        return 0;
      }
    }
    else //You don't own shares in this company
    {
      System.out.println("You don't own any shares of "+ comp +".");
      return 0;
    }
  }

  public ArrayList<String> getCompanies()
  {
    return companies;
  }

  public ArrayList<Integer> getShares()
  {
    return shares;
  }

  public ArrayList<Transaction> getPurcahses()
  {
    return purchases;
  }
  
  public ArrayList<Transaction> getSells()
  {
    return sales;
  }

  public static int getNumOfPortfolios()
  {
    return numOfPortfolios;
  }

  @Override
  public String toString()
  {
    String stringed = "";
    stringed =  "Name: " + name + "\nPositions: \n";
    for(int i = 0; i < companies.size(); i++)
    {
      stringed += companies.get(i) + " | " + shares.get(i) + "\n";
    }
    return stringed;
  }
}