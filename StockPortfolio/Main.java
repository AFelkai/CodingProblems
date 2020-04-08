import java.util.*;
class Main {

  public static void main(String[] args)
  {

    StockPortfolio portfolio = new StockPortfolio("Aaron Felkai");
    StockPortfolio portfolio2 = new StockPortfolio("Shimon Tanami");

    portfolio.purchase("Microsoft", 5);
    portfolio.purchase("Apple", 176);
    portfolio.sell("Apple", 150);

    ArrayList<Transaction> purchases = portfolio.getPurcahses();
    ArrayList<Transaction> sells = portfolio.getSells();

    for(Transaction purch : purchases)
    {
      System.out.println(purch);
    }

    for(Transaction purch : sells)
    {
      System.out.println(purch);
    }

    System.out.println(portfolio);
    System.out.println(StockPortfolio.getNumOfPortfolios());
    System.out.println("HELLO WORLD");
  }
}