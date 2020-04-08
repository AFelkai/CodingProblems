import java.time.Instant;
class Transaction
{
  String company;
  int amount;
  Instant timestamp;
  String buySell;

  public Transaction(String comp, int amt, boolean buy)
  {
    company = comp;
    amount = amt;
    timestamp = Instant.now();
    if(buy) //Buy action
    {
      buySell = "Purchase\n--------";
    }
    else
    {
      buySell = "Sell\n----";
    }
  }

  @Override
  public String toString()
  {
    return ("\n" + buySell + "\nCompany: " + company + "\nAmount: " + amount + "\nTimestamp: " + timestamp);
  }
}
