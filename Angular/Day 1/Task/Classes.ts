interface IAccount {
  DateOfOpening;

  AddCustomer(): void;
  RemoveCustomer(): void;
}

class Account {
  public AccNo: String;
  public Balance: Number;

  constructor(accNo, balance) {
    this.AccNo = accNo;
    this.Balance = balance;
  }

  DebitAmount(): Number {
    return 0;
  }
  CreditAmount(): Number {
    return 0;
  }
  GetBalance(): Number {
    return this.Balance;
  }
}

class SavingAcoount extends Account implements IAccount {
  DateOfOpening = 0;
  MinBalance: Number;
  AddCustomer() {}
  RemoveCustomer() {}
}

class CurrentAccount extends Account implements IAccount {
  DateOfOpening = 0;
  InterestRate: Number;
  AddCustomer() {}
  RemoveCustomer() {}
}
